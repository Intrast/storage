using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName {get; set;}
        public string Price { get; set; }
        public string Url { get; set; }
        public string Notation { get; set; }
        public string UserId { get; set; }

        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }

        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

    }
}