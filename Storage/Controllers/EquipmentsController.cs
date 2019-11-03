using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using PagedList.Mvc;
using Storage.Models;
using Storage.ViewModels;

namespace Storage.Controllers
{
    [Authorize]
    public class EquipmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Equipments
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var equipments = db.Equipments.Include(e => e.Profile).Include(e => e.Categorie).Where(x => x.Deleted == false).OrderByDescending(x => x.Name);

            return View(equipments.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeletedEquipments(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var deletedEquipments = db.Equipments.Include(e => e.Profile).Include(e => e.Categorie).Where(x => x.Deleted == true).OrderByDescending(x => x.Name);
            return View(deletedEquipments.ToPagedList(pageNumber, pageSize));
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Include(e => e.Profile).Include(p => p.Categorie).FirstOrDefault(p => p.Id == id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }
        [Authorize(Roles = "Admin")]
        // GET: Equipments/Create
        public ActionResult Create()
        {
            CreateEquipmentViewModels model = new CreateEquipmentViewModels();
            SelectList profiles = new SelectList(db.Profiles, "Id", "Name");
            SelectList categories = new SelectList(db.EquipmentCategories, "Id", "Categorie");
            ViewBag.Profiles = profiles;
            ViewBag.Categories = categories;
            return View(model);
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEquipmentViewModels model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CreateEquipmentViewModels, Equipment>();
                });
                model.Deleted = false;
                IMapper mapper = config.CreateMapper();
                Equipment equipment = new Equipment();
                equipment = mapper.Map<CreateEquipmentViewModels, Equipment>(model);
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Equipment, EditEquipmentViewModels>();
            });
            IMapper mapper = config.CreateMapper();
            EditEquipmentViewModels model = new EditEquipmentViewModels();
            model = mapper.Map<Equipment, EditEquipmentViewModels>(equipment);
            
            if (equipment == null)
            {
                return HttpNotFound();
            }
            SelectList categories = new SelectList(db.EquipmentCategories, "Id", "Categorie", equipment.CategorieId);
            ViewBag.Categories = categories;
            return View(model);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEquipmentViewModels model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EditEquipmentViewModels, Equipment>();
                });
                IMapper mapper = config.CreateMapper();
                Equipment equipment = new Equipment();
                equipment = mapper.Map<EditEquipmentViewModels, Equipment>(model);
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            equipment.Deleted = true;
            db.Entry(equipment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
