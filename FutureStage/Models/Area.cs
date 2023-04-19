﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("Area")]
    public class Area
    {
        [Key]
        public int ID { get; set; }
        public string AreaName { get; set; }

        //Relationships
        public List<School> Schools { get; set; }


        //City
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
    }
}
