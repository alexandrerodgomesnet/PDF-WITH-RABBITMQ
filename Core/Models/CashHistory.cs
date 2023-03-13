using Core.Enums;

namespace Core.Models
{
    public sealed class CashHistory : Model<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public short Installments { get; set; }
        public HistoryType HistoryType { get; set; }
        public uint AmountInCents { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}