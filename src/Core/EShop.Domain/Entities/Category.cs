using EShop.Domain.Enums;

namespace EShop.Domain.Entities;

public class Category
{
	public string Title { get; set; }
	public Affiliation Affiliation { get; set; }

	public virtual List<Product> Products { get; set; }
}
