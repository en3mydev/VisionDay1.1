using Microsoft.EntityFrameworkCore;
using VisionDay1.Models;

namespace VisionDay1.Data
{

    public class DanielDbContext : DbContext
    {
        public DanielDbContext(DbContextOptions<DanielDbContext> options) : base(options) { }
        public DbSet<Cat> Cats { get; set; }
    }
}
