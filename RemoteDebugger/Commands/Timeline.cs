using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Timeline
    {
        #region Methods

        /// <summary>
        /// Starts capturing instrumentation events.
        /// </summary>
        /// <param name="maxCallStackDepth">Samples JavaScript stack traces up to maxCallStackDepth, defaults to 5.</param>
        /// <returns></returns>
        public static Command Start(int? maxCallStackDepth = null)
        {
            var com = new Command("Timeline.start");
            if (maxCallStackDepth != null)
            {
                com.addParam("maxCallStackDepth", maxCallStackDepth);
            }
            return com;
        }

        /// <summary>
        /// Stops capturing instrumentation events.
        /// </summary>
        /// <returns></returns>
        public static Command Stop()
        {
            var com = new Command("Timeline.stop");
            return com;
        }

        #endregion

        #region Types

        [DataContract]
        public struct TimelineEvent
        {
            /// <summary>
            /// Nested records.
            /// </summary>
            [DataMember(Name = "children", IsRequired = false)]
            public TimelineEvent[] Children;

            /// <summary>
            /// Event data.
            /// </summary>
            [DataMember(Name = "data")]
            public object Data;

            /// <summary>
            /// Event type.
            /// </summary>
            [DataMember(Name = "type")]
            public string Type;
        }

        #endregion
    }
}
