
namespace BuddyGo.DTOs.Announcement {
    public class AnnouncementCreateDTO {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string OwnerId { get; set; } = null!;
        public string PetId { get; set; } = null!;
        public string? OfferId { get; set; } = null!;
    }
}
