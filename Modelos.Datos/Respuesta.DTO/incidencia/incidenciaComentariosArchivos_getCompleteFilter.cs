using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaComentariosArchivos_getCompleteFilter
    {
        public int id { get; set; }
        public int idEmpSist { get; set; }
        public string nombreSistema { get; set; }
        public int idSubtipoIncidencia { get; set; }
        public string subtipoIncidencia { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string usuarioRegistro { get; set; }
        public int idTipoIncidencia { get; set; }
        public string tipoIncidencia { get; set; }
        public string nombreIncidencia { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idPrioridad { get; set; }
        public string prioridad { get; set; }
        public int idEstado { get; set; }
        public string estado { get; set; }
        public DateTime fechaAtencion { get; set; }
        public List<incidenciaArchivos_complete> archivos { get; set; }
        public List<incidenciaComentarios_complete> comentarios { get; set; }
    }
}
