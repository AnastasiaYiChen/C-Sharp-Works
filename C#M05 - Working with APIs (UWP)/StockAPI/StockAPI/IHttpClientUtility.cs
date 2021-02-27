using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Http;

namespace StockAPI
{
    public interface IHttpClientUtility
    {
        string HttpClientPost(string url, object datajson);
    }
}
