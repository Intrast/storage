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
        public string Name { get; set; }
        public string Key { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int CategorieId { get; set; }
        public EquipmentCategorie Categorie { get; set; }

        public int[] EquipmentsIdArray { get; set; }
    }
}