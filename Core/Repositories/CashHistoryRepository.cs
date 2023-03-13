using Core.Infra.Data.Context;
using Core.Models;
using Core.Repositories.DTOs;
using Core.Repositories.Interfaces;
using Core.Repositories.Queries;
using Dapper;

namespace Core.Repositories
{
    public class CashHistoryRepository : ICashHistoryRepository
    {
        private readonly IContext _context;
        public CashHistoryRepository(IContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CashHistoryCreateDto dto)
        {
            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(CashHistoryQueries.Create, dto);
        }

        public async Task<IEnumerable<CashHistory>> ListAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<CashHistory>(CashHistoryQueries.List);
        }
    }
}