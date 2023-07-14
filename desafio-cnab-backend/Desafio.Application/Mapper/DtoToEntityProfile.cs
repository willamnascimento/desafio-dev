using AutoMapper;
using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Entities;

namespace Desafio.Application.Mapper;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<ImportacaoCNAB, ImportacaoCNABDto>()
            .ReverseMap();

    }
}

