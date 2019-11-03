using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;
using Storage.Models;
using Storage.ViewModels;
using StorageView.Models;

namespace Storage.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var orders = db.Orders.Include(o => o.Status).Include(x => x.Profile).Where(x => x.OrderName != null).OrderByDescending(x => x.OrderName);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Request(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var request = db.Orders.Include(o => o.Status).Where(x => x.EquipmentId != null).OrderByDescending(x => x.Id);
            return View(request.ToPagedList(pageNumber, pageSize));
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.OrderStatuses, "Id", "Status");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderName,Price,Url,StatusId,ProfieId")] Order order)
        {
            if (ModelState.IsValid)
            {
                var status = db.OrderStatuses.FirstOrDefault(p => p.Status == "Новий Запит");
                order.StatusId = status.Id;
                order.UserId = User.Identity.GetUserId();
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, EditOrderViewModels>();
            });
            IMapper mapper = config.CreateMapper();
            EditOrderViewModels model = new EditOrderViewModels();
            model = mapper.Map<Order, EditOrderViewModels>(order);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.OrderStatuses, "Id", "Status", order.StatusId);
            return View(model);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditOrderViewModels model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EditOrderViewModels, Order>();
                });
                IMapper mapper = config.CreateMapper();
                Order order = new Order();

               
               
                order = mapper.Map<EditOrderViewModels, Order>(model);
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        
        public ActionResult DeleteRequest(DeleteRequestOrderViewModels model)
        {
            Order order = new Order();
            var status = db.OrderStatuses.FirstOrDefault(p => p.Status == "Новий Запит");
            order.StatusId = status.Id;
            order.UserId = model.UserId;
            order.EquipmentId = model.EquipmentId;
            order.Notation = "Повертаю";
            db.Orders.Add(order);
            db.SaveChanges();
            return Json("Ваш запит надіслано");
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
