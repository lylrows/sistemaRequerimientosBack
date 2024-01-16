using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Modelos.Datos.Mapeo.Base.Datos.correo
{
    public class DatosEmail
    {
        public MailAddress De { get; set; }
        public List<string> Para { get; set; }
        public List<string> ConCopia { get; set; }
        public List<string> ConCopiaOculta { get; set; }
        public string Titulo { get; set; }
        public BodyDto Mensaje { get; set; }
        public List<string> Adjuntos { get; set; }

        public DatosEmail()
        {
            De = new MailAddress("notificaciones@efitec-corp.com");
            Para = new List<string>();
            ConCopia = new List<string>();
            ConCopiaOculta = new List<string>();
            Titulo = "";
            Mensaje = new BodyDto() ;
            Adjuntos = new List<string>();
        }
    }
}
