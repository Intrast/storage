using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;
using Storage.Models;
using Storage.ViewModels;

namespace Storage.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Profiles
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var profiles = db.Profiles.Include(x => x.Group).OrderByDescending(x => x.Name);
            return View(profiles.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult MyProfile()
        {
            var a = User.Identity.GetUserId();
            Models.Profile profile = db.Profiles.Include(x => x.Group).Include(x => x.Equipments).FirstOrDefault(x => x.UserId == a);
            return View(profile);
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Profile profile = db.Profiles.Include(x => x.Group).Include(p => p.Equipments).FirstOrDefault(p=>p.Id==id);

            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }
        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Profile profile = db.Profiles.Find(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Profile, EditProfileViewModels>();
            });

            IMapper mapper = config.CreateMapper();
            EditProfileViewModels model = new EditProfileViewModels();
            model = mapper.Map<Models.Profile, EditProfileViewModels>(profile);

            if (profile == null)
            {
                return HttpNotFound();
            }

            SelectList groups = new SelectList(db.ProfileGroups, "Id", "Group", model.GroupId);
            ViewBag.Groups = groups;
            return View(model);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModels model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EditProfileViewModels, Models.Profile>();
                });

                IMapper mapper = config.CreateMapper();
                Models.Profile profile = new Models.Profile();
                profile = mapper.Map<EditProfileViewModels, Models.Profile>(model);
                
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Admin") &&  model.UserId != User.Identity.GetUserId())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("MyProfile");
                }
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        // GET: Profiles/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
