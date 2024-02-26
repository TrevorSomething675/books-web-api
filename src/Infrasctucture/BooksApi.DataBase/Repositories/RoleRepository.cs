using BooksApi.Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using BookApi.Infrastructure.Data;
using BooksApi.Core.Models;
using BooksApi.Core.Enums;
using AutoMapper;

namespace BooksApi.DataBase.Repositories
{
    public class RoleRepository(
        IDbContextFactory<MainContext> dbContextFactory,
        IMapper mapper
        ) : IRoleRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Role> GetRole(UserRole roleToGet)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var role = await context.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.UserRole == roleToGet);

                return _mapper.Map<Role>(role);
            }
        }
        public async Task<List<Role>> GetRoles()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var roles = await context.Roles
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<Role>>(roles);
            }
        }
    }
}