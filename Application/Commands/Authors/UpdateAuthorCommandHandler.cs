using Application.Interfaces;
using MediatR;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly ILibraryDatabase _database;

        public UpdateAuthorCommandHandler(ILibraryDatabase database)
        {
            _database = database;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _database.Authors.FirstOrDefault(a => a.Id == request.Id);
            if (author == null) return await Task.FromResult(false);

            author.Name = request.Name;
            return await Task.FromResult(true);
        }
    }
}
