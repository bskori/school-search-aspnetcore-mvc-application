using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("EnquiryTbl")]
    public class Enquiry
    {
        [Key]
        public int ID { get; set; }
        public string EnquiryDescription { get; set; }
        public DateTime EnquiryDate { get; set; }

        //Relationships
        public virtual List<GeneralEnquiryReply> GeneralEnquiryReplies { get; set; }

        //Parent
        [ForeignKey("Parent")]
        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }

        //School
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }
    }
}
