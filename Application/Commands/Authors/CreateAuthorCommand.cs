using MediatR;

namespace Application.Commands.Authors
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string? Name { get; set; }
    }
}
