using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Dapper;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Repositorios.Interfaces.persona;

namespace Acceso.Datos.Implementacion.Repositorios.persona
{
    public class accesosRepository : Repository<accesos>, IAccesosRepository
    {
        public accesosRepository(string _connectionString) : base(_connectionString)
        {
        }
        public int generadorCodigo(string usuario)
        {
            //Generar un numero aleatorio de 6 digitos y actualizar el campo codigoValidacion de la tabla persona.accesos where usuario = usuario; y devolver el int generado
            Random random = new Random();
            int n = random.Next(100000, 999999);
            var parameters = new DynamicParameters();
            parameters.Add("@usuario", usuario);
            parameters.Add("@codigo", n);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Query<int>("[persona].[personas_generarCodigo_update]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();                
            }
            return n;
        }


       /* public ResultadoEnvio enviarCorreo(string usuario, int codigo, DatosEmail email, DatosSMTP smtp)
        {
            email.Para.Add(usuario);
            email.Titulo = "EFITEC CÓDIGO DE VALIDACIÓN";
            email.Mensaje = "Su código de validación es: " + codigo;
            smtp.Servidor = "smtp-relay.sendinblue.com";
            smtp.Puerto = 587;
            smtp.CredencialesPorDefecto = false;
            smtp.Usuario = "walter150976@gmail.com";
            smtp.Password = "FtPypca94j2kdJMR";
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
                if (string.IsNullOrEmpty(email.Mensaje))
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
                mensajeEmail.Body = email.Mensaje;
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
        }*/


        public bool validarCodigo(int codigo, string usuario)
        {
            //Validar mediante sp retornar true o false, si el codigo ingresado es el mismo de la tabla persona.accesos where usuario = usuario;
            var parameters = new DynamicParameters();
            parameters.Add("@usuario", usuario);
            parameters.Add("@codigo", codigo);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<bool>("[persona].[acceso_validarCodigoGenerado_select]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool actualizaContrasenia(string contrasenia, string usuario)
        {
            try
            {
                int result = 0;
                var parameters = new DynamicParameters();
                parameters.Add("@usuario", usuario);
                parameters.Add("@contrasenia", contrasenia);
                using (var connection = new SqlConnection(_connectionString))
                {
                    result = connection.Query<int>("[dbo].[sp_actualizaContrasenia]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }

                return (result == 1);
            }
            catch (Exception ex)
            {

                string mensaje = ex.Message;
                return false;
            }
            
        }

        public string getContraseniaByIdUser(in int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<string>("[dbo].[sp_getContraseniaByIdUser]", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        /*private bool EsEmailValido(string email)
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
        }*/
    }
}
