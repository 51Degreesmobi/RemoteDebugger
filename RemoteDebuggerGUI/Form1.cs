using RemoteDebugger.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDebuggerGUI
{
    public partial class Form1 : Form
    {
        RemoteDebugger.RemoteDebugger debugger;

        class ResourceInfo
        {
            public int PageWeight;
            public int PageWeightCompressed;
        }


        /// <summary>
        /// The time to wait in between requests in seconds.
        /// </summary> desk
        private int waitTime = 20;

        public Form1()
        {
            InitializeComponent();
            debugger = new RemoteDebugger.RemoteDebugger("ws://localhost:9222/devtools/page/1/");
        }

        private async void processBut_Click(object sender, EventArgs e)
        {
            var urls = urlsTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(u => u.StartsWith("http://") || u.StartsWith("https://") ? u : "http://" + u).ToArray();
            var responses = new Dictionary<string, List<RemoteDebugger.Commands.Network.Response>>();
            foreach (var url in urls)
            {
                
                responses.Add(url, new List<RemoteDebugger.Commands.Network.Response>());
                var cacheRes = await debugger.Send(Network.SetCacheDisabled(true));
                await debugger.Send(Network.Enable());
                
                await debugger.Send(Page.Navigate(url));

                await Task.Delay(waitTime * 1000);

                await debugger.Send(Network.Disable());
                var data = new Dictionary<string, ResourceInfo>();
                while (debugger.GetNotificationCount() > 0)
                {

                    var notification = debugger.GetNotification();
                    switch (notification.Method)
                    {
                        case "Network.dataReceived":
                            {
                                try
                                {
                                    int dataLength = (int)notification.Params["dataLength"];
                                    int encodedDataLength = (int)notification.Params["encodedDataLength"];
                                    string requestId = (string)notification.Params["requestId"];
                                    if (data.ContainsKey(requestId))
                                    {
                                        data[requestId].PageWeight += dataLength;
                                        data[requestId].PageWeightCompressed += encodedDataLength;
                                    }
                                    else
                                        data.Add(requestId, new ResourceInfo() { PageWeight = dataLength, PageWeightCompressed = encodedDataLength });
                                }
                                catch (Exception ex)
                                {
                                    
                                }
                                break;
                            }

                        case "Network.loadingFailed":
                            {
                                try
                                {
                                    string requestId = (string)notification.Params["requestId"];
                                    if (!data.ContainsKey(requestId))
                                        data.Add(requestId, new ResourceInfo());
                                }
                                catch (Exception ex)
                                {
                                    
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
                dgvResults.Rows.Add(url, data.Keys.Count, data.Sum(d => d.Value.PageWeight).ToString("N0"), data.Sum(d => d.Value.PageWeightCompressed).ToString("N0"));
            }

            //debugger.Close();
            int x = 0;
            x++;
        }

    }
}
