using Application.Queries.Books;
using Application.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace Tests.ApplicationTests.Books
{
    public class GetBooksQueryHandlerTests
    {
        private readonly Mock<ILibraryDatabase> _mockDatabase;
        private readonly GetBooksQueryHandler _handler;

        public GetBooksQueryHandlerTests()
        {
            _mockDatabase = new Mock<ILibraryDatabase>();
            _handler = new GetBooksQueryHandler(_mockDatabase.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", AuthorId = 1 }, // Fixed: AuthorId instead of AuthorID
                new Book { Id = 2, Title = "Book 2", AuthorId = 2 }  // Fixed: AuthorId instead of AuthorID
            };
            _mockDatabase.Setup(db => db.Books).Returns(books);

            // Act
            var result = await _handler.Handle(new GetBooksQuery(), CancellationToken.None);

            // Assert
            Xunit.Assert.Equal(books.Count, result.Count);
            Xunit.Assert.Equal(books, result);
        }
    }
}
