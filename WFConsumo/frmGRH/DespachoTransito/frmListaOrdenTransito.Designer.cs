﻿namespace WFConsumo.frmGRH.DespachoTransito
{
    partial class frmListaOrdenTransito
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaOrdenTransito));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasProg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirLocaliza = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnControlDespacho = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
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
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(992, 391);
            this.splitContainer1.SplitterDistance = 213;
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
            this.gridControl1.Size = new System.Drawing.Size(992, 213);
            this.gridControl1.TabIndex = 72;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "despachoid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "NroOrden";
            this.gridColumn3.FieldName = "nroorden";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Placa";
            this.gridColumn4.FieldName = "Placa";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Marca";
            this.gridColumn5.FieldName = "Marca";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Chofer";
            this.gridColumn6.FieldName = "chofer";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tipo Despacho";
            this.gridColumn7.FieldName = "Naturaleza";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Destino";
            this.gridColumn8.FieldName = "DESTINO";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "NroTraspaso";
            this.gridColumn9.FieldName = "numtraspaso";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Programación";
            this.gridColumn10.FieldName = "tipo";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Login";
            this.gridColumn11.FieldName = "LOGIN";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(992, 158);
            this.xtraTabControl1.TabIndex = 73;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(986, 130);
            this.xtraTabPage1.Text = "Progreso";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl2.Size = new System.Drawing.Size(986, 130);
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
            this.ItemId,
            this.Descripcion,
            this.PiezasReq,
            this.PiezasProg,
            this.PiezasComp,
            this.Peso});
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
            // ItemId
            // 
            this.ItemId.Caption = "ItemId";
            this.ItemId.FieldName = "p_ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.OptionsColumn.AllowEdit = false;
            this.ItemId.OptionsColumn.ReadOnly = true;
            this.ItemId.Visible = true;
            this.ItemId.VisibleIndex = 0;
            this.ItemId.Width = 72;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "p_Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.ReadOnly = true;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 1;
            this.Descripcion.Width = 307;
            // 
            // PiezasReq
            // 
            this.PiezasReq.Caption = "PiezasReq";
            this.PiezasReq.FieldName = "p_PiezasReq";
            this.PiezasReq.Name = "PiezasReq";
            this.PiezasReq.OptionsColumn.ReadOnly = true;
            this.PiezasReq.Visible = true;
            this.PiezasReq.VisibleIndex = 2;
            this.PiezasReq.Width = 98;
            // 
            // PiezasProg
            // 
            this.PiezasProg.Caption = "PiezasProg";
            this.PiezasProg.FieldName = "p_PiezasProg";
            this.PiezasProg.Name = "PiezasProg";
            this.PiezasProg.OptionsColumn.ReadOnly = true;
            this.PiezasProg.Visible = true;
            this.PiezasProg.VisibleIndex = 3;
            this.PiezasProg.Width = 98;
            // 
            // PiezasComp
            // 
            this.PiezasComp.Caption = "PiezasComp";
            this.PiezasComp.FieldName = "p_PiezasComp";
            this.PiezasComp.Name = "PiezasComp";
            this.PiezasComp.OptionsColumn.ReadOnly = true;
            this.PiezasComp.Visible = true;
            this.PiezasComp.VisibleIndex = 4;
            this.PiezasComp.Width = 98;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "p_Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.ReadOnly = true;
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 5;
            this.Peso.Width = 124;
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
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(986, 130);
            this.xtraTabPage2.Text = "Producto";
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(986, 130);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnImprimirLocaliza);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnControlDespacho);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.btnVer);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 50);
            this.panel1.TabIndex = 85;
            // 
            // btnImprimirLocaliza
            // 
            this.btnImprimirLocaliza.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.btnImprimirLocaliza.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.btnImprimirLocaliza.Appearance.Options.UseBackColor = true;
            this.btnImprimirLocaliza.Appearance.Options.UseForeColor = true;
            this.btnImprimirLocaliza.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnImprimirLocaliza.Enabled = false;
            this.btnImprimirLocaliza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirLocaliza.ImageOptions.Image")));
            this.btnImprimirLocaliza.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImprimirLocaliza.Location = new System.Drawing.Point(176, 8);
            this.btnImprimirLocaliza.Name = "btnImprimirLocaliza";
            this.btnImprimirLocaliza.Size = new System.Drawing.Size(35, 35);
            this.btnImprimirLocaliza.TabIndex = 85;
            this.btnImprimirLocaliza.ToolTip = "Imprimir Orden de Carga";
            this.btnImprimirLocaliza.Click += new System.EventHandler(this.btnImprimirLocaliza_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnImprimir.Location = new System.Drawing.Point(53, 8);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(35, 35);
            this.btnImprimir.TabIndex = 84;
            this.btnImprimir.ToolTip = "Imprimir Despachos Autorizados";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnControlDespacho
            // 
            this.btnControlDespacho.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnControlDespacho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnControlDespacho.ImageOptions.Image")));
            this.btnControlDespacho.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnControlDespacho.Location = new System.Drawing.Point(135, 8);
            this.btnControlDespacho.Name = "btnControlDespacho";
            this.btnControlDespacho.Size = new System.Drawing.Size(35, 35);
            this.btnControlDespacho.TabIndex = 83;
            this.btnControlDespacho.ToolTip = "Control Despacho";
            this.btnControlDespacho.Click += new System.EventHandler(this.btnControlDespacho_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(815, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(274, 26);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ORDENES EN TRANSITO";
            // 
            // btnVer
            // 
            this.btnVer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnVer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.ImageOptions.Image")));
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVer.Location = new System.Drawing.Point(12, 8);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(35, 35);
            this.btnVer.TabIndex = 68;
            this.btnVer.ToolTip = "Consultar";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscar.Location = new System.Drawing.Point(94, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 69;
            this.btnBuscar.ToolTip = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmListaOrdenTransito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 441);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaOrdenTransito";
            this.Text = "frmListaOrdenTransito";
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
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn ItemId;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasReq;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasProg;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasComp;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnControlDespacho;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnImprimirLocaliza;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
    }
}