﻿using PassportWebApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.Auth
{
    public class LoggedInUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public string UserName { get; set; }
        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; } 

        public string Role { get; set; }
    }
}
