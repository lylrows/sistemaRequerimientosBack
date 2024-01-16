using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FIlterIncidenciaByAsigMonth
    {
        public int idUsuarioAsignado { get; set; }
        public int mesInicio { get; set; }
        public int mesFin { get; set; }
    }
}
