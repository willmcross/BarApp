using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarApp.Models;

namespace BarApp.Controllers
{
    public class OrderQueuesController : Controller
    {
        private BarAppDb db = new BarAppDb();

        // GET: OrderQueues
        public ActionResult Index()
        {
            //If needed, could add OrderTime field to fill on insertion and run LINQ to OrderBy Ordertime.
            //However, each order is done individually via a particular Drink, so will be inserted in a FIFO manner.
            return View(db.Orders.ToList());
        }

        // GET: OrderQueues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderQueue orderQueue = db.Orders.Find(id);
            if (orderQueue == null)
            {
                return HttpNotFound();
            }
            return View(orderQueue);
        }

        // GET: OrderQueues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderQueues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,DrinkId,DrinkName")] OrderQueue orderQueue)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orderQueue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderQueue);
        }

        // GET: OrderQueues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderQueue orderQueue = db.Orders.Find(id);
            if (orderQueue == null)
            {
                return HttpNotFound();
            }
            return View(orderQueue);
        }

        // POST: OrderQueues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,DrinkId,DrinkName")] OrderQueue orderQueue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderQueue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderQueue);
        }

        // GET: OrderQueues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderQueue orderQueue = db.Orders.Find(id);
            if (orderQueue == null)
            {
                return HttpNotFound();
            }
            return View(orderQueue);
        }

        // POST: OrderQueues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderQueue orderQueue = db.Orders.Find(id);
            db.Orders.Remove(orderQueue);
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
