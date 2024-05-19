using TransactionManagement.Core.Entities;

namespace TransactionManagement.Core.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IList<Transaction>> GetAllAsync();

        Task<Transaction?> GetByIdAsync(Guid id);

        Task CreateAsync(Transaction transaction);

        Task UpdateAsync(Transaction transaction);

        Task DeleteAsync(Guid id);
    }
}
