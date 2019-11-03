namespace Storage.Migrations
{
    using Storage.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Storage.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Storage.Models.ApplicationDbContext context)
        {

            context.ProfileGroups.AddOrUpdate(x => x.Id,
                new ProfileGroup() { Id = 1, Group = "Web Development" },
                new ProfileGroup() { Id = 2, Group = "Mobile Development" }
            );

            context.EquipmentCategories.AddOrUpdate(x => x.Id,
                new EquipmentCategorie() { Id = 1, Categorie = "��������� ����"},    
                new EquipmentCategorie() { Id = 2, Categorie = "������"},    
                new EquipmentCategorie() { Id = 3, Categorie = "�����"},    
                new EquipmentCategorie() { Id = 4, Categorie = "���������"},    
                new EquipmentCategorie() { Id = 5, Categorie = "���������"}    
            );

            context.OrderStatuses.AddOrUpdate(x => x.Id,
                new OrderStatus() { Id = 1, Status = "����� �����"},
                new OrderStatus() { Id = 2, Status = "� �������"},
                new OrderStatus() { Id = 3, Status = "� �����"},
                new OrderStatus() { Id = 4, Status = "�� �����"},
                new OrderStatus() { Id = 5, Status = "³�������"},
                new OrderStatus() { Id = 6, Status = "��������"}
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
