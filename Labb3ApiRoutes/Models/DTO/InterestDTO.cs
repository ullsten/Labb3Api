using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Labb3ApiRoutes.Models.DTO
{
    public class InterestDTO
    {
        [Key]
        public int InterestDtoId { get; set; }
        public int FK_PersonId { get; set; }

        [JsonProperty("Person")]
        public string PersonName { get; set; }
        [JsonProperty("Title")]
        public string InterestTitle { get; set; }
        [JsonProperty("Description")]
        public string InterestDescription { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }
    }
}
