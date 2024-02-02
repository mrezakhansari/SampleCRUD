using Microsoft.EntityFrameworkCore;
using SampleCRUD.Domain;
using SampleCRUD.Persistence.DatabaseContext;

namespace SampleCRUD.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly SampleCRUDDatabaseContext _context;

    public GenericRepository(SampleCRUDDatabaseContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
