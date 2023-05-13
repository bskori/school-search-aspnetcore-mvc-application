using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("EducationBoardTbl")]
    public class EducationBoard : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string EducationBoardTitle { get; set; }
        public string EducationBoardDescription { get; set; }
    }
}
