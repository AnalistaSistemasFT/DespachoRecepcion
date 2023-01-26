namespace WFConsumo.Recepcion
{
    partial class CrearPalet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnBusquedaMan = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmpezarLect = new DevExpress.XtraEditors.SimpleButton();
            this.txtEtiqueta = new DevExpress.XtraEditors.TextEdit();
            this.labelDespacho = new DevExpress.XtraEditors.LabelControl();
            this.txtCorrelativo = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.comBoxItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEtiqueta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(701, 50);
            this.panel1.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "CREAR PALET";
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.comBoxItem);
            this.panelControl1.Controls.Add(this.labelDespacho);
            this.panelControl1.Controls.Add(this.txtCorrelativo);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 50);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(701, 162);
            this.panelControl1.TabIndex = 83;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnImprimir.Appearance.Options.UseBorderColor = true;
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnImprimir.Location = new System.Drawing.Point(523, 41);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(140, 31);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir etiqueta";
            this.btnImprimir.ToolTip = "Impirmir etiqueta para el palet";
            // 
            // btnBusquedaMan
            // 
            this.btnBusquedaMan.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnBusquedaMan.Appearance.Options.UseBorderColor = true;
            this.btnBusquedaMan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBusquedaMan.Location = new System.Drawing.Point(268, 41);
            this.btnBusquedaMan.Name = "btnBusquedaMan";
            this.btnBusquedaMan.Size = new System.Drawing.Size(140, 31);
            this.btnBusquedaMan.TabIndex = 9;
            this.btnBusquedaMan.Text = "Busqueda manual";
            this.btnBusquedaMan.Click += new System.EventHandler(this.btnBusquedaMan_Click);
            // 
            // btnEmpezarLect
            // 
            this.btnEmpezarLect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnEmpezarLect.Location = new System.Drawing.Point(12, 27);
            this.btnEmpezarLect.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.btnEmpezarLect.Name = "btnEmpezarLect";
            this.btnEmpezarLect.Size = new System.Drawing.Size(156, 31);
            this.btnEmpezarLect.TabIndex = 8;
            this.btnEmpezarLect.Text = "Empezar lecturacion";
            this.btnEmpezarLect.Click += new System.EventHandler(this.btnEmpezarLect_Click);
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.Enabled = false;
            this.txtEtiqueta.Location = new System.Drawing.Point(12, 64);
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEtiqueta.Properties.Appearance.Options.UseBorderColor = true;
            this.txtEtiqueta.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Black;
            this.txtEtiqueta.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtEtiqueta.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtEtiqueta.Size = new System.Drawing.Size(156, 20);
            this.txtEtiqueta.TabIndex = 7;
            this.txtEtiqueta.EditValueChanged += new System.EventHandler(this.txtEtiqueta_EditValueChanged);
            // 
            // labelDespacho
            // 
            this.labelDespacho.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDespacho.Appearance.Options.UseFont = true;
            this.labelDespacho.Location = new System.Drawing.Point(15, 14);
            this.labelDespacho.Name = "labelDespacho";
            this.labelDespacho.Size = new System.Drawing.Size(51, 20);
            this.labelDespacho.TabIndex = 4;
            this.labelDespacho.Text = "Palet: ";
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrelativo.Appearance.Options.UseFont = true;
            this.txtCorrelativo.Location = new System.Drawing.Point(72, 14);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(7, 20);
            this.txtCorrelativo.TabIndex = 3;
            this.txtCorrelativo.Text = "-";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl1.Location = new System.Drawing.Point(0, 212);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(701, 301);
            this.gridControl1.TabIndex = 84;
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
            this.Peso});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.CodigoFerro.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "p_ItemFerro", "Total: {0}")});
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
            // btnQuitar
            // 
            this.btnQuitar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnQuitar.Location = new System.Drawing.Point(12, 519);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(76, 31);
            this.btnQuitar.TabIndex = 87;
            this.btnQuitar.Text = "Quitar";
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Appearance.Options.UseBackColor = true;
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.Appearance.Options.UseForeColor = true;
            this.btnSalir.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnSalir.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.AppearanceHovered.Options.UseBackColor = true;
            this.btnSalir.AppearanceHovered.Options.UseForeColor = true;
            this.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSalir.Location = new System.Drawing.Point(589, 546);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 29);
            this.btnSalir.TabIndex = 86;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.Appearance.Options.UseForeColor = true;
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnAceptar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(483, 546);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 29);
            this.btnAceptar.TabIndex = 85;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comBoxItem
            // 
            this.comBoxItem.Location = new System.Drawing.Point(457, 10);
            this.comBoxItem.Name = "comBoxItem";
            this.comBoxItem.Properties.Appearance.BorderColor = System.Drawing.Color.DimGray;
            this.comBoxItem.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxItem.Properties.Appearance.Options.UseBorderColor = true;
            this.comBoxItem.Properties.Appearance.Options.UseFont = true;
            this.comBoxItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.comBoxItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxItem.Size = new System.Drawing.Size(169, 28);
            this.comBoxItem.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(385, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 20);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Codigo: ";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.btnImprimir);
            this.groupControl1.Controls.Add(this.btnEmpezarLect);
            this.groupControl1.Controls.Add(this.btnBusquedaMan);
            this.groupControl1.Controls.Add(this.txtEtiqueta);
            this.groupControl1.Location = new System.Drawing.Point(12, 55);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(677, 94);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "Acciones";
            // 
            // CrearPalet
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 587);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPalet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearPalet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEtiqueta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBusquedaMan;
        private DevExpress.XtraEditors.SimpleButton btnEmpezarLect;
        private DevExpress.XtraEditors.TextEdit txtEtiqueta;
        private DevExpress.XtraEditors.LabelControl labelDespacho;
        private DevExpress.XtraEditors.LabelControl txtCorrelativo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxItem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}