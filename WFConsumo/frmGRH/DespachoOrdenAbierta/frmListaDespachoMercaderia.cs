using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using WFConsumo.frmGRH.DespachoOrdenAbierta;
using DevExpress.XtraEditors;
using CRN.Entidades;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using WFConsumo.frmGRH.Imprimir;

using DevExpress.XtraReports.UI;


namespace WFConsumo.frmGRH
{
    public partial class frmListaDespachoMercaderia : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        CDespacho C_Despacho;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        private DateTime _Fecha = DateTime.Now;
        private string _idDespacho;
        private string IdDespacho = "0";
        string _tipoBusqueda;
        Usuario _usuario;
        List<DetalleProducto> _lstProdDet = new List<DetalleProducto>();

        public frmListaDespachoMercaderia(Usuario user, int sucursalId)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            _usuario = user;
            C_Despacho = new CDespacho();
            TraerData();
        }
        private void TraerData()
        {
            DataSet dataLista = C_Despacho.TraerDespachoAbierto(_idSucursal);
            dataT = dataLista.Tables[0];
            this.gridControl1.DataSource = dataT;
            //foreach(var item in dataLista.Tables[0].Rows)
            //{
            //    Program._listaDespachoAbierto.Add(item);
            //}
            comBoxBuscarPor.Properties.Items.Add("Nro Despacho");
            comBoxBuscarPor.Properties.Items.Add("Fecha");
            comBoxBuscarPor.Properties.Items.Add("Nro Orden");
            comBoxBuscarPor.Properties.Items.Add("Placa");
            comBoxBuscarPor.Properties.Items.Add("Chofer");
            comBoxBuscarPor.Properties.Items.Add("Naturaleza");
            comBoxBuscarPor.Properties.Items.Add("Destino");
            comBoxBuscarPor.Properties.Items.Add("Nro Traspaso");
            checkInicio.Checked = true;
            checkCompleta.Checked = false;
        }
        public void gridView1_RowCellClick(Object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                labelControl2.Text = _idDespacho;

                DataSet detalleLista = C_Despacho.TraerDetalleDespacho(_idDespacho);
                _lstProdDet.Clear();
                this.gridControl2.Refresh();
                this.gridControl2.RefreshDataSource();
                foreach (DataRow item in detalleLista.Tables[0].Rows)
                {
                    string idItem = item[0].ToString();
                    string descItem = item[1].ToString();
                    int reqItem = Convert.ToInt32(item[2]);
                    int compItem = Convert.ToInt32(item[3]);
                    decimal pesoItem = 0;
                    int numPaqCelda = 0;
                    int numPaqSob = 0;
                    DataSet sumCelda = C_Despacho.TraerDetalleDespachoSumCelda(_idDespacho, idItem);
                    foreach (DataRow sumCel in sumCelda.Tables[0].Rows)
                    {
                        numPaqCelda = Convert.ToInt32(sumCel[0]);
                    }
                    DataSet sumSobra = C_Despacho.TraerDetalleDespachoSumSob(_idDespacho, idItem);
                    foreach (DataRow sumSob in sumSobra.Tables[0].Rows)
                    {
                        numPaqSob = Convert.ToInt32(sumSob[0] is DBNull ? 0 : sumSob[0]);
                        //totaltomausado=Convert.ToDecimal(drDatos["total"] is DBNull ? 0:drDatos["total"])
                    }
                    int progItem = numPaqCelda + numPaqSob;
                    _lstProdDet.Add(new DetalleProducto
                    {
                        p_ItemId = idItem,
                        p_Descripcion = descItem,
                        p_PiezasReq = reqItem,
                        p_PiezasProg = progItem,
                        p_PiezasComp = compItem,
                        p_Peso = pesoItem
                    });
                }
                this.gridControl2.DataSource = _lstProdDet;

                DataSet detalleProd = C_Despacho.TraerDespProducto(_idDespacho);
                dataProd = detalleProd.Tables[0];
                this.gridControl3.DataSource = dataProd;
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            } 
        }
        private void btnNuevoDespacho_Click(object sender, EventArgs e)
        {
            int Sucursal = _idSucursal;
            DateTime _hoy = DateTime.Now;
            frmNuevoDespachoMercaderia f2 = new frmNuevoDespachoMercaderia(Sucursal, _usuario, _hoy);
            f2.FormClosed += F2_FormClosed;
            f2.Show();
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            this.gridView1.BeginDataUpdate();
            this.gridView1.EndDataUpdate();
            TraerData();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if(row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if(IdDespacho != "0")
                    {
                        var myForm = new frmEditarDespacho(IdDespacho, _idSucursal);
                        myForm.Show();
                        //this.Enabled = false;
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            if(gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if(row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new ConsultarDespacho(IdDespacho);
                        //this.Enabled = false;
                        myForm.Show();
                    }
                }
                catch(Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        try
                        {
                            XtraMessageBox.AllowCustomLookAndFeel = true;
                            DialogResult dialogResult = XtraMessageBox.Show("¿Eliminar despacho?", "Salir", MessageBoxButtons.YesNo);
                            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                string _IdDespacho = IdDespacho;
                                C_Despacho.EliminarDespacho(_idDespacho);
                                TraerData();
                            }
                            else
                            {
                                //
                            }
                        }
                        catch (Exception err)
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("################## = " + err.ToString());
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    string TipoReporte = "AUTORIZADOS";
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    var myForm = new ReportesDespacho(IdDespacho, TipoReporte);
                    myForm.Show();
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnImprimirLocaliza_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        string TipoReporte = "ORDENCARGA";
                        IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        var myForm = new ReportesDespacho(IdDespacho, TipoReporte);
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                if (IdDespacho != "0")
                {
                    try
                    {
                        XtraMessageBox.AllowCustomLookAndFeel = true;
                        DialogResult dialogResult = XtraMessageBox.Show("¿Mover el despacho " + IdDespacho + " a 'Orden en Proceso'?", "Salir", MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            string _idDespacho = IdDespacho;
                            C_Despacho.ModificarEjecutarAenProceso(_idDespacho);
                            TraerData();
                        }
                        else
                        {
                            //
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                if (IdDespacho != "0")
                {
                    try
                    {
                        string _obsDesp = string.Empty;
                        DataSet dataLista = C_Despacho.TraerObsDespacho(_idDespacho); 
                        foreach(DataRow item in dataLista.Tables[0].Rows)
                        {
                            _obsDesp = item[0].ToString();
                        }
                         
                        string ObsText = "";
                        XtraInputBoxArgs args = new XtraInputBoxArgs();
                        args.Editor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                        args.Caption = "Observacion";
                        args.Prompt = "Agregar observacion:  ";
                        args.DefaultButtonIndex = 0;
                        MemoEdit editor = new MemoEdit();
                        args.Editor = editor; 
                        args.DefaultResponse = _obsDesp; 
                        object result = XtraInputBox.Show(args);

                        if (result != null)
                        {
                            ObsText = result.ToString();
                            C_Despacho.ModificarObsDespacho(IdDespacho, ObsText);
                        }
                        Console.WriteLine("################################### = " + ObsText); 
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
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
        private void checkInicio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkInicio.Checked)
                {
                    checkInicio.Checked = true;
                    checkCompleta.Checked = false;
                }
                else if (checkCompleta.Checked)
                {
                    checkInicio.Checked = false;
                    checkCompleta.Checked = true;
                }
                else
                {
                    checkInicio.Checked = false;
                    checkCompleta.Checked = false;
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void checkCompleta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkCompleta.Checked)
                {
                    checkCompleta.Checked = true;
                    checkInicio.Checked = false;
                }
                else if (checkInicio.Checked)
                {
                    checkCompleta.Checked = false;
                    checkInicio.Checked = true;
                }
                else
                {
                    checkCompleta.Checked = false;
                    checkInicio.Checked = false;
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void comBoxBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int data = comBoxBuscarPor.SelectedIndex;
                if (data != 0)
                {
                    _tipoBusqueda = comBoxBuscarPor.SelectedItem.ToString();
                    if (_tipoBusqueda == "Fecha")
                    {
                        txtBusqueda.Visible = false;
                        txtBusqueda.Text = string.Empty;
                        txtBusqueda.ReadOnly = true;
                        datePick.Visible = true;
                    }
                    else
                    {
                        txtBusqueda.Visible = true;
                        txtBusqueda.ReadOnly = false;
                        datePick.Visible = false;
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void ActualizarLista(int actualizar)
        {
            try
            {
                if (actualizar == 1)
                {
                    this.gridControl1.Refresh();
                    this.gridControl1.RefreshDataSource();
                    this.gridView1.RefreshData();
                    TraerData();
                }
            }
            catch(Exception err)
            {
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        //btnBuscarDespacho
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkInicio.Checked)
            {
                string _nombreSuc = txtBusqueda.Text;
                int _criterioB = 0;
                //gridControl1.DataSource = gridView1.Where(x => x.Nombre.ToLower().Contains(_nombreSuc.ToLower()));
                switch(_tipoBusqueda)
                {
                    case "Nro Despacho":
                        _criterioB = 0;
                        break; 
                    case "Fecha":
                        _criterioB = 1;
                        break;
                    case "Nro Orden":
                        _criterioB = 2;
                        break;
                    case "Placa":
                        _criterioB = 3;
                        break;
                    case "Chofer":
                        _criterioB = 4;
                        break;
                    case "Naturaleza":
                        _criterioB = 5;
                        break;
                    case "Destino":
                        _criterioB = 6;
                        break;
                    case "Nro Traspaso":
                        _criterioB = 7;
                        break;
                    default:
                        _criterioB = 0;
                        break;
                }
                
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (txtBusqueda.Text == gridView1.GetDataRow(_criterioB).ToString())
                    {
                        XtraMessageBox.Show(gridView1.GetDataRow(_criterioB).ToString());
                    }
                }

                this.gridControl1.RefreshDataSource();
                this.gridControl1.Refresh();
            }
            else if (checkCompleta.Checked)
            {

            }
        }
        //btnCronograma
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ColumnView viewDesp = gridControl1.MainView as ColumnView;
            ColumnView view = gridControl2.MainView as ColumnView;
            int[] rowDesp = viewDesp.GetSelectedRows();
            int[] row = view.GetSelectedRows();
            if (rowDesp.Length > 0)
            {
                view.FocusedRowHandle = rowDesp[0];
            }
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                IdDespacho = viewDesp.GetRowCellDisplayText(row[0], viewDesp.Columns[0]);
                string ItemId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                string DescItem = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                int PzaReq = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                int PzaProg = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                int PzaPaq = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                if (IdDespacho != "0")
                {
                    try
                    {
                        var myForm = new CronogramaItem(IdDespacho, ItemId, DescItem, PzaPaq, _idSucursal, PzaReq, PzaProg);
                        myForm.Show();
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ColumnView viewDesp = gridControl1.MainView as ColumnView;
            ColumnView view = gridControl2.MainView as ColumnView;
            int[] rowDesp = viewDesp.GetSelectedRows();
            int[] row = view.GetSelectedRows();
            if (rowDesp.Length > 0)
            {
                view.FocusedRowHandle = rowDesp[0];
            }
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                IdDespacho = viewDesp.GetRowCellDisplayText(row[0], viewDesp.Columns[0]);
                string ItemId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                string DescItem = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                int PzaReq = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                int PzaProg = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                int PzaPaq = 150;
                if (IdDespacho != "0")
                {
                    try
                    {
                        var myForm = new CronogramaItem(IdDespacho, ItemId, DescItem, PzaPaq, _idSucursal, PzaReq, PzaProg);
                        myForm.Show();
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridControl2.CanSelect)
                {
                    ColumnView view = gridControl2.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }

                    ColumnView viewDesp = gridControl1.MainView as ColumnView;
                    int[] rowDesp = viewDesp.GetSelectedRows();
                    if (rowDesp.Length > 0)
                    {
                        viewDesp.FocusedRowHandle = rowDesp[0];
                    }

                    try
                    {
                        IdDespacho = viewDesp.GetRowCellDisplayText(rowDesp[0], viewDesp.Columns[0]);
                        string ItemId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        string DescItem = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                        int PzaReq = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                        int PzaProg = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                        int PzaPaq = 1;
                        DataSet dataPaq = C_Despacho.TraerPzaPaq(_idSucursal, ItemId);
                        foreach (DataRow item in dataPaq.Tables[0].Rows)
                        {
                            PzaPaq = Convert.ToInt32(item[0] is DBNull ? 0 : item[0]);
                        }
                        if (IdDespacho != "0")
                        {
                            try
                            {
                                var myForm = new CronogramaItem(IdDespacho, ItemId, DescItem, PzaPaq, _idSucursal, PzaReq, PzaProg);
                                myForm.Show();
                            }
                            catch (Exception err)
                            {
                                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                                Console.WriteLine("################## = " + err.ToString());
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Seleccione un item de la lista", "Error");
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("################## = GRIDCONTROL 2 NO SELECCIONA");
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        //////////////////////////////////////////////////////////
        public class DetalleProducto
        {
            private string ItemId;
            private string Descripcion;
            private int PiezasReq;
            private int PiezasProg;
            private int PiezasComp;
            private decimal Peso;

            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public int p_PiezasReq
            {
                get { return PiezasReq; }
                set { PiezasReq = value; }
            }
            public int p_PiezasProg
            {
                get { return PiezasProg; }
                set { PiezasProg = value; }
            }
            public int p_PiezasComp
            {
                get { return PiezasComp; }
                set { PiezasComp = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
        }

        private void btnLecturar_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    _Fecha = Convert.ToDateTime(view.GetRowCellDisplayText(row[0], view.Columns[1]));
                    if (IdDespacho != "0")
                    {
                        int Sucursal = _idSucursal;
                        var myForm = new ListaLecturadoA(IdDespacho, _Fecha, Sucursal);
                        //this.Enabled = false;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                    Console.WriteLine("################ = " + err.ToString());
                }
            }
        } 
        private void btnControlDespacho_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new ControlDespacho(IdDespacho);
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
    }
}