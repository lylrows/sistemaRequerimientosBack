using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Repositorios.Interfaces.persona;

namespace Acceso.Datos.Implementacion.Repositorios.persona
{
    public class empresaANSRepository : Repository<t_empresaANS>, IEmpresaANSRepository
    {
        public empresaANSRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<t_empresaANS> getANSByIdEmpresa(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<t_empresaANS>("[dbo].[sp_getANSByIdEmpresa]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<incidenciaHorariosDTO> getIncidenciaHorarios()
        {
            var parameters = new DynamicParameters();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<incidenciaHorariosDTO>("[dbo].[sp_getIncidenciaHorariosDTO]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public DateTime CalcularFechaMaximaDeAtencion(incidenciaHorariosDTO Dto, DateTime fechaHoraInicio,
             DateTime fechaHoraFin, DateTime fechaIngresoMaximo)
        {
            DateTime fechaMaximaDeAtencion = DateTime.MinValue;
            /*DateTime[] feriadosPeru = {
            new DateTime(2023, 1, 1),  
            new DateTime(2023, 4, 14), 
            new DateTime(2023, 4, 16), 
            new DateTime(2023, 5, 1),  
            new DateTime(2023, 6, 29), 
            new DateTime(2023, 7, 28), 
            new DateTime(2023, 7, 29), 
            new DateTime(2023, 8, 30), 
            new DateTime(2023, 10, 8), 
            new DateTime(2023, 12, 8), 
            new DateTime(2023, 12, 25) 
            };*/
            fechaHoraInicio = Dto.fechaRegistro.Date + Dto.horaInicio;
            fechaHoraFin = Dto.fechaRegistro.Date + Dto.horaFin;
            fechaIngresoMaximo = Dto.fechaRegistro.Date + Dto.ingresoMaximo;
            int refrigerio = 0;
            DayOfWeek diaDeLaSemana = Dto.fechaRegistro.DayOfWeek;
            bool esViernes = diaDeLaSemana == DayOfWeek.Friday;
            double horasRestantesDelDia = 0;
            if (Dto.fechaRegistro > fechaHoraFin || Dto.fechaRegistro > fechaIngresoMaximo)
            {
                Dto.fechaRegistro = Dto.fechaRegistro.AddDays(1).Date.AddHours(Dto.horaInicio.TotalHours);
                fechaHoraFin = fechaHoraFin.AddDays(1);
            }
            else if (Dto.fechaRegistro < fechaHoraInicio)
            {
                Dto.fechaRegistro = Dto.fechaRegistro.Date.AddHours(Dto.horaInicio.TotalHours);
            }
            else
            {
                TimeSpan tm = fechaHoraFin.Subtract(Dto.fechaRegistro);
                horasRestantesDelDia = tm.TotalHours;
            }
            DateTime fechaTiempoMaximoAtencion = Dto.fechaRegistro.AddHours(Dto.tiempoMaximoAtencion);
            if (Dto.tiempoMaximoAtencion <= 8)
            {
                if (fechaTiempoMaximoAtencion > fechaHoraFin)
                {
                    fechaMaximaDeAtencion = Dto.fechaRegistro.AddDays(1).Date.AddHours(
                        (Dto.tiempoMaximoAtencion - horasRestantesDelDia) + Dto.horaInicio.TotalHours);
                }
                else
                {
                    fechaMaximaDeAtencion = fechaTiempoMaximoAtencion;
                }

                /*if (esViernes)
                {
                    fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(2);
                }*/
            }
            else
            {
                double horasRestantes = 0;
                if (Dto.fechaRegistro > fechaHoraInicio)
                {
                    horasRestantes = Dto.tiempoMaximoAtencion - horasRestantesDelDia;
                }
                else
                {
                    horasRestantes = Dto.tiempoMaximoAtencion - 8;
                    refrigerio++;
                }   

                while (horasRestantes > 8)
                {
                    Dto.fechaRegistro = Dto.fechaRegistro.AddDays(1);
                    horasRestantes -= 8;
                    refrigerio++;
                }

                fechaMaximaDeAtencion = Dto.fechaRegistro.AddDays(1).Date.AddHours(horasRestantes + Dto.horaInicio.TotalHours + refrigerio);

                /*if (esViernes)
                {
                    fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(2);
                }*/
            }

            if (fechaTiempoMaximoAtencion.TimeOfDay >= new TimeSpan(13, 0, 0) && Dto.fechaRegistro.TimeOfDay < new TimeSpan(14, 0, 0))
            {
                fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddHours(1);
            }

            // verificar el día de la semana
            if (fechaMaximaDeAtencion.DayOfWeek == DayOfWeek.Saturday)
            {
                fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(2);
            }
            else if (fechaMaximaDeAtencion.DayOfWeek == DayOfWeek.Sunday)
            {
                fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(1);
            }
            /*if (fechaMaximaDeAtencion.DayOfWeek == DayOfWeek.Friday)// && Array.IndexOf(feriadosPeru, fechaMaximaDeAtencion) >= 0)
            {
                fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(2);
            }*/
            /*else
            {
                fechaMaximaDeAtencion = fechaMaximaDeAtencion.AddDays(1);
            }*/

            return fechaMaximaDeAtencion;
        }

        public bool updateFechaTiempoMaximoAtencion(in DateTime fechaTiempoMaximoAtencion, int dtoId)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@id", dtoId);
            parameters.Add("@fechaTiempoMaximoAtencion", fechaTiempoMaximoAtencion);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[sp_updateFechaTiempoMaximoAtencion]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return result > 0;
        }

        public incidenciaHorariosDTO getIncidenciaHorarioById(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<incidenciaHorariosDTO>("[dbo].[sp_getIncidenciaHorariosById]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool cambioAnsDescartado(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[sp_cambioAnsDescartado]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return result == 1;
        }
    }
}
