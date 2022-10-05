namespace WFConsumo.frmGRH.DespachoOrdenParcial
{
    partial class AddEnvio
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
            this.txtTitulo = new DevExpress.XtraEditors.LabelControl();
            this.labelTitulo = new DevExpress.XtraEditors.LabelControl();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTitulo.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtTitulo.Appearance.Options.UseFont = true;
            this.txtTitulo.Location = new System.Drawing.Point(120, 12);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(6, 16);
            this.txtTitulo.TabIndex = 4;
            this.txtTitulo.Text = "-";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.labelTitulo.Appearance.Options.UseFont = true;
            this.labelTitulo.Location = new System.Drawing.Point(12, 12);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(102, 16);
            this.labelTitulo.TabIndex = 3;
            this.labelTitulo.Text = "Nro. Despacho: ";
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Location = new System.Drawing.Point(12, 55);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.Size = new System.Drawing.Size(457, 318);
            this.propertyGridControl1.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(203, 389);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 30);
            this.btnSalir.TabIndex = 68;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // AddEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 433);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.propertyGridControl1);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "AddEnvio";
            this.Text = "Añadir envio";
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl txtTitulo;
        private DevExpress.XtraEditors.LabelControl labelTitulo;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
    }
}