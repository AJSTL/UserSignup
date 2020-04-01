using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class UserData
    {
        private static List<User> users = new List<User>();

        public static List<User> GetAll()
        {
            return users;
        }

        public static void Add(User newUser)
        {
            users.Add(newUser);
        }

        public static void Remove(int id)
        {
            User userToRemove = GetById(id);
            users.Remove(userToRemove);
        }

        public static User GetById(int id)
        {
            return users.Single(x => x.UserId == id);
        }
    }
}
