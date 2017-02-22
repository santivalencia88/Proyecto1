using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarLog.Models;

namespace CarLog.Controllers
{
    public class MantenimientoTipoVehiculoController : Controller
    {
        private ParqueaderoEntities1 db = new ParqueaderoEntities1();

        // GET: MantenimientoTipoVehiculo
        public ActionResult Index()
        {
            return View(db.tipo_vehiculo.ToList());
        }

        // GET: MantenimientoTipoVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_vehiculo tipo_vehiculo = db.tipo_vehiculo.Find(id);
            if (tipo_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vehiculo);
        }

        // GET: MantenimientoTipoVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoTipoVehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipovehiculo,detalle_tipovehiculo")] tipo_vehiculo tipo_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tipo_vehiculo.Add(tipo_vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_vehiculo);
        }

        // GET: MantenimientoTipoVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_vehiculo tipo_vehiculo = db.tipo_vehiculo.Find(id);
            if (tipo_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vehiculo);
        }

        // POST: MantenimientoTipoVehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipovehiculo,detalle_tipovehiculo")] tipo_vehiculo tipo_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_vehiculo);
        }

        // GET: MantenimientoTipoVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_vehiculo tipo_vehiculo = db.tipo_vehiculo.Find(id);
            if (tipo_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vehiculo);
        }

        // POST: MantenimientoTipoVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_vehiculo tipo_vehiculo = db.tipo_vehiculo.Find(id);
            db.tipo_vehiculo.Remove(tipo_vehiculo);
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
