﻿using EShop.Domain.Constants;
using EShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Domain.Entities;

[Table(Tables.Users)]
public class User : BaseEntity
{
	public User(long id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime? deletedAt,
		string password, string email, bool emailVerified, string phoneNumber) 
	: base(id,createdAt, updatedAt, isDeleted, deletedAt)
	{
		Email = email;
		EmailVerified = emailVerified;
		PhoneNumber = phoneNumber;
	}

	public string Password { get; set; }
	public string Email { get; set; }
	public bool EmailVerified { get; set; }
	public string PhoneNumber { get; set; }
	public List<Role> Roles { get; set; }

	public virtual UserProfile Profile { get; set; }
}
