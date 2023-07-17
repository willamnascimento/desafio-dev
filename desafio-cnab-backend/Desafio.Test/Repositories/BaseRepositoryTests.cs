using Desafio.Domain.Entities;
using Desafio.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Desafio.Infra.Repositories.Tests
{
    public class ImportacaoCNABRepositoryTests
    {
        private readonly Mock<DbSet<ImportacaoCNAB>> mockDbSet;
        private readonly AppDbContext mockContext;
        private readonly ImportacaoCNABRepository importacaoCNABRepository;

        public ImportacaoCNABRepositoryTests()
        {
            mockDbSet = new Mock<DbSet<ImportacaoCNAB>>();
            mockContext = new InMemoryDbContextFactory().GetDbContext();
            importacaoCNABRepository = new ImportacaoCNABRepository(mockContext);
        }

        [Fact]
        public void GetAll_ShouldReturnAllEntities()
        {
            // Arrange
            var dataImportacao = DateTime.Now;
            var entities = new List<ImportacaoCNAB>
            {
                new ImportacaoCNAB { Id = 1, DataImportacao = dataImportacao },
                new ImportacaoCNAB { Id = 2, DataImportacao = dataImportacao },
                new ImportacaoCNAB { Id = 3, DataImportacao = DateTime.Now.AddDays(-1) }
            };


            var queryableEntities = entities.AsQueryable();

            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.Provider).Returns(queryableEntities.Provider);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.Expression).Returns(queryableEntities.Expression);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.ElementType).Returns(queryableEntities.ElementType);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.GetEnumerator()).Returns(queryableEntities.GetEnumerator());


            // Act
            var result = importacaoCNABRepository.GetAll();

            // Assert
            Assert.Equal(3, result.Count());
            Assert.Equal(entities[0].Id, result.First().Id);
            Assert.Equal(entities[2].Id, result.Last().Id);
        }


        [Fact]
        public void GetAll_ShouldReturnAllEntitiesWithMatchingDataImportacao()
        {
            // Arrange
            var dataImportacao = DateTime.Now;
            var entities = new List<ImportacaoCNAB>
            {
                new ImportacaoCNAB { Id = 1, DataImportacao = dataImportacao },
                new ImportacaoCNAB { Id = 2, DataImportacao = dataImportacao },
                new ImportacaoCNAB { Id = 3, DataImportacao = DateTime.Now.AddDays(-1) }
            };


            var queryableEntities = entities.AsQueryable();

            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.Provider).Returns(queryableEntities.Provider);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.Expression).Returns(queryableEntities.Expression);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.ElementType).Returns(queryableEntities.ElementType);
            mockDbSet.As<IQueryable<ImportacaoCNAB>>().Setup(m => m.GetEnumerator()).Returns(queryableEntities.GetEnumerator());


            // Act
            var result = importacaoCNABRepository.GetAll(dataImportacao);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(entities[0].Id, result.First().Id);
            Assert.Equal(entities[1].Id, result.Last().Id);
        }

    }



    public class InMemoryDbContextFactory
    {
        public AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                            // and also tried using SqlLite approach. But same issue reproduced.
                            .Options;
            var dbContext = new AppDbContext(options);

            var dataImportacao = DateTime.Now;

            //for (int i = 0; i < 3; i++)
            //{
            //    if (!dbContext.importacaoCNABs.Any(x => x.Id.Equals(i + 1)))
            //    {
            //        dbContext.importacaoCNABs.Add(new ImportacaoCNAB { Id = i + 1, DataImportacao = DateTime.Now.AddDays(i) });
            //    }
            //}

            if (dbContext.importacaoCNABs.Count() == 0)
            {
                dbContext.importacaoCNABs.Add(new ImportacaoCNAB { Id = 1, DataImportacao = dataImportacao });
                dbContext.importacaoCNABs.Add(new ImportacaoCNAB { Id = 2, DataImportacao = dataImportacao });
                dbContext.importacaoCNABs.Add(new ImportacaoCNAB { Id = 3, DataImportacao = DateTime.Now.AddDays(-1) });

                dbContext.SaveChanges();
            }

            return dbContext;
        }
    }
}
