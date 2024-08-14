using IronDomeSim.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDomeSim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Weapon> Weapons { get; set; }
    }
}
