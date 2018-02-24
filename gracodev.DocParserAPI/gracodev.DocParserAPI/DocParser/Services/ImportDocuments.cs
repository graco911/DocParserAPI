using gracodev.DocParserAPI.DocParser.Models.UploadResponses;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace gracodev.DocParserAPI.DocParser
{
    public static partial class Services
    {
        public static async Task<UploadResponseData> ImportDocuments(string parseID, string apiKey, Stream paramFileStream)
        {
            var url = string.Format("https://api.docparser.com/v1/document/upload/{0}?api_key={1}", parseID, apiKey);
            var uploadResponseData = new UploadResponseData();

            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {

                formData.Add(fileStreamContent, "file", "file_upload_" + Guid.NewGuid() + "_" + DateTime.Now);

                try
                {
                    var Response = client.PostAsync(url, formData).Result;

                    var result = await Response.Content.ReadAsStringAsync();
                    if (result.Length > 0)
                    {
                        JsonConvert.PopulateObject(result, uploadResponseData);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return uploadResponseData;
        }
    }
}
