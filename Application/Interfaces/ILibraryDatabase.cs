using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILibraryDatabase
    {
        List<Book> Books { get; }
        List<Author> Authors { get; }
    }
}
