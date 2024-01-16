using Logica.Negocio.Interfaces.Logic.emision;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.emision
{
    public class pedidosArchivosLogic : IPedidosarchivosLogic
    {
        private IUnitOfWork _unitOfWork;

        public pedidosArchivosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public pedidosArchivos GetById(int id)
        {
            return _unitOfWork.IPedidosarchivos.GetById(id);
        }
               

        public IEnumerable<pedidosArchivos> GetList()
        {
            return _unitOfWork.IPedidosarchivos.GetList();
        }

        public int Insert(pedidosArchivos obj)
        {
            return _unitOfWork.IPedidosarchivos.Insert(obj);
        }

        public bool Update(pedidosArchivos obj)
        {
            return _unitOfWork.IPedidosarchivos.Update(obj);
        }

        public bool Delete(pedidosArchivos obj)
        {
            return _unitOfWork.IPedidosarchivos.Delete(obj);
        }

        public IEnumerable<pedidosArchivos> getByIdPedido(int id)
        {
            List<pedidosArchivos> pedidosArchivos = new List<pedidosArchivos>();
            pedidosArchivos = (List<pedidosArchivos>)_unitOfWork.IPedidosarchivos.GetList();
            return pedidosArchivos.FindAll( x => x.idPedido == id);
        }
    }
}
