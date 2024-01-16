using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio.Alertas.SGR
{
    public partial class frmWindowsService : Form
    {
        Service servicio = new Service();
        private System.Windows.Forms.Timer timer;
        public frmWindowsService()
        {
            InitializeComponent();
        }

        private void Iniciar(object sender, EventArgs e)
        {
            try
            {
               //timer = new System.Windows.Forms.Timer();
               //timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["IntervaloServicio"]);
               //timer.Enabled = true;
               //timer.Tick += new EventHandler(servicio.NotificarIncidencia);

            }
            catch(Exception err)
            {
                throw;
            }
            
        }
    }
}
