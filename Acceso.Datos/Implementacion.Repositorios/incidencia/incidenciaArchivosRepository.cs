using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Repositorios.Interfaces.incidencia;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaArchivosRepository : Repository<t_incidenciaArchivos>, IIncidenciaArchivosRepository
    {
        public incidenciaArchivosRepository(string _connectionString) : base(_connectionString)
        {
            
        }
        public List<incidenciaArchivos_complete> getArchivosByIncidencia(int id)
        {
            SqlConnection conexion = new SqlConnection(_connectionString);
            List<incidenciaArchivos_complete> archivos = new List<incidenciaArchivos_complete>();
            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<incidenciaArchivos_complete>)connection.Query<incidenciaArchivos_complete>("[dbo].[IncidenciaArchivos_getxIncidencia]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
}
