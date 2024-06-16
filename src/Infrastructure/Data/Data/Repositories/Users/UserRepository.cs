using AutoMapper;
using Data;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShop.Data.Repositories.Users
{
	public class UserRepository : IUserRepository
	{
		private readonly IMapper _mapper;

		private readonly PostgresDbContext _dbContext;
		private readonly DbSet<User> _usersDbSet;
		private readonly ILogger<UserRepository> _logger;

		public UserRepository(
			PostgresDbContext dbContext, 
			ILogger<UserRepository> logger,
			IMapper mapper)
		{
			_dbContext = dbContext;
			_usersDbSet = _dbContext.Users;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<bool> AddAsync(User entity)
		{
			try
			{
				await _usersDbSet.AddAsync(entity);

				_logger.LogInformation("User was add successfully");
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}

		public async Task<User> GetByIdAsync(long id)
		{
			try
			{
				var result = await _usersDbSet.FirstOrDefaultAsync(item => item.Id == id);
				return result;
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
				var item = await _usersDbSet
					.FirstOrDefaultAsync(item => 
						item.Id == entity.Id
						|| item.Email == entity.Email
						|| item.PhoneNumber == entity.PhoneNumber);

				if(item is not null)
				{
					_usersDbSet.Remove(item);

					_logger.LogInformation("User was remove successfully");
					return true;
				}

				_logger.LogWarning("Item was null. Can't delete item.");
				return false;
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
				var item = await GetByIdAsync(id);
				if(item is not null)
				{
					var result = _usersDbSet.Remove(item);

					_logger.LogInformation("User was update successfully");
					return true;
				}

				_logger.LogWarning("Item was null. Can't delete item.");
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return false;
			}
		}

		public async Task<bool> UpdateAsync(User entity)
		{
			var item = await GetByIdAsync(entity.Id);
			if(item is not null)
			{
				item = _mapper.Map<User>(entity);
				_usersDbSet.Update(item);

				_logger.LogInformation("User was update successfully");
				return true;
			}

			_logger.LogWarning("Item was null. Can't update item.");
			return false;
		}
	}
}