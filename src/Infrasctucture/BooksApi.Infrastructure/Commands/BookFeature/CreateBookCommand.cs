using BooksApi.Domain.Entities;

namespace BooksApi.Infrastructure.Commands.BookFeature
{
    public class CreateBookCommand
    {
        public Book Book { get; set; }
    }
}