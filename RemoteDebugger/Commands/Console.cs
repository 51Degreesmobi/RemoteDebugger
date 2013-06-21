using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Console
    {
        #region Methods

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

        #endregion

        #region Types

        [DataContract]
        public struct CallFrame
        {
            /// <summary>
            /// JavaScript script column number.
            /// </summary>
            [DataMember(Name = "ColumnNumber")]
            public int ColumnNumber;

            /// <summary>
            /// JavaScript function name.
            /// </summary>
            [DataMember(Name = "functionName")]
            public string FunctionName;

            /// <summary>
            /// JavaScript script line number.
            /// </summary>
            [DataMember(Name = "lineNumber")]
            public int LineNumber;

            /// <summary>
            /// JavaScript script name or url.
            /// </summary>
            [DataMember(Name = "url")]
            public string Url;

        }

        [DataContract]
        public struct ConsoleMessage
        {
            /// <summary>
            /// Message severity.
            /// </summary>
            [DataMember(Name = "level")]
            public string Level;

            /// <summary>
            /// Line number in the resource that generated this message.
            /// </summary>
            [DataMember(Name = "line", IsRequired = false)]
            public int Line;

            /// <summary>
            /// Identifier of the network request associated with this message.
            /// </summary>
            [DataMember(Name = "networkRequestId", IsRequired = false)]
            public string NetworkRequestId;

            /// <summary>
            /// Message parameters in case of the formatted message.
            /// </summary>
            [DataMember(Name = "parameters", IsRequired = false)]
            public Runtime.RemoteObject[] Parameters;

            /// <summary>
            /// Repeat count for repeated messages.
            /// </summary>
            [DataMember(Name = "repeatCount", IsRequired = false)]
            public int RepeatCount;

            /// <summary>
            /// Message source.
            /// </summary>
            [DataMember(Name = "source")]
            public string Source;

            /// <summary>
            /// JavaScript stack trace for assertions and error messages.
            /// </summary>
            [DataMember(Name = "stackTrace", IsRequired = false)]
            public CallFrame[] StackTrace;

            /// <summary>
            /// Message text.
            /// </summary>
            [DataMember(Name = "text")]
            public string Text;

            /// <summary>
            /// Console message type.
            /// </summary>
            [DataMember(Name = "type", IsRequired = false)]
            public string Type;

            /// <summary>
            /// URL of the message origin.
            /// </summary>
            [DataMember(Name = "url", IsRequired = false)]
            public string Url;

        #endregion

        }
    }
}
