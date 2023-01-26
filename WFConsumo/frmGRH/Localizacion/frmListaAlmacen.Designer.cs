namespace WFConsumo.frmGRH.Localizacion
{
    partial class frmListaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaAlmacen));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNomAlmac = new DevExpress.XtraEditors.LabelControl();
            this.txtIdSucursal = new DevExpress.XtraEditors.LabelControl();
            this.codigolbl = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaqXCelda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CeldasPreAsignadas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.capinst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.caputil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.capinstkg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.caputilkg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCeldas = new DevExpress.XtraEditors.SimpleButton();
            this.btnPaquetes = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlanificar = new DevExpress.XtraEditors.SimpleButton();
            this.labelTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(118, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Almacen: ";
            // 
            // txtNomAlmac
            // 
            this.txtNomAlmac.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomAlmac.Appearance.Options.UseFont = true;
            this.txtNomAlmac.Location = new System.Drawing.Point(134, 10);
            this.txtNomAlmac.Name = "txtNomAlmac";
            this.txtNomAlmac.Size = new System.Drawing.Size(24, 29);
            this.txtNomAlmac.TabIndex = 1;
            this.txtNomAlmac.Text = " - ";
            // 
            // txtIdSucursal
            // 
            this.txtIdSucursal.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSucursal.Appearance.Options.UseFont = true;
            this.txtIdSucursal.Location = new System.Drawing.Point(798, 10);
            this.txtIdSucursal.Name = "txtIdSucursal";
            this.txtIdSucursal.Size = new System.Drawing.Size(24, 29);
            this.txtIdSucursal.TabIndex = 3;
            this.txtIdSucursal.Text = " - ";
            // 
            // codigolbl
            // 
            this.codigolbl.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigolbl.Appearance.Options.UseFont = true;
            this.codigolbl.Location = new System.Drawing.Point(693, 10);
            this.codigolbl.Name = "codigolbl";
            this.codigolbl.Size = new System.Drawing.Size(99, 29);
            this.codigolbl.TabIndex = 2;
            this.codigolbl.Text = "Codigo: ";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1121, 387);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.CodigoFerro,
            this.Descripcion,
            this.PaqXCelda,
            this.CeldasPreAsignadas,
            this.capinst,
            this.caputil,
            this.capinstkg,
            this.caputilkg});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.FindFilterColumns = "Codigo, CodigoFerro, Descripcion";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 76;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferro";
            this.CodigoFerro.FieldName = "ItemFId";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 86;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 257;
            // 
            // PaqXCelda
            // 
            this.PaqXCelda.Caption = "Paquetes por celda";
            this.PaqXCelda.FieldName = "paqXcelda";
            this.PaqXCelda.Name = "PaqXCelda";
            this.PaqXCelda.Visible = true;
            this.PaqXCelda.VisibleIndex = 3;
            this.PaqXCelda.Width = 117;
            // 
            // CeldasPreAsignadas
            // 
            this.CeldasPreAsignadas.Caption = "Celdas pre asignadas";
            this.CeldasPreAsignadas.FieldName = "celdaUtil";
            this.CeldasPreAsignadas.Name = "CeldasPreAsignadas";
            this.CeldasPreAsignadas.Visible = true;
            this.CeldasPreAsignadas.VisibleIndex = 4;
            this.CeldasPreAsignadas.Width = 87;
            // 
            // capinst
            // 
            this.capinst.Caption = "capinst";
            this.capinst.FieldName = "capinst";
            this.capinst.Name = "capinst";
            this.capinst.Visible = true;
            this.capinst.VisibleIndex = 5;
            this.capinst.Width = 87;
            // 
            // caputil
            // 
            this.caputil.Caption = "caputil";
            this.caputil.FieldName = "caputil";
            this.caputil.Name = "caputil";
            this.caputil.Visible = true;
            this.caputil.VisibleIndex = 6;
            this.caputil.Width = 99;
            // 
            // capinstkg
            // 
            this.capinstkg.Caption = "capinstkg";
            this.capinstkg.FieldName = "capinstkg";
            this.capinstkg.Name = "capinstkg";
            this.capinstkg.Visible = true;
            this.capinstkg.VisibleIndex = 7;
            this.capinstkg.Width = 92;
            // 
            // caputilkg
            // 
            this.caputilkg.Caption = "caputilkg";
            this.caputilkg.FieldName = "caputilkg";
            this.caputilkg.Name = "caputilkg";
            this.caputilkg.Visible = true;
            this.caputilkg.VisibleIndex = 8;
            this.caputilkg.Width = 96;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtIdSucursal);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtNomAlmac);
            this.splitContainerControl1.Panel1.Controls.Add(this.codigolbl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1125, 452);
            this.splitContainerControl1.SplitterPosition = 56;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnCeldas);
            this.panel1.Controls.Add(this.btnPaquetes);
            this.panel1.Controls.Add(this.btnPlanificar);
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 50);
            this.panel1.TabIndex = 82;
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
            this.btnBuscar.Location = new System.Drawing.Point(136, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 85;
            this.btnBuscar.ToolTip = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCeldas
            // 
            this.btnCeldas.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCeldas.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCeldas.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCeldas.Appearance.Options.UseBackColor = true;
            this.btnCeldas.Appearance.Options.UseBorderColor = true;
            this.btnCeldas.Appearance.Options.UseForeColor = true;
            this.btnCeldas.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCeldas.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCeldas.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCeldas.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCeldas.AppearancePressed.Options.UseBackColor = true;
            this.btnCeldas.AppearancePressed.Options.UseBorderColor = true;
            this.btnCeldas.AppearancePressed.Options.UseForeColor = true;
            this.btnCeldas.AppearancePressed.Options.UseTextOptions = true;
            this.btnCeldas.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCeldas.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnCeldas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCeldas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCeldas.ImageOptions.Image = global::WFConsumo.Properties.Resources.rack;
            this.btnCeldas.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCeldas.Location = new System.Drawing.Point(95, 9);
            this.btnCeldas.Name = "btnCeldas";
            this.btnCeldas.Size = new System.Drawing.Size(35, 35);
            this.btnCeldas.TabIndex = 84;
            this.btnCeldas.ToolTip = "Celdas";
            this.btnCeldas.Click += new System.EventHandler(this.btnCeldas_Click);
            // 
            // btnPaquetes
            // 
            this.btnPaquetes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPaquetes.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPaquetes.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnPaquetes.Appearance.Options.UseBackColor = true;
            this.btnPaquetes.Appearance.Options.UseBorderColor = true;
            this.btnPaquetes.Appearance.Options.UseForeColor = true;
            this.btnPaquetes.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPaquetes.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPaquetes.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPaquetes.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPaquetes.AppearancePressed.Options.UseBackColor = true;
            this.btnPaquetes.AppearancePressed.Options.UseBorderColor = true;
            this.btnPaquetes.AppearancePressed.Options.UseForeColor = true;
            this.btnPaquetes.AppearancePressed.Options.UseTextOptions = true;
            this.btnPaquetes.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPaquetes.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPaquetes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPaquetes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPaquetes.ImageOptions.Image = global::WFConsumo.Properties.Resources.barcode__1_;
            this.btnPaquetes.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPaquetes.Location = new System.Drawing.Point(53, 9);
            this.btnPaquetes.Name = "btnPaquetes";
            this.btnPaquetes.Size = new System.Drawing.Size(35, 35);
            this.btnPaquetes.TabIndex = 83;
            this.btnPaquetes.ToolTip = "Paquetes";
            this.btnPaquetes.Click += new System.EventHandler(this.btnPaquetes_Click);
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
            this.btnPlanificar.Location = new System.Drawing.Point(12, 9);
            this.btnPlanificar.Name = "btnPlanificar";
            this.btnPlanificar.Size = new System.Drawing.Size(35, 35);
            this.btnPlanificar.TabIndex = 82;
            this.btnPlanificar.ToolTip = "Calcular Abastecimiento";
            this.btnPlanificar.Click += new System.EventHandler(this.btnPlanificar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(996, 10);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(119, 26);
            this.labelTitulo.TabIndex = 80;
            this.labelTitulo.Text = "ALMACÉN";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmListaAlmacen
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 502);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaAlmacen";
            this.Text = "Almacen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl txtNomAlmac;
        private DevExpress.XtraEditors.LabelControl txtIdSucursal;
        private DevExpress.XtraEditors.LabelControl codigolbl;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn PaqXCelda;
        private DevExpress.XtraGrid.Columns.GridColumn CeldasPreAsignadas;
        private DevExpress.XtraGrid.Columns.GridColumn capinst;
        private DevExpress.XtraGrid.Columns.GridColumn caputil;
        private DevExpress.XtraGrid.Columns.GridColumn capinstkg;
        private DevExpress.XtraGrid.Columns.GridColumn caputilkg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitulo;
        private DevExpress.XtraEditors.SimpleButton btnPlanificar;
        private DevExpress.XtraEditors.SimpleButton btnPaquetes;
        private DevExpress.XtraEditors.SimpleButton btnCeldas;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}