using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data.ViewModels
{
    public class AdmissionVM
    {
        public int PrerequisiteAndProcessID { get; set; }

        [Required(ErrorMessage = "Please select a school class.")]
        public int SchoolStandardID { get; set; }

        [Required(ErrorMessage = "Please enter the admission process title.")]
        [Display(Name = "Admission Prerequisite Title")]
        public string PrequisiteTitle { get; set; }

        [Required(ErrorMessage = "Please enter the admission process title.")]
        [Display(Name = "Admission Prerequisite Description")]
        public string PrerequisiteDescription { get; set; }

        [Required(ErrorMessage = "Please enter the admission process title.")]
        [Display(Name = "Admission Process Title")]
        public string ProcessTitle { get; set; }

        [Required(ErrorMessage = "Please enter the admission process description.")]
        [Display(Name = "Admission Process Description")]
        public string ProcessDescription { get; set; }
    }
}
