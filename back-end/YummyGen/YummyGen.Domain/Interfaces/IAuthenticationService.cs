using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> Login(LoginDto loginDto);
        Task<UserDto> Register(RegisterDto userDto);
    }
}