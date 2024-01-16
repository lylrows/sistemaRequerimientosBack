using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Repositorios.Interfaces.incidencia;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaAsignacionesRepository : Repository<t_incidenciaAsignaciones>, IIncidenciaAsignacionesRepository
    {
        public incidenciaAsignacionesRepository(string _connectionString) : base(_connectionString)
        {
        }

        public void borrarAsignaciones(in int IdIncidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", IdIncidencia);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Query<int>("[dbo].[sp_borrarAsignaciones]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<nivelSoporteDTO> getNivelSoporteById(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<nivelSoporteDTO>("[dbo].[sp_getNivelSoporteById]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public personas getUsuarioASignado(in int objIdIncidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", objIdIncidencia);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<personas>("[dbo].[Incidencia_getUsuarioAsignado]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public personas getUsuarioRegistro(in int objIdIncidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", objIdIncidencia);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<personas>("[dbo].[Incidencia_getUsuarioRegistro]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int objIdIncidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", objIdIncidencia);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<incidenciaDetailsEmailDTO>("[dbo].[sp_getIncidenciaDetaliByEmail]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public int getTicketsPendientes(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>("[dbo].[sp_getTicketsPendientes]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
