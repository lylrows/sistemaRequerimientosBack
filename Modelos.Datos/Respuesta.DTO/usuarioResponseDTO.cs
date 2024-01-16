namespace Modelos.Datos.Respuesta.DTO
{
    public class usuarioResponseDTO
    {
        public int id { get; set; }
        public int idPerfil { get; set; }
        public string role { get; set; }
        public string img { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string nroDocumento { get; set; }
        public string razonSocial { get; set; }
        public int idEmpresa { get; set; }
        public int intentosFallidos { get; set; }
        public int primeraVez { get; set; }
        public bool isGerente { get; set; }
        public int idTipoEmision { get; set; }
    }
}