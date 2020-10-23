using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Http;
using PrioAdminApp.Droid;
using PrioAdminApp.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace PrioAdminApp.Droid
{
 
    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return true;
                //return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
    
}