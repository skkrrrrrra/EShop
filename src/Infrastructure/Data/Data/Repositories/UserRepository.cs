﻿using AutoMapper;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;

    private readonly PostgresDbContext _dbContext;
    private readonly DbSet<User> _dbSet;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(
        PostgresDbContext dbContext,
        ILogger<UserRepository> logger,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Users;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(User entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);

            _logger.LogInformation("Entity was add successfully");
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
            var result = await _dbSet.FirstOrDefaultAsync(item => item.Id == id);
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
            var item = await _dbSet
                .FirstOrDefaultAsync(item =>
                    item.Id == entity.Id
                    || item.Email == entity.Email
                    || item.PhoneNumber == entity.PhoneNumber);

            if (item is not null)
            {
                _dbSet.Remove(item);

                _logger.LogInformation("Entity was remove successfully");
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
            if (item is not null)
            {
                var result = _dbSet.Remove(item);

                _logger.LogInformation("Entity was update successfully");
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
        if (item is not null)
        {
            item = _mapper.Map<User>(entity);
            _dbSet.Update(item);

            _logger.LogInformation("Entity was update successfully");
            return true;
        }

        _logger.LogWarning("Item was null. Can't update item.");
        return false;
    }
}