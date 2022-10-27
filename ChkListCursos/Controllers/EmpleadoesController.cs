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
    public class EmpleadoesController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.cat_Area).Include(e => e.Usuario);
            return View(empleado.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea");
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,UuidEmpleado,NombreEmpleado,NoEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.UuidEmpleado = Guid.NewGuid();
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", empleado.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", empleado.UuidUsuario);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", empleado.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", empleado.UuidUsuario);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,UuidEmpleado,NombreEmpleado,NoEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", empleado.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", empleado.UuidUsuario);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
