using Desafio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers;

[ApiController]
[Route("api/v1/importacao")]
public class ImportacaoController : ControllerBase
{
    private readonly IImportacaoCNABService _service;

    public ImportacaoController(IImportacaoCNABService service)
    {
        _service = service;
    }

    [HttpGet]
    public  IActionResult Get(DateTime dataImportacao)
    {
        var importacoes = _service.GetAll(dataImportacao);
        return Ok(importacoes);
    }

    [HttpPost()]
    public async Task<ActionResult> EnviaArquivo([FromForm] ICollection<IFormFile> arquivos)
    {
        if (arquivos.Count == 0)
        {
            return BadRequest("ERRO: Nenhum arquivo enviado.");
        }

        return Ok(_service.Import(arquivos));

    }
}

