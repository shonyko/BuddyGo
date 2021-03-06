namespace BuddyGo.Models {
    public class Announcement : BaseModel {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string OwnerId { get; set; } = null!;
        public Owner Owner { get; set; } = null!;
        public string PetId { get; set; } = null!;
        public Pet Pet { get; set; } = null!;

        public string? OfferId { get; set; } = null!;
        public Offer? Offer { get; set; } = null!;
    }
}
