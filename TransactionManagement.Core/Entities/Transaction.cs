using TransactionManagement.Core.Enums;

namespace TransactionManagement.Core.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
