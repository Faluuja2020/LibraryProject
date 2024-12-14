using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly ILibraryDatabase _database;

        public UpdateBookCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _database.Books.FirstOrDefault(b => b.Id == request.Id);
            if (book == null) return await Task.FromResult(false);

            book.Title = request.Title;
            book.AuthorId = request.AuthorId;
            return await Task.FromResult(true);
        }
    }
}
