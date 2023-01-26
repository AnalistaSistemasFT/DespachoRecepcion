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
using CRN.Entidades;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.Localizacion.Celdas
{
    public partial class frmListaCeldas : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        int Id_Sucursal = 0;
        string _CeldaId = string.Empty;

        public frmListaCeldas(Usuario user, int sucursalId, string sucursallocal)
        {
            InitializeComponent();
            txtIdSucursal.Text = sucursalId.ToString();
            txtNomAlmac.Text = sucursallocal;
            Id_Sucursal = sucursalId;
            C_Celdas = new CCeldas();
            TraerData();
        }

        private void TraerData()
        {
            try
            {
                DataSet _listCeldas = C_Celdas.TraerListaCeldas(Id_Sucursal);
                gridControl1.DataSource = _listCeldas.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("############################ = " + err.ToString());
            }
        }
        private void btnAddCelda_Click(object sender, EventArgs e)
        {
            try
            {
                var myForm = new AgregarCelda(Id_Sucursal);
                myForm.FormClosed += F2_FormClosed;
                myForm.Show();
            }
            catch(Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void btnEditCelda_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    _CeldaId = view.GetRowCellDisplayText(row[0], view.Columns[0]).ToString();
                    int _Area = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                    string _Segmento = view.GetRowCellDisplayText(row[0], view.Columns[3]).ToString();
                    int _Nave = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[4]));
                    string _Columna = view.GetRowCellDisplayText(row[0], view.Columns[5]).ToString();
                    string _Estado = view.GetRowCellDisplayText(row[0], view.Columns[6]).ToString();
                    int _Unidades = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[1]));

                    if (_CeldaId != string.Empty)
                    {
                        var myForm = new EditarCelda(_CeldaId, Id_Sucursal, _Area, _Segmento, _Nave, _Columna, _Estado, _Unidades);
                        myForm.FormClosed += F2_FormClosed;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            TraerData();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView1.OptionsFind.AlwaysVisible == true)
            {
                gridView1.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView1.OptionsFind.AlwaysVisible == false)
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
        }
    }
}