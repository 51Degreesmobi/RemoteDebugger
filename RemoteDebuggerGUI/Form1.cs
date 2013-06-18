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

            foreach (var url in urls)
            {
                await debugger.Send(Page.Navigate(url));
                Thread.Sleep(1000);
            }
        }
    }
}
