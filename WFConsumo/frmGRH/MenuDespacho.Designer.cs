namespace WFConsumo.frmGRH
{
    partial class MenuDespacho
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
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.tabFormContentContainer1 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage1 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer2 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage2 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer3 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage3 = new DevExpress.XtraBars.TabFormPage();
            this.btnOrdenAbierta = new DevExpress.XtraEditors.SimpleButton();
            this.btnOrdenPendiente = new DevExpress.XtraEditors.SimpleButton();
            this.btnOrdenParcial = new DevExpress.XtraEditors.SimpleButton();
            this.tabFormContentContainer4 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage4 = new DevExpress.XtraBars.TabFormPage();
            this.btnListaCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.tabFormContentContainer5 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage5 = new DevExpress.XtraBars.TabFormPage();
            this.btnOrdenCerrada = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            this.tabFormContentContainer1.SuspendLayout();
            this.tabFormContentContainer2.SuspendLayout();
            this.tabFormContentContainer3.SuspendLayout();
            this.tabFormContentContainer4.SuspendLayout();
            this.tabFormContentContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 429);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = null;
            this.ribbonStatusBar.Size = new System.Drawing.Size(643, 20);
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.tabFormPage1);
            this.tabFormControl1.Pages.Add(this.tabFormPage2);
            this.tabFormControl1.Pages.Add(this.tabFormPage3);
            this.tabFormControl1.Pages.Add(this.tabFormPage4);
            this.tabFormControl1.Pages.Add(this.tabFormPage5);
            this.tabFormControl1.SelectedPage = this.tabFormPage2;
            this.tabFormControl1.Size = new System.Drawing.Size(643, 50);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 1;
            this.tabFormControl1.TabStop = false;
            // 
            // tabFormContentContainer1
            // 
            this.tabFormContentContainer1.Controls.Add(this.btnOrdenAbierta);
            this.tabFormContentContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer1.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer1.Name = "tabFormContentContainer1";
            this.tabFormContentContainer1.Size = new System.Drawing.Size(643, 399);
            this.tabFormContentContainer1.TabIndex = 2;
            // 
            // tabFormPage1
            // 
            this.tabFormPage1.ContentContainer = this.tabFormContentContainer1;
            this.tabFormPage1.Name = "tabFormPage1";
            this.tabFormPage1.Text = "Orden Abierta";
            // 
            // tabFormContentContainer2
            // 
            this.tabFormContentContainer2.Controls.Add(this.btnOrdenPendiente);
            this.tabFormContentContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer2.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer2.Name = "tabFormContentContainer2";
            this.tabFormContentContainer2.Size = new System.Drawing.Size(643, 399);
            this.tabFormContentContainer2.TabIndex = 3;
            // 
            // tabFormPage2
            // 
            this.tabFormPage2.ContentContainer = this.tabFormContentContainer2;
            this.tabFormPage2.Name = "tabFormPage2";
            this.tabFormPage2.Text = "Orden Pendiente";
            // 
            // tabFormContentContainer3
            // 
            this.tabFormContentContainer3.Controls.Add(this.btnOrdenParcial);
            this.tabFormContentContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer3.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer3.Name = "tabFormContentContainer3";
            this.tabFormContentContainer3.Size = new System.Drawing.Size(643, 399);
            this.tabFormContentContainer3.TabIndex = 4;
            // 
            // tabFormPage3
            // 
            this.tabFormPage3.ContentContainer = this.tabFormContentContainer3;
            this.tabFormPage3.Name = "tabFormPage3";
            this.tabFormPage3.Text = "Orden Parcial";
            // 
            // btnOrdenAbierta
            // 
            this.btnOrdenAbierta.Location = new System.Drawing.Point(246, 168);
            this.btnOrdenAbierta.Name = "btnOrdenAbierta";
            this.btnOrdenAbierta.Size = new System.Drawing.Size(152, 69);
            this.btnOrdenAbierta.TabIndex = 0;
            this.btnOrdenAbierta.Text = "Orden Abierta";
            this.btnOrdenAbierta.Click += new System.EventHandler(this.btnOrdenAbierta_Click);
            // 
            // btnOrdenPendiente
            // 
            this.btnOrdenPendiente.Location = new System.Drawing.Point(252, 182);
            this.btnOrdenPendiente.Name = "btnOrdenPendiente";
            this.btnOrdenPendiente.Size = new System.Drawing.Size(152, 69);
            this.btnOrdenPendiente.TabIndex = 1;
            this.btnOrdenPendiente.Text = "Orden Pendiente";
            this.btnOrdenPendiente.Click += new System.EventHandler(this.btnOrdenPendiente_Click);
            // 
            // btnOrdenParcial
            // 
            this.btnOrdenParcial.Location = new System.Drawing.Point(237, 183);
            this.btnOrdenParcial.Name = "btnOrdenParcial";
            this.btnOrdenParcial.Size = new System.Drawing.Size(152, 69);
            this.btnOrdenParcial.TabIndex = 2;
            this.btnOrdenParcial.Text = "Orden Parcial";
            // 
            // tabFormContentContainer4
            // 
            this.tabFormContentContainer4.Controls.Add(this.btnListaCerrar);
            this.tabFormContentContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer4.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer4.Name = "tabFormContentContainer4";
            this.tabFormContentContainer4.Size = new System.Drawing.Size(643, 399);
            this.tabFormContentContainer4.TabIndex = 5;
            // 
            // tabFormPage4
            // 
            this.tabFormPage4.ContentContainer = this.tabFormContentContainer4;
            this.tabFormPage4.Name = "tabFormPage4";
            this.tabFormPage4.Text = "Orden lista para cerrar";
            // 
            // btnListaCerrar
            // 
            this.btnListaCerrar.Location = new System.Drawing.Point(245, 174);
            this.btnListaCerrar.Name = "btnListaCerrar";
            this.btnListaCerrar.Size = new System.Drawing.Size(152, 69);
            this.btnListaCerrar.TabIndex = 2;
            this.btnListaCerrar.Text = "Orden Lista para cerrar";
            // 
            // tabFormContentContainer5
            // 
            this.tabFormContentContainer5.Controls.Add(this.btnOrdenCerrada);
            this.tabFormContentContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer5.Location = new System.Drawing.Point(0, 50);
            this.tabFormContentContainer5.Name = "tabFormContentContainer5";
            this.tabFormContentContainer5.Size = new System.Drawing.Size(643, 399);
            this.tabFormContentContainer5.TabIndex = 6;
            // 
            // tabFormPage5
            // 
            this.tabFormPage5.ContentContainer = this.tabFormContentContainer5;
            this.tabFormPage5.Name = "tabFormPage5";
            this.tabFormPage5.Text = "Orden Cerrada";
            // 
            // btnOrdenCerrada
            // 
            this.btnOrdenCerrada.Location = new System.Drawing.Point(236, 167);
            this.btnOrdenCerrada.Name = "btnOrdenCerrada";
            this.btnOrdenCerrada.Size = new System.Drawing.Size(152, 69);
            this.btnOrdenCerrada.TabIndex = 2;
            this.btnOrdenCerrada.Text = "Orden Cerrada";
            // 
            // MenuDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.tabFormContentContainer2);
            this.Controls.Add(this.tabFormControl1);
            this.Name = "MenuDespacho";
            this.TabFormControl = this.tabFormControl1;
            this.Text = "MenuDespacho";
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            this.tabFormContentContainer1.ResumeLayout(false);
            this.tabFormContentContainer2.ResumeLayout(false);
            this.tabFormContentContainer3.ResumeLayout(false);
            this.tabFormContentContainer4.ResumeLayout(false);
            this.tabFormContentContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormPage tabFormPage1;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer1;
        private DevExpress.XtraEditors.SimpleButton btnOrdenAbierta;
        private DevExpress.XtraBars.TabFormPage tabFormPage2;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer2;
        private DevExpress.XtraEditors.SimpleButton btnOrdenPendiente;
        private DevExpress.XtraBars.TabFormPage tabFormPage3;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer3;
        private DevExpress.XtraEditors.SimpleButton btnOrdenParcial;
        private DevExpress.XtraBars.TabFormPage tabFormPage4;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer4;
        private DevExpress.XtraEditors.SimpleButton btnListaCerrar;
        private DevExpress.XtraBars.TabFormPage tabFormPage5;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer5;
        private DevExpress.XtraEditors.SimpleButton btnOrdenCerrada;
    }
}