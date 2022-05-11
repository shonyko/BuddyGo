
using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IAnnouncementRepository : IRepository<Announcement> {
        public Task<List<Announcement>> GetAllByOwnerId(string id);
    }
}
