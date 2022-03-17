using System.ComponentModel.DataAnnotations;

namespace BuddyGo.Models {
    public class BaseModel {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
