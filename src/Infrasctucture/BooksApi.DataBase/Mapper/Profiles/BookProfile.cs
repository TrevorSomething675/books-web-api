using BooksApi.DataBase.Entities;
using BooksApi.Core.Models;
using AutoMapper;

namespace BooksApi.DataBase.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookEntity>().ReverseMap();
        }
    }
}