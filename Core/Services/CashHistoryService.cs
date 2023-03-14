using Core.Models;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class CashHistoryService : ICashHistoryService
    {
        private readonly ICashHistoryRepository _repository;
        public CashHistoryService(ICashHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CashHistory>> ListAsync()
        {
            var result = await _repository.ListAsync();
            return result.ToList();
        }
    }
}