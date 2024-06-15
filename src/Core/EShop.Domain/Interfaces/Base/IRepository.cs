namespace EShop.Domain.Interfaces.Base;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);

    Task<bool> AddAsync(TEntity entity);

    Task<bool> RemoveAsync(TEntity entity);

    Task<bool> RemoveByIdAsync(long id);

    Task<bool> UpdateAsync(TEntity entity);
}