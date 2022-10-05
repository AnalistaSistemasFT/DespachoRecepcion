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
    public partial class SincronizacionInventario : Form
    {
        CProduccionesCerradas coneProd;
        public SincronizacionInventario(string sucursal)
        {
            InitializeComponent();
            this.coneProd = new CProduccionesCerradas();
            cargardatosinicio(sucursal);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }
        public void cargardatosinicio(string sucursal) 
        {
            string consulta = String.Format("select tblMovSync.ordenid,tblMovSync.centrotrabajo,tblMovSync.fecha,tblMovSync.fechacierre,tblmovsync.tipoorden,tblmovsync.status," +
                "tblmovsync.ordenligada,tblmovsync.ItemFLigado,tblmovsync.esdecliente from tblMovSync where status IN ('OPEN','SUSPEND') and sucursalid={0} and fecha>'23/08/2012 20:00:00' " +
                "order by fecha",sucursal);
            DataSet dd = this.coneProd.recojerdatos(consulta);
            this.gridControl1.DataSource = dd.Tables[0];
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //CARGAMOS LOS DATOS DE LA CELDA
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();

            string ord = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            this.labelX3.Text = "Nro Orden "+ord;
            this.labelX5.Text = this.labelX3.Text;

            string consulta = String.Format("SELECT MD.ItemPV [Item],I.DESCRIPCION,MD.Cantidad,MD.Unidad,md.precioton,md.CostoUnitario,MD.ItemF,md.Calidad,md.peso,md.piezas,md.porcdistribucion "+ 
                                            " FROM(tblMovSync M INNER JOIN tblMovSyncDet MD ON M.OrdenId = MD.OrdenId) INNER JOIN tblItem I ON I.ItemId = MD.ItemPV "+
                                            " WHERE M.OrdenId = '{0}' AND MD.TipoMovimiento = 2 ",ord);
            DataSet dd = this.coneProd.recojerdatos(consulta);
            this.gridControl2.DataSource = dd.Tables[0];

            consulta = String.Format("SELECT MD.ItemPV [Item],I.DESCRIPCION,MD.Cantidad,MD.Unidad,md.precioton,md.CostoUnitario,MD.ItemF,md.Calidad,md.peso,md.piezas,md.porcdistribucion "+
                                        " FROM(tblMovSync M INNER JOIN tblMovSyncDet MD ON M.OrdenId = MD.OrdenId) INNER JOIN tblItem I ON I.ItemId = MD.ItemPV "+
                                        " WHERE M.OrdenId = '{0}' AND MD.TipoMovimiento = 1 ",ord);
            dd = null;
            dd = this.coneProd.recojerdatos(consulta);
            this.gridControl3.DataSource = dd.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
