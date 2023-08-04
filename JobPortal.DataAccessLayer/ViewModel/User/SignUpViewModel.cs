using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.ViewModel.User
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email required"),EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password required")]
        [MinLength(2,ErrorMessage ="Password minimum length should be 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="both password should be same")]
        public string ConfirmPassword { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
