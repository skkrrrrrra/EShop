namespace EShop.Domain.Entities.Base;

public class BaseEntity
{
	public long Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public bool IsDeleted { get; set; }
	public DateTime DeletedAt { get; set; }
}
