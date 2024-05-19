using TransactionManagement.Core.Models;
using TransactionManagement.Core.Repositories.Interfaces;
using TransactionManagement.Core.Services.Interfaces;

namespace TransactionManagement.Core.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IList<TransactionModel>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();

            return transactions.Select(t => new TransactionModel(t)).ToList();
        }

        public async Task<TransactionModel?> GetByIdAsync(Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return null;
            }

            return new TransactionModel(transaction);
        }

        public async Task CreateAsync(TransactionModel transaction)
        {
            transaction.CreatedAt = DateTime.UtcNow;
            await _transactionRepository.CreateAsync(transaction.ToEntity());
        }

        public async Task UpdateAsync(TransactionModel transaction)
        {
            await _transactionRepository.UpdateAsync(transaction.ToEntity());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _transactionRepository.DeleteAsync(id);
        }
    }
}
