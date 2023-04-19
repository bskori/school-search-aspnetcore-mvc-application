using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("GeneralEnquiryReplyTbl")]
    public class GeneralEnquiryReply
    {
        [Key]
        public int ID { get; set; }
        public DateTime ReplyDate { get; set; }
        public DateTime ReplyDescription { get; set; }

        //Enquiry
        public int EnquiryID { get; set; }
        [ForeignKey("EnquiryID")]
        public Enquiry Enquiry { get; set; }
    }
}
