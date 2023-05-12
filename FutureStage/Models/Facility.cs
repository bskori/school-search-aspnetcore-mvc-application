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
        public string FacilityTitle { get; set; }
        public string FacilityDescription { get; set; }

        //Relationships
        public virtual List<SchoolFacility> SchoolFacilities { get; set; }
    }
}
