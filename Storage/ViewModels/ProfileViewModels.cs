using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storage.Models;

namespace Storage.ViewModels
{
    public class DetailsProfileViewModels
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
        public ProfileGroup Group { get; set; }

    }


    public class EditProfileViewModels
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
        public ProfileGroup Group { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}