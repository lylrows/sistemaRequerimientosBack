using System;

namespace Modelos.Datos.Respuesta.DTO
{
    public class incidenciaHorariosDTO
    {
        public int id { get; set; }
        public DateTime fechaRegistro { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public TimeSpan ingresoMaximo { get; set; }
        public int tiempoMaximoAtencion { get; set; }
        public int idPrioridad { get; set; }
    }
}