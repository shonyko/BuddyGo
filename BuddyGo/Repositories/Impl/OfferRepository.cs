
using BuddyGo.Data;
using BuddyGo.Models;

namespace BuddyGo.Repositories.Impl {
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository {
        public OfferRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Offers) {
        }

        public Task<List<Offer>> GetAllByAnnouncementId(string id) {
            return Task.FromResult(_dbSet.Where(p => p.AnnouncementId == id).ToList());
        }
    }
}
