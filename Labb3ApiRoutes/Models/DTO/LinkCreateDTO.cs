using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3ApiRoutes.Models.DTO
{
    public class LinkCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string LinkTitle { get; set; }
        [Required]
        [StringLength(100)]
        public string URL { get; set; }
        [Required]
        public int FK_InterestId { get; set; }
        [Required]
        public int FK_PersonId { get; set; }
    }
}
