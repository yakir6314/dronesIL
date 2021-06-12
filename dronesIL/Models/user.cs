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
        public string firstName { get; set; }
        public string lastName { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string mail { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public List<Order> orders { get; set; }
    }
}
