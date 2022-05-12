
using BuddyGo.Models;

namespace BuddyGo.Repositories {
    public interface IOfferRepository : IRepository<Offer> {
        public Task<List<Offer>> GetAllByAnnouncementId(string id);
    }
}
