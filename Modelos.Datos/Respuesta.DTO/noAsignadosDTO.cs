namespace Modelos.Datos.Respuesta.DTO
{
    public class noAsignadosDTO
    {
        public int id { get; set; }
        public string codigoSistema { get; set; }
        public string nombreSistema { get; set; }
        public string descripcion { get; set; }
        public int intervaloAtencion { get; set; }
        public int horasContratadas { get; set; }
    }
}