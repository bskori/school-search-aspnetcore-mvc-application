using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("ParentTbl")]
    public class Parent
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }

        //Relationships
        public List<AdmissionEnquiry> AdmissionEnquiries { get; set; }
        public List<Parent> Parents { get; set; }

    }
}
