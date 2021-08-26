using Meditatori.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meditatori.ro2.Data
{
    public class SiteDbContext : IdentityDbContext<User>
    {
        public SiteDbContext(DbContextOptions<SiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Calification> Califications { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }



    }
}
