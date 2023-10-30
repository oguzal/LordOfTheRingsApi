using System.Text.Json.Serialization;

namespace LotrSDK.Model
{
    public class Movie : BaseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("runtimeInMinutes")]

        public double RunTimeInMinutes { get; set; }

        [JsonPropertyName("budgetInMillions")]

        public double BudgetInMillions { get; set; }

        [JsonPropertyName("boxOfficeRevenueInMillions")]
        public double BoxOfficeRevenueInMillions { get; set; }

        [JsonPropertyName("academyAwardNominations")]
        public int AcademyAwardNominations { get; set; }

        [JsonPropertyName("academyAwardWins")]
        public int AcademyAwardWins { get; set; }

        [JsonPropertyName("rottenTomatoesScore")]
        public double RottenTomatoesScore { get; set; }

    }
}
