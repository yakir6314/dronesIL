using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class user
    {
        [DisplayName("מספר משתמש")]
        [Key]
        public int userId { get; set; }
        [DisplayName("שם פרטי")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\u0590-\u05FF\u200f\u200e ]+$", ErrorMessage = "Invalid Name,try to insert letters in hebrew or english ")]
        public string firstName { get; set; }
        [DisplayName("שם משפחה")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\u0590-\u05FF\u200f\u200e ]+$", ErrorMessage = "Invalid Name,try to insert letters in hebrew or english ")]
        public string lastName { get; set; }
        [DisplayName("כתובת מייל ")]
        [Required]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        public string mail { get; set; }
        [RegularExpression(@"^\+?(972|0)(\-)?0?(([23489]{1}\d{7})|[5]{1}\d{8})$", ErrorMessage = "invalid phone number")]
        [DisplayName("מספר טלפון")]
        [Required]
        public string phoneNumber { get; set; }
        [DisplayName("סיסמה")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DisplayName("תאריך יצירה ")]
        public DateTime createDate { get; set; }
        [DisplayName("תאריך עדכון")]
        public DateTime lastUpdateDate { get; set; }
        [DisplayName("הרשאות מנהל ")]
        public bool? isAdmin { get; set; }
        public ICollection<Order> orders { get; set; }
       
    }
}
