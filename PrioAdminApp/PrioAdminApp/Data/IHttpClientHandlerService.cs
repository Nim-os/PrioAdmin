using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace PrioAdminApp.Data
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
