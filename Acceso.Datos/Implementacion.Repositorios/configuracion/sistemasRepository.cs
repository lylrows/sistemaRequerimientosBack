using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class sistemasRepository: Repository<t_sistemas>,ISistemasRepository
    {
        public sistemasRepository(string _connectionString) : base(_connectionString)
        {
        }

        public int validaSistema(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>("[dbo].[sp_validaSistema]", parameters,
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<noAsignadosDTO> getSistemasNoAsociados(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<noAsignadosDTO>("[dbo].[sp_getSistemasNoAsociados]", parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
