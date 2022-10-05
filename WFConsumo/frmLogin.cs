using CRN.Componentes;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WFConsumo
{
    public partial class frmLogin : Form
    {
        CUsuario user;
        Usuario Udata;
        private string contra = String.Empty;
        private bool ver=false;
        public frmLogin()
        {
            InitializeComponent();
            user = new CUsuario();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (this.txtpas.Text != "" && this.txtlog.Text != "")
            {
                if (user.Logueado(this.txtlog.Text.ToString(), this.contra))
                {
                    Entidades.utilitario.sUsuario = this.txtlog.Text.ToString();
                    Udata = new Usuario();
                    DataSet u = user.DataUsuario(this.txtlog.Text.ToString());
                    if(u.Tables[0].Rows.Count > 0) { 
                    foreach (DataRow item in u.Tables[0].Rows)
                    {
                        Udata.Activo=int.Parse(item[3].ToString());
                        Udata.Clave=item[1].ToString();
                        Udata.EmpleadoId=int.Parse(item[4].ToString());
                        Udata.Id_Grupo=int.Parse(item[2].ToString());
                        Udata.Login=item[0].ToString();
                        Udata.Nivel=int.Parse(item[5].ToString());
                        Udata.Nombre=item[6].ToString();
                        Entidades.utilitario.sUsuario = this.txtlog.Text;
                        Entidades.utilitario.sContraseña = this.txtpas.Text;
                        Entidades.utilitario.sNombreUsuario = item[6].ToString();
                        Entidades.utilitario.iCodEmpleado = int.Parse(item[4].ToString());
                     }
                    this.Hide();
                    this.txtlog.Text = "";
                    this.txtpas.Text = "";


                        string sPC = Environment.MachineName;
                    switch (sPC)
                    {
                        case "PLANTA2":
                            frmOrdenAbiertaNew frm1 = new frmOrdenAbiertaNew("'LINEA01'", Udata);
                            frm1.Show();
                            break;
                        case "PLANTA3":
                            frmOrdenAbiertaNew frm2 = new frmOrdenAbiertaNew("'LINEA02'", Udata);
                            frm2.Show();
                            break;
                        case "PV-LINEA3F":
                            frmOrdenAbiertaNew frm3 = new frmOrdenAbiertaNew("'LINEA03'", Udata);
                            frm3.Show();
                            break;
                        case "PV-TREF-SAL":
                            frmOrdenAbiertaNew frm4 = new frmOrdenAbiertaNew("'TREF01'", Udata);
                            frm4.Show();
                            break;
                        case "PV-GRAF-SAL":
                            frmOrdenAbiertaNew frm5 = new frmOrdenAbiertaNew("'GRAF01'", Udata);
                            frm5.Show();
                            break;
                        case "PV-HORNO2"://HORNO01
                            frmOrdenAbiertaNew frm6 = new frmOrdenAbiertaNew("'HORNO02'", Udata);
                            frm6.Show();
                            break;
                        case "SARCOIL2":
                            frmOrdenAbiertaNew frm7 = new frmOrdenAbiertaNew("'PERFIL03'", Udata);
                            frm7.Show();
                            break;
                        case "PV-BONAK2"://PERFIL02-pv-bonak01-sal04
                            frmOrdenAbiertaNew frm8 = new frmOrdenAbiertaNew("'PERFIL02','PV-BONAK01'", Udata);
                            frm8.Show();
                            break;
                        case "PV-BONAK01"://PERFIL02-pv-bonak01-sal04

                            frmOrdenAbiertaNew frm10 = new frmOrdenAbiertaNew("'PV-BONAK01'", Udata);
                            frm10.Show();
                            break;
                        case "VALENTIN1":
                            frmOrdenAbiertaNew frm9 = new frmOrdenAbiertaNew("'SLI01'", Udata);
                            frm9.Show();
                            break;
                        default:
                            frmMain frm = new frmMain(Udata, this);
                            frm.Show();
                            break;

                    }
                    }
                    else
                    {
                        this.labelX4.Visible = true;
                        this.labelX4.Text = "Usuario No Asignado a un Grupo comuniquese con sistemas, Intente nuevamente";
                    }


                }
                else
                {
                    this.labelX4.Visible = true;
                    this.labelX4.Text = "Usuario No encontrado, Intente nuevamente";
                }
            }
            else 
            {
                this.labelX4.Visible = true;
                this.labelX4.Text = "Llenar los datos correspondientes Por Favor.";
            }         
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            //this.txtpas.pas
            if (!ver)
            {
                this.txtpas.Text = this.contra;
                ver = true;
            }
            else 
            {
                ver = false;
                string repla = String.Empty;
                for (int i = 0; i <this.contra.Length; i++)
                {
                    repla = repla + "*";
                }
                this.txtpas.Text = repla;
            
            }
            
            // string texto = this.txtpas.Text;
            //this.txtpas.Text = texto;
        }

        private void txtpas_KeyPress(object sender, KeyPressEventArgs e)
        {

           if (e.KeyChar == 8)
           {
                if(this.contra.Length>=1)
                    this.contra = this.contra.Substring(0, contra.Length - 1);
            }
            else {
                this.contra = this.contra + "" + e.KeyChar;
                if (!ver)
                    e.KeyChar = '*';
               
            
            }
                
        }

        private void txtpas_TextChanged(object sender, EventArgs e)
        {
            if (ver)
            {
                this.contra = this.txtpas.Text;
            }
        }

        private void txtpas_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX1.PerformClick();
            }
        }

        private void txtpas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX1.PerformClick();
            }
        }

        private void txtlog_Enter(object sender, EventArgs e)
        {
            if(txtlog.Text == "USUARIO")
            {
                txtlog.Text = "";
                txtlog.ForeColor = Color.LightGray;
            }
        }

        private void txtlog_Leave(object sender, EventArgs e)
        {
            if (txtlog.Text == "")
            {
                txtlog.Text = "USUARIO";
                txtlog.ForeColor = Color.DimGray;
            }
        }

        private void txtpas_Enter(object sender, EventArgs e)
        {
            if (txtpas.Text == "PASSWORD")
            {
                txtpas.Text = "";
                txtpas.ForeColor = Color.LightGray;
            }
        }

        private void txtpas_Leave(object sender, EventArgs e)
        {
            if (txtpas.Text == "")
            {
                txtpas.Text = "PASSWORD";
                txtpas.ForeColor = Color.DimGray;
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
