using EShop.Domain.Entities.Base;

namespace EShop.Domain.Entities
{
	public class Role : BaseEntity
	{
		public string Title { get; set; }
		public RoleType RoleType { get; set; }
	}
}