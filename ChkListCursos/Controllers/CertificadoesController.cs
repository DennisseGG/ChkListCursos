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
    public class CertificadoesController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Certificadoes
        public ActionResult Index()
        {
            var certificado = db.Certificado.Include(c => c.cat_Area).Include(c => c.Empleado).Include(c => c.Instructor);
            return View(certificado.ToList());
        }

        // GET: Certificadoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificado certificado = db.Certificado.Find(id);
            if (certificado == null)
            {
                return HttpNotFound();
            }
            return View(certificado);
        }

        // GET: Certificadoes/Create
        public ActionResult Create()
        {
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea");
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado");
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor");
            return View();
        }

        // POST: Certificadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCertificado,UuidCertificado,NombreCertificado,UuidEmpleado,UuidInstructor,UuidArea,FechaInicio,FechaFin,Duracion,FG,UG,FM,UM,FB,UB,ST")] Certificado certificado)
        {
            if (ModelState.IsValid)
            {
                certificado.UuidCertificado = Guid.NewGuid();
                db.Certificado.Add(certificado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", certificado.UuidArea);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", certificado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", certificado.UuidInstructor);
            return View(certificado);
        }

        // GET: Certificadoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificado certificado = db.Certificado.Find(id);
            if (certificado == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", certificado.UuidArea);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", certificado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", certificado.UuidInstructor);
            return View(certificado);
        }

        // POST: Certificadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCertificado,UuidCertificado,NombreCertificado,UuidEmpleado,UuidInstructor,UuidArea,FechaInicio,FechaFin,Duracion,FG,UG,FM,UM,FB,UB,ST")] Certificado certificado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", certificado.UuidArea);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", certificado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", certificado.UuidInstructor);
            return View(certificado);
        }

        // GET: Certificadoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificado certificado = db.Certificado.Find(id);
            if (certificado == null)
            {
                return HttpNotFound();
            }
            return View(certificado);
        }

        // POST: Certificadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Certificado certificado = db.Certificado.Find(id);
            db.Certificado.Remove(certificado);
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
