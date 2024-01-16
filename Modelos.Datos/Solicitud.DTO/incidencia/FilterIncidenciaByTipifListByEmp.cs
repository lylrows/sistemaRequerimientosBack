using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaByTipifListByEmp
    {
        public List<int> idTipificacion { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
       // public int id_usuario { get; set; }
        public int id_rol { get; set; }
        public int id_empresa { get; set; }
        public FilterIncidenciaByTipifListByEmp()
        {
            idTipificacion = new List<int>();
        }
    }
}
