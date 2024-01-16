using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class emissionOrdersGrid
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string inicioVigencia { get; set; }
        public string estado { get; set; }
        public string usuarioRegistro { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public string usuarioAtendido { get; set; }
        public int? idUsuarioAtendido { get; set; }
        public string fechaAtencion { get; set; }

    }
}
