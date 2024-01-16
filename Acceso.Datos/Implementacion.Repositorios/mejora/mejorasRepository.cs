using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.mejora;
using Modelos.Datos.Solicitud.DTO;
using Repositorios.Interfaces.mejoras;

namespace Acceso.Datos.Implementacion.Repositorios.mejora
{
    public class mejorasRepository : Repository<t_mejoras>, IMejorasRepository
    {
        public mejorasRepository(string _connectionString) : base(_connectionString)
        {

        }

        public List<usuariosAsignar> obtenerUsuariosParaAsignarByMejora(in int idMejora)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", idMejora);
            /*string sql = "SELECT " +
                         "idUsuario, " +
                         "idNivelSoporte, " +
                         "pp.nombres + ' ' + pp.apellidos as usuario " +
                         "FROM [incidencia].[incidencias] inc " +
                         "    INNER JOIN [configuracion].[empresaSistemaUsuarios] usu " +
                         "    ON inc.idEmpSist = usu.idEmpresaSistemas " +
                         "    INNER JOIN [persona].[personas] pp " +
                         "    ON usu.idUsuario = pp.id " +
                         "WHERE inc.id = " + idIncidencia +
                         " ORDER BY idNivelSoporte";*/
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<usuariosAsignar>)connection.Query<usuariosAsignar>("[dbo].[sp_obtenerUsuariosParaAsignarByMejora]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<mejoraGridListDTO> obtenerMejoraPorIdUsuario(filterDataDTO obj)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idUsuario", obj.idUser);
            parameters.Add("@fechaInicio", obj.fechaInicio.ToString("yyyy-MM-dd"));
            parameters.Add("@fechaFin", obj.fechaFin.ToString("yyyy-MM-dd"));
            parameters.Add("@idEmp", obj.idEmpresa);
            using (var connection = new SqlConnection(_connectionString))
            {
                var GridList = (List<mejoraGridListDTO>) connection.Query<mejoraGridListDTO>("[dbo].[sp_getMejoraGridList]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (obj.estados.Count > 0)
                {
                    GridList = GridList.Where(mejora => obj.estados.Contains(mejora.idEstadoMejora)).ToList();
                }
                return GridList;
            }
        }
        public List<mejoraComplete> obtenerMejoraPorIdClienteEmpresa(int idUsuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idUsuario", idUsuario);
            using (var connection = new SqlConnection(_connectionString))
            {
                var lista_sp = (List<mejoraComplete>)connection.Query<mejoraComplete>("[mejora].[mejora_getByIdClienteEmp]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return lista_sp;
            }
        }

        public List<ticketsAsosciadosDTO> getTicketsAsosciados(ticketsAsosciadosFilter obj)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", obj.idEmpresa);
            parameters.Add("@idSistema", obj.idSistema);
            using (var connection = new SqlConnection(_connectionString))
            {
                return  (List<ticketsAsosciadosDTO>)connection.Query<ticketsAsosciadosDTO>("[dbo].[sp_getTicketsAsosciados]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                 
            }
        }

        public List<string> getManagerEmailsById(int idEmpresa, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", idEmpresa);
            parameters.Add("@idGerente", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<string>) connection.Query<string>("[dbo].[sp_getManagerEmailsById]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public approverUserData getApproverUserDataById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return  connection.Query<approverUserData>("[dbo].[sp_getApproverUserDataById]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public List<string> getBpoEmailsById(int idEmpresa, int? idUsuarioRegistro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", idEmpresa);
            parameters.Add("@idUsuarioRegistro", idUsuarioRegistro);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<string>)connection.Query<string>("[dbo].[sp_getBpoEmailsById]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
