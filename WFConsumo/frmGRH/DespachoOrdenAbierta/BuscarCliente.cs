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
using DevExpress.XtraGrid.Views.Base;
using CRN.Componentes;
using CRN.Entidades;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class BuscarCliente : DevExpress.XtraEditors.XtraForm
    {
        private int _IdCliente = 0;
        private string _NombreCliente;
        CInformix C_Informix;
        DataTable dataC = new DataTable();
        List<ClientesInformix> _listClientes = new List<ClientesInformix>();
        public BuscarCliente()
        {
            InitializeComponent();
            C_Informix = new CInformix();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                DataSet dataList = C_Informix.TraerTodosClientes();
                dataC = dataList.Tables[0];
                foreach(DataRow item in dataList.Tables[0].Rows)
                {
                    _listClientes.Add(new ClientesInformix
                    {
                        p_IdClienteInf = Convert.ToInt32(item[0]),
                        p_NombreInf = item[1].ToString()
                    });
                }
                gridControl1.DataSource = _listClientes;
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void RowCellClickEvent(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _IdCliente = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                _NombreCliente = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void BuscarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmNuevoDespachoMercaderia"].Enabled = true;
            }
        }
        //btnCancelar
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchControl.Text) || (!string.IsNullOrEmpty(searchControl.Text)))
            {
                try
                {
                    string _nc = searchControl.Text;
                    gridControl1.DataSource = _listClientes.Where(x => x.p_NombreInf.ToLower().Contains(_nc.ToLower()));
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
            else
            {
                gridControl1.DataSource = _listClientes;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
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
                    (this.Owner as frmNuevoDespachoMercaderia).ClienteElegido(_IdCliente, _NombreCliente);
                    this.Close();
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo"); 
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
        }
    }
}