namespace WFConsumo
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSucursal = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sincronizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialSincronizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSucursal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(742, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tsSucursal
            // 
            this.tsSucursal.Image = ((System.Drawing.Image)(resources.GetObject("tsSucursal.Image")));
            this.tsSucursal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSucursal.Name = "tsSucursal";
            this.tsSucursal.Size = new System.Drawing.Size(80, 20);
            this.tsSucursal.Text = "Sucursal";
            this.tsSucursal.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsSucursal_DropDownItemClicked);
            this.tsSucursal.Click += new System.EventHandler(this.tsSucursal_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sincronizacionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sincronizacionToolStripMenuItem
            // 
            this.sincronizacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revisionToolStripMenuItem,
            this.sincronizarToolStripMenuItem,
            this.historialSincronizadasToolStripMenuItem});
            this.sincronizacionToolStripMenuItem.Name = "sincronizacionToolStripMenuItem";
            this.sincronizacionToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.sincronizacionToolStripMenuItem.Text = "Sincronizacion";
            // 
            // revisionToolStripMenuItem
            // 
            this.revisionToolStripMenuItem.Name = "revisionToolStripMenuItem";
            this.revisionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.revisionToolStripMenuItem.Text = "Revision";
            this.revisionToolStripMenuItem.Click += new System.EventHandler(this.revisionToolStripMenuItem_Click);
            // 
            // sincronizarToolStripMenuItem
            // 
            this.sincronizarToolStripMenuItem.Name = "sincronizarToolStripMenuItem";
            this.sincronizarToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.sincronizarToolStripMenuItem.Text = "Sincronizar";
            this.sincronizarToolStripMenuItem.Click += new System.EventHandler(this.sincronizarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // historialSincronizadasToolStripMenuItem
            // 
            this.historialSincronizadasToolStripMenuItem.Name = "historialSincronizadasToolStripMenuItem";
            this.historialSincronizadasToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.historialSincronizadasToolStripMenuItem.Text = "Historial Sincronizadas";
            this.historialSincronizadasToolStripMenuItem.Click += new System.EventHandler(this.historialSincronizadasToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 442);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

         #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sincronizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsSucursal;
        private System.Windows.Forms.ToolStripMenuItem historialSincronizadasToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem pDVToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem hasToolStripMenuItem;
    }
}