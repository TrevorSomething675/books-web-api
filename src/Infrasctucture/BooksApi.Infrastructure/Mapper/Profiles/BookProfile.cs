using BooksApi.Infrastructure.Commands.BookFeature.UpdateBook;
using BooksApi.Infrastructure.Commands.BookFeature.CreateBook;
using BooksApi.Domain.Entities;
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