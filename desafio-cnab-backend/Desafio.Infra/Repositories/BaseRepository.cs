using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext context;
    private DbSet<T> dbSet;

    public BaseRepository(AppDbContext _context)
    {
        this.context = _context;
        dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T> Insert(T entity)
    {

        entity.DataImportacao = DateTime.Now;
        dbSet.Add(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    
}
