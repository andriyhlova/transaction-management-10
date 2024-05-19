using Microsoft.EntityFrameworkCore;
using TransactionManagement.Core.Entities;
using TransactionManagement.Core.Repositories.Interfaces;

namespace TransactionManagement.Infrastructure.Data.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Transaction>> GetAllAsync()
        {
            return await _context.Set<Transaction>().ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Transaction>().FindAsync(id);
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _context.Set<Transaction>().AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.Set<Transaction>().FindAsync(id);
            if (transaction != null)
            {
                _context.Entry(transaction).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
