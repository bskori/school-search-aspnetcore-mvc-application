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
        public List<StandardSeatQuoto> StandardSeatQuotos { get; set; }
        public List<StandardFees> StandardFees { get; set; }
        public List<FeeHead> FeeHeads { get; set; }
        public List<AdmissionPrerequisite> AdmissionPrerequisites { get; set; }
        public List<AdmissionProcess> AdmissionProcesses { get; set; }
        public List<AdmissionEnquiry> AdmissionEnquiries { get; set; }

        //Standard
        public int StandardID { get; set; }
        [ForeignKey("StandardID")]
        public Standard Standard { get; set; }

        //School
        public int SchoolID { get; set; }
        [ForeignKey("SchoolID")]
        public School School { get; set; }
    }
}
