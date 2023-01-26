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
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.Devoluciones
{
    public partial class frmListaDevoluciones : DevExpress.XtraEditors.XtraForm
    {
        int _IdSucursal = 0;
        string _SucursalNombre = string.Empty;
        Usuario _User;
        int _DevolucionId = 0;

        public frmListaDevoluciones(Usuario user, int sucursalId, string sucursallocal)
        {
            InitializeComponent();
            _IdSucursal = sucursalId;
            _SucursalNombre = sucursallocal;
            _User = user;
        }
        private void TraerDatos()
        {
            try
            {

            }
            catch(Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnAgregarDevolucion_Click(object sender, EventArgs e)
        {
            var myForm = new NuevaDevolucion(_IdSucursal, _SucursalNombre);
            myForm.FormClosed += F2_FormClosed;
            myForm.Show();
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView4.RefreshData();
            TraerDatos();
        }
    }
}