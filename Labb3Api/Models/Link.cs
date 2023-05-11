using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labb3Api.Models;
using Labb3ApiWeb.Models;

namespace Labb3ApiWeb.Models
{
	public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }

        [Required]
        [StringLength(20)]
        public string LinkTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string URL { get; set; }

        [ForeignKey("Interests")]
        public int FK_InterestId { get; set; }
        public Interest Interests { get; set; }

        [ForeignKey("Persons")]
        public int FK_PersonId { get; set; }
        public Person Persons { get; set; }
    }
}
