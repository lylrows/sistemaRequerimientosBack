using Modelos.Datos.Mapeo.Base.Datos.emision;
using Repositorios.Interfaces.emision;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.emision
{
    public class pedidosRepository : Repository<pedidos>, IPedidosRepository
    {
        public pedidosRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
