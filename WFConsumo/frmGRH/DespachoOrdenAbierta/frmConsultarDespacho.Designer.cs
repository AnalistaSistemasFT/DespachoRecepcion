namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    partial class frmConsultarDespacho
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
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.txtObs = new DevExpress.XtraEditors.MemoEdit();
            this.txtNroTraspaso = new DevExpress.XtraEditors.TextEdit();
            this.labelNroTraspaso = new DevExpress.XtraEditors.LabelControl();
            this.txtNroOrden = new DevExpress.XtraEditors.TextEdit();
            this.labelNroOrden = new DevExpress.XtraEditors.LabelControl();
            this.labelProgramacion = new DevExpress.XtraEditors.LabelControl();
            this.labelSucursal = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxSucursal = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelCliente = new DevExpress.XtraEditors.LabelControl();
            this.labelNroDespacho = new DevExpress.XtraEditors.LabelControl();
            this.txtNroDespacho = new DevExpress.XtraEditors.TextEdit();
            this.labelTipoDespacho = new DevExpress.XtraEditors.LabelControl();
            this.labelFecha = new DevExpress.XtraEditors.LabelControl();
            this.pickerFecha = new DevExpress.XtraEditors.DateEdit();
            this.groupLogistica = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxPlaca = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCamion = new DevExpress.XtraEditors.TextEdit();
            this.txtCI = new DevExpress.XtraEditors.TextEdit();
            this.labelCamion = new DevExpress.XtraEditors.LabelControl();
            this.labelChofer = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxChofer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnAgregarChofer = new DevExpress.XtraEditors.SimpleButton();
            this.labelPlaca = new DevExpress.XtraEditors.LabelControl();
            this.labelCI = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoDespacho = new DevExpress.XtraEditors.TextEdit();
            this.txtProgramacion = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroTraspaso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDespacho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLogistica)).BeginInit();
            this.groupLogistica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPlaca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChofer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDespacho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(721, 410);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 30);
            this.btnSalir.TabIndex = 61;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(12, 306);
            this.txtObs.Name = "txtObs";
            this.txtObs.Properties.ReadOnly = true;
            this.txtObs.Size = new System.Drawing.Size(785, 74);
            this.txtObs.TabIndex = 58;
            // 
            // txtNroTraspaso
            // 
            this.txtNroTraspaso.Location = new System.Drawing.Point(606, 218);
            this.txtNroTraspaso.Name = "txtNroTraspaso";
            this.txtNroTraspaso.Properties.ReadOnly = true;
            this.txtNroTraspaso.Size = new System.Drawing.Size(191, 20);
            this.txtNroTraspaso.TabIndex = 57;
            // 
            // labelNroTraspaso
            // 
            this.labelNroTraspaso.Location = new System.Drawing.Point(526, 221);
            this.labelNroTraspaso.Name = "labelNroTraspaso";
            this.labelNroTraspaso.Size = new System.Drawing.Size(75, 13);
            this.labelNroTraspaso.TabIndex = 56;
            this.labelNroTraspaso.Text = "Nro. Traspaso: ";
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.Location = new System.Drawing.Point(606, 187);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.Properties.ReadOnly = true;
            this.txtNroOrden.Size = new System.Drawing.Size(191, 20);
            this.txtNroOrden.TabIndex = 55;
            // 
            // labelNroOrden
            // 
            this.labelNroOrden.Location = new System.Drawing.Point(526, 190);
            this.labelNroOrden.Name = "labelNroOrden";
            this.labelNroOrden.Size = new System.Drawing.Size(58, 13);
            this.labelNroOrden.TabIndex = 54;
            this.labelNroOrden.Text = "Nro. Orden:";
            // 
            // labelProgramacion
            // 
            this.labelProgramacion.Location = new System.Drawing.Point(12, 260);
            this.labelProgramacion.Name = "labelProgramacion";
            this.labelProgramacion.Size = new System.Drawing.Size(65, 13);
            this.labelProgramacion.TabIndex = 53;
            this.labelProgramacion.Text = "Programación";
            // 
            // labelSucursal
            // 
            this.labelSucursal.Location = new System.Drawing.Point(12, 194);
            this.labelSucursal.Name = "labelSucursal";
            this.labelSucursal.Size = new System.Drawing.Size(44, 13);
            this.labelSucursal.TabIndex = 51;
            this.labelSucursal.Text = "Sucursal:";
            // 
            // comboBoxSucursal
            // 
            this.comboBoxSucursal.Location = new System.Drawing.Point(98, 190);
            this.comboBoxSucursal.Name = "comboBoxSucursal";
            this.comboBoxSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxSucursal.Properties.HideSelection = false;
            this.comboBoxSucursal.Properties.ReadOnly = true;
            this.comboBoxSucursal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxSucursal.Size = new System.Drawing.Size(220, 20);
            this.comboBoxSucursal.TabIndex = 50;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(98, 222);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Properties.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(220, 20);
            this.txtCliente.TabIndex = 49;
            this.txtCliente.Visible = false;
            // 
            // labelCliente
            // 
            this.labelCliente.Location = new System.Drawing.Point(12, 225);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(37, 13);
            this.labelCliente.TabIndex = 48;
            this.labelCliente.Text = "Cliente:";
            this.labelCliente.Visible = false;
            // 
            // labelNroDespacho
            // 
            this.labelNroDespacho.Location = new System.Drawing.Point(14, 23);
            this.labelNroDespacho.Name = "labelNroDespacho";
            this.labelNroDespacho.Size = new System.Drawing.Size(78, 13);
            this.labelNroDespacho.TabIndex = 41;
            this.labelNroDespacho.Text = "Nro. Despacho: ";
            // 
            // txtNroDespacho
            // 
            this.txtNroDespacho.Location = new System.Drawing.Point(98, 20);
            this.txtNroDespacho.Name = "txtNroDespacho";
            this.txtNroDespacho.Properties.ReadOnly = true;
            this.txtNroDespacho.Size = new System.Drawing.Size(148, 20);
            this.txtNroDespacho.TabIndex = 42;
            // 
            // labelTipoDespacho
            // 
            this.labelTipoDespacho.Location = new System.Drawing.Point(313, 23);
            this.labelTipoDespacho.Name = "labelTipoDespacho";
            this.labelTipoDespacho.Size = new System.Drawing.Size(70, 13);
            this.labelTipoDespacho.TabIndex = 47;
            this.labelTipoDespacho.Text = "Tipo Despacho";
            // 
            // labelFecha
            // 
            this.labelFecha.Location = new System.Drawing.Point(606, 23);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(36, 13);
            this.labelFecha.TabIndex = 43;
            this.labelFecha.Text = "Fecha: ";
            // 
            // pickerFecha
            // 
            this.pickerFecha.EditValue = null;
            this.pickerFecha.Location = new System.Drawing.Point(648, 20);
            this.pickerFecha.Name = "pickerFecha";
            this.pickerFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Properties.ReadOnly = true;
            this.pickerFecha.Size = new System.Drawing.Size(149, 20);
            this.pickerFecha.TabIndex = 44;
            // 
            // groupLogistica
            // 
            this.groupLogistica.Controls.Add(this.simpleButton1);
            this.groupLogistica.Controls.Add(this.comboBoxPlaca);
            this.groupLogistica.Controls.Add(this.txtCamion);
            this.groupLogistica.Controls.Add(this.txtCI);
            this.groupLogistica.Controls.Add(this.labelCamion);
            this.groupLogistica.Controls.Add(this.labelChofer);
            this.groupLogistica.Controls.Add(this.comboBoxChofer);
            this.groupLogistica.Controls.Add(this.btnAgregarChofer);
            this.groupLogistica.Controls.Add(this.labelPlaca);
            this.groupLogistica.Controls.Add(this.labelCI);
            this.groupLogistica.Location = new System.Drawing.Point(12, 46);
            this.groupLogistica.Name = "groupLogistica";
            this.groupLogistica.Size = new System.Drawing.Size(785, 117);
            this.groupLogistica.TabIndex = 45;
            this.groupLogistica.Text = "Logística";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(275, 72);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(31, 20);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "+";
            // 
            // comboBoxPlaca
            // 
            this.comboBoxPlaca.Location = new System.Drawing.Point(86, 72);
            this.comboBoxPlaca.Name = "comboBoxPlaca";
            this.comboBoxPlaca.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxPlaca.Properties.HideSelection = false;
            this.comboBoxPlaca.Properties.ReadOnly = true;
            this.comboBoxPlaca.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxPlaca.Size = new System.Drawing.Size(183, 20);
            this.comboBoxPlaca.TabIndex = 8;
            // 
            // txtCamion
            // 
            this.txtCamion.Location = new System.Drawing.Point(514, 72);
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Properties.ReadOnly = true;
            this.txtCamion.Size = new System.Drawing.Size(220, 20);
            this.txtCamion.TabIndex = 5;
            // 
            // txtCI
            // 
            this.txtCI.Location = new System.Drawing.Point(514, 34);
            this.txtCI.Name = "txtCI";
            this.txtCI.Properties.ReadOnly = true;
            this.txtCI.Size = new System.Drawing.Size(220, 20);
            this.txtCI.TabIndex = 4;
            // 
            // labelCamion
            // 
            this.labelCamion.Location = new System.Drawing.Point(440, 75);
            this.labelCamion.Name = "labelCamion";
            this.labelCamion.Size = new System.Drawing.Size(42, 13);
            this.labelCamion.TabIndex = 3;
            this.labelCamion.Text = "Camion: ";
            // 
            // labelChofer
            // 
            this.labelChofer.Location = new System.Drawing.Point(33, 37);
            this.labelChofer.Name = "labelChofer";
            this.labelChofer.Size = new System.Drawing.Size(40, 13);
            this.labelChofer.TabIndex = 2;
            this.labelChofer.Text = "Chofer: ";
            // 
            // comboBoxChofer
            // 
            this.comboBoxChofer.Location = new System.Drawing.Point(86, 34);
            this.comboBoxChofer.Name = "comboBoxChofer";
            this.comboBoxChofer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChofer.Properties.ReadOnly = true;
            this.comboBoxChofer.Size = new System.Drawing.Size(183, 20);
            this.comboBoxChofer.TabIndex = 11;
            // 
            // btnAgregarChofer
            // 
            this.btnAgregarChofer.Location = new System.Drawing.Point(275, 34);
            this.btnAgregarChofer.Name = "btnAgregarChofer";
            this.btnAgregarChofer.Size = new System.Drawing.Size(31, 20);
            this.btnAgregarChofer.TabIndex = 10;
            this.btnAgregarChofer.Text = " + ";
            // 
            // labelPlaca
            // 
            this.labelPlaca.Location = new System.Drawing.Point(41, 75);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(32, 13);
            this.labelPlaca.TabIndex = 1;
            this.labelPlaca.Text = "Placa: ";
            // 
            // labelCI
            // 
            this.labelCI.Location = new System.Drawing.Point(459, 37);
            this.labelCI.Name = "labelCI";
            this.labelCI.Size = new System.Drawing.Size(23, 13);
            this.labelCI.TabIndex = 0;
            this.labelCI.Text = "C.I.:";
            // 
            // txtTipoDespacho
            // 
            this.txtTipoDespacho.Location = new System.Drawing.Point(389, 20);
            this.txtTipoDespacho.Name = "txtTipoDespacho";
            this.txtTipoDespacho.Properties.ReadOnly = true;
            this.txtTipoDespacho.Size = new System.Drawing.Size(148, 20);
            this.txtTipoDespacho.TabIndex = 62;
            // 
            // txtProgramacion
            // 
            this.txtProgramacion.Location = new System.Drawing.Point(98, 257);
            this.txtProgramacion.Name = "txtProgramacion";
            this.txtProgramacion.Properties.ReadOnly = true;
            this.txtProgramacion.Size = new System.Drawing.Size(220, 20);
            this.txtProgramacion.TabIndex = 63;
            // 
            // frmConsultarDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 452);
            this.Controls.Add(this.txtProgramacion);
            this.Controls.Add(this.txtTipoDespacho);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.txtNroTraspaso);
            this.Controls.Add(this.labelNroTraspaso);
            this.Controls.Add(this.txtNroOrden);
            this.Controls.Add(this.labelNroOrden);
            this.Controls.Add(this.labelProgramacion);
            this.Controls.Add(this.labelSucursal);
            this.Controls.Add(this.comboBoxSucursal);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.labelNroDespacho);
            this.Controls.Add(this.txtNroDespacho);
            this.Controls.Add(this.labelTipoDespacho);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.pickerFecha);
            this.Controls.Add(this.groupLogistica);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "frmConsultarDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar despacho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultarDespacho_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtObs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroTraspaso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDespacho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLogistica)).EndInit();
            this.groupLogistica.ResumeLayout(false);
            this.groupLogistica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPlaca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChofer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoDespacho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.MemoEdit txtObs;
        private DevExpress.XtraEditors.TextEdit txtNroTraspaso;
        private DevExpress.XtraEditors.LabelControl labelNroTraspaso;
        private DevExpress.XtraEditors.TextEdit txtNroOrden;
        private DevExpress.XtraEditors.LabelControl labelNroOrden;
        private DevExpress.XtraEditors.LabelControl labelProgramacion;
        private DevExpress.XtraEditors.LabelControl labelSucursal;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxSucursal;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.LabelControl labelCliente;
        private DevExpress.XtraEditors.LabelControl labelNroDespacho;
        private DevExpress.XtraEditors.TextEdit txtNroDespacho;
        private DevExpress.XtraEditors.LabelControl labelTipoDespacho;
        private DevExpress.XtraEditors.LabelControl labelFecha;
        private DevExpress.XtraEditors.DateEdit pickerFecha;
        private DevExpress.XtraEditors.GroupControl groupLogistica;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxPlaca;
        private DevExpress.XtraEditors.TextEdit txtCamion;
        private DevExpress.XtraEditors.TextEdit txtCI;
        private DevExpress.XtraEditors.LabelControl labelCamion;
        private DevExpress.XtraEditors.LabelControl labelChofer;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxChofer;
        private DevExpress.XtraEditors.SimpleButton btnAgregarChofer;
        private DevExpress.XtraEditors.LabelControl labelPlaca;
        private DevExpress.XtraEditors.LabelControl labelCI;
        private DevExpress.XtraEditors.TextEdit txtTipoDespacho;
        private DevExpress.XtraEditors.TextEdit txtProgramacion;
    }
}