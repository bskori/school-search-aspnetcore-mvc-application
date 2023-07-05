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

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name="Email Address")]
        public string EmailID { get; set; }

        [Required]
        [Display(Name ="Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        public string Password { get; set; }

        //Relationships
        public virtual List<AdmissionEnquiry> AdmissionEnquiries { get; set; }

    }
}
