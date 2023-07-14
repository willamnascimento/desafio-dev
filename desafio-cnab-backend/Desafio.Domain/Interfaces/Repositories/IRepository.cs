using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Insert(T entity);
    Task<IEnumerable<T>> GetAll();
}



