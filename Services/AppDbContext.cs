using Microsoft.EntityFrameworkCore;
using TrainGame.Domain.Models;
namespace TrainGame.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
    }
}
