using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<IncompleteUser> IncompleteUsers { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Sitter> Sitters { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
    }
}