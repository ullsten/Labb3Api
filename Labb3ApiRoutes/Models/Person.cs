using Labb3Api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb3ApiRoutes.Models
{
	public class Person
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
		[DisplayName("Person")]
		public string FullName => $"{FirstName} {LastName}";

		[Required]
		[StringLength(20)]
		[DisplayName("Phone number")]
		public string? PhoneNumber { get; set; }

		public ICollection<Interest>? Interests { get; set; } //navigering
		public ICollection<Link>? Links { get; set; } //navigering
	}
}
