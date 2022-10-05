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

namespace WFConsumo.frmGRH.DespachoOrdenListaCerrar
{
    public partial class CerrarEntregar : DevExpress.XtraEditors.XtraForm
    {
        string _idDespacho;
        CPaquetes C_Paquetes;
        CCatChofer C_Chofer;
        List<int> _camionId = new List<int>();
        List<string> _choferId = new List<string>();
        int _IdCamion = 0;
        string _IdChofer = "0";

        public CerrarEntregar(string IdDespacho, string _fecha, string _sucursal, string _camion, string _chofer)
        {
            InitializeComponent();
            C_Paquetes = new CPaquetes();
            C_Chofer = new CCatChofer();
            txtDespachoId.Text = IdDespacho;
            pickerFecha.Text = _fecha;
            txtSuc.Text = _sucursal;
            cmboxCamion.Text = _camion;
            comboxChofer.Text = _chofer;
            _idDespacho = IdDespacho;
            TraerDatos();
            TraerDataCamion();
            TraerDataChofer();
        }
        private void TraerDatos()
        {
            try
            {
                DataSet DataDet = C_Paquetes.BuscarDatosEntrega(_idDespacho);
                this.gridControl1.DataSource = DataDet.Tables[0];
            }
            catch (Exception err)
            {
                Console.WriteLine("##################### = " + err.ToString());
            }
        }
        public void TraerDataCamion()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerPlacas();
                foreach (DataRow Row in dataLista.Tables[0].Rows)
                {
                    cmboxCamion.Properties.Items.Add(Row[1]);
                    _camionId.Add(Convert.ToInt32(Row[0]));
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void TraerDataChofer()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerChoferes();
                foreach (DataRow Row in dataLista.Tables[0].Rows)
                {
                    comboxChofer.Properties.Items.Add(Row[0]);
                    _choferId.Add(Row[1].ToString());
                }

            }
            catch (Exception err)
            {
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnAddCamion_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarCamionLC();
            myForm.Show();
        }
        private void btnAddChofer_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarChoferLC();
            myForm.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception err)
            {
                Console.WriteLine("##################### = " + err.ToString());
            }
        }
        private void cmboxCamion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = cmboxCamion.SelectedIndex;
                if (_camionId.Count() > 0)
                {
                    _IdCamion = _camionId[_data];
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void comboxChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboxChofer.SelectedIndex;
                if (_choferId.Count() > 0)
                {
                    _IdChofer = _choferId[_data];
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
    }
}