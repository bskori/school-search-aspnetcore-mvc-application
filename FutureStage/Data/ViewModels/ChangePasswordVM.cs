using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewModels
{
    public class ChangePasswordVM
    {
        public int ID { get; set; }

        [Display(Name ="Current Password")]
        [Required(ErrorMessage ="Please enter a current password.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage ="Please enter a password.")]
        [Display(Name = "New Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password and confirm password are not same!")]
        public string Password { get; set; }

        [Display(Name ="Confirm New Password")]
        [Required(ErrorMessage ="Please enter a confirm password.")]
        public string ConfirmPassword { get; set; }


        
    }
}
