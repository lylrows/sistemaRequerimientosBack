using System.Collections.Generic;

namespace Modelos.Datos.Respuesta.DTO
{
    public class tipificacionByEmpresaDTO
    {
        public List<tipificacion> ListTipificacion { get; set; }
        public List<tipoIncidencia> ListTipoIncidencias { get; set; }

        public tipificacionByEmpresaDTO()
        {
            ListTipificacion = new List<tipificacion>();
            ListTipoIncidencias = new List<tipoIncidencia>();
        }
    }

    public class tipoIncidencia
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public int idTipoIncidencia { get; set; }
        public string nombre { get; set; }
    }

    public class tipificacion
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public int idTipificacion { get; set; }
        public string nombre { get; set; }
    }
}