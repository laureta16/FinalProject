using FinalProjeckt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjeckt.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    
    }

}


