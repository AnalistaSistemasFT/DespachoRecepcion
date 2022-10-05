using CRN.Componentes;
using CRN.Entidades;
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
    public partial class frmaddOrdenProd : Form
    {
        COrdenProduccionV2 corden;
        private string sucursalP;
        CCatTablas ensayo;
        string sCentro;

        private string IDtabla;
        private string grupo;
        private string center;
        private int ID_Empleado;
        private string sUser;
        private Usuario user;
        private string item;

        public frmaddOrdenProd(string CentroT, Usuario u)
        {
            InitializeComponent();
            ensayo = new CCatTablas();
            sCentro = CentroT;
            CargarEnsayos(sCentro);
            ID_Empleado = u.EmpleadoId;
            sUser = u.Login;
            user = u;
        }
        public void CargarEnsayos(string workcenter)
        {
            
            string consulta = String.Format("select OPR_PO,OPR_WORKCENTER as CENTRO,OPR_PRODUCT_GROUP,OPR_PRODUCT_CODE,	OPR_PRODUCT_DESC,OPR_QTY,OPR_QTY_UM,OPR_STATUS,OPR_SCHEDULED_DATE, opr_feature_group as Grupo from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_PRO_OPR] where opr_status = 'INPR' and OPR_WORKCENTER in("+ workcenter + ")");
            DataSet data = ensayo.retornarTabla(consulta);
            this.gridControl1.DataSource = data.Tables[0];
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            IDtabla = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            grupo = (view.GetRowCellDisplayText(row[0], view.Columns[9])).ToString();
            center = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
            item = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
           
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ///doble click para poner en proceso una orden
            frmNuevaOrden nuevo = new frmNuevaOrden(item, grupo, IDtabla, center, ID_Empleado,1,user);
           
            this.Hide();
            nuevo.ShowDialog();
        }

        private void frmaddOrdenProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmOrdenAbiertaNew frmNew = new frmOrdenAbiertaNew(sCentro, user);
            frmNew.Show();

        }
    }
}
