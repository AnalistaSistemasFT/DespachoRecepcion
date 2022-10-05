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
    public partial class frmGeneradorFormulas : Form
    {
        public frmGeneradorFormulas()
        {
            InitializeComponent();
        }

        private void frmGeneradorFormulas_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string text = this.textBoxX1.Text.ToString();
            this.Close();
        }
        public void textoA(ref string textos) 
        {
            textos = textBoxX1.Text.ToString();
        }
        private void listBoxAdv1_ItemClick(object sender, EventArgs e)
        {
            string text = listBoxAdv1.Items[listBoxAdv1.SelectedIndex].ToString();
            this.textBoxX1.Text = this.textBoxX1.Text.ToString() + "{" + text+"}".ToString();
            seleecionarfinal();
        }
        public void seleecionarfinal() 
        {
            this.textBoxX1.Focus();
            this.textBoxX1.SelectionStart = this.textBoxX1.Text.Length - 2;        
        }

        private void listBoxAdv2_ItemClick(object sender, EventArgs e)
        {
            string text = listBoxAdv2.Items[listBoxAdv2.SelectedIndex].ToString();
            this.textBoxX1.Text = this.textBoxX1.Text.ToString() + "" + text + "".ToString();
            seleecionarfinal();
        }

        private void listBoxAdv3_ItemClick(object sender, EventArgs e)
        {
            string text = listBoxAdv3.Items[listBoxAdv3.SelectedIndex].ToString();
            this.textBoxX1.Text = this.textBoxX1.Text.ToString() + "" + text + "".ToString();
            seleecionarfinal();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
