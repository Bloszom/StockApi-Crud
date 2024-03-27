using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using morningclassonapi.Model;

namespace morningclassonapi.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        //Roles must be creted when using identity
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
