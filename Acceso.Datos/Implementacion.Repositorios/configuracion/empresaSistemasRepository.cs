using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class empresaSistemasRepository:Repository<t_empresaSistemas>,IEmpresaSistemasRepository
    {
        public empresaSistemasRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<sistemasEmpresaDTO> getSistemasByIdEmpresa(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<sistemasEmpresaDTO>("[dbo].[sp_getSistemasByIdEmpresa]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<sistemasByIdUsuarioDTO> getSistemasByIdUsuario(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<sistemasByIdUsuarioDTO>("[dbo].[sp_getSistemasByIdUsuario]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<sistemasPorAsignarUsuarioDTO> getSistemasPorAsignarByIdUsuario(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<sistemasPorAsignarUsuarioDTO>("[dbo].[sp_getSistemasPorAsignarByIdUsuario]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public bool validaUsuarioAsociado(in int idSistema, in int idEmpresa)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", idEmpresa);
            parameters.Add("@idSistema", idSistema);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[sp_validaUsuarioAsociado]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return (result == 1);
        }

        public bool deleteEmpresaSistemas(in int idEmpresa, in int idSistema)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", idEmpresa);
            parameters.Add("@idSistema", idSistema);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[sp_deleteEmpresaSistemas]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return (result == 1);
        }

        public IEnumerable<sistemasEmpresaByUser> getSistemasEmpresaByUser(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<sistemasEmpresaByUser>("[dbo].[sp_getSistemasEmpresaByUser]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
