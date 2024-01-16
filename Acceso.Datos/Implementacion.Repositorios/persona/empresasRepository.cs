using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.persona;

namespace Acceso.Datos.Implementacion.Repositorios.persona
{
    public class empresasRepository : Repository<t_empresa>, IEmpresasRepository
    {
        public empresasRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<t_empresa> getEmpresaByIdUsuario(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<t_empresa>("[dbo].[sp_getEmpresaByIdUsuario]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
