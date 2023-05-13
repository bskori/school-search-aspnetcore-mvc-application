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

        [Display(Name ="Standard")]
        [Required(ErrorMessage ="Standard is required")]
        public string StandardTitle { get; set; }

        [Display(Name ="Description")]
        [Required(ErrorMessage ="Description is required")]
        public string StandardDescription { get; set; }

        //Relationships
        public virtual List<SchoolStandard> SchoolStandards { get; set; }
    }
}
