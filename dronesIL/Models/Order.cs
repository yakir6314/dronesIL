using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class Order
    {
        [DisplayName("מספר הזמנה")]
        [Key]
        public int orderId { get; set; }
        [DisplayName("תאריך הזמנה ")]
        public DateTime orderDateTime { get; set; }
        [DisplayName("משתמש ")]
        public user user { get; set; }
        [DisplayName("עיר משלוח ")]
        public string city { get; set; }
        [DisplayName("כתובת משלוח")]
        public string street { get; set; }
        [DisplayName("מספר רחוב ")]
        public int streetNum { get; set; }
        [DisplayName("סה״כ לתשלום")]
        public decimal Sum { get; set; }
        [DisplayName("סטטוס הזמנה ")]
        public int orderStatus { get; set; }
        public ICollection<DronesOrders> dronesOrders { get; set; }
    }
}
