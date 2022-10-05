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
using WFConsumo.frmGRH.DespachoOrdenEnProceso;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class AgregarTraspaso : DevExpress.XtraEditors.XtraForm
    {
        string _despachoId;
        int _sucOrigen;
        int _sucDestino;
        int _correlativoMovArt = 0;
        CDespacho C_Despacho;
        CTraspaso C_Traspaso;
        CSucursal C_Sucursal;
        List<ItemTraspaso> _listItemTrasp = new List<ItemTraspaso>();
        List<TraspasoQuery> _listQueryTrasp = new List<TraspasoQuery>();

        public AgregarTraspaso(string _IdDespacho)
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            C_Traspaso = new CTraspaso();
            C_Sucursal = new CSucursal();

            _despachoId = _IdDespacho; 
            //txtFechaDoctxtTransaccion.Text = "26001";
            txtFechaDoc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaReg.Text = DateTime.Now.ToString("dd/MM/yyyy");
            GetData();
            txtDesc.Text = "Traspaso por abastecimiento en " + _IdDespacho;
        }
        public void GetData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoTraspaso(_despachoId);
                foreach(DataRow item in dataLista.Tables[0].Rows)
                {
                    _sucOrigen = Convert.ToInt32(item[1]);
                    _sucDestino = Convert.ToInt32(item[2]);
                }
                string tipoDodId = "0";
                string tipoDodNom = "NN";
                string tipoDocId = "NN";
                string _nSucOrig = "NN";
                string _nSucDest = "NN";
                DataSet dataTrasp = C_Traspaso.TraerTipoDoc(_sucDestino);
                foreach (DataRow items in dataTrasp.Tables[0].Rows)
                {
                    tipoDodId = items[0].ToString();
                    tipoDodNom = items[1].ToString();
                }
                DataSet dataCorr = C_Traspaso.TraerCorrelativo(_sucDestino);
                foreach (DataRow items in dataCorr.Tables[0].Rows)
                {
                    tipoDocId = items[0].ToString();
                }

                DataSet dataListOr = C_Sucursal.BuscarNombreSuc(_sucOrigen);
                foreach (DataRow item in dataListOr.Tables[0].Rows)
                {
                    _nSucOrig = item[0].ToString();
                }
                DataSet dataListDe = C_Sucursal.BuscarNombreSuc(_sucDestino);
                foreach (DataRow item in dataListDe.Tables[0].Rows)
                {
                    _nSucDest = item[0].ToString();
                }
                string _tipoDodId = tipoDodId;
                string _tipoDod = tipoDodNom;
                string _NroDocId = tipoDocId;
                int _sucEntregaId = _sucOrigen;
                string _sucEntregaN = _nSucOrig;
                int _sucRecibeId = _sucDestino;
                string _sucRecibeN = _nSucDest;

                txtTipoDodId.Text = _tipoDodId;
                txtTipoDodNom.Text = _tipoDod;
                txtTipoDocId.Text = _NroDocId;
                txtSucEntregaId.Text = _sucEntregaId.ToString();
                txtSucEntregaNom.Text = _sucEntregaN;
                txtSucRecibeId.Text = _sucRecibeId.ToString();
                txtSucRecibeNom.Text = _sucRecibeN;

                GetProductos();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Ok");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void GetProductos()
        {
            try
            {
                DataSet dataPrd = C_Despacho.TraerDespDetalleTrasp(_despachoId);
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$ = dataPrd = " + dataPrd.Tables[0].Rows.Count);
                foreach(DataRow item in dataPrd.Tables[0].Rows)
                {
                    _listQueryTrasp.Add(new TraspasoQuery
                    {
                        p_ItemFId = item[0].ToString(),
                        p_ItemId = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_Cantidad = Convert.ToInt32(item[3]),
                        p_Peso = Convert.ToDecimal(item[4])
                    });
                }
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$ = _listQueryTrasp = " + _listQueryTrasp.Count);
                foreach (var item in _listQueryTrasp)
                {
                    DataSet dtT = C_Traspaso.TraerCosto(item.p_ItemFId);
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$ = dtT = " + dtT.Tables[0].Rows.Count);
                    foreach (DataRow trsp in dtT.Tables[0].Rows)
                    {
                        _listItemTrasp.Add(new ItemTraspaso
                        {
                            p_Articulo = item.p_ItemFId.ToString(),
                            p_Descripcion = item.p_Descripcion.ToString(),
                            p_Cantidad = item.p_Cantidad,
                            p_Costo = Convert.ToDecimal(trsp[0]) * item.p_Cantidad
                        });
                    }
                }
                gridControl1.DataSource = _listItemTrasp;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Ok");
                Console.WriteLine("####################### = " + err.ToString());
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
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Ok");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btcCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarProducto form2 = new AgregarProducto();
                form2.Owner = this;
                form2.ShowDialog();
                //this.Enabled = false;
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            try
            {
                scttrasp _traspInf = new scttrasp();
                _traspInf.p_sctttdoc = Convert.ToDecimal(txtTipoDodId.Text);
                _traspInf.p_scttndoc = Convert.ToDecimal(txtTipoDocId.Text);
                _traspInf.p_sctiptra = 26001;
                _traspInf.p_scttfdoc = Convert.ToDateTime(txtFechaDoc.DateTime);
                _traspInf.p_scttfreg = Convert.ToDateTime(txtFechaReg.DateTime);
                _traspInf.p_scttsuce = Convert.ToDecimal(txtSucEntregaId.Text);
                _traspInf.p_scttsucr = _sucDestino;
                _traspInf.p_scttdesc = txtDesc.Text.ToUpperInvariant();

                DataTable dt = new DataTable();
                dt.Columns.Add("p_scmvtdoc"); //tipo documento
                dt.Columns.Add("p_scmvndoc"); //numero documento
                dt.Columns.Add("p_scmvnart"); //item Fid
                dt.Columns.Add("p_scmvctra"); //10004
                dt.Columns.Add("p_scmvfdoc"); //fecha documento(actual)
                dt.Columns.Add("p_scmvfreg"); //fecha registro(actual)
                dt.Columns.Add("p_scmvcsuc"); //sucursal recibe 7001 -- sucursal entrega 7002
                dt.Columns.Add("p_scmvcorr"); //correlativo interno de productos agregados a un traspaso
                dt.Columns.Add("p_scmvcmov"); //7001 - 7002
                dt.Columns.Add("p_scmvcant"); //cantidad
                dt.Columns.Add("p_scmvicme"); //costo total = cantidad por costo
                dt.Columns.Add("p_scmvpumo"); //0
                dt.Columns.Add("p_scmvicmo"); //0
                dt.Columns.Add("p_scmvpvus"); //0
                dt.Columns.Add("p_scmvivus"); //0
                dt.Columns.Add("p_scmvpvmn"); //0
                dt.Columns.Add("p_scmvivmn"); //0
                dt.Columns.Add("p_scmvsssu"); //0
                dt.Columns.Add("p_scmvisco"); //0
                dt.Columns.Add("p_scmvssco"); //0
                
                DataRow dr = null;
                //salida - envio
                foreach (var item in _listItemTrasp)
                {
                    _correlativoMovArt++;
                    //salida - envio
                    dr = dt.NewRow(); // have new row on each iteration
                    dr["p_scmvtdoc"] = Convert.ToDecimal(txtTipoDodId.Text); 
                    dr["p_scmvndoc"] = Convert.ToDecimal(txtTipoDocId.Text);
                    dr["p_scmvnart"] = item.p_Articulo;
                    dr["p_scmvctra"] = 10006;
                    dr["p_scmvfdoc"] = Convert.ToDateTime(txtFechaDoc.Text);
                    dr["p_scmvfreg"] = Convert.ToDateTime(txtFechaReg.Text);
                    dr["p_scmvcsuc"] = _sucOrigen;
                    dr["p_scmvcmov"] = 7002;
                    dr["p_scmvcant"] = item.p_Cantidad;
                    dr["p_scmvicme"] = item.p_Cantidad * item.p_Costo;
                    dr["p_scmvpumo"] = 0;
                    dr["p_scmvicmo"] = 0;
                    dr["p_scmvpvus"] = 0;
                    dr["p_scmvivus"] = 0;
                    dr["p_scmvpvmn"] = 0;
                    dr["p_scmvivmn"] = 0;
                    dr["p_scmvsssu"] = 0;
                    dr["p_scmvisco"] = 0;
                    dr["p_scmvssco"] = 0;
                    dt.Rows.Add(dr);
                    //entrada - recibe
                    dr = dt.NewRow(); // have new row on each iteration
                    dr["p_scmvtdoc"] = Convert.ToDecimal(txtTipoDodId.Text);
                    dr["p_scmvndoc"] = Convert.ToDecimal(txtTipoDocId.Text);
                    dr["p_scmvnart"] = item.p_Articulo;
                    dr["p_scmvctra"] = 10004;
                    dr["p_scmvfdoc"] = Convert.ToDateTime(txtFechaDoc.Text);
                    dr["p_scmvfreg"] = Convert.ToDateTime(txtFechaReg.Text);
                    dr["p_scmvcsuc"] = _sucDestino;
                    dr["p_scmvcmov"] = 7001;
                    dr["p_scmvcant"] = item.p_Cantidad;
                    dr["p_scmvicme"] = item.p_Cantidad * item.p_Costo;
                    dr["p_scmvpumo"] = 0;
                    dr["p_scmvicmo"] = 0;
                    dr["p_scmvpvus"] = 0;
                    dr["p_scmvivus"] = 0;
                    dr["p_scmvpvmn"] = 0;
                    dr["p_scmvivmn"] = 0;
                    dr["p_scmvsssu"] = 0;
                    dr["p_scmvisco"] = 0;
                    dr["p_scmvssco"] = 0;
                    dt.Rows.Add(dr);
                }
                _correlativoMovArt = 0;
                if (C_Traspaso.InsertarTraspaso(_traspInf, dt, _sucOrigen) > 0)
                {
                    XtraMessageBox.Show("El traspaso ha sido guardado", "Guardar");
                }
                else
                {
                    XtraMessageBox.Show("Algo salio mal, intentalo de nuevo", "Error ");
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Ok");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
    }
}