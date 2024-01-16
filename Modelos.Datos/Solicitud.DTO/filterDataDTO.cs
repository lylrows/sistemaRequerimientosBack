using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO
{
    public class filterDataDTO
    {
        public int idUser { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEmpresa { get; set; }
        public List<int> estados { get; set; }
    }
}
