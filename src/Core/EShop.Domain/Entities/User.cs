using EShop.Domain.Entities.Base;
using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class User : BaseEntity
{
	public string Username { get; set; }
	public string PasswordHash { get; set; }
	public string Email { get; set; }
	public bool EmailVerified { get; set; }
	public string PhoneNumber { get; set; }
}
