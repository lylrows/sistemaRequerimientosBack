using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    [Table("[persona].[empresaANS]")]
    public class t_empresaANS
    {
        public int id                                { get; set; }
            public int idEmpresa                     { get; set; }
            public int idTipoIncidencia { get; set; }
            public decimal tiempoMaximoAtencion      { get; set; }
            public int usuarioNotificación           { get; set; }
            public int esActivo { get; set; }
    }
}
