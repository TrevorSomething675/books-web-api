using BooksApi.Infrastructure.Commands.BookFeatures.UpdateBook;
using BooksApi.Infrastructure.Commands.BookFeatures.CreateBook;
using BooksApi.Application.Models;
using BooksApi.Core.Shared;
using AutoMapper;

namespace BooksApi.Infrastructure.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Book, BookQueryModel>().ReverseMap();
        }
    }
}