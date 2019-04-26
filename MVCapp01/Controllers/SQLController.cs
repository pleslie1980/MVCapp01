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
    

    public class SQLController : Controller
    {
        // GET: SQL
        public ActionResult Index()
        {
            // A tbl_User2 tábla lekérése
            UserDbEntities db = new UserDbEntities();
            IQueryable<tbl_User2> user2Query =
            from U2 in db.tbl_User2
            select U2;

            //Hiányzó adatok lekérése
            var r1 = db.Adatmigracio_test().ToList();

            string E1 = null;
            string E2 = null;
            DateTime D1 = DateTime.Now;

            if (r1.Count > 0 )
            {
                //Ha történt
                E1 = "Adatmásolás";
                E2 = "Megtörtént"; 
            }
            else
            {
                //Ha nem történt
                E1 = "Adatmásolás";
                E2 = "Nincs új rekord";                
            }

            
            //Logolás
            var futtatas2 = db.Logolas2(E1, E2, D1);

            //Az Adatmigráció tárolt eljárás futtatása
            var futtatas = db.Adatmigracio();

            

            //Adatátadás a View-nak
            ViewBag.Esemeny = E1;
            ViewBag.Eredmeny = E2;
            ViewBag.Datum = D1;
            ViewBag.SpR = r1;

            return View(user2Query);
        }
       

        // GET: SQL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SQL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SQL/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SQL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SQL/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SQL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SQL/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
