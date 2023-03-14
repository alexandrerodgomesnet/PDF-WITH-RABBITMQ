using FluentMigrator;

namespace Core.Infra.Data.Migrations
{
    [Migration(99999999)]
    public class Seed : Migration
    {
        private const string tableName = "CashHistory";
        public override void Down()
        {
            Delete.FromTable(tableName).AllRows();
        }

        public override void Up()
        {
            for(var i = 1; i <= 500; i++)
            {
                var rand = new Random();
                Insert.IntoTable(tableName)
                .Row(new {
                    Name = $"Venda do curso numero {i}",
                    Installments = (int)rand.NextInt64(-1, 12),
                    HistoryType = rand.Next() % 2 == 0 ? 1 : -1,
                    AmountInCents = (int)rand.NextInt64(100, 100_000)
                });
            }
        }
    }
}