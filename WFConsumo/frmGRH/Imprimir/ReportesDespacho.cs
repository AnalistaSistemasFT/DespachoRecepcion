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
        DataSet _data;

        public ReportesDespacho(DataSet data, string TipoReporte)
        {            
            InitializeComponent();
            _tipoReporte = TipoReporte;
            _data = data;
            CargarReporte();
        }
        private void CargarReporte()
        {
            if(_tipoReporte == "AUTORIZADOS")
            {
                DespachosAutorizados _autorizados = new DespachosAutorizados();
                // _autorizados.SetDatabaseLogon("sa", "PlantaV.", @"192.168.0.200", "LYBK");
                //_autorizados.SetDatabaseLogon("sa", "Passw0rd", "10.10.100.26", "LYBK");
                _autorizados.SetDataSource(_data.Tables[0]);
                _autorizados.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _autorizados;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
            else if(_tipoReporte == "AUTHORIZADOS-PARCIAL")
            {
                DespachosAutorizadosParcial _autorizadosParcial = new DespachosAutorizadosParcial();
                _autorizadosParcial.SetDatabaseLogon("sa", "PlantaV.", @"192.168.0.200", "LYBK");
                _autorizadosParcial.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _autorizadosParcial;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
            else if(_tipoReporte == "ORDENCARGA")
            {
                OrdenCarga _orden = new OrdenCarga();
                _orden.SetDatabaseLogon("sa", "PlantaV.", @"192.168.0.200", "LYBK");
                _orden.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _orden;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
            else if (_tipoReporte == "ORDENCARGA-PARCIAL")
            {
                OrdenCargaParcial _ordenParcial = new OrdenCargaParcial();
                _ordenParcial.SetDatabaseLogon("sa", "PlantaV.", @"192.168.0.200", "LYBK");
                _ordenParcial.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _ordenParcial;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            } 
            else if(_tipoReporte == "ORDENENTREGA")
            {
                OrdendeEntrega _ordenEntrega = new OrdendeEntrega();
                //_ordenEntrega.SetDatabaseLogon("sa", "PlantV.", "10.10.100.26", "LYBK");
                _ordenEntrega.SetDatabaseLogon("sa", "PlantaV.", @"192.168.0.200", "LYBK");
                _ordenEntrega.SetParameterValue("DespachoId", _idDespacho);
                crystalReportViewer1.ReportSource = _ordenEntrega;
                crystalReportViewer1.Refresh();
                crystalReportViewer1.Zoom(70);
            }
        }
    }
}
