using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class frmModeloEnsayo : Form
    {
      
        CTblEnsayo ensayos;
        CTblEnsayoDetalle ensayodetalle;
        TblEnsayo tblens;
        List<TblEnsayoDetalle> tblensdetalle;
        OrdenProduccion ordenP;
        COrdenProduccion ordenProd;
        private string ord;
        private string grupEn;
        private int IDReg;
        private int ID_Empleado;
        private string sUsuario;
        public frmModeloEnsayo(int ids,string item,string orden,string grupo,string center,string paquete,int IdUser,string sUser)
        {
            InitializeComponent();
            ID_Empleado = IdUser;
            sUsuario = sUser;
            ensayos = new CTblEnsayo();
            ensayodetalle = new CTblEnsayoDetalle();
            ordenProd = new COrdenProduccion();
            grupEn = grupo;
            this.cargarCombo();
            ord = item;
            this.textBoxX4.Text = ord.ToString();
            this.textBoxX6.Text = orden.ToString();      
            this.lblfecha.Text=DateTime.Now.ToString();
            this.textBoxX3.Text = center.ToString();
            IDReg = ids != 0 ? ids : (obtenerIdSiguiente() + 1);
            this.textBoxX1.Text = IDReg.ToString();
            this.textBoxX5.Text = paquete.ToString();
            this.cbEstado.SelectedIndex = 1;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            //GUARDAR
            tblens = new TblEnsayo();
            ordenP = new OrdenProduccion();
            //tblens.IDEnsayo = 0 incrementabl
            tblens.FCreacion = Convert.ToDateTime(lblfecha.Text.ToString());
            tblens.ORDENid = this.textBoxX6.Text.ToString();
            tblens.ITEMid = this.textBoxX4.Text.ToString();
            tblens.CentroID = this.textBoxX3.Text.ToString();
            tblens.EmpleadoID = ID_Empleado;
            tblens.COLADA = "0";
            tblens.OBS = "ENSAYOS " + this.textBoxX2.Text.ToString();
            tblens.EnsayOID = int.Parse(this.textBoxX1.Text.ToString());
            //CRRELATIVO ULTUMO INCREMENTABLE
            tblens.CorrelativO = int.Parse(this.textBoxX1.Text.ToString());
            tblens.FEjecucion = Convert.ToDateTime(lblfecha.Text.ToString());
            tblens.PaqueteID = this.textBoxX5.Text.ToString();
            tblens.TIPO = this.cbxTipo.SelectedValue.ToString();
            tblens.STatus = "LISTA";
            tblens.TipoGeneracioN = "0";
            tblens.Result = "0";
            tblens.Estado1 = 1;
            tblens._Usuario = sUsuario;
            if (this.Text == "EDITAR")
            {
                tblens.IDEnsayo = this.IDReg;
                //ensayodetalle.EliminarParaInsertar(IDReg);
                /*foreach (var item in tblensdetalle)
                {
                    item.Limite = item.Limite == " " || item.Limite == "" ? "  " : item.Limite;
                    ensayodetalle.GuardarTblNuevoDetalle(item);
                }*/
                ensayos.ModificarTblNuevo(tblens, tblensdetalle,IDReg);
                //ver si esto sera correcto
                //ordenProd.Modificar(this.textBoxX6.Text.ToString(),1,DateTime.Now);
                MessageBox.Show(" El ensayo se actualizo correctamente ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else 
            {
                
              /*  foreach (var item in tblensdetalle)
                {
                    item.Limite = item.Limite == " " || item.Limite == "" ? "  " : item.Limite;
                    ensayodetalle.GuardarTblNuevoDetalle(item);
                }*/
                ensayos.GuardarTblNuevo(tblens,tblensdetalle);
                //orden
              /*ordenP.ID_Orden = this.textBoxX6.Text.ToString();
                ordenP.Fecha = tblens.FCreacion;
                ordenP.Estado = 0;
                ordenP.FechaEstado = tblens.FCreacion;
                ordenP.ItemId = this.textBoxX4.Text.ToString();
                ordenP.EmpleadoId = ID_Empleado;
                ordenP.CentroId = tblens.CentroID;
                ordenP.TipoEnsayo=int.Parse(this.comboBoxEx1.SelectedValue.ToString());
                ordenP.Operacion = 0;
                ordenProd.GuardarTablaNuevo(ordenP);*/
                MessageBox.Show(" El Ensayo se guardo Correctamente "," ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }            
        }
        public int obtenerIdSiguiente()
        {
            //string consulta = "SELECT distinct TOP 1 (Id_Ensayo)    FROM [dbo].[tblEnsayo]  ORDER BY Id_Ensayo DESC";
            DataSet d = ensayos.obtenerIdSiguiente();
            string ids = String.Empty;
            foreach (DataRow item in d.Tables[0].Rows)
            {
                ids = item[0].ToString();
            }
            return int.Parse(ids==""?"0":ids);       
        }
        private void frmModeloEnsayo_Load(object sender, EventArgs e)
        {
        }
        public void cargarCombo()
        {           
            //string consulta = String.Format("select [TipoId],[Descripcion] from tblTipoEnsayo where Grupo='{0}'",grupEn);
            DataSet variable = ensayos.retornarParaCargarCombo(grupEn);
            this.cbxTipoEnsayo.DataSource = variable.Tables[0];
            this.cbxTipoEnsayo.DisplayMember = "Descripcion";
            this.cbxTipoEnsayo.ValueMember = "TipoId";

            DataSet variable1 = ensayos.retornarParaCargarComboEnsayoTipo();
            this.cbxTipo.DataSource = variable1.Tables[0];
            this.cbxTipo.DisplayMember = "sDescEnsayo";
            this.cbxTipo.ValueMember = "idEnsayoTipo";

        }
        public void cargardataeditar(string colada)
        {
            tblensdetalle = new List<TblEnsayoDetalle>();
            DataSet variable = ensayos.retornarParaEditar(IDReg);
            this.cbEstado.SelectedIndex = 1;
            this.textBoxX1.Text = IDReg + "".ToString();
            this.textBoxX2.Text = colada + "".ToString();
            foreach (DataRow item in variable.Tables[0].Rows)
            {
                this.textBoxX6.Text=item[3].ToString();
                this.textBoxX4.Text=item[6].ToString();
                this.textBoxX3.Text=item[7].ToString();
                this.textBoxX5.Text=item[4].ToString();
                this.textBoxX2.Text=item[5].ToString();
            }
            DataSet dat = ensayos.retornardetalles(IDReg);           
            foreach (DataRow item in dat.Tables[0].Rows) 
            {
                TblEnsayoDetalle dd = new TblEnsayoDetalle();
                dd.Ensayo_ID =int.Parse( item[3].ToString());
                dd.ID_ensayo = int.Parse(item[1].ToString());
                dd.Descripcion = item[0].ToString();
                dd.ValoR = item[4].ToString();               
                dd.Param_ID = int.Parse(item[2].ToString());
                dd.StatuS = item[5].ToString();  
                dd.TipoDato = item[7].ToString();
                dd.Limite = item[6].ToString();  
                tblensdetalle.Add(dd);         
            }
            this.gridControl1.DataSource = tblensdetalle;
            this.cbxTipoEnsayo.Enabled = true;            
            this.gridView1.Columns["Ensayo_ID"].Visible = false;
            this.gridView1.Columns["Param_ID"].Visible = false;
            this.gridView1.Columns["ID_ensayo"].Visible = false;
            this.gridView1.Columns["TipoDato"].Width = 15;
            this.gridView1.Columns["StatuS"].Width = 45;

            this.gridView1.Columns["Descripcion"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["StatuS"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["TipoDato"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["Limite"].OptionsColumn.AllowEdit = false;   

            this.gridView1.Columns["TipoDato"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["StatuS"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["Descripcion"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["ValoR"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["Limite"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;         
        }
        private void dataGridViewX1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {           
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.Column.FieldName == "StatuS") 
            {
                if (e.CellValue.ToString() == "ok")
                {                   
                    // e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.Green;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;                    
                }
                else if (e.CellValue.ToString() == "wait")
                {
                    //e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.Orange;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
                else {
                  //  e.Appearance.BackColor = Color.DarkRed;
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }                           
            }       
        }
        public void cargardetalle1(string pid) 
        {
            this.gridControl1.DataSource = null;
            this.gridView1.Columns.Clear();   
            tblensdetalle = new List<TblEnsayoDetalle>();
            DataSet variable = ensayos.retornarDetallesParaFiltrar(pid);
            string paralimites = String.Empty;


            foreach (DataRow item in variable.Tables[0].Rows)
            {
                TblEnsayoDetalle dd = new TblEnsayoDetalle();
                // ESTE ENSAYOID  HAY QUE VER DE DONDE SE SACA
                 dd.Ensayo_ID= int.Parse(this.textBoxX1.Text);
                 dd.ID_ensayo = int.Parse(this.textBoxX1.Text);
                 dd.Descripcion = item[1].ToString();                
                 //primero vemos si es true el valor minimo, sino luego valor maximo, sino es ninguno , entonces comprobamos si es minymax  true, si es asi 
                 //entonces tendremos dos limites que comprobar
                 dd.ValoR = ((bool)item[4] ? item[5].ToString() : ((bool)item[6] ? item[7].ToString() : ((bool)item[8] ? ObtenerValorSegunLimites(item[9].ToString(), 3, item[12].ToString(), ref paralimites, "0") + "" : "0")));
                 if ((bool)item[8])
                 {
                     //limites de la tabla
                     ObtenerValorSegunLimites(item[9].ToString(), 4, "", ref paralimites, dd.ValoR);
                     dd.Limite = paralimites == ""?"Valor "+dd.ValoR+" no se encuentra":paralimites ;                     
                 }
                 else if((bool)item[4] && (bool)item[6])
                 {
                     dd.Limite = "" + item[5].ToString() + " ~ " + item[7].ToString();
                 }
                 else //limites de min o max  o vacio
                     dd.Limite = ((bool)item[4] ? ">=" + item[5].ToString() : ((bool)item[6] ? "<=" + item[7].ToString() : " "));
                //Por si no se encuentra aun limite llenoo                   
               
                dd.Param_ID= int.Parse(item[0].ToString());
                dd.TipoDato = item[13].ToString();  
                dd.ValoR = dd.TipoDato=="1"? " ":"0";
                dd.StatuS="wait";
                paralimites = "";
                tblensdetalle.Add(dd);              
            }
            this.gridControl1.DataSource = tblensdetalle;         
            this.gridView1.Columns["Ensayo_ID"].Visible = false;
            this.gridView1.Columns["Param_ID"].Visible = false;
            this.gridView1.Columns["ID_ensayo"].Visible = false;    
            this.gridView1.Columns["TipoDato"].Width=15;
            this.gridView1.Columns["StatuS"].Width=45;
            this.gridView1.Columns["Descripcion"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["StatuS"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["TipoDato"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["Limite"].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns["TipoDato"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["StatuS"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["Descripcion"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["ValoR"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["Limite"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
        public string ObtenerValorSegunLimites(string valor1,int opcion,string campotabla,ref string limitesParaTabla, string val) 
        {
            string item = this.textBoxX4.Text;
            string retorno = string.Empty;
            string retornovalor = String.Empty;
            switch (opcion)
            {
                case 1:
                    //caso para limite min                    
                    break;
                case 2:
                    // caso para limite max                    
                    break;
                case 3:
                    //caso para valortabla
                    retornovalor = String.Format("SELECT [LPF_VALUE] AS VALOR from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_PRODUCT_CODE ='{0}' and LPF_FEATURE ='{1}'", item, campotabla);
                    DataSet variable = ensayos.retornarEnsayo(retornovalor);
                    string valor = "0";
                    foreach (DataRow da in variable.Tables[0].Rows)
                    {
                        valor = (da[0].ToString());//double.Parse
                    }
                    return valor;
                case 4:
                    ///limite tabla
                    retornovalor = String.Format("select Minimo,Maximo from tblCatTablaDetalle where tablaid = {0} and valor='{1}'", valor1, val);
                    DataSet variable1 = ensayos.retornarEnsayo(retornovalor);
                    foreach (DataRow da2 in variable1.Tables[0].Rows)
                    {
                        string d = da2[0].ToString();
                        string d2 = da2[1].ToString();
                        //limitesParaTabla = d.Substring(0,d.Length-2) + " ~ " + da2[1].ToString());
                        limitesParaTabla = (d.Length > 5 ? d.Substring(0, d.Length - 2) : d) + " ~ " + (d2.Length > 5 ? d2.Substring(0, d2.Length - 2) : d2);
                    }
                    break;
                default:
                    break;
            }
            return "0";    
        }
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {      
        }           
        private void comboBoxEx1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //seleccion combobox
            string id = this.cbxTipoEnsayo.SelectedValue.ToString();
            cargardetalle1(id);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //DETECTAMOS CUANDO SE EDITA UNA CELDA            
            if(e.Column.FieldName=="StatuS")
            {                
            }            
            if (e.Column.FieldName == "ValoR") 
            {      
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();                     
                string valor =(view.GetRowCellDisplayText(e.RowHandle, view.Columns[4])).ToString();
                string limite = (view.GetRowCellDisplayText(e.RowHandle, view.Columns[6])).ToString();
                int valDato = int.Parse((view.GetRowCellDisplayText(e.RowHandle, view.Columns[7])).ToString());
                if(limite==" " || valDato==1)
                {
                    if (e.Value.ToString() == "BUENO")
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns[5], "ok");
                    }
                    else if (e.Value.ToString() == "MALO")
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");
                    }
                    else 
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns[4], "MALO");                                      
                    }
                }
                else if( limite.Contains("~")|| limite.Contains("-") )
                {
                    //tiene ambos limites
                    string[] lim = limite.Split('~');
                    double val = 0;
                    if (Double.TryParse(valor, out val))
                    {                       
                        if (val >= Double.Parse(lim[0].Trim().Substring(0, lim[0].TrimEnd().Length - 1)) &&
                            val <= Double.Parse(lim[1].Trim().Substring(0, lim[1].TrimEnd().Length - 1)))
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns[5], "ok");
                        }
                        else 
                        { 
                           view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");
                        }                        
                    }
                    else 
                    {
                        MessageBox.Show("Cuando existen limite,  \n los valores tienen que ser numericos.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        view.SetRowCellValue(e.RowHandle, view.Columns[4], "0"); 
                        view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");
                    }                
                }
                else if (limite.Contains(">=") || limite.Contains("<="))
                {
                    string[] param = limite.Split('=');
                     double val = 0;
                     if (Double.TryParse(valor, out val))
                     {
                         if (param[0].Contains("<"))
                         {
                             if (val <= double.Parse(param[1]))
                             {
                                 view.SetRowCellValue(e.RowHandle, view.Columns[5], "ok");
                             }
                             else
                                 view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");
                         }
                         else
                         {
                             if (val >= double.Parse(param[1]))
                             {
                                 view.SetRowCellValue(e.RowHandle, view.Columns[5], "ok");
                             }
                             else
                                 view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");
                         }
                     }
                     else 
                     {
                         MessageBox.Show("Cuando existen limite,  \n los valores tienen que ser numericos. ","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                         view.SetRowCellValue(e.RowHandle, view.Columns[4], "0");
                         view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");                     
                     }            
                }
                else if(valDato==0 && ( limite.Equals("")||limite.Equals("  ") ) )
                {
                    double val = 0;
                    if (Double.TryParse(valor, out val)) 
                    {                        
                    }else
                        view.SetRowCellValue(e.RowHandle, view.Columns[4], ""+val);
                    
                    view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");                   
                }
                else if(Regex.IsMatch(valor, @"^[a-zA-Z]+$"))
                {
                    view.SetRowCellValue(e.RowHandle, view.Columns[4], "0");
                    view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");      
                }
                else 
                {
                    //0.0
                   // view.SetRowCellValue(e.RowHandle, view.Columns[4], "0");
                    view.SetRowCellValue(e.RowHandle, view.Columns[5], "adv");                    
               }                
            }
        }
        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            //cargando datasourc
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int row = view.RowCount;
            int col=view.Columns.Count;          
            RepositoryItemTextEdit _text = new RepositoryItemTextEdit();
            RepositoryItemComboBox _riEditor = new RepositoryItemComboBox();            
            _riEditor.Items.AddRange(new string[] { "BUENO", "MALO" });                       
            gridView1.CustomRowCellEdit += (senda, ee) =>
            {
                GridView view1 = senda as GridView;
                if (ee.Column.FieldName == "ValoR")
                {
                    int boolVal = int.Parse(view1.GetRowCellValue(ee.RowHandle, "TipoDato").ToString());
                    if (boolVal == 1)
                        ee.RepositoryItem = _riEditor;
                }
            };
        }
        private void labelX2_Click(object sender, EventArgs e)
        {

        }
    }
}
