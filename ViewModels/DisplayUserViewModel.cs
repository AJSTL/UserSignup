using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;

namespace UserSignup.ViewModels
{
    public class DisplayUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public DisplayUserViewModel() { }

        public DisplayUserViewModel(int id)
        {
            User user = UserData.GetById(id);
            UserName = user.UserName;
            Email = user.Email;
        }
    }

}