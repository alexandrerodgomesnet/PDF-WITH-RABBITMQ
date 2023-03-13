using System.Data;
using System.Data.SqlClient;

namespace Core.Infra.Data.Context
{
    public sealed class DapperContext : IContext
    {
        public readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() 
            => new SqlConnection(_configuration.GetConnectionString("Default"));
        public IDbConnection CreateMasterConnection()
            => new SqlConnection(_configuration.GetConnectionString("Master"));
    }
}