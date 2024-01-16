using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class reporteIncidenciaResponseDTO
    {
        public int id { get; set; }
        public int idTicket { get; set; }
        public string solicitante { get; set; }
        public string fechaRegistro { get; set; }
        public string tituloTicket { get; set; }
        public string estado { get; set; }
        public string razonSocial { get; set; }
        public string sistema { get; set; }
        public string prioridad { get; set; }
        public string responsable { get; set; }
        public string fechaAtencion { get; set; }
        public string tipificacion { get; set; }
        public string tipo { get; set; }
        public decimal horasEstimadas { get; set; }
        public decimal horasEjecutadas { get; set; }
        public string TiempoEmpleado { get; set; }
        public string ans { get; set; }
    }
}
