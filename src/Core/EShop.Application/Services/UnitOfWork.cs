using AutoMapper;
using Data;
using EShop.Data.Repositories.Users;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using Microsoft.Extensions.Logging;

namespace EShop.Application.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
	private readonly PostgresDbContext _dbContext;


	private readonly ILogger<UserRepository> _logger;
	private readonly IMapper _mapper;
	public IUserRepository Users { get; private set; }


	public UnitOfWork(
		PostgresDbContext dbContext,
		ILogger<UserRepository> logger,
		IMapper mapper)
	{
		_dbContext = dbContext;

		_mapper = mapper;
		_logger = logger;
		Users = new UserRepository(_dbContext, _logger, _mapper);
	}

	public async Task<bool> CompleteAsync()
	{
		await _dbContext.SaveChangesAsync();
		return true;
	}

	public void Dispose()
	{
		_dbContext.Dispose();
	}
}