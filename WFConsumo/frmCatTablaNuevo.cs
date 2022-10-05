using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraGrid;
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
    public partial class frmCatTablaNuevo : Form
    {
        CCatTablas catTab;
        CatTabla tablacat;
        List<CatTablaDetalle> tabladetalle;
        CCatTablaDetalle cattabladetalle;
        private int indexrow;
        private int IDTabla;
        public frmCatTablaNuevo(int idCatParte)
        {
            InitializeComponent();
            this.txtid.Text = idCatParte + "".ToString();
            catTab = new CCatTablas();
            tabladetalle = new List<CatTablaDetalle>();
            cattabladetalle = new CCatTablaDetalle();
            CargarCombos();
            if(idCatParte==0)
            {
                DataTable d = new DataTable();
                d.Columns.Add("VALOR");
                d.Columns.Add("MINIMO");
                d.Columns.Add("MAXIMO");
                this.gridControl1.DataSource = d;           
            }            
            IDTabla = idCatParte;
        }
        public void CargarCombos() 
        {
            string consulta = "select * from tblCatUnidad where not tipo IS NULL order by unidad asc";
            DataSet data1 = catTab.retornarTabla(consulta);
            this.combounidad.DataSource = data1.Tables[0];
            this.combounidad.DisplayMember = "Descripcion";
            this.combounidad.ValueMember = "Unidad";

            consulta = "SELECT CGR_GROUP_CODE as grupo,[CGR_CODE_DESC] +'--('+CGR_FEATURE_GROUP+')'  as Descripcion FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_GROUPS]";
            data1 = catTab.retornarTabla(consulta);
            this.combotipoproducto.DataSource = data1.Tables[0];
            this.combotipoproducto.DisplayMember = "Descripcion";
            // or grupo
            this.combotipoproducto.ValueMember = "grupo";
        }
        public void CargarPaEditar()
        {
            string consulta = String.Format("select TablaId,Descripcion, CGR_GROUP_CODE,unidad  from tblcattabla inner join [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_GROUPS] on tblCatTabla.TipoProducto =CGR_GROUP_CODE  where TablaId={0}", IDTabla);
            DataSet datalocal = catTab.retornarTabla(consulta);
            foreach (DataRow item in datalocal.Tables[0].Rows)
            {
                this.txtdescripcion.Text = item[1].ToString();
                this.combotipoproducto.SelectedValue = item[2].ToString();
                this.combounidad.SelectedValue = item[3].ToString();
            }
            consulta = String.Format("SELECT valor as VALOR,minimo AS MINIMO,maximo AS MAXIMO FROM tblCatTabladetalle where TablaId={0}",IDTabla);
            datalocal = catTab.retornarTabla(consulta);            
            this.gridControl1.DataSource = datalocal.Tables[0];                      
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }     
        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = gridControl1.DataSource as DataTable;
            DataRow datarow;
            datarow = dt2.NewRow();
            datarow[0]=decimal.Parse("0");
            datarow[1] = decimal.Parse("0");
            datarow[2] = decimal.Parse("0");           
            dt2.Rows.Add(datarow);
            //this.gridView1.AddNewRow();
            
          //  gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Name"], "Please enter new value");
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            if (indexrow > -1)
                this.gridView1.DeleteRow(indexrow);
                             
            
            indexrow = -1;
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;           
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                tablacat = new CatTabla();
                tablacat.Descripcion = this.txtdescripcion.Text.ToString();
                tablacat.TipoProducto = this.combotipoproducto.SelectedValue.ToString();
                tablacat.Unidad = this.combounidad.SelectedValue.ToString();
                tablacat.Campo = " ";
                tablacat.TtablaId = IDTabla == 0 ? (BuscarId() + 1) : IDTabla;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    DataRow f = gridView1.GetDataRow(i);
                    tabladetalle.Add(new CatTablaDetalle()
                        {
                         Tablaid=tablacat.TtablaId,
                          Min=decimal.Parse(f[1].ToString()),
                          Max=decimal.Parse(f[2].ToString()),
                          Nominal=decimal.Parse(f[0].ToString())
                        });
                }
                if (IDTabla == 0)
                {                                    
                    catTab.GuardarTablaNuevo(tablacat, tabladetalle);
                    MessageBox.Show("AGREGADO CORRECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {                                
                    catTab.ModificarCatTabla(tablacat,tabladetalle);
                    MessageBox.Show("ACTUALIZADO CORRECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Hubo un error al realizar la accion, compruebe que los datos tengan el formato correcto. Msg => "+ee,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }
        public int BuscarId() 
        {
            string consulta = "SELECT distinct TOP 1 (TablaId) FROM   tblcattabla  ORDER BY tablaid DESC";
            DataSet data4 = catTab.retornarTabla(consulta);
            int s = 0;
            foreach (DataRow item in data4.Tables[0].Rows)
            {
                s = int.Parse(item[0].ToString());
            }
            return s;
        }
        private void frmCatTablaNuevo_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexrow = e.RowHandle;
            
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //verificar que solo entren numeros
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            //MessageBox.Show("CARGADO");
            double n = 0;
            bool d = Double.TryParse(e.Value.ToString(), out n);
            if (!d)
            {
                view.SetRowCellValue(e.RowHandle, view.Columns[e.Column.ToString()=="VALOR"?0:(e.Column.ToString()=="MINIMO"?1:2)], n);
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexrow = e.RowHandle;            
        }

   
    }

}
