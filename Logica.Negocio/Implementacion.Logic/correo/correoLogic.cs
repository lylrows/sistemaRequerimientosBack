using Logica.Negocio.Interfaces.Logic.correo;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.correo
{
    public class correoLogic : ICorreoLogic 
    {
        private IUnitOfWork _unitOfWork;
        public correoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResultadoEnvio enviarCorreo(DatosEmail email, DatosSMTP smtp)
        {
            return _unitOfWork.ICorreo.enviarCorreo(email, smtp);
        }
    }
}
