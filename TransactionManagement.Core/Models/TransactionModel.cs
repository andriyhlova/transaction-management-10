using TransactionManagement.Core.Entities;
using TransactionManagement.Core.Enums;

namespace TransactionManagement.Core.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public TransactionModel() { }

        public TransactionModel(Transaction transaction)
        {
            Id = transaction.Id;
            Description = transaction.Description;
            Amount = transaction.Amount;
            Type = transaction.Type;
            CreatedAt = transaction.CreatedAt;
        }

        public Transaction ToEntity()
        {
            return new Transaction
            {
                Id = Id,
                Description = Description,
                Amount = Amount,
                Type = Type,
                CreatedAt = CreatedAt
            };
        }
    }
}
