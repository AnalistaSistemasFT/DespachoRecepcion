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

namespace WFConsumo.frmGRH.DespachoOrdenEnProceso
{
    public partial class AbrirPaquete : DevExpress.XtraEditors.XtraForm
    {
        int _cantPaq = 0;
        int _cantRetirar = 0;
        decimal _psoUnd = 0;
        decimal _psoTotal = 0;
        string _codigoPaq = "0";
        CPaquetes C_Paquetes;
        DataTable dataT = new DataTable();
        int _PiezasRet = 0;
        decimal _PesoRet = 0;
        public AbrirPaquete(string IdDespacho, string _codigoPr, int _CantidadPaq, decimal _PesoUnidad, decimal pso)
        {
            InitializeComponent();
            labelCodigo.Text = IdDespacho;
            labelCantPaq.Text = _CantidadPaq.ToString();
            labelDesp.Text = _codigoPr;
            labelPesoPaq.Text = (_CantidadPaq * _PesoUnidad).ToString("0.###") + " Kg.";
            _codigoPaq = _codigoPr;
            _cantPaq = _CantidadPaq;
            _psoUnd = _PesoUnidad;
            _psoTotal = pso;
            TraerData();
            C_Paquetes = new CPaquetes();
            TraerData();
        }
        private void TraerData()
        {
            try
            {
                if(_codigoPaq != null)
                {
                    string _IdPaquete = _codigoPaq;
                    DataSet dataLista = C_Paquetes.TraerDatosAbrirPaq(_IdPaquete);
                    foreach (DataRow item in dataLista.Tables[0].Rows)
                    {
                        _PiezasRet = _PiezasRet + Convert.ToInt32(item[0]);
                        _PesoRet = _PesoRet + Convert.ToDecimal(item[1]);
                    }
                }
                else
                {
                    Console.WriteLine("####################### Codigo Paquete= " + _codigoPaq.ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void AbrirPaquete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["ListaLecturado"].Enabled = true;
            }
        }
        private void txtCantRetirar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _cantRetirar = Convert.ToInt32(txtCantRetirar.Text);
                if (_cantRetirar > _cantPaq)
                {
                    txtCantRetirar.Text = _cantPaq.ToString();
                    _cantRetirar = Convert.ToInt32(txtCantRetirar.Text);
                }
                
                labelSaldoAlm.Text = (_cantPaq - _cantRetirar).ToString();
                labelPsoCrg.Text = (_cantRetirar * _psoUnd).ToString("0.###") + " Kg.";
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCantRetirar.Text) || (!string.IsNullOrEmpty(txtCantRetirar.Text)))
            {
                try
                {
                    string _IdPaquete = _codigoPaq;
                    int piezasEntr = Convert.ToInt32(txtCantRetirar.Text);
                    decimal pesoEntr = _cantRetirar * _psoUnd;
                    int _PiezasEnt = _PiezasRet + piezasEntr;
                    decimal _PesoEnt = _PesoRet + pesoEntr;
                    if (_PiezasEnt > _cantPaq)
                    {
                        XtraMessageBox.Show("Piezas a entregegar" + _PiezasEnt.ToString());
                        XtraMessageBox.Show("Cantidad de Piezas" + _cantPaq.ToString());
                    }
                    
                    int _PiezaAct = _cantPaq - piezasEntr;
                    decimal _PesoAct = _psoTotal - pesoEntr;
                    int EditPaq = C_Paquetes.AbrirPaquete(_IdPaquete, _PiezasEnt, _PiezaAct, _PesoEnt, _PesoAct);
                    if(EditPaq != 0)
                    {
                        XtraMessageBox.Show("Cambios registrados", "Guardado");
                        (this.Owner as ListaLecturado).PaqueteAbierto(_IdPaquete, piezasEntr, pesoEntr);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se pudo registrar los cambios", "Error");
                        this.Close();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Cantidad a retirar' esta vacio", "Error");
            }
        }
    }
}