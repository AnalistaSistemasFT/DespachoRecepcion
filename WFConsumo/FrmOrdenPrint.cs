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
using System.Drawing;
using ZXing;
using System.IO;
using CRN.Entidades;
namespace WFConsumo
{
    public partial class FrmOrdenPrint : Form
    {
        COrdenProduccionV2 corden;
        ProduccionDetalle ord;
        private string ruta,calidad,medida;
        public FrmOrdenPrint(string orden,string operador)
        {
            InitializeComponent();
            corden = new COrdenProduccionV2();
            cargardataparaimprimir( orden);
            this.textBox18.Text = operador;
        }
        public void cargardataparaimprimir(string orden) 
        {
            string consulta = String.Format("select * from tblOrdenProduccion where status != 'INPR' or status != 'PROCESO' and sOrdenId='{0}'",orden);
            var data = corden.retornarTabla(consulta);
            this.comboBox1.Items.Add(data.Tables[0].Rows[0]["sOrdenId"].ToString());
            this.comboBox1.SelectedIndex = 0;
            this.textBox2.Text = data.Tables[0].Rows[0]["sitemid"].ToString();
            this.textBox3.Text = data.Tables[0].Rows[0]["sGrupoProd"].ToString();            
            //data = corden.retornarTabla(String.Format("select ItemId from tblpaquetes where tblpaquetes.paqueteid='2105R801379'"));
            data = corden.retornarTabla(String.Format("select * from tblItem where ItemId = '{0}'",this.textBox2.Text.ToString()));
            this.medida = data.Tables[0].Rows[0]["Descripcion"].ToString();
            int posi = medida.IndexOf('*', 1);
            this.medida = this.medida.Substring(posi,(medida.Length-posi));            
            this.calidad = data.Tables[0].Rows[0]["Calidad"].ToString(); 
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void labelX4_Click(object sender, EventArgs e)
        {

        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //imprimir  GUARDAMOS A CA EN LA TABLA TBLPRDODUCCUIONDETALLE PERO CON P  DE PRODUCIDO
            ord = new ProduccionDetalle();
            ord.peso = decimal.Parse(this.textBox7.Text.ToString());
            ord.metros = decimal.Parse(this.textBox12.Text.ToString());
            ord.ordenid = this.comboBox1.SelectedItem.ToString();
            ord.fechafinal = this.dateTimePicker1.Value.ToString();
            ord.operador = this.textBox18.Text.ToString();
            ord.turno = this.comboBox6.SelectedItem.ToString();
            ord.tipo = "P";            
            ord.itemid = this.textBox2.Text.ToString();            
        }
        private void FrmOrdenPrint_Load(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //generar codigo de barras
            BarcodeWriter cod = new BarcodeWriter();
            //cod.Format = BarcodeFormat.MAXICODE;           
            //   Bitmap bm = new Bitmap(cod.Write("4343fs453"),300,300);
            // pictureBox1.Image = bm;
            // generarcodigo();
        }
        void generarcodigo(string orden)
        {
            

            ZXing.OneD.Code128Writer dd = new ZXing.OneD.Code128Writer();
            ZXing.Common.BitMatrix byteIMGNew1 = dd.encode(orden, ZXing.BarcodeFormat.CODE_128, 1, 1);
            //pictureBox1.Image= byteIMGNew1.ToBitmap(ZXing.BarcodeFormat.CODE_128,orden);
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String Imagename =  Path +"\\"+ "PRUEBA" + ".png";
            ruta = Imagename;
            if (!File.Exists(Imagename))
            {
                File.Create(Imagename).Close();
            }
            else
            {
                File.Delete(Imagename);
                File.Create(Imagename).Close();
            }
            byteIMGNew1.ToBitmap(ZXing.BarcodeFormat.CODE_128, orden).Save(Imagename, System.Drawing.Imaging.ImageFormat.Png);
            byteIMGNew1.ToBitmap(ZXing.BarcodeFormat.CODE_128, orden).Dispose();
            byteIMGNew1.clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //ver para imprimir            
            if (this.panel7.Controls.Count > 0)
                this.panel7.Controls.RemoveAt(0);
            try
            {
                string code = this.comboBox1.SelectedItem.ToString();
                string peso = this.textBox7.Text.ToString() + " Kg";
                string loongi = this.textBox9.Text.ToString() + " mm";
                string codigo = this.textBox2.Text.ToString();
                generarcodigo(code);
                frmEtiqueta1 frmp = new frmEtiqueta1(code, medida, loongi, peso, "1", this.calidad, codigo, ruta);
                frmp.Dock = DockStyle.Fill;
                frmp.TopLevel = false;
                this.panel7.Controls.Add(frmp);
                this.panel7.Tag = frmp;
                frmp.FormBorderStyle = FormBorderStyle.None;
                // form.Bounds = this.panel1.Bounds;
                frmp.Show();
            }
            catch (Exception eror)
            {
                MessageBox.Show("Rellenar todos los campos necesarios para continuar con el proceso","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }            
        }
        private void labelX6_Click(object sender, EventArgs e)
        {
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            PrintDialog printDialog1 = new PrintDialog();
            //printDialog1.Document = ;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //printDocument1.Print();
            }  
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
        }
    }
}
