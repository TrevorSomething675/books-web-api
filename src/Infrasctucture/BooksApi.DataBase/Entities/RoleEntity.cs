using BooksApi.Core.Enums;

namespace BooksApi.DataBase.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}