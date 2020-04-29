using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        private static int nextId = 1;

        public static string DisplayName { get; set; }

        public User()
        {
            UserId = nextId;
            nextId++;          
        }
    }
}
