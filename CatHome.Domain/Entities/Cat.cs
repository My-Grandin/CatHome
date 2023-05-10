using System.Text.Json.Serialization;

namespace CatHome.Domain.Entities
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Birthdate { get; set; } 
        public string Color { get; set; } = null!;
        public string Sex { get; set; } = null!;
        [JsonIgnore]
        [JsonPropertyName("townId")]
        public int Town { get; set; }
        public Town City { get; set; } = null!;
        public List<string>? Personality { get; set; }
        public string? Disability { get; set; }
        public List<int>? LivesWith { get; set; }

    }
}
