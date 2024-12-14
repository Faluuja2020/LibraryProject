using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
    {
        private readonly ILibraryDatabase _database;

        public GetBooksQueryHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_database.Books);
        }
    }
}
