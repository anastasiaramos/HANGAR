namespace moleQule.Face.Application
{
    partial class SettingsForm
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
            System.Windows.Forms.Label label39;
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.FTPHost_TB = new System.Windows.Forms.TextBox();
            this.Instruccion_TP = new System.Windows.Forms.TabPage();
            this.ImpresionEmpresaDefault_BT = new System.Windows.Forms.Button();
            this.ImpresionEmpresaDefault_TB = new System.Windows.Forms.TextBox();
            this.ImpresionEmpresaDefault_CB = new System.Windows.Forms.CheckBox();
            this.InstructoresAutorizados_CB = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.InicioManana_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasMI = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.FinTarde2_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasT2F = new System.Windows.Forms.BindingSource(this.components);
            this.FinManana_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasMF = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.InicioTarde2_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasT2I = new System.Windows.Forms.BindingSource(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.InicioTarde1_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasT1I = new System.Windows.Forms.BindingSource(this.components);
            this.label31 = new System.Windows.Forms.Label();
            this.FinTarde1_CB = new System.Windows.Forms.ComboBox();
            this.Datos_HorasT1F = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.Pm_NotaExamen_CB = new System.Windows.Forms.CheckBox();
            this.PM_FaltasModulo_CB = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.PM_FaltasModulo_TB = new System.Windows.Forms.TextBox();
            this.Pm_ExamenAprobado_TB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PreguntasDesarrollo_MTB = new System.Windows.Forms.MaskedTextBox();
            this.PreguntasTest_MTB = new System.Windows.Forms.MaskedTextBox();
            label39 = new System.Windows.Forms.Label();
            this.Settings_TP.SuspendLayout();
            this.Idioma_GB.SuspendLayout();
            this.General_TP.SuspendLayout();
            this.DBHosts_GB.SuspendLayout();
            this.FilesHost_GB.SuspendLayout();
            this.Hosts_TP.SuspendLayout();
            this.Backups_TP.SuspendLayout();
            this.Design_GB.SuspendLayout();
            this.Folders_GB.SuspendLayout();
            this.SMTP_GB.SuspendLayout();
            this.Backups_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.Instruccion_TP.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT2F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasMF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT2I)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT1I)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT1F)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings_TP
            // 
            this.Settings_TP.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.Settings_TP.Controls.Add(this.Instruccion_TP);
            this.Settings_TP.ItemSize = new System.Drawing.Size(120, 20);
            this.Settings_TP.Multiline = true;
            this.HelpProvider.SetShowHelp(this.Settings_TP, true);
            this.Settings_TP.Size = new System.Drawing.Size(577, 637);
            this.Settings_TP.Controls.SetChildIndex(this.Instruccion_TP, 0);
            this.Settings_TP.Controls.SetChildIndex(this.Hosts_TP, 0);
            this.Settings_TP.Controls.SetChildIndex(this.Backups_TP, 0);
            this.Settings_TP.Controls.SetChildIndex(this.General_TP, 0);
            // 
            // Idioma_GB
            // 
            this.Idioma_GB.Location = new System.Drawing.Point(197, 164);
            this.HelpProvider.SetShowHelp(this.Idioma_GB, true);
            // 
            // General_TP
            // 
            this.General_TP.Location = new System.Drawing.Point(4, 24);
            this.HelpProvider.SetShowHelp(this.General_TP, true);
            this.General_TP.Size = new System.Drawing.Size(569, 609);
            // 
            // English_RB
            // 
            this.HelpProvider.SetShowHelp(this.English_RB, true);
            // 
            // Spanish_RB
            // 
            this.HelpProvider.SetShowHelp(this.Spanish_RB, true);
            // 
            // Predeterminado_RB
            // 
            this.HelpProvider.SetShowHelp(this.Predeterminado_RB, true);
            // 
            // DBHosts_GB
            // 
            this.DBHosts_GB.Location = new System.Drawing.Point(108, 92);
            this.HelpProvider.SetShowHelp(this.DBHosts_GB, true);
            this.DBHosts_GB.Controls.SetChildIndex(this.LANHost_TB, 0);
            this.DBHosts_GB.Controls.SetChildIndex(this.WANHost_TB, 0);
            // 
            // WANHost_TB
            // 
            this.WANHost_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.WANHost_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.WANHost_TB, true);
            // 
            // LANHost_TB
            // 
            this.LANHost_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.LANHost_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.LANHost_TB, true);
            // 
            // FilesHost_GB
            // 
            this.FilesHost_GB.Location = new System.Drawing.Point(108, 6);
            this.HelpProvider.SetShowHelp(this.FilesHost_GB, true);
            this.FilesHost_GB.Controls.SetChildIndex(this.FilesHost_TB, 0);
            // 
            // FilesHost_TB
            // 
            this.FilesHost_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FilesHost_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.FilesHost_TB, true);
            // 
            // Hosts_TP
            // 
            this.Hosts_TP.Controls.Add(this.groupBox5);
            this.Hosts_TP.Location = new System.Drawing.Point(4, 24);
            this.HelpProvider.SetShowHelp(this.Hosts_TP, true);
            this.Hosts_TP.Size = new System.Drawing.Size(571, 477);
            this.Hosts_TP.Controls.SetChildIndex(this.DBHosts_GB, 0);
            this.Hosts_TP.Controls.SetChildIndex(this.SMTP_GB, 0);
            this.Hosts_TP.Controls.SetChildIndex(this.FilesHost_GB, 0);
            this.Hosts_TP.Controls.SetChildIndex(this.Folders_GB, 0);
            this.Hosts_TP.Controls.SetChildIndex(this.groupBox5, 0);
            // 
            // Backups_TP
            // 
            this.Backups_TP.Location = new System.Drawing.Point(4, 24);
            this.HelpProvider.SetShowHelp(this.Backups_TP, true);
            this.Backups_TP.Size = new System.Drawing.Size(571, 477);
            // 
            // FormatGrids_CkB
            // 
            this.HelpProvider.SetShowHelp(this.FormatGrids_CkB, true);
            // 
            // Design_GB
            // 
            this.Design_GB.Location = new System.Drawing.Point(112, 324);
            this.HelpProvider.SetShowHelp(this.Design_GB, true);
            // 
            // Folders_GB
            // 
            this.Folders_GB.Location = new System.Drawing.Point(7, 332);
            this.HelpProvider.SetShowHelp(this.Folders_GB, true);
            this.Folders_GB.Size = new System.Drawing.Size(555, 83);
            this.Folders_GB.Controls.SetChildIndex(this.PDFPrinstFolder_BT, 0);
            this.Folders_GB.Controls.SetChildIndex(this.PDFPrintsFolder_TB, 0);
            // 
            // PDFPrinstFolder_BT
            // 
            this.PDFPrinstFolder_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.PDFPrinstFolder_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PDFPrinstFolder_BT.Location = new System.Drawing.Point(513, 40);
            this.HelpProvider.SetShowHelp(this.PDFPrinstFolder_BT, true);
            // 
            // PDFPrintsFolder_TB
            // 
            this.PDFPrintsFolder_TB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PDFPrintsFolder_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PDFPrintsFolder_TB.ForeColor = System.Drawing.Color.Black;
            this.PDFPrintsFolder_TB.Location = new System.Drawing.Point(9, 43);
            this.HelpProvider.SetShowHelp(this.PDFPrintsFolder_TB, true);
            this.PDFPrintsFolder_TB.Size = new System.Drawing.Size(498, 21);
            this.PDFPrintsFolder_TB.TabStop = false;
            // 
            // SMTP_GB
            // 
            this.SMTP_GB.Location = new System.Drawing.Point(108, 188);
            this.HelpProvider.SetShowHelp(this.SMTP_GB, true);
            this.SMTP_GB.Controls.SetChildIndex(this.label6, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPPwd_TB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.MostrarPassword_CkB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.label7, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPEnableSSL_CkB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPHost_TB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPPort_TB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPUser_TB, 0);
            this.SMTP_GB.Controls.SetChildIndex(this.SMTPMail_TB, 0);
            // 
            // SMTPUser_TB
            // 
            this.SMTPUser_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SMTPUser_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.SMTPUser_TB, true);
            // 
            // SMTPPort_TB
            // 
            this.SMTPPort_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SMTPPort_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.SMTPPort_TB, true);
            // 
            // SMTPHost_TB
            // 
            this.SMTPHost_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SMTPHost_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.SMTPHost_TB, true);
            // 
            // SMTPMail_TB
            // 
            this.SMTPMail_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SMTPMail_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.SMTPMail_TB, true);
            // 
            // ShowNullRecords_CkB
            // 
            this.HelpProvider.SetShowHelp(this.ShowNullRecords_CkB, true);
            // 
            // BackupsHour_DTP
            // 
            this.HelpProvider.SetShowHelp(this.BackupsHour_DTP, true);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HelpProvider.SetShowHelp(this.label23, true);
            // 
            // BackupsLastDate_DTP
            // 
            this.HelpProvider.SetShowHelp(this.BackupsLastDate_DTP, true);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HelpProvider.SetShowHelp(this.label14, true);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HelpProvider.SetShowHelp(this.label13, true);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HelpProvider.SetShowHelp(this.label12, true);
            // 
            // BackupsDays_TB
            // 
            this.BackupsDays_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BackupsDays_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.BackupsDays_TB, true);
            // 
            // label7
            // 
            this.HelpProvider.SetShowHelp(this.label7, true);
            // 
            // MostrarPassword_CkB
            // 
            this.HelpProvider.SetShowHelp(this.MostrarPassword_CkB, true);
            // 
            // SMTPPwd_TB
            // 
            this.SMTPPwd_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SMTPPwd_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HelpProvider.SetShowHelp(this.SMTPPwd_TB, true);
            // 
            // label6
            // 
            this.HelpProvider.SetShowHelp(this.label6, true);
            // 
            // SMTPEnableSSL_CkB
            // 
            this.HelpProvider.SetShowHelp(this.SMTPEnableSSL_CkB, true);
            // 
            // Backups_GB
            // 
            this.Backups_GB.Location = new System.Drawing.Point(85, 195);
            this.HelpProvider.SetShowHelp(this.Backups_GB, true);
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(156, 9);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(246, 9);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
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
            this.PanelesV.Size = new System.Drawing.Size(579, 679);
            this.PanelesV.SplitterDistance = 639;
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(85, 164);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(579, 679);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(257, 391);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(257, 306);
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new System.Drawing.Font("Tahoma", 8.25F);
            label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label39.Location = new System.Drawing.Point(79, 27);
            label39.Name = "label39";
            this.HelpProvider.SetShowHelp(label39, true);
            label39.Size = new System.Drawing.Size(54, 13);
            label39.TabIndex = 45;
            label39.Text = "FTP Host:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(label39);
            this.groupBox5.Controls.Add(this.FTPHost_TB);
            this.groupBox5.Location = new System.Drawing.Point(108, 461);
            this.groupBox5.Name = "groupBox5";
            this.HelpProvider.SetShowHelp(this.groupBox5, true);
            this.groupBox5.Size = new System.Drawing.Size(352, 69);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Servidor FTP del Gestor Documental";
            // 
            // FTPHost_TB
            // 
            this.FTPHost_TB.Location = new System.Drawing.Point(139, 24);
            this.FTPHost_TB.Name = "FTPHost_TB";
            this.HelpProvider.SetShowHelp(this.FTPHost_TB, true);
            this.FTPHost_TB.Size = new System.Drawing.Size(159, 21);
            this.FTPHost_TB.TabIndex = 44;
            this.FTPHost_TB.TabStop = false;
            // 
            // Instruccion_TP
            // 
            this.Instruccion_TP.Controls.Add(this.groupBox2);
            this.Instruccion_TP.Controls.Add(this.ImpresionEmpresaDefault_BT);
            this.Instruccion_TP.Controls.Add(this.ImpresionEmpresaDefault_TB);
            this.Instruccion_TP.Controls.Add(this.ImpresionEmpresaDefault_CB);
            this.Instruccion_TP.Controls.Add(this.InstructoresAutorizados_CB);
            this.Instruccion_TP.Controls.Add(this.groupBox4);
            this.Instruccion_TP.Controls.Add(this.groupBox1);
            this.Instruccion_TP.Location = new System.Drawing.Point(4, 24);
            this.Instruccion_TP.Name = "Instruccion_TP";
            this.Instruccion_TP.Padding = new System.Windows.Forms.Padding(3);
            this.Instruccion_TP.Size = new System.Drawing.Size(569, 609);
            this.Instruccion_TP.TabIndex = 10;
            this.Instruccion_TP.Text = "Instrucción";
            this.Instruccion_TP.UseVisualStyleBackColor = true;
            // 
            // ImpresionEmpresaDefault_BT
            // 
            this.ImpresionEmpresaDefault_BT.Image = global::moleQule.Face.Application.Properties.Resources.Seleccionar_16;
            this.ImpresionEmpresaDefault_BT.Location = new System.Drawing.Point(418, 570);
            this.ImpresionEmpresaDefault_BT.Name = "ImpresionEmpresaDefault_BT";
            this.ImpresionEmpresaDefault_BT.Size = new System.Drawing.Size(48, 23);
            this.ImpresionEmpresaDefault_BT.TabIndex = 31;
            this.ImpresionEmpresaDefault_BT.UseVisualStyleBackColor = true;
            this.ImpresionEmpresaDefault_BT.Click += new System.EventHandler(this.ImprimirEmpresaDefault_BT_Click);
            // 
            // ImpresionEmpresaDefault_TB
            // 
            this.ImpresionEmpresaDefault_TB.Location = new System.Drawing.Point(80, 570);
            this.ImpresionEmpresaDefault_TB.Name = "ImpresionEmpresaDefault_TB";
            this.ImpresionEmpresaDefault_TB.ReadOnly = true;
            this.ImpresionEmpresaDefault_TB.Size = new System.Drawing.Size(332, 21);
            this.ImpresionEmpresaDefault_TB.TabIndex = 30;
            // 
            // ImpresionEmpresaDefault_CB
            // 
            this.ImpresionEmpresaDefault_CB.Location = new System.Drawing.Point(167, 545);
            this.ImpresionEmpresaDefault_CB.Name = "ImpresionEmpresaDefault_CB";
            this.ImpresionEmpresaDefault_CB.Size = new System.Drawing.Size(232, 17);
            this.ImpresionEmpresaDefault_CB.TabIndex = 29;
            this.ImpresionEmpresaDefault_CB.Text = "Imprimir Datos de Empresa por Defecto";
            this.ImpresionEmpresaDefault_CB.UseVisualStyleBackColor = true;
            // 
            // InstructoresAutorizados_CB
            // 
            this.InstructoresAutorizados_CB.Enabled = false;
            this.InstructoresAutorizados_CB.Location = new System.Drawing.Point(167, 522);
            this.InstructoresAutorizados_CB.Name = "InstructoresAutorizados_CB";
            this.InstructoresAutorizados_CB.Size = new System.Drawing.Size(232, 17);
            this.InstructoresAutorizados_CB.TabIndex = 28;
            this.InstructoresAutorizados_CB.Text = "Mostrar Instructores Autorizados";
            this.InstructoresAutorizados_CB.UseVisualStyleBackColor = true;
            this.InstructoresAutorizados_CB.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.InicioManana_CB);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.FinTarde2_CB);
            this.groupBox4.Controls.Add(this.FinManana_CB);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.InicioTarde2_CB);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.InicioTarde1_CB);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.FinTarde1_CB);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(103, 315);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 165);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Agrupación de horas de Disponibilidad";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(251, 28);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(35, 13);
            this.label37.TabIndex = 35;
            this.label37.Text = "Hasta";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(134, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(37, 13);
            this.label36.TabIndex = 34;
            this.label36.Text = "Desde";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(55, 119);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(41, 13);
            this.label35.TabIndex = 33;
            this.label35.Text = "Tarde2";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(55, 119);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 33;
            this.label32.Text = "Tarde2";
            // 
            // InicioManana_CB
            // 
            this.InicioManana_CB.DataSource = this.Datos_HorasMI;
            this.InicioManana_CB.DisplayMember = "Texto";
            this.InicioManana_CB.FormattingEnabled = true;
            this.InicioManana_CB.Location = new System.Drawing.Point(120, 48);
            this.InicioManana_CB.Name = "InicioManana_CB";
            this.InicioManana_CB.Size = new System.Drawing.Size(75, 21);
            this.InicioManana_CB.TabIndex = 25;
            this.InicioManana_CB.ValueMember = "Oid";
            // 
            // Datos_HorasMI
            // 
            this.Datos_HorasMI.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(120, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // FinTarde2_CB
            // 
            this.FinTarde2_CB.DataSource = this.Datos_HorasT2F;
            this.FinTarde2_CB.DisplayMember = "Texto";
            this.FinTarde2_CB.FormattingEnabled = true;
            this.FinTarde2_CB.Location = new System.Drawing.Point(234, 116);
            this.FinTarde2_CB.Name = "FinTarde2_CB";
            this.FinTarde2_CB.Size = new System.Drawing.Size(75, 21);
            this.FinTarde2_CB.TabIndex = 32;
            this.FinTarde2_CB.ValueMember = "Oid";
            // 
            // Datos_HorasT2F
            // 
            this.Datos_HorasT2F.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // FinManana_CB
            // 
            this.FinManana_CB.DataSource = this.Datos_HorasMF;
            this.FinManana_CB.DisplayMember = "Texto";
            this.FinManana_CB.FormattingEnabled = true;
            this.FinManana_CB.Location = new System.Drawing.Point(234, 48);
            this.FinManana_CB.Name = "FinManana_CB";
            this.FinManana_CB.Size = new System.Drawing.Size(75, 21);
            this.FinManana_CB.TabIndex = 26;
            this.FinManana_CB.ValueMember = "Oid";
            // 
            // Datos_HorasMF
            // 
            this.Datos_HorasMF.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(234, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 21);
            this.comboBox2.TabIndex = 26;
            // 
            // InicioTarde2_CB
            // 
            this.InicioTarde2_CB.DataSource = this.Datos_HorasT2I;
            this.InicioTarde2_CB.DisplayMember = "Texto";
            this.InicioTarde2_CB.FormattingEnabled = true;
            this.InicioTarde2_CB.Location = new System.Drawing.Point(120, 116);
            this.InicioTarde2_CB.Name = "InicioTarde2_CB";
            this.InicioTarde2_CB.Size = new System.Drawing.Size(75, 21);
            this.InicioTarde2_CB.TabIndex = 31;
            this.InicioTarde2_CB.ValueMember = "Oid";
            // 
            // Datos_HorasT2I
            // 
            this.Datos_HorasT2I.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(55, 51);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(45, 13);
            this.label30.TabIndex = 27;
            this.label30.Text = "Mañana";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(55, 85);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 13);
            this.label34.TabIndex = 30;
            this.label34.Text = "Tarde1";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(55, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(45, 13);
            this.label33.TabIndex = 27;
            this.label33.Text = "Mañana";
            // 
            // InicioTarde1_CB
            // 
            this.InicioTarde1_CB.DataSource = this.Datos_HorasT1I;
            this.InicioTarde1_CB.DisplayMember = "Texto";
            this.InicioTarde1_CB.FormattingEnabled = true;
            this.InicioTarde1_CB.Location = new System.Drawing.Point(120, 82);
            this.InicioTarde1_CB.Name = "InicioTarde1_CB";
            this.InicioTarde1_CB.Size = new System.Drawing.Size(75, 21);
            this.InicioTarde1_CB.TabIndex = 28;
            this.InicioTarde1_CB.ValueMember = "Oid";
            // 
            // Datos_HorasT1I
            // 
            this.Datos_HorasT1I.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(55, 85);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 13);
            this.label31.TabIndex = 30;
            this.label31.Text = "Tarde1";
            // 
            // FinTarde1_CB
            // 
            this.FinTarde1_CB.DataSource = this.Datos_HorasT1F;
            this.FinTarde1_CB.DisplayMember = "Texto";
            this.FinTarde1_CB.FormattingEnabled = true;
            this.FinTarde1_CB.Location = new System.Drawing.Point(234, 82);
            this.FinTarde1_CB.Name = "FinTarde1_CB";
            this.FinTarde1_CB.Size = new System.Drawing.Size(75, 21);
            this.FinTarde1_CB.TabIndex = 29;
            this.FinTarde1_CB.ValueMember = "Oid";
            // 
            // Datos_HorasT1F
            // 
            this.Datos_HorasT1F.DataSource = typeof(moleQule.Library.HComboBoxSourceList);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(234, 82);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(75, 21);
            this.comboBox3.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.Pm_NotaExamen_CB);
            this.groupBox1.Controls.Add(this.PM_FaltasModulo_CB);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.PM_FaltasModulo_TB);
            this.groupBox1.Controls.Add(this.Pm_ExamenAprobado_TB);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(101, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 131);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios para filtrado listado de alumnos a examen";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(309, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 13);
            this.label29.TabIndex = 26;
            this.label29.Text = "Activo";
            // 
            // Pm_NotaExamen_CB
            // 
            this.Pm_NotaExamen_CB.AutoSize = true;
            this.Pm_NotaExamen_CB.Location = new System.Drawing.Point(322, 88);
            this.Pm_NotaExamen_CB.Name = "Pm_NotaExamen_CB";
            this.Pm_NotaExamen_CB.Size = new System.Drawing.Size(15, 14);
            this.Pm_NotaExamen_CB.TabIndex = 25;
            this.Pm_NotaExamen_CB.UseVisualStyleBackColor = true;
            // 
            // PM_FaltasModulo_CB
            // 
            this.PM_FaltasModulo_CB.AutoSize = true;
            this.PM_FaltasModulo_CB.Location = new System.Drawing.Point(322, 54);
            this.PM_FaltasModulo_CB.Name = "PM_FaltasModulo_CB";
            this.PM_FaltasModulo_CB.Size = new System.Drawing.Size(15, 14);
            this.PM_FaltasModulo_CB.TabIndex = 24;
            this.PM_FaltasModulo_CB.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(21, 54);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(199, 13);
            this.label28.TabIndex = 22;
            this.label28.Text = "Porcentaje máximo de faltas por módulo";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 87);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(194, 13);
            this.label27.TabIndex = 23;
            this.label27.Text = "Nota mínima para aprobar examen (%)";
            // 
            // PM_FaltasModulo_TB
            // 
            this.PM_FaltasModulo_TB.Location = new System.Drawing.Point(226, 51);
            this.PM_FaltasModulo_TB.Name = "PM_FaltasModulo_TB";
            this.PM_FaltasModulo_TB.Size = new System.Drawing.Size(51, 21);
            this.PM_FaltasModulo_TB.TabIndex = 20;
            // 
            // Pm_ExamenAprobado_TB
            // 
            this.Pm_ExamenAprobado_TB.Location = new System.Drawing.Point(226, 84);
            this.Pm_ExamenAprobado_TB.Name = "Pm_ExamenAprobado_TB";
            this.Pm_ExamenAprobado_TB.Size = new System.Drawing.Size(51, 21);
            this.Pm_ExamenAprobado_TB.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PreguntasTest_MTB);
            this.groupBox2.Controls.Add(this.PreguntasDesarrollo_MTB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(101, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 131);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Establecer tiempo de Preguntas de Examen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Preguntas de Tipo Desarrollo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Preguntas de Tipo Test";
            // 
            // PreguntasDesarrollo_MTB
            // 
            this.PreguntasDesarrollo_MTB.Location = new System.Drawing.Point(226, 46);
            this.PreguntasDesarrollo_MTB.Mask = "00:00:00";
            this.PreguntasDesarrollo_MTB.Name = "PreguntasDesarrollo_MTB";
            this.PreguntasDesarrollo_MTB.Size = new System.Drawing.Size(62, 21);
            this.PreguntasDesarrollo_MTB.TabIndex = 24;
            // 
            // PreguntasTest_MTB
            // 
            this.PreguntasTest_MTB.Location = new System.Drawing.Point(226, 79);
            this.PreguntasTest_MTB.Mask = "00:00:00";
            this.PreguntasTest_MTB.Name = "PreguntasTest_MTB";
            this.PreguntasTest_MTB.Size = new System.Drawing.Size(62, 21);
            this.PreguntasTest_MTB.TabIndex = 25;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(579, 679);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "SettingsForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Controls.SetChildIndex(this.ProgressInfo_PB, 0);
            this.Controls.SetChildIndex(this.Progress_PB, 0);
            this.Controls.SetChildIndex(this.ProgressBK_Panel, 0);
            this.Controls.SetChildIndex(this.PanelesV, 0);
            this.Settings_TP.ResumeLayout(false);
            this.Idioma_GB.ResumeLayout(false);
            this.Idioma_GB.PerformLayout();
            this.General_TP.ResumeLayout(false);
            this.DBHosts_GB.ResumeLayout(false);
            this.DBHosts_GB.PerformLayout();
            this.FilesHost_GB.ResumeLayout(false);
            this.FilesHost_GB.PerformLayout();
            this.Hosts_TP.ResumeLayout(false);
            this.Backups_TP.ResumeLayout(false);
            this.Design_GB.ResumeLayout(false);
            this.Folders_GB.ResumeLayout(false);
            this.Folders_GB.PerformLayout();
            this.SMTP_GB.ResumeLayout(false);
            this.SMTP_GB.PerformLayout();
            this.Backups_GB.ResumeLayout(false);
            this.Backups_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.Instruccion_TP.ResumeLayout(false);
            this.Instruccion_TP.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT2F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasMF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT2I)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT1I)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_HorasT1F)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox5;
        protected System.Windows.Forms.TextBox FTPHost_TB;
        private System.Windows.Forms.TabPage Instruccion_TP;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Pm_ExamenAprobado_TB;
        private System.Windows.Forms.TextBox PM_FaltasModulo_TB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox Pm_NotaExamen_CB;
        private System.Windows.Forms.CheckBox PM_FaltasModulo_CB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox InicioManana_CB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox FinTarde2_CB;
        private System.Windows.Forms.ComboBox FinManana_CB;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox InicioTarde2_CB;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox InicioTarde1_CB;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox FinTarde1_CB;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.BindingSource Datos_HorasMI;
        private System.Windows.Forms.BindingSource Datos_HorasT2F;
        private System.Windows.Forms.BindingSource Datos_HorasMF;
        private System.Windows.Forms.BindingSource Datos_HorasT2I;
        private System.Windows.Forms.BindingSource Datos_HorasT1I;
        private System.Windows.Forms.BindingSource Datos_HorasT1F;
        private System.Windows.Forms.CheckBox InstructoresAutorizados_CB;
        private System.Windows.Forms.Button ImpresionEmpresaDefault_BT;
        private System.Windows.Forms.TextBox ImpresionEmpresaDefault_TB;
        private System.Windows.Forms.CheckBox ImpresionEmpresaDefault_CB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox PreguntasTest_MTB;
        private System.Windows.Forms.MaskedTextBox PreguntasDesarrollo_MTB;
    }
}
