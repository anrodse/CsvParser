namespace Anrodse.CsvParser.Demo
{
	partial class Ventana
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabModelo = new System.Windows.Forms.DataGridView();
			this.cmbModelo = new System.Windows.Forms.ComboBox();
			this.lblModelo = new System.Windows.Forms.Label();
			this.btnCargar = new System.Windows.Forms.Button();
			this.pnStatus = new System.Windows.Forms.Panel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblResultado = new System.Windows.Forms.Label();
			this.lblSep = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tabModelo)).BeginInit();
			this.pnStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabModelo
			// 
			this.tabModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabModelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tabModelo.Location = new System.Drawing.Point(15, 37);
			this.tabModelo.Name = "tabModelo";
			this.tabModelo.Size = new System.Drawing.Size(528, 238);
			this.tabModelo.TabIndex = 0;
			// 
			// cmbModelo
			// 
			this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModelo.FormattingEnabled = true;
			this.cmbModelo.Location = new System.Drawing.Point(88, 9);
			this.cmbModelo.Name = "cmbModelo";
			this.cmbModelo.Size = new System.Drawing.Size(121, 21);
			this.cmbModelo.TabIndex = 1;
			// 
			// lblModelo
			// 
			this.lblModelo.Location = new System.Drawing.Point(12, 9);
			this.lblModelo.Name = "lblModelo";
			this.lblModelo.Size = new System.Drawing.Size(70, 21);
			this.lblModelo.TabIndex = 2;
			this.lblModelo.Text = "Modelo:";
			this.lblModelo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCargar
			// 
			this.btnCargar.Location = new System.Drawing.Point(215, 8);
			this.btnCargar.Name = "btnCargar";
			this.btnCargar.Size = new System.Drawing.Size(75, 23);
			this.btnCargar.TabIndex = 3;
			this.btnCargar.Text = "Cargar";
			this.btnCargar.UseVisualStyleBackColor = true;
			this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
			// 
			// pnStatus
			// 
			this.pnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnStatus.Controls.Add(this.lblResultado);
			this.pnStatus.Controls.Add(this.lblStatus);
			this.pnStatus.Location = new System.Drawing.Point(0, 285);
			this.pnStatus.Name = "pnStatus";
			this.pnStatus.Size = new System.Drawing.Size(544, 20);
			this.pnStatus.TabIndex = 4;
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(3, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(432, 20);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "Esperando lectura";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblResultado
			// 
			this.lblResultado.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblResultado.Location = new System.Drawing.Point(441, 0);
			this.lblResultado.Name = "lblResultado";
			this.lblResultado.Size = new System.Drawing.Size(100, 20);
			this.lblResultado.TabIndex = 1;
			this.lblResultado.Text = "Listo";
			this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSep
			// 
			this.lblSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblSep.Location = new System.Drawing.Point(0, 283);
			this.lblSep.Name = "lblSep";
			this.lblSep.Size = new System.Drawing.Size(556, 2);
			this.lblSep.TabIndex = 5;
			// 
			// Ventana
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 307);
			this.Controls.Add(this.lblSep);
			this.Controls.Add(this.pnStatus);
			this.Controls.Add(this.btnCargar);
			this.Controls.Add(this.lblModelo);
			this.Controls.Add(this.cmbModelo);
			this.Controls.Add(this.tabModelo);
			this.Name = "Ventana";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Csv Parser - Demo";
			((System.ComponentModel.ISupportInitialize)(this.tabModelo)).EndInit();
			this.pnStatus.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView tabModelo;
		private System.Windows.Forms.ComboBox cmbModelo;
		private System.Windows.Forms.Label lblModelo;
		private System.Windows.Forms.Button btnCargar;
		private System.Windows.Forms.Panel pnStatus;
		private System.Windows.Forms.Label lblResultado;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblSep;
	}
}

