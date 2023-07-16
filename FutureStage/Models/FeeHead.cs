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
        [Display(Name ="FeeHead Name")]
        [Required(ErrorMessage ="Please enter a feehead name.")]
        public string FeeHeadName { get; set; }

        //SchoolStandard
        [ForeignKey("SchoolStandard")]
        [Required(ErrorMessage ="Please select a class.")]
        public int SchoolStandardID { get; set; }
        public virtual SchoolStandard  SchoolStandard { get; set; }

        //Relationships
        public virtual List<StandardFees> StandardFees { get; set; }
        
        
    }
}
