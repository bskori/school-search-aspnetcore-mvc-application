using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewModels
{
    public class AdmissionVM
    {
        public int SchoolStandardID { get; set; }
        public string PrequisiteTitle { get; set; }
        public string PrerequisiteDescription { get; set; }
        public string ProcessTitle { get; set; }
        public string ProcessDescription { get; set; }
    }
}
