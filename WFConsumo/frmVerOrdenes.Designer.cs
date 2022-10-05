namespace WFConsumo
{
    partial class frmVerOrdenes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private static frmVerOrdenes aForm = null;
        //public static frmVerOrdenes Instance(int sucursal)
        //{
        //    if (aForm == null)
        //    {
        //        aForm = new frmVerOrdenes(sucursal);
        //    }
        //    return aForm;
        //}
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
            //aForm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerOrdenes));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFilas = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRevisar = new System.Windows.Forms.ToolStripButton();
            this.tsbEsDeCliente = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOrdenes = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpConsumidos = new System.Windows.Forms.TabPage();
            this.dgvConsumidos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpProducidos = new System.Windows.Forms.TabPage();
            this.dgvProducidos = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpConsumidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpProducidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(656, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFilas
            // 
            this.lblFilas.Name = "lblFilas";
            this.lblFilas.Size = new System.Drawing.Size(118, 17);
            this.lblFilas.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRevisar,
            this.tsbEsDeCliente});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(656, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbRevisar
            // 
            this.tsbRevisar.Image = ((System.Drawing.Image)(resources.GetObject("tsbRevisar.Image")));
            this.tsbRevisar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRevisar.Name = "tsbRevisar";
            this.tsbRevisar.Size = new System.Drawing.Size(64, 22);
            this.tsbRevisar.Text = "Revisar";
            this.tsbRevisar.Click += new System.EventHandler(this.tsbRevisar_Click);
            // 
            // tsbEsDeCliente
            // 
            this.tsbEsDeCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbEsDeCliente.Image")));
            this.tsbEsDeCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEsDeCliente.Name = "tsbEsDeCliente";
            this.tsbEsDeCliente.Size = new System.Drawing.Size(92, 22);
            this.tsbEsDeCliente.Text = "Es de cliente";
            this.tsbEsDeCliente.Click += new System.EventHandler(this.tsbEsDeCliente_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrdenes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(656, 446);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenes.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdenes.MainView = this.gridView3;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(656, 197);
            this.dgvOrdenes.TabIndex = 0;
            this.dgvOrdenes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.dgvOrdenes.Click += new System.EventHandler(this.dgvOrdenes_Click);
            this.dgvOrdenes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOrdenes_KeyUp);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dgvOrdenes;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView3_FocusedRowChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpConsumidos);
            this.tabControl1.Controls.Add(this.tpProducidos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 245);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpConsumidos
            // 
            this.tpConsumidos.Controls.Add(this.dgvConsumidos);
            this.tpConsumidos.Location = new System.Drawing.Point(4, 22);
            this.tpConsumidos.Name = "tpConsumidos";
            this.tpConsumidos.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsumidos.Size = new System.Drawing.Size(648, 219);
            this.tpConsumidos.TabIndex = 0;
            this.tpConsumidos.Text = "Consumidos";
            this.tpConsumidos.UseVisualStyleBackColor = true;
            // 
            // dgvConsumidos
            // 
            this.dgvConsumidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsumidos.Location = new System.Drawing.Point(3, 3);
            this.dgvConsumidos.MainView = this.gridView1;
            this.dgvConsumidos.Name = "dgvConsumidos";
            this.dgvConsumidos.Size = new System.Drawing.Size(642, 213);
            this.dgvConsumidos.TabIndex = 0;
            this.dgvConsumidos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgvConsumidos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvConsumidos_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvConsumidos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // tpProducidos
            // 
            this.tpProducidos.Controls.Add(this.dgvProducidos);
            this.tpProducidos.Location = new System.Drawing.Point(4, 22);
            this.tpProducidos.Name = "tpProducidos";
            this.tpProducidos.Padding = new System.Windows.Forms.Padding(3);
            this.tpProducidos.Size = new System.Drawing.Size(648, 219);
            this.tpProducidos.TabIndex = 1;
            this.tpProducidos.Text = "Producidos";
            this.tpProducidos.UseVisualStyleBackColor = true;
            // 
            // dgvProducidos
            // 
            this.dgvProducidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducidos.Location = new System.Drawing.Point(3, 3);
            this.dgvProducidos.MainView = this.gridView2;
            this.dgvProducidos.Name = "dgvProducidos";
            this.dgvProducidos.Size = new System.Drawing.Size(642, 213);
            this.dgvProducidos.TabIndex = 0;
            this.dgvProducidos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.dgvProducidos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProducidos_KeyUp);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dgvProducidos;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowFooter = true;
            // 
            // frmVerOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 493);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmVerOrdenes";
            this.Text = "frmVerOrdenes";
            this.Load += new System.EventHandler(this.frmVerOrdenes_Load);
            this.Shown += new System.EventHandler(this.frmVerOrdenes_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpConsumidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpProducidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFilas;
        private System.Windows.Forms.ToolStripButton tsbRevisar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpConsumidos;
        private System.Windows.Forms.TabPage tpProducidos;
        private DevExpress.XtraGrid.GridControl dgvProducidos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl dgvConsumidos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl dgvOrdenes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.ToolStripButton tsbEsDeCliente;
    }
}