namespace WFConsumo.frmGRH.Devoluciones
{
    partial class frmListaDevoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaDevoluciones));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition1 = new DevExpress.Utils.Animation.SlideFadeTransition();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarDevolucion = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClienteCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClienteNom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrdenVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Monto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaRecepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Observaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnAgregarDevolucion);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 50);
            this.panel1.TabIndex = 81;
            // 
            // btnAgregarDevolucion
            // 
            this.btnAgregarDevolucion.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAgregarDevolucion.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAgregarDevolucion.AppearancePressed.Options.UseBackColor = true;
            this.btnAgregarDevolucion.AppearancePressed.Options.UseForeColor = true;
            this.btnAgregarDevolucion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnAgregarDevolucion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarDevolucion.ImageOptions.Image")));
            this.btnAgregarDevolucion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAgregarDevolucion.Location = new System.Drawing.Point(12, 8);
            this.btnAgregarDevolucion.Name = "btnAgregarDevolucion";
            this.btnAgregarDevolucion.Size = new System.Drawing.Size(35, 35);
            this.btnAgregarDevolucion.TabIndex = 82;
            this.btnAgregarDevolucion.ToolTip = "Agregar devolución";
            this.btnAgregarDevolucion.Click += new System.EventHandler(this.btnAgregarDevolucion_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(738, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(188, 26);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "DEVOLUCIONES";
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(961, 452);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 82;
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
            this.gridControl1.Size = new System.Drawing.Size(959, 213);
            this.gridControl1.TabIndex = 73;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ClienteCod,
            this.ClienteNom,
            this.OrdenVenta,
            this.Vendedor,
            this.Monto,
            this.FechaEntrega,
            this.FechaRecepcion});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsBehavior.ReadOnly = true;
            this.gridView4.OptionsFind.FindNullPrompt = "Introduzca el despacho a buscar...";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // ClienteCod
            // 
            this.ClienteCod.Caption = "Codigo cliente";
            this.ClienteCod.FieldName = "NroPlan";
            this.ClienteCod.Name = "ClienteCod";
            this.ClienteCod.Visible = true;
            this.ClienteCod.VisibleIndex = 1;
            this.ClienteCod.Width = 127;
            // 
            // ClienteNom
            // 
            this.ClienteNom.Caption = "Nombre";
            this.ClienteNom.FieldName = "Login";
            this.ClienteNom.Name = "ClienteNom";
            this.ClienteNom.Visible = true;
            this.ClienteNom.VisibleIndex = 2;
            this.ClienteNom.Width = 245;
            // 
            // OrdenVenta
            // 
            this.OrdenVenta.Caption = "Orden de Venta";
            this.OrdenVenta.FieldName = "Fecha";
            this.OrdenVenta.Name = "OrdenVenta";
            this.OrdenVenta.Visible = true;
            this.OrdenVenta.VisibleIndex = 0;
            this.OrdenVenta.Width = 107;
            // 
            // Vendedor
            // 
            this.Vendedor.Caption = "Vendedor";
            this.Vendedor.FieldName = "ItemId";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Visible = true;
            this.Vendedor.VisibleIndex = 3;
            this.Vendedor.Width = 262;
            // 
            // Monto
            // 
            this.Monto.Caption = "Monto";
            this.Monto.FieldName = "Descripcion";
            this.Monto.Name = "Monto";
            this.Monto.Visible = true;
            this.Monto.VisibleIndex = 4;
            this.Monto.Width = 103;
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.Caption = "Fecha entrega";
            this.FechaEntrega.FieldName = "Origen";
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.Visible = true;
            this.FechaEntrega.VisibleIndex = 5;
            this.FechaEntrega.Width = 135;
            // 
            // FechaRecepcion
            // 
            this.FechaRecepcion.Caption = "Fecha recepción";
            this.FechaRecepcion.FieldName = "Destino";
            this.FechaRecepcion.Name = "FechaRecepcion";
            this.FechaRecepcion.Visible = true;
            this.FechaRecepcion.VisibleIndex = 6;
            this.FechaRecepcion.Width = 154;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage4;
            this.xtraTabControl2.Size = new System.Drawing.Size(959, 215);
            this.xtraTabControl2.TabIndex = 3;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage4});
            this.xtraTabControl2.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl2.Transition.TransitionType = slideFadeTransition1;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.gridControl4);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(953, 187);
            this.xtraTabPage4.Text = "Detalle de mercaderia devuelta";
            // 
            // gridControl4
            // 
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.Location = new System.Drawing.Point(0, 0);
            this.gridControl4.MainView = this.gridView3;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.gridControl4.Size = new System.Drawing.Size(953, 187);
            this.gridControl4.TabIndex = 3;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView3.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.CodigoFerro,
            this.Descripcion,
            this.Cantidad,
            this.Unidad,
            this.Observaciones});
            this.gridView3.GridControl = this.gridControl4;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 95;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferrotodo";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 131;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 334;
            // 
            // Cantidad
            // 
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 3;
            this.Cantidad.Width = 117;
            // 
            // Unidad
            // 
            this.Unidad.Caption = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Visible = true;
            this.Unidad.VisibleIndex = 4;
            this.Unidad.Width = 90;
            // 
            // Observaciones
            // 
            this.Observaciones.Caption = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Visible = true;
            this.Observaciones.VisibleIndex = 5;
            this.Observaciones.Width = 349;
            // 
            // repositoryItemButtonEdit2
            // 
            serializableAppearanceObject1.BackColor = System.Drawing.Color.DarkGreen;
            serializableAppearanceObject1.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject1.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            serializableAppearanceObject2.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject2.Options.UseForeColor = true;
            serializableAppearanceObject3.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject3.Options.UseForeColor = true;
            serializableAppearanceObject4.ForeColor = System.Drawing.Color.LimeGreen;
            serializableAppearanceObject4.Options.UseForeColor = true;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", 1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Programar despacho", null, null)});
            this.repositoryItemButtonEdit2.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.ReadOnly = true;
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemButtonEdit2.UseReadOnlyAppearance = false;
            // 
            // frmListaDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 502);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmListaDevoluciones";
            this.Text = "Lista de Devoluciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraGrid.GridControl gridControl4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.SimpleButton btnAgregarDevolucion;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn ClienteCod;
        private DevExpress.XtraGrid.Columns.GridColumn ClienteNom;
        private DevExpress.XtraGrid.Columns.GridColumn OrdenVenta;
        private DevExpress.XtraGrid.Columns.GridColumn Vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn Monto;
        private DevExpress.XtraGrid.Columns.GridColumn FechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn FechaRecepcion;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Unidad;
        private DevExpress.XtraGrid.Columns.GridColumn Observaciones;
    }
}