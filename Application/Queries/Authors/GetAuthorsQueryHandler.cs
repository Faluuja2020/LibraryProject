using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Queries.Authors
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<Author>>
    {
        private readonly ILibraryDatabase _database;

        public GetAuthorsQueryHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<List<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_database.Authors);
        }
    }
}
