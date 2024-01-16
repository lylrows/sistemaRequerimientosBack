using Dapper.Contrib.Extensions;
using System;
namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    [Table("[persona].[empresaHorarios]")]
    public class t_empresaHorarios
    {
        public int id                        { get; set; }
        public int idEmpresa             { get; set; }
        public string diasAtencion       { get; set; }
        public DateTime fechaInicio { get; set; }
        public TimeSpan horaInicio       { get; set; }
        public DateTime fechaFin { get; set; }
        public TimeSpan horaFin          { get; set; }
        public int esActivo { get; set; }
    }
}
