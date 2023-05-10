using System.Linq.Expressions;

namespace Labb3ApiRoutes.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        //      Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        //      Task CreateAsync(T entity);
        //      Task RemoveAsync(T entity);
        //      Task UpdateAsync(T entity);
        //      Task SaveAsync();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
