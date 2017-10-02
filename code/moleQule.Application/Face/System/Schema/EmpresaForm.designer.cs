namespace moleQule.Face.Application
{
    partial class EmpresaForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label codPostalLabel;
            System.Windows.Forms.Label direccionLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label provinciaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label municipioLabel1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpresaForm));
            this.ID_TB = new System.Windows.Forms.TextBox();
            this.Codigo_TB = new System.Windows.Forms.TextBox();
            this.CodPostal_TextBox = new System.Windows.Forms.TextBox();
            this.Direccion_TextBox = new System.Windows.Forms.TextBox();
            this.Nombre_TextBox = new System.Windows.Forms.TextBox();
            this.Provincia_TextBox = new System.Windows.Forms.TextBox();
            this.Examinar_Button = new System.Windows.Forms.Button();
            this.Logo_PictureBox = new System.Windows.Forms.PictureBox();
            this.Municipio_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Municipios = new System.Windows.Forms.BindingSource(this.components);
            this.Browser = new System.Windows.Forms.OpenFileDialog();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.General_TP = new System.Windows.Forms.TabPage();
            this.Cuenta_BT = new System.Windows.Forms.Button();
            this.Cuenta_TB = new System.Windows.Forms.TextBox();
            this.MascaraID_Label = new System.Windows.Forms.Label();
            this.ID_GB = new System.Windows.Forms.GroupBox();
            this.Otros_RB = new System.Windows.Forms.RadioButton();
            this.NIF_RB = new System.Windows.Forms.RadioButton();
            this.NIE_RB = new System.Windows.Forms.RadioButton();
            this.CIF_RB = new System.Windows.Forms.RadioButton();
            this.CtaCotizacion_TB = new System.Windows.Forms.TextBox();
            this.Municipios_Button = new System.Windows.Forms.Button();
            this.Ninguno_Button = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Contactos_TP = new System.Windows.Forms.TabPage();
            this.Contactos_Grid = new System.Windows.Forms.DataGridView();
            this.Cargo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_Cargos = new System.Windows.Forms.BindingSource(this.components);
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_Municipios_Contactos = new System.Windows.Forms.BindingSource(this.components);
            this.Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefonos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datos_Contactos = new System.Windows.Forms.BindingSource(this.components);
            ID_LB = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            codPostalLabel = new System.Windows.Forms.Label();
            direccionLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            provinciaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            municipioLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Municipios)).BeginInit();
            this.TabControl.SuspendLayout();
            this.General_TP.SuspendLayout();
            this.ID_GB.SuspendLayout();
            this.Contactos_TP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Contactos_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cargos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Municipios_Contactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Contactos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(914, 437);
            this.PanelesV.SplitterDistance = 396;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(370, 7);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Size = new System.Drawing.Size(83, 23);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(459, 7);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            this.Cancel_BT.Size = new System.Drawing.Size(83, 23);
            // 
            // Paneles2
            // 
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(912, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(814, 7);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            this.Imprimir_Button.Size = new System.Drawing.Size(87, 23);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Application.Empresa);
            this.Datos.DataSourceChanged += new System.EventHandler(this.Datos_DataSourceChanged);
            // 
            // ID_LB
            // 
            ID_LB.AutoSize = true;
            ID_LB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ID_LB.Location = new System.Drawing.Point(72, 69);
            ID_LB.Name = "ID_LB";
            ID_LB.Size = new System.Drawing.Size(55, 13);
            ID_LB.TabIndex = 5;
            ID_LB.Text = "CIF / NIF:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(83, 42);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 7;
            codigoLabel.Text = "Código:";
            // 
            // codPostalLabel
            // 
            codPostalLabel.AutoSize = true;
            codPostalLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPostalLabel.Location = new System.Drawing.Point(50, 178);
            codPostalLabel.Name = "codPostalLabel";
            codPostalLabel.Size = new System.Drawing.Size(76, 13);
            codPostalLabel.TabIndex = 9;
            codPostalLabel.Text = "Código Postal:";
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            direccionLabel.Location = new System.Drawing.Point(72, 123);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new System.Drawing.Size(54, 13);
            direccionLabel.TabIndex = 11;
            direccionLabel.Text = "Dirección:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(67, 96);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(60, 13);
            nombreLabel.TabIndex = 17;
            nombreLabel.Text = "Nombre * :";
            // 
            // provinciaLabel
            // 
            provinciaLabel.AutoSize = true;
            provinciaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            provinciaLabel.Location = new System.Drawing.Point(291, 178);
            provinciaLabel.Name = "provinciaLabel";
            provinciaLabel.Size = new System.Drawing.Size(54, 13);
            provinciaLabel.TabIndex = 19;
            provinciaLabel.Text = "Provincia:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(657, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 13);
            label1.TabIndex = 24;
            label1.Text = "Logo:";
            // 
            // municipioLabel1
            // 
            municipioLabel1.AutoSize = true;
            municipioLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            municipioLabel1.Location = new System.Drawing.Point(72, 150);
            municipioLabel1.Name = "municipioLabel1";
            municipioLabel1.Size = new System.Drawing.Size(54, 13);
            municipioLabel1.TabIndex = 25;
            municipioLabel1.Text = "Municipio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(68, 205);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 13);
            label2.TabIndex = 28;
            label2.Text = "Teléfonos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(363, 205);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 13);
            label3.TabIndex = 30;
            label3.Text = "Fax:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(93, 232);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 32;
            label4.Text = "Web:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(353, 232);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(39, 13);
            label5.TabIndex = 34;
            label5.Text = "e-mail:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(54, 258);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 13);
            label6.TabIndex = 36;
            label6.Text = "Responsable:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(345, 286);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(84, 13);
            label7.TabIndex = 158;
            label7.Text = "Cta. Cotización:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(36, 286);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(90, 13);
            label8.TabIndex = 162;
            label8.Text = "Cuenta Bancaria:";
            // 
            // ID_TB
            // 
            this.ID_TB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "ID", true));
            this.ID_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ID_TB.Location = new System.Drawing.Point(134, 66);
            this.ID_TB.Name = "ID_TB";
            this.ID_TB.Size = new System.Drawing.Size(80, 21);
            this.ID_TB.TabIndex = 20;
            // 
            // Codigo_TB
            // 
            this.Codigo_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Code", true));
            this.Codigo_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Codigo_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Codigo_TB.Location = new System.Drawing.Point(134, 39);
            this.Codigo_TB.Name = "Codigo_TB";
            this.Codigo_TB.ReadOnly = true;
            this.Codigo_TB.Size = new System.Drawing.Size(80, 21);
            this.Codigo_TB.TabIndex = 5;
            this.Codigo_TB.TabStop = false;
            this.Codigo_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CodPostal_TextBox
            // 
            this.CodPostal_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "CodPostal", true));
            this.CodPostal_TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodPostal_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CodPostal_TextBox.Location = new System.Drawing.Point(133, 174);
            this.CodPostal_TextBox.Name = "CodPostal_TextBox";
            this.CodPostal_TextBox.Size = new System.Drawing.Size(80, 21);
            this.CodPostal_TextBox.TabIndex = 60;
            this.CodPostal_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Direccion_TextBox
            // 
            this.Direccion_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Direccion", true));
            this.Direccion_TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Direccion_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Direccion_TextBox.Location = new System.Drawing.Point(133, 120);
            this.Direccion_TextBox.Name = "Direccion_TextBox";
            this.Direccion_TextBox.Size = new System.Drawing.Size(460, 21);
            this.Direccion_TextBox.TabIndex = 30;
            // 
            // Nombre_TextBox
            // 
            this.Nombre_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Name", true));
            this.Nombre_TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Nombre_TextBox.Location = new System.Drawing.Point(134, 93);
            this.Nombre_TextBox.Name = "Nombre_TextBox";
            this.Nombre_TextBox.Size = new System.Drawing.Size(460, 21);
            this.Nombre_TextBox.TabIndex = 10;
            // 
            // Provincia_TextBox
            // 
            this.Provincia_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Provincia", true));
            this.Provincia_TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Provincia_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Provincia_TextBox.Location = new System.Drawing.Point(351, 174);
            this.Provincia_TextBox.Name = "Provincia_TextBox";
            this.Provincia_TextBox.Size = new System.Drawing.Size(242, 21);
            this.Provincia_TextBox.TabIndex = 70;
            // 
            // Examinar_Button
            // 
            this.Examinar_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar_Button.Location = new System.Drawing.Point(660, 269);
            this.Examinar_Button.Name = "Examinar_Button";
            this.Examinar_Button.Size = new System.Drawing.Size(83, 23);
            this.Examinar_Button.TabIndex = 130;
            this.Examinar_Button.Text = "&Examinar";
            this.Examinar_Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Examinar_Button.UseVisualStyleBackColor = true;
            // 
            // Logo_PictureBox
            // 
            this.Logo_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Logo_PictureBox.Location = new System.Drawing.Point(660, 82);
            this.Logo_PictureBox.Name = "Logo_PictureBox";
            this.Logo_PictureBox.Size = new System.Drawing.Size(172, 178);
            this.Logo_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_PictureBox.TabIndex = 23;
            this.Logo_PictureBox.TabStop = false;
            // 
            // Municipio_CB
            // 
            this.Municipio_CB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Municipio", true));
            this.Municipio_CB.DataSource = this.Datos_Municipios;
            this.Municipio_CB.DisplayMember = "Valor";
            this.Municipio_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Municipio_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Municipio_CB.FormattingEnabled = true;
            this.Municipio_CB.Location = new System.Drawing.Point(133, 147);
            this.Municipio_CB.Name = "Municipio_CB";
            this.Municipio_CB.Size = new System.Drawing.Size(238, 21);
            this.Municipio_CB.TabIndex = 40;
            this.Municipio_CB.ValueMember = "Valor";
            // 
            // Datos_Municipios
            // 
            this.Datos_Municipios.DataSource = typeof(moleQule.Library.Common.MunicipioList);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.General_TP);
            this.TabControl.Controls.Add(this.Contactos_TP);
            this.TabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(19, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(877, 369);
            this.TabControl.TabIndex = 0;
            // 
            // General_TP
            // 
            this.General_TP.Controls.Add(this.Cuenta_BT);
            this.General_TP.Controls.Add(this.Cuenta_TB);
            this.General_TP.Controls.Add(label8);
            this.General_TP.Controls.Add(this.MascaraID_Label);
            this.General_TP.Controls.Add(this.ID_GB);
            this.General_TP.Controls.Add(label7);
            this.General_TP.Controls.Add(this.CtaCotizacion_TB);
            this.General_TP.Controls.Add(this.Municipios_Button);
            this.General_TP.Controls.Add(this.Ninguno_Button);
            this.General_TP.Controls.Add(this.textBox5);
            this.General_TP.Controls.Add(label6);
            this.General_TP.Controls.Add(this.textBox4);
            this.General_TP.Controls.Add(label5);
            this.General_TP.Controls.Add(this.textBox3);
            this.General_TP.Controls.Add(label4);
            this.General_TP.Controls.Add(this.textBox2);
            this.General_TP.Controls.Add(label3);
            this.General_TP.Controls.Add(this.textBox1);
            this.General_TP.Controls.Add(label2);
            this.General_TP.Controls.Add(this.Direccion_TextBox);
            this.General_TP.Controls.Add(this.Provincia_TextBox);
            this.General_TP.Controls.Add(municipioLabel1);
            this.General_TP.Controls.Add(provinciaLabel);
            this.General_TP.Controls.Add(this.Nombre_TextBox);
            this.General_TP.Controls.Add(this.Municipio_CB);
            this.General_TP.Controls.Add(nombreLabel);
            this.General_TP.Controls.Add(this.Examinar_Button);
            this.General_TP.Controls.Add(label1);
            this.General_TP.Controls.Add(this.Logo_PictureBox);
            this.General_TP.Controls.Add(direccionLabel);
            this.General_TP.Controls.Add(ID_LB);
            this.General_TP.Controls.Add(this.CodPostal_TextBox);
            this.General_TP.Controls.Add(this.ID_TB);
            this.General_TP.Controls.Add(codPostalLabel);
            this.General_TP.Controls.Add(codigoLabel);
            this.General_TP.Controls.Add(this.Codigo_TB);
            this.General_TP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.General_TP.Location = new System.Drawing.Point(4, 22);
            this.General_TP.Name = "General_TP";
            this.General_TP.Padding = new System.Windows.Forms.Padding(3);
            this.General_TP.Size = new System.Drawing.Size(869, 343);
            this.General_TP.TabIndex = 2;
            this.General_TP.Text = "Datos Generales";
            this.General_TP.UseVisualStyleBackColor = true;
            // 
            // Cuenta_BT
            // 
            this.Cuenta_BT.Image = global::moleQule.Face.Application.Properties.Resources.Seleccionar_16;
            this.Cuenta_BT.Location = new System.Drawing.Point(303, 282);
            this.Cuenta_BT.Name = "Cuenta_BT";
            this.Cuenta_BT.Size = new System.Drawing.Size(27, 21);
            this.Cuenta_BT.TabIndex = 163;
            this.Cuenta_BT.UseVisualStyleBackColor = true;
            // 
            // Cuenta_TB
            // 
            this.Cuenta_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "CuentaBancaria", true));
            this.Cuenta_TB.Location = new System.Drawing.Point(132, 282);
            this.Cuenta_TB.Name = "Cuenta_TB";
            this.Cuenta_TB.Size = new System.Drawing.Size(161, 22);
            this.Cuenta_TB.TabIndex = 161;
            // 
            // MascaraID_Label
            // 
            this.MascaraID_Label.AutoSize = true;
            this.MascaraID_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MascaraID_Label.Location = new System.Drawing.Point(477, 69);
            this.MascaraID_Label.Name = "MascaraID_Label";
            this.MascaraID_Label.Size = new System.Drawing.Size(0, 13);
            this.MascaraID_Label.TabIndex = 160;
            // 
            // ID_GB
            // 
            this.ID_GB.Controls.Add(this.Otros_RB);
            this.ID_GB.Controls.Add(this.NIF_RB);
            this.ID_GB.Controls.Add(this.NIE_RB);
            this.ID_GB.Controls.Add(this.CIF_RB);
            this.ID_GB.Location = new System.Drawing.Point(220, 57);
            this.ID_GB.Name = "ID_GB";
            this.ID_GB.Size = new System.Drawing.Size(242, 31);
            this.ID_GB.TabIndex = 159;
            this.ID_GB.TabStop = false;
            // 
            // Otros_RB
            // 
            this.Otros_RB.AutoSize = true;
            this.Otros_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Otros_RB.Location = new System.Drawing.Point(175, 10);
            this.Otros_RB.Name = "Otros_RB";
            this.Otros_RB.Size = new System.Drawing.Size(56, 17);
            this.Otros_RB.TabIndex = 29;
            this.Otros_RB.Text = "Otros";
            this.Otros_RB.UseVisualStyleBackColor = true;
            // 
            // NIF_RB
            // 
            this.NIF_RB.AutoSize = true;
            this.NIF_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIF_RB.Location = new System.Drawing.Point(67, 10);
            this.NIF_RB.Name = "NIF_RB";
            this.NIF_RB.Size = new System.Drawing.Size(43, 17);
            this.NIF_RB.TabIndex = 26;
            this.NIF_RB.Text = "NIF";
            this.NIF_RB.UseVisualStyleBackColor = true;
            // 
            // NIE_RB
            // 
            this.NIE_RB.AutoSize = true;
            this.NIE_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIE_RB.Location = new System.Drawing.Point(121, 10);
            this.NIE_RB.Name = "NIE_RB";
            this.NIE_RB.Size = new System.Drawing.Size(43, 17);
            this.NIE_RB.TabIndex = 28;
            this.NIE_RB.Text = "NIE";
            this.NIE_RB.UseVisualStyleBackColor = true;
            // 
            // CIF_RB
            // 
            this.CIF_RB.AutoSize = true;
            this.CIF_RB.Checked = true;
            this.CIF_RB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CIF_RB.Location = new System.Drawing.Point(13, 10);
            this.CIF_RB.Name = "CIF_RB";
            this.CIF_RB.Size = new System.Drawing.Size(43, 17);
            this.CIF_RB.TabIndex = 24;
            this.CIF_RB.TabStop = true;
            this.CIF_RB.Text = "CIF";
            this.CIF_RB.UseVisualStyleBackColor = true;
            // 
            // CtaCotizacion_TB
            // 
            this.CtaCotizacion_TB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CtaCotizacion_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "CtaCotizacion", true));
            this.CtaCotizacion_TB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtaCotizacion_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CtaCotizacion_TB.Location = new System.Drawing.Point(435, 282);
            this.CtaCotizacion_TB.Name = "CtaCotizacion_TB";
            this.CtaCotizacion_TB.Size = new System.Drawing.Size(158, 21);
            this.CtaCotizacion_TB.TabIndex = 25;
            this.CtaCotizacion_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Municipios_Button
            // 
            this.Municipios_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Municipios_Button.Location = new System.Drawing.Point(377, 145);
            this.Municipios_Button.Name = "Municipios_Button";
            this.Municipios_Button.Size = new System.Drawing.Size(25, 25);
            this.Municipios_Button.TabIndex = 43;
            this.Municipios_Button.UseVisualStyleBackColor = true;
            // 
            // Ninguno_Button
            // 
            this.Ninguno_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ninguno_Button.Location = new System.Drawing.Point(749, 269);
            this.Ninguno_Button.Name = "Ninguno_Button";
            this.Ninguno_Button.Size = new System.Drawing.Size(83, 23);
            this.Ninguno_Button.TabIndex = 140;
            this.Ninguno_Button.Text = "&Ninguno";
            this.Ninguno_Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Ninguno_Button.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Responsable", true));
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox5.Location = new System.Drawing.Point(133, 255);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(460, 21);
            this.textBox5.TabIndex = 120;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Email", true));
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox4.Location = new System.Drawing.Point(398, 229);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 21);
            this.textBox4.TabIndex = 110;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Url", true));
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox3.Location = new System.Drawing.Point(133, 228);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(180, 21);
            this.textBox3.TabIndex = 100;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fax", true));
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(398, 202);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 21);
            this.textBox2.TabIndex = 90;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Telefonos", true));
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(133, 201);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 21);
            this.textBox1.TabIndex = 80;
            // 
            // Contactos_TP
            // 
            this.Contactos_TP.Controls.Add(this.Contactos_Grid);
            this.Contactos_TP.Location = new System.Drawing.Point(4, 22);
            this.Contactos_TP.Name = "Contactos_TP";
            this.Contactos_TP.Padding = new System.Windows.Forms.Padding(3);
            this.Contactos_TP.Size = new System.Drawing.Size(869, 343);
            this.Contactos_TP.TabIndex = 0;
            this.Contactos_TP.Text = " Contactos ";
            this.Contactos_TP.UseVisualStyleBackColor = true;
            // 
            // Contactos_Grid
            // 
            this.Contactos_Grid.AutoGenerateColumns = false;
            this.Contactos_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Contactos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cargo,
            this.Nombre,
            this.Dni,
            this.Direccion,
            this.Municipio,
            this.Provincia,
            this.CodPostal,
            this.Telefonos});
            this.Contactos_Grid.DataSource = this.Datos_Contactos;
            this.Contactos_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contactos_Grid.Location = new System.Drawing.Point(3, 3);
            this.Contactos_Grid.Name = "Contactos_Grid";
            this.Contactos_Grid.Size = new System.Drawing.Size(863, 337);
            this.Contactos_Grid.TabIndex = 10;
            this.Contactos_Grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Contactos_Grid_CellValueChanged);
            this.Contactos_Grid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Contactos_Grid_CellMouseDoubleClick);
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.DataSource = this.Datos_Cargos;
            this.Cargo.DisplayMember = "Valor";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cargo.ValueMember = "Valor";
            this.Cargo.Width = 120;
            // 
            // Datos_Cargos
            // 
            this.Datos_Cargos.DataSource = typeof(moleQule.Library.Common.CargoList);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 120;
            // 
            // Dni
            // 
            this.Dni.DataPropertyName = "Dni";
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.Width = 70;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.Width = 110;
            // 
            // Municipio
            // 
            this.Municipio.DataPropertyName = "Municipio";
            this.Municipio.DataSource = this.Datos_Municipios_Contactos;
            this.Municipio.DisplayMember = "Valor";
            this.Municipio.HeaderText = "Municipio";
            this.Municipio.Name = "Municipio";
            this.Municipio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Municipio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Municipio.ValueMember = "Valor";
            this.Municipio.Width = 120;
            // 
            // Datos_Municipios_Contactos
            // 
            this.Datos_Municipios_Contactos.DataSource = typeof(moleQule.Library.Common.MunicipioList);
            // 
            // Provincia
            // 
            this.Provincia.DataPropertyName = "Provincia";
            this.Provincia.HeaderText = "Provincia";
            this.Provincia.Name = "Provincia";
            // 
            // CodPostal
            // 
            this.CodPostal.DataPropertyName = "CodPostal";
            this.CodPostal.HeaderText = "C. Postal";
            this.CodPostal.Name = "CodPostal";
            this.CodPostal.Width = 80;
            // 
            // Telefonos
            // 
            this.Telefonos.DataPropertyName = "Telefonos";
            this.Telefonos.HeaderText = "Tfnos.";
            this.Telefonos.Name = "Telefonos";
            // 
            // Datos_Contactos
            // 
            this.Datos_Contactos.DataSource = typeof(moleQule.Library.Application.ContactoEmpresas);
            // 
            // EmpresaForm
            // 
            this.ClientSize = new System.Drawing.Size(914, 437);
            this.Controls.Add(this.TabControl);
            this.HelpProvider.SetHelpKeyword(this, "60");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmpresaForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "EmpresaForm";
            this.Controls.SetChildIndex(this.PanelesV, 0);
            this.Controls.SetChildIndex(this.TabControl, 0);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Municipios)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.General_TP.ResumeLayout(false);
            this.General_TP.PerformLayout();
            this.ID_GB.ResumeLayout(false);
            this.ID_GB.PerformLayout();
            this.Contactos_TP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Contactos_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cargos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Municipios_Contactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Contactos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label ID_LB;
		private System.Windows.Forms.TabPage General_TP;
		private System.Windows.Forms.TabPage Contactos_TP;
        protected System.Windows.Forms.BindingSource Datos_Contactos;
		protected System.Windows.Forms.TextBox ID_TB;
		protected System.Windows.Forms.TextBox Codigo_TB;
		protected System.Windows.Forms.TextBox CodPostal_TextBox;
		protected System.Windows.Forms.TextBox Direccion_TextBox;
		protected System.Windows.Forms.TextBox Nombre_TextBox;
		protected System.Windows.Forms.TextBox Provincia_TextBox;
		protected System.Windows.Forms.Button Examinar_Button;
		protected System.Windows.Forms.PictureBox Logo_PictureBox;
		protected System.Windows.Forms.ComboBox Municipio_CB;
		protected System.Windows.Forms.TabControl TabControl;
		protected System.Windows.Forms.TextBox textBox2;
		protected System.Windows.Forms.TextBox textBox1;
		protected System.Windows.Forms.TextBox textBox3;
		protected System.Windows.Forms.TextBox textBox4;
		protected System.Windows.Forms.TextBox textBox5;
		protected System.Windows.Forms.Button Ninguno_Button;
		protected System.Windows.Forms.DataGridView Contactos_Grid;
		protected System.Windows.Forms.BindingSource Datos_Municipios;
		protected System.Windows.Forms.OpenFileDialog Browser;
		protected System.Windows.Forms.BindingSource Datos_Cargos;
		protected System.Windows.Forms.BindingSource Datos_Municipios_Contactos;
		protected System.Windows.Forms.Button Municipios_Button;
		protected System.Windows.Forms.TextBox CtaCotizacion_TB;
		protected System.Windows.Forms.GroupBox ID_GB;
		protected System.Windows.Forms.RadioButton Otros_RB;
		protected System.Windows.Forms.RadioButton NIF_RB;
		protected System.Windows.Forms.RadioButton NIE_RB;
		protected System.Windows.Forms.RadioButton CIF_RB;
		protected System.Windows.Forms.Label MascaraID_Label;
        protected System.Windows.Forms.TextBox Cuenta_TB;
        private System.Windows.Forms.DataGridViewComboBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewComboBoxColumn Municipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefonos;
        protected System.Windows.Forms.Button Cuenta_BT;

    }
}
