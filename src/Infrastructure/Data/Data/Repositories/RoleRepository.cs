using AutoMapper;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShop.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IMapper _mapper;

    private readonly PostgresDbContext _dbContext;
    private readonly DbSet<Role> _dbSet;
    private readonly ILogger<RoleRepository> _logger;

    public RoleRepository(
        PostgresDbContext dbContext,
        ILogger<RoleRepository> logger,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Roles;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(Role entity)
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

    public async Task<Role> GetByIdAsync(long id)
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

    public async Task<bool> RemoveAsync(Role entity)
    {
        try
        {
            var item = await _dbSet
                .FirstOrDefaultAsync(item => 
                item.RoleType == entity.RoleType
                || item.Id == entity.Id
                || item.Title == entity.Title);

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

    public async Task<bool> UpdateAsync(Role entity)
    {
        var item = await GetByIdAsync(entity.Id);
        if (item is not null)
        {
            item = _mapper.Map<Role>(entity);
            _dbSet.Update(item);

            _logger.LogInformation("Entity was update successfully");
            return true;
        }

        _logger.LogWarning("Item was null. Can't update item.");
        return false;
    }
}