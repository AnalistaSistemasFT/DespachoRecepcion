using CRN.Componentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class FrmOrdenEnProceso : Form
    {
        private string centro,operadorO,ordenId;
        public string seleccionadoLocal;
        COrdenProduccionV2 corden;
        public FrmOrdenEnProceso(string operador)
        {
            InitializeComponent();
            iniciarseleccionArea();  
            if (seleccionadoLocal.Equals(""))
            {
                this.Close();
            }
            else 
            {
                corden = new COrdenProduccionV2();
                this.operadorO = operador;
                recojerordenenProceso();                  
            }
           
        }
        void recojerordenenProceso() 
        {
            string consulta = "select * from tblOrdenProduccion where status = 'INPR' or status = 'PROCESO'";
            var data = corden.retornarTabla(consulta);
            if(data.Tables[0].Rows.Count>0)
            {
                ordenId = data.Tables[0].Rows[0]["sOrdenId"].ToString();            
            }
            
        }

        void iniciarseleccionArea()
        {
            FrmCentroTrabajosEscoger recp = new FrmCentroTrabajosEscoger();
            recp.ShowDialog();
            seleccionadoLocal = recp.seleecionado;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2.Controls.Count > 0)
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
            FrmOrdenEspera frmT = new FrmOrdenEspera();
            frmT.TopLevel = false;
            this.splitContainer1.Panel2.Controls.Add(frmT);
            this.splitContainer1.Panel2.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.FormBorderStyle = FormBorderStyle.None;
            frmT.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2.Controls.Count > 0)
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
            FrmOrdenPrint frmT = new FrmOrdenPrint(this.ordenId,this.operadorO);
            frmT.TopLevel = false;
            this.splitContainer1.Panel2.Controls.Add(frmT);
            this.splitContainer1.Panel2.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.FormBorderStyle = FormBorderStyle.None;
            frmT.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2.Controls.Count > 0)
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
            FrmFOrdenAbierta frmT = new FrmFOrdenAbierta(this.operadorO,this.seleccionadoLocal);
            frmT.TopLevel = false;
            this.splitContainer1.Panel2.Controls.Add(frmT);
            this.splitContainer1.Panel2.Tag = frmT;
            frmT.Dock = DockStyle.Fill;
            frmT.FormBorderStyle = FormBorderStyle.None;
            frmT.Show();

        }

        private void FrmOrdenEnProceso_Load(object sender, EventArgs e)
        {

        }



    }
}
