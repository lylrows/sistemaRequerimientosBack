using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaByMonthYearEmp
    {
        public int idEmpresa      {get;set;}
            public int mesInicio  {get;set;}
            public int mesFin     {get;set;}
            public int anio { get; set; }
    }
}
