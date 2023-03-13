using System.Data;

namespace Core.Infra.Data.Context
{
    public interface IContext
    {
        IDbConnection CreateConnection();
        IDbConnection CreateMasterConnection();
    }
}