using System.Text.Json.Serialization;

namespace LotrSDK.Model
{
    public  class BaseModel
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
    }
}
