using MediatR;

namespace Application.Commands.Authors
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
