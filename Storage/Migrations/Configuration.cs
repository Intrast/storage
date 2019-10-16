namespace Storage.Migrations
{
    using Storage.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StorageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.ProfileGroups.AddOrUpdate(x => x.Id,
                new ProfileGroup { Id = 1, Group = "Web Development" },
                new ProfileGroup { Id = 2, Group = "Mobile Development" }
                );

            context.EquipmentCategories.AddOrUpdate(x => x.Id,
                new EquipmentCategorie { Id = 1, Categorie = "Системний блок" },
                new EquipmentCategorie { Id = 2, Categorie = "Монітор" },
                new EquipmentCategorie { Id = 3, Categorie = "Клавіатура" },
                new EquipmentCategorie { Id = 4, Categorie = "Мишка" },
                new EquipmentCategorie { Id = 5, Categorie = "Навушники" }
                );

            context.AuditStatuses.AddOrUpdate(x => x.Id,
                new AuditStatus { Id = 1, Status = "На складі"},
                new AuditStatus { Id = 2, Status = "Використовується"}
                );

            base.Seed(context);
        }
    }
}
