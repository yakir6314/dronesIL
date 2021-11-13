using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class Drone
    {
        [DisplayName("מספר קטלוגי")]
        [Key]
        
        public int droneId { get; set; }
        [DisplayName("שם דגם רחפן")]
        public string name { get; set; }
        [DisplayName("מחיר")]
        public decimal price { get; set; }
        [DisplayName("תאריך יצירה")]
        public DateTime createDate { get; set; }
        [DisplayName("תאריך עדכון")]
        public DateTime LastUpdateDate { get; set; }
        [DisplayName("תיאור רחפן")]
        public string description { get; set; }
        [DisplayName("תמונה")]
        public string imageUrl { get; set; }
        public bool isEnterprise { get; set; }
        public ICollection<DronesOrders> dronesOrders { get; set; }

    }
}
