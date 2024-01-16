using Logica.Negocio.Interfaces.Logic.emision;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.emision
{
    public class pedidosRespuestaLogic : IPedidosrespuestaLogic
    {
        private IUnitOfWork _unitOfWork;

        public pedidosRespuestaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public pedidosRespuesta GetById(int id)
        {
            return _unitOfWork.IPedidosrespuesta.GetById(id);
        }

        public IEnumerable<pedidosRespuesta> GetList()
        {
            return _unitOfWork.IPedidosrespuesta.GetList();
        }

        public int Insert(pedidosRespuesta obj)
        {
            return _unitOfWork.IPedidosrespuesta.Insert(obj);
        }

        public bool Update(pedidosRespuesta obj)
        {
            return _unitOfWork.IPedidosrespuesta.Update(obj);
        }

        public bool Delete(pedidosRespuesta obj)
        {
            return _unitOfWork.IPedidosrespuesta.Delete(obj);
        }

        public pedidosRespuesta getByIdPedido(int id)
        {
            var respuestaList = (List<pedidosRespuesta>) _unitOfWork.IPedidosrespuesta.GetList();
            return respuestaList.Find(x => x.idPedido == id);
        }
    }
}
