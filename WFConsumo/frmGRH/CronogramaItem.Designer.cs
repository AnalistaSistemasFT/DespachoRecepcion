namespace WFConsumo.frmGRH
{
    partial class CronogramaItem
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Celda_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Stock_Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Stock_Paquetes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PiezasPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaqPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha_Creacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Antiguedad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CeldaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.Paquete_Plan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumPiezas = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPiezasPend = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPiezasProg = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDespacho = new DevExpress.XtraEditors.TextEdit();
            this.txtItemId = new DevExpress.XtraEditors.TextEdit();
            this.txtPzsPaq = new DevExpress.XtraEditors.TextEdit();
            this.txtItemDesc = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPiezas.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiezasPend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiezasProg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDespacho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPzsPaq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 50);
            this.panel1.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 26);
            this.label1.TabIndex = 80;
            this.label1.Text = "CRONOGRAMA DESPACHO";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 247);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(838, 172);
            this.groupControl2.TabIndex = 82;
            this.groupControl2.Text = "Paquetes Standard";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(834, 150);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Celda_Id,
            this.Stock_Piezas,
            this.Stock_Paquetes,
            this.PiezasPlan,
            this.PaqPlan,
            this.Fecha_Creacion,
            this.Antiguedad});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // Celda_Id
            // 
            this.Celda_Id.Caption = "Celda";
            this.Celda_Id.FieldName = "p_CeldaId";
            this.Celda_Id.Name = "Celda_Id";
            this.Celda_Id.OptionsColumn.AllowEdit = false;
            this.Celda_Id.OptionsColumn.ReadOnly = true;
            this.Celda_Id.Visible = true;
            this.Celda_Id.VisibleIndex = 1;
            this.Celda_Id.Width = 113;
            // 
            // Stock_Piezas
            // 
            this.Stock_Piezas.Caption = "Stock Piezas";
            this.Stock_Piezas.FieldName = "p_StockPiezas";
            this.Stock_Piezas.Name = "Stock_Piezas";
            this.Stock_Piezas.OptionsColumn.AllowEdit = false;
            this.Stock_Piezas.OptionsColumn.ReadOnly = true;
            this.Stock_Piezas.Visible = true;
            this.Stock_Piezas.VisibleIndex = 2;
            this.Stock_Piezas.Width = 128;
            // 
            // Stock_Paquetes
            // 
            this.Stock_Paquetes.Caption = "Stock Paquetes";
            this.Stock_Paquetes.FieldName = "p_StockPaquetes";
            this.Stock_Paquetes.Name = "Stock_Paquetes";
            this.Stock_Paquetes.OptionsColumn.AllowEdit = false;
            this.Stock_Paquetes.OptionsColumn.ReadOnly = true;
            this.Stock_Paquetes.Visible = true;
            this.Stock_Paquetes.VisibleIndex = 3;
            this.Stock_Paquetes.Width = 133;
            // 
            // PiezasPlan
            // 
            this.PiezasPlan.Caption = "Piezas Plan";
            this.PiezasPlan.FieldName = "p_PlanPiezas";
            this.PiezasPlan.Name = "PiezasPlan";
            this.PiezasPlan.Visible = true;
            this.PiezasPlan.VisibleIndex = 4;
            this.PiezasPlan.Width = 139;
            // 
            // PaqPlan
            // 
            this.PaqPlan.Caption = "Paquete Plan";
            this.PaqPlan.FieldName = "p_PlanPaquetes";
            this.PaqPlan.Name = "PaqPlan";
            this.PaqPlan.Visible = true;
            this.PaqPlan.VisibleIndex = 5;
            this.PaqPlan.Width = 151;
            // 
            // Fecha_Creacion
            // 
            this.Fecha_Creacion.Caption = "Fecha Creacion";
            this.Fecha_Creacion.FieldName = "p_Fecha";
            this.Fecha_Creacion.Name = "Fecha_Creacion";
            this.Fecha_Creacion.OptionsColumn.AllowEdit = false;
            this.Fecha_Creacion.OptionsColumn.ReadOnly = true;
            this.Fecha_Creacion.Visible = true;
            this.Fecha_Creacion.VisibleIndex = 6;
            this.Fecha_Creacion.Width = 113;
            // 
            // Antiguedad
            // 
            this.Antiguedad.Caption = "Antiguedad (Dias)";
            this.Antiguedad.FieldName = "p_Antiguedad";
            this.Antiguedad.Name = "Antiguedad";
            this.Antiguedad.OptionsColumn.AllowEdit = false;
            this.Antiguedad.OptionsColumn.ReadOnly = true;
            this.Antiguedad.Visible = true;
            this.Antiguedad.VisibleIndex = 7;
            this.Antiguedad.Width = 145;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Location = new System.Drawing.Point(12, 425);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(838, 149);
            this.groupControl3.TabIndex = 83;
            this.groupControl3.Text = "Sobrantes";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 20);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(834, 127);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CeldaId,
            this.Paquete,
            this.Piezas});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView2_SelectionChanged);
            // 
            // CeldaId
            // 
            this.CeldaId.Caption = "Celda";
            this.CeldaId.FieldName = "p_CeldaId";
            this.CeldaId.Name = "CeldaId";
            this.CeldaId.OptionsColumn.AllowEdit = false;
            this.CeldaId.OptionsColumn.ReadOnly = true;
            this.CeldaId.Visible = true;
            this.CeldaId.VisibleIndex = 1;
            this.CeldaId.Width = 203;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_Paquete";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 2;
            this.Paquete.Width = 437;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "p_Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.OptionsColumn.AllowEdit = false;
            this.Piezas.OptionsColumn.ReadOnly = true;
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 3;
            this.Piezas.Width = 262;
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.Appearance.Options.UseBorderColor = true;
            this.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSalir.Location = new System.Drawing.Point(732, 594);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 30);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Paquete_Plan
            // 
            this.Paquete_Plan.Caption = "Paquete Plan";
            this.Paquete_Plan.Name = "Paquete_Plan";
            this.Paquete_Plan.OptionsColumn.ReadOnly = true;
            this.Paquete_Plan.Visible = true;
            this.Paquete_Plan.VisibleIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.Options.UseBorderColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(603, 594);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(123, 30);
            this.btnAceptar.TabIndex = 84;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Despacho:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Item:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(593, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(78, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Piezas/Paquete:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumPiezas);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Location = new System.Drawing.Point(23, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden";
            // 
            // txtNumPiezas
            // 
            this.txtNumPiezas.Location = new System.Drawing.Point(155, 26);
            this.txtNumPiezas.Name = "txtNumPiezas";
            this.txtNumPiezas.Size = new System.Drawing.Size(100, 20);
            this.txtNumPiezas.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 29);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(128, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "N° Piezas pedidas (orden):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPiezasPend);
            this.groupBox2.Controls.Add(this.labelControl6);
            this.groupBox2.Controls.Add(this.txtPiezasProg);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(321, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 61);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programación";
            // 
            // txtPiezasPend
            // 
            this.txtPiezasPend.Location = new System.Drawing.Point(371, 26);
            this.txtPiezasPend.Name = "txtPiezasPend";
            this.txtPiezasPend.Size = new System.Drawing.Size(100, 20);
            this.txtPiezasPend.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(275, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(90, 13);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Piezas pendientes:";
            // 
            // txtPiezasProg
            // 
            this.txtPiezasProg.Location = new System.Drawing.Point(132, 26);
            this.txtPiezasProg.Name = "txtPiezasProg";
            this.txtPiezasProg.Size = new System.Drawing.Size(100, 20);
            this.txtPiezasProg.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(26, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(100, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Piezas programadas:";
            // 
            // txtDespacho
            // 
            this.txtDespacho.Location = new System.Drawing.Point(80, 30);
            this.txtDespacho.Name = "txtDespacho";
            this.txtDespacho.Size = new System.Drawing.Size(100, 20);
            this.txtDespacho.TabIndex = 6;
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(80, 66);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 7;
            // 
            // txtPzsPaq
            // 
            this.txtPzsPaq.Location = new System.Drawing.Point(692, 66);
            this.txtPzsPaq.Name = "txtPzsPaq";
            this.txtPzsPaq.Size = new System.Drawing.Size(100, 20);
            this.txtPzsPaq.TabIndex = 8;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Location = new System.Drawing.Point(186, 66);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(313, 20);
            this.txtItemDesc.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtItemDesc);
            this.groupControl1.Controls.Add(this.txtPzsPaq);
            this.groupControl1.Controls.Add(this.txtItemId);
            this.groupControl1.Controls.Add(this.txtDespacho);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 65);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(838, 176);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Programación de despacho";
            // 
            // CronogramaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 629);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CronogramaItem";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cronograma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPiezas.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiezasPend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiezasProg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDespacho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPzsPaq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraGrid.Columns.GridColumn Celda_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Stock_Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Stock_Paquetes;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha_Creacion;
        private DevExpress.XtraGrid.Columns.GridColumn Antiguedad;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete_Plan;
        private DevExpress.XtraGrid.Columns.GridColumn CeldaId;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtNumPiezas;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtPiezasPend;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPiezasProg;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtDespacho;
        private DevExpress.XtraEditors.TextEdit txtItemId;
        private DevExpress.XtraEditors.TextEdit txtPzsPaq;
        private DevExpress.XtraEditors.TextEdit txtItemDesc;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn PiezasPlan;
        private DevExpress.XtraGrid.Columns.GridColumn PaqPlan;
    }
}