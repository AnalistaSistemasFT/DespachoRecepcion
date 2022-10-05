using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraRichEdit.Layout;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo
{
    public partial class frmConformidad : Form
    {
        List<TAccion> taccionlis;
        NoConformidad objconf;
        CConforme objintermediario;
        DataSet datosemple;
        private int sucursallocal;
        public frmConformidad(int sucursal)
        {
             InitializeComponent();
             sucursallocal = sucursal;
             datosemple = new DataSet();
             objintermediario = new CConforme();            
             objconf = new NoConformidad();
             taccionlis = new List<TAccion>();
             recargarempleados();
             cargarchecklistycombos();
             llenargriddatos(" ");
             this.xtraTabPage1.PageEnabled = false;
             this.xtraTabPage2.PageEnabled = false;
             this.xtraTabPage3.PageEnabled = false;
             this.textBoxX5.Enabled = false;
 
             
            // gridView1.Optionscol
        }
        public void cargarchecklistycombos() 
        {
            string consulta = "select * from tbltiporesultado";
            DataSet far = objintermediario.Ejecutarsentencias(consulta);
            this.checkedListBoxControl1.DataSource = far.Tables[0];
            this.checkedListBoxControl1.ValueMember = "itiporesultado_id";
            this.checkedListBoxControl1.DisplayMember = "sdescripcion";
            consulta = "select * from tblareaproceso";
            far = objintermediario.Ejecutarsentencias(consulta);
            this.comboBoxEx1.DataSource = far.Tables[0];
            this.comboBoxEx1.DisplayMember = "sdescripcion";
            this.comboBoxEx1.ValueMember = "iareaproceso_id";
            DataGridViewComboBoxColumn comboboxColumn = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            far = objintermediario.Ejecutarsentencias("select EmpleadoId, Nombre +' '+Apellido as Nombres from empleados.dbo.tblempleados");            
            comboboxColumn.DataSource = far.Tables[0];
            comboboxColumn.DisplayMember = "Nombres";
            comboboxColumn.ValueMember = "EmpleadoId";
            //consulta = "select * from tblaccion ";
            //far = objintermediario.Ejecutarsentencias(consulta);
            //this.gridControl2.DataSource = far.Tables[0];
            consulta = "select * from tblestado";
            far = objintermediario.Ejecutarsentencias(consulta);
            this.comboestado.DataSource = far.Tables[0];
            this.comboestado.DisplayMember = "sdescricpion";
            this.comboestado.ValueMember = "iestado_id";
        }
        public void llenargriddatos(string condicion) 
        {
            //string consulta1 = String.Format("select tl.iaccion_id,tl.saccion_desc as Descripcion,tl.dtfecha_plazo as fecha_Plazo,tl.dtfecha_cierre as fecha_Cierre,e.sdescricpion as Estado, emp.Nombre +' '+emp.Apellido as Responsables  from tblaccion as tl inner join tblestado as e on tl.sestado=e.iestado_id inner join  empleados.dbo.tblempleados as emp on tl.iresponsable_id=emp.EmpleadoId where tl.inoconformidad_id={0}", idconforme);
            //tblnoconformidad.itipoincidente_id, tblnoconformidad.itipo_id,
            string consulta = " SELECT tblnoconformidad.inoconformidad_id as ID, tblnoconformidad.dtfecha_ide as Fecha_Identificacion, tblnoconformidad.dtfecha_cierre as Fecha_Cierre, "+
              " tblnoconformidad.sdescripcion as Descripcion, tblnoconformidad.sconsecuencias as Consecuencias,tblnoconformidad.sdoc_relacionado,  " +
             " tblnoconformidad.ssolicion_inmediata as Solucion_Inmediata,tblnoconformidad.sanalisis_causaraiz as Analisis_CausaRaiz, tblnoconformidad.sresultado as Resultado, " +
             "  tblnoconformidad.sverificacion_eficacia as Verificacion_Eficacia, emp1.Nombre +' '+emp1.Apellido as Emitido_Por, emp2.Nombre +' '+emp2.Apellido as Recibido_Por,tbltip.sdescripcion as Tipo_NoConformidad,area.sdescripcion as AreaProceso  from tblnoconformidad left join " +
             " empleados.dbo.tblempleados as emp1 on tblnoconformidad.iemitido_por=emp1.EmpleadoId left join  empleados.dbo.tblempleados as emp2 on tblnoconformidad.irecibido_por=emp2.EmpleadoId "+
            " left join tbltiponoconformidad as tbltip on tblnoconformidad.itipo_id=tbltip.itipo_id left join tblareaproceso as area on  tblnoconformidad.iareaproceso=area.iareaproceso_id where isucursal_id="+sucursallocal+" "+ condicion;
  
            DataSet far = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl1.DataSource = far.Tables[0];        
            this.gridView1.Columns["ID"].Width=5;
        }
        public void recargarempleados() 
        {
            string sentencia = "select  EmpleadoId, Nombre +' '+Apellido as Nombres,CodFerro  from empleados.dbo.tblempleados";
            datosemple= objintermediario.Ejecutarsentencias(sentencia);               
        }
        private void labelX2_Click(object sender, EventArgs e)
        {
        }
        public void eliminarfilasvaciasdtgv() 
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null && dataGridView1.Rows[i].Cells[1].Value == null && dataGridView1.Rows[i].Cells[2].Value == null && dataGridView1.Rows[i].Cells[7].Value == null)
                {
                    this.dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    i--;
                }
            }        
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            // this.textBoxX7.Text.ToString().Length > 0
            try
            {
                eliminarfilasvaciasdtgv();
                if (this.dataGridView1.Rows.Count > 0 && this.txt41.Text.ToString().Length > 0)
                {
                    objconf.DtFecha_reg = DateTime.Now;
                    objconf.Dtfecha_ide = this.dateidentificacion.Value.ToShortDateString();
                    objconf.Dtfecha_cierre = this.dateplazocierre.Value.ToShortDateString();
                    objconf.IAreaProceso = int.Parse(this.comboBoxEx1.SelectedValue.ToString());
                    objconf.Itipo_Id = retornartipo();
                    objconf.Descripcion = this.txt1.Text.ToString();
                    objconf.ITipoIncidente_id = retornoartipoincidente();
                    objconf.PsConsecuencias = this.txt2.Text.ToString();
                    objconf.SDoc_relacionado = this.txt3.Text.ToString();
                    objconf.SSolucion_Inmediata = this.txt4.Text.ToString();
                    objconf.IEmitido_por = int.Parse(this.txt41.Text.ToString().Length > 0 ? txt41.Text.ToString() : "0");
                    objconf.IRecibido_por = int.Parse(this.txt42.Text.ToString().Length > 0 ? txt42.Text.ToString() : "0");
                    objconf.SAnalisis_Causaraiz = this.textBoxX5.Text.ToString();
                    objconf.IEncargado_seg = int.Parse(this.textBoxX7.Text.ToString().Length > 0 ? textBoxX7.Text.ToString() : "0");
                    objconf.IEstado = int.Parse(this.comboestado.SelectedValue != null ? this.comboestado.SelectedValue.ToString() : "0");
                    objconf.ISucursal = sucursallocal;
                    //estado se llenara a partir de otra tabla que es tblaccion 
                    foreach (DataGridViewRow item in this.dataGridView1.Rows)
                    {
                        //
                        TAccion taccion = new TAccion();
                        if (item.Cells[0].Value != null && item.Cells[1].Value != null && item.Cells[2].Value != null && item.Cells[7] != null)
                        {
                            taccion.SAccion_Desc = item.Cells[0].Value.ToString();
                            taccion.IResponsable_ID = int.Parse(item.Cells[1].Value.ToString());
                            taccion.DTfecha_plazo = item.Cells[2].Value == null ? null : item.Cells[2].Value.ToString();
                            taccion.DTfecha_cierre = item.Cells[7].Value == null ? null : item.Cells[7].Value.ToString();
                            taccion.INoconformidad_Id = 0;
                            if (item.Cells[3].Value != null)
                            {
                                taccion.EstadoId = 1;
                            }
                            else if (item.Cells[4].Value != null)
                            {
                                taccion.EstadoId = 2;
                            }
                            else if (item.Cells[5].Value != null)
                            {
                                taccion.EstadoId = 3;
                            }
                            else if (item.Cells[6].Value != null)
                            {
                                taccion.EstadoId = 4;
                            }
                            taccionlis.Add(taccion);
                        }
                    }
                    objconf.IResultado_id = 0;
                    objconf.SResultado = this.textBoxX3.Text.ToString();
                    objconf.SVerificacion_eficacia = this.textBoxX1.Text.ToString();
                    objconf.IEncargado_cierre = int.Parse(textBoxX6.Text.ToString().Length > 0 ? textBoxX6.Text.ToString() : "0");
                    //de la tabla resultados obtener lo guardaremos al momento que se guarde la tabla noconformidad
                    List<int> resultadoObtenido = new List<int>();
                    foreach (object item in checkedListBoxControl1.CheckedItems)
                    {
                        DataRowView row = item as DataRowView;
                        resultadoObtenido.Add(int.Parse(row.Row[0].ToString()));
                    }
                    if (labelX26.Text.Length > 0)
                    {
                        //editar   
                        int id = int.Parse(this.labelX26.Text.ToString());
                        if (objintermediario.EditarInfo(taccionlis, objconf, resultadoObtenido, id))
                        {
                            MessageBox.Show("LA TAREA SE GUARDO CORRECTAMENTE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.xtraTabPage4.Show();
                        }                           
                        else
                            MessageBox.Show("OCURRIO UN ERROR AL GUARDAR LA TAREA, \n Asegurese de llenar todos los campos", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //guardar
                        //enviamos toda la informacion en una para procesarla dentro de una transaccion
                        if (objintermediario.GuardarInformacion(taccionlis, objconf, resultadoObtenido))
                        {
                            MessageBox.Show("LA TAREA SE GUARDO CORRECTAMENTE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.xtraTabPage4.Show();
                        }                            
                        else
                            MessageBox.Show("OCURRIO UN ERROR AL GUARDAR LA TAREA, \n Asegurese de llenar todos los campos", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    MessageBox.Show("Asegurese de tener minimo una accion llenada los responsables del seguimiento del informe como Encargados de seguimiento,y los emisores correspondientes.","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                taccionlis.Clear();
                llenargriddatos(" ");
            }
            catch (Exception E)
            {
                MessageBox.Show("Ocurrio un problema al procesar la informacion, \n posiblemente le falto llenar unos campos necesarios"+E.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        public int retornoartipoincidente() 
        {
            return this.i1.Checked ? 1 : (this.i2.Checked ? 2 : (this.i3.Checked ? 3 : 4));
        }
        public int retornartipo()
        {
            return this.radioButton3.Checked ? 1 : (this.radioButton4.Checked ? 2 : 6);        
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {            
            this.dataGridView1.Rows.Add(1);           
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {                 
        }
        public string incidente() 
        {
            if (i1.Checked) 
            {
                return "Con Baja Medica";
            }
            else if (i2.Checked)
            {
                return "Sin Baja Medica";
            }
            else if (i3.Checked)
            {
                return "Ambiental";
            }
            else 
            {
                return "Con Daños Materiales";            
            }        
        }
        private void rsi_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void txt42_TextChanged(object sender, EventArgs e)
        {
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            //emitido
            string cod = this.txt41.Text.ToString();
            if(cod.Length>0)
                busquedadedatos(cod);           
        }                
        public void busquedadedatos(string cod) 
        {
            foreach (DataRow item in datosemple.Tables[0].Rows)
            {
                if (int.Parse(item[0].ToString()) == int.Parse(cod)) 
                {
                    this.txt41.Text = item[0].ToString();
                    this.labelX18.Text = item[1].ToString();
                }                
            }      
        }
        public void busquedadedatos1(string cod)
        {
            foreach (DataRow item in datosemple.Tables[0].Rows)
            {
                if (int.Parse(item[0].ToString()) == int.Parse(cod))
                {
                    this.txt42.Text = item[0].ToString();
                    this.labelX19.Text = item[1].ToString();
                }
            }
        }
        public void busquedadedatos11(string cod,int seccion)
        {
            foreach (DataRow item in datosemple.Tables[0].Rows)
            {
                if (int.Parse(item[0].ToString()) == int.Parse(cod))
                {
                    if (seccion == 3) 
                    {
                        this.textBoxX7.Text = item[0].ToString();
                        this.labelX23.Text = item[1].ToString();                    
                    }else if(seccion==4)
                    {
                        this.textBoxX6.Text = item[0].ToString();
                        this.labelX21.Text = item[1].ToString();                      
                    }                    
                }
            }
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            //recibido
            string cod1 = this.txt42.Text.ToString();
            if (cod1.Length > 0)
                busquedadedatos1(cod1);    
        }
        private void txt41_TextChanged(object sender, EventArgs e)
        {            
        }
        private void txt41_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else 
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }            
        }
        private void txt42_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado busc = new frmBuscarEmpleado();
            busc.ShowDialog();
            if(busc.nombre!=null)
            {
                this.txt41.Text = busc.codigo.ToString();
                this.labelX18.Text = busc.nombre.ToString();            
            }           
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado busc = new frmBuscarEmpleado();
            busc.ShowDialog();
            if (busc.nombre != null)
            {
                this.txt42.Text = busc.codigo.ToString();
                this.labelX19.Text = busc.nombre.ToString();               
            }            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==8)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value == null)
                {
                    OpenFileDialog archivo = new OpenFileDialog();
                    if (archivo.ShowDialog() == DialogResult.OK)
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = archivo.FileName;
                    }
                }
                else
                {
                    Process.Start(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString());
                }           
            }                 
        }
        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonX9_Click(object sender, EventArgs e)
        {
            //emitido
            string cod = this.textBoxX6.Text.ToString();
            if (cod.Length > 0)
                busquedadedatos11(cod,4);   
        }
        private void textBoxX6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }  
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado busc = new frmBuscarEmpleado();
            busc.ShowDialog();
            if (busc.nombre != null)
            {
                this.textBoxX6.Text = busc.codigo.ToString();
                this.labelX21.Text = busc.nombre.ToString();
            } 
        }
        private void buttonX10_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado busc = new frmBuscarEmpleado();
            busc.ShowDialog();
            if (busc.nombre != null)
            {
                this.textBoxX7.Text = busc.codigo.ToString();
                this.labelX23.Text = busc.nombre.ToString();
            } 
        }
        private void buttonX11_Click(object sender, EventArgs e)
        {
            string cod = this.textBoxX7.Text.ToString();
            if (cod.Length > 0)
                busquedadedatos11(cod,3); 
        }
        private void textBoxX7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }  
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
        public void llenarresultados_acciones(int idconforme) 
        {
            string consulta = String.Format("select tl.iaccion_id,tl.saccion_desc as Descripcion,tl.dtfecha_plazo as fecha_Plazo,tl.dtfecha_cierre as fecha_Cierre,e.sdescricpion as Estado, emp.Nombre +' '+emp.Apellido as Responsables  from tblaccion as tl inner join tblestado as e on tl.sestado=e.iestado_id inner join  empleados.dbo.tblempleados as emp on tl.iresponsable_id=emp.EmpleadoId where tl.inoconformidad_id={0}", idconforme);
            DataSet far = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl2.DataSource = far.Tables[0];

            consulta = String.Format("select tblr.iresultado_id,tblt.sdescripcion from tblResultado as tblr inner join tbltiporesultado  as tblt on tblr.itiporesultado_id=tblt.itiporesultado_id where tblr.inoconformidad_id={0}",idconforme);
            far = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl3.DataSource = far.Tables[0];        
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click fila
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            int codigo = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            llenarresultados_acciones(codigo);
        }
        private void buttonX12_Click(object sender, EventArgs e)
        {
            //filtros de fecha
            string fecha1 = this.dateTimePicker1.Value.ToShortDateString();
            string fecha2 = this.dateTimePicker2.Value.ToShortDateString();
            string sentencia = String.Format(" and dtfecha_ide between '{0}' and '{1}'",fecha1,fecha2);
            llenargriddatos(sentencia);          
        }
        private void buttonX13_Click(object sender, EventArgs e)
        {           
        }
        private void buttonX14_Click(object sender, EventArgs e)
        {
            //editar
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            int codigo = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            cargarchecklistycombos();
            llenarparaeditar(codigo);
            this.xtraTabPage1.PageEnabled = true;
            this.xtraTabPage2.PageEnabled = true;
            this.xtraTabPage3.PageEnabled = true;
            this.xtraTabPage1.Show();
            this.labelX26.Text =codigo.ToString();
            this.textBoxX5.Enabled = true;
        }
        public void llenarparaeditar(int id) 
        {
            string consulta = String.Format("select * from dbo.tblnoconformidad where inoconformidad_id={0}",id);
            DataSet d = objintermediario.Ejecutarsentencias(consulta);
            this.radioButton2.Checked = true;
            foreach (DataRow item in d.Tables[0].Rows)
            {
                this.dateidentificacion.Value= Convert.ToDateTime(item[2].ToString());
                this.dateplazocierre.Value = Convert.ToDateTime(item[3].ToString());
                this.comboBoxEx1.SelectedValue = int.Parse(item[4].ToString());               
                chekartipo(int.Parse(item[5].ToString()));
                this.txt1.Text = item[6].ToString();
                chekartipoincidente(int.Parse(item[7].ToString()));
                this.txt2.Text=item[8].ToString();
                this.txt3.Text = item[9].ToString();
                this.txt4.Text = item[10].ToString();
                txt41.Text = item[11].ToString();
                txt42.Text = item[12].ToString();
                this.textBoxX5.Text = item[13].ToString();
                this.textBoxX7.Text=item[14].ToString();
                //15estado
                this.comboestado.SelectedValue = int.Parse(item[15].ToString());
                //resultado id 16
                this.textBoxX3.Text=item[17].ToString();
                this.textBoxX1.Text = item[18].ToString();
                this.textBoxX6.Text=item[19].ToString();
            }
            consulta = String.Format("select itiporesultado_id from dbo.tblResultado where inoconformidad_id={0}",id);
            d=objintermediario.Ejecutarsentencias(consulta);
            foreach (DataRow item in d.Tables[0].Rows)
            {
                this.checkedListBoxControl1.SetItemChecked(int.Parse(item[0].ToString())-1, true);            
            }
            consulta = String.Format("select * from dbo.tblaccion where inoconformidad_id={0}",id);
            d = objintermediario.Ejecutarsentencias(consulta);            
            int fila = 0;
            this.dataGridView1.Rows.Clear();
            foreach (DataRow item in d.Tables[0].Rows)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[fila].Cells[0].Value = item[1].ToString();
                this.dataGridView1.Rows[fila].Cells[1].Value = int.Parse(item[2].ToString());
                this.dataGridView1.Rows[fila].Cells[2].Value = item[3].ToString();
                if(int.Parse(item[4].ToString())==1)
                    this.dataGridView1.Rows[fila].Cells[3].Value = true;
                else if(int.Parse(item[4].ToString())==2)
                    this.dataGridView1.Rows[fila].Cells[4].Value = true;
                else if(int.Parse(item[4].ToString())==3)
                    this.dataGridView1.Rows[fila].Cells[5].Value = true;
                else
                    this.dataGridView1.Rows[fila].Cells[6].Value = true;
                this.dataGridView1.Rows[fila].Cells[7].Value = item[5].ToString();
                fila++;
            }        
        }
        public void chekartipo(int id) 
        {
            if (id == 1)
                radioButton3.Checked = true;
            else if(id==2)
                radioButton4.Checked = true;
            else
                radioButton5.Checked = true;        
        }
        public void chekartipoincidente(int id) 
        {
            if (id == 1)
                i1.Checked = true;
            else if (id == 2)
                i2.Checked = true;
            else if (id == 3)
                i3.Checked = true;
            else
                i4.Checked = true;        
        }
        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void labelX27_Click(object sender, EventArgs e)
        {            
        }
        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            try
            {
                int con = this.dataGridView1.CurrentRow.Index;
                this.dataGridView1.Rows.RemoveAt(con);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Seleccione una fila para proceder la eliminacion","--",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }           
        }
        private void buttonX13_Click_1(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                int codigo = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                //rredirigiendo a reporteprincipal
                ReporteNoConforme rpt = new ReporteNoConforme();
                rpt.redirigirRemoto(codigo);
                rpt.ShowDialog();
            }
            catch (Exception w)
            {
                MessageBox.Show("Posiblemente no selecciono una fila de la tabl principal \n Intentelo nuevamente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonX15_Click(object sender, EventArgs e)
        {
            this.txt1.Text = "";
            this.txt2.Text = "";
            this.txt3.Text = "";
            this.txt4.Text = "";
            this.txt41.Text = "";
            this.txt42.Text="";
            this.textBoxX5.Text = "";
            this.textBoxX7.Text = "";
            this.textBoxX3.Text = "";
            this.textBoxX1.Text = "";
            this.textBoxX6.Text = "";
            this.labelX21.Text = "";
            this.labelX23.Text = "";
            this.labelX18.Text = "";
            this.labelX19.Text = "";
            this.dataGridView1.Rows.Clear();
            this.xtraTabPage1.PageEnabled = true;
            this.xtraTabPage2.PageEnabled = true;
            this.xtraTabPage3.PageEnabled = true;
            this.xtraTabPage1.Show();
            this.labelX26.Text = "";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxX5.Text = "";
            this.textBoxX5.Enabled = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxX5.Text = "";
            this.textBoxX5.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker2.MinDate = this.dateTimePicker1.Value;
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dateidentificacion_ValueChanged(object sender, EventArgs e)
        {
            this.dateplazocierre.MinDate = this.dateidentificacion.Value;
        }

        private void xtraTabControl1_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {           
            if (e.PageIndex == 0)
            {
                this.xtraTabPage1.PageEnabled = false;
                this.xtraTabPage2.PageEnabled = false;
                this.xtraTabPage3.PageEnabled = false;
            }
            else 
            {            

            }
        }

        private void labelX22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}
