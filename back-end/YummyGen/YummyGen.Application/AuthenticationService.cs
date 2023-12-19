using Microsoft.AspNetCore.Identity;
using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> userManager;

        public AuthenticationService(UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var existingUser = await userManager.FindByNameAsync(registerDto.UserName);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = Mapper.ToUser(registerDto);
            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed");
            }

            var addedUser = await userManager.FindByNameAsync(registerDto.UserName);

            var registerResult = Mapper.ToUserDto(addedUser);
            return registerResult;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var existingUser = await userManager.FindByNameAsync(loginDto.UserName);

            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            var result = await userManager.CheckPasswordAsync(existingUser, loginDto.Password);

            if (!result)
            {
                throw new Exception("Invalid password");
            }

            var loginResult = Mapper.ToUserDto(existingUser);

            return loginResult;
        }
    }
}
