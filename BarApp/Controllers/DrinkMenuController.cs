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
    public class DrinkMenuController : Controller
    {
        private BarAppDb db = new BarAppDb();

        // GET: DrinkMenu
        public ActionResult Index()
        {
            return View(db.Drinks.ToList());
        }


        [HttpPost]
        public ActionResult Order(int DrinkId, string DrinkName)
        {

            var model = (from c in db.Drinks
                         select new
                         {
                             c.DrinkId,
                             c.DrinkName
                         });

            foreach (var item in model)
                db.Orders.Add(new OrderQueue()
                {
                    DrinkId = item.DrinkId,
                    DrinkName = item.DrinkName

                });

            db.SaveChanges();

            return View();
        }

        // GET: DrinkMenu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkMenu drinkMenu = db.Drinks.Find(id);
            if (drinkMenu == null)
            {
                return HttpNotFound();
            }
            return View(drinkMenu);
        }

        // GET: DrinkMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrinkMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrinkId,DrinkName")] DrinkMenu drinkMenu)
        {
            if (ModelState.IsValid)
            {
                db.Drinks.Add(drinkMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drinkMenu);
        }

        // GET: DrinkMenu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkMenu drinkMenu = db.Drinks.Find(id);
            if (drinkMenu == null)
            {
                return HttpNotFound();
            }
            return View(drinkMenu);
        }

        // POST: DrinkMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrinkId,DrinkName")] DrinkMenu drinkMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinkMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drinkMenu);
        }

        // GET: DrinkMenu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkMenu drinkMenu = db.Drinks.Find(id);
            if (drinkMenu == null)
            {
                return HttpNotFound();
            }
            return View(drinkMenu);
        }

        // POST: DrinkMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrinkMenu drinkMenu = db.Drinks.Find(id);
            db.Drinks.Remove(drinkMenu);
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
