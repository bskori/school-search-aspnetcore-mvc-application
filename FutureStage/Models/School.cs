using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolTbl")]
    public class School
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public DateTime EstablishmentDate { get; set; }

        //Relationships
        public virtual List<SchoolFacility> SchoolFacilities { get; set; }
        public virtual List<SchoolAchivement> SchoolAchivements { get; set; }
        public virtual List<School> Schools { get; set; }
        public virtual List<Enquiry> Enquiries { get; set; }
        public virtual List<SchoolStandard> SchoolStandards { get; set; }

        //Area
        [ForeignKey("Area")]
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }

    }
}
