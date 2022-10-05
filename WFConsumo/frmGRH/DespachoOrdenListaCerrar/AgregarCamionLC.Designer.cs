namespace WFConsumo.frmGRH.DespachoOrdenListaCerrar
{
    partial class AgregarCamionLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarCamionLC));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlacaNum = new DevExpress.XtraEditors.TextEdit();
            this.txtMarca = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtPlacaLetra = new DevExpress.XtraEditors.TextEdit();
            this.txtCapacidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlacaNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlacaLetra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacidad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Agregar Camion";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(56, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Placa:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(51, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Marca:";
            // 
            // txtPlacaNum
            // 
            this.txtPlacaNum.Location = new System.Drawing.Point(111, 57);
            this.txtPlacaNum.Name = "txtPlacaNum";
            this.txtPlacaNum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPlacaNum.Properties.Appearance.Options.UseFont = true;
            this.txtPlacaNum.Properties.Mask.EditMask = "d";
            this.txtPlacaNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPlacaNum.Properties.MaxLength = 4;
            this.txtPlacaNum.Size = new System.Drawing.Size(99, 22);
            this.txtPlacaNum.TabIndex = 3;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(111, 95);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMarca.Properties.Appearance.Options.UseFont = true;
            this.txtMarca.Size = new System.Drawing.Size(207, 22);
            this.txtMarca.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(167, 202);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Aceptar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(268, 202);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(95, 23);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtPlacaLetra
            // 
            this.txtPlacaLetra.Location = new System.Drawing.Point(219, 57);
            this.txtPlacaLetra.Name = "txtPlacaLetra";
            this.txtPlacaLetra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPlacaLetra.Properties.Appearance.Options.UseFont = true;
            this.txtPlacaLetra.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlacaLetra.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtPlacaLetra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPlacaLetra.Properties.MaxLength = 4;
            this.txtPlacaLetra.Size = new System.Drawing.Size(99, 22);
            this.txtPlacaLetra.TabIndex = 7;
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(111, 133);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCapacidad.Properties.Appearance.Options.UseFont = true;
            this.txtCapacidad.Properties.Mask.EditMask = "\\d+";
            this.txtCapacidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCapacidad.Size = new System.Drawing.Size(177, 22);
            this.txtCapacidad.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(27, 136);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 16);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Capacidad:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(294, 136);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 16);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Kgs.";
            // 
            // AgregarCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 237);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtPlacaLetra);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtPlacaNum);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Camion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarCamion_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtPlacaNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlacaLetra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapacidad.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPlacaNum;
        private DevExpress.XtraEditors.TextEdit txtMarca;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtPlacaLetra;
        private DevExpress.XtraEditors.TextEdit txtCapacidad;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}