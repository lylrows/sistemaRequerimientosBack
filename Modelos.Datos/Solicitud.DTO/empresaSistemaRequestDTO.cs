using Modelos.Datos.Mapeo.Base.Datos.configuracion;

namespace Modelos.Datos.Solicitud.DTO
{
    public class empresaSistemaRequestDTO
    {
        public t_sistemas sistema { get; set; }
        public t_empresaSistemas empresaSistema { get; set; }

        public empresaSistemaRequestDTO()
        {
            sistema = new t_sistemas();
            empresaSistema = new t_empresaSistemas();
        }
    }
}