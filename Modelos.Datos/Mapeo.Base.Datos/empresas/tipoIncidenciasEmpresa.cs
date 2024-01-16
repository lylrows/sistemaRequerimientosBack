using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.empresas
{
    [Table("[empresas].[tipoIncidenciasEmpresa]")]
    public class tipoIncidenciasEmpresa
    {
        public int id { get; set; }
        public int? idEmpresa { get; set; }
        public int? idTipoIncidencia { get; set; }
    }
}
