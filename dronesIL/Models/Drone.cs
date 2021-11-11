using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class Drone
    {
        [Key]
        public int droneId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime createDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public ICollection<DronesOrders> dronesOrders { get; set; }

    }
}
