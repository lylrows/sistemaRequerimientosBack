using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using Repositorios.Interfaces.login;

namespace Acceso.Datos.Implementacion.Repositorios.login
{
    public class credencialesRepository : Repository<CredencialesUsuaroBE>, ICredencialesRepository
    {
        public credencialesRepository(string _connectionString) : base(_connectionString)
        {
        }

        public usuarioResponseDTO LoguearUsuario(CredencialesUsuaroBE usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@usuario", usuario.usuario);
            parameters.Add("@contrasenia", usuario.contrasenia);
            //parameters.Add("@idPerfil", usuario.idPerfil);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<usuarioResponseDTO>("[dbo].[sp_login_v2]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
