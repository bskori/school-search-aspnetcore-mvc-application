using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("SchoolStandardTbl")]
    public class SchoolStandard
    {
        [Key]
        public int ID { get; set; }
        public int IntakeCapacity { get; set; }

        //Relationships
        public virtual List<StandardSeatQuoto> StandardSeatQuotos { get; set; }
        public virtual List<StandardFees> StandardFees { get; set; }
        public virtual List<FeeHead> FeeHeads { get; set; }
        public virtual List<AdmissionPrerequisite> AdmissionPrerequisites { get; set; }
        public virtual List<AdmissionProcess> AdmissionProcesses { get; set; }
        public virtual List<AdmissionEnquiry> AdmissionEnquiries { get; set; }

        //Standard
        [ForeignKey("Standard")]
        public int StandardID { get; set; }
        public virtual Standard Standard { get; set; }

        //School
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }
    }
}
