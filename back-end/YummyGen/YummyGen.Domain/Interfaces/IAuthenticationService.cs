using YummyGen.Domain.Dto;

namespace YummyGen.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<UserDto> Register(RegisterDto userDto);
    }
}