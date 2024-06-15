using EShop.Domain.Entities.Base;
using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class User : BaseEntity
{
	public User(long id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime? deletedAt,
		string username, string passwordHash, string email, bool emailVerified, string phoneNumber) 
		: base(id,createdAt, updatedAt, isDeleted, deletedAt)
	{
		Username = username;
		PasswordHash = passwordHash;
		Email = email;
		EmailVerified = emailVerified;
		PhoneNumber = phoneNumber;
	}

	public string Username { get; set; }
	public string PasswordSalt { get; set; }
	public string PasswordHash { get; set; }
	public string Email { get; set; }
	public bool EmailVerified { get; set; }
	public string PhoneNumber { get; set; }

	public virtual UserProfile Profile { get; set; }
}
