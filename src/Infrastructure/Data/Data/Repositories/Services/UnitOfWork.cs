using Data;
using EShop.Data.Repositories.Users;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;

namespace EShop.Data.Repositories.Services
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly PostgresDbContext _dbContext;

		public IUserRepository Users { get; private set; }
		

		public UnitOfWork(PostgresDbContext dbContext)
		{
			_dbContext = dbContext;

			Users = new UserRepository(_dbContext);
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
}