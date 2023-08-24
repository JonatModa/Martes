using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Martes22.Models;

namespace Martes22.Controllers
{
    public class RegistrosController : Controller
    {
        private Context db = new Context();

        // GET: Registros
        public ActionResult Index()
        {
            return View(db.Registros.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int Edad)
        {
            var Buscar = (from A in db.Registros
                          where A.edad == Edad
                          select  new 
                          {
                              Nombre = A.Nombre,
                              Pais = A.Pais,
                              edad= A.edad,
                              Puesto = A.Puesto
                              
                          }).ToList();

            //List<Registros> lst = null;

            var lst = db.Registros.Where(p => p.edad == Edad).Select(x => new 
            {
                Nombre = x.Nombre,
                Pais = x.Pais,
                edad = x.edad,
                Puesto = x.Puesto
            }).ToList();

            List<Registros> list = new List<Registros>();
            foreach (var R in lst)
            {
                list.Add(new Registros { Nombre = R.Nombre, Pais = R.Pais, edad = R.edad, Puesto = R.Puesto });
            }
            //List<SelectListItem> item = lst.ConvertAll(d =>
            //{
            //    return new SelectListItem() 
            //    {
            //        Text = d.Nombre,
            //        te = d.Pais,
            //        edad = d.edad,
            //        Puesto = d.Puesto
            //    }
            //})

            ViewBag.item = list;


            return View();
        }

        // GET: Registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros registros = db.Registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Pais,edad,Salario,Puesto")] Registros registros)
        {
            if (ModelState.IsValid)
            {
                db.Registros.Add(registros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registros);
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros registros = db.Registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // POST: Registros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Pais,edad,Salario,Puesto")] Registros registros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registros);
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registros registros = db.Registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registros registros = db.Registros.Find(id);
            db.Registros.Remove(registros);
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
