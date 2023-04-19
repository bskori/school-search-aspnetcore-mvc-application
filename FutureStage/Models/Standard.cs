using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StandardTbl")]
    public class Standard
    {
        [Key]
        public int ID { get; set; }
        public string StandardTitle { get; set; }
        public string StandardDescription { get; set; }

        //Relationships
        public List<SchoolStandard> SchoolStandards { get; set; }
    }
}
