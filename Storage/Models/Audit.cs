using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public string ProfileId { get; set; }
        public string EquipmentId { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
}