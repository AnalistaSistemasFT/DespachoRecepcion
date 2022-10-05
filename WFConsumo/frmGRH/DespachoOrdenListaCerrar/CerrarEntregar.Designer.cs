namespace WFConsumo.frmGRH.DespachoOrdenListaCerrar
{
    partial class CerrarEntregar
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDespachoId = new DevExpress.XtraEditors.LabelControl();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnAddCamion = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddChofer = new DevExpress.XtraEditors.SimpleButton();
            this.pickerFecha = new DevExpress.XtraEditors.DateEdit();
            this.comboxChofer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmboxCamion = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSuc = new DevExpress.XtraEditors.TextEdit();
            this.lblCamion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxChofer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxCamion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtDespachoId);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 50);
            this.panel1.TabIndex = 81;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(231, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Cerrar y entregar Despacho:";
            // 
            // txtDespachoId
            // 
            this.txtDespachoId.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.txtDespachoId.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDespachoId.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtDespachoId.Appearance.Options.UseBackColor = true;
            this.txtDespachoId.Appearance.Options.UseFont = true;
            this.txtDespachoId.Appearance.Options.UseForeColor = true;
            this.txtDespachoId.Location = new System.Drawing.Point(249, 12);
            this.txtDespachoId.Name = "txtDespachoId";
            this.txtDespachoId.Size = new System.Drawing.Size(17, 19);
            this.txtDespachoId.TabIndex = 4;
            this.txtDespachoId.Text = " - ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(900, 12);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(276, 26);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ORDENES EN PROCESO";
            // 
            // btnAddCamion
            // 
            this.btnAddCamion.Location = new System.Drawing.Point(330, 103);
            this.btnAddCamion.Name = "btnAddCamion";
            this.btnAddCamion.Size = new System.Drawing.Size(31, 20);
            this.btnAddCamion.TabIndex = 89;
            this.btnAddCamion.Text = " + ";
            this.btnAddCamion.Click += new System.EventHandler(this.btnAddCamion_Click);
            // 
            // btnAddChofer
            // 
            this.btnAddChofer.Location = new System.Drawing.Point(825, 103);
            this.btnAddChofer.Name = "btnAddChofer";
            this.btnAddChofer.Size = new System.Drawing.Size(31, 20);
            this.btnAddChofer.TabIndex = 88;
            this.btnAddChofer.Text = "+";
            this.btnAddChofer.Click += new System.EventHandler(this.btnAddChofer_Click);
            // 
            // pickerFecha
            // 
            this.pickerFecha.EditValue = null;
            this.pickerFecha.Location = new System.Drawing.Point(61, 73);
            this.pickerFecha.Name = "pickerFecha";
            this.pickerFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Size = new System.Drawing.Size(300, 20);
            this.pickerFecha.TabIndex = 87;
            // 
            // comboxChofer
            // 
            this.comboxChofer.Location = new System.Drawing.Point(556, 103);
            this.comboxChofer.Name = "comboxChofer";
            this.comboxChofer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboxChofer.Size = new System.Drawing.Size(263, 20);
            this.comboxChofer.TabIndex = 86;
            this.comboxChofer.SelectedIndexChanged += new System.EventHandler(this.comboxChofer_SelectedIndexChanged);
            // 
            // cmboxCamion
            // 
            this.cmboxCamion.EditValue = "0";
            this.cmboxCamion.Location = new System.Drawing.Point(61, 103);
            this.cmboxCamion.Name = "cmboxCamion";
            this.cmboxCamion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxCamion.Size = new System.Drawing.Size(263, 20);
            this.cmboxCamion.TabIndex = 85;
            this.cmboxCamion.SelectedIndexChanged += new System.EventHandler(this.cmboxCamion_SelectedIndexChanged);
            // 
            // txtSuc
            // 
            this.txtSuc.Location = new System.Drawing.Point(556, 73);
            this.txtSuc.Name = "txtSuc";
            this.txtSuc.Properties.ReadOnly = true;
            this.txtSuc.Size = new System.Drawing.Size(300, 20);
            this.txtSuc.TabIndex = 84;
            // 
            // lblCamion
            // 
            this.lblCamion.AutoSize = true;
            this.lblCamion.Location = new System.Drawing.Point(9, 106);
            this.lblCamion.Name = "lblCamion";
            this.lblCamion.Size = new System.Drawing.Size(46, 13);
            this.lblCamion.TabIndex = 83;
            this.lblCamion.Text = "Camion:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 76);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 13);
            this.lblFecha.TabIndex = 82;
            this.lblFecha.Text = "Fecha: ";
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(503, 106);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(47, 13);
            this.lblChofer.TabIndex = 91;
            this.lblChofer.Text = "Chofer: ";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(496, 76);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(54, 13);
            this.lblSucursal.TabIndex = 90;
            this.lblSucursal.Text = "Sucursal: ";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.groupControl1.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupControl1.AppearanceCaption.BackColor2 = System.Drawing.SystemColors.HotTrack;
            this.groupControl1.AppearanceCaption.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 147);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(846, 217);
            this.groupControl1.TabIndex = 92;
            this.groupControl1.Text = "Productos";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(842, 195);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.CodigoFerro,
            this.Descripcion,
            this.Paquete,
            this.Piezas,
            this.Peso});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 99;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "CodigoFerro";
            this.CodigoFerro.FieldName = "ItemFId";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 108;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 421;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "ProductoId";
            this.Paquete.Name = "Paquete";
            this.Paquete.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductoId", "{0} paquetes")});
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 3;
            this.Paquete.Width = 120;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Piezas", "Total: {0:#.##}")});
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 4;
            this.Piezas.Width = 91;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Peso", "Total: {0:n0} kgs.")});
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 5;
            this.Peso.Width = 138;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseForeColor = true;
            this.btnAceptar.AppearancePressed.BackColor = System.Drawing.Color.DimGray;
            this.btnAceptar.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearancePressed.ForeColor = System.Drawing.Color.DimGray;
            this.btnAceptar.AppearancePressed.Options.UseBackColor = true;
            this.btnAceptar.AppearancePressed.Options.UseBorderColor = true;
            this.btnAceptar.AppearancePressed.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(692, 380);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 30);
            this.btnAceptar.TabIndex = 93;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AppearanceHovered.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancelar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnCancelar.AppearanceHovered.Options.UseForeColor = true;
            this.btnCancelar.AppearancePressed.BackColor = System.Drawing.Color.DimGray;
            this.btnCancelar.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearancePressed.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.AppearancePressed.Options.UseBackColor = true;
            this.btnCancelar.AppearancePressed.Options.UseBorderColor = true;
            this.btnCancelar.AppearancePressed.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(778, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 94;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CerrarEntregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 415);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.btnAddCamion);
            this.Controls.Add(this.btnAddChofer);
            this.Controls.Add(this.pickerFecha);
            this.Controls.Add(this.comboxChofer);
            this.Controls.Add(this.cmboxCamion);
            this.Controls.Add(this.txtSuc);
            this.Controls.Add(this.lblCamion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CerrarEntregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CerrarEntregar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxChofer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxCamion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl txtDespachoId;
        private DevExpress.XtraEditors.SimpleButton btnAddCamion;
        private DevExpress.XtraEditors.SimpleButton btnAddChofer;
        private DevExpress.XtraEditors.DateEdit pickerFecha;
        private DevExpress.XtraEditors.ComboBoxEdit comboxChofer;
        private DevExpress.XtraEditors.ComboBoxEdit cmboxCamion;
        private DevExpress.XtraEditors.TextEdit txtSuc;
        private System.Windows.Forms.Label lblCamion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Label lblSucursal;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
    }
}