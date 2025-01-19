using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RamirezforaneoApp.Models;

namespace RamirezforaneoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RamirezforaneoApp.Models.Category> Category { get; set; } = default!;
        public DbSet<RamirezforaneoApp.Models.Event> Event { get; set; } = default!;
        public DbSet<RamirezforaneoApp.Models.Market> Market { get; set; } = default!;
        public DbSet<RamirezforaneoApp.Models.Slider> Slider { get; set; } = default;
    }
}
