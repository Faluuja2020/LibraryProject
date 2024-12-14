using MediatR;

namespace Application.Commands.Books
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
