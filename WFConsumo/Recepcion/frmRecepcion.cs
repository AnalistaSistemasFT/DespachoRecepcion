using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Componentes;
using DevExpress.ExpressApp; 
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.Recepcion
{
    public partial class frmRecepcion : DevExpress.XtraEditors.XtraForm
    {
        CCamion oCamion = new CCamion();
        CChofer oChofer = new CChofer();
        CFabricante oFabricante = new CFabricante();
        CCeldas oCelda = new CCeldas();
        CSucursal oSucursal = new CSucursal();
        CRecepcion oRecep = new CRecepcion();
        public int iOrden = 0;
        List<CRN.Entidades.RecepcionProducto> LisRecDetPrd = new List<CRN.Entidades.RecepcionProducto>();
        List<CRN.Entidades.RecepcionDetalle> LisRecDet = new List<CRN.Entidades.RecepcionDetalle>();
        //
        List<CRN.Entidades.RecepcionProducto> _LisRecDetPrdFiltrar = new List<CRN.Entidades.RecepcionProducto>();
        List<CRN.Entidades.RecepcionDetalle> _LisRecDetFiltrar = new List<CRN.Entidades.RecepcionDetalle>();

        public frmRecepcion()
        {
            InitializeComponent();
            CargarCombox();
        }
        private void CargarCombox()
        {
            DataSet dtsCamion = oCamion.SeleccionarCamion();
            this.cboplaca.DataSource = dtsCamion.Tables[0];
            this.cboplaca.DisplayMember = "Placa";
            this.cboplaca.ValueMember = "Id_Camion";

            DataSet dtsChofer = oChofer.SeleccionarChofer();
            this.cbochofer.DataSource = dtsChofer.Tables[0];
            this.cbochofer.DisplayMember = "Nombre";
            this.cbochofer.ValueMember = "ci";

            DataSet dtsSucursal = oSucursal.SeleccionarSucursalTodo();
            this.cboorigen.DataSource = dtsSucursal.Tables[0];
            this.cboorigen.DisplayMember = "Nombre";
            this.cboorigen.ValueMember = "SucursalID";

            DataSet dtsCeldas = oCelda.CargarCelda(Entidades.utilitario.iSucursal);
            this.cbocelda.DataSource = dtsCeldas.Tables[0];
            this.cbocelda.DisplayMember = "celdaid";
            this.cbocelda.ValueMember = "celdaid";
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            CRN.Entidades.Recepcion oRec = new CRN.Entidades.Recepcion();
            oRec.RecepcionId = txtrecepcion.Text;
            oRec.Fecha = DateTime.Now;
            oRec.Chofer = cbochofer.SelectedValue.ToString();
            string display = cboplaca.GetItemText(cboplaca.SelectedValue);
            oRec.Camion = Convert.ToInt32(display);
            oRec.Placa = cboplaca.Text;
            oRec.CI = txtci.Text;
            oRec.Propietario = txtpropietario.Text.Trim();
            oRec.Login = Entidades.utilitario.sUsuario.Trim();
            oRec.Obs = txtobs.Text.Trim();
            oRec.Correlativo = 0;
            oRec.Status = "OPEN";
            oRec.SucursalId = Entidades.utilitario.iSucursal;
            oRec.SucOrigen = Convert.ToInt32(cboorigen.SelectedValue);
            //oRec.SucOrigen = 
            oRec.Documento = txtdocumento.Text.Trim();
            oRec.Fuente = 2;//TRASPASO
            oRec.EsDeCliente = cbxCliente.Checked;
            oRec.Manifiesto = txtDui.Text.Trim();
            oRec.Barco = "0";
            oRec.Id_Pais = 0;
            oRec.BL = "0";
            oRec.ProveedorId = 0;


            //
            CRN.Entidades.RecepcionProducto oRecDet = new CRN.Entidades.RecepcionProducto();
            CRN.Entidades.RecepcionDetalle oRecDetalle = new CRN.Entidades.RecepcionDetalle();
            DataTable ds;
            ds = oRecep.TraerOrdenDetProd(iOrden, 1).Tables[0];// (DataTable)dgvdetalle.DataSource;
            for (int a = 0; a < ds.Rows.Count; a++)
            {
                int len = 0;
                oRecDet = new CRN.Entidades.RecepcionProducto();
                oRecDet.RecepcionId = txtrecepcion.Text;
                oRecDet.ProductoId = ds.Rows[a]["PaqueteId"].ToString();
                oRecDet.Fabricante = "Ferrotodo";
                oRecDet.ItemId = ds.Rows[a]["ItemId"].ToString();
                oRecDet.Colada = ds.Rows[a]["Colada"].ToString();
                oRecDet.SucursalId = Entidades.utilitario.iSucursal;
                oRecDet.AlmacenId = Entidades.utilitario.iAlmacen;
                oRecDet.CeldaId = cbocelda.SelectedValue.ToString();
                oRecDet.Fecha = DateTime.Now;
                oRecDet.Correlativo = a;
                oRecDet.Login = Entidades.utilitario.sUsuario.Trim();
                oRecDet.Status = "OPEN";
                oRecDet.CodPackList = ds.Rows[a]["Colada"].ToString();
                oRecDet.PesoNetoProveedor = Convert.ToDecimal(ds.Rows[a]["Peso"].ToString());
                oRecDet.PesoBrutoProveedor = Convert.ToDecimal(ds.Rows[a]["Peso"].ToString());
                oRecDet.EsDeCliente = cbxCliente.Checked;
                oRecDet.Piezas = Convert.ToInt32(ds.Rows[a]["Cantidad"].ToString()); 
                oRecDet.Id_TipoObservacion = 0;
                oRecDet.Peso = Convert.ToDecimal(ds.Rows[a]["Peso"].ToString());
                len = ds.Rows[a]["Colada"].ToString().Count();
                if(len > 150)
                {
                    XtraMessageBox.Show("La longitud de la colada es mayor a la permitida ("+len+" caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
                }
                if (string.IsNullOrEmpty(ds.Rows[a]["FechaVenc"].ToString()))
                    oRecDet.FechaVenc = DateTime.Now.AddDays(360);
                else
                    oRecDet.FechaVenc = Convert.ToDateTime(ds.Rows[a]["FechaVenc"].ToString());
                LisRecDetPrd.Add(oRecDet);

            }
            DataTable ds1 = oRecep.TraerOrdenCargaDetalle(iOrden).Tables[0];
            for (int x = 0; x < ds1.Rows.Count; x++)
            {
                oRecDetalle = new CRN.Entidades.RecepcionDetalle();
                oRecDetalle.RecepcionId = txtrecepcion.Text;
                oRecDetalle.Unidad = ds1.Rows[x]["Unidad"].ToString();
                if(ds1.Rows[x]["Unidad"].ToString().ToLower() == "kg")
                {
                    oRecDetalle.Cantidad = Convert.ToDecimal(ds1.Rows[x]["Peso"].ToString());
                }
                else
                {
                    oRecDetalle.Cantidad = Convert.ToDecimal(ds1.Rows[x]["Cantidad"].ToString());
                }
                oRecDetalle.ItemId = ds1.Rows[x]["ItemId"].ToString();
                oRecDetalle.Status = "OPEN";
                oRecDetalle.SucursalId = Entidades.utilitario.iSucursal;
                //
                string itm = ds1.Rows[x]["ItemId"].ToString();
                var result = LisRecDet.FirstOrDefault(y => y.ItemId == itm);
                if (result != null)
                {
                    //found
                }
                else
                {
                    LisRecDet.Add(oRecDetalle);
                }
                //
                //LisRecDet.Add(oRecDetalle);
            }
            //
            try
            {
                //GridView view = sender as GridView;
                ColumnView view = dgvdetalle.MainView as ColumnView;
                if (view == null) return;
                int[] row = view.GetSelectedRows();
                //editar cantidad por recibidos
                foreach (var itmLst in LisRecDet)
                {
                    int cantidad_ret = 0;
                    for (int i = 0; i < row.Length; i++)
                    {
                        string Item_Id = view.GetRowCellDisplayText(row[i], view.Columns[2]).ToString();
                        string Recibir = view.GetRowCellDisplayText(row[i], view.Columns[7]).ToString();
                        
                        if (Item_Id == itmLst.ItemId)
                        {
                            cantidad_ret = cantidad_ret + Convert.ToInt32(Recibir);
                            _LisRecDetFiltrar.Add(new CRN.Entidades.RecepcionDetalle
                            {
                                RecepcionId = itmLst.RecepcionId,
                                ItemId = itmLst.ItemId,
                                Cantidad = itmLst.Cantidad,
                                Unidad = itmLst.Unidad,
                                Status = itmLst.Status,
                                SucursalId = itmLst.SucursalId
                            });
                        }
                    }
                    _LisRecDetFiltrar.Find(p => p.ItemId == itmLst.ItemId).Cantidad = cantidad_ret;
                }
                //editar cantidad por detalle producto
                foreach (var itmPrd in LisRecDetPrd)
                {
                    int cantidad_ret = 0;
                    for (int i = 0; i < row.Length; i++)
                    {
                        string Item_Id = view.GetRowCellDisplayText(row[i], view.Columns[2]).ToString();
                        string Paquete_Id = view.GetRowCellDisplayText(row[i], view.Columns[1]).ToString();
                        string Unidad = view.GetRowCellDisplayText(row[i], view.Columns[4]).ToString();
                        string Recibir = view.GetRowCellDisplayText(row[i], view.Columns[7]).ToString();
                        if (Paquete_Id == itmPrd.ProductoId)
                        {
                            if (Unidad.ToLower() == "pcs")
                            {
                                _LisRecDetPrdFiltrar.Add(new CRN.Entidades.RecepcionProducto
                                {
                                    RecepcionId = itmPrd.RecepcionId,
                                    ProductoId = itmPrd.ProductoId,
                                    Fabricante = itmPrd.Fabricante,
                                    ItemId = itmPrd.ItemId,
                                    Colada = itmPrd.Colada,
                                    SucursalId = itmPrd.SucursalId,
                                    AlmacenId = itmPrd.AlmacenId,
                                    CeldaId = itmPrd.CeldaId,
                                    Fecha = itmPrd.Fecha,
                                    Correlativo = itmPrd.Correlativo,
                                    Login = itmPrd.Login,
                                    Status = itmPrd.Status,
                                    CodPackList = itmPrd.CodPackList,
                                    PesoNetoProveedor = itmPrd.PesoNetoProveedor,
                                    PesoBrutoProveedor = itmPrd.PesoBrutoProveedor,
                                    EsDeCliente = itmPrd.EsDeCliente,
                                    Id_TipoObservacion = itmPrd.Id_TipoObservacion,
                                    FechaVenc = itmPrd.FechaVenc,
                                    Piezas = Convert.ToInt32(Recibir),
                                    Peso = itmPrd.Peso
                                });
                            }
                            else
                            {
                                _LisRecDetPrdFiltrar.Add(new CRN.Entidades.RecepcionProducto
                                {
                                    RecepcionId = itmPrd.RecepcionId,
                                    ProductoId = itmPrd.ProductoId,
                                    Fabricante = itmPrd.Fabricante,
                                    ItemId = itmPrd.ItemId,
                                    Colada = itmPrd.Colada,
                                    SucursalId = itmPrd.SucursalId,
                                    AlmacenId = itmPrd.AlmacenId,
                                    CeldaId = itmPrd.CeldaId,
                                    Fecha = itmPrd.Fecha,
                                    Correlativo = itmPrd.Correlativo,
                                    Login = itmPrd.Login,
                                    Status = itmPrd.Status,
                                    CodPackList = itmPrd.CodPackList,
                                    PesoNetoProveedor = itmPrd.PesoNetoProveedor,
                                    PesoBrutoProveedor = itmPrd.PesoBrutoProveedor,
                                    EsDeCliente = itmPrd.EsDeCliente,
                                    Id_TipoObservacion = itmPrd.Id_TipoObservacion,
                                    FechaVenc = itmPrd.FechaVenc,
                                    Piezas = itmPrd.Piezas,
                                    Peso = itmPrd.Peso
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err);
            }

            //string Despacho = view.GetRowCellDisplayText(row[i], view.Columns[0]).ToString();
            //string Paquete = view.GetRowCellDisplayText(row[i], view.Columns[1]).ToString();
            //string Recep = view.GetRowCellDisplayText(row[i], view.Columns[7]).ToString();
            CAnotacion oAnot = new CAnotacion();
            string sError = string.Empty;
            //int b = oAnot.InsertarRecepcionPorDespacho(out sError, oRec, _LisRecDetFiltrar, _LisRecDetPrdFiltrar, iOrden);
            if(LisRecDet.Count > 0 && _LisRecDetPrdFiltrar.Count > 0)
            {
                int b = oAnot.InsertarRecepcionPorDespacho(out sError, oRec, LisRecDet, _LisRecDetPrdFiltrar, iOrden);
                if (b > 0)
                    MessageBox.Show("Se genero con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Problemas en la transaccion...", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine("############################### = " + sError);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Seleccione los productos que va a recepcionar", "Aviso");
            }
        }

        private void frmRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvdetalle.DataSource = null;
            _LisRecDetFiltrar.Clear();
            _LisRecDetPrdFiltrar.Clear();
        }
    }
}