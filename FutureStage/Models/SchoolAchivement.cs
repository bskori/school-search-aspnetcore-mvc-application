using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolAchivementTbl")]
    public class SchoolAchivement : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter the achivement title.")]
        [Display(Name = "Achivement Title")]
        public string AchivementTitle { get; set; }

        [Required(ErrorMessage = "Please enter the achivement description.")]
        [Display(Name = "Achivement Description")]
        public string AchivementDescription { get; set; }

        [Required(ErrorMessage = "Please enter the achivement date.")]
        [Display(Name = "Achivement Date")]
        public DateTime AchivementDate { get; set; }

        //School
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

    }
}
