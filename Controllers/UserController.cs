using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;



namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user, string verify)
        {
            // Make sure the username is not blank.
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                user.Username = string.Empty; 
                user.Password = string.Empty;  // blank out the password even if data was entered     
                ViewBag.Email = user.Email;  // keep the email address as entered
                ViewBag.Error = "Username is required.";
                return View(user);
            }
            // Make sure the email is not blank.
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                ViewBag.Username = user.Username; // keep the username as entered
                user.Password = string.Empty; // blank out the password even if data was entered
                user.Email = string.Empty;
                ViewBag.Error = "Email address is required.";
                return View(user);
            }
            // Make sure the email is in proper format // IsValidEmail(email@address.com) WORKS! 
            if (IsValidEmail(user.Email) == false)
            {
                ViewBag.Username = user.Username; // keep the username as entered
                user.Password = string.Empty; // blank out the password even if data was entered
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
        }
       
    }
}