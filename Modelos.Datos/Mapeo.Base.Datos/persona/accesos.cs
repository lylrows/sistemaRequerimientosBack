using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    [Table("[persona].[accesos]")]
    public class accesos
    {
        public int id { get; set; }
        public int idPersona { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public int? intentosFallidos { get; set; }
        public DateTime? fechaUltimoLogin { get; set; }
        public int codigoValidacion { get; set; }
        public bool? estaBloqueado { get; set; }
    }
}
