using MediatR;

namespace Application.Commands.Authors
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
