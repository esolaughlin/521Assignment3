using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _521Assignment3.Models;

namespace _521Assignment3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_521Assignment3.Models.Actor> Actor { get; set; }
        public DbSet<_521Assignment3.Models.Movie> Movie { get; set; }
        public DbSet<_521Assignment3.Models.ActorMovie> ActorMovie { get; set; }
    }
}