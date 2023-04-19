using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("CountyTbl")]
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }

        //Relationships
        public List<State> States { get; set; }
    }
}
