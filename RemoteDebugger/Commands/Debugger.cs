using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Debugger
    {
        #region Methods

        /// <summary>
        /// Tells whether setScriptSource is supported.
        /// </summary>
        /// <returns>result (boolean): True if setScriptSource is supported.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-canSetScriptSource"/>
        public static Command CanSetScriptSource()
        {
            var com = new Command("Debugger.canSetScriptSource");
            return com;
        }

        /// <summary>
        /// Continues execution until specific location is reached.
        /// </summary>
        /// <param name="location">Location to continue to.</param>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-continueToLocation"/>
        public static Command ContinueToLocation(Location location)
        {
            var com = new Command("Debugger.continueToLocation");
            com.addParam("location", location);
            return com;
        }

        /// <summary>
        /// Disables debugger for given page.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-disable"/>
        public static Command Disable()
        {
            var com = new Command("Debugger.disable");
            return com;
        }

        /// <summary>
        /// Enables debugger for the given page. Clients should not assume that the debugging has been enabled until the result for this command is received.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-enable"/>
        public static Command Enable()
        {
            var com = new Command("Debugger.enable");
            return com;
        }

        /// <summary>
        /// Evaluates expression on a given call frame.
        /// </summary>
        /// <param name="callFrameId">Call frame identifier to evaluate on.</param>
        /// <param name="expression">Expression to evaluate.</param>
        /// <param name="objectGroup">(Optional) String object group name to put result into (allows rapid releasing resulting object handles using releaseObjectGroup).</param>
        /// <param name="returnByValue">(Optional) Whether the result is expected to be a JSON object that should be sent by value.</param>
        /// <returns>result (Runtime.RemoteObject): Object wrapper for the evaluation result.
        /// wasThrown (optional boolean): True if the result was thrown during the evaluation.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-evaluateOnCallFrame"/>
        public static Command EvaluateOnCallFrame(string callFrameId, string expression, string objectGroup = null, bool returnByValue = false)
        {
            var com = new Command("Debugger.evaluateOnCallFrame");
            com.addParam("callFrameId", callFrameId);
            com.addParam("expression", expression);
            if (objectGroup != null)
            {
                com.addParam("objectGroup", objectGroup);
            }
            if (returnByValue)
            {
                com.addParam("returnByValue", returnByValue);
            }
            return com;
        }

        /// <summary>
        /// Returns source for the script with given id.
        /// </summary>
        /// <param name="scriptId">Id of the script to get source for.</param>
        /// <returns>scriptSource (string): Script source.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-getScriptSource"/>
        public static Command GetScriptSource(string scriptId)
        {
            var com = new Command("Debugger.getScriptSource");
            com.addParam("scriptId", scriptId);
            return com;
        }

        /// <summary>
        /// Stops on the next JavaScript statement.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-pause"/>
        public static Command Pause()
        {
            var com = new Command("Debugger.pause");
            return com;
        }

        /// <summary>
        /// Removes JavaScript breakpoint.
        /// </summary>
        /// <param name="breakPointId">breakpointId</param>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-removeBreakpoint"/>
        public static Command RemoveBreakpoint(string breakPointId)
        {
            var com = new Command("Debugger.removeBreakpoint");
            com.addParam("breakpointId", breakPointId);
            return com;
        }

        /// <summary>
        /// Resumes JavaScript execution.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-resume"/>
        public static Command Resume()
        {
            var com = new Command("Debugger.resume");
            return com;
        }

        /// <summary>
        /// Searches for given string in script content.
        /// </summary>
        /// <param name="scriptId">Id of the script to search in.</param>
        /// <param name="query">String to search for.</param>
        /// <param name="caseSensitive">If true, search is case sensitive.</param>
        /// <param name="isRegex">If true, treats string parameter as regex.</param>
        /// <returns>result (array of Page.SearchMatch): List of search matches.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-searchInContent"/>
        public static Command SearchInContent(string scriptId, string query, bool caseSensitive = false, bool isRegex = false)
        {
            var com = new Command("Debugger.searchInContent");
            com.addParam("scriptId", scriptId);
            com.addParam("query", query);
            if (caseSensitive)
            {
                com.addParam("caseSensitive", caseSensitive);
            }
            if (isRegex)
            {
                com.addParam("isRegex", isRegex);
            }
            return com;
        }

        /// <summary>
        /// Sets JavaScript breakpoint at a given location.
        /// </summary>
        /// <param name="location">Location to set breakpoint in.</param>
        /// <param name="condition">Expression to use as a breakpoint condition. When specified, 
        /// debugger will only stop on the breakpoint if this expression evaluates to true.</param>
        /// <returns>breakpointId (string): Id of the created breakpoint for further reference.
        /// actualLocation (Location): Location this breakpoint resolved into.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-setBreakpoint"/>
        public static Command SetBreakpoint(Location location, string condition = null)
        {
            var com = new Command("Debugger.setBreakpoint");
            com.addParam("location", location);
            if (condition != null)
            {
                com.addParam("condition", condition);
            }
            return com;
        }

        /// <summary>
        /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. 
        /// Once this command is issued, all existing parsed scripts will have breakpoints resolved and 
        /// returned in locations property. Further matching script parsing will result in subsequent 
        /// breakpointResolved events issued. This logical breakpoint will survive page reloads.
        /// </summary>
        /// <param name="lineNumber">Line number to set breakpoint at.</param>
        /// <param name="url">URL of the resources to set breakpoint on.</param>
        /// <param name="urlRegex">Regex pattern for the URLs of the resources to set breakpoints on. 
        /// Either url or urlRegex must be specified.</param>
        /// <param name="columnNumber">Offset in the line to set breakpoint at.</param>
        /// <param name="condition">Expression to use as a breakpoint condition. 
        /// When specified, debugger will only stop on the breakpoint if this expression evaluates to true.</param>
        /// <returns>breakpointId (string): Id of the created breakpoint for further reference.
        /// locations (optional array of Location): List of the locations this breakpoint resolved into upon addition.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-setBreakpointByUrl"/>
        public static Command SetBreakpointByUrl(
            int lineNumber,
            string url = null,
            string urlRegex = null,
            int? columnNumber = null,
            string condition = null)
        {
            if (url == null && urlRegex == null)
            {
                throw new ArgumentException("Either url or urlRegex must be specified.");
            }
            else
            {
                var com = new Command("Debugger.setBreakpointByUrl");
                com.addParam("lineNumber", lineNumber);
                if (url != null)
                {
                    com.addParam("url", url);
                }
                if (urlRegex != null)
                {
                    com.addParam("urlRegex", urlRegex);
                }
                if (columnNumber != null)
                {
                    com.addParam("columnNumber", columnNumber);
                }
                if (condition != null)
                {
                    com.addParam("condition", condition);
                }
                return com;
            }
        }

        /// <summary>
        /// Activates / deactivates all breakpoints on the page.
        /// </summary>
        /// <param name="active">New value for breakpoints active state.</param>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-setBreakpointsActive"/>
        public static Command SetBreakpointsActive(bool active)
        {
            var com = new Command("Debugger.setBreakpointsActive");
            com.addParam("active", active);
            return com;
        }

        /// <summary>
        /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions or no exceptions. 
        /// Initial pause on exceptions state is none.
        /// </summary>
        /// <param name="state">Pause on exceptions mode.</param>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-setPauseOnExceptions"/>
        public static Command SetPauseOnExceptions(State state)
        {
            var com = new Command("Debugger.setPauseOnExceptions");
            com.addParam("state", Enum.GetName(typeof(State), state));
            return com;
        }

        /// <summary>
        /// Edits JavaScript source live.
        /// </summary>
        /// <param name="scriptId">Id of the script to edit.</param>
        /// <param name="scriptSource">New content of the script.</param>
        /// <returns>callFrames (optional array of CallFrame): New stack trace in case editing has happened while VM was stopped.</returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-setScriptSource"/>
        public static Command SetScriptSource(string scriptId, string scriptSource)
        {
            var com = new Command("Debugger.setScriptSource");
            com.addParam("scriptId", scriptId);
            com.addParam("scriptSource", scriptSource);
            return com;
        }

        /// <summary>
        /// Steps into the function call.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-stepInto"/>
        public static Command StepInto()
        {
            var com = new Command("Debugger.stepInto");
            return com;
        }

        /// <summary>
        /// Steps out of the function call.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-stepOut"/>
        public static Command StepOut()
        {
            var com = new Command("Debugger.stepOut");
            return com;
        }

        /// <summary>
        /// Steps over the statement.
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/debugger#command-stepOver"/>
        public static Command StepOver()
        {
            var com = new Command("Debugger.stepOver");
            return com;
        }

        #endregion

        #region Types

        [DataContract]
        public struct Location
        {
            [DataMember(Name = "columnNumber")]
            public int? ColumnNumber;
            [DataMember(Name = "lineNumber")]
            public int LineNumber;
            [DataMember(Name = "scriptId")]
            public string ScriptId;
        }

        [DataContract]
        public struct CallFrame
        {
            /// <summary>
            /// Call frame identifier. This identifier is only valid while the virtual machine is paused.
            /// </summary>
            [DataMember(Name = "callFrameId")]
            public string CallFrameId;

            /// <summary>
            /// Name of the JavaScript function called on this call frame.
            /// </summary>
            [DataMember(Name = "functionName")]
            public string FunctionName;

            /// <summary>
            /// Location in the source code.
            /// </summary>
            [DataMember(Name = "location")]
            public Location Location;

            /// <summary>
            /// Scope chain for this call frame.
            /// </summary>
            [DataMember(Name = "scopeChain")]
            public Runtime.Scope[] ScopeChain;

            /// <summary>
            /// this object for this call frame.
            /// </summary>
            /// <param name="?"></param>
            /// <returns></returns>
            [DataMember(Name = "this")]
            public Runtime.RemoteObject thisRemoteObject;

        }

        public enum State
        {
            all,
            none,
            uncaught
        }

        #endregion

    }
}
