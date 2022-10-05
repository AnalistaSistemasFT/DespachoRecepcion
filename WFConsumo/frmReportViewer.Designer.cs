
namespace WFConsumo
{
    partial class frmReportViewer
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
            this.Visor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Visor
            // 
            this.Visor.ActiveViewIndex = -1;
            this.Visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Visor.Cursor = System.Windows.Forms.Cursors.Default;
            this.Visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Visor.Location = new System.Drawing.Point(0, 0);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(574, 308);
            this.Visor.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 308);
            this.Controls.Add(this.Visor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportViewer";
            this.Text = "frmReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Visor;
    }
}