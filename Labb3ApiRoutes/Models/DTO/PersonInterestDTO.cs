using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Labb3ApiRoutes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Labb3ApiRoutes.Models.DTO
{
    public class PersonInterestDTO
    {
        public int PersonInterestDtoId { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public int InterestId { get; set; }
        public Interest? Interest { get; set; }

        public int LinkId { get; set; }
        public Link? Link { get; set; }
    }
}
