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
using CRN.Entidades;
using WFConsumo.Recepcion;
using WFConsumo.pryEnsayo;
using WFConsumo.frmGRH.DespachoOrdenEntrega;
using WFConsumo.frmGRH.DespachoOrdenListaCerrar;
using WFConsumo.frmGRH.Traspaso;
using WFConsumo.frmGRH.DespachoOrdenEnProceso;
using WFConsumo.frmGRH;
using WFConsumo.frmGRH.DespachoOrdenCerrada;

namespace WFConsumo
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        frmPlantillas frmp;
        Usuario user;
        frmLogin ocu;
        public frmMain(Usuario u,frmLogin oculto)            
        {
            InitializeComponent();
            user = u;
            ocu = oculto;
            EligiendoSucursal();
           frmp = new frmPlantillas(user.EmpleadoId);
           frmp.Dock = DockStyle.Fill;
            frmp.TopLevel = false;
            this.panel1.Controls.Add(frmp);
            this.panel1.Tag = frmp;
            this.labelX2.Text = user.Nombre;
            //this.barListItem1.Links.Add(user.Nombre);
            // form.Bounds = this.panel1.Bounds;
           //frmp.Show();
            frmp.Visible = false;
        }
        private int sucursalId;
        private string sucursallocal;
        private int apagar = -1;
        public void EligiendoSucursal()
        {
            CUsuario Udata = new CUsuario();
            DataSet dt = Udata.DataSucursalxUsuario(user.Login);
            if (dt.Tables[0].Rows.Count == 1)
            {
                sucursallocal = dt.Tables[0].Rows[0]["Nombre"].ToString();
                //sucursalId = Convert.ToInt32(dt.Tables[0].Rows[0]["SucursalId"]);
                Entidades.utilitario.iSucursal = Convert.ToInt32(dt.Tables[0].Rows[0]["SucursalId"].ToString());
                DataSet dt1 = Udata.DataAlmacenxUsuario(Convert.ToInt32(dt.Tables[0].Rows[0]["SucursalId"].ToString()));
                if (dt.Tables[0].Rows.Count > 0)
                    Entidades.utilitario.iAlmacen = Convert.ToInt32(dt1.Tables[0].Rows[0]["AlmacenId"].ToString());
            }
            else
            {
                if (dt.Tables[0].Rows.Count > 1)
                {
                    string sucursal = string.Empty;
                    frmOpcionSucursal op = new frmOpcionSucursal();
                    op.ShowDialog();
                    op.prueba(ref sucursal);
                    sucursallocal = sucursal;
                }
            }
            this.labelX1.Text = sucursallocal;
            getIdSuc();
        }
        public void getIdSuc()
        {
            //
            try
            {
                CUsuario Udata = new CUsuario();
                DataSet dat = Udata.DataSucursalxUsuario(user.Login);
                foreach (DataRow item in dat.Tables[0].Rows)
                {
                    if (item[1].ToString() == sucursallocal)
                    {
                        sucursalId = Convert.ToInt32(item[0]);
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("################# = " + err.ToString());
            } 
            //
        }
        private void Viewform(Form _form)
        {
            _form.MdiParent = this;
            _form.Show();
        }
        private void bbRevision_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerOrdenes frm = new frmVerOrdenes(12070);
            Viewform(frm);
        }
        private void bbSincronizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGeneraProduccion frm = new frmGeneraProduccion("OPEN",12070);
            Viewform(frm);
        }
        private void bbHistorial_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGeneraProduccion frm = new frmGeneraProduccion("CLOSE", 12070);
            Viewform(frm);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
        }
        private void navBarControl1_Click(object sender, EventArgs e)
        {
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {           
        }        
        private void ribbon_Click(object sender, EventArgs e)
        {            
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }    
        public void CargarFormInicial(Form form) 
        {
            form.Dock = DockStyle.Fill;           
            form.TopLevel = false;
            this.panel1.Controls.Add(form);
            this.panel1.Tag = form;
           // form.Bounds = this.panel1.Bounds;
            form.Show();    
        }
        private void gridView1_Click(object sender, EventArgs e)
        {           
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        { 
                      
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {           
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {           
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void buttonX4_Click_1(object sender, EventArgs e)
        {
    
        }
        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmp.Dock = DockStyle.Fill;
            frmp.TopLevel = false;
            this.panel1.Controls.Add(frmp);
            this.panel1.Tag = frmp;
            // form.Bounds = this.panel1.Bounds;
            frmp.Show();
        }
        private void navBarItem1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmTablas frmT = new frmTablas();
            frmT.TopLevel = false;
            this.panel1.Controls.Add(frmT);
            this.panel1.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.Show();
        }
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmOrdenesAbiertas frmT = new frmOrdenesAbiertas(user);
            frmT.TopLevel = false;
            this.panel1.Controls.Add(frmT);
            this.panel1.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.Show();
        }
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ORDENES CERRADAS
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmEnsayosCerrados frmT = new frmEnsayosCerrados(sucursallocal, user);
            frmT.TopLevel = false;
            this.panel1.Controls.Add(frmT);
            this.panel1.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            //frmT.CargaraEnsayos(" ");
            frmT.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
            
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
            
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //don valentin
            if (this.labelX1.Text != "PLANTA DON VALENTIN")
            {
                this.labelX1.Text = "PLANTA DON VALENTIN".ToString();
                sucursallocal = "12071";
                sucursalId = 12071;
                this.panel1.Controls.RemoveAt(0);
                frmp.Dock = DockStyle.Fill;
                frmp.TopLevel = false;
                this.panel1.Controls.Add(frmp);
                this.panel1.Tag = frmp;
                // form.Bounds = this.panel1.Bounds;
                frmp.Show();
            }
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //1o hectareas
            if (this.labelX1.Text != "PLANTA 10 HECTAREAS")
            {
                this.labelX1.Text = "PLANTA 10 HECTAREAS".ToString();
                sucursallocal = "12081";
                sucursalId = 12081;
                this.panel1.Controls.RemoveAt(0);
                frmp.Dock = DockStyle.Fill;
                frmp.TopLevel = false;
                this.panel1.Controls.Add(frmp);
                this.panel1.Tag = frmp;
                // form.Bounds = this.panel1.Bounds;
                frmp.Show();
            }
        }
        private void navBarItem8_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //cerrar sesion
            apagar = 0;
            this.Close();
            ocu.Show();
            
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //salir absolutamente
            if(apagar==0)
            {              
            }else
                Application.Exit();
            
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ORDENES ABIERTAS
            if(this.panel1.Controls.Count>0)
                this.panel1.Controls.RemoveAt(0);
            frmOrdenAbiertaNew abierta = new frmOrdenAbiertaNew(user);
            abierta.TopLevel = false;
            this.panel1.Controls.Add(abierta);
            this.panel1.Tag =abierta;
            abierta.Dock = DockStyle.Fill;
            abierta.Show();
        }
        private void navBarItem9_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmReportes rpt = new frmReportes();
           rpt.TopLevel = false;
           this.panel1.Controls.Add(rpt);
           this.panel1.Tag = rpt;
           rpt.Dock = DockStyle.Fill;
           rpt.Show();
        }
        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Parametro rpt = new Parametro();
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmSector rpt = new frmSector(sucursallocal,user.EmpleadoId);
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            historialesProd_Fallas rpt = new historialesProd_Fallas(1);
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            historialesProd_Fallas rpt = new historialesProd_Fallas(2);
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmConformidad rpt = new frmConformidad(int.Parse(sucursallocal));
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
           
            rpt.Show();
        }
        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmFormulariosIndependientes rpt = new frmFormulariosIndependientes();
            rpt.TopLevel = false;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            ReporteNoConforme rpt = new ReporteNoConforme();
            rpt.TopLevel = false;
            rpt.FormBorderStyle=FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //PRODUCCION
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            ProduccionesCerradas rpt = new ProduccionesCerradas(this.sucursallocal);
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            SincronizacionInventario rpt = new SincronizacionInventario(this.sucursallocal);
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            apagar = 0;
            this.Close();
            ocu.Show();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmOrdenesProduccion rpt = new frmOrdenesProduccion(this.sucursallocal);
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ordenproceso
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            FrmOrdenEnProceso rpt = new FrmOrdenEnProceso(user.Login);
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;

            if(rpt.seleccionadoLocal!="")
                rpt.Show();           
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ordenespera         

           /* if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            FrmFOrdenAbierta rpt = new FrmFOrdenAbierta(user.Login);
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            if (!rpt.seleccionadoLocal.Equals(""))
                rpt.Show();*/
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //esperandoordenes
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            FrmOrdenEspera rpt = new FrmOrdenEspera();
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //imprimir
            /*if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            FrmOrdenPrint rpt = new FrmOrdenPrint();
            rpt.TopLevel = false;
            rpt.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(rpt);
            this.panel1.Tag = rpt;
            rpt.Dock = DockStyle.Fill;
            rpt.Show();*/
        }
        private void navBarControl2_Click(object sender, EventArgs e)
        {
        }

        private void nviRecepcion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //esperandoordenes
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmPackingList frmPack = new frmPackingList();
            frmPack.TopLevel = false;
            frmPack.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmPack);
            this.panel1.Tag = frmPack;
            frmPack.Dock = DockStyle.Fill;
            frmPack.Show();
        }

        private void navBarItem23_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmGenCC frmgen = new frmGenCC();
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
        }

        private void navBarItem25_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmRecepInt frmgen = new frmRecepInt(user,"OPEN");
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmAdmAnotacion frmAnot = new frmAdmAnotacion("INPROCESS");
            frmAnot.TopLevel = false;
            this.panel1.Controls.Add(frmAnot);
            this.panel1.Tag = frmAnot;
            frmAnot.Dock = DockStyle.Fill;
            frmAnot.Show();
        }

        private void nvitem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmPaquetes frmAnot = new frmPaquetes();
            frmAnot.TopLevel = false;
            this.panel1.Controls.Add(frmAnot);
            this.panel1.Tag = frmAnot;
            frmAnot.Dock = DockStyle.Fill;
            frmAnot.Show();
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ORDENES CERRADAS
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmEnsayos frmT = new frmEnsayos(0);
            frmT.TopLevel = false;
            this.panel1.Controls.Add(frmT);
            this.panel1.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.CargaraEnsayos("1");
            frmT.Show();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmProductos frmT = new frmProductos();
            frmT.TopLevel = false;
            this.panel1.Controls.Add(frmT);
            this.panel1.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.Show();
        }
        private void DespachoAbierto_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            
            frmListaDespachoMercaderia frmListaDespacho = new frmListaDespachoMercaderia(user, sucursalId);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }

        private void DespachoEnProceso_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmListaOrdenEnProceso frmListaDespacho = new frmListaOrdenEnProceso(user, sucursalId);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }

        private void DespachoParcial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmListaOrdenEntrega frmListaDespacho = new frmListaOrdenEntrega(user, sucursalId);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }

        private void DespachoListoCerrar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmListaOrdenListaCerrar frmListaDespacho = new frmListaOrdenListaCerrar(user, sucursalId);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }
        private void DespachoCerrado_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            DfrmListaOrdenCerrada frmListaDespacho = new DfrmListaOrdenCerrada(user, sucursalId);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }
        private void Traspasos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            NuevoTraspaso frmListaDespacho = new NuevoTraspaso(user, sucursalId, sucursallocal);
            frmListaDespacho.TopLevel = false;
            this.panel1.Controls.Add(frmListaDespacho);
            this.panel1.Tag = frmListaDespacho;
            frmListaDespacho.Dock = DockStyle.Fill;
            frmListaDespacho.Show();
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmCCI frmgen = new frmCCI(user);
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
        }

       

        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmAdmAnotacion frmAnot = new frmAdmAnotacion("CLOSE");
            frmAnot.TopLevel = false;
            this.panel1.Controls.Add(frmAnot);
            this.panel1.Tag = frmAnot;
            frmAnot.Dock = DockStyle.Fill;
            frmAnot.Show();
        }

        private void navBarItem31_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmRecepInt frmgen = new frmRecepInt(user, "CLOSE");
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
        }

        private void navBarItem29_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmAdmAnotacion frmAnot = new frmAdmAnotacion("CLOSE");
            frmAnot.TopLevel = false;
            this.panel1.Controls.Add(frmAnot);
            this.panel1.Tag = frmAnot;
            frmAnot.Dock = DockStyle.Fill;
            frmAnot.Show();
        }

        private void navBarItem30_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmRecepInt frmgen = new frmRecepInt(user, "CLOSE");
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
        }

        private void nvRecDesp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            frmRecepDespacho frmgen = new frmRecepDespacho(user, "TRANSITO");
            frmgen.TopLevel = false;
            frmgen.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(frmgen);
            this.panel1.Tag = frmgen;
            frmgen.Dock = DockStyle.Fill;
            frmgen.Show();
            
        }
    }
}