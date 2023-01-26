namespace WFConsumo.Recepcion
{
    partial class frmListaPalet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPalet));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCrearPalet = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditarPalet = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Palet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquetes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PesoPal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoDet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerroDet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasDet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Celda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnCrearPalet);
            this.panel1.Controls.Add(this.btnEditarPalet);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 50);
            this.panel1.TabIndex = 80;
            // 
            // btnCrearPalet
            // 
            this.btnCrearPalet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCrearPalet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearPalet.ImageOptions.Image")));
            this.btnCrearPalet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCrearPalet.Location = new System.Drawing.Point(12, 8);
            this.btnCrearPalet.Name = "btnCrearPalet";
            this.btnCrearPalet.Size = new System.Drawing.Size(35, 35);
            this.btnCrearPalet.TabIndex = 93;
            this.btnCrearPalet.ToolTip = "Crear nuevo palet";
            this.btnCrearPalet.Click += new System.EventHandler(this.btnCrearPalet_Click);
            // 
            // btnEditarPalet
            // 
            this.btnEditarPalet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnEditarPalet.Enabled = false;
            this.btnEditarPalet.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnEditarPalet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarPalet.ImageOptions.Image")));
            this.btnEditarPalet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEditarPalet.Location = new System.Drawing.Point(53, 8);
            this.btnEditarPalet.Name = "btnEditarPalet";
            this.btnEditarPalet.Size = new System.Drawing.Size(35, 35);
            this.btnEditarPalet.TabIndex = 92;
            this.btnEditarPalet.ToolTip = "Editar palet";
            this.btnEditarPalet.Click += new System.EventHandler(this.btnEditarPalet_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(815, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(62, 26);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Palet";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBuscar.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBuscar.AppearancePressed.Options.UseBackColor = true;
            this.btnBuscar.AppearancePressed.Options.UseForeColor = true;
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(135, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 69;
            this.btnBuscar.ToolTip = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnImprimir.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnImprimir.AppearancePressed.Options.UseBackColor = true;
            this.btnImprimir.AppearancePressed.Options.UseForeColor = true;
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImprimir.Location = new System.Drawing.Point(94, 8);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(35, 35);
            this.btnImprimir.TabIndex = 76;
            this.btnImprimir.ToolTip = "Imprimir etiqueta";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 476);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 84;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            toolTipTitleItem2.Text = "Nuevo";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.gridControl1.EmbeddedNavigator.SuperTip = superToolTip2;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1186, 259);
            this.gridControl1.TabIndex = 73;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Palet,
            this.Codigo,
            this.CodigoFerro,
            this.Paquetes,
            this.PesoPal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Introduzca el despacho a buscar...";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // Palet
            // 
            this.Palet.Caption = "Palet";
            this.Palet.FieldName = "PaletId";
            this.Palet.Name = "Palet";
            this.Palet.Visible = true;
            this.Palet.VisibleIndex = 0;
            this.Palet.Width = 204;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 206;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferro";
            this.CodigoFerro.FieldName = "ItemFId";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 2;
            this.CodigoFerro.Width = 206;
            // 
            // Paquetes
            // 
            this.Paquetes.Caption = "Paquetes";
            this.Paquetes.FieldName = "Cantidad_Paqs";
            this.Paquetes.Name = "Paquetes";
            this.Paquetes.Visible = true;
            this.Paquetes.VisibleIndex = 3;
            this.Paquetes.Width = 200;
            // 
            // PesoPal
            // 
            this.PesoPal.Caption = "Peso";
            this.PesoPal.FieldName = "Peso_Paqs";
            this.PesoPal.Name = "PesoPal";
            this.PesoPal.Visible = true;
            this.PesoPal.VisibleIndex = 4;
            this.PesoPal.Width = 244;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1186, 197);
            this.xtraTabControl1.TabIndex = 73;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1180, 169);
            this.xtraTabPage1.Text = "Detalle";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl2.Size = new System.Drawing.Size(1180, 169);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView2.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Paquete,
            this.CodigoDet,
            this.CodigoFerroDet,
            this.Descripcion,
            this.Peso,
            this.PiezasDet,
            this.Celda});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "PaqueteId";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 0;
            this.Paquete.Width = 102;
            // 
            // CodigoDet
            // 
            this.CodigoDet.Caption = "Codigo";
            this.CodigoDet.FieldName = "ItemId";
            this.CodigoDet.Name = "CodigoDet";
            this.CodigoDet.OptionsColumn.ReadOnly = true;
            this.CodigoDet.Visible = true;
            this.CodigoDet.VisibleIndex = 1;
            this.CodigoDet.Width = 98;
            // 
            // CodigoFerroDet
            // 
            this.CodigoFerroDet.Caption = "Codigo Ferro";
            this.CodigoFerroDet.FieldName = "ItemFId";
            this.CodigoFerroDet.Name = "CodigoFerroDet";
            this.CodigoFerroDet.OptionsColumn.ReadOnly = true;
            this.CodigoFerroDet.Visible = true;
            this.CodigoFerroDet.VisibleIndex = 2;
            this.CodigoFerroDet.Width = 117;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.ReadOnly = true;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 3;
            this.Descripcion.Width = 384;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.ReadOnly = true;
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 4;
            this.Peso.Width = 97;
            // 
            // PiezasDet
            // 
            this.PiezasDet.Caption = "Piezas";
            this.PiezasDet.FieldName = "Piezas";
            this.PiezasDet.Name = "PiezasDet";
            this.PiezasDet.OptionsColumn.ReadOnly = true;
            this.PiezasDet.Visible = true;
            this.PiezasDet.VisibleIndex = 5;
            this.PiezasDet.Width = 108;
            // 
            // Celda
            // 
            this.Celda.Caption = "Celda";
            this.Celda.FieldName = "CeldaId";
            this.Celda.Name = "Celda";
            this.Celda.Visible = true;
            this.Celda.VisibleIndex = 6;
            this.Celda.Width = 137;
            // 
            // repositoryItemButtonEdit1
            // 
            serializableAppearanceObject5.BackColor = System.Drawing.Color.DarkGreen;
            serializableAppearanceObject5.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject5.Options.UseForeColor = true;
            serializableAppearanceObject5.Options.UseTextOptions = true;
            serializableAppearanceObject5.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject5.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            serializableAppearanceObject6.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject6.Options.UseForeColor = true;
            serializableAppearanceObject7.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject7.Options.UseForeColor = true;
            serializableAppearanceObject8.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject8.Options.UseForeColor = true;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", 1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "Programar despacho", null, null)});
            this.repositoryItemButtonEdit1.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.repositoryItemButtonEdit1.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.ContextImageOptions.Image")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ReadOnly = true;
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemButtonEdit1.UseReadOnlyAppearance = false;
            // 
            // frmListaPalet
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 526);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmListaPalet";
            this.Text = "frmListaPalet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SimpleButton btnCrearPalet;
        private DevExpress.XtraEditors.SimpleButton btnEditarPalet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Palet;
        private DevExpress.XtraGrid.Columns.GridColumn Paquetes;
        private DevExpress.XtraGrid.Columns.GridColumn PesoPal;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoDet;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerroDet;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasDet;
        private DevExpress.XtraGrid.Columns.GridColumn Celda;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
    }
}