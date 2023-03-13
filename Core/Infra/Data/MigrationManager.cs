using FluentMigrator.Runner;

namespace Core.Infra.Data
{
    public static class MigrationManager
    {
        public static IHost RunMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            databaseService.CreateDatabaseIfNotExists("PdfWithRabbitMQ");

            migrationService.ListMigrations();
            migrationService.MigrateUp();

            return host;
        }
    }
}