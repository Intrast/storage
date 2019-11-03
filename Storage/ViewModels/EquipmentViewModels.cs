using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Storage.Models;

namespace Storage.ViewModels
{
    public class CreateEquipmentViewModels
    {
        public string Name { get; set; }
        public string Key { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public int CategorieId { get; set; }
        public EquipmentCategorie Categorie { get; set; }

        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

    }

    public class EditEquipmentViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public int CategorieId { get; set; }
        public EquipmentCategorie Categorie { get; set; }


        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }
    }

    public class RemoveEquipmentFromProfileViewModel
    {
        public string UserId { get; set; }
        public string Notations { get; set; }
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}