namespace Modelos.Datos.Respuesta.DTO
{
    public class sistemasEmpresaDTO
    {
        public int idSistema { get; set; }
        public string codigoSistema { get; set; }
        public string nombreSistema { get; set; }
        public string descripcion { get; set; }
        public int tipoSistema { get; set; }
        public string tipoSistemaNombre { get; set; }
        public int horasContratadas { get; set; }
        public string descripcionTipoSistema { get; set; }
        public decimal intervaloAtencion { get; set; }
        public int esActivo { get; set; }
        public int idEmpresaSistema { get; set; }
    }
}