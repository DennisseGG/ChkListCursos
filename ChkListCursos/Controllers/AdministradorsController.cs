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
    public class AdministradorsController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Administradors
        public ActionResult Index()
        {
            var administrador = db.Administrador.Include(a => a.cat_Area).Include(a => a.Usuario);
            return View(administrador.ToList());
        }

        // GET: Administradors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administradors/Create
        public ActionResult Create()
        {
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea");
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario");
            return View();
        }

        // POST: Administradors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAdministrador,UuidAdministrador,NombreAdministrador,UuidEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                administrador.UuidAdministrador = Guid.NewGuid();
                db.Administrador.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", administrador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", administrador.UuidUsuario);
            return View(administrador);
        }

        // GET: Administradors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", administrador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", administrador.UuidUsuario);
            return View(administrador);
        }

        // POST: Administradors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAdministrador,UuidAdministrador,NombreAdministrador,UuidEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", administrador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", administrador.UuidUsuario);
            return View(administrador);
        }

        // GET: Administradors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Administrador administrador = db.Administrador.Find(id);
            db.Administrador.Remove(administrador);
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
