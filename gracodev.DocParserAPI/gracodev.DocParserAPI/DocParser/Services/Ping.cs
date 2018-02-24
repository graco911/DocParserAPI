using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace gracodev.DocParserAPI.DocParser
{
    public static partial class Services
    {
        public static async Task<PingResponse> Ping(string apiKey)
        {
            var pingResponse = new PingResponse();
            var url = string.Format("/ping?api_key={0}", apiKey);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.docparser.com/v1");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage Response = await client.GetAsync(url);
                    var result = await Response.Content.ReadAsStringAsync();
                    if (result.Length > 0)
                    {
                        JsonConvert.PopulateObject(result, pingResponse);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return pingResponse;
        }

        public class PingResponse
        {
            [JsonProperty("msg")]
            public string Msg { get; set; }
        }
    }
}
