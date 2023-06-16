using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    public class School_EducationBoard
    { 
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        public int EducationBoardID { get; set; }
        public virtual  EducationBoard  EducationBoard { get; set; }
    }
}
