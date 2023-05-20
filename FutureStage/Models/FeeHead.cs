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
        [Display(Name ="Fee Head Title")]
        [Required(ErrorMessage =" Fee Head Title is required")]
        public string FeeHeadTitle { get; set; }

        [Display(Name ="Fee Head Description")]
        [Required(ErrorMessage = "Fee Head Description is required")]
        public string FeeHeadDescription { get; set; }

        //Relationships
        public virtual List<StandardFees> StandardFees { get; set; }
    }
}
