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

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class BuscarPaquetes : DevExpress.XtraEditors.XtraForm
    {
        CPaquetes C_Paquetes;
        int _IdSucursal = 0;
        string _IdPaquete = string.Empty;

        public BuscarPaquetes(int _SucursalId)
        {
            InitializeComponent();
            C_Paquetes = new CPaquetes();
            _IdSucursal = _SucursalId;
            searchPaquete.KeyDown += EnterBtn;
        }

        public void TraerData()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchPaquete.Text) || (!string.IsNullOrEmpty(searchPaquete.Text)))
                {
                    _IdPaquete = searchPaquete.Text;
                    DataSet lstPaquete = C_Paquetes.TraerPaqueteBusqueda(_IdPaquete, _IdSucursal);
                    foreach (DataRow item in lstPaquete.Tables[0].Rows)
                    {
                        txtOrden.Text = item[0].ToString();
                        txtCodigo.Text = item[1].ToString();
                        txtCodigoFerro.Text = item[2].ToString();
                        txtDescripcion.Text = item[3].ToString();
                        txtPiezas.Text = item[4].ToString();
                        txtPeso.Text = item[5].ToString();
                        txtSucursal.Text = item[6].ToString() + " - " + item[7].ToString();
                        txtAlmacen.Text = item[8].ToString();
                        txtCelda.Text = item[9].ToString();
                        txtEstado.Text = item[10].ToString();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Campo de busqueda vacio", "Error");
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("########################### = " + err.ToString());
            }
        }
        private void EnterBtn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraerData();
            }
        }
    }
}