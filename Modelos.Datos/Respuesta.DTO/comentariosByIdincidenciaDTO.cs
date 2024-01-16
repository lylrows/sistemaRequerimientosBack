using System;

namespace Modelos.Datos.Respuesta.DTO
{
    public class comentariosByIdincidenciaDTO
    {
        public int id { get; set; }
        public int idIncidencia { get; set; }
        public string usuario { get; set; }
        public string img { get; set; }
        public string comentario { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}