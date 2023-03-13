using System.Reflection;
using Core.Infra.Data;
using Core.Infra.Data.Context;
using Core.Repositories;
using Core.Repositories.Interfaces;
using FluentMigrator.Runner;

namespace Core.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IContext, DapperContext>();
            services.AddSingleton<Database>();

            services.AddLogging(x => x.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(x => x.AddSqlServer()
                    .WithGlobalConnectionString(configuration.GetConnectionString("Default"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICashHistoryRepository, CashHistoryRepository>();
            return services;
        }
    }
}