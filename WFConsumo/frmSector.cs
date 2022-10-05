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
    public partial class frmSector : Form
    {
        Sector sec = new Sector();
        CSector csec = new CSector();
        CCentroTrabajo centrotrab;
        private string centroD;
        private int sectoRR;
        private int refe1;
        private int filaP;
        public frmSector(string sucursal1, int IdUser)
        {
            InitializeComponent();
            centrotrab = new CCentroTrabajo();
            llenarcentros_Trabajo(Entidades.utilitario.iSucursal);
           // cargarSectores();
        }
        public void cargarSectores(string centro)
        {
            string consulta = String.Format("select * from tblsector where id_centro='{0}'",centro);
            DataSet dat = csec.retornarTabla(consulta);
            this.gridControl1.DataSource = dat.Tables[0];        
        }
        public void llenarcentros_Trabajo(int sucursal)
        {
            DataSet d = centrotrab.TraerxCentro(sucursal);
            // this.gridControl3.DataSource = d.Tables[0];
            this.listView1.Items.Clear();
            foreach (DataRow item in d.Tables[0].Rows)
            {
                this.listView1.Items.Add(item[0].ToString());
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            NuevoSubItems nuev = new NuevoSubItems(centroD, "Centro");
            nuev.cargarcentros("SE");
            nuev.ShowDialog();
            cargarSectores(centroD);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int d = int.Parse(listView1.Items.IndexOf(listView1.SelectedItems[0]).ToString());
                centroD = listView1.Items[d].Text.ToString();
                this.labelX4.Text = "Centro de Trabajo " + centroD;
                cargarSectores(centroD);
            }   
        }
        private void cargarsectores(string centro) 
        { 
            string consulta = String.Format("",centro);        
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            NuevoSubItems nuev = new NuevoSubItems(centroD, "Referencia 1");
            nuev.ref1 = refe1;
            nuev.sector = sectoRR;
            nuev.filaPrincipal = filaP;
            nuev.cargarcentros("R2");
            nuev.ShowDialog();
            cargarSectores(centroD);
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            NuevoSubItems nuev = new NuevoSubItems(centroD, "Referencia 0");
            nuev.sector = sectoRR;
            nuev.filaPrincipal = filaP;
            nuev.cargarcentros("R1");
            nuev.ShowDialog();
            cargarSectores(centroD);
            cargarParam2(refe1);
            cargarParam1(sectoRR);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click en la celdade una fila grid1
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            int idsector = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString());
            filaP = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            cargarParam1(idsector);
            this.gridView3.Columns.Clear();
        }
        public void cargarParam1(int idsector) 
        {
             sectoRR=idsector;
            string sentencia = String.Format("select tbl.id_parametro1,catP.parametro_desc from tblsector as tbl,Cat_Parametro as catP where tbl.id_parametro1=catP.id_parametro and tbl.id_parametro={0} and tbl.id_centro='{1}'",idsector,centroD);
            DataSet dat = csec.retornarTabla(sentencia);
            this.gridControl2.DataSource = dat.Tables[0];
        }
        public void cargarParam2(int idref1) 
        {
            string sentencia = String.Format("select tbl.id_parametro2,catP.parametro_desc from tblsector as tbl,Cat_Parametro as catP where tbl.id_parametro2=catP.id_parametro and tbl.id_parametro={0} and tbl.id_centro='{1}'", sectoRR, centroD);
            DataSet dat = csec.retornarTabla(sentencia);
            this.gridControl3.DataSource = dat.Tables[0];
        }
        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click en la celda de una fila del grid2
            ColumnView view = this.gridControl2.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            refe1 = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            cargarParam2(refe1);
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
