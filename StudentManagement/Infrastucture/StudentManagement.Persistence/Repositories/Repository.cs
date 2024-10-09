using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Repositories;
using StudentManagement.Domain.Abstracts;
using StudentManagement.Persistence.Context;
using System.Linq.Expressions;

namespace StudentManagement.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly StudentManagementDbContext _context;

    public Repository(StudentManagementDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Set => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        var entry = await Set.AddAsync(entity);
        return entry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        await Set.AddRangeAsync(entities);
    }

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Set.AsQueryable();
        return tracking ? query : query.AsNoTracking();
    }

    public async Task<T?> GetAsync(int id, bool tracking = true)
    {
        var query = Set.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Set.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(method);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Set.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();

        return query.Where(method);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var model = await Set.FirstOrDefaultAsync(x => x.Id == id);
        if(model is { })
        {
            model.IsDeleted = true;
            model.DeletedDate = DateTime.UtcNow;
            return true;
        }
        return false;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public bool Update(T entity)
    {
        var entry = Set.Update(entity);
        return entry.State == EntityState.Modified;
    }
}
