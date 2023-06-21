using FutureStage.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureStage.Models
{
    [Table("StandardTbl")]
    public class Standard : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Standard")]
        [Required(ErrorMessage ="Please enter standard name.")]
        public string StandardName { get; set; }

        //Relationships
        public virtual List<SchoolStandard> SchoolStandards { get; set; }
    }
}
