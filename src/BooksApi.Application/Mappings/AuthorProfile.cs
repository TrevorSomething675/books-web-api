using BooksApi.Core.WebModels.Author;
using BooksApi.Core.Entities;
using AutoMapper;

namespace BooksApi.Application.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequest, Author>();
            CreateMap<Author, AuthorResponse>();
        }
    }
}