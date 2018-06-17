using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models.Enitites;

namespace Models.Context
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(IDbContextOptions options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=mtm.tika.me;Database=EfTests;uid=sa;pwd=<pwd>");
            }
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}