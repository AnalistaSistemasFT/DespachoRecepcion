namespace WFConsumo.frmGRH.Localizacion
{
    partial class frmListaOrdenAbierta
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaOrdenAbierta));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NroPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NroOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Item = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Operador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Centro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlanificar = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DetalleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AlmacenOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AlmacenDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CeldaOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CeldaDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquetes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Secuencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatusD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PaqueteId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PesoD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CeldaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 96);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 74;
            this.labelControl1.Text = "Nro. Orden:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(67, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(4, 13);
            this.labelControl2.TabIndex = 75;
            this.labelControl2.Text = "-";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            toolTipTitleItem1.Text = "Nuevo";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.gridControl1.EmbeddedNavigator.SuperTip = superToolTip1;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1186, 227);
            this.gridControl1.TabIndex = 72;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NroPlan,
            this.NroOrden,
            this.Item,
            this.Descripcion,
            this.Fecha,
            this.Cantidad,
            this.Unidad,
            this.Operador,
            this.Status,
            this.Centro});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsBehavior.ReadOnly = true;
            this.gridView4.OptionsFind.FindNullPrompt = "Introduzca el despacho a buscar...";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView4_RowCellClick);
            // 
            // NroPlan
            // 
            this.NroPlan.Caption = "Nro Plan";
            this.NroPlan.FieldName = "planid";
            this.NroPlan.Name = "NroPlan";
            this.NroPlan.Visible = true;
            this.NroPlan.VisibleIndex = 0;
            this.NroPlan.Width = 65;
            // 
            // NroOrden
            // 
            this.NroOrden.Caption = "Nro Orden";
            this.NroOrden.FieldName = "ordenid";
            this.NroOrden.Name = "NroOrden";
            this.NroOrden.Visible = true;
            this.NroOrden.VisibleIndex = 1;
            this.NroOrden.Width = 85;
            // 
            // Item
            // 
            this.Item.Caption = "Item";
            this.Item.FieldName = "ItemId";
            this.Item.Name = "Item";
            this.Item.Visible = true;
            this.Item.VisibleIndex = 2;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 3;
            this.Descripcion.Width = 273;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 4;
            this.Fecha.Width = 83;
            // 
            // Cantidad
            // 
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.FieldName = "cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 5;
            this.Cantidad.Width = 83;
            // 
            // Unidad
            // 
            this.Unidad.Caption = "Unidad";
            this.Unidad.FieldName = "unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Visible = true;
            this.Unidad.VisibleIndex = 6;
            this.Unidad.Width = 65;
            // 
            // Operador
            // 
            this.Operador.Caption = "Operador";
            this.Operador.FieldName = "operador";
            this.Operador.Name = "Operador";
            this.Operador.Visible = true;
            this.Operador.VisibleIndex = 7;
            this.Operador.Width = 100;
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.VisibleIndex = 8;
            this.Status.Width = 68;
            // 
            // Centro
            // 
            this.Centro.Caption = "Centro";
            this.Centro.FieldName = "Centrotrabajo";
            this.Centro.Name = "Centro";
            this.Centro.Visible = true;
            this.Centro.VisibleIndex = 9;
            this.Centro.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.btnPlanificar);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 50);
            this.panel1.TabIndex = 79;
            // 
            // btnPlanificar
            // 
            this.btnPlanificar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPlanificar.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPlanificar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPlanificar.Appearance.Options.UseBackColor = true;
            this.btnPlanificar.Appearance.Options.UseBorderColor = true;
            this.btnPlanificar.Appearance.Options.UseForeColor = true;
            this.btnPlanificar.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlanificar.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlanificar.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlanificar.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlanificar.AppearancePressed.Options.UseBackColor = true;
            this.btnPlanificar.AppearancePressed.Options.UseBorderColor = true;
            this.btnPlanificar.AppearancePressed.Options.UseForeColor = true;
            this.btnPlanificar.AppearancePressed.Options.UseTextOptions = true;
            this.btnPlanificar.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPlanificar.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPlanificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlanificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPlanificar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanificar.ImageOptions.Image")));
            this.btnPlanificar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPlanificar.Location = new System.Drawing.Point(12, 8);
            this.btnPlanificar.Name = "btnPlanificar";
            this.btnPlanificar.Size = new System.Drawing.Size(35, 35);
            this.btnPlanificar.TabIndex = 26;
            this.btnPlanificar.ToolTip = "Picking";
            this.btnPlanificar.Click += new System.EventHandler(this.btnPlanificar_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(939, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(237, 26);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ORDENES ABIERTAS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1188, 598);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 80;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1186, 347);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1178, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programación";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(3, 3);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1172, 315);
            this.gridControl2.TabIndex = 2;
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
            this.DetalleId,
            this.AlmacenOrigen,
            this.AlmacenDestino,
            this.CeldaOrigen,
            this.CeldaDestino,
            this.Paquetes,
            this.Secuencia,
            this.StatusD});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
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
            // DetalleId
            // 
            this.DetalleId.Caption = "DetalleId";
            this.DetalleId.FieldName = "DetalleId";
            this.DetalleId.Name = "DetalleId";
            this.DetalleId.OptionsColumn.AllowEdit = false;
            this.DetalleId.OptionsColumn.ReadOnly = true;
            this.DetalleId.Visible = true;
            this.DetalleId.VisibleIndex = 0;
            this.DetalleId.Width = 90;
            // 
            // AlmacenOrigen
            // 
            this.AlmacenOrigen.Caption = "Almacen Origen";
            this.AlmacenOrigen.FieldName = "AlmacenOrigen";
            this.AlmacenOrigen.Name = "AlmacenOrigen";
            this.AlmacenOrigen.OptionsColumn.ReadOnly = true;
            this.AlmacenOrigen.Visible = true;
            this.AlmacenOrigen.VisibleIndex = 1;
            this.AlmacenOrigen.Width = 129;
            // 
            // AlmacenDestino
            // 
            this.AlmacenDestino.Caption = "Almacen Destino";
            this.AlmacenDestino.FieldName = "AlmacenDestino";
            this.AlmacenDestino.Name = "AlmacenDestino";
            this.AlmacenDestino.OptionsColumn.ReadOnly = true;
            this.AlmacenDestino.Visible = true;
            this.AlmacenDestino.VisibleIndex = 2;
            this.AlmacenDestino.Width = 133;
            // 
            // CeldaOrigen
            // 
            this.CeldaOrigen.Caption = "Celda Origen";
            this.CeldaOrigen.FieldName = "CeldaOrigen";
            this.CeldaOrigen.Name = "CeldaOrigen";
            this.CeldaOrigen.OptionsColumn.ReadOnly = true;
            this.CeldaOrigen.Visible = true;
            this.CeldaOrigen.VisibleIndex = 3;
            this.CeldaOrigen.Width = 161;
            // 
            // CeldaDestino
            // 
            this.CeldaDestino.Caption = "Celda Destino";
            this.CeldaDestino.FieldName = "CeldaDestino";
            this.CeldaDestino.Name = "CeldaDestino";
            this.CeldaDestino.Visible = true;
            this.CeldaDestino.VisibleIndex = 4;
            this.CeldaDestino.Width = 186;
            // 
            // Paquetes
            // 
            this.Paquetes.Caption = "Paquetes";
            this.Paquetes.FieldName = "Paquetes";
            this.Paquetes.Name = "Paquetes";
            this.Paquetes.Visible = true;
            this.Paquetes.VisibleIndex = 5;
            this.Paquetes.Width = 85;
            // 
            // Secuencia
            // 
            this.Secuencia.Caption = "Secuencia";
            this.Secuencia.FieldName = "secuencia";
            this.Secuencia.Name = "Secuencia";
            this.Secuencia.Visible = true;
            this.Secuencia.VisibleIndex = 6;
            this.Secuencia.Width = 102;
            // 
            // StatusD
            // 
            this.StatusD.Caption = "Status";
            this.StatusD.FieldName = "Status";
            this.StatusD.Name = "StatusD";
            this.StatusD.Visible = true;
            this.StatusD.VisibleIndex = 7;
            this.StatusD.Width = 94;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1178, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(3, 3);
            this.gridControl3.MainView = this.gridView1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(1172, 315);
            this.gridControl3.TabIndex = 3;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PaqueteId,
            this.ItemId,
            this.PiezasD,
            this.PesoD,
            this.CeldaId,
            this.FechaD});
            this.gridView1.GridControl = this.gridControl3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // PaqueteId
            // 
            this.PaqueteId.Caption = "Paquete";
            this.PaqueteId.FieldName = "Paqueteid";
            this.PaqueteId.Name = "PaqueteId";
            this.PaqueteId.OptionsColumn.AllowEdit = false;
            this.PaqueteId.OptionsColumn.ReadOnly = true;
            this.PaqueteId.Visible = true;
            this.PaqueteId.VisibleIndex = 0;
            this.PaqueteId.Width = 159;
            // 
            // ItemId
            // 
            this.ItemId.Caption = "Codigo";
            this.ItemId.FieldName = "itemid";
            this.ItemId.Name = "ItemId";
            this.ItemId.OptionsColumn.ReadOnly = true;
            this.ItemId.Visible = true;
            this.ItemId.VisibleIndex = 1;
            this.ItemId.Width = 167;
            // 
            // PiezasD
            // 
            this.PiezasD.Caption = "Piezas";
            this.PiezasD.FieldName = "piezas";
            this.PiezasD.Name = "PiezasD";
            this.PiezasD.OptionsColumn.ReadOnly = true;
            this.PiezasD.Visible = true;
            this.PiezasD.VisibleIndex = 2;
            this.PiezasD.Width = 140;
            // 
            // PesoD
            // 
            this.PesoD.Caption = "Peso";
            this.PesoD.FieldName = "peso";
            this.PesoD.Name = "PesoD";
            this.PesoD.OptionsColumn.ReadOnly = true;
            this.PesoD.Visible = true;
            this.PesoD.VisibleIndex = 3;
            this.PesoD.Width = 123;
            // 
            // CeldaId
            // 
            this.CeldaId.Caption = "Celda";
            this.CeldaId.FieldName = "Celdaid";
            this.CeldaId.Name = "CeldaId";
            this.CeldaId.Visible = true;
            this.CeldaId.VisibleIndex = 4;
            this.CeldaId.Width = 221;
            // 
            // FechaD
            // 
            this.FechaD.Caption = "Fecha";
            this.FechaD.FieldName = "fecha";
            this.FechaD.Name = "FechaD";
            this.FechaD.Visible = true;
            this.FechaD.VisibleIndex = 5;
            this.FechaD.Width = 170;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.simpleButton1.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.simpleButton1.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.simpleButton1.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.simpleButton1.AppearancePressed.Options.UseBackColor = true;
            this.simpleButton1.AppearancePressed.Options.UseBorderColor = true;
            this.simpleButton1.AppearancePressed.Options.UseForeColor = true;
            this.simpleButton1.AppearancePressed.Options.UseTextOptions = true;
            this.simpleButton1.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(53, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(35, 35);
            this.simpleButton1.TabIndex = 27;
            this.simpleButton1.ToolTip = "Planificar Localizacion";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmListaOrdenAbierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 648);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaOrdenAbierta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListaOrdenAbierta";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        } 
        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn NroOrden;
        private DevExpress.XtraGrid.Columns.GridColumn Item;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Unidad;
        private DevExpress.XtraGrid.Columns.GridColumn Centro;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn DetalleId;
        private DevExpress.XtraGrid.Columns.GridColumn AlmacenOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn AlmacenDestino;
        private DevExpress.XtraGrid.Columns.GridColumn CeldaOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn NroPlan;
        private DevExpress.XtraGrid.Columns.GridColumn Operador;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.Columns.GridColumn CeldaDestino;
        private DevExpress.XtraGrid.Columns.GridColumn Paquetes;
        private DevExpress.XtraGrid.Columns.GridColumn Secuencia;
        private DevExpress.XtraGrid.Columns.GridColumn StatusD;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn PaqueteId;
        private DevExpress.XtraGrid.Columns.GridColumn ItemId;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasD;
        private DevExpress.XtraGrid.Columns.GridColumn PesoD;
        private DevExpress.XtraGrid.Columns.GridColumn CeldaId;
        private DevExpress.XtraGrid.Columns.GridColumn FechaD;
        private DevExpress.XtraEditors.SimpleButton btnPlanificar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}