﻿using BooksApi.Domain.Entities;

namespace BooksApi.Application.Repositories
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorByIdAsync(int id);
        public Task<List<Author>> GetAuthorsAsync(int pageNumber = 1, int totalAuthorsInPage = 8);
        public Task<int> CreateAuthorAsync(Author author);
        public Task<int> RemoveAuthorAsync(int id);
        public Task<int> UpdateAuthorAsync(Author authorToUpdate);
    }
}