using Disc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Services
{
    public class HttpsClientHandlerService : IHttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler()
        {
#if ANDROID
#if NET6_0
            var handler = new CustomAndroidMessageHandler();
#elif NET7_0_OR_GREATER
            var handler = new Xamarin.Android.Net.AndroidMessageHandler();
#endif
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                //if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                //return errors == System.Net.Security.SslPolicyErrors.None;
            };
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Handler Info: " + handler);
            Console.WriteLine("-----------------------------------");
            return handler;

            
#elif IOS
            var handler = new NSUrlSessionHandler
            {
                TrustOverrideForUrl = IsHttpsLocalhost
            };
            return handler;
#elif WINDOWS || MACCATALYST
            return null;
#else
            throw new PlatformNotSupportedException("Only Android, iOS, MacCatalyst, and Windows supported.");
#endif
        }
#if ANDROID && NET6_0
    Console.WriteLine("-----------------------------------"
    Console.WriteLine("ANDROID && NET6_0"
    internal sealed class CustomAndroidMessageHandler : Xamarin.Android.Net.AndroidMessageHandler
    {
        protected override Javax.Net.Ssl.IHostnameVerifier GetSSLHostnameVerifier(Javax.Net.Ssl.HttpsURLConnection connection)
            => new CustomHostnameVerifier();

        private sealed class CustomHostnameVerifier : Java.Lang.Object, Javax.Net.Ssl.IHostnameVerifier
        {
            public bool Verify(string hostname, Javax.Net.Ssl.ISSLSession session)
            {
                return true;
            }
        }
    }
    Console.WriteLine("-----------------------------------"
#elif IOS
        public bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
        {
            if (url.StartsWith("https://localhost"))
                return true;
            return false;
        }
#endif
    }
}
