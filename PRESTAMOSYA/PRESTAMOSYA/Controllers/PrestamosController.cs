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
    public class PrestamosController : Controller
    {
        private PRESTAMOSYAEntities db = new PRESTAMOSYAEntities();

        // GET: Prestamos
        public ActionResult Index()
        {
            var prestamoes = db.Prestamoes.Include(p => p.Cliente).Include(p => p.Empleado);
            return View(prestamoes.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente");
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "Nombre_Empleado");
  
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Prestamo,ID_Empleado,ID_Cliente,Monto_Aprobado,Cuotas,Gastos_Cierre,Tasa,Garante,")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamoes.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", prestamo.ID_Cliente);
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "Nombre_Empleado", prestamo.ID_Empleado);
        
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", prestamo.ID_Cliente);
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "Nombre_Empleado", prestamo.ID_Empleado);
      
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Prestamo,ID_Empleado,ID_Cliente,Monto_Aprobado,Cuotas,Gastos_Cierre,Tasa,Garante,")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", prestamo.ID_Cliente);
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "Nombre_Empleado", prestamo.ID_Empleado);
     
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamoes.Find(id);
            db.Prestamoes.Remove(prestamo);
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
