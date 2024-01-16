using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class horarioEmpresaListDTO
    {
        public int idHorario { get; set; }
        public List<diasAtencion> dias { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

        public horarioEmpresaListDTO()
        {
            dias = new List<diasAtencion>();
        }
    }

    public class diasAtencion
    {
        public string dia { get; set; }
        public bool @checked { get; set; }
    }
}
