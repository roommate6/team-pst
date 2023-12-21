using Microsoft.AspNetCore.Identity;
using YummyGen.Domain;
using YummyGen.Domain.Interfaces;

namespace YummyGen.DataAccess.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserManager<User> userManager;

        public UserRoleRepository(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<User> AssignRoleToUser(User user, string roleName)
        {
            await userManager.AddToRoleAsync(user, roleName);
            return user;
        }

        public async Task<User> RemoveRoleFromUser(User user, string roleName)
        {
            await userManager.RemoveFromRoleAsync(user, roleName);
            return user;
        }

        public async Task<bool> HasRole(User user, string roleName)
        {
            return await userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<IEnumerable<User>> GetUsersInRole(string roleName)
        {
            return await userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<string> GetRoleByUser(User user)
        {
            string adminRole = Domain.Enums.Role.Admin.ToString();
            string normalUserRole = Domain.Enums.Role.User.ToString();

            if (await HasRole(user, adminRole))
            {
                return adminRole;
            }
            else if (await HasRole(user, normalUserRole))
            {
                return normalUserRole;
            }

            return "";
        }
    }
}
