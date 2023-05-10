using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb3ApiRoutes.Models.DTO
{
    public class PersonUpdateDTO
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
