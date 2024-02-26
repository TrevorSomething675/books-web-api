using BooksApi.DataBase.Entities;
using BooksApi.Domain.Enums;

namespace BooksApi.DataBase.Repositories.Abstractions
{
    public interface IRoleRepository
    {
        public Task<List<RoleEntity>> GetRoles();
        public Task<RoleEntity> GetRole(UserRole roleToGet);
    }
}