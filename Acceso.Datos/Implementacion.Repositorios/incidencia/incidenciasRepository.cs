using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Repositorios.Interfaces.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using Unidad.Trabajo;
using Logica.Negocio.Implementacion.Logic.incidencia;
using System.Linq;
using System;
using System.Data;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using System.Net.Mail;
using System.IO;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Solicitud.DTO.incidencia;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Repositorios.Interfaces.configuracion;
using Modelos.Datos.Utils;
using Modelos.Datos.Solicitud.DTO;
using Logica.Negocio.Interfaces.Logic.empresas;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Repositorios.Interfaces.empresas;

namespace Acceso.Datos.Implementacion.Repositorios.incidencia
{
    public class incidenciasRepository : Repository<t_incidencias>, IIncidenciasRepository
    {
        private IUnitOfWork _unitOfWork;
        private IParametroDetallesRepository parametroDetalles;
        private ITipificacionesempresaRepository _tipificacionesempresa;

        public incidenciasRepository(string _connectionString, IParametroDetallesRepository parametroDetalles, ITipificacionesempresaRepository tipificacionesempresa) : base(_connectionString)
        {
            this.parametroDetalles = parametroDetalles;
            _tipificacionesempresa = tipificacionesempresa;
        }

        public incidenciaArchivosComentarios_complete getIncidenciaArchivosComentariosxIncidencia(int id)
        {
            List<incidenciaComentarios_complete> comentarios = new List<incidenciaComentarios_complete>();
            List<incidenciaArchivos_complete> archivos = new List<incidenciaArchivos_complete>();
            incidencia_getComplete incidencia = new incidencia_getComplete();
            SqlConnection conexion = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                incidencia = connection.Query<incidencia_getComplete>("[dbo].[Incidencia_getxId]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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
                        comentarios.Add(new incidenciaComentarios_complete()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                            idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                            comentario = reader["comentario"].ToString()!,
                            usuario = reader["usuario"].ToString()!,
                            fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro"))
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
                        archivos.Add(new incidenciaArchivos_complete()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                            idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                            urlArchivo = reader["urlArchivo"].ToString()!,
                            nombreArchivo = reader["nombreArchivo"].ToString()!,
                            usuario = reader["usuario"].ToString()!,
                            fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro"))
                        });
                    }
                }
                conn.Close();
            }
            incidenciaArchivosComentarios_complete rpta = new incidenciaArchivosComentarios_complete();

            rpta.incidencia = incidencia;
            rpta.lstComentarios = comentarios;
            rpta.lstArchivos = archivos;

