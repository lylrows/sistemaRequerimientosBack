using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidencias]")]
    public class t_incidencias
    {
        public int id                        { get; set; }
        public int idTicket { get; set; }
        public int idEmpSist { get; set; }
        public int idUsuarioRegistro         { get; set; }
        public int idTipoIncidencia { get; set; }
        public int idSubtipoIncidencia { get; set; }
        public int idTipificacion { get; set; }
        public string nombre                 { get; set; }
        public DateTime fechaRegistro        { get; set; }
        public int idPrioridad               { get; set; }
        public int idEstado                  { get; set; }
        public DateTime? fechaAtencion        { get; set; }
        public int calificacionIncidente { get; set; }
        public int cumplioANS { get; set; }
        public decimal horasEstimadas { get; set; }
        public decimal horasEjecutadas { get; set; }
        public DateTime? fechaMaximaAtencion { get; set; }
        public int idUsuarioActualiza { get; set; }
        public DateTime? fechaActualiza { get; set; }
        public int esActivo { get; set; }
    }
}
