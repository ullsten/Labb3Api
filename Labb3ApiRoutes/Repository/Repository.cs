using System.Linq.Expressions;
using Labb3ApiRoutes.Data;
using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Labb3ApiRoutes.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Labb3ApiRouteDbContext _db;
        internal DbSet<T> dbset;

        public Repository(Labb3ApiRouteDbContext context)
        {
            _db = context;
            this.dbset = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _db.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _db.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await SaveAsync() ;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
