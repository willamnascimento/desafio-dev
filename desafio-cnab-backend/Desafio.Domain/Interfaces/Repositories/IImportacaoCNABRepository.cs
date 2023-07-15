using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repositories;

public interface IImportacaoCNABRepository : IRepository<ImportacaoCNAB>
{
    IEnumerable<ImportacaoCNAB> GetAll(DateTime dataImportacao);
}

