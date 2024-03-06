using Back_end_Challenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_end_Challenge.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
    }
}
