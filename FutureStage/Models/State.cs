using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StateTbl")]
    public class State : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="State Name")]
        [Required(ErrorMessage ="Please enter state name.")]
        public string StateName { get; set; }

        //Relationships
        public virtual List<City> Cities { get; set; }


    }
}
