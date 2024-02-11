using BooksApi.Core.WebModels.Book;
using BooksApi.Core.Entities;
using AutoMapper;

namespace BooksApi.Application.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();
        }
    }
}