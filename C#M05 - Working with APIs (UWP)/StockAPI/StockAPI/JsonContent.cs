using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

namespace StockAPI
{
    public class JsonContent : StringContent
    {
        /*get SerializeObject value*/
        public JsonContent(object value)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json")
        {
        }

        public JsonContent(object value, string mediaType)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
        {
        }
    }
}
