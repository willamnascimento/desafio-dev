using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T Insert(T entity);
    IEnumerable<T> GetAll();
}



