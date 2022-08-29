using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthSample
{
    internal class AuthResponseFuture
    {
        public delegate void AuthUriCallbackHandler(Uri uri);

        public event AuthUriCallbackHandler OnAuthComplete;

        public void RaiseAuthCallbackEvent(Uri uri)
        {
            OnAuthComplete.Invoke(uri);
        }
    }
}
