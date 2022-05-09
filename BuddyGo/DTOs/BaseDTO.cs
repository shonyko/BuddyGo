using System.ComponentModel.DataAnnotations;

namespace BuddyGo.DTOs {
    public class BaseDTO {
        [Key]
        public string Id { get; set; }  = null!;
    }
}
