using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using CRN.Componentes;

using CrystalDecisions.Shared;
using WFConsumo.frmGRH.Imprimir;
using WFConsumo.Reportes;

namespace WFConsumo.frmGRH.Imprimir
{
    public partial class ReportesDespacho : Form
    {
        string _tipoReporte = string.Empty;
        string _idDespacho = "";
        ParameterFields param = new ParameterFields();
        public ReportesDespacho(string IdDespacho, string TipoReporte)
        {            
            InitializeComponent();
            _idDespacho = IdDespacho;
            _tipoReporte = TipoReporte;
            CargarReporte();
            txtDespacho.Text = IdDespacho;
        }
        private void CargarReporte()
        {
            if(_tipoReporte == "AUTORIZADOS")
            {
                DespachosAutorizados _autorizados = new DespachosAutorizados();
                _autorizados.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                _autorizados.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _autorizados;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
            else if(_tipoReporte == "ORDENCARGA")
            {
                OrdenCarga _orden = new OrdenCarga();
                _orden.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                _orden.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _orden;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
        }
    }
}
