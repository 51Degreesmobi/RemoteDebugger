using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Console
    {
        /// <summary>
        /// Clears console messages collected in the browser.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/console#command-clearMessages"/>
        public static Command ClearMessages()
        {
            var com = new Command("Console.clearMessages");
            return com;
        }

        /// <summary>
        /// Disables console domain, prevents further console messages from being reported to the client.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/console#command-disable"/>
        public static Command Disable()
        {
            var com = new Command("Console.disable");
            return com;
        }

        /// <summary>
        /// Enables console domain, sends the messages collected so far to the client by means of the messageAdded notification.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/console#command-enable"/>
        public static Command Enable()
        {
            var com = new Command("Console.enable");
            return com;
        }

    }
}
