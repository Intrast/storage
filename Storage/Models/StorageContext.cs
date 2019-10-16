using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class StorageContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileGroup> ProfileGroups { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategorie> EquipmentCategories { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditStatus> AuditStatuses { get; set; }
    }
}