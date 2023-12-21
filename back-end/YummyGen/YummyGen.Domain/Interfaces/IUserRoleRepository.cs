using YummyGen.Domain;

namespace YummyGen.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<User> AssignRoleToUser(User user, string roleName);
        Task<string> GetRoleByUser(User user);
        Task<IEnumerable<User>> GetUsersInRole(string roleName);
        Task<bool> HasRole(User user, string roleName);
        Task<User> RemoveRoleFromUser(User user, string roleName);
    }
}