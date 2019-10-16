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
        public int EquipmentId { get; set; }
        public int NewProfileId { get; set; }
        public int OldProfileId { get; set; }
        public AuditStatus NewStatus { get; set; }
        public AuditStatus OldStatus { get; set; }
        public DateTime Time { get; set; }
    }
}