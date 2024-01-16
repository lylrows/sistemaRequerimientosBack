using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    public class ResultadoEnvio
    {
        public bool FueExitoso { get; set; }
        public string MensajeError { get; set; }
        public string DetalleAdjuntosEnviados { get; set; }
        public string DestinatariosPara { get; set; }
        public string DestinatariosConCopia { get; set; }
        public string DestinatariosConCopiaOculta { get; set; }
    }
}
