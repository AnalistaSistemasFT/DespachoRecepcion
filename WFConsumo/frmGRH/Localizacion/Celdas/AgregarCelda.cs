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

namespace WFConsumo.frmGRH.Localizacion.Celdas
{
    public partial class AgregarCelda : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        int _IdSucursal = 0;
        int _EstadoCelda = 0;
        string _NombreCelda = string.Empty;
        int _IdAlmacen = 0;
        int _AreasCnt = 0;
        int _NavesCnt = 0;

        public AgregarCelda(int Id_Sucursal)
        {
            InitializeComponent();
            C_Celdas = new CCeldas();
            _IdSucursal = Id_Sucursal;
            GetDatosAlmacen();
        }
        public void GetDatosAlmacen()
        {
            try
            {
                DataSet listAlm = C_Celdas.BuscarAlmacenId(_IdSucursal);
                foreach(DataRow item in listAlm.Tables[0].Rows)
                {
                    _IdAlmacen = Convert.ToInt32(item[0] is DBNull ? 0 : item[0]);
                    _AreasCnt = Convert.ToInt32(item[1] is DBNull ? 0 : item[1]);
                    _NavesCnt = Convert.ToInt32(item[2] is DBNull ? 0 : item[2]); 
                }
                comBoxEstado.Properties.Items.Add("Habilitado");
                comBoxEstado.Properties.Items.Add("Maquina");
                comBoxEstado.Properties.Items.Add("Oficina");
                comBoxEstado.Properties.Items.Add("Carril");
                comBoxEstado.Properties.Items.Add("NO ASIGNADO");
                txtColumna.Properties.Items.Add("A");
                txtColumna.Properties.Items.Add("B");
                txtColumna.Properties.Items.Add("C");
                txtSegmento.Properties.Items.Add("S1");
                txtSegmento.Properties.Items.Add("S2");
                txtSegmento.Properties.Items.Add("S3");
                for (int i = 1; i <= _AreasCnt; i++)
                {
                    txtArea.Properties.Items.Add(i.ToString());
                }
                for (int i = 1; i <= _NavesCnt; i++)
                {
                    txtNave.Properties.Items.Add(i.ToString());
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("############################## = " + err.ToString());
            }
        }
        public void GetEstado(string _status)
        {
            switch (_status)
            {
                case "Habilitado":
                    _EstadoCelda = 1;
                    break;
                case "Maquina":
                    _EstadoCelda = 2;
                    break;
                case "Oficina":
                    _EstadoCelda = 3;
                    break;
                case "Carril":
                    _EstadoCelda = 4;
                    break;
                case "NO ASIGNADO":
                    _EstadoCelda = 0;
                    break;
                default:
                    _EstadoCelda = 0;
                    break;
            }
        }
        public void GenerarNombre()
        {
            _NombreCelda = "AL" + _IdAlmacen + ":" + txtNave.Text.Trim() + txtColumna.Text.Trim() + "-" + txtArea.Text.Trim() + txtSegmento.Text.Trim();
            txtCelda.Text = _NombreCelda;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        { 
            if (!string.IsNullOrWhiteSpace(txtArea.Text) || (!string.IsNullOrEmpty(txtArea.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtSegmento.Text) || (!string.IsNullOrEmpty(txtSegmento.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(txtColumna.Text) || (!string.IsNullOrEmpty(txtColumna.Text)))
                    {
                        if (!string.IsNullOrWhiteSpace(txtNave.Text) || (!string.IsNullOrEmpty(txtNave.Text)))
                        {
                            if (!string.IsNullOrWhiteSpace(comBoxEstado.Text) || (!string.IsNullOrEmpty(comBoxEstado.Text)))
                            {
                                if (!string.IsNullOrWhiteSpace(txtCelda.Text) || (!string.IsNullOrEmpty(txtCelda.Text)))
                                {
                                    try
                                    {
                                        CRN.Entidades.Celdas _celda = new CRN.Entidades.Celdas();
                                        CCeldas C_Celdas = new CCeldas();

                                        _celda.SucursalId = _IdSucursal;
                                        _celda.CeldaId = txtCelda.Text;
                                        _celda.AlmacenId = _IdAlmacen;
                                        _celda.Area = Convert.ToInt32(txtArea.Text);
                                        _celda.Segmento = txtSegmento.Text;
                                        _celda.Fila = "0";
                                        _celda.Nave = Convert.ToInt32(txtNave.Text);
                                        _celda.Columna = txtColumna.Text;
                                        _celda.ItemId = "Varios";
                                        _celda.Unidades = 0;
                                        _celda.Kgs = 0;
                                        _celda.Status = _EstadoCelda;
                                        _celda.Proceso = "Llenado";
                                        _celda.PreAsignado = 0;
                                        _celda.CeldaTemp = "NN";

                                        int a = C_Celdas.AgregarCelda(_celda);
                                        if (a > 0)
                                        {
                                            XtraMessageBox.Show("Se guardaron los cambios", "AGREGAR");
                                            this.Close();
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("No se pudieron guardar los cambios", "Error");
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        Console.WriteLine("###################### = " + err.ToString());
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El campo de 'Nombre' esta vacio", "Error");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El campo de 'Estado' esta vacio", "Error");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El campo de 'Nave' esta vacio", "Error");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El campo de 'Columna' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo de 'Segmento' esta vacio", "Error");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Area' esta vacio", "Error");
            }
        }
        private void comBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comBoxEstado.SelectedIndex;
                if (_data != 0)
                {
                    GetEstado(comBoxEstado.Text);
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombre();
        }
        private void txtSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombre();
        }
        private void txtNave_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombre();
        }
        private void txtColumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarNombre();
        }
    }
}