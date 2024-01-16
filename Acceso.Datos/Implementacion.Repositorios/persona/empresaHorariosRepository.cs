using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.persona;

namespace Acceso.Datos.Implementacion.Repositorios.persona
{
    public class empresaHorariosRepository : Repository<t_empresaHorarios>, IEmpresaHorariosRepository
    {
        public empresaHorariosRepository(string _connectionString) : base(_connectionString)
        {
        }

        public horarioEmpresaListDTO getHorarioEmpresaList(in int id)
        {
            horarioEmpresaListDTO horarioEmpresaList = new horarioEmpresaListDTO();
            diasAtencion dia = new diasAtencion();
            dia.dia = "Lunes";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            dia = new diasAtencion();
            dia.dia = "Martes";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            dia = new diasAtencion();
            dia.dia = "Miércoles";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            dia = new diasAtencion();
            dia.dia = "Jueves";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            dia = new diasAtencion();
            dia.dia = "Viernes";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            dia = new diasAtencion();
            dia.dia = "Sábado";
            dia.@checked = false;
            horarioEmpresaList.dias.Add(dia);
            empresaHorarioDTO horarioDTO = new empresaHorarioDTO();
            List<string> dias = new List<string>();
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                horarioDTO = connection.Query<empresaHorarioDTO>("[dbo].[sp_getHorarioEmpresaList]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            if (horarioDTO != null)
            {
                diasAtencion findDia = new diasAtencion();
                dias = new List<string>(horarioDTO.diasAtencion.Split(';'));
                foreach (var dd in dias)
                {
                    findDia = new diasAtencion();
                    findDia = horarioEmpresaList.dias.Find(x => x.dia == dd);
                    if (findDia != null)
                    {
                        foreach (var diasAtencion in horarioEmpresaList.dias)
                        {
                            if (diasAtencion.dia == findDia.dia)
                            {
                                diasAtencion.@checked = true;
                                break;
                            }
                        }
                    }
                }

                horarioEmpresaList.fechaInicio = horarioDTO.fechaInicio;
                horarioEmpresaList.fechaFin = horarioDTO.fechaFin;
                horarioEmpresaList.idHorario = horarioDTO.idHorario;
            }
            return horarioEmpresaList;
        }
    }
}
