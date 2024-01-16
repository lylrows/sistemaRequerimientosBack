using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;

namespace Repositorios.Interfaces.login
{
    public interface ICredencialesRepository : IRepository<CredencialesUsuaroBE>
    {
        usuarioResponseDTO LoguearUsuario(CredencialesUsuaroBE usuario);
    }
}
