﻿namespace BooksApi.Core.DtoModels
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookDto> Books { get; set; }
    }
}