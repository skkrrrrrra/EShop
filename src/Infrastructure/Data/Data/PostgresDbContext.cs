using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data;

public class PostgresDbContext : DbContext, IUnitOfWork
{
	public PostgresDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
	public DbSet<UserProfile> Profiles { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	IUserRepository IUnitOfWork.Users => throw new NotImplementedException();

	public async Task<bool> CompleteAsync()
	{
		var success = await SaveChangesAsync() > 0;
		return success;
	}
}
