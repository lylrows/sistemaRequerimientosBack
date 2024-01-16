using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.mejora
{
    public class mejoraComplete
    {
        public int id                                {get;set;}
            public string nombreSistema              {get;set;}
            public int idSistema { get; set; }
            public int idTipo { get; set; }
            public string tipoMejora                 {get;set;}
            public int prioridad                  {get;set;}
            public string usuarioRegistro            {get;set;}
            public string usuarioAsignado            {get;set;}
            public string titulo                     {get;set;}
            public string descripcion                {get;set;}
            public float horasEstimadas              {get;set;}
            public float horasConsumidas             {get;set;}
            public DateTime fechaRegistro            {get;set;}
            public DateTime fechaAtencion            {get;set;}
            public string usuarioCliente             {get;set;}
            public string estadoMejora               {get;set;}
            public int valorEstado { get; set; }
            public string solucion                   {get;set;}
            public string comentario                 {get;set;}
            public string usuarioActualiza           {get;set;}
            public DateTime fechaActualiza           {get;set;}
            public int esActivo                      {get;set;}
            public string empresa                    {get;set;}
            public int idEmpresa { get; set; }
            public int aprobado { get; set; }
        public int idUsuarioRegistro { get; set; }


    }
}
