using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;

namespace Logica.Negocio.Interfaces.Logic.login
{
    public interface ICredencialesLogic
    {
        usuarioResponseDTO LoguearUsuario(CredencialesUsuaroBE usuario);
    }
}
