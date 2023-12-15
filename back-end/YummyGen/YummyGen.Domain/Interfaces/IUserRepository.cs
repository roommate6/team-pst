using System.Linq.Expressions;

namespace YummyGen.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Add(User entity);
        Task<bool> AnyByCondition(Expression<Func<User, bool>> expression);
        Task Delete(User entity);
        Task<IEnumerable<User>> FindByCondition(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<string> GetUserRole(User user);
        Task<IEnumerable<User>> GetUsersByRoleName(string roleName);
        Task<User> SingleByCondition(Expression<Func<User, bool>> expression);
        Task<User> Update(User entity);
    }
}