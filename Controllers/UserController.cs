using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = UserData.GetAll();
            return View(users);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        //public IActionResult Add(User user, string verify)
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = addUserViewModel.UserName,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };

                UserData.Add(user);
                return Redirect("/User");
            }

            return View(addUserViewModel);
        }

        public IActionResult DisplayUser(int id)
        {
            DisplayUserViewModel displayUserViewModel = new DisplayUserViewModel(id);

            return View(displayUserViewModel);
        }

        /* Make sure the username is not blank.
        if (string.IsNullOrWhiteSpace(user.Username))
        {
            user.Username = string.Empty;
            ViewBag.Password = user.Password; // keep the password as entered
            ViewBag.Email = user.Email;  // keep the email address as entered
            ViewBag.Error = "Username is required.";
            return View(user);
        }
        // Make sure the username is between 5-15 characters
        if (user.Username.Length <= 5 || user.Username.Length >= 15)
        {
            user.Username = string.Empty;
            ViewBag.Password = user.Password; // keep the password as entered
            ViewBag.Email = user.Email;  // keep the email address as entered
            ViewBag.Error = "Username must be between 5 and 15 letter characters.";
            return View(user);
        }
        // Make sure the username only contains letters 
        if (user.Username.Any(char.IsDigit) || user.Username.Any(char.IsPunctuation))
        {
            user.Username = string.Empty;
            ViewBag.Password = user.Password;// keep the password as entered
            ViewBag.Email = user.Email;  // keep the email address as entered
            ViewBag.Error = "Username may not contain numbers or special characters.";
            return View(user);
        }
        // Make sure the email is not blank.
        if (string.IsNullOrWhiteSpace(user.Email))
        {
            ViewBag.Username = user.Username; // keep the username as entered
            ViewBag.Password = user.Password;
            user.Email = string.Empty;
            ViewBag.Error = "Email address is required.";
            return View(user);
        }
        // Make sure the email is in proper format // IsValidEmail(email@address.com) WORKS! 
        if (IsValidEmail(user.Email) == false)
        {
            ViewBag.Username = user.Username; // keep the username as entered
            ViewBag.Password = user.Password; // keep the password as entered
            user.Email = string.Empty;
            ViewBag.Error = "Please enter a valid email address.";
            return View(user);
        }
        // Make sure the password is not blank.
        if (string.IsNullOrWhiteSpace(user.Password))
        {
            user.Password = string.Empty;
            ViewBag.Username = user.Username; // keep the username as entered
            ViewBag.Email = user.Email;  // keep the email address as entered
            ViewBag.Error = "Password is required.";
            return View(user);
        }
        // Make sure the passwords match.
        if (user.Password != verify) 
        {
            user.Password = string.Empty;
            ViewBag.Username = user.Username;
            ViewBag.Email = user.Email;
            ViewBag.Error = "Passwords do not match.";
            return View(user);
        }


        // can't get this to work... 
        TempData["Welcome"] = user.Username;



        // Send to the index view.
        return Redirect("/User");
    }


        public static bool IsValidEmail(string email) // email validation 
        {
            return Regex.Match(email, "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]+$", RegexOptions.IgnoreCase).Success;
        }*/

    }
}