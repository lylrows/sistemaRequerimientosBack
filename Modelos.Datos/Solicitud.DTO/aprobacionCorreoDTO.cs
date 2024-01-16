using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO
{
    public class aprobacionCorreoDTO
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public List<string> emailToList { get; set; }
        public string comentario { get; set; }

        public aprobacionCorreoDTO()
        {
            emailToList = new List<string>();
        }
    }
}
