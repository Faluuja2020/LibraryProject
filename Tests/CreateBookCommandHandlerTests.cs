using Application.Commands.Books;
using Application.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace Tests.ApplicationTests.Books
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<ILibraryDatabase> _mockDatabase;
        private readonly CreateBookCommandHandler _handler;

        public CreateBookCommandHandlerTests()
        {
            _mockDatabase = new Mock<ILibraryDatabase>();
            _handler = new CreateBookCommandHandler(_mockDatabase.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddBookToDatabase()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "Test Book",
                AuthorId = 1
            };

            _mockDatabase.Setup(db => db.Books).Returns(new List<Book>());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockDatabase.Verify(db => db.Books.Add(It.IsAny<Book>()), Times.Once);
            Xunit.Assert.True(result > 0); // Book ID should be greater than 0
        }
    }
}
