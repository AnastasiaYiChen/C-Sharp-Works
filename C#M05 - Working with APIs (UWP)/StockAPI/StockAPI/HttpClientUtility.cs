using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StockAPI
{
    public class HttpClientUtility : IHttpClientUtility
    {


        public HttpClientUtility()
        {

        }
        public string HttpClientPost(string url, object datajson)
        {
            using (HttpClient httpClient = new HttpClient()) //http Object
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = new TimeSpan(0, 0, 5);

                //Convert to the format required for the link
                HttpContent httpContent = new JsonContent(datajson);

                //request
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    return t.Result;
                }
                throw new Exception("failed to call");
            }

        }
    }
}
