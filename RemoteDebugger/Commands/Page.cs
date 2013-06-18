using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Page
    {
        /// <summary>
        /// Disables page domain notifications.
        /// </summary>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/page#command-disable"/>
        /// <returns></returns>
        public static Command Disable()
        {
            var com = new Command("Page.disable");
            return com;
        }

        /// <summary>
        /// Enables page domain notifications.
        /// </summary>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/page#command-enable"/>
        /// <returns></returns>
        public static Command Enable()
        {
            var com = new Command("Page.enable");
            return com;
        }

        /// <summary>
        /// Navigates current page to the given URL.
        /// </summary>
        /// <param name="url">URL to navigate the page to.</param>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/page#command-navigate"/>
        /// <returns></returns>
        public static Command Navigate(string url)
        {
            var com = new Command("Page.navigate");
            com.addParam("url", url);
            return com;
        }

        /// <summary>
        /// Reloads given page optionally ignoring the cache.
        /// </summary>
        /// <param name="ignoreCache">If true, browser cache is ignored (as if the user pressed Shift+refresh).</param>
        /// <param name="scriptToEvaluateOnLoad">If set, the script will be injected into all frames of the inspected page after reload.</param>
        /// <see cref="https://developers.google.com/chrome-developer-tools/docs/protocol/1.0/page#command-reload"/>
        /// <returns></returns>
        public static Command Reload(bool ignoreCache = false, string scriptToEvaluateOnLoad = null)
        {
            var com = new Command("Page.reload");
            if (!ignoreCache)
            {
                com.addParam("ignoreCache", ignoreCache);
            }
            if (scriptToEvaluateOnLoad == null)
            {
                com.addParam("scriptToEvaluateOnLoad", scriptToEvaluateOnLoad);
            }
            return com;
        }


    }
}
