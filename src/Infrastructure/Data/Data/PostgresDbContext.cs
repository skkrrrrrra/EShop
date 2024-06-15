using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class PostgresDbContext : DbContext
	{
		public PostgresDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<UserProfile> Profiles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
