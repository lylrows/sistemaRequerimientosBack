using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaSolucionArchivosRepository : Repository<t_incidenciaSolucionArchivos>, IIncidenciaSolucionArchivosRepository
    {
        public incidenciaSolucionArchivosRepository(string _connectionString) : base(_connectionString)
        {
        }

        public List<t_incidenciaSolucionArchivos> GetByIdIncSol(int id_incSol)
        {
            List<t_incidenciaSolucionArchivos> incSolArchivos = new List<t_incidenciaSolucionArchivos>();
            SqlConnection conexion = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaSolArchivos_getByIncSol]", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;


                    var parametro = comando.Parameters.AddWithValue("@idIncidencia", id_incSol);

                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        incSolArchivos.Add(new t_incidenciaSolucionArchivos()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidenciaSolucion = int.Parse(reader["idIncidenciaSolucion"].ToString()!),
                            idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                            urlArchivo = reader["urlArchivo"].ToString()!,
                            nombreArchivo = reader["nombreArchivo"].ToString()!
                        });
                    }
                }
                conn.Close();
                return incSolArchivos;
            }
        }
    }
}
