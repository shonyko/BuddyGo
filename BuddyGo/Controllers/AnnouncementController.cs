
using BuddyGo.Services;
using Microsoft.AspNetCore.Mvc;
using BuddyGo.DTOs.Announcement;
using BuddyGo.Models;

namespace BuddyGo.Controllers {
    [Route("/announcements")]
    public class AnnouncementController : BaseController<Announcement, AnnouncementDTO, AnnouncementCreateDTO, AnnouncementUpdateDTO> {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService) : base(announcementService) {
            _announcementService = announcementService;
        }
    }
}
