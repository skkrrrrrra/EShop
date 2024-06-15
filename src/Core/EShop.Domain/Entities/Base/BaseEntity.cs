namespace EShop.Domain.Entities.Base;

public class BaseEntity
{
	public BaseEntity(long id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime? deletedAt)
	{
		Id = id;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		IsDeleted = isDeleted;
		DeletedAt = deletedAt;
	}

	public long Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DeletedAt { get; set; } = null;
}
