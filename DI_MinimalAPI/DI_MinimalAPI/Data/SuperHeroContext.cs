using DI.Models;
using Microsoft.EntityFrameworkCore;

namespace DI.Data
{
    public class SuperHeroContext : DbContext
    {
        public SuperHeroContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SuperHero> SuperHeros { get; set; }
    }
}
