using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.Reportes;

namespace WFConsumo
{
    public partial class ReporteNoConforme : Form
    {

        public ReporteNoConforme()
        {
            InitializeComponent();
        }
        private void crystalReportViewer3_Load(object sender, EventArgs e)
        {

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            int d = int.Parse(this.textBoxX1.Text.ToString());
            reporteporte cr = new reporteporte();
            cr.SetParameterValue("inoconforme", d);
            crystalReportViewer4.ReportSource = cr;
            crystalReportViewer4.Refresh();   
        }
        public void redirigirRemoto(int idform) 
        {
            reporteporte cr = new reporteporte();
            cr.SetParameterValue("inoconforme", idform);
            crystalReportViewer4.ReportSource = cr;
            crystalReportViewer4.Refresh();        
        }
    }
}
