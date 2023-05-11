using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Labb3ApiRoutes.Models.DTO
{
    public class LinkUpdateDTO
    {
        public int LinkId { get; set; }

        [Required]
        public string LinkTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string URL { get; set; }

        public int FK_InterestId { get; set; }
        [Required]
        public int FK_PersonId { get; set; }
    }
}
