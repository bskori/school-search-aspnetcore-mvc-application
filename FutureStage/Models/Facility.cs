using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("FacilityTbl")]
    public class Facility : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter facility name.")]
        [Display(Name ="Facility Name")]
        public string FacilityName { get; set; }


        [Required(ErrorMessage ="Please provide icon.")]
        [Display(Name ="Facility Icon")]
        public string FacilityIcon { get; set; }

        //Relationships
        public virtual List<SchoolFacility> SchoolFacilities { get; set; }
    }
}
