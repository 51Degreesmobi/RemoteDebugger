using RemoteDebugger.Responses;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace RemoteDebugger
{
    public class RemoteDebugger
    {
        private WebSocket4Net.WebSocket socket;
        private int commandsSent = 1;
        private Dictionary<int, Response> responses = new Dictionary<int, Response>();
        private Stack<Response> Notifications = new Stack<Response>();

        public RemoteDebugger(string url)
        {
            Uri uri = new Uri(url);
            if (uri.Scheme != "ws")
            {
                throw new ArgumentException("Remote debugging must use a ws url.");
            }
            else
            {
                // open web socket
                var uriS = uri.ToString();
                // trailing backslash must be removed
                uriS = uriS.TrimEnd('/');
                socket = new WebSocket(uriS); // ("ws://localhost:9222/devtools/page/1");
                socket.Opened += new EventHandler(socketOpened);
                //socket.Error += new EventHandler<ErrorEventArgs>(socketError);
                socket.Closed += new EventHandler(socketClosed);
                socket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(socketMessageReceived);
                socket.Open();
            }
        }

        public async Task<Response> Send(Commands.Command command)
        {
            int id = commandsSent;
            var mes = command.GetMessage(id);
            commandsSent++;
            bool hasResponse = false;
            socket.Send(mes);
            while (!hasResponse)
            {
                await Task.Delay(10).ConfigureAwait(false);
                lock (responses)
                {
                    hasResponse = responses.ContainsKey(id);
                }
            }
            var response = responses[id];
            removeResponse(id);
            return response;
        }

        private void addResponse(Response response)
        {
            if (response.Id != null)
            {
                lock (responses)
                {
                    int id = (int)response.Id;
                    responses.Add(id, response);
                }
            }
        }

        private void addNotification(Response response)
        {
            lock (Notifications)
            {
                Notifications.Push(response);
            }
        }

        public Response GetNotification()
        {
            if (GetNotificationCount() > 0)
            {
                return Notifications.Pop();
            }
            else
            {
                return null;
            }
        }

        public int GetNotificationCount()
        {
            return Notifications.Count;
        }

        private void removeResponse(int id)
        {
            lock (responses)
            {
                responses.Remove(id);
            }
        }


        void socketOpened(object sender, EventArgs e)
        {
            
        }

        //void socketError(object sender, ErrorEventArgs e)
        //{
        //    throw new Exception();
        //}

        void socketClosed(object sender, EventArgs e)
        {
            
            Console.WriteLine("Connection Closed.");
        }

        void socketMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            using (var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(e.Message)))
            {
                DataContractJsonSerializerSettings settings =
                        new DataContractJsonSerializerSettings();
                settings.UseSimpleDictionaryFormat = true;

                DataContractJsonSerializer serializer =
                        new DataContractJsonSerializer(typeof(Response), settings);

                var response = (Response)serializer.ReadObject(ms);
                if (response.Id != null)
                {
                    addResponse(response);
                }
                else
                {
                    addNotification(response);
                }
            }
        }

        ~RemoteDebugger()
        {
            if (socket.State == WebSocketState.Open)
            {
                socket.Close();
            }
        }
    }
}
