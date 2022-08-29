using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthSample
{
    internal static class Auth
    {
        private static IDictionary<Uri, AuthResponseFuture> _pendingAuthResponses = new Dictionary<Uri, AuthResponseFuture>();

        public static void RaiseAuthResponseFutureEvent(Uri forCallbackUri, Uri responseUri)
        {
            if (_pendingAuthResponses.TryGetValue(forCallbackUri, out AuthResponseFuture future))
            {
                future.RaiseAuthCallbackEvent(responseUri);
                _pendingAuthResponses.Remove(forCallbackUri);
            }
            else
            {
                throw new Exception("This callback uri is not registered for auth");
            }
        }

        public static async Task<AuthResponseFuture> AuthorizeInBrowser(Uri authEndpoint, Uri callbackUri)
        {
            await Windows.System.Launcher.LaunchUriAsync(authEndpoint);
            var resp = new AuthResponseFuture();
            _pendingAuthResponses.Add(callbackUri, resp);
            return resp;
        }
    }
}
