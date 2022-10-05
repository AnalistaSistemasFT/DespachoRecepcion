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
using WFConsumo.Reportes;


namespace WFConsumo
{
    public partial class frmReportes : Form
    {
        CEnsayo ensay = new CEnsayo();

        ParameterFields param = new ParameterFields();
        public frmReportes()
        {            
            InitializeComponent();
            //this.EnsayoDataSet = new Microsoft.Reporting.WinForms.ReportDataSource();
            RecojerEmpleados();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EnsayoDataSet.tblEnsayo' table. You can move, or remove it, as needed.
            // this.tblEnsayoTableAdapter.Fill(this.EnsayoDataSet.tblEnsayo);
            //this.reportViewer1.RefreshReport();        
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDatabaseLogon("sa", "PlantaV.");

            cr.SetParameterValue("Orden", this.comboBoxEx1.SelectedValue.ToString());
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();           
          //  ReportParameter param = new ReportParameter("fecha", dateEdit1.EditValue == null ? null : dateEdit1.EditValue.ToString());
          //  ReportParameter param2 = new ReportParameter("fecha2", dateEdit2.EditValue == null ?null : dateEdit2.EditValue.ToString());
          //  int val = this.comboBoxEx1.SelectedValue.ToString() != " " ? int.Parse(this.comboBoxEx1.SelectedValue.ToString()) : -1;
          //  ReportParameter param3 = new ReportParameter("empleado", val.ToString());
          //  this.reportViewer1.LocalReport.SetParameters(param);
          /// this.reportViewer1.LocalReport.SetParameters(param2);
          //  this.reportViewer1.LocalReport.SetParameters(param3);
          //  this.reportViewer1.RefreshReport();
        }
        
        public void RecojerEmpleados() 
        {
            string consulta = "select distinct OrdenId from tblEnsayo ";
            DataSet d=ensay.retornarEnsayo(consulta);
            //d.Tables[0].Rows.Add(0);
            this.comboBoxEx1.DataSource = d.Tables[0];
            this.comboBoxEx1.DisplayMember = "OrdenId";
            this.comboBoxEx1.ValueMember = "OrdenId";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
