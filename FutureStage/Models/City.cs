using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Models
{
    [Table("CityTbl")]
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string CityName { get; set; }

        //Rlationships
        public List<Area> Areas { get; set; }

        //Area
        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public State State { get; set; }
    }
}
