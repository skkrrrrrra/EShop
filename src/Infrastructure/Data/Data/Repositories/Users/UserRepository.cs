using Data;
using EShop.Common.Helpers;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShop.Data.Repositories.Users
{
	public class UserRepository : IUserRepository
	{
		private readonly PostgresDbContext _dbContext;
		private readonly ILogger<UserRepository> _logger;

		public UserRepository(PostgresDbContext dbContext, ILogger<UserRepository> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		public async Task<bool> AddAsync(User entity)
		{
			try
			{
				await _dbContext.Users.AddAsync(entity);
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}

		public async Task<User> GetByIdAsync(int id)
		{
			try
			{
				var user = await _dbContext
					.Users
					.FirstOrDefaultAsync(item =>
						item.Id == id
						&& item.IsDeleted == false);

				return user;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return null;
			}
		}

		public async Task<bool> RemoveAsync(User entity)
		{
			try
			{
				var item = await _dbContext
					.Users
					.AsNoTracking()
					.FirstOrDefaultAsync(item =>
						item.Id == entity.Id
						|| item.Username == entity.Username
						|| item.Email == entity.Email
						|| item.PhoneNumber == entity.PhoneNumber);

				item.IsDeleted = true;
				item.DeletedAt = DateHelper.GetCurrentDateTime();

				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}

		public async Task<bool> RemoveByIdAsync(long id)
		{
			try
			{
				var item = await _dbContext
					.Users
					.AsNoTracking()
					.FirstOrDefaultAsync(item => item.Id == id);

				item.IsDeleted = true;
				item.DeletedAt = DateHelper.GetCurrentDateTime();

				return true;

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}

		public async Task<bool> UpdateAsync(User entity)
		{
			try
			{
				var item = await _dbContext
						.Users
						.AsNoTracking()
						.FirstOrDefaultAsync(item => item.Id == entity.Id
						|| item.Username == entity.Username
						|| item.Email == entity.Email);

				item.IsDeleted = true;
				item.DeletedAt = DateHelper.GetCurrentDateTime();
				
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}
	}
}