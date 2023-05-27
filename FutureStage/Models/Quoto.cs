using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("QuotoTbl")]
    public class Quoto : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Quota Title")]
        [Required(ErrorMessage ="Quota Title is required")]
        public string QuotoTitle { get; set; }

        [Display(Name ="Quota Description")]
        [Required(ErrorMessage ="Quota Description is required")]
        public string QuotoDescription { get; set; }

        //Relationships
        public virtual List<StandardSeatQuoto> StandardSeatQuotos { get; set; }
    }
}
