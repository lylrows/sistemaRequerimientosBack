using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.login;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using Unidad.Trabajo;
using Modelos.Datos.Solicitud.DTO;


namespace Logica.Negocio.Implementacion.Logic.login
{
    public class credencialesLogic : ICredencialesLogic
    {

        private IUnitOfWork _unitOfWork;

        public credencialesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public usuarioResponseDTO LoguearUsuario(CredencialesUsuaroBE usuario)
        {
            return _unitOfWork.ICredenciales.LoguearUsuario(usuario);
        }

       /* public object LoguearUsuario(CredencialesUsuaroBE usuario)
        {
            throw new NotImplementedException();
        }*/
    }
}
