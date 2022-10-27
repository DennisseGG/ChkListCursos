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
    public class cat_RolesController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: cat_Roles
        public ActionResult Index()
        {
            return View(db.cat_Roles.ToList());
        }

        // GET: cat_Roles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Roles cat_Roles = db.cat_Roles.Find(id);
            if (cat_Roles == null)
            {
                return HttpNotFound();
            }
            return View(cat_Roles);
        }

        // GET: cat_Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cat_Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRol,UuidRol,NombreRol,FG,UG,FM,UM,FB,UB,ST")] cat_Roles cat_Roles)
        {
            if (ModelState.IsValid)
            {
                cat_Roles.UuidRol = Guid.NewGuid();
                db.cat_Roles.Add(cat_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_Roles);
        }

        // GET: cat_Roles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Roles cat_Roles = db.cat_Roles.Find(id);
            if (cat_Roles == null)
            {
                return HttpNotFound();
            }
            return View(cat_Roles);
        }

        // POST: cat_Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRol,UuidRol,NombreRol,FG,UG,FM,UM,FB,UB,ST")] cat_Roles cat_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_Roles);
        }

        // GET: cat_Roles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_Roles cat_Roles = db.cat_Roles.Find(id);
            if (cat_Roles == null)
            {
                return HttpNotFound();
            }
            return View(cat_Roles);
        }

        // POST: cat_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            cat_Roles cat_Roles = db.cat_Roles.Find(id);
            db.cat_Roles.Remove(cat_Roles);
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
