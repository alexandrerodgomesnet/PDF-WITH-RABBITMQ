using Core.Enums;

namespace Core.Repositories.DTOs
{
    public sealed record CashHistoryCreateDto(string Name, short Installments, HistoryType HistoryType, uint AmountInCents);
}