using Microsoft.EntityFrameworkCore;
using PexelStore.Models.Domain;
using System.CodeDom.Compiler;

namespace PexelStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {   
        }

        public DbSet<Games> games { get; set; }

        public DbSet<Genre> genres { get; set; }
    }
}
