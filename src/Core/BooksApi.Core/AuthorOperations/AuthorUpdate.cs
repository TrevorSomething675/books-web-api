using BooksApi.Domain.Entities;

namespace BooksApi.Core.AuthorOperations
{
    public static class AuthorUpdate
    {
        public static Author AuthorUpdateFields(Author authorToUpdate, out Author author)
        {
            author = authorToUpdate;
            return author;
        }
    }
}