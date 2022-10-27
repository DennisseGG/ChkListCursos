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
    public class CursoesController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Cursoes
        public ActionResult Index()
        {
            var curso = db.Curso.Include(c => c.Instructor);
            return View(curso.ToList());
        }

        // GET: Cursoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursoes/Create
        public ActionResult Create()
        {
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor");
            return View();
        }

        // POST: Cursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCurso,UuidCurso,NombreCurso,UuidInstructor,Capacidad,Duracion,FechaInicio,FechaFin,Estatus,FG,UG,FM,UM,FB,UB,ST")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                curso.UuidCurso = Guid.NewGuid();
                db.Curso.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", curso.UuidInstructor);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", curso.UuidInstructor);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCurso,UuidCurso,NombreCurso,UuidInstructor,Capacidad,Duracion,FechaInicio,FechaFin,Estatus,FG,UG,FM,UM,FB,UB,ST")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", curso.UuidInstructor);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Curso curso = db.Curso.Find(id);
            db.Curso.Remove(curso);
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
