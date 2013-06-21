using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Network
    {

        #region Methods

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

        #endregion

        #region Types

        public struct CachedResource
        {
            /// <summary>
            /// Cached response body size.
            /// </summary>
            [DataMember(Name = "bodySize")]
            int BodySize;

            /// <summary>
            /// Cached response data.
            /// </summary>
            [DataMember(Name = "response", IsRequired = false)]
            Response response;

            /// <summary>
            /// Type of this resource.
            /// </summary>
            [DataMember(Name = "type")]
            String Type;

            /// <summary>
            /// Resource URL.
            /// </summary>
            [DataMember(Name = "url")]
            string Url;
        }

        [DataContract]
        public struct Initiator
        {
            /// <summary>
            /// Initiator line number, set for Parser type only.
            /// </summary>
            [DataMember(Name = "lineNumber", IsRequired = false)]
            public int? LineNumber;

            /// <summary>
            /// Initiator JavaScript stack trace, set for Script only.
            /// </summary>
            [DataMember(Name = "stackTrace", IsRequired = false)]
            public Console.CallFrame[] StackTrace;

            /// <summary>
            /// Type of this initiator.
            /// </summary>
            [DataMember(Name = "type")]
            public string Type;

            /// <summary>
            /// Initiator URL, set for Parser type only.
            /// </summary>
            [DataMember(Name = "url", IsRequired = false)]
            public string Url;

        }

        [DataContract]
        public struct Request
        {
            /// <summary>
            /// HTTP request headers.
            /// </summary>
            [DataMember(Name = "headers")]
            public Dictionary<string, string> headers;

            /// <summary>
            /// HTTP request method.
            /// </summary>
            [DataMember(Name = "method")]
            public string Method;

            /// <summary>
            /// HTTP POST request data.
            /// </summary>
            [DataMember(Name = "postData", IsRequired = false)]
            public string PostData;

            /// <summary>
            /// Request URL.
            /// </summary>
            [DataMember(Name = "url")]
            public string Url;
        }

        [DataContract]
        public struct ResourceTiming
        {
            /// <summary>
            /// Connected to the remote host.
            /// </summary>
            [DataMember(Name = "connectEnd")]
            public int ConnectEnd;

            /// <summary>
            /// Started connecting to the remote host.
            /// </summary>
            [DataMember(Name = "connectStart")]
            public int ConnectStart;

            /// <summary>
            /// Finished DNS address resolve.
            /// </summary>
            [DataMember(Name = "dnsEnd")]
            public int DnsEnd;

            /// <summary>
            /// Started DNS address resolve.
            /// </summary>
            [DataMember(Name = "dnsStart")]
            public int DnsStart;

            /// <summary>
            /// Finished resolving proxy.
            /// </summary>
            [DataMember(Name = "proxyEnd")]
            public int ProxyEnd;

            /// <summary>
            /// Started resolving proxy.
            /// </summary>
            [DataMember(Name = "proxyStart")]
            public int ProxyStart;

            /// <summary>
            /// Finished receiving response headers.
            /// </summary>
            [DataMember(Name = "receiveHeadersEnd")]
            public int ReceiveHeadersEnd;

            /// <summary>
            /// Timing's requestTime is a baseline in seconds, while the other numbers are ticks in milliseconds relatively to this requestTime.
            /// </summary>
            [DataMember(Name = "requestTime")]
            public int RequestTime;

            /// <summary>
            /// Finished sending request.
            /// </summary>
            [DataMember(Name = "sendEnd")]
            public int SendEnd;

            /// <summary>
            /// Started sending request.
            /// </summary>
            [DataMember(Name = "sendStart")]
            public int SendStart;

            /// <summary>
            /// Finished SSL handshake.
            /// </summary>
            [DataMember(Name = "sslEnd")]
            public int SslEnd;

            /// <summary>
            /// Started SSL handshake.
            /// </summary>
            [DataMember(Name = "sslStart")]
            public int SslStart;
        }

        [DataContract]
        public struct Response
        {
            /// <summary>
            /// Physical connection id that was actually used for this request.
            /// </summary>
            [DataMember(Name = "connectionId")]
            public int ConnectionId;

            /// <summary>
            /// Specifies whether physical connection was actually reused for this request.
            /// </summary>
            [DataMember(Name = "connectionReused")]
            public bool ConnectionReused;

            /// <summary>
            /// Specifies that the request was served from the disk cache.
            /// </summary>
            [DataMember(Name = "fromDiskCache", IsRequired = false)]
            public bool FromDiskCache;

            /// <summary>
            /// HTTP response headers.
            /// </summary>
            [DataMember(Name = "headers")]
            public Dictionary<string, string> Headers;

            /// <summary>
            /// HTTP response headers text.
            /// </summary>
            [DataMember(Name = "headersText", IsRequired = false)]
            public string HeadersText;

            /// <summary>
            /// Resource mimeType as determined by the browser.
            /// </summary>
            [DataMember(Name = "mimeType")]
            public string MimeType;

            /// <summary>
            /// Refined HTTP request headers that were actually transmitted over the network.
            /// </summary>
            [DataMember(Name = "requestHeaders", IsRequired = false)]
            public Dictionary<string, string> RequestHeaders;

            /// <summary>
            /// HTTP request headers text.
            /// </summary>
            [DataMember(Name = "requestHeadersText", IsRequired = false)]
            public string RequestHeadersText;

            /// <summary>
            /// HTTP response status code.
            /// </summary>
            [DataMember(Name = "status")]
            public int Status;

            /// <summary>
            /// HTTP response status text.
            /// </summary>
            [DataMember(Name = "statusText")]
            public string StatusText;

            /// <summary>
            /// Timing information for the given request.
            /// </summary>
            [DataMember(Name = "timing", IsRequired = false)]
            public ResourceTiming Timing;

            /// <summary>
            /// Response URL.
            /// </summary>
            [DataMember(Name = "url")]
            public string Url;

        #endregion

        }
    }
}
