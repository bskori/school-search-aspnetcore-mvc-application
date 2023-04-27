using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("CountyTbl")]
    public class Country : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Country Name")]
        [Required(ErrorMessage = "Country name required")]
        public string CountryName { get; set; }

        //Relationships
        public virtual List<State> States { get; set; }
    }
}
