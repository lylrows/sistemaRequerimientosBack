using System.Collections.Generic;

namespace Modelos.Datos.Solicitud.DTO
{
    public class tagsObjDTO
    {
        public int id { get; set; }
        public int idIncidenciaSolucion { get; set; }
        public int idPalabraClave { get; set; }
        public List<Tag> tags { get; set; }

        public tagsObjDTO()
        {
            tags = new List<Tag>();
        }
    }

    public class Tag
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}