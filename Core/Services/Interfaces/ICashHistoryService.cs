using Core.Models;

namespace Core.Services.Interfaces
{
    public interface ICashHistoryService
    {
        Task<List<CashHistory>> ListAsync();
    }
}