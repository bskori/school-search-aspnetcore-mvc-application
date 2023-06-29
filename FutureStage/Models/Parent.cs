using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("ParentTbl")]
    public class Parent
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter a address.")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Please enter a email address.")]
        [Display(Name="Email Address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage ="Please enter a mobile number.")]
        [Display(Name ="Mobile Number")]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Please enter a 10 digit valid mobile number.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage ="Please enter a password.")]
        public string Password { get; set; }

        //Relationships
        public virtual List<AdmissionEnquiry> AdmissionEnquiries { get; set; }

    }
}
