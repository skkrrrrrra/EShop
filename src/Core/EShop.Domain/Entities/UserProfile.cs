using EShop.Domain.Entities.Base;
using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class UserProfile : BaseEntity
{
	public UserProfile() : base() { }

	public UserProfile(long id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime? deletedAt,
		string first, string last, string image, Sex sex, int userId) 
		: base(id, createdAt, updatedAt, isDeleted, deletedAt)
	{
		First = first;
		Last = last;
		ImagePath = image;
		Sex = sex;
		UserId = userId;
	}

	public string First { get; set; }
	public string Last { get; set; }
	public string ImagePath { get; set; }
	public Sex Sex { get; set; }
	public int UserId { get; set; }
	public virtual User User { get; set; }
}
