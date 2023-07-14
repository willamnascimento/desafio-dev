using Desafio.Domain.Interfaces.Services;
using Desafio.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.DI;

public class ConfigService
{
    public static void ConfigureDependenciesService(IServiceCollection services)
    {
        services.AddTransient<IImportacaoCNABService, ImportacaoCNABService>();
    }
}

