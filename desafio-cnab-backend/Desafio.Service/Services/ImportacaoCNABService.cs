using System;
using AutoMapper;
using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Responses;
using Microsoft.AspNetCore.Http;

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

    public IEnumerable<ImportacaoCNABDto> GetAll(DateTime dataImportacao)
    {
        var entities = repository.GetAll(dataImportacao);

        return mapper.Map<IEnumerable<ImportacaoCNABDto>>(entities);
    }

    public Domain.Responses.HttpResponse Import(ICollection<IFormFile> arquivos)
    {
        try
        {
            if (arquivos.Count == 0)
                throw new Exception("Lista de arquivos vazia.");

            foreach (var arquivo in arquivos)
            {
                using (var stream = new MemoryStream())
                {
                    ReadFile(arquivo.OpenReadStream());
                }
            }
            return new Domain.Responses.HttpResponse { Message = "Importação feita com sucesso.", StatusCode = 200 };
        }
        catch (Exception e)
        {
            return new Domain.Responses.HttpResponse { Message = "Houve problema para importacao. ERRO: " + e.Message, StatusCode = 500 };
        }
    }

    private void ReadFile(Stream stream)
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                FormatData(line);
        }
    }

    private void FormatData(string line)
    {
        var tipo = line.Substring(0, 1);
        var data = line.Substring(1, 8);
        var valor = line.Substring(10, 10);
        var cpf = line.Substring(19,11);
        var cartao = line.Substring(30, 12);
        var hora = line.Substring(42, 6);
        var representanteLoja = line.Substring(48, 14);
        var loja = line.Substring(62);


        var dto = new ImportacaoCNABDto
        {
            Tipo = int.Parse(tipo),
            Data = FormatDate(data),
            Valor = FormatValue(valor,tipo),
            Cpf = cpf,
            Cartao = cartao,
            Hora = FormatTime(data, hora),
            RepresentanteLoja = representanteLoja,
            Loja = loja
        };

        Insere(dto);
    }

    private void Insere(ImportacaoCNABDto dto)
    {
        var entidade = mapper.Map<ImportacaoCNAB>(dto);
        repository.Insert(entidade);
    }

    private DateTime FormatDate(string date)
    {
        var ano = date.Substring(0, 4);
        var mes = date.Substring(4, 2);
        var dia = date.Substring(6);

        return new DateTime(int.Parse(ano), int.Parse(mes), int.Parse(dia));
    }

    private DateTime FormatTime(string date, string time)
    {
        var data = FormatDate(date);
        var horas = time.Substring(0, 2);
        var minutos = time.Substring(2, 2);
        var segundos = time.Substring(4);

        return new DateTime(data.Year, data.Month, data.Day, int.Parse(horas), int.Parse(minutos), int.Parse(segundos));
    }

    private decimal FormatValue(string valor, string tipo)
    {
        var sinal = TipoSinal.returnSignType(tipo);

        if (sinal.Equals("+"))
            return decimal.Parse(valor) / 100;

        return (decimal.Parse(valor) / 100) * -1;
    }
}

