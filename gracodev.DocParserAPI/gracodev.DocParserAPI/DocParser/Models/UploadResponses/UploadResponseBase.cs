using Newtonsoft.Json;
using System;

namespace gracodev.DocParserAPI.DocParser.Models.UploadResponses
{
    public abstract class UploadResponseBase
    {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("file_size")]
            public int FileSize { get; set; }
            [JsonProperty("pages")]
            public int Pages { get; set; }
            [JsonProperty("quota_used")]
            public int QuotaUsed { get; set; }
            [JsonProperty("quota_left")]
            public int QuotaLeft { get; set; }
            [JsonProperty("quota_refill")]
            public DateTime QuotaRefill { get; set; }
    }
}
