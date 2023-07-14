using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Responses;

namespace Desafio.Domain.Interfaces.Services;

public interface IImportacaoCNABService
{
    Task<IEnumerable<ImportacaoCNABDto>> GetAll();

    Task<HttpResponse> Create(ImportacaoCNABDto dto);
}

