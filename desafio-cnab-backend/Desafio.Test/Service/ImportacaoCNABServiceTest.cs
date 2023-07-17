using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Desafio.Domain.DTOs.ImportacaoCNAB;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Responses;
using Desafio.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Xunit;

namespace Desafio.Service.Tests
{
    public class ImportacaoCNABServiceTests
    {
        private ImportacaoCNABService importacaoCNABService;
        private IMapper mapper;
        private Mock<IImportacaoCNABRepository> mockRepository;

        public ImportacaoCNABServiceTests()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportacaoCNABDto, ImportacaoCNAB>();
            }).CreateMapper();

            mockRepository = new Mock<IImportacaoCNABRepository>();
            importacaoCNABService = new ImportacaoCNABService(mapper, mockRepository.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnImportacaoCNABDtoList_WhenDataImportacaoIsValid()
        {
            // Arrange
            DateTime dataImportacao = DateTime.Now;
            IEnumerable<ImportacaoCNAB> entities = new List<ImportacaoCNAB>();
            mockRepository.Setup(r => r.GetAll(dataImportacao)).Returns(entities);

            // Act
            IEnumerable<ImportacaoCNABDto> result = importacaoCNABService.GetAll(dataImportacao);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Import_ShouldReturnSuccessResponse_WhenArquivosAreValid()
        {
            // Arrange
            //Setup mock file using a memory stream
            var content = "5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ";
            var fileName = "cnab.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            ICollection<IFormFile> arquivos = new List<IFormFile>();
            arquivos.Add(file);
            var httpResponse = new Domain.Responses.HttpResponse { Message = "Importação feita com sucesso.", StatusCode = 200 };

            // Act
            Domain.Responses.HttpResponse result = importacaoCNABService.Import(arquivos);

            // Assert
            Assert.Equal(httpResponse.Message, result.Message);
            Assert.Equal(httpResponse.StatusCode, result.StatusCode);
        }

        [Fact]
        public void Import_ShouldReturnErrorResponse_WhenAnExceptionOccurs()
        {
            // Arrange
            ICollection<IFormFile> arquivos = new List<IFormFile>();
            var exceptionMessage = "Lista de arquivos vazia.";
            mockRepository.Setup(r => r.Insert(It.IsAny<ImportacaoCNAB>())).Throws(new Exception(exceptionMessage));
            var expectedResponse = new Domain.Responses.HttpResponse { Message = "Houve problema para importacao. ERRO: " + exceptionMessage, StatusCode = 500 };

            // Act
            Domain.Responses.HttpResponse result = importacaoCNABService.Import(arquivos);

            // Assert
            Assert.Equal(expectedResponse.Message, result.Message);
            Assert.Equal(expectedResponse.StatusCode, result.StatusCode);
        }

        

    }
}
