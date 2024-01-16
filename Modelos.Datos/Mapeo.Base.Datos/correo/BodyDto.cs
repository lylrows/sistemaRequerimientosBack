using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.correo
{
    public class BodyDto
    {
        public EnumBodyMail Format { get; set; }
        public string Value { get; set; }
    }
}
