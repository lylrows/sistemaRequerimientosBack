using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class constantesLogic : IConstantesLogic
    {
        private IUnitOfWork _unitOfWork;

        public constantesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_constantes GetById(int id)
        {
            return _unitOfWork.IConstantes.GetById(id);
        }

        public IEnumerable<t_constantes> GetList()
        {
            return _unitOfWork.IConstantes.GetList();
        }

        public int Insert(t_constantes obj)
        {
            return _unitOfWork.IConstantes.Insert(obj);
        }

        public bool Update(t_constantes obj)
        {
            return _unitOfWork.IConstantes.Update(obj);
        }
    }
}
