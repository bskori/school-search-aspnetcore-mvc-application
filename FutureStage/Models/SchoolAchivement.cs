using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolAchivementTbl")]
    public class SchoolAchivement
    {
        [Key]
        public int ID { get; set; }
        public string AchivementTitle { get; set; }
        public string AchivementDescription { get; set; }
        public DateTime AchivementDate { get; set; }

        //School
        public int SchoolID { get; set; }
        [ForeignKey("SchoolID")]
        public School School { get; set; }

    }
}
