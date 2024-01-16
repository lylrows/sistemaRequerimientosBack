using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Repositorios.Interfaces.incidencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaSolucionRepository : Repository<t_incidenciaSolucion>, IIncidenciaSolucionRepository
    {
        public incidenciaSolucionRepository(string _connectionString) : base(_connectionString) { }
        public List<incidenciaSolucion_complete> getIncidenciaSolucionesFilter(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<incidenciaSolucion_complete>)connection.Query<incidenciaSolucion_complete>("[dbo].[IncidenciaSol_getFilter]",parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public List<incidenciaSolTagFilterResponse> getIncidenciasSolucionesByTagFilter(List<palabrasClave_tag> req)
        {
            List<incidenciaSolTagFilterResponse> incidencia = new List<incidenciaSolTagFilterResponse>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                
                //DT
                DataTable palabrasClave = new DataTable();
                palabrasClave.Columns.Add("tag");

                for(var i =0;i<req.Count();i++)
                {
                    DataRow row = palabrasClave.NewRow();
                    row["tag"] = req[i].tag;

                    palabrasClave.Rows.Add(row);
                    palabrasClave.AcceptChanges();
                }
                //
                try
                {
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand("[dbo].[incidenciaSol_getTagFilter_select_v2]", conn))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        var parametro = comando.Parameters.AddWithValue("@List", palabrasClave);
                        parametro.SqlDbType = SqlDbType.Structured;
                        parametro.TypeName = "[dbo].[palabras_clave_tag]";

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                incidencia.Add(new incidenciaSolTagFilterResponse()
                                {
                                    idIncidencia = reader.GetInt32(reader.GetOrdinal("idIncidencia")),
                                    idSolucion = reader.GetInt32(reader.GetOrdinal("idSolucion")),
                                    idTicket = reader.GetInt32(reader.GetOrdinal("idTicket")),
                                    titulo = reader.GetString(reader.GetOrdinal("titulo")),
                                    empresa = reader.GetString(reader.GetOrdinal("empresa")),
                                    sistema = reader.GetString(reader.GetOrdinal("sistema")),                                    
                                    nombreIncidencia = reader.GetString(reader.GetOrdinal("nombreIncidencia")),                                    
                                    tipificacion = reader.GetString(reader.GetOrdinal("tipificacion")),
                                    prioridad = reader.GetString(reader.GetOrdinal("prioridad")),
                                    solucion = reader.GetString(reader.GetOrdinal("solucion")),
                                    
                                });
                            }
                        }
                    }
                    conn.Close();
                }
                catch(Exception e)
                {

                }
                
            }
            return incidencia;
        }
        public List<incidenciaSolTagFilterResponse> getIncidenciasSolucionesAll()
        {
            List<incidenciaSolTagFilterResponse> incidencia = new List<incidenciaSolTagFilterResponse>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        incidencia = (List<incidenciaSolTagFilterResponse>)connection.Query<incidenciaSolTagFilterResponse>("[dbo].[tag_debug_select]", commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
                catch (Exception e)
                {

                }

            }
            return incidencia;
        }

        public solucionDTO getSolutionById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<solucionDTO>("[dbo].[sp_getSolutionById]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<solutionImgDTO> getSolutionImg(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<solutionImgDTO>)connection.Query<solutionImgDTO>("[dbo].[sp_getSolutionImg]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        /*public incidenciaSolArchivosPalabras getIncidenciaArchivosComentariosxIncidencia(int id)
        {
            List<t_incidenciaSolucionPalabrasClave> palabras = new List<t_incidenciaSolucionPalabrasClave>();
            List<t_incidenciaSolucionArchivos> archivos = new List<t_incidenciaSolucionArchivos>();
            t_incidenciaSolucion incidenciaSol = new t_incidenciaSolucion();
            SqlConnection conexion = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                incidenciaSol = connection.Query<t_incidenciaSolucion>("[dbo].[IncidenciaSol_getxId]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaComentarios_getxIncidencia]", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;


                    var parametro = comando.Parameters.AddWithValue("@idIncidencia", id);
                    //parametro.SqlDbType = SqlDbType.Structured;

                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        comentarios.Add(new t_incidenciaComentarios()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                            idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                            comentario = reader["comentario"].ToString()!
                        });
                    }
                }
                conn.Close();
                conn.Open();
                using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaArchivos_getxIncidencia]", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;


                    var parametro = comando.Parameters.AddWithValue("@idIncidencia", id);

                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        archivos.Add(new t_incidenciaArchivos()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                            idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                            urlArchivo = reader["urlArchivo"].ToString()!,
                            nombreArchivo = reader["nombreArchivo"].ToString()!,
                        });
                    }
                }
                conn.Close();
            }
            GetIncidenciaArchivosComentarios rpta = new GetIncidenciaArchivosComentarios();

            rpta.incidencia = incidencia;
            rpta.lstComentarios = comentarios;
            rpta.lstArchivos = archivos;

            return rpta;
        }*/
    }
}
