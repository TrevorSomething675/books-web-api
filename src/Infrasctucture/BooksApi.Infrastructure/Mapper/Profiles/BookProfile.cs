using BooksApi.Domain.Entities;
using BooksApi.Core.Shared;
using AutoMapper;

namespace BooksApi.Infrastructure.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookQueryModel>().ReverseMap();
        }
    }
}