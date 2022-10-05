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

namespace WFConsumo.frmGRH.Traspaso
{
    public partial class NuevoTraspaso : DevExpress.XtraEditors.XtraForm
    {
        List<SucursalElegir> _sucursalList = new List<SucursalElegir>();
        List<ItemTraspaso> _listItemTrasp = new List<ItemTraspaso>();
        CSucursal C_Sucursal;
        CTraspaso C_Traspaso;
        int _idSucursal = 0;
        int _idSucursalInf = 0;
        int _itipodoct = 0;
        decimal _idSucRecibe = 0;

        public NuevoTraspaso(Usuario user, int sucursalId, string sucursallocal)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            txtSucEntregaId.Text = sucursalId.ToString();
            txtSucEntregaNom.Text = sucursallocal;
            C_Sucursal = new CSucursal();
            C_Traspaso = new CTraspaso();
            GetSucursal();
            GetData();
            gridControl1.DataSource = _listItemTrasp;
            txtTransaccion.Text = "26001";
            txtFechaDoc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaReg.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void GetSucursal()
        {
            try
            {
                DataSet dataSuc = C_Traspaso.TraerTipoDoc(_idSucursal);
                foreach(DataRow items in dataSuc.Tables[0].Rows)
                {
                    _itipodoct = Convert.ToInt32(items[0]); 
                    _idSucursalInf = Convert.ToInt32(items[0]);
                }
                _sucursalList.Clear();
                //DataSet dataList = C_Sucursal.TraerSucursalesTraspaso();
                DataSet dataList = C_Traspaso.TraerTransitos();
                foreach (DataRow item in dataList.Tables[0].Rows)
                {
                    _sucursalList.Add(new SucursalElegir
                    {
                        p_sccodfin = Convert.ToInt32(item[0]),
                        p_sctcdesc = item[1].ToString()
                    });
                    cBoxSucRecibe.Properties.Items.Add(item[0] + " - " + item[1]);
                }
                //foreach (var item in _sucursalList)
                //{
                //    if (item.p_sccodfin == _itipodoct)
                //    {
                //        txtSucEntregaId.Text = item.p_sccodfin.ToString();
                //        txtSucEntregaNom.Text = item.p_sctcdesc.ToString();
                //    }
                //}
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void GetData()
        {
            try
            {
                int _IdSucursal = _idSucursal;
                DataSet dataTrasp = C_Traspaso.TraerTipoDoc(_IdSucursal);
                foreach (DataRow items in dataTrasp.Tables[0].Rows)
                {
                    txtTipoDodId.Text = items[0].ToString();
                    txtTipoDodNom.Text = items[1].ToString();
                }
                DataSet dataCorr = C_Traspaso.TraerCorrelativo(_idSucursalInf);
                foreach (DataRow items in dataCorr.Tables[0].Rows)
                {
                    txtTipoDocId.Text = (Convert.ToInt32(items[0])).ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.ToString(), "Ok");
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void cBoxSucRecibe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = cBoxSucRecibe.SelectedIndex;
                if (_data != -1)
                {
                    
                    foreach (var item in _sucursalList)
                    {
                        if (item.p_sccodfin + " - " + item.p_sctcdesc == cBoxSucRecibe.SelectedItem.ToString())
                        {
                            txtSucRecibeNom.Text = item.p_sctcdesc;
                            //_idSucursalElegida = Convert.ToInt32(item.SucursalId);
                            //_idSucRecibe = Convert.ToDecimal(item.SucursalId);
                            //try
                            //{
                            //    int _IdSucursal = _idSucursalElegida;
                            //    Console.WriteLine("########################## _idSucursalElegida = " + _idSucursalElegida);
                            //    DataSet dataTrasp = C_Traspaso.TraerTipoDoc(_IdSucursal);
                            //    foreach (DataRow items in dataTrasp.Tables[0].Rows)
                            //    {
                            //        txtTipoDodId.Text = items[0].ToString();
                            //        txtTipoDodNom.Text = items[1].ToString();
                            //    }
                            //    Console.WriteLine("########################## cont TipoDoc = " + dataTrasp.Tables[0].Rows.Count);
                            //    DataSet dataCorr = C_Traspaso.TraerCorrelativo(_IdSucursal);
                            //    foreach (DataRow items in dataCorr.Tables[0].Rows)
                            //    {
                            //        txtTipoDocId.Text = items[0].ToString();
                            //    }
                            //    Console.WriteLine("########################## cont Correlativo = " + dataCorr.Tables[0].Rows.Count);
                            //}
                            //catch (Exception err)
                            //{
                            //    XtraMessageBox.Show(err.ToString(), "Ok");
                            //}
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        public void ProductoElegido(string _idProducto, string _Descripcion, int _Cantidad, decimal _Costo)
        {
            try
            {
                if (_Cantidad > 0)
                {
                    decimal _cost = _Costo * _Cantidad;
                    _listItemTrasp.Add(new ItemTraspaso
                    {
                        p_Articulo = _idProducto,
                        p_Descripcion = _Descripcion,
                        p_Cantidad = _Cantidad,
                        p_Costo = _cost,
                    });

                    this.gridControl1.RefreshDataSource();
                    this.gridControl1.Refresh();
                }
                else
                {
                    //XtraMessageBox.Show("Cantidad= ", _cantidad.ToString());
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        //btnAceptar
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cBoxSucRecibe.Text) || (!string.IsNullOrEmpty(cBoxSucRecibe.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtSucRecibeNom.Text) || (!string.IsNullOrEmpty(txtSucRecibeNom.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(txtDesc.Text) || (!string.IsNullOrEmpty(txtDesc.Text)))
                    {
                        string sError = string.Empty;
                        try
                        {
                            scttrasp _traspInf = new scttrasp();
                            _traspInf.p_sctttdoc = Convert.ToDecimal(txtTipoDocId.Text);
                            _traspInf.p_scttndoc = Convert.ToDecimal(txtTipoDocId.Text);
                            _traspInf.p_sctiptra = Convert.ToDecimal(txtSucEntregaId.Text);
                            _traspInf.p_scttfdoc = Convert.ToDateTime(txtFechaDoc.DateTime);
                            _traspInf.p_scttfreg = Convert.ToDateTime(txtFechaReg.DateTime);
                            _traspInf.p_scttsuce = Convert.ToDecimal(txtSucEntregaId.Text);
                            _traspInf.p_scttsucr = _idSucRecibe;
                            _traspInf.p_scttdesc = txtDesc.Text;
                            //C_Traspaso.GuardarTraspaso(ref sError, _traspInf);
                            if(C_Traspaso.GuardarTraspaso(ref sError, _traspInf) > 0)
                            {

                            }
                        }
                        catch(Exception err)
                        {
                            //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("####################### = " + err.ToString());
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El campo de 'Descripcion' esta vacio", "Ok");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo de 'Sucursal recibe' esta vacio", "Ok");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Sucursal recibe' esta vacio", "Ok");
            }
        }
        private void txtSucRecibeId_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int Sucursal = _idSucursal;
                AgregarProductos form2 = new AgregarProductos(Sucursal);
                form2.Owner = this;
                form2.ShowDialog();
                //this.Enabled = false;
            }
            catch(Exception err)
            {
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void txtSucRecibeNom_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int _IdSucursal = _idSucursalElegida;
            //    Console.WriteLine("########################## _idSucursalElegida = " + _idSucursalElegida);
            //    DataSet dataTrasp = C_Traspaso.TraerTipoDoc(_IdSucursal);
            //    foreach(DataRow item in dataTrasp.Tables[0].Rows)
            //    {
            //        txtTipoDodId.Text = item[0].ToString();
            //        txtTipoDodNom.Text = item[1].ToString();
            //    }
            //    Console.WriteLine("########################## cont TipoDoc = " + dataTrasp.Tables[0].Rows.Count);
            //    DataSet dataCorr = C_Traspaso.TraerCorrelativo(_IdSucursal);
            //    foreach (DataRow item in dataCorr.Tables[0].Rows)
            //    {
            //        txtTipoDocId.Text = item[0].ToString();
            //    }
            //    Console.WriteLine("########################## cont Correlativo = " + dataCorr.Tables[0].Rows.Count);
            //}
            //catch (Exception err)
            //{
            //    XtraMessageBox.Show(err.ToString(), "Ok");
            //}
        }
    }
}