using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.emision;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.emision;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.emision
{
    public class pedidosArchivosRepository : Repository<pedidosArchivos>, IPedidosarchivosRepository
    {
        public pedidosArchivosRepository(string _connectionString) : base(_connectionString)
        {
        }

        public List<emissionOrdersGrid> getEmissionOrdersGrid()
        {
            var parameters = new DynamicParameters();
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<emissionOrdersGrid>) connection.Query<emissionOrdersGrid>("[dbo].[sp_getEmissionOrdersGrid]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<asignarPedido> getPboUsers(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<asignarPedido>)connection.Query<asignarPedido>("[dbo].[sp_getPboUsers]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
