using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StandardFeesTbl")]
    public class StandardFees
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }

        //SchoolStandard
        [ForeignKey("SchoolStandard")]
        public int SchoolStandardID { get; set; }
        public virtual SchoolStandard SchoolStandard { get; set; }

        //FeeHead
        [ForeignKey("FeeHead")]
        public int FeeHeadID { get; set; }
        public virtual FeeHead FeeHead { get; set; }
    }
}
