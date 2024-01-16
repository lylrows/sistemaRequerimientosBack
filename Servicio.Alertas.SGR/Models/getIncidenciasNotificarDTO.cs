using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Alertas.SGR.Models
{
    public class getIncidenciasNotificarDTO
    {
        public int id { get; set; }
        public string reportadoPor         {get;set;}
        public string usuario { get; set; }
        public DateTime fechaRegistro        {get;set;}
    }
}
