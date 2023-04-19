using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AdmissionEnquiryTbl")]
    public class AdmissionEnquiry
    {
        [Key]
        public int ID { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string EnquiryDescription { get; set; }

        //Relationships
        public List<AdmissionConfirmation> AdmissionConfirmations { get; set; }

        //Parent
        public int ParentID { get; set; }
        [ForeignKey("ParentID")]
        public Parent Parent { get; set; }

        //School
        public int SchoolID { get; set; }
        [ForeignKey("SchoolID")]
        public School School { get; set; }

        //SchoolStandard
        public int SchoolStandardID { get; set; }
        [ForeignKey("SchoolStandardID")]
        public SchoolStandard SchoolStandard { get; set; }
    }
}
