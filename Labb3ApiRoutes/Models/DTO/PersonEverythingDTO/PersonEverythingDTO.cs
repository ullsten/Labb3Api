using Newtonsoft.Json;

namespace Labb3ApiRoutes.Models.DTO.PersonEverythingDTO
{
    public class PersonEverythingDTO
    {
        [JsonProperty("Person link interst id")]
        public int PersonLinkInterstDTOId { get; set; }

        [JsonProperty("Person Id")]
        public int FK_PersonId { get; set; }

        [JsonProperty("Person name")]
        public string PersonName { get; set; }

        [JsonProperty("Interest Id")]
        public int FK_InterestId { get; set; }
        [JsonProperty("Interest title")]
        public string InterestTitle { get; set; }

        [JsonProperty("Interest description")]
        public string InterestDescription { get; set; }

        [JsonProperty("Link Id")]
        public int FK_LinkId { get; set; }
        [JsonProperty("Link title")]
        public string LinkTitle { get; set; }
        public string URL { get; set; }
    }
}
