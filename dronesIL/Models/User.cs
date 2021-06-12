using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
    }
}
