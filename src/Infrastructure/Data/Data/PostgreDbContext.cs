using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class PostgreDbContext : DbContext
	{
		public PostgreDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<UserProfile> Profiles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
