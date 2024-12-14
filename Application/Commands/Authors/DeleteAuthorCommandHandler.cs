using Application.Interfaces;
using MediatR;

namespace Application.Commands.Authors
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly ILibraryDatabase _database;

        public DeleteAuthorCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _database.Authors.FirstOrDefault(a => a.Id == request.Id);
            if (author == null) return await Task.FromResult(false);

            _database.Authors.Remove(author);
            return await Task.FromResult(true);
        }
    }
}
