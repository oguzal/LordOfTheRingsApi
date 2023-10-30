using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace LotrSDK.Helpers
{
    public class ApiResponse
    {
        [JsonPropertyName("docs")]
        public List<JsonObject>? Records { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        public int StatusCode { get; set; }
    }
}
