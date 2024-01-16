using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.persona;

namespace Acceso.Datos.Implementacion.Repositorios.persona
{
    public class personasRepository : Repository<personas>, IT_personasRepository
    {
        public personasRepository(string _connectionString) : base(_connectionString)
        {
        }

        public getNombresDTO GetNombres(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<getNombresDTO>("[persona].[personas_nombres_select]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public int InsertUser(personas obj, string contrasenia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerfil", obj.idPerfil);
            parameters.Add("@idEmpresa ", obj.idEmpresa);
            parameters.Add("@nombres ", obj.nombres);
            parameters.Add("@apellidos", obj.apellidos);
            parameters.Add("@email ", obj.email);
            parameters.Add("@tipoDocumento", obj.tipoDocumento);
            parameters.Add("@nroDocumento", obj.nroDocumento);
            parameters.Add("@direccion", obj.direccion);
            parameters.Add("@telefono", obj.telefono);
            parameters.Add("@celular", obj.celular);
            parameters.Add("@img ", obj.img);
            parameters.Add("@contrasenia", contrasenia);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>("[persona].[personas_insert]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<personas> getUsuariosByEmpresa(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<personas>("[dbo].[sp_getUsuariosByEmpresa]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<usuariosByEmpresaDTO> getUsersByIdEmpresa(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<usuariosByEmpresaDTO>("[dbo].[sp_getUsuariosByEmpresa]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
