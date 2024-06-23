using EShop.Domain.Entities.Base;
using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class Role : BaseEntity
{
	public string Title { get; set; }
	public RoleType RoleType { get; set; }

	public virtual User User { get; set; }
}