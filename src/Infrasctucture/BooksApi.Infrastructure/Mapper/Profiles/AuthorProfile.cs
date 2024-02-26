using BooksApi.Infrastructure.Commands.AuthorFeatures.CreateAuthor;
using BooksApi.Infrastructure.Commands.AuthorFeatures.UpdateAuthor;
using BooksApi.Core.Shared;
using BooksApi.Core.Models;
using AutoMapper;

namespace BooksApi.Infrastructure.Mapper.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();

            CreateMap<Author, AuthorQueryModel>().ReverseMap();
        }
    }
}