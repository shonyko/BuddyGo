using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}