using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace StockAPI
{
    public class TuShareUtility
    {
        private IHttpClientUtility _httpClientUtility;
        private string _url = "http://api.waditu.com/";

        public TuShareUtility(IHttpClientUtility httpClientUtility)
        {
            _httpClientUtility = httpClientUtility;
        }

        /// <summary>
        /// Call TuShare API
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="parmaMap"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public DataTable GetData(string apiName, Dictionary<string, string> parmaMap, params string[] fields)
        {
            var tuShareParamObj = new TuShareParamObj() { ApiName = apiName, Params = parmaMap, Fields = string.Join(",", fields) };

            //Http call HttpClientUtility class with in HttpClientPost methods
            var result = _httpClientUtility.HttpClientPost(_url, tuShareParamObj);

            //Serializes the returned result into an object
            var desResult = JsonConvert.DeserializeObject<TuShareResult>(result);

            //If the call fails, an exception is thrown
            if (!string.IsNullOrEmpty(desResult.Msg))
                throw new Exception(desResult.Msg);

            //The return result is divided into two parts, one is the column header information 
            //and the other is the data itself, from which the DataTable can be built
            DataTable dt = new DataTable();
            foreach (var dataField in desResult.Data.Fields)
            {
                dt.Columns.Add(dataField);
            }

            foreach (var dataItemRow in desResult.Data.Items)
            {
                var newdr = dt.NewRow();
                for (int i = 0; i < dataItemRow.Length; i++)
                {
                    newdr[i] = dataItemRow[i];
                }

                dt.Rows.Add(newdr);
            }
            return dt;
        }

        private class TuShareParamObj
        {
            [JsonProperty("api_name")]
            public string ApiName { get; set; }

            [JsonProperty("token")]
            public string Token { get; } = "Put your Token";//Your Token

            [JsonProperty("params")]
            public Dictionary<string, string> Params { get; set; }

            [JsonProperty("fields")]
            public string Fields { get; set; }
        }

        private class TuShareData
        {
            [JsonProperty("fields")]
            public string[] Fields { get; set; }

            [JsonProperty("items")]
            public string[][] Items { get; set; }
        }

        private class TuShareResult
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("msg")]
            public string Msg { get; set; }

            [JsonProperty("data")]
            public TuShareData Data { get; set; }
        }
    }
}
