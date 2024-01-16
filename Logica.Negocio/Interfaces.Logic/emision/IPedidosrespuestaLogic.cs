using Modelos.Datos.Mapeo.Base.Datos.emision;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.emision
{
    public interface IPedidosrespuestaLogic
    {
        bool Update(pedidosRespuesta obj);
        int Insert(pedidosRespuesta obj);
        IEnumerable<pedidosRespuesta> GetList();
        pedidosRespuesta GetById(int id);
        bool Delete(pedidosRespuesta obj);
        pedidosRespuesta getByIdPedido(int id);
    }
}
