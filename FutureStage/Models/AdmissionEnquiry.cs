using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AdmissionEnquiryTbl")]
    public class AdmissionEnquiry : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name ="Date")]
        public DateTime EnquiryDate { get; set; }

        [Required]
        [Display(Name ="Enquiry")]
        public string EnquiryDescription { get; set; }

        //Relationships
        public virtual List<AdmissionConfirmation> AdmissionConfirmations { get; set; }

        //Parent
        [ForeignKey("Parent")]
        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }

        //School
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        //SchoolStandard
        [ForeignKey("SchoolStandard")]
        public int SchoolStandardID { get; set; }
        public virtual SchoolStandard SchoolStandard { get; set; }
    }
}
