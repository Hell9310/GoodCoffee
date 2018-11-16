using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodCoffee.Models;

namespace GoodCoffee.Controllers
{
    public class GALERIAsController : Controller
    {
        private PRODUCTOSEntities db = new PRODUCTOSEntities();

        // GET: GALERIAs
        public ActionResult Index()
        {
            return View(db.GALERIA.ToList());
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }
        // GET: GALERIAs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GALERIA gALERIA = db.GALERIA.Find(id);
            if (gALERIA == null)
            {
                return HttpNotFound();
            }
            return View(gALERIA);
        }

        // GET: GALERIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GALERIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,VARIEDAD,PAIS,OURSCORE,FARM,IMAGEN")] GALERIA gALERIA)
        {
            if (ModelState.IsValid)
            {
                db.GALERIA.Add(gALERIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gALERIA);
        }

        // GET: GALERIAs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GALERIA gALERIA = db.GALERIA.Find(id);
            if (gALERIA == null)
            {
                return HttpNotFound();
            }
            return View(gALERIA);
        }

        // POST: GALERIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,VARIEDAD,PAIS,OURSCORE,FARM,IMAGEN")] GALERIA gALERIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gALERIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gALERIA);
        }

        // GET: GALERIAs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GALERIA gALERIA = db.GALERIA.Find(id);
            if (gALERIA == null)
            {
                return HttpNotFound();
            }
            return View(gALERIA);
        }

        // POST: GALERIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GALERIA gALERIA = db.GALERIA.Find(id);
            db.GALERIA.Remove(gALERIA);
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
