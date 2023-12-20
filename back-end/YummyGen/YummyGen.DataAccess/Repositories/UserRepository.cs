using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(UserRepository.userManager));
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await userManager.Users.ToListAsync();
        }
        public async Task<User> GetById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }
        public async Task<User> Add(User entity)
        {
            await userManager.CreateAsync(entity);
            return entity;
        }
        public async Task Delete(User entity)
        {
            await userManager.DeleteAsync(entity);
        }
        public async Task<User> Update(User entity)
        {
            await userManager.UpdateAsync(entity);
            return entity;
        }
        public async Task<IEnumerable<User>> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return await userManager.Users.Where(expression).ToListAsync();
        }
        public async Task<bool> AnyByCondition(Expression<Func<User, bool>> expression)
        {
            return await userManager.Users.AnyAsync(expression);
        }
        public async Task<string> GetUserRole(User user)
        {
            var result = await userManager.GetRolesAsync(user);
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<User>> GetUsersByRoleName(string roleName)
        {
            return await userManager.GetUsersInRoleAsync(roleName);
        }
        public async Task<User> SingleByCondition(Expression<Func<User, bool>> expression)
        {
            return await userManager.Users.SingleOrDefaultAsync(expression);
        }
    }
}
