﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dronesIL.Models
{
    public class DronesOrders
    {
        [Key]
        public int id { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
        public int droneId { get; set; }
        public Drone drone { get; set; }
    }
}