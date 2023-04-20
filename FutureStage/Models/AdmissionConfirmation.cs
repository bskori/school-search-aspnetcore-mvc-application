﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AdmissionConfirmationTbl")]
    public class AdmissionConfirmation
    {
        [Key]
        public int ID { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public bool Remark { get; set; }

        //AdmissionEnquiry
        [ForeignKey("AdmissionEnquiry")]
        public int AdmissionEnquiryID { get; set; }
        public virtual AdmissionEnquiry AdmissionEnquiry { get; set; }
    }
}
