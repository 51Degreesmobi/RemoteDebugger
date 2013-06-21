using RemoteDebugger.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RemoteDebuggerGUI
{
    public partial class Form1 : Form
    {
        RemoteDebugger.RemoteDebugger debugger;
        public Form1()
        {
            InitializeComponent();
            debugger = new RemoteDebugger.RemoteDebugger("ws://localhost:9222/devtools/page/1/");
        }

        private async void processBut_Click(object sender, EventArgs e)
        {
            var urls = urlsTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var responses = new Dictionary<string, List<RemoteDebugger.Commands.Network.Response>>();
            foreach (var url in urls)
            {
                responses.Add(url, new List<RemoteDebugger.Commands.Network.Response>());
                var cacheRes = await debugger.Send(Network.SetCacheDisabled(true));
                await debugger.Send(Network.Enable());
                
                await debugger.Send(Page.Navigate(url));

                // wait 10 seconds
                Thread.Sleep(10000);

                await debugger.Send(Network.Disable());
                Dictionary<string, int> data = new Dictionary<string, int>();
                while (debugger.GetNotificationCount() > 0)
                {

                    var notification = debugger.GetNotification();
                    switch (notification.Method)
                    {
                        case "Network.dataReceived":
                            {
                                try
                                {
                                    // int dataLength = (int)notification.Params["dataLength"];
                                    int dataLength = (int)notification.Params["encodedDataLength"];
                                    string requestId = (string)notification.Params["requestId"];
                                    if (data.ContainsKey(requestId))
                                        data[requestId] += dataLength;
                                    else
                                        data.Add(requestId, dataLength);
                                }
                                catch (Exception ex)
                                {
                                    int k = 0;
                                    k++;
                                }
                                break;
                            }

                        case "Network.loadingFailed":
                            {
                                try
                                {
                                    string requestId = (string)notification.Params["requestId"];
                                    if (data.ContainsKey(requestId))
                                        data[requestId] += 0;
                                    else
                                        data.Add(requestId, 0);
                                }
                                catch (Exception ex)
                                {
                                    int k = 0;
                                    k++;
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
                dgvResults.Rows.Add(url, data.Keys.Count, data.Sum(d => d.Value));
            }

            //debugger.Close();
            int x = 0;
            x++;
        }

    }
}
