using System;

namespace Modelos.Datos.Respuesta.DTO.mejora
{
    public class mejoraGridListDTO
    {
        public int idMejora { get; set; }
        public int idTicket { get; set; }
        public string nombreSistema { get; set; }
        public string tipoMejora { get; set; }
        public int prioridad { get; set; }
        public string titulo { get; set; }
        public string usuarioAsignado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioCliente { get; set; }
        public string estadoMejora { get; set; }
        public int idEstadoMejora { get; set; }
        public string usuarioRegistro { get; set; }
        public decimal horasEstimadas { get; set; }
        public decimal horasEjecutadas { get; set; }
    }
}