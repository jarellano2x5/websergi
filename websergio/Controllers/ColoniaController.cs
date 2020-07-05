using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using websergio.Data;
using websergio.Models;

namespace websergio.Controllers
{
    public class ColoniaController : Controller
    {
        private RevContext db = new RevContext();

        // GET: Colonia
        public ActionResult Index()
        {
            return View(db.Colonias.ToList());
        }

        // GET: Colonia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colonia colonia = db.Colonias.Find(id);
            if (colonia == null)
            {
                return HttpNotFound();
            }
            return View(colonia);
        }

        // GET: Colonia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colonia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Activo")] Colonia colonia)
        {
            if (ModelState.IsValid)
            {
                db.Colonias.Add(colonia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colonia);
        }

        // GET: Colonia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colonia colonia = db.Colonias.Find(id);
            if (colonia == null)
            {
                return HttpNotFound();
            }
            return View(colonia);
        }

        // POST: Colonia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Activo")] Colonia colonia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colonia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colonia);
        }

        // GET: Colonia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colonia colonia = db.Colonias.Find(id);
            if (colonia == null)
            {
                return HttpNotFound();
            }
            return View(colonia);
        }

        // POST: Colonia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colonia colonia = db.Colonias.Find(id);
            db.Colonias.Remove(colonia);
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
