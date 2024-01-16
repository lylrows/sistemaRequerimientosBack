using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.configuracion;

namespace Acceso.Datos.Implementacion.Repositorios.configuracion
{
    public class menuRepository : Repository<t_menu>, IMenuRepository
    {
        public menuRepository (string _connectionString) : base(_connectionString)
        {
        }

        public getByIdRoleDTO GetByIdRole(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<getByIdRoleDTO>("[configuracion].[menu_getByIdRole_select]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
