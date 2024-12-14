using MediatR;

namespace Application.Commands.Books
{
    public class CreateBookCommand : IRequest<int>
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }
    }
}
