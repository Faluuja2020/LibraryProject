using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Books
{
    public class GetBooksQuery : IRequest<List<Book>> { }
}
