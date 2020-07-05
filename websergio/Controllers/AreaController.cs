using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using websergio.Models;
using websergio.Data;
using websergio.DTOs;

namespace websergio.Controllers
{
    public class AreaController : Controller
    {
        private RevContext db = new RevContext();
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetByColonia(int id)
        {
            List<AreaDTO> ls = db.Areas.Where(a => a.IdColonia == id)
                .Select(a => new AreaDTO
                {
                    Id = a.Id,
                    IdColonia = a.IdColonia,
                    Puntos = a.Puntos,
                    Activo = a.Activo
                }).ToList();
            return Json(ls, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(List<Area> li)
        {
            if (li.Any())
            {
                foreach(Area a in li)
                {
                    if (a.Id == 0)
                    {
                        db.Areas.Add(a);
                    }
                    else
                    {
                        db.Entry(a).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            Area ar = db.Areas.FirstOrDefault(a => a.Id == id);
            db.Areas.Remove(ar);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
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