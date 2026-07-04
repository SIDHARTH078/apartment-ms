using System.ComponentModel.DataAnnotations;

namespace apartment_management_system.Models
{
    public class menu
    {
        [Key]

        public int OwnerID { get; set; }

        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]

        public string? FlatNumber { get; set; }


    }
}
