using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Commands.Authors
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly ILibraryDatabase _database;

        public CreateAuthorCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = _database.Authors.Count + 1, // Simulerad ID-generering
                Name = request.Name
            };

            _database.Authors.Add(author);
            return await Task.FromResult(author.Id);
        }
    }
}
