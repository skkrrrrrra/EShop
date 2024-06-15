namespace EShop.Domain.Entities.Base
{
	public class BaseEntityBase
	{
		public DateTime CreatedAt { get; set; }
		public DateTime? DeletedAt { get; set; } = null;
		public long Id { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime UpdatedAt { get; set; }
	}
}