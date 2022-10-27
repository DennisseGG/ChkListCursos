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
    public class VerificadorsController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Verificadors
        public ActionResult Index()
        {
            var verificador = db.Verificador.Include(v => v.cat_Area).Include(v => v.Usuario);
            return View(verificador.ToList());
        }

        // GET: Verificadors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verificador verificador = db.Verificador.Find(id);
            if (verificador == null)
            {
                return HttpNotFound();
            }
            return View(verificador);
        }

        // GET: Verificadors/Create
        public ActionResult Create()
        {
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea");
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario");
            return View();
        }

        // POST: Verificadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCurso,UuidVerificador,NombreVerificador,UuidEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Verificador verificador)
        {
            if (ModelState.IsValid)
            {
                verificador.UuidVerificador = Guid.NewGuid();
                db.Verificador.Add(verificador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", verificador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", verificador.UuidUsuario);
            return View(verificador);
        }

        // GET: Verificadors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verificador verificador = db.Verificador.Find(id);
            if (verificador == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", verificador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", verificador.UuidUsuario);
            return View(verificador);
        }

        // POST: Verificadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCurso,UuidVerificador,NombreVerificador,UuidEmpleado,UuidArea,FG,UG,FM,UM,FB,UB,ST,UuidUsuario")] Verificador verificador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verificador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", verificador.UuidArea);
            ViewBag.UuidUsuario = new SelectList(db.Usuario, "UuidUsuario", "NombreUsuario", verificador.UuidUsuario);
            return View(verificador);
        }

        // GET: Verificadors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verificador verificador = db.Verificador.Find(id);
            if (verificador == null)
            {
                return HttpNotFound();
            }
            return View(verificador);
        }

        // POST: Verificadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Verificador verificador = db.Verificador.Find(id);
            db.Verificador.Remove(verificador);
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
