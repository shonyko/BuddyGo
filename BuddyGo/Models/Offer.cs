
using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class Offer : BaseModel {
        public string SitterId { get; set; } = null!;
        public string AnnouncementId { get; set; } = null!;
    }
}
