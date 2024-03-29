﻿using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AdmissionPrerequisiteTbl")]
    public class AdmissionPrerequisite : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        
        public string PrerequisiteTitle { get; set; }

        
        public string PrerequisiteDescription { get; set; }

        //SchoolStandard
        [ForeignKey("SchoolStandard")]
        public int SchoolStandardID { get; set; }
        public virtual SchoolStandard SchoolStandard { get; set; }
    }
}
