using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Repositorios.Interfaces.empresas;

namespace Acceso.Datos.Implementacion.Repositorios.empresas
{
    public class tipificacionesEmpresaRepository : Repository<tipificacionesEmpresa>, ITipificacionesempresaRepository
    {
        public tipificacionesEmpresaRepository(string _connectionString) : base(_connectionString)
        {
        }

        public tipificacionByEmpresaDTO getTipificacionByEmpresa(in int id)
        {
            tipificacionByEmpresaDTO tipificaciones = new tipificacionByEmpresaDTO();
            string sql = "[dbo].[getTipificacionByEmpresa]";
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                command.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                adapter.Fill(dataset);
            }

            if (dataset.Tables[0] != null && dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dataset.Tables[0].Rows)
                {
                    tipificaciones.ListTipificacion.Add(SetCategoryTipificacion(item));
                }
            }
            if (dataset.Tables[1] != null && dataset.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow item in dataset.Tables[1].Rows)
                {
                    tipificaciones.ListTipoIncidencias.Add(SetCategoryIncidencias(item));
                }
            }
            return tipificaciones;
        }

        public IEnumerable<empresasByGerenciaDTO> getEmpresasByGerencia()
        {
            var parameters = new DynamicParameters();
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<empresasByGerenciaDTO>("[dbo].[sp_getEmpresasByGerencia]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<soporteByAsignacionDTO> getSoporteByAsignacion()
        {
            var parameters = new DynamicParameters();
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<soporteByAsignacionDTO>("[dbo].[sp_getSoporteByAsignacion]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        private tipoIncidencia SetCategoryIncidencias(DataRow item)
        {
            return new tipoIncidencia
            {
                id = Convert.ToInt32(item["id"].ToString()),
                idEmpresa = Convert.ToInt32(item["idEmpresa"].ToString()),
                idTipoIncidencia = Convert.ToInt32(item["idTipoIncidencia"].ToString()),
                nombre = item["nombre"].ToString()
            };
        }

        private tipificacion SetCategoryTipificacion(DataRow item)
        {
           return new tipificacion
           {
                id = Convert.ToInt32(item["id"].ToString()),
                idEmpresa = Convert.ToInt32(item["idEmpresa"].ToString()),
                idTipificacion = Convert.ToInt32(item["idTipificacion"].ToString()),
                nombre = item["nombre"].ToString()
           };
        }
    }
}
