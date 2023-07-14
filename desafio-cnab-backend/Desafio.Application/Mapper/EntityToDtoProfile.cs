using AutoMapper;
using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Entities;

namespace Desafio.Application.Mapper;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<ImportacaoCNABDto, ImportacaoCNAB>()
            .ReverseMap();

    }
}
