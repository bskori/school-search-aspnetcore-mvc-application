using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolFacilityTbl")]
    public class SchoolFacility
    {
        [Key]
        public int ID { get; set; }
        public string FacilityDescription { get; set; }

        //School
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        //Facility
        [ForeignKey("Facility")]
        public int FacilityID { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
