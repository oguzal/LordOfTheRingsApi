using System.Text.Json.Serialization;

namespace LotrSDK.Model
{
    public class Quote : BaseModel
    {
          
        [JsonPropertyName("dialog")]
        public string Dialog { get; set; }

        [JsonPropertyName("movie")]
        public string Movie { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }

    }
}
