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

namespace WFConsumo.frmGRH.Devoluciones
{
    public partial class NuevaDevolucion : DevExpress.XtraEditors.XtraForm
    {
        int _IdSucursal = 0;
        string _SucursalNombre = string.Empty;
        int _idDevolucion = 0;
        CDevolucion C_Devolucion;
        List<DevolucionDetalle> _listDevDeta = new List<DevolucionDetalle>();

        public NuevaDevolucion(int sucursalId, string sucursallocal)
        {
            InitializeComponent();
            C_Devolucion = new CDevolucion();
            _IdSucursal = sucursalId;
            _SucursalNombre = sucursallocal; 
        }

        private void TraerData()
        {
            try
            {
                DataSet listDev = C_Devolucion.TraerDevolucion(_idDevolucion);
                foreach (DataRow itm in listDev.Tables[0].Rows)
                {
                    txtCodigoCliente.Text = itm[0].ToString();
                    txtNombreCliente.Text = itm[1].ToString();
                    txtNumOV.Text = itm[2].ToString();
                    txtNuevaOV.Text = itm[3].ToString();
                    txtMonto.Text = itm[4].ToString();
                    txtSucursal.Text = itm[5].ToString();
                    txtVendedor.Text = itm[6].ToString();
                    txtChofer.Text = itm[7].ToString();
                    txtPlaca.Text = itm[8].ToString();
                    txtFechaEntrega.Text = itm[9].ToString();
                    txtFechaRecepcion.Text = itm[10].ToString();
                }
                //lista detalle del azul
                DataSet listDetDev = C_Devolucion.TraerDetalleDevolucion(_idDevolucion);
                foreach (DataRow item in listDev.Tables[0].Rows)
                {
                    _listDevDeta.Add(new DevolucionDetalle
                    {
                        p_Id_detalle_devolucion = 0,
                        p_Id_devolucion = 0,
                        p_Codigo = item[0].ToString(),
                        p_CodigoFerro = Convert.ToInt32(item[1]),
                        p_Descripcion = item[2].ToString(),
                        p_Cantidad = Convert.ToInt32(item[3]),
                        p_Unidad = item[4].ToString(),
                        p_Reincorporado = Convert.ToInt32(item[5]),
                        p_Observaciones = item[6].ToString()
                    });
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigoCliente.Text) || (!string.IsNullOrEmpty(txtCodigoCliente.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtNombreCliente.Text) || (!string.IsNullOrEmpty(txtNombreCliente.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(txtNumOV.Text) || (!string.IsNullOrEmpty(txtNumOV.Text)))
                    {
                        if (!string.IsNullOrWhiteSpace(txtMonto.Text) || (!string.IsNullOrEmpty(txtMonto.Text)))
                        {
                            if (!string.IsNullOrWhiteSpace(txtSucursal.Text) || (!string.IsNullOrEmpty(txtSucursal.Text)))
                            {
                                if (!string.IsNullOrWhiteSpace(txtVendedor.Text) || (!string.IsNullOrEmpty(txtVendedor.Text)))
                                {
                                    if (!string.IsNullOrWhiteSpace(txtNuevaOV.Text) || (!string.IsNullOrEmpty(txtNuevaOV.Text)))
                                    {
                                        if (!string.IsNullOrWhiteSpace(txtFechaEntrega.Text) || (!string.IsNullOrEmpty(txtFechaEntrega.Text)))
                                        {
                                            if (!string.IsNullOrWhiteSpace(txtFechaRecepcion.Text) || (!string.IsNullOrEmpty(txtFechaRecepcion.Text)))
                                            {
                                                try
                                                {
                                                    Devolucion _devolucion = new Devolucion();
                                                    _devolucion.p_Cod_cliente = Convert.ToInt32(txtCodigoCliente.Text);
                                                    _devolucion.p_Nom_cliente = txtNombreCliente.Text;
                                                    _devolucion.p_OrdenVenta = txtNumOV.Text;
                                                    _devolucion.p_Monto = Convert.ToDecimal(txtMonto.Text);
                                                    _devolucion.p_Sucursal = Convert.ToInt32(txtSucursal);
                                                    _devolucion.p_Chofer = txtChofer.Text;
                                                    _devolucion.p_Placa = txtPlaca.Text;
                                                    _devolucion.p_NuevaOrdenVenta = txtNuevaOV.Text;
                                                    _devolucion.p_Fecha_entrega = Convert.ToDateTime(txtFechaEntrega.Text);
                                                    _devolucion.p_Fecha_recepcion = Convert.ToDateTime(txtFechaRecepcion.Text);
                                                    _devolucion.p_Motivo = txtMotivo.Text;

                                                    DataTable dt = new DataTable();
                                                    dt.Columns.Add("p_Id_devolucion");
                                                    dt.Columns.Add("p_Codigo");
                                                    dt.Columns.Add("p_CodigoFerro");
                                                    dt.Columns.Add("p_Descripcion");
                                                    dt.Columns.Add("p_Cantidad");
                                                    dt.Columns.Add("p_Unidad");
                                                    dt.Columns.Add("p_Reincorporado");
                                                    dt.Columns.Add("p_Observaciones");
                                                    DataRow dr = null;

                                                    foreach (var item in _listDevDeta)
                                                    {
                                                        dr = dt.NewRow(); 
                                                        dr["p_Id_devolucion"] = item.p_Id_devolucion;
                                                        dr["p_Codigo"] = item.p_Codigo;
                                                        dr["p_CodigoFerro"] = item.p_CodigoFerro;
                                                        dr["p_Descripcion"] = item.p_Descripcion;
                                                        dr["p_Cantidad"] = item.p_Cantidad;
                                                        dr["p_Unidad"] = item.p_Unidad;
                                                        dr["p_Reincorporado"] = item.p_Reincorporado;
                                                        dr["p_Observaciones"] = item.p_Observaciones;
                                                        dt.Rows.Add(dr);
                                                    }
                                                    if (C_Devolucion.InsertarDevolucion(_devolucion, dt) > 0)
                                                    {
                                                        XtraMessageBox.Show("Devolucion agregada", "Guardar");
                                                        this.Close();
                                                    }
                                                    else
                                                    {
                                                        XtraMessageBox.Show("Problemas al agregar la Devolucion", "Guardar");
                                                        this.Close();
                                                    }
                                                }
                                                catch(Exception err)
                                                {
                                                    Console.WriteLine("##################### = " + err.ToString());
                                                }
                                            }
                                            else
                                            {
                                                XtraMessageBox.Show("El campo de 'Fecha de recepcion' esta vacio", "Error");
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("El campo de 'Fecha de entrega' esta vacio", "Error");
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("El campo de 'N° de nueva OV' esta vacio", "Error");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El campo de 'Vendedor' esta vacio", "Error");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El campo de 'Sucursal' esta vacio", "Error");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El campo de 'Monto' esta vacio", "Error");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El campo de 'Numero de OV' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo de 'Nombre del cliente' esta vacio", "Error");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Codigo del cliente' esta vacio", "Error");
            }
        }
    }
}