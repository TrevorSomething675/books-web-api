using BooksApi.Core.Models;
using BooksApi.Core.Enums;

namespace BooksApi.Core.Abstractions.Repositories
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetRoles();
        public Task<Role> GetRole(UserRole roleToGet);
    }
}