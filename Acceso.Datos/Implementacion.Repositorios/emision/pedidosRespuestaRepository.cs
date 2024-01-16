using Modelos.Datos.Mapeo.Base.Datos.emision;
using Repositorios.Interfaces.emision;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.emision
{
    public class pedidosRespuestaRepository : Repository<pedidosRespuesta>, IPedidosrespuestaRepository
    {
        public pedidosRespuestaRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}
