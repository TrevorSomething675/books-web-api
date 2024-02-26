using BooksApi.Domain.Enums;

namespace BooksApi.Application.Models
{
    public class Role
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}
