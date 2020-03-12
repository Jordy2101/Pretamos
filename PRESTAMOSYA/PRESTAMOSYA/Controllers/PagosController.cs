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
    public class PagosController : Controller
    {
        private PRESTAMOSYAEntities db = new PRESTAMOSYAEntities();

        // GET: Pagos
        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.Cliente).Include(p => p.Transaccion);
            return View(pagos.ToList());
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente");
            ViewBag.ID_Transaccion = new SelectList(db.Transaccions, "ID_Transaccion", "ID_Transaccion");
            ViewBag.ID_Recibo = new SelectList(db.Reciboes, "ID_Recibo", "ID_Recibo");
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pago,ID_Cliente,ID_Recibo,ID_Transaccion,Monto,Tipo_Pago,Fecha_Pago")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", pago.ID_Cliente);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccions, "ID_Transaccion", "ID_Transaccion", pago.ID_Transaccion);
            ViewBag.ID_Recibo = new SelectList(db.Reciboes, "ID_Recibo", "ID_Recibo", pago.ID_Recibo);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", pago.ID_Cliente);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccions, "ID_Transaccion", "ID_Transaccion", pago.ID_Transaccion);
            ViewBag.ID_Recibo = new SelectList(db.Reciboes, "ID_Recibo", "ID_Recibo", pago.ID_Recibo);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pago,ID_Cliente,ID_Recibo,ID_Transaccion,Monto,Tipo_Pago,Fecha_Pago")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "Nombre_Cliente", pago.ID_Cliente);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccions, "ID_Transaccion", "ID_Transaccion", pago.ID_Transaccion);
            ViewBag.ID_Recibo = new SelectList(db.Reciboes, "ID_Recibo", "ID_Recibo", pago.ID_Recibo);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagos.Find(id);
            db.Pagos.Remove(pago);
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
