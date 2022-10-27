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
    public class CursoXempleadoesController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: CursoXempleadoes
        public ActionResult Index()
        {
            var cursoXempleado = db.CursoXempleado.Include(c => c.Curso).Include(c => c.Empleado).Include(c => c.Instructor);
            return View(cursoXempleado.ToList());
        }

        // GET: CursoXempleadoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoXempleado cursoXempleado = db.CursoXempleado.Find(id);
            if (cursoXempleado == null)
            {
                return HttpNotFound();
            }
            return View(cursoXempleado);
        }

        // GET: CursoXempleadoes/Create
        public ActionResult Create()
        {
            ViewBag.UuidCurso = new SelectList(db.Curso, "UuidCurso", "NombreCurso");
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado");
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor");
            return View();
        }

        // POST: CursoXempleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCursoXempleado,UuidCursoXempleado,UuidCurso,UuidEmpleado,UuidInstructor,Estatus,FG,UG,FM,UM,FB,UB,ST")] CursoXempleado cursoXempleado)
        {
            if (ModelState.IsValid)
            {
                cursoXempleado.UuidCursoXempleado = Guid.NewGuid();
                db.CursoXempleado.Add(cursoXempleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidCurso = new SelectList(db.Curso, "UuidCurso", "NombreCurso", cursoXempleado.UuidCurso);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", cursoXempleado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", cursoXempleado.UuidInstructor);
            return View(cursoXempleado);
        }

        // GET: CursoXempleadoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoXempleado cursoXempleado = db.CursoXempleado.Find(id);
            if (cursoXempleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidCurso = new SelectList(db.Curso, "UuidCurso", "NombreCurso", cursoXempleado.UuidCurso);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", cursoXempleado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", cursoXempleado.UuidInstructor);
            return View(cursoXempleado);
        }

        // POST: CursoXempleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCursoXempleado,UuidCursoXempleado,UuidCurso,UuidEmpleado,UuidInstructor,Estatus,FG,UG,FM,UM,FB,UB,ST")] CursoXempleado cursoXempleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoXempleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidCurso = new SelectList(db.Curso, "UuidCurso", "NombreCurso", cursoXempleado.UuidCurso);
            ViewBag.UuidEmpleado = new SelectList(db.Empleado, "UuidEmpleado", "NombreEmpleado", cursoXempleado.UuidEmpleado);
            ViewBag.UuidInstructor = new SelectList(db.Instructor, "UuidInstructor", "NombreInstructor", cursoXempleado.UuidInstructor);
            return View(cursoXempleado);
        }

        // GET: CursoXempleadoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoXempleado cursoXempleado = db.CursoXempleado.Find(id);
            if (cursoXempleado == null)
            {
                return HttpNotFound();
            }
            return View(cursoXempleado);
        }

        // POST: CursoXempleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CursoXempleado cursoXempleado = db.CursoXempleado.Find(id);
            db.CursoXempleado.Remove(cursoXempleado);
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
