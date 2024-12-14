using Application.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.FakeDatabase
{
    public class LibraryDatabase : ILibraryDatabase
    {
        public List<Book> Books { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
    }
}
