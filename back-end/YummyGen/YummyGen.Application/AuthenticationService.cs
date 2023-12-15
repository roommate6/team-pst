using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto> Register(RegisterDto userDto)
        {
            var existingUser = await userRepository.SingleByCondition(u => u.UserName == userDto.UserName);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = Mapper.ToUser(userDto);
            var addedUser = await userRepository.Add(user);

            var registerResult = Mapper.ToUserDto(addedUser);
            return registerResult;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await userRepository.SingleByCondition(u => u.UserName == loginDto.UserName);

            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            var loginResult = Mapper.ToUserDto(user);

            return loginResult;
        }
    }
}
