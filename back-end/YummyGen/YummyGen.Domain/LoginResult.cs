using YummyGen.Domain.Dto;

namespace YummyGen.Domain
{
    public class LoginResult
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
