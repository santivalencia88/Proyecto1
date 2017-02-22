using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLog.Models
{
    public class ElVehiculos
    {
        public int El_vehiculo { get; set; }
        public string El_detalle_tipoV { get; set; }
        public string El_detalle_marca { get; set; }
        public string color { get; set; }
        public string numero_placa { get; set; }
        public DateTime fecha { get; set; }


    }
}