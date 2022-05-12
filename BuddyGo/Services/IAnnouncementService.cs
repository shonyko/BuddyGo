
using BuddyGo.DTOs.Announcement;
using BuddyGo.DTOs.Offer;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface IAnnouncementService : IService<Announcement, AnnouncementDTO, AnnouncementCreateDTO, AnnouncementUpdateDTO> {
        public Task<List<OfferDTO>> GetOffers(string id);
    }
}
