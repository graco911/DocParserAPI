using Newtonsoft.Json;

namespace gracodev.DocParserAPI.DocParser.Models.Parsers
{
    public abstract class ParserBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
