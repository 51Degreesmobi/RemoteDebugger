using RemoteDebugger.Responses;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Stack<Notification> Notifications = new Stack<Notification>();
        private DataContractJsonSerializerSettings settings;

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
                //socket.Open();

                settings = createJsonSettings();
            }
        }

        DataContractJsonSerializerSettings createJsonSettings()
        {
            DataContractJsonSerializerSettings settings =
                        new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            var knownTypes = new List<Type>();
            knownTypes.Add(typeof(Commands.Timeline.TimelineEvent));
            settings.KnownTypes = knownTypes;

            return settings;
        }

        public async Task<Response> Send(Commands.Command command)
        {
            
            int id = commandsSent;
            var mes = command.GetMessage(id);
            commandsSent++;
            bool hasResponse = false;
            if (socket.State != WebSocketState.Open)
            {
                if (socket.State == WebSocketState.None || socket.State == WebSocketState.Closed)
                {
                    socket.Open();
                    while (socket.State == WebSocketState.Connecting)
                        await Task.Delay(100);

                    if (socket.State != WebSocketState.Open)
                        throw new Exception("Socket could not be opened.");
                }
            }
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

        private void addNotification(Notification notification)
        {
            lock (Notifications)
            {
                Notifications.Push(notification);
            }
        }

        public Notification GetNotification()
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
                if (e.Message.Contains("id"))
                {
                    DataContractJsonSerializer serializer =
                            new DataContractJsonSerializer(typeof(Response), settings);

                    var response = (Response)serializer.ReadObject(ms);
                    addResponse(response);
                }
                else
                {
                    File.AppendAllText("debug.txt", e.Message + Environment.NewLine);
                    DataContractJsonSerializer serializer =
                            new DataContractJsonSerializer(typeof(Notification), settings);

                    var response = (Notification)serializer.ReadObject(ms);
                    addNotification(response);
                }
            }
        }

        public void Close()
        {
            if (socket.State == WebSocketState.Open)
            {
                socket.Close();
            }
        }

        //~RemoteDebugger()
        //{
        //    if (socket.State == WebSocketState.Open)
        //    {
        //        socket.Close();
        //    }
        //}
    }
}
