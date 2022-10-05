using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class ListaChoferes : DevExpress.XtraEditors.XtraForm
    {
        CCatChofer C_Chofer;
        DataTable dataT = new DataTable();
        DataTable dataB = new DataTable();
        string _nombreB;
        string _nombreChofer;
        string _ciChofer;
        public ListaChoferes()
        {
            InitializeComponent();
            C_Chofer = new CCatChofer();
            TraerData();
        }
        public void TraerData()
        {
            DataSet dataLista = C_Chofer.TraerChoferes();
            dataT = dataLista.Tables[0];
            this.gridControl1.DataSource = dataT;
        }
        public void sb_search(object sender, EventArgs e)
        {
            _nombreB = searchControl1.Text;
            DataSet dataBuscar = C_Chofer.BuscarChofer(_nombreB);
            dataB = dataBuscar.Tables[0];
            this.gridControl1.DataSource = dataB;
        }
        public void gridView1_RowCellClick(Object sender, EventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            _nombreChofer = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            _ciChofer = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
        }
        public void btnAceptar_Click(Object sender, EventArgs e)
        {
            try
            {
                //frmNuevoDespachoMercaderia frmNuevoDespacho = new frmNuevoDespachoMercaderia();
                //frmNuevoDespacho.DataChofer(_nombreChofer, _ciChofer);
                //this.Close();
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void ListaChoferes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmNuevoDespachoMercaderia"].Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}