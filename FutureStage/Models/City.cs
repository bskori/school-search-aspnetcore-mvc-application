using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("CityTbl")]
    public class City : IEntityBase
    {
        [Key]
        
        public int ID { get; set; }

        [Display(Name ="City Name")]
        [Required(ErrorMessage ="Please enter city name.")]
        public string CityName { get; set; }

        //Rlationships
        public virtual List<Area> Areas { get; set; }

        //Area
        [ForeignKey("State")]
        [Required(ErrorMessage ="Please select a state.")]
        public int StateID { get; set; }
        public virtual State State { get; set; }
    }
}
