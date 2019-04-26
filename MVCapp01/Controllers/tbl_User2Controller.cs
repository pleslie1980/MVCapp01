using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCapp01;
using MVCapp01.Models;

namespace MVCapp01.Controllers
{
    public class tbl_User2Controller : Controller
    {
        private Models.UserDbEntities db = new Models.UserDbEntities();

        // GET: tbl_User2
        public ActionResult Index()
        {
            return View(db.tbl_User2.ToList());
        }

        public ActionResult Urites()
        {
            using (UserDbEntities db = new UserDbEntities())
            {
                var urites = db.Urites();
            }
            return View();
        }

        // GET: tbl_User2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User2 tbl_User2 = db.tbl_User2.Find(id);
            if (tbl_User2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User2);
        }

        // GET: tbl_User2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_User2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserEmail,Password,Role")] tbl_User2 tbl_User2)
        {
            if (ModelState.IsValid)
            {
                db.tbl_User2.Add(tbl_User2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_User2);
        }

        // GET: tbl_User2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User2 tbl_User2 = db.tbl_User2.Find(id);
            if (tbl_User2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User2);
        }

        // POST: tbl_User2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserEmail,Password,Role")] tbl_User2 tbl_User2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_User2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_User2);
        }

        // GET: tbl_User2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User2 tbl_User2 = db.tbl_User2.Find(id);
            if (tbl_User2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User2);
        }

        // POST: tbl_User2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_User2 tbl_User2 = db.tbl_User2.Find(id);
            db.tbl_User2.Remove(tbl_User2);
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
