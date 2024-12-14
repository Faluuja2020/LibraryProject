using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Commands.Books
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly ILibraryDatabase _database;

        public CreateBookCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = _database.Books.Count + 1, // Simulerad ID-generering
                Title = request.Title,
                AuthorId = request.AuthorId
            };

            _database.Books.Add(book);
            return await Task.FromResult(book.Id);
        }
    }
}
