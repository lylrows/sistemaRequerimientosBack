using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Servicio.Alertas.SGR.Connections;
using Servicio.Alertas.SGR.Logic;
using Servicio.Alertas.SGR.Models;

namespace Servicio.Alertas.SGR
{
    public partial class Service : ServiceBase
    {
        private NotificarIncidenciasLogic logic;
        private List<getIncidenciasNotificarDTO> incidencias = new List<getIncidenciasNotificarDTO>();
        private dbSqlConnection dbSqlConnection = new dbSqlConnection();
        private System.Windows.Forms.Timer timer;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["IntervaloServicio"]);
            //timer.Enabled = true;
            //timer.Tick += new EventHandler(NotificarIncidencia);
            //stLapso.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["IntervaloServicio"]);
            logic = new NotificarIncidenciasLogic();
            logic.Start();
        }

        /*public void NotificarIncidencia()
        {
            DatosSMTP smtp = new DatosSMTP();
            DatosEmail email = new DatosEmail();
            incidencias = dbSqlConnection.GetIncidenciasNotificar();
            for(var i= 0;i<incidencias.Count();i++)
            {
                ResultadoEnvio result = dbSqlConnection.enviarCorreo(incidencias[i], email, smtp);
            }
        }*/

        protected override void OnStop()
        {
            logic.Finish();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
