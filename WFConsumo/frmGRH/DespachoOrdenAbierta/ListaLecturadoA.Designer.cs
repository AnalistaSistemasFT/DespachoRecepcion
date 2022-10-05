namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    partial class ListaLecturadoA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtNroOrden = new DevExpress.XtraEditors.TextEdit();
            this.btnBusqPaquete = new DevExpress.XtraEditors.SimpleButton();
            this.btnBusquedaMan = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmpezarLect = new DevExpress.XtraEditors.SimpleButton();
            this.txtEtiqueta = new DevExpress.XtraEditors.TextEdit();
            this.txtFecha = new DevExpress.XtraEditors.TextEdit();
            this.checkPallet = new DevExpress.XtraEditors.CheckEdit();
            this.labelDespacho = new DevExpress.XtraEditors.LabelControl();
            this.txtDespacho = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Retiro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEtiqueta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPallet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtNroOrden);
            this.panelControl1.Controls.Add(this.btnBusqPaquete);
            this.panelControl1.Controls.Add(this.btnBusquedaMan);
            this.panelControl1.Controls.Add(this.btnEmpezarLect);
            this.panelControl1.Controls.Add(this.txtEtiqueta);
            this.panelControl1.Controls.Add(this.txtFecha);
            this.panelControl1.Controls.Add(this.checkPallet);
            this.panelControl1.Controls.Add(this.labelDespacho);
            this.panelControl1.Controls.Add(this.txtDespacho);
            this.panelControl1.Location = new System.Drawing.Point(13, 66);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(687, 147);
            this.panelControl1.TabIndex = 0;
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.Location = new System.Drawing.Point(505, 102);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNroOrden.Properties.Mask.PlaceHolder = '1';
            this.txtNroOrden.Size = new System.Drawing.Size(166, 20);
            this.txtNroOrden.TabIndex = 11;
            // 
            // btnBusqPaquete
            // 
            this.btnBusqPaquete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBusqPaquete.Location = new System.Drawing.Point(505, 64);
            this.btnBusqPaquete.Name = "btnBusqPaquete";
            this.btnBusqPaquete.Size = new System.Drawing.Size(166, 31);
            this.btnBusqPaquete.TabIndex = 10;
            this.btnBusqPaquete.Text = "Busqueda por numero de orden";
            this.btnBusqPaquete.Click += new System.EventHandler(this.btnBusqPaquete_Click);
            // 
            // btnBusquedaMan
            // 
            this.btnBusquedaMan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBusquedaMan.Location = new System.Drawing.Point(265, 64);
            this.btnBusquedaMan.Name = "btnBusquedaMan";
            this.btnBusquedaMan.Size = new System.Drawing.Size(140, 31);
            this.btnBusquedaMan.TabIndex = 9;
            this.btnBusquedaMan.Text = "Busqueda manual";
            this.btnBusquedaMan.Click += new System.EventHandler(this.btnBusquedaMan_Click);
            // 
            // btnEmpezarLect
            // 
            this.btnEmpezarLect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnEmpezarLect.Location = new System.Drawing.Point(15, 64);
            this.btnEmpezarLect.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.btnEmpezarLect.Name = "btnEmpezarLect";
            this.btnEmpezarLect.Size = new System.Drawing.Size(156, 31);
            this.btnEmpezarLect.TabIndex = 8;
            this.btnEmpezarLect.Text = "Empezar lecturacion";
            this.btnEmpezarLect.Click += new System.EventHandler(this.btnEmpezarLect_Click);
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Location = new System.Drawing.Point(15, 101);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEtiqueta.Properties.Appearance.Options.UseBorderColor = true;
            this.txtEtiqueta.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Black;
            this.txtEtiqueta.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtEtiqueta.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtEtiqueta.Size = new System.Drawing.Size(156, 20);
            this.txtEtiqueta.TabIndex = 7;
            this.txtEtiqueta.TextChanged += new System.EventHandler(this.txtEtiqueta_TextChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(571, 11);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 6;
            // 
            // checkPallet
            // 
            this.checkPallet.Enabled = false;
            this.checkPallet.Location = new System.Drawing.Point(210, 11);
            this.checkPallet.Name = "checkPallet";
            this.checkPallet.Properties.Caption = "Palet";
            this.checkPallet.Size = new System.Drawing.Size(75, 19);
            this.checkPallet.TabIndex = 5;
            // 
            // labelDespacho
            // 
            this.labelDespacho.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelDespacho.Appearance.Options.UseFont = true;
            this.labelDespacho.Location = new System.Drawing.Point(15, 14);
            this.labelDespacho.Name = "labelDespacho";
            this.labelDespacho.Size = new System.Drawing.Size(61, 13);
            this.labelDespacho.TabIndex = 4;
            this.labelDespacho.Text = "Despacho: ";
            // 
            // txtDespacho
            // 
            this.txtDespacho.Location = new System.Drawing.Point(82, 14);
            this.txtDespacho.Name = "txtDespacho";
            this.txtDespacho.Size = new System.Drawing.Size(4, 13);
            this.txtDespacho.TabIndex = 3;
            this.txtDespacho.Text = "-";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(13, 219);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(687, 369);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.CodigoFerro,
            this.Descripcion,
            this.Paquete,
            this.Piezas,
            this.Peso,
            this.Retiro});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "p_ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.ReadOnly = true;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 105;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "CodigoFerro";
            this.CodigoFerro.FieldName = "p_ItemFerro";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 0;
            this.CodigoFerro.Width = 113;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "p_Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.AllowEdit = false;
            this.Descripcion.OptionsColumn.ReadOnly = true;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 334;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_PaqueteId";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 3;
            this.Paquete.Width = 129;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "p_Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.OptionsColumn.AllowEdit = false;
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 4;
            this.Piezas.Width = 88;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "p_Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.AllowEdit = false;
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 5;
            this.Peso.Width = 107;
            // 
            // Retiro
            // 
            this.Retiro.Caption = "Cantidad";
            this.Retiro.FieldName = "p_Retirar";
            this.Retiro.Name = "Retiro";
            this.Retiro.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.True;
            this.Retiro.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.True;
            this.Retiro.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.Retiro.Visible = true;
            this.Retiro.VisibleIndex = 6;
            this.Retiro.Width = 101;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(600, 626);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(100, 29);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Cancelar";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(494, 626);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 29);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnQuitar.Location = new System.Drawing.Point(12, 594);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(76, 31);
            this.btnQuitar.TabIndex = 10;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 50);
            this.panel1.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "LECTURAR";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(900, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(271, 26);
            this.lbTitle.TabIndex = 79;
            this.lbTitle.Text = "ORDENES DE ENTREGA";
            // 
            // ListaLecturado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaLecturado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Lecturado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaLecturado_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEtiqueta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPallet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelDespacho;
        private DevExpress.XtraEditors.LabelControl txtDespacho;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtEtiqueta;
        private DevExpress.XtraEditors.TextEdit txtFecha;
        private DevExpress.XtraEditors.CheckEdit checkPallet;
        private DevExpress.XtraEditors.SimpleButton btnEmpezarLect;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraEditors.SimpleButton btnBusquedaMan;
        private DevExpress.XtraEditors.TextEdit txtNroOrden;
        private DevExpress.XtraEditors.SimpleButton btnBusqPaquete;
        private DevExpress.XtraGrid.Columns.GridColumn Retiro;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
    }
}