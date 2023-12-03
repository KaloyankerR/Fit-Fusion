using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;
using System.ComponentModel.DataAnnotations;

namespace FitFusionWeb.Pages.Users
{
    [Authorize(Roles = "Owner, Staff")]
    public class CreateModel : PageModel
    {
        public class UserCreateModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "First Name is required.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string PasswordHash { get; set; }

            [Required(ErrorMessage = "Address is required.")]
            public string Address { get; set; }
        }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public UserCreateModel UserForm { get; set; } = new();
            
        public void OnGet()
        {
            
        }

        public void OnPost() 
        {
            //if (ModelState.IsValid)
            //{ }                
            //else
            //{
            //    var a = 1;
            //}
        }

    }
}
