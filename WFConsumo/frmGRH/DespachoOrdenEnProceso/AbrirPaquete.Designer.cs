namespace WFConsumo.frmGRH.DespachoOrdenEnProceso
{
    partial class AbrirPaquete
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
            this.labelTituCod = new DevExpress.XtraEditors.LabelControl();
            this.labelCodigo = new DevExpress.XtraEditors.LabelControl();
            this.txtCantRetirar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelCantPaq = new DevExpress.XtraEditors.LabelControl();
            this.labelSaldoAlm = new DevExpress.XtraEditors.LabelControl();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelDesp = new DevExpress.XtraEditors.LabelControl();
            this.labelTituloDesp = new DevExpress.XtraEditors.LabelControl();
            this.labelPesoPaq = new DevExpress.XtraEditors.LabelControl();
            this.labelPesoPaqTi = new DevExpress.XtraEditors.LabelControl();
            this.labelPsoCrg = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantRetirar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTituCod
            // 
            this.labelTituCod.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelTituCod.Appearance.Options.UseFont = true;
            this.labelTituCod.Location = new System.Drawing.Point(324, 12);
            this.labelTituCod.Name = "labelTituCod";
            this.labelTituCod.Size = new System.Drawing.Size(60, 18);
            this.labelTituCod.TabIndex = 0;
            this.labelTituCod.Text = "Codigo: ";
            // 
            // labelCodigo
            // 
            this.labelCodigo.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelCodigo.Appearance.Options.UseFont = true;
            this.labelCodigo.Location = new System.Drawing.Point(390, 12);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(6, 18);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "-";
            // 
            // txtCantRetirar
            // 
            this.txtCantRetirar.Location = new System.Drawing.Point(12, 161);
            this.txtCantRetirar.Name = "txtCantRetirar";
            this.txtCantRetirar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCantRetirar.Properties.Appearance.Options.UseFont = true;
            this.txtCantRetirar.Size = new System.Drawing.Size(147, 20);
            this.txtCantRetirar.TabIndex = 2;
            this.txtCantRetirar.TextChanged += new System.EventHandler(this.txtCantRetirar_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Piezas en el paquete";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(147, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Cantidad de piezas a retirar";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(381, 141);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(95, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Saldo en almacen";
            // 
            // labelCantPaq
            // 
            this.labelCantPaq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelCantPaq.Appearance.Options.UseFont = true;
            this.labelCantPaq.Location = new System.Drawing.Point(12, 100);
            this.labelCantPaq.Name = "labelCantPaq";
            this.labelCantPaq.Size = new System.Drawing.Size(4, 14);
            this.labelCantPaq.TabIndex = 6;
            this.labelCantPaq.Text = "-";
            // 
            // labelSaldoAlm
            // 
            this.labelSaldoAlm.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelSaldoAlm.Appearance.Options.UseFont = true;
            this.labelSaldoAlm.Location = new System.Drawing.Point(381, 164);
            this.labelSaldoAlm.Name = "labelSaldoAlm";
            this.labelSaldoAlm.Size = new System.Drawing.Size(5, 14);
            this.labelSaldoAlm.TabIndex = 7;
            this.labelSaldoAlm.Text = "-";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(297, 222);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 40);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(403, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelDesp
            // 
            this.labelDesp.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelDesp.Appearance.Options.UseFont = true;
            this.labelDesp.Location = new System.Drawing.Point(88, 12);
            this.labelDesp.Name = "labelDesp";
            this.labelDesp.Size = new System.Drawing.Size(6, 18);
            this.labelDesp.TabIndex = 11;
            this.labelDesp.Text = "-";
            // 
            // labelTituloDesp
            // 
            this.labelTituloDesp.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelTituloDesp.Appearance.Options.UseFont = true;
            this.labelTituloDesp.Location = new System.Drawing.Point(12, 12);
            this.labelTituloDesp.Name = "labelTituloDesp";
            this.labelTituloDesp.Size = new System.Drawing.Size(70, 18);
            this.labelTituloDesp.TabIndex = 10;
            this.labelTituloDesp.Text = "Paquete: ";
            // 
            // labelPesoPaq
            // 
            this.labelPesoPaq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelPesoPaq.Appearance.Options.UseFont = true;
            this.labelPesoPaq.Location = new System.Drawing.Point(220, 100);
            this.labelPesoPaq.MaximumSize = new System.Drawing.Size(100, 0);
            this.labelPesoPaq.Name = "labelPesoPaq";
            this.labelPesoPaq.Size = new System.Drawing.Size(4, 14);
            this.labelPesoPaq.TabIndex = 13;
            this.labelPesoPaq.Text = "-";
            // 
            // labelPesoPaqTi
            // 
            this.labelPesoPaqTi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelPesoPaqTi.Appearance.Options.UseFont = true;
            this.labelPesoPaqTi.Location = new System.Drawing.Point(220, 77);
            this.labelPesoPaqTi.Name = "labelPesoPaqTi";
            this.labelPesoPaqTi.Size = new System.Drawing.Size(96, 14);
            this.labelPesoPaqTi.TabIndex = 12;
            this.labelPesoPaqTi.Text = "Peso del paquete";
            // 
            // labelPsoCrg
            // 
            this.labelPsoCrg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelPsoCrg.Appearance.Options.UseFont = true;
            this.labelPsoCrg.Location = new System.Drawing.Point(220, 164);
            this.labelPsoCrg.MaximumSize = new System.Drawing.Size(100, 0);
            this.labelPsoCrg.Name = "labelPsoCrg";
            this.labelPsoCrg.Size = new System.Drawing.Size(5, 14);
            this.labelPsoCrg.TabIndex = 15;
            this.labelPsoCrg.Text = "-";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(220, 141);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Peso de carga";
            // 
            // AbrirPaquete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 274);
            this.Controls.Add(this.labelPsoCrg);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelPesoPaq);
            this.Controls.Add(this.labelPesoPaqTi);
            this.Controls.Add(this.labelDesp);
            this.Controls.Add(this.labelTituloDesp);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelSaldoAlm);
            this.Controls.Add(this.labelCantPaq);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCantRetirar);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.labelTituCod);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "AbrirPaquete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrir paquete";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbrirPaquete_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtCantRetirar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelTituCod;
        private DevExpress.XtraEditors.LabelControl labelCodigo;
        private DevExpress.XtraEditors.TextEdit txtCantRetirar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelCantPaq;
        private DevExpress.XtraEditors.LabelControl labelSaldoAlm;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelDesp;
        private DevExpress.XtraEditors.LabelControl labelTituloDesp;
        private DevExpress.XtraEditors.LabelControl labelPesoPaq;
        private DevExpress.XtraEditors.LabelControl labelPesoPaqTi;
        private DevExpress.XtraEditors.LabelControl labelPsoCrg;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}