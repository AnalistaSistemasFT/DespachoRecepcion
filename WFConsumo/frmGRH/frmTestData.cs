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

namespace WFConsumo.frmGRH
{
    public partial class frmTestData : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 12081;
        string _Usuario = "User123";
        DataTable dataOrden = new DataTable();
        DataTable dataOrden2 = new DataTable();
        DataTable dataOrden3 = new DataTable();
        CNroOrden C_NroOrden;
        CItem C_Item;
        public frmTestData()
        {
            InitializeComponent();
            C_NroOrden = new CNroOrden();
            C_Item = new CItem();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                int _idSucursalDestino = 12080;
                //DataSet dataLista = C_Item.TraerTodoItem();
                //dataOrden = dataLista.Tables[0];
                //this.gridControl1.DataSource = dataOrden;

                //DataSet dataLista2 = C_NroOrden.TraerTodo2();
                //dataOrden2 = dataLista2.Tables[0];
                //this.gridControl2.DataSource = dataOrden2;

                //DataSet dataLista3 = C_NroOrden.TraerTodo(_idSucursalDestino);
                //dataOrden3 = dataLista3.Tables[0];
                //this.gridControl1.DataSource = dataOrden3;

                dataOrden2.Columns.Add("Nombre");
                dataOrden2.Columns.Add("Entregado");
                dataOrden2.Columns.Add("Total");
                dataOrden2.Columns.Add("Pendiente");

                dataOrden2.Rows.Add(new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit", 20, 100, 80});
                dataOrden2.Rows.Add(new object[] { "sed do eiusmod tempor incididunt", 20, 100, 80 });
                dataOrden2.Rows.Add(new object[] { "ut labore et dolore magna aliqua", 20, 100, 80 });
                dataOrden2.Rows.Add(new object[] { "Ut enim ad minim veniam", 20, 100, 80 });
                dataOrden2.Rows.Add(new object[] { "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat", 20, 100, 80 });
                dataOrden2.Rows.Add(new object[] { "Duis aute irure dolor in reprehenderit", 20, 100, 80 });
                //gridControl1.DataSourceID = null;
                this.gridControl2.DataSource = dataOrden2;
                this.gridControl1.DataSource = dataOrden2;
            }
            catch(Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
    }
}