using System.Text.Json.Serialization;

namespace LotrSDK.Model
{
    public enum Race
    { 
        Human,
        Elf,
        Dwarf,
        Orc,
        Ent,
        Maiar,
        Ainur,
        Hobbit
    }

    
    public class Character : BaseModel
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("wikiUrl")]
        public string WikiUrl { get; set; }

        [JsonPropertyName ("race")] 
        public Race Race { get; set; }
        
        [JsonPropertyName("birth")]
        public string Birth { get; set; }
        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }


        [JsonPropertyName("death")] 
        public string Death { get; set; }
        [JsonPropertyName("hair")]
        public string Hair { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("realm")]
        public string Realm { get; set; }
        [JsonPropertyName("spouse")]
        public string Spouse { get; set; }
    }
           
    
}
