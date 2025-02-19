using Microsoft.EntityFrameworkCore;
using RSConnect.Api.Domain.Entities;

namespace RSConnect.Api.Infraestructure.DataAccess
{
    public class RSConnectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=C:\\Users\\dinoe\\Downloads\\TechLibraryDb.db");
        }
    }
}
