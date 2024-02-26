using BooksApi.DataBase.Entities;
using BooksApi.Core.Models;
using AutoMapper;

namespace BooksApi.DataBase.Mapper.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorEntity>().ReverseMap();
        }
    }
}