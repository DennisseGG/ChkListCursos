using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChkListCursos.Models;

namespace ChkListCursos.Controllers
{
    public class cat_AreaController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: cat_Area
        public ActionResult Index()
        {
            return View(db.cat_Area.ToList());
        }

        // GET: cat_Area/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Area cat_Area = db.cat_Area.Find(id);
            if (cat_Area == null)
            {
                return HttpNotFound();
            }
            return View(cat_Area);
        }

        // GET: cat_Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_Area/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArea,UuidArea,NombreArea,FG,UG,FM,UM,FB,UB,ST")] cat_Area cat_Area)
        {
            if (ModelState.IsValid)
            {
                cat_Area.UuidArea = Guid.NewGuid();
                db.cat_Area.Add(cat_Area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_Area);
        }

        // GET: cat_Area/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Area cat_Area = db.cat_Area.Find(id);
            if (cat_Area == null)
            {
                return HttpNotFound();
            }
            return View(cat_Area);
        }

        // POST: cat_Area/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArea,UuidArea,NombreArea,FG,UG,FM,UM,FB,UB,ST")] cat_Area cat_Area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_Area);
        }

        // GET: cat_Area/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Area cat_Area = db.cat_Area.Find(id);
            if (cat_Area == null)
            {
                return HttpNotFound();
            }
            return View(cat_Area);
        }

        // POST: cat_Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            cat_Area cat_Area = db.cat_Area.Find(id);
            db.cat_Area.Remove(cat_Area);
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
