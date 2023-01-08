using Microsoft.EntityFrameworkCore;
using IBKS.Models.Domain;
using Microsoft.Extensions.Options;

namespace IBKS.Data
{
    public class IBKSDbContext : DbContext
    {
        public IBKSDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } // Users is the table name 
        public DbSet<Project> Projects { get; set; }  // Projects is the table name



    
    }
}
