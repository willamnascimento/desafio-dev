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

    public IEnumerable<T> GetAll()
    {
        return  dbSet.ToList();
    }

    public T Insert(T entity)
    {

        entity.DataImportacao = DateTime.Now;
        dbSet.Add(entity);

        context.SaveChanges();

        return entity;
    }

    
}
