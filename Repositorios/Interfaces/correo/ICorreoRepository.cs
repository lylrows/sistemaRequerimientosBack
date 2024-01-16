using Modelos.Datos.Mapeo.Base.Datos.correo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios.Interfaces.correo
{
    public interface ICorreoRepository
    {
        public ResultadoEnvio enviarCorreo(DatosEmail email, DatosSMTP smtp);
    }
}
