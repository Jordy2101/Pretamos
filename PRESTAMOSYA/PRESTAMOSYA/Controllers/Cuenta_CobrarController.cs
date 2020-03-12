using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRESTAMOSYA.Models;

namespace PRESTAMOSYA.Controllers
{
    public class Cuenta_CobrarController : Controller
    {
        private PRESTAMOSYAEntities db = new PRESTAMOSYAEntities();

        // GET: Cuenta_Cobrar
        public ActionResult Index()
        {
            var cuenta_Cobrar = db.Cuenta_Cobrar.Include(c => c.Cliente);
            return View(cuenta_Cobrar.ToList());
        }

        // GET: Cuenta_Cobrar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cobrar cuenta_Cobrar = db.Cuenta_Cobrar.Find(id);
            if (cuenta_Cobrar == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_Cobrar);
        }

        // GET: Cuenta_Cobrar/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente");
            return View();
        }

        // POST: Cuenta_Cobrar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente,Total_Mora,Monto_Capital,Monto_Interes,ID_Cuenta_Cobrar")] Cuenta_Cobrar cuenta_Cobrar)
        {
            if (ModelState.IsValid)
            {
                db.Cuenta_Cobrar.Add(cuenta_Cobrar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Prestamo = new SelectList(db.Prestamoes, "ID_Cliente", "Nombre_Cliente", cuenta_Cobrar.ID_Cliente);
            return View(cuenta_Cobrar);
        }

        // GET: Cuenta_Cobrar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cobrar cuenta_Cobrar = db.Cuenta_Cobrar.Find(id);
            if (cuenta_Cobrar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Prestamo = new SelectList(db.Prestamoes, "ID_Cliente", "Nombre_Cliente", cuenta_Cobrar.ID_Cliente);
            return View(cuenta_Cobrar);
        }

        // POST: Cuenta_Cobrar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,Total_Mora,Monto_Capital,Monto_Interes,ID_Cuenta_Cobrar")] Cuenta_Cobrar cuenta_Cobrar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta_Cobrar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Prestamo = new SelectList(db.Prestamoes, "ID_Cliente", "Nombre_Cliente", cuenta_Cobrar.ID_Cliente);
            return View(cuenta_Cobrar);
        }

        // GET: Cuenta_Cobrar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cobrar cuenta_Cobrar = db.Cuenta_Cobrar.Find(id);
            if (cuenta_Cobrar == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_Cobrar);
        }

        // POST: Cuenta_Cobrar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta_Cobrar cuenta_Cobrar = db.Cuenta_Cobrar.Find(id);
            db.Cuenta_Cobrar.Remove(cuenta_Cobrar);
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
