using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PagueMe.DataProvider.Interfaces;
using PagueMe.DataProvider.Repositories;
using PagueMe.Domain.Entities;

[TestFixture]
public class LoanRepositoryTests
{
    private LoanRepository _loanRepository;
    private Mock<IApplicationDbContext> _mockContext;

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<IApplicationDbContext>();
        _loanRepository = new LoanRepository(_mockContext.Object);
    }

    [Test]
    public void CreateLoan_ShouldAddLoan()
    {
        // Arrange
        var loan = new Loan();
        var mockSet = new Mock<DbSet<Loan>>();

        _mockContext.Setup(m => m.Loan).Returns(mockSet.Object);
        _mockContext.Setup(m => m.SaveChanges()).Returns(1); // Simula a operação de salvar as alterações

        // Act
        _loanRepository.CreateLoan(loan);

        // Assert
        mockSet.Verify(m => m.Add(It.IsAny<Loan>()), Times.Once());
        _mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}