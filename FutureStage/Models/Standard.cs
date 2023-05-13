using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StandardTbl")]
    public class Standard : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string StandardTitle { get; set; }
        public string StandardDescription { get; set; }

        //Relationships
        public virtual List<SchoolStandard> SchoolStandards { get; set; }
    }
}
