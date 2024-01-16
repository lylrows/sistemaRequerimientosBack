using Modelos.Datos.Mapeo.Base.Datos.emision;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.emision
{
    public interface IPedidosarchivosLogic
    {
        bool Update(pedidosArchivos obj);
        int Insert(pedidosArchivos obj);
        IEnumerable<pedidosArchivos> GetList();
        pedidosArchivos GetById(int id);
        bool Delete(pedidosArchivos obj);
        IEnumerable<pedidosArchivos> getByIdPedido(int id);
    }
}
