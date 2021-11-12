using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class DronesOrders
    {
        
        [DisplayName("מספר הזמנה")]
        [Key]
        public int orderId { get; set; }
        [DisplayName("הזמנה")]
        public Order order { get; set; }
        [DisplayName("מספר דגם")]
        [Key]
        public int droneId { get; set; }
        [DisplayName("רחפן")]
        public Drone drone { get; set; }
        [DisplayName("כמות רחפנים")]
        public int quantity { get; set; }
    }
}
