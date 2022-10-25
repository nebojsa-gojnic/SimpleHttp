namespace SimpleHttp
{
	partial class StartServerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartServerForm));
			this.cmdStartOnResources = new System.Windows.Forms.Button();
			this.cmdStartOnFiles = new System.Windows.Forms.Button();
			this.gbFilePath = new System.Windows.Forms.GroupBox();
			this.cmdSelectPath = new System.Windows.Forms.Button();
			this.tbWebroot = new System.Windows.Forms.TextBox();
			this.gpPort = new System.Windows.Forms.GroupBox();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.folders = new System.Windows.Forms.FolderBrowserDialog();
			this.gbAssemblies = new System.Windows.Forms.GroupBox();
			this.cmdLoadAssembly = new System.Windows.Forms.Button();
			this.cbAssemblies = new System.Windows.Forms.ComboBox();
			this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.startPanel = new System.Windows.Forms.Panel();
			this.cmdStart = new System.Windows.Forms.Button();
			this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.gbCertificate = new System.Windows.Forms.GroupBox();
			this.cmdSelectCertificate = new System.Windows.Forms.Button();
			this.cbNoCertificate = new System.Windows.Forms.CheckBox();
			this.tbCertificate = new System.Windows.Forms.TextBox();
			this.openAssemblyDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
			this.openCertificateDialog = new System.Windows.Forms.OpenFileDialog();
			this.passwordPanel = new System.Windows.Forms.Panel();
			this.gbPassword = new System.Windows.Forms.GroupBox();
			this.cmdCancelSslTest = new System.Windows.Forms.Button();
			this.cmdAcceptPassword = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.gbFilePath.SuspendLayout();
			this.gpPort.SuspendLayout();
			this.gbAssemblies.SuspendLayout();
			this.buttonLayout.SuspendLayout();
			this.startPanel.SuspendLayout();
			this.mainLayout.SuspendLayout();
			this.gbCertificate.SuspendLayout();
			this.passwordPanel.SuspendLayout();
			this.gbPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdStartOnResources
			// 
			this.cmdStartOnResources.Location = new System.Drawing.Point(217, 4);
			this.cmdStartOnResources.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
			this.cmdStartOnResources.Name = "cmdStartOnResources";
			this.cmdStartOnResources.Size = new System.Drawing.Size(211, 73);
			this.cmdStartOnResources.TabIndex = 0;
			this.cmdStartOnResources.TabStop = false;
			this.cmdStartOnResources.Text = "&Resource based server";
			this.cmdStartOnResources.UseVisualStyleBackColor = true;
			this.cmdStartOnResources.Click += new System.EventHandler(this.cmdStartOnResources_Click);
			// 
			// cmdStartOnFiles
			// 
			this.cmdStartOnFiles.Location = new System.Drawing.Point(0, 4);
			this.cmdStartOnFiles.Margin = new System.Windows.Forms.Padding(0, 4, 3, 4);
			this.cmdStartOnFiles.Name = "cmdStartOnFiles";
			this.cmdStartOnFiles.Size = new System.Drawing.Size(211, 73);
			this.cmdStartOnFiles.TabIndex = 1;
			this.cmdStartOnFiles.TabStop = false;
			this.cmdStartOnFiles.Text = "&File based server";
			this.cmdStartOnFiles.UseVisualStyleBackColor = true;
			this.cmdStartOnFiles.Click += new System.EventHandler(this.cmdStartOnFiles_Click);
			// 
			// gbFilePath
			// 
			this.gbFilePath.Controls.Add(this.cmdSelectPath);
			this.gbFilePath.Controls.Add(this.tbWebroot);
			this.gbFilePath.Location = new System.Drawing.Point(8, 99);
			this.gbFilePath.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbFilePath.Name = "gbFilePath";
			this.gbFilePath.Padding = new System.Windows.Forms.Padding(0);
			this.gbFilePath.Size = new System.Drawing.Size(432, 74);
			this.gbFilePath.TabIndex = 1;
			this.gbFilePath.TabStop = false;
			this.gbFilePath.Text = " Local disk &path: ";
			this.gbFilePath.Visible = false;
			// 
			// cmdSelectPath
			// 
			this.cmdSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectPath.Location = new System.Drawing.Point(380, 30);
			this.cmdSelectPath.Name = "cmdSelectPath";
			this.cmdSelectPath.Size = new System.Drawing.Size(40, 27);
			this.cmdSelectPath.TabIndex = 1;
			this.cmdSelectPath.TabStop = false;
			this.cmdSelectPath.Text = "...";
			this.cmdSelectPath.UseVisualStyleBackColor = true;
			this.cmdSelectPath.Click += new System.EventHandler(this.cmdSelectPath_Click);
			this.cmdSelectPath.Resize += new System.EventHandler(this.cmdSelectFolder_Resize);
			// 
			// tbWebroot
			// 
			this.tbWebroot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWebroot.Location = new System.Drawing.Point(12, 30);
			this.tbWebroot.Margin = new System.Windows.Forms.Padding(0);
			this.tbWebroot.Name = "tbWebroot";
			this.tbWebroot.Size = new System.Drawing.Size(373, 27);
			this.tbWebroot.TabIndex = 0;
			this.tbWebroot.Text = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			// 
			// gpPort
			// 
			this.gpPort.Controls.Add(this.tbPort);
			this.gpPort.Dock = System.Windows.Forms.DockStyle.Left;
			this.gpPort.Location = new System.Drawing.Point(0, 0);
			this.gpPort.Name = "gpPort";
			this.gpPort.Padding = new System.Windows.Forms.Padding(0);
			this.gpPort.Size = new System.Drawing.Size(143, 74);
			this.gpPort.TabIndex = 4;
			this.gpPort.TabStop = false;
			this.gpPort.Text = " &Port: ";
			// 
			// tbPort
			// 
			this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPort.Location = new System.Drawing.Point(12, 32);
			this.tbPort.Margin = new System.Windows.Forms.Padding(0);
			this.tbPort.MaxLength = 5;
			this.tbPort.Name = "tbPort";
			this.tbPort.PlaceholderText = "1-65535";
			this.tbPort.Size = new System.Drawing.Size(119, 27);
			this.tbPort.TabIndex = 0;
			this.tbPort.Text = "50080";
			this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
			this.tbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPort_KeyPress);
			// 
			// folders
			// 
			this.folders.SelectedPath = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			this.folders.ShowNewFolderButton = false;
			// 
			// gbAssemblies
			// 
			this.gbAssemblies.Controls.Add(this.cmdLoadAssembly);
			this.gbAssemblies.Controls.Add(this.cbAssemblies);
			this.gbAssemblies.Location = new System.Drawing.Point(8, 177);
			this.gbAssemblies.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbAssemblies.Name = "gbAssemblies";
			this.gbAssemblies.Padding = new System.Windows.Forms.Padding(0);
			this.gbAssemblies.Size = new System.Drawing.Size(432, 74);
			this.gbAssemblies.TabIndex = 2;
			this.gbAssemblies.TabStop = false;
			this.gbAssemblies.Text = " Assemblies: ";
			this.gbAssemblies.Visible = false;
			// 
			// cmdLoadAssembly
			// 
			this.cmdLoadAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdLoadAssembly.Location = new System.Drawing.Point(380, 30);
			this.cmdLoadAssembly.Margin = new System.Windows.Forms.Padding(0);
			this.cmdLoadAssembly.Name = "cmdLoadAssembly";
			this.cmdLoadAssembly.Size = new System.Drawing.Size(40, 27);
			this.cmdLoadAssembly.TabIndex = 4;
			this.cmdLoadAssembly.TabStop = false;
			this.cmdLoadAssembly.Text = "...";
			this.cmdLoadAssembly.UseVisualStyleBackColor = true;
			this.cmdLoadAssembly.Click += new System.EventHandler(this.cmdLoadAssembly_Click);
			// 
			// cbAssemblies
			// 
			this.cbAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAssemblies.IntegralHeight = false;
			this.cbAssemblies.Location = new System.Drawing.Point(12, 30);
			this.cbAssemblies.Margin = new System.Windows.Forms.Padding(0);
			this.cbAssemblies.MaxDropDownItems = 12;
			this.cbAssemblies.Name = "cbAssemblies";
			this.cbAssemblies.Size = new System.Drawing.Size(408, 28);
			this.cbAssemblies.TabIndex = 0;
			this.cbAssemblies.DropDown += new System.EventHandler(this.cbAssemblies_DropDown);
			this.cbAssemblies.SelectedIndexChanged += new System.EventHandler(this.cbAssemblies_SelectedIndexChanged);
			this.cbAssemblies.DropDownClosed += new System.EventHandler(this.cbAssemblies_DropDownClosed);
			this.cbAssemblies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAssemblies_KeyDown);
			this.cbAssemblies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAssemblies_KeyPress);
			// 
			// buttonLayout
			// 
			this.buttonLayout.AutoSize = true;
			this.buttonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonLayout.Controls.Add(this.cmdStartOnFiles);
			this.buttonLayout.Controls.Add(this.cmdStartOnResources);
			this.buttonLayout.Location = new System.Drawing.Point(11, 11);
			this.buttonLayout.Name = "buttonLayout";
			this.buttonLayout.Size = new System.Drawing.Size(428, 81);
			this.buttonLayout.TabIndex = 5;
			this.buttonLayout.WrapContents = false;
			// 
			// startPanel
			// 
			this.startPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.startPanel.Controls.Add(this.gpPort);
			this.startPanel.Controls.Add(this.cmdStart);
			this.startPanel.Location = new System.Drawing.Point(11, 363);
			this.startPanel.Name = "startPanel";
			this.startPanel.Size = new System.Drawing.Size(429, 74);
			this.startPanel.TabIndex = 6;
			// 
			// cmdStart
			// 
			this.cmdStart.Location = new System.Drawing.Point(282, 0);
			this.cmdStart.Margin = new System.Windows.Forms.Padding(0);
			this.cmdStart.Name = "cmdStart";
			this.cmdStart.Size = new System.Drawing.Size(146, 73);
			this.cmdStart.TabIndex = 1;
			this.cmdStart.TabStop = false;
			this.cmdStart.Text = "Start";
			this.cmdStart.UseVisualStyleBackColor = true;
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			// 
			// mainLayout
			// 
			this.mainLayout.AutoSize = true;
			this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainLayout.Controls.Add(this.buttonLayout);
			this.mainLayout.Controls.Add(this.gbFilePath);
			this.mainLayout.Controls.Add(this.gbAssemblies);
			this.mainLayout.Controls.Add(this.gbCertificate);
			this.mainLayout.Controls.Add(this.startPanel);
			this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(8);
			this.mainLayout.Size = new System.Drawing.Size(451, 448);
			this.mainLayout.TabIndex = 7;
			this.mainLayout.WrapContents = false;
			// 
			// gbCertificate
			// 
			this.gbCertificate.Controls.Add(this.cmdSelectCertificate);
			this.gbCertificate.Controls.Add(this.cbNoCertificate);
			this.gbCertificate.Controls.Add(this.tbCertificate);
			this.gbCertificate.Location = new System.Drawing.Point(8, 259);
			this.gbCertificate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
			this.gbCertificate.Name = "gbCertificate";
			this.gbCertificate.Padding = new System.Windows.Forms.Padding(0);
			this.gbCertificate.Size = new System.Drawing.Size(432, 93);
			this.gbCertificate.TabIndex = 3;
			this.gbCertificate.TabStop = false;
			this.gbCertificate.Text = " Load SSL certifcate from: ";
			this.gbCertificate.Resize += new System.EventHandler(this.gbCertificate_Resize);
			// 
			// cmdSelectCertificate
			// 
			this.cmdSelectCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectCertificate.Location = new System.Drawing.Point(380, 30);
			this.cmdSelectCertificate.Margin = new System.Windows.Forms.Padding(0);
			this.cmdSelectCertificate.Name = "cmdSelectCertificate";
			this.cmdSelectCertificate.Size = new System.Drawing.Size(40, 27);
			this.cmdSelectCertificate.TabIndex = 3;
			this.cmdSelectCertificate.TabStop = false;
			this.cmdSelectCertificate.Text = "...";
			this.cmdSelectCertificate.UseVisualStyleBackColor = true;
			this.cmdSelectCertificate.Click += new System.EventHandler(this.cmdSelectCertificate_Click);
			// 
			// cbNoCertificate
			// 
			this.cbNoCertificate.AutoSize = true;
			this.cbNoCertificate.Checked = true;
			this.cbNoCertificate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNoCertificate.Location = new System.Drawing.Point(11, 61);
			this.cbNoCertificate.Name = "cbNoCertificate";
			this.cbNoCertificate.Size = new System.Drawing.Size(143, 24);
			this.cbNoCertificate.TabIndex = 2;
			this.cbNoCertificate.Text = "&No SSL, flat HTTP";
			this.cbNoCertificate.UseVisualStyleBackColor = true;
			this.cbNoCertificate.CheckedChanged += new System.EventHandler(this.cbNoCertificate_CheckedChanged);
			// 
			// tbCertificate
			// 
			this.tbCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCertificate.Enabled = false;
			this.tbCertificate.Location = new System.Drawing.Point(12, 30);
			this.tbCertificate.Margin = new System.Windows.Forms.Padding(0);
			this.tbCertificate.Name = "tbCertificate";
			this.tbCertificate.Size = new System.Drawing.Size(408, 27);
			this.tbCertificate.TabIndex = 0;
			this.tbCertificate.Text = "C:\\Code\\localhost2.pfx";
			// 
			// openAssemblyDialog
			// 
			this.openAssemblyDialog.DefaultExt = "dll";
			this.openAssemblyDialog.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.e" +
    "xe|Any|*.*";
			this.openAssemblyDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "dll";
			this.openFileDialog1.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.e" +
    "xe|Any|*.*";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.DefaultExt = "dll";
			this.openFileDialog2.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.e" +
    "xe|Any|*.*";
			// 
			// openFileDialog3
			// 
			this.openFileDialog3.DefaultExt = "dll";
			this.openFileDialog3.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.e" +
    "xe|Any|*.*";
			// 
			// openCertificateDialog
			// 
			this.openCertificateDialog.Filter = "Default (*.cer,*.pfx)|*.cer;*.pfx|Certificate file format (*.cer)|*.cer|Personal " +
    "Information Exchange (*.pkx)|*.pfx|All files(*.*)|*.*";
			this.openCertificateDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
			// 
			// passwordPanel
			// 
			this.passwordPanel.Controls.Add(this.gbPassword);
			this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.passwordPanel.Location = new System.Drawing.Point(0, 0);
			this.passwordPanel.Name = "passwordPanel";
			this.passwordPanel.Size = new System.Drawing.Size(452, 457);
			this.passwordPanel.TabIndex = 9;
			this.passwordPanel.Visible = false;
			this.passwordPanel.Click += new System.EventHandler(this.passwordPanel_Click);
			this.passwordPanel.Resize += new System.EventHandler(this.passwordPanel_Resize);
			// 
			// gbPassword
			// 
			this.gbPassword.Controls.Add(this.cmdCancelSslTest);
			this.gbPassword.Controls.Add(this.cmdAcceptPassword);
			this.gbPassword.Controls.Add(this.tbPassword);
			this.gbPassword.Location = new System.Drawing.Point(11, 82);
			this.gbPassword.Margin = new System.Windows.Forms.Padding(0);
			this.gbPassword.Name = "gbPassword";
			this.gbPassword.Padding = new System.Windows.Forms.Padding(0);
			this.gbPassword.Size = new System.Drawing.Size(391, 74);
			this.gbPassword.TabIndex = 9;
			this.gbPassword.TabStop = false;
			this.gbPassword.Text = " Certificate file password(it can be empty): ";
			// 
			// cmdCancelSslTest
			// 
			this.cmdCancelSslTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancelSslTest.AutoSize = true;
			this.cmdCancelSslTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdCancelSslTest.Location = new System.Drawing.Point(311, 30);
			this.cmdCancelSslTest.Margin = new System.Windows.Forms.Padding(0);
			this.cmdCancelSslTest.Name = "cmdCancelSslTest";
			this.cmdCancelSslTest.Size = new System.Drawing.Size(71, 30);
			this.cmdCancelSslTest.TabIndex = 2;
			this.cmdCancelSslTest.TabStop = false;
			this.cmdCancelSslTest.Text = " Cancel ";
			this.cmdCancelSslTest.UseVisualStyleBackColor = true;
			this.cmdCancelSslTest.Click += new System.EventHandler(this.cmdCancelSslTest_Click);
			// 
			// cmdAcceptPassword
			// 
			this.cmdAcceptPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAcceptPassword.AutoSize = true;
			this.cmdAcceptPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdAcceptPassword.Location = new System.Drawing.Point(240, 30);
			this.cmdAcceptPassword.Margin = new System.Windows.Forms.Padding(0);
			this.cmdAcceptPassword.Name = "cmdAcceptPassword";
			this.cmdAcceptPassword.Size = new System.Drawing.Size(63, 30);
			this.cmdAcceptPassword.TabIndex = 1;
			this.cmdAcceptPassword.TabStop = false;
			this.cmdAcceptPassword.Text = "   OK   ";
			this.cmdAcceptPassword.UseVisualStyleBackColor = true;
			this.cmdAcceptPassword.Click += new System.EventHandler(this.cmdAcceptPassword_Click);
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(9, 31);
			this.tbPassword.Margin = new System.Windows.Forms.Padding(0);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '#';
			this.tbPassword.Size = new System.Drawing.Size(223, 27);
			this.tbPassword.TabIndex = 0;
			this.tbPassword.Text = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
			// 
			// StartServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(452, 457);
			this.Controls.Add(this.mainLayout);
			this.Controls.Add(this.passwordPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartServerForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Http Server Startup";
			this.gbFilePath.ResumeLayout(false);
			this.gbFilePath.PerformLayout();
			this.gpPort.ResumeLayout(false);
			this.gpPort.PerformLayout();
			this.gbAssemblies.ResumeLayout(false);
			this.buttonLayout.ResumeLayout(false);
			this.startPanel.ResumeLayout(false);
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.gbCertificate.ResumeLayout(false);
			this.gbCertificate.PerformLayout();
			this.passwordPanel.ResumeLayout(false);
			this.gbPassword.ResumeLayout(false);
			this.gbPassword.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private Button cmdStartOnResources;
        private Button cmdStartOnFiles;
        private GroupBox gbFilePath;
        private TextBox tbWebroot;
        private GroupBox gpPort;
        private TextBox tbPort;
		private Button cmdSelectPath;
        private FolderBrowserDialog folders;
        private GroupBox gbAssemblies;
        private ComboBox cbAssemblies;
        private FlowLayoutPanel buttonLayout;
        private Panel startPanel;
        private Button cmdStart;
        private FlowLayoutPanel mainLayout;
        private OpenFileDialog openAssemblyDialog;
        private GroupBox gbCertificate;
        private TextBox tbCertificate;
        private CheckBox cbNoCertificate;
        private Button cmdSelectCertificate;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private OpenFileDialog openCertificateDialog;
        private Panel passwordPanel;
        private GroupBox gbPassword;
        private Button cmdAcceptPassword;
        private TextBox tbPassword;
        private Button cmdCancelSslTest;
		private Button cmdLoadAssembly;
	}
}