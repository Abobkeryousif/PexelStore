using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PexelStore.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var UserId = "ae96f4b2-450b-407f-a848-c0bea04dd408";
            var AdminId = "a395e76d-cff4-4639-baf1-7118b51f4208";
            var Role = new List<IdentityRole>()
            {
               new IdentityRole()
               {
               Id = UserId,
               Name = "User",
               ConcurrencyStamp = UserId,
               NormalizedName = "User".ToUpper()
               }
            ,

            new IdentityRole() 
            {
                Id =  AdminId,
                Name = "Admin",
                ConcurrencyStamp = AdminId,
                NormalizedName = "Admin".ToUpper()
            } };

            builder.Entity<IdentityRole>().HasData(Role);
        }

    }
}




