namespace WFConsumo.frmGRH.Devoluciones
{
    partial class NuevaDevolucion
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumOV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSucursal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtChofer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombreCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtMonto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtVendedor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlaca = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtNuevaOV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RecepcionP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Observaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtMotivo = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtFechaEntrega = new DevExpress.XtraEditors.DateEdit();
            this.txtFechaRecepcion = new DevExpress.XtraEditors.DateEdit();
            this.searchOV = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChofer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaOV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaEntrega.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaEntrega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRecepcion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRecepcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchOV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(154, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Datos de la venta: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Codigo cliente: ";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(125, 62);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(140, 20);
            this.txtCodigoCliente.TabIndex = 2;
            // 
            // txtNumOV
            // 
            this.txtNumOV.Enabled = false;
            this.txtNumOV.Location = new System.Drawing.Point(125, 96);
            this.txtNumOV.Name = "txtNumOV";
            this.txtNumOV.Size = new System.Drawing.Size(140, 20);
            this.txtNumOV.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "N° OV:";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Enabled = false;
            this.txtSucursal.Location = new System.Drawing.Point(125, 129);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(140, 20);
            this.txtSucursal.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 132);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Sucursal: ";
            // 
            // txtChofer
            // 
            this.txtChofer.Enabled = false;
            this.txtChofer.Location = new System.Drawing.Point(125, 162);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(140, 20);
            this.txtChofer.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 165);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Chofer: ";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(462, 62);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(503, 20);
            this.txtNombreCliente.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(349, 65);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(92, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Nombre del cliente:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(462, 96);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(140, 20);
            this.txtMonto.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(349, 99);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Monto Bs.:";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Enabled = false;
            this.txtVendedor.Location = new System.Drawing.Point(462, 129);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(140, 20);
            this.txtVendedor.TabIndex = 14;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(349, 132);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(53, 13);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "Vendedor: ";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Enabled = false;
            this.txtPlaca.Location = new System.Drawing.Point(462, 162);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(140, 20);
            this.txtPlaca.TabIndex = 16;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(349, 165);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(32, 13);
            this.labelControl9.TabIndex = 15;
            this.labelControl9.Text = "Placa: ";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(712, 99);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(92, 13);
            this.labelControl10.TabIndex = 17;
            this.labelControl10.Text = "Fecha de entrega: ";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(712, 132);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(100, 13);
            this.labelControl11.TabIndex = 19;
            this.labelControl11.Text = "Fecha de recepción: ";
            // 
            // txtNuevaOV
            // 
            this.txtNuevaOV.Enabled = false;
            this.txtNuevaOV.Location = new System.Drawing.Point(825, 162);
            this.txtNuevaOV.Name = "txtNuevaOV";
            this.txtNuevaOV.Size = new System.Drawing.Size(140, 20);
            this.txtNuevaOV.TabIndex = 22;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(712, 165);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(81, 13);
            this.labelControl12.TabIndex = 21;
            this.labelControl12.Text = "N° de nueva OV:";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(12, 200);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(288, 19);
            this.labelControl13.TabIndex = 23;
            this.labelControl13.Text = "Detalle de la mercaderia devuelta: ";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 225);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(952, 200);
            this.gridControl1.TabIndex = 24;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Cantidad,
            this.Unidad,
            this.RecepcionP,
            this.Observaciones});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Codigo
            // 
            this.Codigo.AppearanceHeader.Options.UseTextOptions = true;
            this.Codigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Codigo.Caption = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 123;
            // 
            // Descripcion
            // 
            this.Descripcion.AppearanceHeader.Options.UseTextOptions = true;
            this.Descripcion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 1;
            this.Descripcion.Width = 419;
            // 
            // Cantidad
            // 
            this.Cantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.Cantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 2;
            this.Cantidad.Width = 74;
            // 
            // Unidad
            // 
            this.Unidad.AppearanceHeader.Options.UseTextOptions = true;
            this.Unidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Unidad.Caption = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Visible = true;
            this.Unidad.VisibleIndex = 3;
            this.Unidad.Width = 65;
            // 
            // RecepcionP
            // 
            this.RecepcionP.AppearanceHeader.Options.UseTextOptions = true;
            this.RecepcionP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RecepcionP.Caption = "Recepcion producto";
            this.RecepcionP.ColumnEdit = this.repositoryItemCheckEdit1;
            this.RecepcionP.Name = "RecepcionP";
            this.RecepcionP.Visible = true;
            this.RecepcionP.VisibleIndex = 4;
            this.RecepcionP.Width = 73;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // Observaciones
            // 
            this.Observaciones.AppearanceHeader.Options.UseTextOptions = true;
            this.Observaciones.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Observaciones.Caption = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Visible = true;
            this.Observaciones.VisibleIndex = 5;
            this.Observaciones.Width = 301;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(12, 440);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(203, 19);
            this.labelControl14.TabIndex = 25;
            this.labelControl14.Text = "Motivo de la devolución: ";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(11, 465);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMotivo.Size = new System.Drawing.Size(953, 96);
            this.txtMotivo.TabIndex = 26;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseBorderColor = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnCancelar.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btnCancelar.AppearanceHovered.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancelar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnCancelar.AppearanceHovered.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(864, 567);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseBorderColor = true;
            this.btnAceptar.Appearance.Options.UseForeColor = true;
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnAceptar.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btnAceptar.AppearanceHovered.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(758, 567);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.TabIndex = 28;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.EditValue = null;
            this.txtFechaEntrega.Enabled = false;
            this.txtFechaEntrega.Location = new System.Drawing.Point(825, 96);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaEntrega.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaEntrega.Size = new System.Drawing.Size(140, 20);
            this.txtFechaEntrega.TabIndex = 30;
            // 
            // txtFechaRecepcion
            // 
            this.txtFechaRecepcion.EditValue = null;
            this.txtFechaRecepcion.Enabled = false;
            this.txtFechaRecepcion.Location = new System.Drawing.Point(825, 129);
            this.txtFechaRecepcion.Name = "txtFechaRecepcion";
            this.txtFechaRecepcion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaRecepcion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaRecepcion.Size = new System.Drawing.Size(140, 20);
            this.txtFechaRecepcion.TabIndex = 31;
            // 
            // searchOV
            // 
            this.searchOV.Location = new System.Drawing.Point(179, 11);
            this.searchOV.Name = "searchOV";
            this.searchOV.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.searchOV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.searchOV.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.searchOV.Properties.Appearance.Options.UseBorderColor = true;
            this.searchOV.Properties.Appearance.Options.UseFont = true;
            this.searchOV.Properties.Appearance.Options.UseForeColor = true;
            this.searchOV.Properties.Appearance.Options.UseTextOptions = true;
            this.searchOV.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.searchOV.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.Green;
            this.searchOV.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.searchOV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.searchOV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchOV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.searchOV.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.searchOV.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.searchOV.Properties.NullValuePrompt = "Ingrese el numero de OV";
            this.searchOV.Size = new System.Drawing.Size(234, 22);
            this.searchOV.TabIndex = 32;
            // 
            // NuevaDevolucion
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 608);
            this.Controls.Add(this.searchOV);
            this.Controls.Add(this.txtFechaRecepcion);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.txtNuevaOV);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtChofer);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtNumOV);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Devolucion";
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChofer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaOV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaEntrega.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaEntrega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRecepcion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRecepcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchOV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodigoCliente;
        private DevExpress.XtraEditors.TextEdit txtNumOV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSucursal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtChofer;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtNombreCliente;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtMonto;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtVendedor;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPlaca;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtNuevaOV;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.MemoEdit txtMotivo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.DateEdit txtFechaEntrega;
        private DevExpress.XtraEditors.DateEdit txtFechaRecepcion;
        private DevExpress.XtraEditors.SearchControl searchOV;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Unidad;
        private DevExpress.XtraGrid.Columns.GridColumn RecepcionP;
        private DevExpress.XtraGrid.Columns.GridColumn Observaciones;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}