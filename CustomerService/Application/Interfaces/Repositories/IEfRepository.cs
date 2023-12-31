﻿using System.Linq.Expressions;
using CustomerService.Domain.Common;

namespace CustomerService.Application.Interfaces.Repositories
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(T entity);
        Task<T> RemoveAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entites);
        Task<bool> RemoveRangeAsync(List<T> entites);
    }
}
