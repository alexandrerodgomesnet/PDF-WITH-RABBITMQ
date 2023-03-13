using FluentMigrator;

namespace Core.Infra.Data.Migrations
{
    [Migration(1)]
    public class CreateCashHistoryTable_1 : Migration
    {
        private const string TableName = "CashHistory";
        public override void Down()
        {
            Delete.Table(TableName);
        }

        public override void Up()
        {
            Create
                .Table(TableName)
                .WithColumn("Id").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid).PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Installments").AsInt16().NotNullable().WithDefaultValue(-1)
                .WithColumn("HistoryType").AsInt16().NotNullable()
                .WithColumn("AmountInCents").AsInt64().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }
    }
}