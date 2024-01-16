using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class modificarActivoLogic:IModificarActivoLogic
    {
        private IUnitOfWork _unitOfWork;

        public modificarActivoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public modificacionActivoDTO ModificarActivo(string tabla, int valor, int id)
        {
            return _unitOfWork.IModificacionActivo.ModificarActivo(tabla, valor, id);
        }
    }
}
