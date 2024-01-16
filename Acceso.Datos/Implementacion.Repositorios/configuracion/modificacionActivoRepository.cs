using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class modificacionActivoRepository : Repository<modificacionActivoDTO>, IModificacionActivoRepository
    {
        public modificacionActivoRepository(string _connectionString) : base(_connectionString)
        {
        }

        public modificacionActivoDTO ModificarActivo(string tabla, int valor,int id)
        {
            var parameters = new DynamicParameters();
            modificacionActivoDTO modf = new modificacionActivoDTO();
            string query = "UPDATE " + tabla + " set esActivo = " + valor + " where id=" + id + " SELECT @@ROWCOUNT";
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query<int>(query, parameters, commandType: System.Data.CommandType.Text).FirstOrDefault();
                modf.result = result == 1 ? true : false;
            }
            return modf;
        }
    }
}
