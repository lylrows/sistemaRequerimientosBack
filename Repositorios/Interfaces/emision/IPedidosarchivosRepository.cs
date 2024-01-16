using Modelos.Datos.Mapeo.Base.Datos.emision;
using Modelos.Datos.Respuesta.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios.Interfaces.emision
{
    public interface IPedidosarchivosRepository : IRepository<pedidosArchivos>
    {
        List<emissionOrdersGrid> getEmissionOrdersGrid();
        List<asignarPedido> getPboUsers(int id);
    }
}
