using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("StateTbl")]
    public class State
    {
        [Key]
        public int ID { get; set; }
        public string StateName { get; set; }

        //Relationships
        public List<City> Cities { get; set; }

        //Country
        public int CountryID { get; set; }
        [ForeignKey("CountryID")]
        public Country Country { get; set; }

    }
}
