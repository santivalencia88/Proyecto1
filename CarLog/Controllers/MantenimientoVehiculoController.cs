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
    public class MantenimientoVehiculoController : Controller
    {
        private ParqueaderoEntities1 db = new ParqueaderoEntities1();

        // GET: MantenimientoVehiculo
        public ActionResult Index()
        {
            var vehiculo = db.vehiculo.Include(v => v.empleado).Include(v => v.marca).Include(v => v.tipo_vehiculo);
            return View(vehiculo.ToList());
            
        }

        // GET: MantenimientoVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: MantenimientoVehiculo/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre");
            ViewBag.id_marca = new SelectList(db.marca, "id_marca", "detalle_marca");
            ViewBag.id_tipovehiculo = new SelectList(db.tipo_vehiculo, "id_tipovehiculo", "detalle_tipovehiculo");
            return View();
        }

        // POST: MantenimientoVehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vehiculo,id_tipovehiculo,id_marca,id_empleado,color,num_placa,fecha")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", vehiculo.id_empleado);
            ViewBag.id_marca = new SelectList(db.marca, "id_marca", "detalle_marca", vehiculo.id_marca);
            ViewBag.id_tipovehiculo = new SelectList(db.tipo_vehiculo, "id_tipovehiculo", "detalle_tipovehiculo", vehiculo.id_tipovehiculo);
            return View(vehiculo);
        }

        // GET: MantenimientoVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", vehiculo.id_empleado);
            ViewBag.id_marca = new SelectList(db.marca, "id_marca", "detalle_marca", vehiculo.id_marca);
            ViewBag.id_tipovehiculo = new SelectList(db.tipo_vehiculo, "id_tipovehiculo", "detalle_tipovehiculo", vehiculo.id_tipovehiculo);
            return View(vehiculo);
        }

        // POST: MantenimientoVehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vehiculo,id_tipovehiculo,id_marca,id_empleado,color,num_placa,fecha")] vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.empleado, "id_empleado", "nombre", vehiculo.id_empleado);
            ViewBag.id_marca = new SelectList(db.marca, "id_marca", "detalle_marca", vehiculo.id_marca);
            ViewBag.id_tipovehiculo = new SelectList(db.tipo_vehiculo, "id_tipovehiculo", "detalle_tipovehiculo", vehiculo.id_tipovehiculo);
            return View(vehiculo);
        }

        // GET: MantenimientoVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: MantenimientoVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            db.vehiculo.Remove(vehiculo);
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
