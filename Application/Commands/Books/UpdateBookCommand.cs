using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
    }
}
