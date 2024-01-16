using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.mejora;

namespace Modelos.Datos.Respuesta.DTO.mejora
{
    public class mejoraDTO 
    {
        public t_mejoras mejora { get; set; }
        public List<t_mejoraArchivos> mejoraArchivos { get; set; }
        public List<t_mejoraRegistroActividades> mejoraActividades { get; set; }

        public mejoraDTO()
        {
            mejora = new t_mejoras();
            mejoraArchivos = new List<t_mejoraArchivos>();
            mejoraActividades = new List<t_mejoraRegistroActividades>();
        }
    }
}