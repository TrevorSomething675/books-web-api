using BooksApi.Domain.Entities;

namespace BooksApi.Core.AuthorOperations
{
    public static class BookUpdate
    {
        public static Book BookUpdateFields(Book bookToUpdate, Book book)
        {
            book.Name = bookToUpdate.Name;
            book.PagesCount = bookToUpdate.PagesCount;
            book.AuthorId = bookToUpdate.AuthorId;
            if(bookToUpdate.Author != null && bookToUpdate.AuthorId == bookToUpdate.Author.Id)
            {
                book.AuthorId = bookToUpdate.AuthorId;
                book.Author = book.Author;
            }
            return book;
        }
    }
}