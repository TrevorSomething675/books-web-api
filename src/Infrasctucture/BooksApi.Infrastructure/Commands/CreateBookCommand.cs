using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Commands
{
    public class CreateBookCommand
    {
        public Book Book { get; set; }
    }
}