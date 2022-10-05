namespace CP
{
	partial class IUTipoCambio
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
		base.Dispose();
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtFecha = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTC = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
//label1
//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12,9);
			this.label1.Name = "label1"
			this.label1.Size = new System.Drawing.Size(35,13);
			this.label1.TabIndex = 0
			this.label1.Text ="Fecha";
			//
//txtFecha
//
			this.txtFecha.Location = new System.Drawing.Point(113,9);
			this.txtFecha.Name = "txtFecha"
			this.txtFecha.Size = new System.Drawing.Size(183,20);
			this.txtFecha.TabIndex = 0

			//
//label2
//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12,35);
			this.label2.Name = "label2"
			this.label2.Size = new System.Drawing.Size(35,13);
			this.label2.TabIndex = 0
			this.label2.Text ="TC";
			//
//txtTC
//
			this.txtTC.Location = new System.Drawing.Point(113,35);
			this.txtTC.Name = "txtTC"
			this.txtTC.Size = new System.Drawing.Size(183,20);
			this.txtTC.TabIndex = 0

			//
//IUItem
//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 427);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFecha);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtTC);
			this.Name = "IUTipoCambio";
			this.Text = "IUTipoCambio";
			this.ResumeLayout(false);
		}
		#endregion
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.TextBox txtFecha;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.TextBox txtTC;
	}
}

