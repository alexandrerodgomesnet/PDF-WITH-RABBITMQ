using Core.Infra.Data.Context;
using Core.Repositories.Queries;
using Dapper;

namespace Core.Infra.Data
{
    public sealed class Database
    {
        private readonly IContext _context;
        public Database(IContext context)
        {
            _context = context;
        }

        public void CreateDatabaseIfNotExists(string databaseName)
        {
            string query = string.Empty;
            var queryParams = new DynamicParameters();

            queryParams.Add("Name", databaseName);

            using var connection = _context.CreateMasterConnection();

            query = string.Format(DatabaseQueries.FindDatabaseQuery, databaseName);
            var databases = connection.Query(query, queryParams);
            
            if(!databases.Any())
                connection.Execute($"CREATE DATABASE {databaseName}");                
        }
    }
}