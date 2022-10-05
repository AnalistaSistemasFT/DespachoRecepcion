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
    public partial class ProduccionesCerradas : Form
    {

        CProduccionesCerradas coneProd;
        private string sucursalId;
        private DataSet data1;
        private DataSet data2;
        public ProduccionesCerradas(string sucursal)
        {
            InitializeComponent();
            this.coneProd = new CProduccionesCerradas();
            this.sucursalId = sucursal;
            cargardatosGrid1();
        }

        public void cargardatosGrid1() 
        {
            string consul = String.Format("select opr_po as Orden,opr_product_code as ItemId,opr_product_desc as Descripcion,opr_status_date as Fecha,opr_qty as CANTIDAD,OPR_QTY_UM AS UNIDAD, "+
                            " opr_workcenter as Centro, opr_status as Status from ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR inner join "+
                            " tblCentroTrabajo on OPR_WORKCENTER collate Modern_Spanish_CI_AS = tblCentroTrabajo.CentroId "+ 
                            " where opr_po collate Modern_Spanish_CI_AS not in (select ordenid from tblMovSync) and tblCentroTrabajo.sincronizacion = 'TRUE' AND OPR_STATUS = 'CLOS' AND "+
                            "   OPR_status_date >= tblCentroTrabajo.FechaInicioSync AND sucursalid = {0}",this.sucursalId);
            DataSet datos = this.coneProd.recojerdatos(consul);
            this.gridControl1.DataSource = datos.Tables[0];
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
           
            string ord = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            string item = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
            //EJECUTAREMMOS CONSULTAS PARA MOSTRAR EN CONSUMIDO Y PRODUCIDO
            //CONSUMIDO
            string consulta = String.Format("SELECT fbc_product_code as itemid,tblitem.Descripcion,round(sum([FCS_CONSUMED_QTY]),2) "
                +" as peso,SUM(FBC_PIECE ) as piezas,0 as Metros,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor FROM "
                 + "  (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) "
            +" left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid  WHERE FCS_PO  = '{0}' group by "
           +" fbc_product_code,tblitem.Descripcion,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor ", ord);
            DataSet datos=this.coneProd.recojerdatos(consulta);
            this.data1 = datos;
            this.gridControl2.DataSource = datos.Tables[0];
            //PRODUCIDO
            consulta = String.Format("select fbc_product_code as itemid,tblitem.Descripcion,round(SUM(FBC_WEIGHT),2) "
                      +  "as peso,SUM(FBC_PIECE) as piezas,round(sum(FBC_Meters),2) as Metros,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor "
             +"from ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid  "
            + "WHERE Fbc_pO = '{0}' group by fbc_product_code,tblitem.Descripcion,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor ", ord);
            datos = null;
            datos = this.coneProd.recojerdatos(consulta);
            this.data2 = datos;
            this.gridControl3.DataSource = datos.Tables[0];

            consulta = String.Format("select * from tblCentroTrabajo where CentroId = '{0}'", item);
            var pruebj = this.coneProd.recojerdatos(consulta).Tables[0];
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                string ord = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                string item = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                string centro = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                string cantidad = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                string unidad = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();

                SincronizarAgregar frmv = new SincronizarAgregar(this.sucursalId, item, ord,centro,cantidad,unidad,data1,data2);
                frmv.ShowDialog();

            }
            catch (Exception ee)
            {
                
            }
            
        }
    }
}
