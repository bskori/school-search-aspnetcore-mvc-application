using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AdmissionProcessTbl")]
    public class AdmissionProcess
    {
        [Key]
        public int ID { get; set; }
        public string ProcessTitle { get; set; }
        public string ProcessDescription { get; set; }

        //SchoolStandard
        public int SchoolStandardID { get; set; }
        [ForeignKey("SchoolStandardID")]
        public List<SchoolStandard> SchoolStandards { get; set; }
    }
}
