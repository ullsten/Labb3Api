using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Labb3ApiRoutes.Models.DTO
{
    public class LinkDTO
    {
        [Key]
        public int LinkId { get; set; }
        public int PersonId { get; set; }

        [JsonProperty("Name")]
        public string PersonName { get; set; }
        [Required]
        [StringLength(100)]
        public string URL { get; set; }   
    }
}
