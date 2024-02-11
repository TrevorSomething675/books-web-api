using BooksApi.Core.Entities;
using AutoMapper;
using BooksApi.Core.WebModels.Book;

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