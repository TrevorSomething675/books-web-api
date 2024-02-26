using BooksApi.Domain.Enums;

namespace BooksApi.DataBase.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}