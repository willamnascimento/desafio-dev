using Desafio.Domain.DTOs.ImportacaoCNAB;
using Microsoft.AspNetCore.Http;

namespace Desafio.Domain.Interfaces.Services;

public interface IImportacaoCNABService
{
    IEnumerable<ImportacaoCNABDto> GetAll(DateTime dataImportacao);

    Responses.HttpResponse Import(ICollection<IFormFile> arquivos);
}

