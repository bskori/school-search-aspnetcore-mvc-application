using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StandardSeatQuotoTbl")]
    public class StandardSeatQuoto
    {
        [Key]
        public int ID { get; set; }
        public int NumberOfSeats { get; set; }

        //SchoolStandard
        [ForeignKey("SchoolStandard")]
        public int SchoolStandardID { get; set; }
        public virtual SchoolStandard SchoolStandard { get; set; }

        //Quoto
        [ForeignKey("Quoto")]
        public int QuotoID { get; set; }
        public virtual Quoto Quoto { get; set; }
    }
}
