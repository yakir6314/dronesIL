using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public DateTime orderDateTime { get; set; }
        public user user { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int streetNum { get; set; }
        public decimal Sum { get; set; }
        public int orderStatus { get; set; }
        public List<Drone> drones { get; set; }
    }
}
