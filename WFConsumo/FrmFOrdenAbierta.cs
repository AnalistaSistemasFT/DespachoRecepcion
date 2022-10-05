using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class FrmFOrdenAbierta : Form
    {
        private string centro;
        COrdenProduccionV2 corden;
        CProduccionMateriaPrima cmateria;
        private string itemid, ordenid, operador;
        public string seleccionadoLocal;
        public FrmFOrdenAbierta(string operador,string centro)
        {
            InitializeComponent();
            seleccionadoLocal = centro;           
            this.corden = new COrdenProduccionV2();
            this.cmateria = new CProduccionMateriaPrima();
            nombrepc();
            cargardata();
            this.operador = operador;            
                     
        }

      
        void nombrepc() 
        {
            string t = System.Environment.GetEnvironmentVariable("MachineName");
            string n=System.Environment.MachineName.ToString();
            this.centro= "MALLAO";
            //select * from tblOrdenProduccion where sCentroTrabajo = s;
            this.labelX3.Text = n;
        }
        public void cargardata() 
        {
            string consulta = String.Format("select * from tblOrdenProduccion where sCentroTrabajo = '{0}' and status='INPR'", this.centro);
            // string consulta = String.Format("select * from tblOrdenProduccion where sCentroTrabajo = '{0}' and status='{1}'", this.centro, "INPR");
            var data=this.corden.retornarTabla(consulta);
            this.gridControl1.DataSource = data.Tables[0];
            this.gridView1.Columns["iCorrelativo"].Visible=false;
            //tblOrdenProduccionDetalle ///tabla guardar
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click de enproceso
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            this.ordenid = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
            this.itemid = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
            labelX6.Text="ORDEN = "+ordenid;
            llenarmateriaprima();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ordenid!=null)
            {
                frmMateriaPrima frmmat = new frmMateriaPrima(this.ordenid, this.itemid, this.operador, 0);
                frmmat.ShowDialog();
                llenarmateriaprima();
            }
            else
                MessageBox.Show("Seleccione una orden antes de cargar la materia prima ! ","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);          
        }
        void llenarmateriaprima() 
        {
            string consulta = String.Format("select * from tblOrdenProduccionDetalle where OrdenId='{0}' and Tipo='C'", this.ordenid);
            var data=this.cmateria.traerDatos(consulta);
            this.gridControl2.DataSource = data.Tables[0];
            consulta = String.Format("select * from tblOrdenProduccionDetalle where OrdenId='{0}' and Tipo='P'", this.ordenid);
            data = this.cmateria.traerDatos(consulta);
            this.gridControl3.DataSource = data.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {           
            if (this.ordenid!=null)
            {
                frmMateriaPrima frmmat = new frmMateriaPrima(this.ordenid, this.itemid, this.operador, 1);
                frmmat.ShowDialog();
                llenarmateriaprima();
            }else
                MessageBox.Show("Seleccione una orden antes de cargar la materia prima ! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
