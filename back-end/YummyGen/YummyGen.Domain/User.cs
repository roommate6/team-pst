﻿using Microsoft.AspNetCore.Identity;

namespace YummyGen.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
