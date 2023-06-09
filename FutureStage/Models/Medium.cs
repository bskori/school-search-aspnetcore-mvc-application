﻿using FutureStage.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("MediumTbl")]
    public class Medium : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
