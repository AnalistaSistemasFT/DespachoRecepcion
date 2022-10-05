using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRN.Componentes;

namespace WFConsumo
{
    public partial class frmPrincipal : Form
    {
        static int sucursal;
        private readonly Dictionary<string, Form> ventanasActivas;
        public frmPrincipal()
        {
            InitializeComponent();
            ventanasActivas = new Dictionary<string, Form>();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void revisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sucursal > 0)
            {
                string clave = "ventana1";
                frmVerOrdenes frm;
                if (ventanasActivas.ContainsKey(clave))
                {
                    frm = ventanasActivas[clave] as frmVerOrdenes;
                    frm.Activate();
                }
                else
                {
                    this.MdiChildren.OfType<Form>().ToList().ForEach(x => x.Close());
                frm = new frmVerOrdenes(sucursal);
                    frm.MdiParent = this;
                    frm.FormClosing += ((s, ex) => ventanasActivas.Remove(clave));
                    ventanasActivas.Add(clave, frm);
                    frm.Show();
                }
                //frmVerOrdenes frm = new frmVerOrdenes(sucursal);
                //frm.MdiParent = this;
                //frm.Show();
            }
            else
                MessageBox.Show("Debe seleccionar una Sucursal","",MessageBoxButtons.OK);
        }

        private void sincronizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sucursal > 0)
            {
                string clave = "ventana2";
                frmGeneraProduccion frm;
                if (ventanasActivas.ContainsKey(clave))
                {
                    frm = ventanasActivas[clave] as frmGeneraProduccion;
                    frm.Activate();
                }
                else
                {
                    this.MdiChildren.OfType<Form>().ToList().ForEach(x => x.Close());

                    frm = new frmGeneraProduccion("OPEN",sucursal);
                    frm.MdiParent = this;
                    frm.FormClosing += ((s, ex) => ventanasActivas.Remove(clave));
                    ventanasActivas.Add(clave, frm);
                    frm.Show();
                }
                //frmGeneraProduccion frm = new frmGeneraProduccion("OPEN",sucursal);
                //frm.MdiParent = this;
                //frm.Show();
            }
            else
                MessageBox.Show("Debe seleccionar una Sucursal", "", MessageBoxButtons.OK);
        }

        // private void hasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    sucursal = 12081;
        //    tsSucursal.Text = hasToolStripMenuItem.Text;
        //}

        //private void pDVToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    sucursal = 12070;
        //    tsSucursal.Text = pDVToolStripMenuItem.Text;

        //}

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarSucursal();
        }

        void CargarSucursal() 
        {
            CSucursal cSuc = new CSucursal();
            string where = "ferrotodo='True'";
            DataSet ds = cSuc.TraerTodasLasSucursales(where);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ToolStripItem fs = new ToolStripMenuItem();
                fs.Text = dr["Nombre"].ToString();
                fs.Tag = dr["SucursalId"].ToString(); 

                tsSucursal.DropDownItems.Add(fs);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void tsSucursal_Click(object sender, EventArgs e)
        {

        }

        private void tsSucursal_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sucursal = Convert.ToInt32(e.ClickedItem.Tag.ToString());
            tsSucursal.Text = e.ClickedItem.Text.ToString();
            this.MdiChildren.OfType<Form>().ToList().ForEach(x => x.Close());
         }

        private void historialSincronizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sucursal > 0)
            {
                string clave = "ventana3";
                frmGeneraProduccion frm;
                if (ventanasActivas.ContainsKey(clave))
                {
                    frm = ventanasActivas[clave] as frmGeneraProduccion;
                    frm.Activate();
                }
                else
                {
                    frm = new frmGeneraProduccion("CLOSE", sucursal);
                    frm.MdiParent = this;
                    frm.FormClosing += ((s, ex) => ventanasActivas.Remove(clave));
                    ventanasActivas.Add(clave, frm);
                    frm.Show();
                }
                //frmGeneraProduccion frm = new frmGeneraProduccion("CLOSE", sucursal);
                //frm.MdiParent = this;
                //frm.Show();
            }
            else
                MessageBox.Show("Debe seleccionar una Sucursal", "", MessageBoxButtons.OK);
        }
    }
}
