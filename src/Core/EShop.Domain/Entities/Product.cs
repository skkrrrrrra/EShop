using EShop.Domain.Entities.Base;

namespace EShop.Domain.Entities;

public class Product : BaseProduct
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string ImagePath { get; set; }


	public long CategoryId { get; set; }
}
