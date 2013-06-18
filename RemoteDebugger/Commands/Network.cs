using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Network
    {
        /// <summary>
        /// Tells whether clearing browser cache is supported.
        /// </summary>
        /// <returns>result (boolean): True if browser cache can be cleared.</returns>
        public static Command CanClearBrowserCache()
        {
            var com = new Command("Network.canClearBrowserCache");
            return com;
        }

        /// <summary>
        /// Tells whether clearing browser cookies is supported.
        /// </summary>
        /// <returns>result (boolean): True if browser cookies can be cleared.</returns>
        public static Command CanClearBrowserCookies()
        {
            var com = new Command("Network.canClearBrowserCookies");
            return com;
        }

        /// <summary>
        /// Clears browser cache.
        /// </summary>
        public static Command ClearBrowserCache()
        {
            var com = new Command("Network.clearBrowserCache");
            return com;
        }

        /// <summary>
        /// Clears browser cookies.
        /// </summary>
        /// <returns></returns>
        public static Command ClearBrowserCookies()
        {
            var com = new Command("Network.clearBrowserCookies");
            return com;
        }

        /// <summary>
        /// Disables network tracking, prevents network events from being sent to the client.
        /// </summary>
        /// <returns></returns>
        public static Command Disable()
        {
            var com = new Command("Network.disable");
            return com;
        }

        /// <summary>
        /// Enables network tracking, network events will now be delivered to the client.
        /// </summary>
        /// <returns></returns>
        public static Command Enable()
        {
            var com = new Command("Network.enable");
            return com;
        }

        /// <summary>
        /// Returns content served for the given request.
        /// </summary>
        /// <param name="requestId">Identifier of the network request to get content for.</param>
        /// <returns>body (string): Response body.
        /// base64Encoded (boolean): True, if content was sent as base64.</returns>
        public static Command GetResponseBody(string requestId)
        {
            var com = new Command("Network.getResponseBody");
            com.addParam("requestId", requestId);
            return com;
        }

        /// <summary>
        /// Toggles ignoring cache for each request. If true, cache will not be used.
        /// </summary>
        /// <param name="cacheDisabled">Cache disabled state.</param>
        /// <returns></returns>
        public static Command SetCacheDisabled(bool cacheDisabled)
        {
            var com = new Command("Network.setCacheDisabled");
            com.addParam("cacheDisabled", cacheDisabled);
            return com;
        }

        /// <summary>
        /// Specifies whether to always send extra HTTP headers with the requests from this page.
        /// </summary>
        /// <param name="headers">Map with extra HTTP headers.</param>
        /// <returns></returns>
        public static Command SetExtraHTTPHeaders(Dictionary<string, string> headers)
        {
            var com = new Command("Network.setExtraHTTPHeaders");
            com.addParam("headers", Command.GetJsonFromDictionary(headers));
            return com;
        }

        /// <summary>
        /// Allows overriding user agent with the given string.
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns>userAgent (string): Useragent to use.</returns>
        public static Command SetUserAgentOverride(string userAgent)
        {
            var com = new Command("Network.setUserAgentOverride");
            com.addParam("userAgent", userAgent);
            return com;
        }

    }
}
