namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{
    partial class frmListaOrdenParcial
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
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PesoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pendiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NroOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Placa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Chofer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoDespacho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NroTraspaso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Usuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Destino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirLocaliza = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnImprimir.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon_print;
            this.btnImprimir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImprimir.Location = new System.Drawing.Point(95, 11);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(35, 35);
            this.btnImprimir.TabIndex = 71;
            this.btnImprimir.ToolTip = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnBuscar.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon_buscar;
            this.btnBuscar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(136, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 68;
            this.btnBuscar.ToolTip = "Buscar";
            // 
            // btnVer
            // 
            this.btnVer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnVer.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon_ver;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVer.Location = new System.Drawing.Point(54, 11);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(35, 35);
            this.btnVer.TabIndex = 67;
            this.btnVer.ToolTip = "Consultar";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 319);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 76;
            this.labelControl1.Text = "Nro. Orden:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Size = new System.Drawing.Size(1188, 328);
            this.xtraTabControl1.TabIndex = 75;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1182, 300);
            this.xtraTabPage1.Text = "Detalles de notas de entrega";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1182, 300);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo_,
            this.CodigoFerro,
            this.Descripcion,
            this.Paquete,
            this.UnidadMedida,
            this.Piezas,
            this.Peso,
            this.PesoTotal,
            this.Pendiente});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // Codigo_
            // 
            this.Codigo_.Caption = "Codigo";
            this.Codigo_.FieldName = "ItemId";
            this.Codigo_.Name = "Codigo_";
            this.Codigo_.Visible = true;
            this.Codigo_.VisibleIndex = 0;
            this.Codigo_.Width = 72;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferro";
            this.CodigoFerro.FieldName = "ItemFId";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 81;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 326;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "ProductoId";
            this.Paquete.Name = "Paquete";
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 3;
            this.Paquete.Width = 117;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.Caption = "Unidad de Medida";
            this.UnidadMedida.FieldName = "UnidadF";
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnidadF", "Totales")});
            this.UnidadMedida.Visible = true;
            this.UnidadMedida.VisibleIndex = 4;
            this.UnidadMedida.Width = 105;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Piezas.FieldName = "Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Piezas", "Piezas: {0:n0}")});
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 5;
            this.Piezas.Width = 95;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso (Kgs.)";
            this.Peso.FieldName = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Peso", "Peso:{0:n0} kgs."),
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 6;
            this.Peso.Width = 104;
            // 
            // PesoTotal
            // 
            this.PesoTotal.Caption = "PesoTotal (Kgs.)";
            this.PesoTotal.FieldName = "PesoTotal";
            this.PesoTotal.Name = "PesoTotal";
            this.PesoTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PesoTotal", "Peso total: {0:n0} kgs.")});
            this.PesoTotal.Visible = true;
            this.PesoTotal.VisibleIndex = 7;
            this.PesoTotal.Width = 145;
            // 
            // Pendiente
            // 
            this.Pendiente.Caption = "Pendiente";
            this.Pendiente.FieldName = "Pendiente";
            this.Pendiente.Name = "Pendiente";
            this.Pendiente.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pendiente", "Pendientes: {0:n0}")});
            this.Pendiente.Visible = true;
            this.Pendiente.VisibleIndex = 8;
            this.Pendiente.Width = 119;
            // 
            // gridControl3
            // 
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(400, 200);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl3;
            this.gridView1.Name = "gridView1";
            // 
            // gridView3
            // 
            this.gridView3.Name = "gridView3";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(80, 319);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(4, 13);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "-";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1188, 250);
            this.gridControl1.TabIndex = 74;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Fecha,
            this.NroOrden,
            this.Placa,
            this.Marca,
            this.Chofer,
            this.TipoDespacho,
            this.NroTraspaso,
            this.Estado,
            this.Usuario,
            this.Destino});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsBehavior.ReadOnly = true;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView4_RowClick);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 58;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 1;
            this.Fecha.Width = 82;
            // 
            // NroOrden
            // 
            this.NroOrden.Caption = "NroOrden";
            this.NroOrden.FieldName = "NroOrden";
            this.NroOrden.Name = "NroOrden";
            this.NroOrden.Visible = true;
            this.NroOrden.VisibleIndex = 2;
            this.NroOrden.Width = 82;
            // 
            // Placa
            // 
            this.Placa.Caption = "Placa";
            this.Placa.FieldName = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.Visible = true;
            this.Placa.VisibleIndex = 3;
            this.Placa.Width = 82;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 4;
            this.Marca.Width = 82;
            // 
            // Chofer
            // 
            this.Chofer.Caption = "Chofer";
            this.Chofer.FieldName = "Chofer";
            this.Chofer.Name = "Chofer";
            this.Chofer.Visible = true;
            this.Chofer.VisibleIndex = 5;
            this.Chofer.Width = 82;
            // 
            // TipoDespacho
            // 
            this.TipoDespacho.Caption = "TipoDespacho";
            this.TipoDespacho.FieldName = "TipoDespacho";
            this.TipoDespacho.Name = "TipoDespacho";
            this.TipoDespacho.Visible = true;
            this.TipoDespacho.VisibleIndex = 6;
            this.TipoDespacho.Width = 82;
            // 
            // NroTraspaso
            // 
            this.NroTraspaso.Caption = "NroTraspaso";
            this.NroTraspaso.FieldName = "NroTraspaso";
            this.NroTraspaso.Name = "NroTraspaso";
            this.NroTraspaso.Visible = true;
            this.NroTraspaso.VisibleIndex = 7;
            this.NroTraspaso.Width = 82;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 8;
            this.Estado.Width = 82;
            // 
            // Usuario
            // 
            this.Usuario.Caption = "Usuario";
            this.Usuario.FieldName = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Visible = true;
            this.Usuario.VisibleIndex = 9;
            this.Usuario.Width = 82;
            // 
            // Destino
            // 
            this.Destino.Caption = "Destino";
            this.Destino.FieldName = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.Visible = true;
            this.Destino.VisibleIndex = 10;
            this.Destino.Width = 115;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon_add_entrega;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(13, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(35, 35);
            this.simpleButton1.TabIndex = 78;
            this.simpleButton1.ToolTip = "Añadir entrega";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnImprimirLocaliza);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.btnVer);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 50);
            this.panel1.TabIndex = 79;
            // 
            // btnImprimirLocaliza
            // 
            this.btnImprimirLocaliza.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnImprimirLocaliza.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon_print_localiza;
            this.btnImprimirLocaliza.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImprimirLocaliza.Location = new System.Drawing.Point(177, 11);
            this.btnImprimirLocaliza.Name = "btnImprimirLocaliza";
            this.btnImprimirLocaliza.Size = new System.Drawing.Size(35, 35);
            this.btnImprimirLocaliza.TabIndex = 80;
            this.btnImprimirLocaliza.ToolTip = "Localiza Celdas";
            this.btnImprimirLocaliza.Click += new System.EventHandler(this.btnImprimirLocaliza_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1188, 598);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 80;
            // 
            // frmListaOrdenParcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 648);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaOrdenParcial";
            this.Text = "Ordenes parciales";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton btnImprimirLocaliza;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn NroOrden;
        private DevExpress.XtraGrid.Columns.GridColumn Placa;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraGrid.Columns.GridColumn Chofer;
        private DevExpress.XtraGrid.Columns.GridColumn TipoDespacho;
        private DevExpress.XtraGrid.Columns.GridColumn NroTraspaso;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn Usuario;
        private DevExpress.XtraGrid.Columns.GridColumn Destino;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo_;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraGrid.Columns.GridColumn UnidadMedida;
        private DevExpress.XtraGrid.Columns.GridColumn PesoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn Pendiente;
    }
}