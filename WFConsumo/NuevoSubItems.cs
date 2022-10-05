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

namespace WFConsumo
{
    public partial class NuevoSubItems : Form
    {
        CParametros cparam = new CParametros();
        CSector sect = new CSector();
        Sector Objsector;
        private string tipoItem;
        private string centro;
        public int sector;
        public int ref1;
        public int filaPrincipal;
        public NuevoSubItems(string centro,string tipo)
        {
            InitializeComponent();
            this.labelX1.Text =  "Centro de Trabajo "+centro.ToString();
            this.labelX3.Text = "Seleccionar "+tipo;
            tipoItem = tipo;
            this.centro = centro;
        }
        private void NuevoSubItems_Load(object sender, EventArgs e)
        {
        }
        public void cargarcentros(string tipo)
        {
            string consulta =String.Format( "select id_parametro,parametro_desc from Cat_Parametro where tipo_parametro='{0}'",tipo);
            DataSet ff = cparam.retornarTabla(consulta);
            this.comboBoxEx1.DataSource = ff.Tables[0];
            this.comboBoxEx1.DisplayMember = "parametro_desc";
            this.comboBoxEx1.ValueMember = "id_parametro";       
        }       
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Objsector = new Sector();
            string sentencia = "";
            int d;
            d = int.Parse(this.comboBoxEx1.SelectedValue.ToString());
            switch (tipoItem)
            {
                case "Centro":
                    Objsector.Id_Centro = centro;
                    d = int.Parse(this.comboBoxEx1.SelectedValue.ToString());
                    Objsector.Id_Parametro = d;
                    Objsector.Id_Parametro1 = 0;
                    Objsector.Id_Parametro2 = 0;
                    sect.GuardarParam(Objsector);
                    break;
                case "Referencia 0":
                    sentencia = String.Format("select * from tblsector where id_parametro={0} and id_centro='{1}' and id_parametro1={2}",sector,centro,d );
                    if((sect.retornarTabla(sentencia)).Tables[0].Rows.Count==0)
                    {
                        d = int.Parse(this.comboBoxEx1.SelectedValue.ToString());
                        sentencia = String.Format("update tblsector set id_parametro1={0} where id_sector={1}  and id_parametro={2} and id_parametro1=0", d, filaPrincipal, sector);
                        if (!sect.SentenciaEjecut(sentencia)) 
                        {
                            Objsector.Id_Centro = centro;
                            Objsector.Id_Parametro = sector;
                            Objsector.Id_Parametro1 = d;
                            Objsector.Id_Parametro2 = 0;
                            sect.GuardarParam(Objsector);                          
                        }                                                
                    }else
                    {
                        Objsector.Id_Centro = centro;
                        Objsector.Id_Parametro = sector;
                        Objsector.Id_Parametro1 = d;
                        Objsector.Id_Parametro2 = 0;
                        sect.GuardarParam(Objsector);                     
                    }
                              
                   
                    break;
                case "Referencia 1":
                    
                    sentencia = String.Format("select * from tblsector where id_centro='{0}' and id_parametro={1} and  id_parametro1={2} and id_parametro2=0",centro,sector,ref1);
                    DataSet dd = sect.retornarTabla(sentencia);
                    if (dd.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in dd.Tables[0].Rows)
                        {
                            int fila = int.Parse(item[0].ToString());
                            sentencia = String.Format("update tblsector set id_parametro2={0} where  id_sector={1}", d, fila);
                            sect.SentenciaEjecut(sentencia);
                            break;
                        }
                    }
                    else 
                    {
                        Objsector.Id_Centro = centro;
                        Objsector.Id_Parametro = sector;
                        Objsector.Id_Parametro1 = ref1;
                        Objsector.Id_Parametro2 = d;
                        sect.GuardarParam(Objsector);                        
                    }                    
                    break;                    
            }
            MessageBox.Show("AGREGADO CORRECTAMENTE");
            this.Close();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
