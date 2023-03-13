using Core.Models;
using Core.Repositories.DTOs;

namespace Core.Repositories.Interfaces
{
    public interface ICashHistoryRepository
    {
        public Task<IEnumerable<CashHistory>> ListAsync();
        public Task CreateAsync(CashHistoryCreateDto dto);
    }
}