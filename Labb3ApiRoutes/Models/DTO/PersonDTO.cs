using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb3ApiRoutes.Models.DTO
{
    public class PersonDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("First name")]
        public string? FirstName { get; set; } = default;

        [Required]
        [StringLength(30)]
        [DisplayName("Last name")]
        public string? LastName { get; set; } = default;

        [NotMapped]
        [DisplayName("Full name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(20)]
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
