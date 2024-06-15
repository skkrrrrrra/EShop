using Data;
using EShop.Data.Repositories.Users;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using Microsoft.Extensions.Logging;

namespace EShop.Data.Repositories.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
	private readonly PostgresDbContext _dbContext;


	private readonly ILogger<UserRepository> _logger;
	public IUserRepository Users { get; private set; }
	

	public UnitOfWork(
		PostgresDbContext dbContext,
		ILogger<UserRepository> logger)
	{
		_dbContext = dbContext;

		_logger = logger;
		Users = new UserRepository(_dbContext, _logger);
	}

	public async Task CompleteAsync()
	{
		await _dbContext.SaveChangesAsync();
	}

	public void Dispose()
	{
		_dbContext.Dispose();
	}
}