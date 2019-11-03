using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}