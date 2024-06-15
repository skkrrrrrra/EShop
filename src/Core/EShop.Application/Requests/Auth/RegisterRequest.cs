using EShop.Domain.Enums;

namespace EShop.Application.Requests.Auth
{
	public class RegisterRequest
	{
		public string First { get; set; }
		public string Last { get; set; }
		public Sex Sex { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public string Image { get; set; }
	}
}