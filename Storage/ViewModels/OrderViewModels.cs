using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Storage.Models;

namespace StorageView.Models
{
    public class EditOrderViewModels
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class DeleteRequestOrderViewModels
    {
        public string UserId { get; set; }
        public string Notations { get; set; }
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}