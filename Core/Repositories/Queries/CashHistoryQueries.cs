namespace Core.Repositories.Queries
{
    public static class CashHistoryQueries
    {
        public const string List = "SELECT * FROM CashHistory ORDER BY CreatedAt ASC";
        public const string Create = @"INSERT INTO CashHistory (Name, Installments, HistoryType, AmountInCents) 
                                        VALUES (@Name, @Installments, @HistoryType, @AmountInCents)";
    }
}