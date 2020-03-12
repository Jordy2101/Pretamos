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
    public class SolicitudesController : Controller
    {
        private PRESTAMOSYAEntities db = new PRESTAMOSYAEntities();

        // GET: Solicitudes
        public ActionResult Index()
        {
            var solicitudes = db.Solicitudes.Include(s => s.Cliente);
            return View(solicitudes.ToList());
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitude solicitude = db.Solicitudes.Find(id);
            if (solicitude == null)
            {
                return HttpNotFound();
            }
            return View(solicitude);
        }

        // GET: Solicitudes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente");
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Solicitud,ID_Cliente,Nombre_Solicitante,Cedula_Solicitante,Telefono_Solicitante,tasa,monto,plazo,Monto_Cuota,Correo_Electronico")] Solicitude solicitude)
        {
            if (ModelState.IsValid)
            {
                db.Solicitudes.Add(solicitude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", solicitude.ID_Cliente);
            return View(solicitude);
        }

        // GET: Solicitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitude solicitude = db.Solicitudes.Find(id);
            if (solicitude == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", solicitude.ID_Cliente);
            return View(solicitude);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Solicitud,ID_Cliente,Nombre_Solicitante,Cedula_Solicitante,Telefono_Solicitante,tasa,monto,plazo,Monto_Cuota,Correo_Electronico")] Solicitude solicitude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", solicitude.ID_Cliente);
            return View(solicitude);
        }

        // GET: Solicitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitude solicitude = db.Solicitudes.Find(id);
            if (solicitude == null)
            {
                return HttpNotFound();
            }
            return View(solicitude);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitude solicitude = db.Solicitudes.Find(id);
            db.Solicitudes.Remove(solicitude);
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
