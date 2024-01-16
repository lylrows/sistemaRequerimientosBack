using System;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciasGridDTO
    {
        public int idIncidencia { get; set; }
        public int idTicket { get; set; }
        public int idSistema { get; set; }
        public string nombreSistema { get; set; }
        public string razonSocial { get; set; }
        public string tipoIncidencia { get; set; }
        public string incidente { get; set; }
        public string prioridad { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioReg { get; set; }
        public int idEmpresa { get; set; }
        public string usuarioAsignado { get; set; }
        public DateTime fechaMaximaAtencion { get; set; }
    }
}