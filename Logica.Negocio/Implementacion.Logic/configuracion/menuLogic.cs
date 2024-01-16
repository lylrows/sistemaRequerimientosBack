using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class menuLogic : IMenuLogic
    {
        private IUnitOfWork _unitOfWork;

        public menuLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_menu GetById(int id)
        {
            return _unitOfWork.IMenu.GetById(id);
        }

        public IEnumerable<t_menu> GetList()
        {
            return _unitOfWork.IMenu.GetList();
        }

        public int Insert(t_menu obj)
        {
            return _unitOfWork.IMenu.Insert(obj);
        }

        public bool Update(t_menu obj)
        {
            return _unitOfWork.IMenu.Update(obj);
        }

        public bool Delete(t_menu obj)
        {
            return _unitOfWork.IMenu.Delete(obj);
        }

        public getByIdRoleDTO GetByIdRole(int id)
        {
            return _unitOfWork.IMenu.GetByIdRole(id);
        }
    }
}
