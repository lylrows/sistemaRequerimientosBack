using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO
{
    public class filterDataMejorasDTO
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEmpresa { get; set; }
        public int solucionRaiz { get; set; }
    }
}
