﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace gracodev.DocParserAPI.DocParser
{
    public static partial class Services
    {
        public static object HttpUtility { get; private set; }

        public static async Task<Object> GetDataResults(Object type, string parseID, string apiKey)
        {
            var dataResponse = new Object();
            var url = string.Format("/document/fetch/{0}?api_key={1}", parseID, apiKey);
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
                        JsonConvert.PopulateObject(result, dataResponse);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return dataResponse;
        }
    }
}
