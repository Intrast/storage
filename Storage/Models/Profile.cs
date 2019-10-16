using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tehnology { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStartWork { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateEndWork { get; set; }

        public int GroupId { get; set; }
        public ProfileGroup ProfileGroup { get; set; }

        public ICollection<Equipment> Equipments { get; set; }


    }
}