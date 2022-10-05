using CRN.Componentes;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmGenCC : DevExpress.XtraEditors.XtraForm
    {
        CRecepcion oDetalle;
        public frmGenCC()
        {

            InitializeComponent();
          
          
           
        }

        private void CargarGrid(string sAnotacion)
        {
            oDetalle = new CRecepcion();
            DataSet dtsLista = oDetalle.TraerDetalleAnotacion(sAnotacion);
            dgvDetalle.DataSource = dtsLista.Tables[0];
            //FormatoGrid();
        }

        
     

       

        private void FormatoGrid()
        {
            gridView2.Columns["sNroFac"].Caption = "NroFac";
            gridView2.Columns["iItem_id"].Caption = "Item";
            gridView2.Columns["scmadesc"].Caption = "Descripcion";
            gridView2.Columns["sColada"].Caption = "Colada";
            gridView2.Columns["sSerie"].Caption = "Serie";
            gridView2.Columns["dPeso"].Caption = "Peso Bruto";
            gridView2.Columns["dPesoNeto"].Caption = "Peso Neto";
            gridView2.Columns["dPesocc"].Caption = "Peso CC";

            gridView2.Columns["idetalle_id"].Visible = false;
            gridView2.Columns["iNroRec"].Visible = false;
            gridView2.Columns["iPedido_id"].Visible = false;
            gridView2.Columns["dtFechaReg"].Visible = false;

            gridView2.Columns["sNroFac"].Width = 80;
            gridView2.Columns["iItem_id"].Width = 50;
            gridView2.Columns["scmadesc"].Width = 170;
            gridView2.Columns["sColada"].Width = 90;
            gridView2.Columns["sSerie"].Width = 90;
            gridView2.Columns["dPeso"].Width = 60;
            gridView2.Columns["dPesoNeto"].Width = 60;
            gridView2.Columns["dPesocc"].Width = 60;
        }

      

       

       

       

        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.CargarGrid(txtdocumento.Text);
            }
        }

        private void barInsertar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recepcion.frmCC ofrmcc = new Recepcion.frmCC();
            ofrmcc.ShowDialog();
        }
        //private void barInsertar_ItemClick(object sender, ItemClickEventArgs e)
        //{

        //}
    }
}