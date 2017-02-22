using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarLog.Models;

namespace CarLog.Controllers
{
    public class VehiculoController : Controller
    {
        ParqueaderoEntities1 entidadbd = new ParqueaderoEntities1();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var listavehiculos = entidadbd.vehiculo;
            
            return View(listavehiculos.ToList());
        }

        public ActionResult Empleados()
        {
            var listaempleados = entidadbd.empleado;

            return View(listaempleados.ToList());
        }

                
        public ActionResult Marcas()
        {
            var listamarcas = entidadbd.marca;

            return View(listamarcas.ToList());
        }

        public ActionResult TipoVehiculo()
        {
            var listatipov = entidadbd.tipo_vehiculo;

            return View(listatipov.ToList());
        }

        //public ActionResult VehiculosDetallados()
        //{
        //    var modelo = from v in entidadbd.vehiculo
        //                 join tv in entidadbd.tipo_vehiculo
        //                 on v.id_tipovehiculo equals tv.id_tipovehiculo
        //                 join m in entidadbd.marca
        //                 on v.id_marca equals m.id_marca

        //                 select new ElVehiculos
        //                 {
        //                     El_vehiculo = v.id_vehiculo,
        //                     El_detalle_tipoV = tv.detalle_tipovehiculo,
        //                     El_detalle_marca = m.detalle_marca

        //                 };
        //    return View(modelo.ToList());
        //}

    }
}