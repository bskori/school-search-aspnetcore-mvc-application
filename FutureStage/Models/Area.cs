﻿using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("AreaTbl")]
    public class Area : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Area Name")]
        [Required(ErrorMessage ="Please enter area name.")]
        public string AreaName { get; set; }

        //Relationships
        public virtual List<School> Schools { get; set; }

        //City
        [ForeignKey("City")]
        [Required(ErrorMessage = "Please select a city.")]
        public int CityID { get; set; }
        public virtual City City { get; set; }
    }
}
