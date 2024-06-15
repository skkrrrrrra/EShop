using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EShop.Application.ViewModels
{
	public class CustomerViewModel
	{
		[Key]
		public long Id { get; set; }

		[Required(ErrorMessage = "The Name is Required")]
		[MinLength(2)]
		[MaxLength(100)]
		[DisplayName("Name")]
		public string Name { get; set; }



	}
}