
using BuddyGo.Data;
using BuddyGo.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyGo.Repositories.Impl {
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository {
        public AnnouncementRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Announcements) {
        }

        public Task<List<Announcement>> GetAllByOwnerId(string id) {
            return Task.FromResult(_dbSet.Where(p => p.OwnerId == id).ToList());
        }
    }
}
