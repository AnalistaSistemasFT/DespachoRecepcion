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
using WFConsumo.frmGRH.Localizacion.Celdas;
using CRN.Componentes;

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class frmListaAlmacen : DevExpress.XtraEditors.XtraForm
    {
        int _IdSucursal = 0;
        Usuario _user;
        string _NomSucursal = string.Empty;
        CCeldas C_Celdas;
        int _AlmacenId = 0;

        public frmListaAlmacen(Usuario user, int sucursalId, string sucursallocal)
        {
            InitializeComponent();
            _IdSucursal = sucursalId;
            _user = user;
            C_Celdas = new CCeldas();
            _NomSucursal = sucursallocal;
            txtNomAlmac.Text = sucursallocal;
            txtIdSucursal.Text = sucursalId.ToString();
            GetData();
        }

        public void GetData()
        {
            try
            {
                DataSet listAlmId = C_Celdas.BuscarAlmacenId(_IdSucursal);
                foreach(DataRow item in listAlmId.Tables[0].Rows)
                {
                    _AlmacenId = Convert.ToInt32(item[0] is DBNull ? 0 : item[0]);
                }
                if(_AlmacenId > 0)
                {
                    DataSet listData = C_Celdas.TraerDetalleAlmacen(_IdSucursal, _AlmacenId);
                    gridControl1.DataSource = listData.Tables[0];
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
            }
        }
        private void btnPlanificar_Click(object sender, EventArgs e)
        {
            var myForm = new VistaAlmacen(_IdSucursal);
            myForm.Show();
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            var myForm = new BuscarPaquetes(_IdSucursal);
            myForm.Show();
        }

        private void btnCeldas_Click(object sender, EventArgs e)
        {
            var myForm = new frmListaCeldas(_user, _IdSucursal, _NomSucursal);
            myForm.Show();
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