using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class solucionDTORequest
    {
        public int idTipoSolucion                        {get;set;}
		public int idTipificacion                          {get;set;}
		public List<palabrasClave_tag> palabrasClaves { get; set; }
    }
}
