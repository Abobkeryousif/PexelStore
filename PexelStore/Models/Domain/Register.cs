﻿namespace PexelStore.Models.Domain
{
    public class Register
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }

        public string[] Roles{ get; set; }  
    }
}
