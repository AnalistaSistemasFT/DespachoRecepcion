namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    partial class BuscarDespacho
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
            this.comBoxBuscarPor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtBusqueda = new DevExpress.XtraEditors.TextEdit();
            this.labelBuscarPor = new DevExpress.XtraEditors.LabelControl();
            this.labelBusqueda = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkCompleta = new DevExpress.XtraEditors.CheckEdit();
            this.checkInicio = new DevExpress.XtraEditors.CheckEdit();
            this.datePick = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxBuscarPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkCompleta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePick.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePick.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comBoxBuscarPor
            // 
            this.comBoxBuscarPor.Location = new System.Drawing.Point(84, 12);
            this.comBoxBuscarPor.Name = "comBoxBuscarPor";
            this.comBoxBuscarPor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxBuscarPor.Size = new System.Drawing.Size(153, 20);
            this.comBoxBuscarPor.TabIndex = 0;
            this.comBoxBuscarPor.SelectedIndexChanged += new System.EventHandler(this.comBoxBuscarPor_SelectedIndexChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(84, 48);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(153, 20);
            this.txtBusqueda.TabIndex = 1;
            // 
            // labelBuscarPor
            // 
            this.labelBuscarPor.Location = new System.Drawing.Point(9, 15);
            this.labelBuscarPor.Name = "labelBuscarPor";
            this.labelBuscarPor.Size = new System.Drawing.Size(58, 13);
            this.labelBuscarPor.TabIndex = 2;
            this.labelBuscarPor.Text = "Buscar por: ";
            // 
            // labelBusqueda
            // 
            this.labelBusqueda.Location = new System.Drawing.Point(9, 51);
            this.labelBusqueda.Name = "labelBusqueda";
            this.labelBusqueda.Size = new System.Drawing.Size(54, 13);
            this.labelBusqueda.TabIndex = 3;
            this.labelBusqueda.Text = "Busqueda: ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(9, 209);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(228, 26);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(9, 261);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(228, 26);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkCompleta);
            this.groupControl1.Controls.Add(this.checkInicio);
            this.groupControl1.Location = new System.Drawing.Point(9, 86);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(228, 117);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Modo";
            // 
            // checkCompleta
            // 
            this.checkCompleta.EditValue = true;
            this.checkCompleta.Location = new System.Drawing.Point(56, 80);
            this.checkCompleta.Name = "checkCompleta";
            this.checkCompleta.Properties.Caption = "Palabra completa";
            this.checkCompleta.Size = new System.Drawing.Size(105, 19);
            this.checkCompleta.TabIndex = 1;
            this.checkCompleta.CheckedChanged += new System.EventHandler(this.checkCompleta_CheckedChanged);
            // 
            // checkInicio
            // 
            this.checkInicio.Location = new System.Drawing.Point(56, 37);
            this.checkInicio.Name = "checkInicio";
            this.checkInicio.Properties.Caption = "Palabra inicio";
            this.checkInicio.Size = new System.Drawing.Size(105, 19);
            this.checkInicio.TabIndex = 0;
            this.checkInicio.CheckedChanged += new System.EventHandler(this.checkInicio_CheckedChanged);
            // 
            // datePick
            // 
            this.datePick.EditValue = null;
            this.datePick.Location = new System.Drawing.Point(84, 48);
            this.datePick.Name = "datePick";
            this.datePick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePick.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePick.Size = new System.Drawing.Size(153, 20);
            this.datePick.TabIndex = 2;
            this.datePick.Visible = false;
            // 
            // BuscarDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 299);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.labelBusqueda);
            this.Controls.Add(this.labelBuscarPor);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.comBoxBuscarPor);
            this.Controls.Add(this.datePick);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Despacho";
            ((System.ComponentModel.ISupportInitialize)(this.comBoxBuscarPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkCompleta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePick.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePick.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comBoxBuscarPor;
        private DevExpress.XtraEditors.TextEdit txtBusqueda;
        private DevExpress.XtraEditors.LabelControl labelBuscarPor;
        private DevExpress.XtraEditors.LabelControl labelBusqueda;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkCompleta;
        private DevExpress.XtraEditors.CheckEdit checkInicio;
        private DevExpress.XtraEditors.DateEdit datePick;
    }
}