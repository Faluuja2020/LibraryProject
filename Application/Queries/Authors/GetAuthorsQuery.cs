using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Authors
{
    public class GetAuthorsQuery : IRequest<List<Author>> { }
}
