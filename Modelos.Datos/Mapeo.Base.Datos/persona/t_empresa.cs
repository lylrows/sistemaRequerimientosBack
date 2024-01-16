using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    [Table("[persona].[empresas]")]
    public class t_empresa
    {
        public int id                                   { get; set; }
        public int  tipoEmpresa                         { get; set; }
        public int tipoServicio { get; set; }
        public string numeroRUC                         { get; set; }
        public string razonSocial                       { get; set; }
        public string direccion                         { get; set; }
        public string urlWeb                            { get; set; }
        public string nombreContacto                    { get; set; }
        public string emailContacto                     { get; set; }
        public string observacion                       { get; set; }
        public int esActivo { get; set; }
    }
}
