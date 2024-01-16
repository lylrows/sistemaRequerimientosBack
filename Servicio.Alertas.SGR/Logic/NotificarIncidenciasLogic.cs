using Modelos.Datos.Mapeo.Base.Datos.persona;
using Servicio.Alertas.SGR.Connections;
using Servicio.Alertas.SGR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servicio.Alertas.SGR.Logic
{
    public class NotificarIncidenciasLogic
    {
        private List<getIncidenciasNotificarDTO> incidencias = new List<getIncidenciasNotificarDTO>();
        private dbSqlConnection dbSqlConnection = new dbSqlConnection();
        private Timer feqProcessVh;
        private Timer feqProcessDay;
        private bool InProcess { get; set; }
        private string Path { get; set; }
        private TimeSpan StartTime { get; set; }
        private TimeSpan EndTime { get; set; }

        public void Start()
        {
            try
            {
                feqProcessVh = new Timer(45000);
                feqProcessVh.Elapsed += feqProcessVh_Elapsed;
                StartTime = DateTime.Parse("06:00").TimeOfDay;
                EndTime = DateTime.Parse("23:00").TimeOfDay;
                feqProcessVh.Start();
            }
            catch (Exception ex)
            {
            }
        }

        public void Finish()
        {
            if (feqProcessDay != null && feqProcessDay.Enabled)
            {
                feqProcessDay.Stop();
                feqProcessDay.Elapsed -= feqProcessDay_Elapsed;
                feqProcessDay.Dispose();
                feqProcessDay = null;
            }

            if (feqProcessVh != null && feqProcessVh.Enabled)
            {
                feqProcessVh.Stop();
                feqProcessVh.Elapsed -= feqProcessVh_Elapsed;
                feqProcessVh.Dispose();
                feqProcessVh = null;
            }
            InProcess = false;
        }

        void feqProcessDay_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Validar que dia de la semana se ejecutara
            try
            {
                Run();
            }
            catch (Exception ex)
            {
            }

        }
        public List<string> Run()
        {
            var lst = new List<string>();
            try
            {

                NotificarIncidencia();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }
        public void NotificarIncidencia()
        {
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            incidencias = dbSqlConnection.GetIncidenciasNotificar();
            for (var i = 0; i < incidencias.Count(); i++)
            {
                ResultadoEnvio result = dbSqlConnection.enviarCorreo(incidencias[i], email, smtp);
            }
        }
        /*public void SendMailAttachment(P_NotifyReminderEntity objParameters)
        {
            try
            {
                DMailAttachmentData = new NotifyReminderData();
                DMailAttachmentData.SendMailAttachment(objParameters);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "MailAttachmentLogic: Finalizó Método [SendMailAttachment]");
                throw ex;
            }
        }*/
        void feqProcessVh_Elapsed(object sender, ElapsedEventArgs e)
        {
            var horaActual = GetLimaDateTimeNow().TimeOfDay;
            if (horaActual >= StartTime && horaActual <= EndTime)
            {
                if (feqProcessDay == null)
                {
                    feqProcessDay = new Timer(int.Parse("180000"));
                    feqProcessDay.Elapsed += feqProcessDay_Elapsed;
                }
                if (!feqProcessDay.Enabled && !InProcess)
                {
                    InProcess = true;

                    Run();
                    feqProcessDay.Start();
                }
            }
            else
            {
                if (feqProcessDay != null && feqProcessDay.Enabled)
                {
                    InProcess = false;
                    feqProcessDay.Stop();
                }
            }
        }
        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }
    }
}
