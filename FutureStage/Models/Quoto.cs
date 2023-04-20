using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("QuotoTbl")]
    public class Quoto
    {
        [Key]
        public int ID { get; set; }
        public string QuotoTitle { get; set; }
        public string QuotoDescription { get; set; }

        //Relationships
        public virtual List<StandardSeatQuoto> StandardSeatQuotos { get; set; }
    }
}
