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
    public class UsuariosController : Controller
    {
        private ChkListCursosEntities db = new ChkListCursosEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.cat_Roles);
            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.UuidRol = new SelectList(db.cat_Roles, "UuidRol", "NombreRol");
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,UuidUsuario,NombreUsuario,ApellidoPaterno,ApellidoMaterno,NoEmpleado,UuidArea,UuidRol,Email,Password,FG,UG,FM,UM,FB,UB,ST")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.UuidUsuario = Guid.NewGuid();
                db.Usuario.Add(usuario);
                if (usuario.UuidRol.Equals("38556786-5d45-4479-a745-850003779962"))
                {
                    
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UuidRol = new SelectList(db.cat_Roles, "UuidRol", "NombreRol", usuario.UuidRol);
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", usuario.UuidArea);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.UuidRol = new SelectList(db.cat_Roles, "UuidRol", "NombreRol", usuario.UuidRol);
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", usuario.UuidArea);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,UuidUsuario,NombreUsuario,ApellidoPaterno,ApellidoMaterno,NoEmpleado,UuidArea,UuidRol,Email,Password,FG,UG,FM,UM,FB,UB,ST")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UuidRol = new SelectList(db.cat_Roles, "UuidRol", "NombreRol", usuario.UuidRol);
            ViewBag.UuidArea = new SelectList(db.cat_Area, "UuidArea", "NombreArea", usuario.UuidArea);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
