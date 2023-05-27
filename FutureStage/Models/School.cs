using FutureStage.Data.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolTbl")]
    public class School : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "School name is required")]
        [Display(Name = "School Name")]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Choose Image")]
        [Required(ErrorMessage = "School Image is required")]
        [NotMapped]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please enter a valid Email address")]
        [Display(Name ="Email Address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage ="Contact no is required")]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Please enter a 10-digit valid Contact Number")]
        [Display(Name ="Contact No.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Establishment date is equired")]
        [Display(Name="Establishment Date")]
        public DateTime EstablishmentDate { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [Compare("ConfirmPassword",ErrorMessage ="Password and confirm password are not same!")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password is required")]
        public string ConfirmPassword { get; set; }

        //Relationships
        public virtual List<SchoolFacility> SchoolFacilities { get; set; }
        public virtual List<SchoolAchivement> SchoolAchivements { get; set; }
        public virtual List<School> Schools { get; set; }
        public virtual List<Enquiry> Enquiries { get; set; }
        public virtual List<SchoolStandard> SchoolStandards { get; set; }
        
        //Area
        [ForeignKey("Area")]
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
    }
}
