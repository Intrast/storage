using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class ProfileGroup
    {
        public int Id { get; set; }
        public string Group { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}