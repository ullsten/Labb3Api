using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3ApiRoutes.Models.DTO
{
    public class InterestCreateDTO
    {
        public int FK_PersonId { get; set; }
        
        [Required]
        //[JsonProperty("Title")]
        public string InterestTitle { get; set; }
        
        [Required]
        //[JsonProperty("Description")]
        public string InterestDescription { get; set; }
    }
}
