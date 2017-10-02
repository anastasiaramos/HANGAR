namespace moleQule.Face.Application
{
	partial class AboutForm
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.Paneles = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Paneles2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iQ_LL = new System.Windows.Forms.LinkLabel();
            this.Logo_PB = new System.Windows.Forms.PictureBox();
            this.moleQuleLogo_PB = new System.Windows.Forms.PictureBox();
            this.iQLogo_PB = new System.Windows.Forms.PictureBox();
            this.Paneles.Panel1.SuspendLayout();
            this.Paneles.Panel2.SuspendLayout();
            this.Paneles.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.Panel2.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moleQuleLogo_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iQLogo_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Paneles
            // 
            this.Paneles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paneles.Location = new System.Drawing.Point(0, 0);
            this.Paneles.Name = "Paneles";
            this.Paneles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Paneles.Panel1
            // 
            this.Paneles.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Paneles.Panel1.Controls.Add(this.label7);
            this.Paneles.Panel1.Controls.Add(this.Logo_PB);
            this.Paneles.Panel1.Controls.Add(this.label3);
            this.Paneles.Panel1.Controls.Add(this.label1);
            // 
            // Paneles.Panel2
            // 
            this.Paneles.Panel2.Controls.Add(this.Paneles2);
            this.Paneles.Size = new System.Drawing.Size(351, 606);
            this.Paneles.SplitterDistance = 199;
            this.Paneles.SplitterWidth = 1;
            this.Paneles.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(98, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 91);
            this.label7.TabIndex = 13;
            this.label7.Text = "Application based on:\r\n\r\niQ moleQule 2.0\r\nPostgreSQL 8.0.3\r\nVisual C# .Net 2005\r\n" +
                "\r\nDistributed under GNU License";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Powered by iQ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 5;
            this.label1.Tag = "NO FORMAT";
            this.label1.Text = "iQ Hangar 1.0";
            // 
            // Paneles2
            // 
            this.Paneles2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paneles2.Location = new System.Drawing.Point(0, 0);
            this.Paneles2.Name = "Paneles2";
            this.Paneles2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Paneles2.Panel1
            // 
            this.Paneles2.Panel1.Controls.Add(this.label6);
            this.Paneles2.Panel1.Controls.Add(this.label4);
            this.Paneles2.Panel1.Controls.Add(this.label5);
            this.Paneles2.Panel1.Controls.Add(this.moleQuleLogo_PB);
            // 
            // Paneles2.Panel2
            // 
            this.Paneles2.Panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Paneles2.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Paneles2.Panel2.Controls.Add(this.label8);
            this.Paneles2.Panel2.Controls.Add(this.label2);
            this.Paneles2.Panel2.Controls.Add(this.iQLogo_PB);
            this.Paneles2.Panel2.Controls.Add(this.iQ_LL);
            this.Paneles2.Size = new System.Drawing.Size(351, 406);
            this.Paneles2.SplitterDistance = 198;
            this.Paneles2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 91);
            this.label6.TabIndex = 12;
            this.label6.Text = "Visual C# Framework based on:\r\n\r\nCSLA 2.0\r\nNHibernate 2.0\r\nVisual C# .Net 2005\r\n\r" +
                "\nDistributed under GNU License";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Powered by iQ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 23);
            this.label5.TabIndex = 10;
            this.label5.Tag = "NO FORMAT";
            this.label5.Text = "iQ moleQule Framework 2.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(203, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "Canary Islands\r\nSpain";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(168, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 7;
            this.label2.Tag = "NO FORMAT";
            this.label2.Text = "iQ Ingenieros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iQ_LL
            // 
            this.iQ_LL.AutoSize = true;
            this.iQ_LL.BackColor = System.Drawing.Color.Transparent;
            this.iQ_LL.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iQ_LL.ForeColor = System.Drawing.Color.White;
            this.iQ_LL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.iQ_LL.Location = new System.Drawing.Point(123, 150);
            this.iQ_LL.Name = "iQ_LL";
            this.iQ_LL.Size = new System.Drawing.Size(105, 16);
            this.iQ_LL.TabIndex = 0;
            this.iQ_LL.TabStop = true;
            this.iQ_LL.Text = "iqingenieros.com";
            this.iQ_LL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iQ_LL_LinkClicked);
            // 
            // Logo_PB
            // 
            this.Logo_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo_PB.Image = global::moleQule.Face.Application.Properties.Resources.Hangar;
            this.Logo_PB.Location = new System.Drawing.Point(87, 21);
            this.Logo_PB.Name = "Logo_PB";
            this.Logo_PB.Size = new System.Drawing.Size(50, 50);
            this.Logo_PB.TabIndex = 8;
            this.Logo_PB.TabStop = false;
            // 
            // moleQuleLogo_PB
            // 
            this.moleQuleLogo_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moleQuleLogo_PB.Image = global::moleQule.Face.Application.Properties.Resources.molequle;
            this.moleQuleLogo_PB.Location = new System.Drawing.Point(23, 21);
            this.moleQuleLogo_PB.Name = "moleQuleLogo_PB";
            this.moleQuleLogo_PB.Size = new System.Drawing.Size(50, 50);
            this.moleQuleLogo_PB.TabIndex = 9;
            this.moleQuleLogo_PB.TabStop = false;
            // 
            // iQLogo_PB
            // 
            this.iQLogo_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iQLogo_PB.Image = ((System.Drawing.Image)(resources.GetObject("iQLogo_PB.Image")));
            this.iQLogo_PB.Location = new System.Drawing.Point(65, 39);
            this.iQLogo_PB.Name = "iQLogo_PB";
            this.iQLogo_PB.Size = new System.Drawing.Size(75, 75);
            this.iQLogo_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iQLogo_PB.TabIndex = 2;
            this.iQLogo_PB.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(351, 606);
            this.Controls.Add(this.Paneles);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "NoFormat";
            this.Text = "Acerca de...";
            this.Paneles.Panel1.ResumeLayout(false);
            this.Paneles.Panel1.PerformLayout();
            this.Paneles.Panel2.ResumeLayout(false);
            this.Paneles.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.Panel1.PerformLayout();
            this.Paneles2.Panel2.ResumeLayout(false);
            this.Paneles2.Panel2.PerformLayout();
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moleQuleLogo_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iQLogo_PB)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer Paneles;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer Paneles2;
		private System.Windows.Forms.LinkLabel iQ_LL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox iQLogo_PB;
		private System.Windows.Forms.PictureBox Logo_PB;
		private System.Windows.Forms.PictureBox moleQuleLogo_PB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
	}
}
