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
    public partial class SincronizarAgregar : Form
    {
        private string sucursaL;
        private string iteM;
        private DataSet data2;
        private DataSet data1;
        CProduccionesCerradas cp;
        public SincronizarAgregar(string sucursal,string item,string orden,string centro,string cantidad,string unidad,DataSet consumido,DataSet producido)
        {
            InitializeComponent();
            this.sucursaL = sucursal;
            this.iteM = item;
            cp = new CProduccionesCerradas();
            this.txtfecha.Text=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.txtorden.Text = orden;
            this.txtcentro.Text = centro;
            this.txtcant.Text = cantidad;
            this.txtunidad.Text = unidad;
            this.data1 = consumido;
            this.data2 = producido;
        }
        private void SincronizarAgregar_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string orden = this.txtorden.Text.ToString();
            string prod = this.txtproducto.Text.ToString();
            string prod2 = this.txtprod2.Text.ToString();
            string cant = this.txtcant.Text.ToString();
            string cent = this.txtcentro.Text.ToString();
            string fech = this.txtfecha.Text.ToString();
            string unid = this.txtunidad.Text.ToString();
            try
            {
                string consulta = String.Empty;
                bool resp = false;
                //consumido
                foreach (DataRow item in this.data1.Tables[0].Rows)
                {

                    consulta = String.Format("insert into tblMovSync (ordenid,fecha,centrotrabajo,status,tipoorden,sucursalid, " +
                                           " sucursaldestino,ordenligada,itemfligado,esdecliente)values " +
                                           " ('{0}',sysdatetime(),'{1}','OPEN','{3}',{4},{5},'','{6}',{7})", orden, cent, "PRODUCCION", this.sucursaL, 0, 6748, 0);
                    resp = cp.ejecutar(consulta);
                }
                foreach (DataRow item in this.data2.Tables[0].Rows)
                {
                    consulta = String.Format("insert into tblMovSyncDet (OrdenId,ItemPV,ItemF,Piezas,Peso,Metros,CostoUnitario,PrecioTon,Calidad,Cantidad,Unidad,TipoMovimiento,PorcDistribucion)" +
                                          " values('{0}','{1}',{2},{2},{3},{4}, {5},{6},'',{7},'{8}',{9},{10})", orden, this.iteM, item[5].ToString(), 8555, 0, 0, 0, cant, unid, 2, 0);
                    resp = cp.ejecutar(consulta);
                }               
               
                MessageBox.Show("SE GUARDO CORRECTAMENTE","INFORMATION");
            }
            catch ( Exception er)
            {
                MessageBox.Show("Ocurrio un error al guardar los datos =>"+er.Message,"INFORMATION");               
            }

            
        
        }
    }
}
