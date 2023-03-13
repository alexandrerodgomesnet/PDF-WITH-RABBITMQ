namespace Core.Repositories.Queries
{
    public static class DatabaseQueries
    {
        public const string FindDatabaseQuery = "SELECT * FROM sys.databases WHERE name = '{0}';";
    }
}