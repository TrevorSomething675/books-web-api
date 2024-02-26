using BooksApi.Core.Enums;

namespace BooksApi.Core.Models
{
    public class Role
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}
