using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    class usuarioAsignadoMejora
    {
        public int idUsuario { get; set; }
        public int idNivelSoporte { get; set; }
        public string usuario { get; set; }
        public int asignado { get; set; }
    }
}
