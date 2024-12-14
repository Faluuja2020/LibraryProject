using Application.Interfaces;
using MediatR;

namespace Application.Commands.Books
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly ILibraryDatabase _database;

        public DeleteBookCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _database.Books.FirstOrDefault(b => b.Id == request.Id);
            if (book == null) return await Task.FromResult(false);

            _database.Books.Remove(book);
            return await Task.FromResult(true);
        }
    }
}
