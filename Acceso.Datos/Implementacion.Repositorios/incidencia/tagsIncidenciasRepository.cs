using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Repositorios.Interfaces.incidencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class tagsIncidenciasRepository : Repository<tagsIncidencias>, ITagsincidenciasRepository
    {
        public tagsIncidenciasRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<tags> getTagListByIdIncidencia(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<tags>("[dbo].[sp_getTagListByIdIncidencia]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<tagsIncidenciaDTO> getTagsByIncidencias(filterDataMejorasDTO obj)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechaInicial", obj.fechaInicio.Date);
            parameters.Add("@fechaFinal", obj.fechaFin.Date);
            parameters.Add("@idEmpresa", obj.idEmpresa);
            List<tagsIncidenciaDTO> tagsIncidencias = new List<tagsIncidenciaDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query<dynamic>("[incidencia].[sp_getTagsByIncidencias]", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

                foreach (var row in result)
                {
                    var dto = new tagsIncidenciaDTO
                    {
                        idIncidencia = row.idIncidencia,
                        incidenciaNombre = row.incidenciaNombre,
                        ticketId = row.ticketId,
                        tagIds = ((string)row.tagIds).Split(',').Select(int.Parse).ToList(),
                        tagNames = ((string)row.tagNames).Split(',').ToList(),
                        solucionRaiz = row.solucionRaiz,
                        soporte = row.soporte,
                        cliente = row.cliente,
                        sistema = row.sistema,
                        fechaRegistro = DateTime.Parse(row.fechaRegistro.ToString()),
                    };
                    tagsIncidencias.Add(dto);
                }
            }
            if (obj.solucionRaiz != -1)
            {
                tagsIncidencias = tagsIncidencias.FindAll(x => x.solucionRaiz == obj.solucionRaiz);
            }
            return tagsIncidencias;
        }

    }
}
