using YummyGen.Domain;

namespace YummyGen.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User user);
    }
}