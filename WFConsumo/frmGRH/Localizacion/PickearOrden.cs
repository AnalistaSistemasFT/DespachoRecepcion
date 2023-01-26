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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class PickearOrden : DevExpress.XtraEditors.XtraForm
    {
        CLocaliza C_Localiza;
        int IdSucursal = 0;
        string _PlanId = string.Empty;
        string _OrdeNro = string.Empty;
        List<Picked> _listPick = new List<Picked>();

        public PickearOrden(int _IdSucursal, string _NrOrden, string _centro, string _IdPlan)
        {
            InitializeComponent();
            txtOrden.Text = _NrOrden;
            txtCentroTrabajo.Text = _centro;
            IdSucursal = _IdSucursal;
            _PlanId = _IdPlan;
            _OrdeNro = _NrOrden;
            C_Localiza = new CLocaliza();
            TraerDatos();
        }
        public void TraerDatos()
        {
            try
            {
                DataSet ListPick = C_Localiza.TraerDatosPicking(_PlanId);
                foreach (DataRow item in ListPick.Tables[0].Rows)
                {
                    bool stat = true;
                    if (item[4].ToString() == "CLOSE")
                    {
                        stat = true;
                    }
                    else
                    {
                        stat = false;
                    }
                    _listPick.Add(new Picked
                    {
                        p_PaqueteId = item[0].ToString(),
                        p_AlmacenId = Convert.ToInt32(item[1]),
                        p_CeldaId = item[2].ToString(),
                        p_Fecha = Convert.ToDateTime(item[3]), 
                        p_Status = stat
                    });
                }
                gridControl1.DataSource = _listPick;
            }
            catch(Exception err)
            {
                Console.WriteLine("########################### = " + err.ToString());
            }
        }
        public class Picked
        {
            private string PaqueteId;
            private int AlmacenId;
            private string CeldaId;
            private DateTime Fecha;
            private bool Status;

            public string p_PaqueteId
            {
                get { return PaqueteId; }
                set { PaqueteId = value; }
            }
            public int p_AlmacenId
            {
                get { return AlmacenId; }
                set { AlmacenId = value; }
            }
            public string p_CeldaId
            {
                get { return CeldaId; }
                set { CeldaId = value; }
            }
            public DateTime p_Fecha
            {
                get { return Fecha; }
                set { Fecha = value; }
            }
            public bool p_Status
            {
                get { return Status; }
                set { Status = value; }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void btnConsolidar_Click(object sender, EventArgs e)
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
                    string _PaqueteId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    string _status = view.GetRowCellValue(row[0], view.Columns[4]).ToString();
                    if (_PlanId != string.Empty)
                    {
                        if(_status.ToLower() == "true")
                        {
                            XtraMessageBox.Show("Paquete ya consolidado", "Error");
                        }
                        else
                        {
                            int a = C_Localiza.ConsolidarPaquetePick(_PlanId, _PaqueteId);
                            if (a > 0)
                            {
                                _listPick.Clear();
                                TraerDatos();
                                XtraMessageBox.Show("Paquete consolidado", "Consolidar");
                            }
                            else
                            {
                                XtraMessageBox.Show("No se pudo consolidar el paquete seleccionado", "Error");
                            }
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
        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            try
            { 
                XtraMessageBox.AllowCustomLookAndFeel = true;
                DialogResult dialogResult = XtraMessageBox.Show("¿Cerrar la orden " + _OrdeNro + "?", "Salir", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    string sError = string.Empty;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("p_NroOrden");
                    dt.Columns.Add("p_PlanId");
                    dt.Columns.Add("p_PaqueteId");
                    dt.Columns.Add("p_Status");
                    DataRow dr = null;
                    foreach (var item in _listPick)
                    {
                        dr = dt.NewRow(); // have new row on each iteration
                        dr["p_NroOrden"] = _OrdeNro;
                        dr["p_PlanId"] = _PlanId;
                        dr["p_PaqueteId"] = item.p_PaqueteId;
                        dr["p_Status"] = item.p_Status;
                        dt.Rows.Add(dr);
                    }

                    //int a = C_Localiza.CerrarOrdenPicking(sError, _PlanId, _OrdeNro, dt);
                    //if(a > 0)
                    //{
                    //    XtraMessageBox.Show("La orden " + _OrdeNro + " se cerro", "Cerrar orden");
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    //}
                }
                else
                {
                    //
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("########################## = " + err.ToString());
            }
        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                GridColumn colPaq = view.Columns["p_PaqueteId"];
                if (colPaq == null) return;
                int[] selectedRowHandles = view.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    // Move focus to the first selected row.
                    view.FocusedRowHandle = selectedRowHandles[0];
                    // Copy the selection to the clipboard
                    view.CopyToClipboard();
                    // Copy the selected company names to a Memo editor.
                    for (int i = 0; i < selectedRowHandles.Length; i++)
                        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ = " + view.GetRowCellDisplayText(selectedRowHandles[i], colPaq) + "\r\n");
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("##################### = " + err.ToString());
            }
        }
    }
}