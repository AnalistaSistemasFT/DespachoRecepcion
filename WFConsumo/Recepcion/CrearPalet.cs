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
using CRN.Entidades;

namespace WFConsumo.Recepcion
{
    public partial class CrearPalet : DevExpress.XtraEditors.XtraForm
    {
        CDespacho C_Despacho;
        CPaquetes C_Paquete;
        int _idSucursal = 0;
        string _CorrelativoNuevo;
        List<string> _listPaqLecturados = new List<string>();
        List<PaletLecturado> _paqList = new List<PaletLecturado>();
        string _codigoPaq = string.Empty;
        string _ItemId = string.Empty;
        int _ItemFId = 0;
        int _cantPaqs = 0;
        decimal _pesoPaqs = 0;

        public CrearPalet(int idSucursal)
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            C_Paquete = new CPaquetes();
            _idSucursal = idSucursal;
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                //Traer Correlativo
                _CorrelativoNuevo = C_Despacho.TraerSecuenciaPalet(_idSucursal);
                txtCorrelativo.Text = _CorrelativoNuevo;
                gridControl1.DataSource = _paqList;
                //Traer codigos
                DataSet dataCodigo = C_Paquete.TraerItemPaquetesDisponibles(_idSucursal);
                foreach(DataRow item in dataCodigo.Tables[0].Rows)
                {
                    comBoxItem.Properties.Items.Add(item[0].ToString());
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################## = " + err.ToString());
            }
        }
        public void TraerCorrelativo()
        {
            try
            {
                 
            }
            catch(Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void btnBusquedaMan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comBoxItem.Text) || (!string.IsNullOrEmpty(comBoxItem.Text)))
            {
                int IdSucursal = _idSucursal;
                try
                {
                    //for (int i = 0; i < gridView1.DataRowCount; i++)
                    //{
                    //    string ValPaq = gridView1.GetRowCellValue(i, "p_PaqueteId").ToString();

                    //    if (ValPaq != null && ValPaq != string.Empty)
                    //    {
                    //        _listPaqLecturados.Add(ValPaq);
                    //    }
                    //}
                    ListProdLectPalet form2 = new ListProdLectPalet(IdSucursal, comBoxItem.Text.Trim(),  _listPaqLecturados, _CorrelativoNuevo);
                    form2.Owner = this;
                    form2.ShowDialog(this);
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("############################################# = " + err.ToString());
                } 
            }
            else
            {
                XtraMessageBox.Show("Elija un Codigo para porder seleccionar los paquetes", "Codigo vacio");
            } 
        }
        private void btnEmpezarLect_Click(object sender, EventArgs e)
        {
            if (txtEtiqueta.Enabled == true)
            {
                txtEtiqueta.Enabled = false;
                btnEmpezarLect.Text = "Empezar lecturacion";
                //btnBusquedaMan.Enabled = false; 
            }
            else if (txtEtiqueta.Enabled == false)
            {
                txtEtiqueta.Focus();
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.Enabled = true;
                btnEmpezarLect.Text = "Finalizar lecturacion";
                btnBusquedaMan.Enabled = true;
            }
            else
            {
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.Enabled = true;
                btnEmpezarLect.Text = "Empezar lecturacion";
                btnBusquedaMan.Enabled = true;
            }
        }
        public void ProductoElegido(string _idItem, string _itemFerro, string _descripcion, string _paquete, int _piezas, decimal _peso)
        {
            try
            {
                if (_piezas > 0)
                {
                    if (!_paqList.Any(n => n.p_PaqueteId == _paquete))
                    {
                        _paqList.Add(new PaletLecturado
                        {
                            p_ItemId = _idItem,
                            p_ItemFerro = _itemFerro,
                            p_Descripcion = _descripcion,
                            p_PaqueteId = _paquete,
                            p_Piezas = _piezas,
                            p_Peso = _peso
                        });
                    }

                    this.gridControl1.RefreshDataSource();
                    this.gridControl1.Refresh();
                }
                else
                {
                    XtraMessageBox.Show("Cantidad menor a 1", "Cantidad");
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("############################# = " + err.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            try
            {
                if(_ItemFId < 1)
                {
                    _ItemFId = 001;
                }
                foreach (var item in _paqList)
                {
                    _pesoPaqs = _pesoPaqs + item.p_Peso;
                    _ItemFId = Convert.ToInt32(item.p_ItemFerro);
                }
                _cantPaqs = _paqList.Count;

                Palet _palet = new Palet();
                _palet.p_PaletId = _CorrelativoNuevo;
                _palet.p_ItemId = comBoxItem.Text.Trim();
                _palet.p_ItemFerro = _ItemFId;
                _palet.p_SucursalId = _idSucursal;
                _palet.p_Cantidad_Paqs = _cantPaqs;
                _palet.p_Peso_Paqs = _pesoPaqs;
                _palet.p_Estado = "ACTIVO";
                int a = 0;
                a = C_Despacho.InsertarPalet(out sError, _CorrelativoNuevo, _idSucursal, _palet, _paqList);
                if(a > 0)
                {
                    XtraMessageBox.Show("El palet fue creado", "Crear palet");
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Problemas al crear el Palet", "Error");
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("##################### = " + err.ToString());
            }
        }
        private void txtEtiqueta_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEtiqueta.Text) || (!string.IsNullOrEmpty(txtEtiqueta.Text)))
            {
                try
                {
                    _codigoPaq = txtEtiqueta.Text.ToUpper();
                    if (_codigoPaq != string.Empty)
                    {
                        if (_codigoPaq.Length > 5)
                        {
                            Lecturar(_codigoPaq);
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
        }
        private void Lecturar(string _codigoPr)
        {
            try
            { 
                string _IdPaquete = "0";
                _IdPaquete = _codigoPr;
                DataSet dataLista = C_Paquete.TraerProductosLecturarPaletValidar(_idSucursal);

                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    if (_codigoPr == item[3].ToString())
                    {
                        if (!_paqList.Any(n => n.p_PaqueteId.ToUpper() == _codigoPr.ToUpper()))
                        {
                            _paqList.Add(new PaletLecturado
                            {
                                p_ItemId = item[0].ToString(),
                                p_ItemFerro = item[1].ToString(),
                                p_Descripcion = item[2].ToString(),
                                p_PaqueteId = item[3].ToString(),
                                p_Piezas = Convert.ToInt32(item[4]),
                                p_Peso = Convert.ToDecimal(item[5])
                            });
                        }
                        else
                        {

                        }
                    }
                }
                this.gridControl1.RefreshDataSource();
                this.gridControl1.Refresh();
                _codigoPr = string.Empty;
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.DoValidate();
                //
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
    }
}