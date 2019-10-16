using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class EquipmentCategorie
    {
        public int Id { get; set; }
        public string Categorie { get; set; }
        
        public ICollection<Equipment> Equipments { get; set; }
    }
}