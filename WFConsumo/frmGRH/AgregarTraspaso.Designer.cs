namespace WFConsumo.frmGRH
{
    partial class AgregarTraspaso
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
            this.btcCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtFechaReg = new DevExpress.XtraEditors.DateEdit();
            this.txtFechaDoc = new DevExpress.XtraEditors.DateEdit();
            this.txtSucRecibeNom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtSucEntregaNom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoDodNom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSucEntregaId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoDocId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoDodId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAgregarProducto = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Costo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSucRecibeId = new DevExpress.XtraEditors.TextEdit();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaReg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaReg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDoc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucRecibeNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucEntregaNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDodNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucEntregaId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDocId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDodId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucRecibeId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btcCancelar
            // 
            this.btcCancelar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btcCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btcCancelar.Appearance.Options.UseBackColor = true;
            this.btcCancelar.Appearance.Options.UseForeColor = true;
            this.btcCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btcCancelar.Location = new System.Drawing.Point(550, 441);
            this.btcCancelar.Name = "btcCancelar";
            this.btcCancelar.Size = new System.Drawing.Size(100, 29);
            this.btcCancelar.TabIndex = 52;
            this.btcCancelar.Text = "Cancelar";
            this.btcCancelar.Click += new System.EventHandler(this.btcCancelar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Location = new System.Drawing.Point(444, 441);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 29);
            this.simpleButton1.TabIndex = 51;
            this.simpleButton1.Text = "Aceptar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtFechaReg
            // 
            this.txtFechaReg.EditValue = null;
            this.txtFechaReg.Enabled = false;
            this.txtFechaReg.Location = new System.Drawing.Point(550, 44);
            this.txtFechaReg.Name = "txtFechaReg";
            this.txtFechaReg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaReg.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaReg.Properties.ReadOnly = true;
            this.txtFechaReg.Size = new System.Drawing.Size(100, 20);
            this.txtFechaReg.TabIndex = 50;
            // 
            // txtFechaDoc
            // 
            this.txtFechaDoc.EditValue = null;
            this.txtFechaDoc.Enabled = false;
            this.txtFechaDoc.Location = new System.Drawing.Point(372, 44);
            this.txtFechaDoc.Name = "txtFechaDoc";
            this.txtFechaDoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaDoc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechaDoc.Properties.ReadOnly = true;
            this.txtFechaDoc.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDoc.TabIndex = 49;
            // 
            // txtSucRecibeNom
            // 
            this.txtSucRecibeNom.Location = new System.Drawing.Point(372, 115);
            this.txtSucRecibeNom.Name = "txtSucRecibeNom";
            this.txtSucRecibeNom.Properties.ReadOnly = true;
            this.txtSucRecibeNom.Size = new System.Drawing.Size(278, 20);
            this.txtSucRecibeNom.TabIndex = 47;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(279, 118);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(79, 13);
            this.labelControl11.TabIndex = 46;
            this.labelControl11.Text = "Sucursal Recibe:";
            // 
            // txtSucEntregaNom
            // 
            this.txtSucEntregaNom.Location = new System.Drawing.Point(372, 79);
            this.txtSucEntregaNom.Name = "txtSucEntregaNom";
            this.txtSucEntregaNom.Properties.ReadOnly = true;
            this.txtSucEntregaNom.Size = new System.Drawing.Size(278, 20);
            this.txtSucEntregaNom.TabIndex = 45;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(279, 82);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(85, 13);
            this.labelControl10.TabIndex = 44;
            this.labelControl10.Text = "Sucursal Entrega:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(489, 47);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(55, 13);
            this.labelControl9.TabIndex = 43;
            this.labelControl9.Text = "Fecha Reg:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(279, 47);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 13);
            this.labelControl8.TabIndex = 42;
            this.labelControl8.Text = "Fecha Doc:";
            // 
            // txtTipoDodNom
            // 
            this.txtTipoDodNom.Location = new System.Drawing.Point(372, 9);
            this.txtTipoDodNom.Name = "txtTipoDodNom";
            this.txtTipoDodNom.Properties.ReadOnly = true;
            this.txtTipoDodNom.Size = new System.Drawing.Size(278, 20);
            this.txtTipoDodNom.TabIndex = 41;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(279, 12);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(46, 13);
            this.labelControl7.TabIndex = 40;
            this.labelControl7.Text = "Tipo Dod:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(108, 153);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(542, 20);
            this.txtDesc.TabIndex = 37;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 156);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Descripcion:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 118);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 13);
            this.labelControl4.TabIndex = 35;
            this.labelControl4.Text = "Sucursal Recibe:";
            // 
            // txtSucEntregaId
            // 
            this.txtSucEntregaId.Location = new System.Drawing.Point(108, 79);
            this.txtSucEntregaId.Name = "txtSucEntregaId";
            this.txtSucEntregaId.Properties.ReadOnly = true;
            this.txtSucEntregaId.Size = new System.Drawing.Size(140, 20);
            this.txtSucEntregaId.TabIndex = 34;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "Sucursal Entrega:";
            // 
            // txtTipoDocId
            // 
            this.txtTipoDocId.Location = new System.Drawing.Point(108, 44);
            this.txtTipoDocId.Name = "txtTipoDocId";
            this.txtTipoDocId.Properties.Mask.EditMask = "f0";
            this.txtTipoDocId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoDocId.Properties.ReadOnly = true;
            this.txtTipoDocId.Size = new System.Drawing.Size(140, 20);
            this.txtTipoDocId.TabIndex = 32;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "Nro. Doc:";
            // 
            // txtTipoDodId
            // 
            this.txtTipoDodId.Location = new System.Drawing.Point(108, 9);
            this.txtTipoDodId.Name = "txtTipoDodId";
            this.txtTipoDodId.Properties.ReadOnly = true;
            this.txtTipoDodId.Size = new System.Drawing.Size(140, 20);
            this.txtTipoDodId.TabIndex = 30;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Tipo Dod:";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.groupControl1.Controls.Add(this.btnAgregarProducto);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.BeforeText;
            this.groupControl1.Location = new System.Drawing.Point(2, 188);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(648, 236);
            this.groupControl1.TabIndex = 48;
            this.groupControl1.Text = "Productos";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregarProducto.Location = new System.Drawing.Point(25, 197);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(110, 30);
            this.btnAgregarProducto.TabIndex = 30;
            this.btnAgregarProducto.Text = "Agregar producto";
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(24, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(619, 187);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Cantidad,
            this.Costo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "p_Articulo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 106;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "p_Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 0;
            this.Descripcion.Width = 533;
            // 
            // Cantidad
            // 
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.FieldName = "p_Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 1;
            this.Cantidad.Width = 122;
            // 
            // Costo
            // 
            this.Costo.Caption = "Costo";
            this.Costo.FieldName = "p_Costo";
            this.Costo.Name = "Costo";
            this.Costo.Visible = true;
            this.Costo.VisibleIndex = 2;
            this.Costo.Width = 166;
            // 
            // txtSucRecibeId
            // 
            this.txtSucRecibeId.Location = new System.Drawing.Point(108, 115);
            this.txtSucRecibeId.Name = "txtSucRecibeId";
            this.txtSucRecibeId.Properties.ReadOnly = true;
            this.txtSucRecibeId.Size = new System.Drawing.Size(140, 20);
            this.txtSucRecibeId.TabIndex = 53;
            // 
            // btnImprimir
            // 
            this.btnImprimir.AppearanceHovered.BackColor = System.Drawing.Color.Black;
            this.btnImprimir.AppearanceHovered.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.AppearanceHovered.Options.UseBackColor = true;
            this.btnImprimir.AppearanceHovered.Options.UseBorderColor = true;
            this.btnImprimir.AppearanceHovered.Options.UseForeColor = true;
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnImprimir.Location = new System.Drawing.Point(12, 436);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 30);
            this.btnImprimir.TabIndex = 54;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // AgregarTraspaso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 478);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtSucRecibeId);
            this.Controls.Add(this.btcCancelar);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtFechaReg);
            this.Controls.Add(this.txtFechaDoc);
            this.Controls.Add(this.txtSucRecibeNom);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtSucEntregaNom);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtTipoDodNom);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtSucEntregaId);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtTipoDocId);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTipoDodId);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarTraspaso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Traspaso";
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaReg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaReg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDoc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucRecibeNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucEntregaNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDodNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucEntregaId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDocId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDodId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSucRecibeId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btcCancelar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit txtFechaReg;
        private DevExpress.XtraEditors.DateEdit txtFechaDoc;
        private DevExpress.XtraEditors.TextEdit txtSucRecibeNom;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtSucEntregaNom;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtTipoDodNom;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSucEntregaId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTipoDocId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTipoDodId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnAgregarProducto;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Costo;
        private DevExpress.XtraEditors.TextEdit txtSucRecibeId;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
    }
}