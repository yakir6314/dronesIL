using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class user
    {
        [Key]
        public int userId { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z\u0590-\u05FF\u200f\u200e ]+$", ErrorMessage = "Invalid Name,try to insert letters in hebrew or english ")]
        public string firstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\u0590-\u05FF\u200f\u200e ]+$", ErrorMessage = "Invalid Name,try to insert letters in hebrew or english ")]
        public string lastName { get; set; }
        [Required]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        public string mail { get; set; }
        //[RegularExpression(@"^d$", ErrorMessage = "invalid phone number")]
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public bool? isAdmin { get; set; }
        public ICollection<Order> orders { get; set; }
       
    }
}
