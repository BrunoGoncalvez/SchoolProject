using Microsoft.EntityFrameworkCore;
using Prodam.Core.Entities;

namespace Prodam.Data.Context
{
    public class EntitiesContext : DbContext
    {

        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        
        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

    }
}
