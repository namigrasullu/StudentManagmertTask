using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Abstracts;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudentManagement.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Set { get; }

    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T?> GetAsync(int id, bool tracking = true);
    Task<T?> GetAsync(Expression<Func<T, bool>> method, bool tracking = true);

    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    bool Update(T entity);
    Task<bool> RemoveAsync(int id);
    Task<int> SaveChangesAsync();
}
