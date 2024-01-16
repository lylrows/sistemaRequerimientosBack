using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Mapeo.Base.Datos.correo;

namespace Logica.Negocio.Interfaces.Logic.correo
{
    public interface ICorreoLogic
    {
        public ResultadoEnvio enviarCorreo(DatosEmail email, DatosSMTP smtp);
    }
}
