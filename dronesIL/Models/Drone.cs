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
        public int id { get; set; }
        [Display(Name = "שם רחפן")]
        public string name { get; set; }
        [Display(Name = "מחיר")]
        public decimal price { get; set; }
        [Display(Name = "תאריך הוספת רחפן")]
        public DateTime createDate { get; set; }
        [Display(Name = "תאריך עדכון")]
        public DateTime LastUpdateDate { get; set; }
        [Display(Name = "תיאור רחפן")]
        public string description { get; set; }
        [Display(Name = "קישור לתמונת רחפן")]
        public string imageUrl { get; set; }
        [Display(Name = "ייצרן")]
        public string Manufacturer { get; set; }

    }
}
