using System;
using AutoMapper;
using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Responses;

namespace Desafio.Service.Services;

public class ImportacaoCNABService : IImportacaoCNABService
{
    private readonly IMapper mapper;
    private IImportacaoCNABRepository repository;

    public ImportacaoCNABService(IMapper mapper, IImportacaoCNABRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public Task<HttpResponse> Create(ImportacaoCNABDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ImportacaoCNABDto>> GetAll()
    {
        var entities = await repository.GetAll();

        return mapper.Map<IEnumerable<ImportacaoCNABDto>>(entities);
    }
}

