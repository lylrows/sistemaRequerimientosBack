using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.emision
{
    [Table("[emision].[pedidos]")]
    public  class pedidos
    {       
        public int id { get; set; }
        public string titulo { get; set; }
        public string emailCopyList { get; set; }
        public string descripcion { get; set; }
        public DateTime? inicioVigencia { get; set; }
        public int idEstado { get; set; }
        public int idCuenta { get; set; }
        public int idMovimiento { get; set; }
        public string fichaTecnica { get; set; }
        public string tramaDatos { get; set; }
        public string cartaNoSiniestro { get; set; }
        public string documentosAdicionales { get; set; }
        public string ordenesServicio { get; set; }
        public int? idUsuarioRegistro { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public int? idUsuarioAtendido { get; set; }
        public DateTime? fechaAtencion { get; set; }
        public bool? esActivo { get; set; }
    }
}
