using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;


namespace UserSignup.ViewModels
{
    public class AddUserViewModel 
    {
        // future project: save the username and/or email address if the other fields don't validate
        [TempData] // from https://www.learnrazorpages.com/razor-pages/tempdata but requires more work, TBD
        [Required, MinLength(5), MaxLength(15), RegularExpression(@"^[a-zA-Z]+$")]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage="Password must be at least six characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Verify Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string VerifyPassword { get; set; }

    }
}

