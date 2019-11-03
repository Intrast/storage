using Storage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storage.ViewModels;

namespace Storage.Controllers
{
    [Authorize(Roles="Admin")]
    public class EquipmentManageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult AddEquipmentsToProfile()
        {

            SelectList profiles = new SelectList(db.Profiles, "Id", "Name");
            MultiSelectList equipments = new MultiSelectList(db.Equipments.Where(x => x.ProfileId == null), "Id", "Name");
            SelectList categories = new SelectList(db.EquipmentCategories, "Id", "Categorie");
            ViewBag.Profiles = profiles;
            ViewBag.Equipments = equipments;
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult AddEquipmentsToProfile(Equipment ProfileAndEquipmentId)
        {

            foreach (var item in ProfileAndEquipmentId.EquipmentsIdArray)
            {
                Equipment equipment = db.Equipments.Find(item);
                equipment.ProfileId = ProfileAndEquipmentId.ProfileId;
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Profiles");
        }

        [HttpPost]
        public JsonResult RemoveFromProfile(RemoveEquipmentFromProfileViewModel model)
        {
            Equipment equipment = db.Equipments.Find(model.EquipmentId);
            equipment.ProfileId = null;
            db.Entry(equipment).State = EntityState.Modified;
            db.SaveChanges();
            return Json(model.EquipmentId);
        }
    }
}
