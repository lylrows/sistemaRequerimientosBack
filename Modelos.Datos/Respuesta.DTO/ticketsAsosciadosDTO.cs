using System;

namespace Modelos.Datos.Respuesta.DTO
{
    public class ticketsAsosciadosDTO
    {
        public int idIncidencia { get; set; }
        public int idTicket { get; set; }
        public string nombre { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}