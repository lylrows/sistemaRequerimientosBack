using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class tagsIncidenciaDTO
    {
        public int idIncidencia { get; set; }
        public string incidenciaNombre { get; set; }
        public int ticketId { get; set; }
        public List<int> tagIds { get; set; }
        public List<string> tagNames { get; set; }
        public int solucionRaiz { get; set; }
        public string soporte { get; set; }
        public string cliente { get; set; }
        public string sistema { get; set; }
        public DateTime fechaRegistro { get; set; }
        public tagsIncidenciaDTO()
        {
            tagIds = new List<int>();
            tagNames = new List<string>();
        }
    }
}
