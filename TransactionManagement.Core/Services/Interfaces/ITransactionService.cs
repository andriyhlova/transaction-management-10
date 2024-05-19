using TransactionManagement.Core.Models;

namespace TransactionManagement.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IList<TransactionModel>> GetAllAsync();

        Task<TransactionModel?> GetByIdAsync(Guid id);

        Task CreateAsync(TransactionModel transaction);

        Task UpdateAsync(TransactionModel transaction);

        Task DeleteAsync(Guid id);
    }
}
