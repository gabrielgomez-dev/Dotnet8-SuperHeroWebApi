using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Entities;

namespace SuperHeroWebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
