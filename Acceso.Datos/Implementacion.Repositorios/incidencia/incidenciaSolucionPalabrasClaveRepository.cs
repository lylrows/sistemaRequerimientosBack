using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Unidad.Trabajo;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciaSolucionPalabrasClaveRepository : Repository<t_incidenciaSolucionPalabrasClave>, IIncidenciaSolucionPalabrasClaveRepository
    {
        public incidenciaSolucionPalabrasClaveRepository(string _connectionString) : base(_connectionString)
        {
        }

        public List<t_incidenciaSolucionPalabrasClave> GetByIdIncSol(int id_incSol)
        {
            List<t_incidenciaSolucionPalabrasClave> incSolPalabras = new List<t_incidenciaSolucionPalabrasClave>();
            SqlConnection conexion = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                /*conn.Open();
                using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaSolPalabras_getByIncSol]", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;


                    var parametro = comando.Parameters.AddWithValue("@idIncidencia", id_incSol);

                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        incSolPalabras.Add(new t_incidenciaSolucionPalabrasClave()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidenciaSolucion = int.Parse(reader["idIncidenciaSolucion"].ToString()!),
                            idPalabraClave = int.Parse(reader["idPalabraClave"].ToString()!),
                        });
                    }
                }
                conn.Close();*/
                return incSolPalabras;
            }
        }
    }
}
