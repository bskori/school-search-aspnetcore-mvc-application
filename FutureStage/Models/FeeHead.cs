using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("FeeHeadTbl")]
    public class FeeHead:IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string FeeHeadTitle { get; set; }
        public string FeeHeadDescription { get; set; }

        //Relationships
        public virtual List<StandardFees> StandardFees { get; set; }
    }
}
