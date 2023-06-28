using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Please enter a email address.")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please enter a password.")]
        public string Password { get; set; }
    }
}
