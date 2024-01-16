using Modelos.Datos.Mapeo.Base.Datos.correo;
using Repositorios.Interfaces.correo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Acceso.Datos.Implementacion.Repositorios.correo
{
    public class correoRepository : Repository<ResultadoEnvio>,ICorreoRepository
    {
        public correoRepository(string _connectionString) : base(_connectionString) { }
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
        public ResultadoEnvio enviarCorreo(DatosEmail email, DatosSMTP smtp)
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

    }
}
