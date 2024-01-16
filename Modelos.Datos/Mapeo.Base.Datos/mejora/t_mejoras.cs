using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.mejora
{
    [Table("[mejora].[mejoras]")]
    public class t_mejoras
    {
		[Key]
		public int id					  {get;set;}
        public int idMejora				  {get; set;}
        public int idSistema			  {get;set;}
		public int idTipo				  {get;set;}
		public int prioridad 			  {get;set;}
		public int idUsuarioRegistro 	  {get;set;}
		public int idUsuarioAsignado 	  {get;set;}
		public string titulo 			  {get;set;}
		public string descripcion 		  {get;set;}
		public float horasEstimadas		  {get;set;}
		public float horasConsumidas	  {get;set;}
		public DateTime? fechaRegistro	  {get;set;}
		public DateTime? fechaAtencion	  {get;set;}
		public int idUsuarioCliente		  {get;set;}
		public int idEstado 			  {get;set;}
		public string comentario 		  {get;set;}
		public int? idUsuarioActualiza 	  {get;set;}
		public DateTime? fechaActualiza 	  {get;set;}
		public int esActivo { get; set; }
        public int idEmpresa { get; set; }
    }
}
