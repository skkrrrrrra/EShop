using EShop.Domain.Entities.Base;
using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class UserProfile : BaseEntity
{
	public string First { get; set; }
	public string Last { get; set; }
	public string ImagePath { get; set; }
	public Sex Sex { get; set; }
}
