using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories;

public class ImportacaoCNABRepository : BaseRepository<ImportacaoCNAB>, IImportacaoCNABRepository
{
    private readonly DbSet<ImportacaoCNAB> dbSet;

    public ImportacaoCNABRepository(AppDbContext _context) : base(_context)
    {
        dbSet = _context.Set<ImportacaoCNAB>();
    }

    public IEnumerable<ImportacaoCNAB> GetAll(DateTime dataImportacao)
    {
        return dbSet.Where(x => x.DataImportacao.Date == dataImportacao.Date).ToList();
    }
}

