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

        [Display(Name ="Education Board Name")]
        [Required(ErrorMessage ="Please enter the education board name.")]
        public string EducationBoardName { get; set; }

        public virtual ICollection<School_EducationBoard> School_EducationBoards { get; set; }

    }
}
