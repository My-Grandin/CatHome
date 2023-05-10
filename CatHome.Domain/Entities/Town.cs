namespace CatHome.Domain.Entities
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Population { get; set; }
    }
}
