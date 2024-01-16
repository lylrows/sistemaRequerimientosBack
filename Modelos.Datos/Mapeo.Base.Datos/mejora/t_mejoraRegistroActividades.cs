using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.mejora
{
    [Table("[mejora].[mejoraRegistroActividades]")]
    public class t_mejoraRegistroActividades
    {
		[Key]
		public int id		   {get;set;}
	 public int idMejora 			   {get;set;}
	 public decimal horasActividad 		   {get;set;}
	public string descripcion 		   {get;set;}
	public int idUsuarioRegistro	   {get;set;}
	public DateTime	fechaActividad 	   {get;set;}
	 public int? idUsuarioActualiza	   {get;set;}
	public DateTime? fechaActualiza	   {get;set;}
	 public int esActivo { get; set; }
	}
}
