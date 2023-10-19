using Identity.Application.Interfaces.Repositories;
using Identity.Domain.Common;
using Identity.Persistence.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Implementations.Repositories
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        readonly IdentityContext _identityContext;
        public EfRepository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }
        public DbSet<T> Table => _identityContext.Set<T>();
        public virtual IQueryable<T> GetAll(bool tracking = true)
        {

            if (!tracking)
                return Table.AsNoTracking();
            else
                return Table.AsQueryable();
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true)
        {

            if (!tracking)
                return Table.Where(expression).AsNoTracking();
            else
                return Table.Where(expression).AsQueryable();

        }
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(expression);
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return null;
                {
                    await Table.AddAsync(entity);
                    return entity;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<bool> AddRangeAsync(List<T> entites)
        {
            if (entites.Count == 0)
                return false;
            else
            {
                await Table.AddRangeAsync(entites);
                await _identityContext.SaveChangesAsync();
                return true;
            }

        }
        public async Task<T> RemoveAsync(T entity)
        {
            if (entity == null)
                return null;
            else
            {
                entity.IsDeleted = true;
                Table.Update(entity);
                await _identityContext.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<T> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            entity.IsDeleted = true;
            if (entity == null)
                return null;
            else
            {
                Table.Update(entity);
                await _identityContext.SaveChangesAsync();
                return entity;

            }

        }
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                return null;
            else
            {
                Table.Update(entity);
                await _identityContext.SaveChangesAsync();
                return entity;

            }
        }
        public async Task<bool> RemoveRangeAsync(List<T> entites)
        {
            if (entites.Count == 0)
                return false;
            else
            {
                Table.RemoveRange(entites);
                await _identityContext.SaveChangesAsync();
                return true;
            }

        }


    }
}
