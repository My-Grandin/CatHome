namespace CatHome.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public List<string>? CatPreferences { get; set; }
        public int Town { get; set; }
        public string Personnummer { get; set; } = null!;
        public int YearsOfExperienceWithCats { get; set; }
        public string Email { get; set; } = null!;
        public int NumberOfCatsCanAdopt { get; set; }
        public bool DisabilityCertified { get; set; }
    }
}
