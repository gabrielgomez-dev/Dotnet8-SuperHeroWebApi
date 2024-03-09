namespace SuperHeroWebApi.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string HeroName { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
