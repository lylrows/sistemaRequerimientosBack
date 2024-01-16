using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.incidencia;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaComentariosRepository : Repository<t_incidenciaComentarios>, IIncidenciaComentariosRepository
    {
        public incidenciaComentariosRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<comentariosByIdincidenciaDTO> getComentariosByIdincidencia(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<comentariosByIdincidenciaDTO>("[dbo].[sp_getComentariosByIdincidencia]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
