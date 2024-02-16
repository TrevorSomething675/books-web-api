using BooksApi.Domain.Entities;

namespace BooksApi.Core.AuthorOperations
{
    public static class AuthorUpdate
    {
        public static Author AuthorUpdateFields(Author authorToUpdate, Author author)
        {
            author.Name = authorToUpdate.Name;
            return author;
        }
    }
}