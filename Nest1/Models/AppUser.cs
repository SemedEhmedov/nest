﻿using Microsoft.AspNetCore.Identity;

namespace Nest1.Models
{
    public class AppUser:IdentityUser
    {
        public string UserName { get; set; }
    }
}
