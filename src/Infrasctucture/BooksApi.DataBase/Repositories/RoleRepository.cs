using BooksApi.DataBase.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.DataBase.Entities;
using BooksApi.Domain.Enums;

namespace BooksApi.DataBase.Repositories
{
    public class RoleRepository(
        IDbContextFactory<MainContext> dbContextFactory) : IRoleRepository
    {
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<RoleEntity> GetRole(UserRole roleToGet)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var role = await context.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.UserRole == roleToGet);

                return role;
            }
        }
        public async Task<List<RoleEntity>> GetRoles()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var roles = await context.Roles
                    .AsNoTracking()
                    .ToListAsync();

                return roles;
            }
        }
    }
}
