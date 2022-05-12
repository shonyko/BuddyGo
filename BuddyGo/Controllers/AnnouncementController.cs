
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;
using BuddyGo.DTOs.Announcement;
using BuddyGo.Models;

namespace BuddyGo.Controllers {
    [Route("/announcements")]
    public class AnnouncementController : BaseController<Announcement, AnnouncementDTO, AnnouncementCreateDTO, AnnouncementUpdateDTO> {
        private readonly IAnnouncementService _announcementService;
        private readonly IOfferService _offerService;
        public AnnouncementController(IAnnouncementService announcementService, IOfferService offerService) : base(announcementService) {
            _announcementService = announcementService;
            _offerService = offerService;
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetOffers(string id) {
            return Ok(await _announcementService.GetOffers(id));
        }
    }
}
