using Moq;
using TransactionManagement.Core.Entities;
using TransactionManagement.Core.Repositories.Interfaces;
using TransactionManagement.Core.Services.Implementations;
using TransactionManagement.Core.Services.Interfaces;

namespace TransactionManagement.UnitTests
{
    public class TransactionManagementServiceTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
        private readonly ITransactionService _transactionService;

        public TransactionManagementServiceTests()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepositoryMock.Object);
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnValidRecord()
        {
            _transactionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Transaction());

            var transaction = await _transactionService.GetByIdAsync(It.IsAny<Guid>());

            _transactionRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
            Assert.NotNull(transaction);
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnEmptyRecord()
        {
            _transactionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Transaction?)null);

            var transaction = await _transactionService.GetByIdAsync(It.IsAny<Guid>());

            _transactionRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            Assert.Null(transaction);
        }
    }
}