using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Repositories.Users
{
	public class UserRepository : IUserRepository
	{ 
		private readonly DbContext _dbContext;

		public UserRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<bool> AddAsync(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveAsync(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveByIdAsync(long id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(User entity)
		{
			throw new NotImplementedException();
		}
	}
}