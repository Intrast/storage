using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Categories { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        public string Notes { get; set; }

    }
}