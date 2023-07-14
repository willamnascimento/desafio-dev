using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.DI;

public class ConfigRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IImportacaoCNABRepository, ImportacaoCNABRepository>();
    }
}

