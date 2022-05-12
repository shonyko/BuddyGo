
using AutoMapper;
using BuddyGo.DTOs.Announcement;
using BuddyGo.DTOs.Offer;
using BuddyGo.Models;
using BuddyGo.Repositories;

namespace BuddyGo.Services.Impl {
    public class AnnouncementService : BaseService<Announcement, AnnouncementDTO, AnnouncementCreateDTO, AnnouncementUpdateDTO>, IAnnouncementService {
        private readonly IAnnouncementRepository _repository;
        private readonly IOfferRepository _offerRepository;

        public AnnouncementService(IAnnouncementRepository repository, IOfferRepository offerRepository, IMapper mapper) : base(repository, mapper) {
            _repository = repository;
            _offerRepository = offerRepository;
        }

        public async Task<List<OfferDTO>> GetOffers(string id) {
            return _mapper.Map<List<Offer>, List<OfferDTO>>(await _offerRepository.GetAllByAnnouncementId(id));
        }
    }
}