            return rpta;
        }

        public List<usuariosAsignar> obtenerUsuariosParaAsignar(in int idIncidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", idIncidencia);
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
                return (List<usuariosAsignar>) connection.Query<usuariosAsignar>("[dbo].[sp_obtenerUsuariosParaAsignar]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<incidenciasGridDTO> getIncidenciasByRolAndUsuarioid(string rol, in int id, int idNivel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@role", rol);
            parameters.Add("@id", id);
            parameters.Add("@idNivel", idNivel);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<incidenciasGridDTO>("[dbo].[sp_getIncidenciasByRolAndUsuarioid]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<incidenciaComentariosArchivos_getCompleteFilter> getIncidenciasArchivosComentariosFilter()
        {
            List<incidenciaComentariosArchivos_getCompleteFilter> incidencia = new List<incidenciaComentariosArchivos_getCompleteFilter>();
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand("[dbo].[Incidencia_getFilter]", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        incidencia.Add(new incidenciaComentariosArchivos_getCompleteFilter()
                        {
                            id = int.Parse(reader["id"].ToString()!),
                            idEmpSist = int.Parse(reader["idEmpSist"].ToString()!),
                            nombreSistema = reader["nombreSistema"].ToString()!,
                            idSubtipoIncidencia = int.Parse(reader["idSubtipoIncidencia"].ToString()!),
                            subtipoIncidencia = reader["subtipoIncidencia"].ToString()!,
                            idUsuarioRegistro = int.Parse(reader["idUsuarioRegistro"].ToString()!),
                            usuarioRegistro = reader["usuarioRegistro"].ToString()!,
                            idTipoIncidencia = int.Parse(reader["idTipoIncidencia"].ToString()!),
                            tipoIncidencia = reader["tipoIncidencia"].ToString()!,
                            nombreIncidencia = reader["nombreIncidencia"].ToString()!,
                            fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro")),
                            idPrioridad = int.Parse(reader["idPrioridad"].ToString()!),
                            prioridad = reader["prioridad"].ToString()!,
                            idEstado = int.Parse(reader["idEstado"].ToString()!),
                            estado = reader["estado"].ToString()!,
                            fechaAtencion = reader.GetDateTime(reader.GetOrdinal("fechaAtencion")),
                        });
                    }
                }
                conn.Close();
                for (var i = 0; i < incidencia.Count(); i++)
                {
                    var id = incidencia[i].id;
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaComentarios_getxIncidencia]", conn))
                    {
                        List<incidenciaComentarios_complete> comentarios = new List<incidenciaComentarios_complete>();
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        var parametro = comando.Parameters.AddWithValue("@idIncidencia", id);
                        //parametro.SqlDbType = SqlDbType.Structured;

                        var reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            comentarios.Add(new incidenciaComentarios_complete()
                            {
                                id = int.Parse(reader["id"].ToString()!),
                                idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                                idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                                comentario = reader["comentario"].ToString()!,
                                usuario = reader["usuario"].ToString()!,
                                fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro"))
                            });
                        }
                        incidencia[i].comentarios = comentarios;
                    }
                    conn.Close();
                }
                for (var i = 0; i < incidencia.Count(); i++)
                {
                    var id = incidencia[i].id;
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand("[dbo].[IncidenciaArchivos_getxIncidencia]", conn))
                    {
                        List<incidenciaArchivos_complete> archivos = new List<incidenciaArchivos_complete>();
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        var parametro = comando.Parameters.AddWithValue("@idIncidencia", id);

                        var reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            archivos.Add(new incidenciaArchivos_complete()
                            {
                                id = int.Parse(reader["id"].ToString()!),
                                idIncidencia = int.Parse(reader["idIncidencia"].ToString()!),
                                idUsuario = int.Parse(reader["idUsuario"].ToString()!),
                                urlArchivo = reader["urlArchivo"].ToString()!,
                                nombreArchivo = reader["nombreArchivo"].ToString()!,
                                usuario = reader["usuario"].ToString()!,
                                fechaRegistro = reader.GetDateTime(reader.GetOrdinal("fechaRegistro"))
                            });
                        }
                        incidencia[i].archivos= archivos;
                    }
                    conn.Close();
                }
            }
            return incidencia;
        }

        public Modelos.Datos.Mapeo.Base.Datos.correo.ResultadoEnvio enviarCorreo(Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email, Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp)
        {
            
            smtp.Servidor = "smtp.office365.com";
            smtp.Puerto = 587;
            smtp.CredencialesPorDefecto = false;
            smtp.Usuario = "notificaciones@efitec-corp.com";
            smtp.Password = "N0t1Fic@$$2023";
            try
            {
                if (string.IsNullOrEmpty(smtp.Servidor))
                    throw new Exception("Debe especificar el servidor SMTP (smtp.Servidor)");
                if (email.De == null || string.IsNullOrEmpty(email.De.Address))
                    throw new Exception("Debe especificar remitente (email.De.Adress)");
                if (smtp.CredencialesPorDefecto == false && string.IsNullOrEmpty(smtp.Usuario))
                    throw new Exception("Si no se usan credenciales por defecto, es necesario especificar el usuario");

                if (string.IsNullOrEmpty(email.Titulo))
                    throw new Exception("Debe especificar el título del correo (email.Titulo)");
                if (email.Mensaje.Value == "")
                    throw new Exception("Debe especificar el cuerpo del correo (email.Mensaje)");
                if ((email.Para == null ? 0 : email.Para.Count) + (email.ConCopia == null ? 0 : email.ConCopia.Count) + (email.ConCopiaOculta == null ? 0 : email.ConCopiaOculta.Count) == 0)
                    throw new Exception("Debe especificar al menos un remitente en cualquiera de las listas (email.Para, email.ConCopia, email.ConCopiaOculta)");
                SmtpClient client = new SmtpClient();
                client.Host = smtp.Servidor;
                if (smtp.Puerto != -1)
                    client.Port = smtp.Puerto;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                if (smtp.CredencialesPorDefecto)
                    client.UseDefaultCredentials = true;
                else
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(smtp.Usuario, smtp.Password);
                }
                client.EnableSsl = true;
                MailMessage mensajeEmail = new MailMessage();
                mensajeEmail.From = email.De;
                string destinatariosPara = "";
                if (email.Para != null)
                    foreach (string correo in email.Para)
                    {
                        if (EsEmailValido(correo))
                        {
                            mensajeEmail.To.Add(new MailAddress(correo));
                            destinatariosPara = destinatariosPara + correo + ";";
                        }
                    }
                string destinatariosConCopia = "";
                if (email.ConCopia != null)
                    foreach (string correo in email.ConCopia)
                    {
                        if (EsEmailValido(correo))
                        {
                            mensajeEmail.CC.Add(new MailAddress(correo));
                            destinatariosConCopia = destinatariosConCopia + correo + ";";
                        }
                    }
                string destinatariosConCopiaOculta = "";
                if (email.ConCopiaOculta != null)
                    foreach (string correo in email.ConCopiaOculta)
                    {
                        if (EsEmailValido(correo))
                        {
                            mensajeEmail.Bcc.Add(new MailAddress(correo));
                            destinatariosConCopiaOculta = destinatariosConCopiaOculta + correo + ";";
                        }
                    }

                if (string.IsNullOrEmpty(destinatariosPara) && string.IsNullOrEmpty(destinatariosConCopia) && string.IsNullOrEmpty(destinatariosConCopiaOculta))
                    throw new Exception("Ninguno de los correos especificados es válido");

                mensajeEmail.IsBodyHtml = true;
                mensajeEmail.Subject = email.Titulo;
                mensajeEmail.Body = email.Mensaje.Value;
                List<string> detalleAdjuntos = new List<string>();
                if (email.Adjuntos != null)
                    foreach (string adjunto in (email.Adjuntos))
                    {
                        if (File.Exists(adjunto))
                        {
                            mensajeEmail.Attachments.Add(new Attachment(adjunto));
                            detalleAdjuntos.Add(adjunto + ": Adjuntado con éxito");
                        }
                        else
                            detalleAdjuntos.Add(adjunto + ": El archivo no existe o es inaccesible");
                    }
                client.Send(mensajeEmail);
                ResultadoEnvio ResultadoEnvio = new ResultadoEnvio()
                {
                    FueExitoso = true,
                    DetalleAdjuntosEnviados = string.Join<string>("\r\n", detalleAdjuntos),
                    DestinatariosPara = destinatariosPara,
                    DestinatariosConCopia = destinatariosConCopia,
                    DestinatariosConCopiaOculta = destinatariosConCopiaOculta,
                    MensajeError = null
                };
                return ResultadoEnvio;
            }
            catch (Exception ex)
            {
                ResultadoEnvio ResultadoEnvio = new ResultadoEnvio()
                {
                    FueExitoso = false,
                    MensajeError = ex.Message,
                    DestinatariosPara = null,
                    DestinatariosConCopia = null,
                    DestinatariosConCopiaOculta = null,
                    DetalleAdjuntosEnviados = null
                };
                return ResultadoEnvio;
            }
        }

        public bool updateincidenciaTipifica(t_incidencias obj)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@idTipoIncidencia", obj.idTipoIncidencia);
            parameters.Add("@idSubtipoIncidencia", 0);
            parameters.Add("@id", obj.id);
            parameters.Add("@idTipificacion", obj.idTipificacion);
            parameters.Add("@idEstado", obj.idEstado);
            parameters.Add("@idPrioridad", obj.idPrioridad);
            parameters.Add("@calificacionIncidente", obj.calificacionIncidente);
            parameters.Add("@fechaActualiza", obj.fechaActualiza);
            parameters.Add("@horasEstimadas", obj.horasEstimadas);
            parameters.Add("@horasEjecutadas", obj.horasEjecutadas);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[sp_updateincidenciaTipifica]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return (result == 1);
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                MailAddress correo = new MailAddress(email);
                return correo.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool cumpleANS(int diasRespuesta,t_incidencias incidencia)
        {
            int result = 0;            
            var parameters = new DynamicParameters();
            parameters.Add("@diasRespuesta", diasRespuesta);
            parameters.Add("@idEmpresa", incidencia.idEmpSist);
            parameters.Add("@idTipoIncidencia", incidencia.idTipoIncidencia);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.Query<int>("[dbo].[cumpleANS]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return (result == 1);
        }
        public personas getUsuarioASignado(t_incidencias incidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", incidencia.id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<personas>("[dbo].[Incidencia_getUsuarioAsignado]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public personas getUsuarioRegistro(t_incidencias incidencia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idIncidencia", incidencia.id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<personas>("[dbo].[Incidencia_getUsuarioRegistro]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public string getLinkIncidencia()
        {
            var parameters = new DynamicParameters();
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<string>("[dbo].[Incidencia_getLink_]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        
        public List<incidenciaByTipifFecha> getIncidenciasByTipifFecha(FilterIncidenciaByFechaById Entity)
        {
            List<incidenciaByTipifFecha> incidencias = new List<incidenciaByTipifFecha>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                bool fin = true;
                DateTime fecha_fin_aux = Entity.fecha_ini;
                DateTime fecha_ini_aux = Entity.fecha_ini;
                while (fin)
                {
                    fecha_fin_aux = fecha_fin_aux.AddDays(6);
                    if (fecha_fin_aux > Entity.fecha_fin)
                    {
                        fecha_fin_aux = Entity.fecha_fin;
                        fin = false;
                    }
                    var parameters = new DynamicParameters();
                    parameters.Add("@date_ini", fecha_ini_aux);
                    parameters.Add("@date_fin", fecha_fin_aux);                    

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        var lista_sp = (List<incidenciaByTipifFecha>)connection.Query<incidenciaByTipifFecha>("[dbo].[Incidencia_getByTipiFecha]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                        for(var i = 0;i<lista_sp.Count();i++)
                        {
                            lista_sp[i].fecha_ini = fecha_ini_aux;
                            lista_sp[i].fecha_fin = fecha_fin_aux;
                            incidencias.Add(lista_sp[i]);
                        }
                    }
                    fecha_ini_aux = fecha_fin_aux.AddDays(1);
                    fecha_fin_aux = fecha_fin_aux.AddDays(1);
                }
            }
            return incidencias;
        }
        public List<incidenciaBySistemaFecha> getIncidenciasBySistemaFecha(FilterIncidenciaByFechaById Entity)
        {
            List<incidenciaBySistemaFecha> incidencias = new List<incidenciaBySistemaFecha>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                bool fin = true;
                DateTime fecha_fin_aux = Entity.fecha_ini;
                DateTime fecha_ini_aux = Entity.fecha_ini;
                while (fin)
                {
                    fecha_fin_aux = fecha_fin_aux.AddDays(6);
                    if (fecha_fin_aux > Entity.fecha_fin)
                    {
                        fecha_fin_aux = Entity.fecha_fin;
                        fin = false;
                    }
                    var parameters = new DynamicParameters();
                    parameters.Add("@date_ini", fecha_ini_aux);
                    parameters.Add("@date_fin", fecha_fin_aux);

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        var lista_sp = (List<incidenciaBySistemaFecha>)connection.Query<incidenciaBySistemaFecha>("[dbo].[Incidencia_getBySistemaFecha]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                        for (var i = 0; i < lista_sp.Count(); i++)
                        {
                            lista_sp[i].fecha_ini = fecha_ini_aux;
                            lista_sp[i].fecha_fin = fecha_fin_aux;
                            incidencias.Add(lista_sp[i]);
                        }
                    }
                    fecha_ini_aux = fecha_fin_aux.AddDays(1);
                    fecha_fin_aux = fecha_fin_aux.AddDays(1);
                }
            }
            return incidencias;
        }
        public incidenciaByTipifList getIncidenciasBySistemaFecha_sol(FilterIncidenciaByMonth Entity)
        {
            var result = new incidenciaByTipifList();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("incidencia.incidencia_getSistemaFecha_sol", conn))
                {
                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@anio", SqlDbType.Int).Value = Entity.anho;
                    cmd.Parameters.Add("@mes", SqlDbType.Int).Value = Entity.mes;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Entity.id_usuario;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var incidencias = new List<IncidenciaByTipificacion>();
                        while (reader.Read())
                        {
                            incidencias.Add(new IncidenciaByTipificacion
                            {
                                Nombre = reader.GetString(0),
                                PrimerRango = reader.GetInt32(1),
                                SegundoRango = reader.GetInt32(2),
                                TercerRango = reader.GetInt32(3),
                                CuartoRango = reader.GetInt32(4),
                                QuintoRango = reader.GetInt32(5)
                            });
                        }
                        foreach (var incidencia in incidencias)
                        {
                            var serie = new seriesReq
                            {
                                name = incidencia.Nombre,
                                type = "bar",
                                data = new List<int> { incidencia.PrimerRango, incidencia.SegundoRango, incidencia.TercerRango, incidencia.CuartoRango, incidencia.QuintoRango}
                            };
                            result.series.Add(serie);
                        }
                        int diasDelMes = DateTime.DaysInMonth(Entity.anho, Entity.mes);
                        int diaInicio = 1;
                        DateTime fechaInicio = new DateTime(Entity.anho, Entity.mes, diaInicio);
                        while (fechaInicio.DayOfWeek != DayOfWeek.Monday)
                        {
                            fechaInicio = fechaInicio.AddDays(-1);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            DateTime fechaFin = fechaInicio.AddDays(6);
                            result.data.Add(fechaInicio.ToString("dd-MMMM") + "-" + fechaFin.ToString("dd-MMMM"));
                            fechaInicio = fechaFin.AddDays(1);
                        }
                        /*for (int i = 0; i < 4; i++)
                        {
                            int diaFinal = diaInicio + 7;
                            if (diaFinal > diasDelMes) diaFinal = diasDelMes;
                            result.data.Add(diaInicio + "-" + diaFinal);
                            diaInicio = diaFinal + 1;
                        }*/
                    }
                }
            }

            return result;
        }
        public incidenciaByTipifList getIncidenciasBySistemaFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity)
        {
            var result = new incidenciaByTipifList();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("incidencia.incidencia_getSistemaFecha_solByEmp", conn))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@anio", SqlDbType.Int).Value = Entity.anho;
                    cmd.Parameters.Add("@mes", SqlDbType.Int).Value = Entity.mes;
                    cmd.Parameters.Add("@id_empresa", SqlDbType.Int).Value = Entity.id_empresa;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var incidencias = new List<IncidenciaByTipificacion>();
                        while (reader.Read())
                        {
                            incidencias.Add(new IncidenciaByTipificacion
                            {
                                Nombre = reader.GetString(0),
                                PrimerRango = reader.GetInt32(1),
                                SegundoRango = reader.GetInt32(2),
                                TercerRango = reader.GetInt32(3),
                                CuartoRango = reader.GetInt32(4),
                                QuintoRango = reader.GetInt32(5)
                            });
                        }
                        foreach (var incidencia in incidencias)
                        {
                            var serie = new seriesReq
                            {
                                name = incidencia.Nombre,
                                type = "bar",
                                data = new List<int> { incidencia.PrimerRango, incidencia.SegundoRango, incidencia.TercerRango, incidencia.CuartoRango, incidencia.QuintoRango }
                            };
                            result.series.Add(serie);
                        }
                        int diasDelMes = DateTime.DaysInMonth(Entity.anho, Entity.mes);
                        int diaInicio = 1;
                        DateTime fechaInicio = new DateTime(Entity.anho, Entity.mes, diaInicio);
                        while (fechaInicio.DayOfWeek != DayOfWeek.Monday)
                        {
                            fechaInicio = fechaInicio.AddDays(-1);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            DateTime fechaFin = fechaInicio.AddDays(6);
                            result.data.Add(fechaInicio.ToString("dd-MMMM") + "-" + fechaFin.ToString("dd-MMMM"));
                            fechaInicio = fechaFin.AddDays(1);
                        }
                        /*for (int i = 0; i < 4; i++)
                        {
                            int diaFinal = diaInicio + 7;
                            if (diaFinal > diasDelMes) diaFinal = diasDelMes;
                            result.data.Add(diaInicio + "-" + diaFinal);
                            diaInicio = diaFinal + 1;
                        }*/
                    }
                }
            }

            return result;
        }
        public incidenciaByTipifListDecimal Incidencia_conteoHorasByIncidenciaSistema(FilterIncidenciaByMonthByEmp Entity)
        {
            incidenciaByTipifListDecimal result = new incidenciaByTipifListDecimal();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("dbo.Incidencia_conteoHorasByIncidenciaSistema", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = Entity.mes;
                command.Parameters.Add("@anio", SqlDbType.Int).Value = Entity.anho;
                command.Parameters.Add("@id_empresa", SqlDbType.Int).Value = Entity.id_empresa;
                SqlDataReader reader = command.ExecuteReader();

                DataTable schema = reader.GetSchemaTable();
                foreach (DataRow row in schema.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    if (columnName != "tipo_incidencia")
                    {
                        result.data.Add(columnName);
                    }
                }

                while (reader.Read()) 
                {
                    string tipoIncidencia = reader.GetValue(0).ToString();
                    seriesReqDecimal serie = new seriesReqDecimal();
                    serie.name = tipoIncidencia;
                    serie.type = "bar";

                    for (int i = 1; i < schema.Rows.Count; i++)
                    {
                        decimal conteoHoras;
                        if (reader.GetValue(i) == DBNull.Value)
                        {
                            conteoHoras = 0;
                        }
                        else
                        {
                            conteoHoras = Convert.ToDecimal(reader.GetValue(i));
                        }
                        serie.data.Add(conteoHoras);
                    }
                    result.series.Add(serie);
                }
                connection.Close();

                return result;
            }
        }
        public incidenciaByTipifList getIncidenciasByTipifList(FilterIncidenciaByTipifListByEmp Entity)
        {
            var result = new incidenciaByTipifList();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("incidencia.incidencia_getByTipifList_sol", conn))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("idTipificaciones", typeof(int));
                    // Agregamos las filas con los valores de la lista de idTipificaciones
                    foreach (int id in Entity.idTipificacion)
                    {
                        dt.Rows.Add(id);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@anio", SqlDbType.Int).Value = Entity.anio;
                    cmd.Parameters.Add("@mes", SqlDbType.Int).Value = Entity.mes;
                    cmd.Parameters.Add("@id_empresa", SqlDbType.Int).Value = Entity.id_empresa;
                    cmd.Parameters.AddWithValue("@idTipificaciones", dt);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var incidencias = new List<IncidenciaByTipificacion>();
                        var contador = 0;
                        while (reader.Read())
                        {
                            incidencias.Add(new IncidenciaByTipificacion
                            {
                                Nombre = reader.GetString(0),
                                PrimerRango = reader.GetInt32(1),
                                SegundoRango = reader.GetInt32(2),
                                TercerRango = reader.GetInt32(3),
                                CuartoRango = reader.GetInt32(4),
                                QuintoRango = reader.GetInt32(5)
                            });
                            var serie = new seriesReq
                            {
                                name = incidencias[contador].Nombre,
                                type = "bar",
                                data = new List<int> { incidencias[contador].PrimerRango, incidencias[contador].SegundoRango, incidencias[contador].TercerRango, incidencias[contador].CuartoRango, incidencias[contador].QuintoRango }
                            };
                            result.series.Add(serie);
                            contador++;
                        }

                        /*foreach (var incidencia in incidencias)
                        {
                            var serie = new seriesReq
                            {
                                name = incidencia.Nombre,
                                type = "bar",
                                data = new List<int> { incidencia.PrimerRango, incidencia.SegundoRango, incidencia.TercerRango, incidencia.CuartoRango, incidencia.QuintoRango }
                            };
                            result.series.Add(serie);
                        }*/
                        int diasDelMes = DateTime.DaysInMonth(Entity.anio, Entity.mes);
                        int diaInicio = 1;
                        DateTime fechaInicio = new DateTime(Entity.anio, Entity.mes, diaInicio);
                        while (fechaInicio.DayOfWeek != DayOfWeek.Monday)
                        {
                            fechaInicio = fechaInicio.AddDays(-1);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            

                            DateTime fechaFin = fechaInicio.AddDays(6);
                            //if (fechaFin.Month != Entity.mes)
                            //{
                            //    fechaFin = new DateTime(Entity.anio, Entity.mes, diasDelMes);
                            //}

                            result.data.Add(fechaInicio.ToString("dd-MMMM") + "-" + fechaFin.ToString("dd-MMMM"));
                            fechaInicio = fechaFin.AddDays(1);
                        }
                    }
                }
            }

            return result;
        }
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_sol(FilterIncidenciaByMonth Entity)
        {
            List<incidenciaByTipifFecha_sol> incidencias_sol = new List<incidenciaByTipifFecha_sol>();

            
            DateTime date1 = new DateTime(Entity.anho, Entity.mes, 1);
            DateTime date2 = date1.AddMonths(1).AddDays(-1);
            while (date1.DayOfWeek != DayOfWeek.Monday)
                date1 = date1.AddDays(-1);
            while (date2.DayOfWeek != DayOfWeek.Sunday)
                date2 = date2.AddDays(1);
            // Obtiene una lista de todos los parámetros de tipo "t_parametroDetalles"
            IEnumerable<t_parametroDetalles> parametros;
            parametros = parametroDetalles.GetList();
            // Obtiene solo los parámetros cuyo idParametro sea 15
            var tipificaciones = parametros.Where(x => x.idParametro == 15);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // indica cuándo se ha terminado de iterar sobre todas las semanas del mes
                bool fin = true;
                DateTime fecha_fin_aux = date1;
                DateTime fecha_ini_aux = date1;
                // Contador para llevar el índice de la incidencia_sol actual en la lista incidencias_sol
                var k = 0;
                while (fin)
                {
                    incidenciaByTipifFecha_sol incidencia_sol = new incidenciaByTipifFecha_sol();
                    fecha_fin_aux = fecha_ini_aux.AddDays(6);
                    // Si la fecha_fin_aux es mayor al último día del mes, entonces se establece la fecha_fin_aux como el último día del mes
                    // y se establece la bandera fin como false para terminar el ciclo
                    if (fecha_fin_aux >= date2)
                    {
                        fecha_fin_aux = date2;
                        fin = false;
                    }
                    var parameters = new DynamicParameters();
                    parameters.Add("@date_ini", fecha_ini_aux);
                    parameters.Add("@date_fin", fecha_fin_aux);

                    incidencia_sol.type = "bar";
                    string fechaFormateada = String.Format("{0:dd-MMMM}-{1:dd-MMMM}", fecha_ini_aux, fecha_fin_aux);
                    incidencia_sol.name = fechaFormateada;
                    incidencia_sol.data = new List<int>();
                    incidencias_sol.Add(incidencia_sol);

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        var lista_sp = (List<incidenciaByTipifFecha>)connection.Query<incidenciaByTipifFecha>("[dbo].[Incidencia_getByTipiFecha]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                        
                        foreach (var tipificacion in tipificaciones)
                        {
                            int existeTipificacion = 0;
                            foreach (var item in lista_sp)
                            {
                                if (item.idTipificacion == tipificacion.id)
                                {
                                    incidencias_sol[k].data.Add(item.cantidad);
                                    existeTipificacion = 1;
                                }
                            }
                            if(existeTipificacion==0)
                                incidencias_sol[k].data.Add(0);
                        }
                        
                       
                    }
                    
                    fecha_ini_aux = fecha_fin_aux.AddDays(1);
                    //fecha_fin_aux = fecha_fin_aux.AddDays(1);
                    k++;
                }
            }
            return incidencias_sol;
        }
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity)
        {
            List<incidenciaByTipifFecha_sol> incidencias_sol = new List<incidenciaByTipifFecha_sol>();


            DateTime date1 = new DateTime(Entity.anho, Entity.mes, 1);
            DateTime date2 = date1.AddMonths(1).AddDays(-1);
            while (date1.DayOfWeek != DayOfWeek.Monday)
                date1 = date1.AddDays(-1);
            while (date2.DayOfWeek != DayOfWeek.Sunday)
                date2 = date2.AddDays(1);
            IEnumerable<tipificacionesEmpresa> parametros;
            parametros = _tipificacionesempresa.GetList();
            var tipificaciones = parametros.Where(x => x.idEmpresa == Entity.id_empresa);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                bool fin = true;
                DateTime fecha_fin_aux = date1;
                DateTime fecha_ini_aux = date1;
                var k = 0;
                while (fin)
                {
                    incidenciaByTipifFecha_sol incidencia_sol = new incidenciaByTipifFecha_sol();
                    fecha_fin_aux = fecha_ini_aux.AddDays(6);
                    if (fecha_fin_aux >= date2)
                    {
                        fecha_fin_aux = date2;
                        fin = false;
                    }
                    var parameters = new DynamicParameters();
                    parameters.Add("@date_ini", fecha_ini_aux);
                    parameters.Add("@date_fin", fecha_fin_aux);
                    parameters.Add("@id_empresa", Entity.id_empresa);

                    incidencia_sol.type = "bar";
                    string fechaFormateada = String.Format("{0:dd-MMMM}-{1:dd-MMMM}", fecha_ini_aux, fecha_fin_aux);
                    incidencia_sol.name = fechaFormateada;
                    incidencia_sol.data = new List<int>();
                    incidencias_sol.Add(incidencia_sol);

                    using (var connection = new SqlConnection(_connectionString))
                    {
                        var lista_sp = (List<incidenciaByTipifFecha>)connection.Query<incidenciaByTipifFecha>("[dbo].[Incidencia_getByTipiFecha]", parameters, commandType: System.Data.CommandType.StoredProcedure);

                        foreach (var tipificacion in tipificaciones)
                        {
                            int existeTipificacion = 0;
                            foreach (var item in lista_sp)
                            {
                                if (item.idTipificacion == tipificacion.idTipificacion)
                                {
                                    incidencias_sol[k].data.Add(item.cantidad);
                                    existeTipificacion = 1;
                                }
                            }
                            if (existeTipificacion == 0)
                                incidencias_sol[k].data.Add(0);
                        }


                    }

                    fecha_ini_aux = fecha_fin_aux.AddDays(1);
                    //fecha_fin_aux = fecha_fin_aux.AddDays(1);
                    k++;
                }
            }
            return incidencias_sol;
        }

        public int getIdSecuencialTicket(in int idEmpSist, int idTabla)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpSist ", idEmpSist);
            parameters.Add("@idTabla ", idTabla);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>("[dbo].[sp_getIdSecuencialTicket]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<reporteIncidenciaResponseDTO> getReporteIncidenciasByFechas(reporteIncidenciaDTO objDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechaInicial ", objDto.fechaInicial);
            parameters.Add("@fechaFinal ", objDto.fechaFinal);
            parameters.Add("@id ", objDto.idEmpresa);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<reporteIncidenciaResponseDTO>("[dbo].[sp_getReporteIncidenciasByFechas]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public seriesAtencionSolicitudes getANSByMonth_sol(FilterIncidenciaANSByMonth Entity)
        {
            seriesAtencionSolicitudes result = new seriesAtencionSolicitudes();
            dataLabelReq seriesCumplioANS = new dataLabelReq { data = new List<int>(), label = "Cumplio ANS" };
            dataLabelReq seriesNoCumplioANS = new dataLabelReq { data = new List<int>(), label = "No cumplio ANS" };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[incidencia].[incidencias_getANSByMonth]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@anio", Entity.anho);
                    command.Parameters.AddWithValue("@mesInicio", Entity.mesIniANS);
                    command.Parameters.AddWithValue("@mesFin", Entity.mesFinANS);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.rangoFechas.Add(reader.GetString(1));
                            seriesCumplioANS.data.Add(reader.GetInt32(2));
                            seriesNoCumplioANS.data.Add(reader.GetInt32(3));
                        }
                    }
                }

                connection.Close();
            }
            result.series.Add(seriesCumplioANS);
            result.series.Add(seriesNoCumplioANS);

            return result;
        }
        public incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int incidenciaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", incidenciaId);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<incidenciaDetailsEmailDTO>("[dbo].[sp_getIncidenciaDetaliByEmail]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<object> obtenerIncidenciasSistemaPorIdUsuario(int idUsuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idUsuario", idUsuario);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<object>)connection.Query<object>("[dbo].[Incidencia_getSistemasByIdUsuario]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public IEnumerable<incidenciasGridDTO> getTicketsGerenteCliente(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<incidenciasGridDTO>)connection.Query<incidenciasGridDTO>("[dbo].[sp_getTicketsGerenteCliente]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public IEnumerable<incidenciasGridDTO> getTicketsGerenteSoporte(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<incidenciasGridDTO>)connection.Query<incidenciasGridDTO>("[dbo].[sp_getTicketsGerenteSoporte]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public IncidenciasByEtapa getIncidenciasByEtapa (onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getPeriodos]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuarioAsignado", Entity.id_usuario);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEtapa result = new IncidenciasByEtapa();
                        while (reader.Read())
                        {
                            int incidenciasHoy = reader.GetInt32(0);
                            int incidenciasSemana = reader.GetInt32(1);
                            int incidenciasMes = reader.GetInt32(2);
                            int incidenciasAno = reader.GetInt32(3);
                            int incidenciasHoyAnterior = reader.GetInt32(4);
                            int incidenciasSemanaAnterior = reader.GetInt32(5);
                            int incidenciasMesAnterior = reader.GetInt32(6);
                            int incidenciasAnoAnterior = reader.GetInt32(7);

                            result.conteo.Add(incidenciasHoy);
                            result.conteo.Add(incidenciasSemana);
                            result.conteo.Add(incidenciasMes);
                            result.conteo.Add(incidenciasAno);
                            result.porcentaje.Add((incidenciasHoyAnterior == 0) ? 0 : (int)((incidenciasHoy - incidenciasHoyAnterior) * 100.0 / incidenciasHoyAnterior));
                            result.porcentaje.Add((incidenciasSemanaAnterior == 0) ? 0 : (int)((incidenciasSemana - incidenciasSemanaAnterior) * 100.0 / incidenciasSemanaAnterior));
                            result.porcentaje.Add((incidenciasMesAnterior == 0) ? 0 : (int)((incidenciasMes - incidenciasMesAnterior) * 100.0 / incidenciasMesAnterior));
                            result.porcentaje.Add((incidenciasAnoAnterior == 0) ? 0 : (int)((incidenciasAno - incidenciasAnoAnterior) * 100.0 / incidenciasAnoAnterior));
                        }

                        return result;
                    }
                }
            }
        }
        public IncidenciasByEtapa getIncidenciasByEtapaGen()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getPeriodosGen]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEtapa result = new IncidenciasByEtapa();
                        while (reader.Read())
                        {
                            int incidenciasHoy = reader.GetInt32(0);
                            int incidenciasSemana = reader.GetInt32(1);
                            int incidenciasMes = reader.GetInt32(2);
                            int incidenciasAno = reader.GetInt32(3);
                            int incidenciasHoyAnterior = reader.GetInt32(4);
                            int incidenciasSemanaAnterior = reader.GetInt32(5);
                            int incidenciasMesAnterior = reader.GetInt32(6);
                            int incidenciasAnoAnterior = reader.GetInt32(7);

                            result.conteo.Add(incidenciasHoy);
                            result.conteo.Add(incidenciasSemana);
                            result.conteo.Add(incidenciasMes);
                            result.conteo.Add(incidenciasAno);
                            result.porcentaje.Add((incidenciasHoyAnterior == 0) ? 0 : (int)((incidenciasHoy - incidenciasHoyAnterior) * 100.0 / incidenciasHoyAnterior));
                            result.porcentaje.Add((incidenciasSemanaAnterior == 0) ? 0 : (int)((incidenciasSemana - incidenciasSemanaAnterior) * 100.0 / incidenciasSemanaAnterior));
                            result.porcentaje.Add((incidenciasMesAnterior == 0) ? 0 : (int)((incidenciasMes - incidenciasMesAnterior) * 100.0 / incidenciasMesAnterior));
                            result.porcentaje.Add((incidenciasAnoAnterior == 0) ? 0 : (int)((incidenciasAno - incidenciasAnoAnterior) * 100.0 / incidenciasAnoAnterior));
                        }

                        return result;
                    }
                }
            }
        }
        public IncidenciasByEtapa getIncidenciasByEtapaCliente(onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getPeriodosCliente]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuarioRegistro", Entity.id_usuario);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEtapa result = new IncidenciasByEtapa();
                        while (reader.Read())
                        {
                            int incidenciasHoy = reader.GetInt32(0);
                            int incidenciasSemana = reader.GetInt32(1);
                            int incidenciasMes = reader.GetInt32(2);
                            int incidenciasAno = reader.GetInt32(3);
                            int incidenciasHoyAnterior = reader.GetInt32(4);
                            int incidenciasSemanaAnterior = reader.GetInt32(5);
                            int incidenciasMesAnterior = reader.GetInt32(6);
                            int incidenciasAnoAnterior = reader.GetInt32(7);

                            result.conteo.Add(incidenciasHoy);
                            result.conteo.Add(incidenciasSemana);
                            result.conteo.Add(incidenciasMes);
                            result.conteo.Add(incidenciasAno);
                            result.porcentaje.Add((incidenciasHoyAnterior == 0) ? 0 : (int)((incidenciasHoy - incidenciasHoyAnterior) * 100.0 / incidenciasHoyAnterior));
                            result.porcentaje.Add((incidenciasSemanaAnterior == 0) ? 0 : (int)((incidenciasSemana - incidenciasSemanaAnterior) * 100.0 / incidenciasSemanaAnterior));
                            result.porcentaje.Add((incidenciasMesAnterior == 0) ? 0 : (int)((incidenciasMes - incidenciasMesAnterior) * 100.0 / incidenciasMesAnterior));
                            result.porcentaje.Add((incidenciasAnoAnterior == 0) ? 0 : (int)((incidenciasAno - incidenciasAnoAnterior) * 100.0 / incidenciasAnoAnterior));
                        }

                        return result;
                    }
                }
            }
        }
        public IncidenciasByEstado getIncidenciasByEstado(onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstado]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuarioAsignado", Entity.id_usuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEstado result = new IncidenciasByEstado();
                        while (reader.Read())
                        {
                            result.estados.Add(reader.GetString(0));
                            result.conteo.Add(reader.GetInt32(1));
                        }

                        return result;
                    }
                }
            }
        }
        public IncidenciasByEstado getIncidenciasByEstadoGen()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstadoGen]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEstado result = new IncidenciasByEstado();
                        while (reader.Read())
                        {
                            result.estados.Add(reader.GetString(0));
                            result.conteo.Add(reader.GetInt32(1));
                        }

                        return result;
                    }
                }
            }
        }
        public IncidenciasByEstado getIncidenciasByEstadoCliente(onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstadoCliente]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuarioRegistro", Entity.id_usuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IncidenciasByEstado result = new IncidenciasByEstado();
                        while (reader.Read())
                        {
                            result.estados.Add(reader.GetString(0));
                            result.conteo.Add(reader.GetInt32(1));
                        }

                        return result;
                    }
                }
            }
        }
        public incidenciaByTipifList Incidencias_getEstadosByUsuario (onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstadosByIdUsuario]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuario", Entity.id_usuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        incidenciaByTipifList result = new incidenciaByTipifList();

                        DataTable schema = reader.GetSchemaTable();
                        foreach (DataRow row in schema.Rows)
                        {
                            string columnName = row["ColumnName"].ToString();
                            if (columnName != "Nombre_estado")
                            {
                                result.data.Add(columnName);
                            }
                        }

                        while (reader.Read())
                        {
                            string nombreEstado = reader.GetValue(0).ToString();
                            seriesReq serie = new seriesReq();
                            serie.name = nombreEstado;
                            serie.type = "bar";

                            for (int i = 1; i < schema.Rows.Count; i++)
                            {
                                int conteoInc;
                                if (reader.GetValue(i) == DBNull.Value)
                                {
                                    conteoInc = 0;
                                }
                                else
                                {
                                    conteoInc = Convert.ToInt32(reader.GetValue(i));
                                }
                                serie.data.Add(conteoInc);
                            }
                            result.series.Add(serie);
                        }

                        return result;
                    }
                }
            }
        }
        public incidenciaByTipifList Incidencias_getEstadosByUsuarioGen()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstadosByIdUsuarioGen]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        incidenciaByTipifList result = new incidenciaByTipifList();

                        DataTable schema = reader.GetSchemaTable();
                        foreach (DataRow row in schema.Rows)
                        {
                            string columnName = row["ColumnName"].ToString();
                            if (columnName != "Nombre_estado")
                            {
                                result.data.Add(columnName);
                            }
                        }

                        while (reader.Read())
                        {
                            string nombreEstado = reader.GetValue(0).ToString();
                            seriesReq serie = new seriesReq();
                            serie.name = nombreEstado;
                            serie.type = "bar";

                            for (int i = 1; i < schema.Rows.Count; i++)
                            {
                                int conteoInc;
                                if (reader.GetValue(i) == DBNull.Value)
                                {
                                    conteoInc = 0;
                                }
                                else
                                {
                                    conteoInc = Convert.ToInt32(reader.GetValue(i));
                                }
                                serie.data.Add(conteoInc);
                            }
                            result.series.Add(serie);
                        }

                        return result;
                    }
                }
            }
        }
        public incidenciaByTipifList Incidencias_getEstadosByCliente(onlyIdAndRol Entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[dbo].[Incidencia_getEstadosByIdUsuarioRegistra]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuario", Entity.id_usuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        incidenciaByTipifList result = new incidenciaByTipifList();

                        DataTable schema = reader.GetSchemaTable();
                        foreach (DataRow row in schema.Rows)
                        {
                            string columnName = row["ColumnName"].ToString();
                            if (columnName != "Nombre_estado")
                            {
                                result.data.Add(columnName);
                            }
                        }

                        while (reader.Read())
                        {
                            string nombreEstado = reader.GetValue(0).ToString();
                            seriesReq serie = new seriesReq();
                            serie.name = nombreEstado;
                            serie.type = "bar";

                            for (int i = 1; i < schema.Rows.Count; i++)
                            {
                                int conteoInc;
                                if (reader.GetValue(i) == DBNull.Value)
                                {
                                    conteoInc = 0;
                                }
                                else
                                {
                                    conteoInc = Convert.ToInt32(reader.GetValue(i));
                                }
                                serie.data.Add(conteoInc);
                            }
                            result.series.Add(serie);
                        }

                        return result;
                    }
                }
            }
        }
        public List<IncidenciaHorasByMes> Incidencias_getHorasByMes(FilterIncidenciaByEmpMonth Entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", Entity.idEmpresa);
            parameters.Add("@mesInicio", Entity.mesInicio);
            parameters.Add("@mesFin", Entity.mesFin);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<IncidenciaHorasByMes>)connection.Query<IncidenciaHorasByMes>("[incidencia].[incidencia_getHorasByMonth]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<IncidenciaHorasUsuarioAsignadoByMonth> Incidencias_getHorasSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", Entity.idEmpresa);
            parameters.Add("@mesInicio", Entity.mesInicio);
            parameters.Add("@mesFin", Entity.mesFin);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<IncidenciaHorasUsuarioAsignadoByMonth>)connection.Query<IncidenciaHorasUsuarioAsignadoByMonth>("[incidencia].[incidencia_getHorasSistemaByMonth]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<IncidenciasHorasSistemaByMonth> Incidencia_getHorasUsuarioAsignadoByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", Entity.idEmpresa);
            parameters.Add("@mesInicio", Entity.mesInicio);
            parameters.Add("@mesFin", Entity.mesFin);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<IncidenciasHorasSistemaByMonth>)connection.Query<IncidenciasHorasSistemaByMonth>("[incidencia].[incidencia_getHorasUsuarioAsignadoByMonth]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<IncidenciaHorasUsuarioAsignadoSistemaByMonth> Incidencia_getHorasUsuarioAsignadoSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", Entity.idEmpresa);
            parameters.Add("@mesInicio", Entity.mesInicio);
            parameters.Add("@mesFin", Entity.mesFin);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<IncidenciaHorasUsuarioAsignadoSistemaByMonth>)connection.Query<IncidenciaHorasUsuarioAsignadoSistemaByMonth>("[incidencia].[incidencia_getHorasUsuarioAsignadoSistemaByMonth]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<incidenciaFactorRendimientoAsignado> Incidencia_getFactorRendimientoAsignado(FIlterIncidenciaByAsigMonth Entity)
        {
            List<incidenciaFactorRendimientoAsignado> result = new List<incidenciaFactorRendimientoAsignado>();
            List<string> sistemas = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("incidencia.incidencia_getFactorRendimientoAsignado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idUsuarioAsignado", Entity.idUsuarioAsignado);
                    command.Parameters.AddWithValue("@mesInicio", Entity.mesInicio);
                    command.Parameters.AddWithValue("@mesFin", Entity.mesFin);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            string nombreSistema = reader.GetValue(0).ToString();
                            float factor = Convert.ToSingle(reader.GetValue(1));
                            int mes = Convert.ToInt32(reader.GetValue(2));
                            int anio = Convert.ToInt32(reader.GetValue(3));

                            SeriesStrInt serie = new SeriesStrInt()
                            {
                                name = anio.ToString("00") + "-" + mes.ToString("00"),
                                value = factor
                            };

                            incidenciaFactorRendimientoAsignado incidencia = result.FirstOrDefault(i => i.name == nombreSistema);

                            if (incidencia == null)
                            {
                                incidencia = new incidenciaFactorRendimientoAsignado()
                                {
                                    name = nombreSistema,
                                    series = new List<SeriesStrInt>()
                                };
                                result.Add(incidencia);
                            }

                            incidencia.series.Add(serie);
                            if (!sistemas.Contains(nombreSistema))
                            {
                                sistemas.Add(nombreSistema);
                            }
                        }
                    }
                }
            }
            for (int i = Entity.mesInicio; i <= Entity.mesFin; i++)
            {
                int year = GetLimaDateTimeNow().Year;
                foreach (string sistema in sistemas)
                {
                    incidenciaFactorRendimientoAsignado incidencia = result.FirstOrDefault(x => x.name == sistema);
                    if (incidencia != null)
                    {
                        SeriesStrInt serie = incidencia.series.FirstOrDefault(x => x.name == year.ToString("00") + "-" + i.ToString("00"));
                        if (serie == null)
                        {
                            serie = new SeriesStrInt()
                            {
                                name = year.ToString("00") + "-" + i.ToString("00"),
                                value = 0
                            };
                            incidencia.series.Add(serie);
                        }
                    }
                }
            }
            return result.OrderBy(x => x.name).ToList();
        }

        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }
        public List<IncidenciaGetTable1> Incidencia_getTicketHorasTable1(FilterIncidenciaByMonthYearEmp Entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", Entity.idEmpresa);
            parameters.Add("@mesInicio", Entity.mesInicio);
            parameters.Add("@mesFin", Entity.mesFin);
            parameters.Add("@anio", Entity.anio);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<IncidenciaGetTable1>)connection.Query<IncidenciaGetTable1>("[incidencia].[Incidencia_getTicketHorasTable1]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<incidencia_dataIntLabelString> Incidencia_getANSByEmp(FilterIncidenciaByEmpDate Entity)
        {
            List<incidencia_dataIntLabelString> dataList = new List<incidencia_dataIntLabelString>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("incidencia.getANSByEmp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fechaInicio", Entity.fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", Entity.fechaFin);
                cmd.Parameters.AddWithValue("@id_empresa", Entity.idEmpresa);

                SqlDataReader reader = cmd.ExecuteReader();

                List<int> totalTickets = new List<int>();
                List<int> totalANS1 = new List<int>();
                List<int> totalANS2 = new List<int>();
                List<int> totalANS0 = new List<int>();

                while (reader.Read())
                {
                    totalTickets.Add(reader.GetInt32(0));
                    totalANS0.Add(reader.GetInt32(1));
                    totalANS1.Add(reader.GetInt32(2));
                    totalANS2.Add(reader.GetInt32(3));
                }

                incidencia_dataIntLabelString t1 = new incidencia_dataIntLabelString
                {
                    name = "Total Tickets",
                    type = "bar",
                    data = totalTickets,
                   
                };
                incidencia_dataIntLabelString t2 = new incidencia_dataIntLabelString
                {
                    name = "No cumplió",
                    type = "bar",
                    data = totalANS0,
                    
                };
                incidencia_dataIntLabelString t3 = new incidencia_dataIntLabelString
                {
                    name = "Cumplió",
                    type = "bar",
                    data = totalANS1,
                    
                };
                incidencia_dataIntLabelString t4 = new incidencia_dataIntLabelString
                {
                    name = "Decartado",
                    type = "bar",
                    data = totalANS2,
                    
                };
                dataList.Add(t1);
                dataList.Add(t2);
                dataList.Add(t3);
                dataList.Add(t4);
            }

            return dataList;
        }

        public IEnumerable<PorcentajeCumplimientoDTO> getPorcentajeCumplimiento(FilterIncidenciaByEmpDate entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idEmpresa", entity.idEmpresa);
            parameters.Add("@fechaInicio", entity.fechaInicio);
            parameters.Add("@fechaFin", entity.fechaFin);
            using (var connection = new SqlConnection(_connectionString))
            {
                return (List<PorcentajeCumplimientoDTO>)connection.Query<PorcentajeCumplimientoDTO>("[dbo].[sp_getPorcentajeCumplimiento]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
