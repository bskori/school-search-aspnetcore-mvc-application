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

        [Required(ErrorMessage = "Please enter a school name.")]
        [Display(Name = "School Name")]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "School Image")]
        [Required(ErrorMessage = "Please choose a school image.")]
        [NotMapped]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage ="Please enter a school address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a address.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please enter a valid email address.")]
        [Display(Name ="Email Address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage ="Please enter a contact number.")]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Please enter a 10-digit valid contact number.")]
        [Display(Name ="Contact No.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter a establishment date.")]
        [Display(Name="Establishment Date")]
        public DateTime EstablishmentDate { get; set; }

        [Required(ErrorMessage ="Please enter a password.")]
        [Compare("ConfirmPassword",ErrorMessage ="Password and confirm password are not same!")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter a confirm password.")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="Please select boards from the list.")]
        public List<int> EducationBoardID { get; set; }

        //Relationships
        public virtual List<SchoolFacility> SchoolFacilities { get; set; }
        public virtual List<SchoolAchivement> SchoolAchivements { get; set; }
        public virtual List<Enquiry> Enquiries { get; set; }
        public virtual List<SchoolStandard> SchoolStandards { get; set; }
        public virtual ICollection<School_EducationBoard> School_EducationBoards { get; set; }

        //Area
        [ForeignKey("Area")]
        [Required(ErrorMessage ="Please select a area.")]
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
    }
}
