namespace SimpleHttp
{
	partial class StartServerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartServerForm));
			this.cmdResourceMode = new System.Windows.Forms.Button();
			this.cmdFileMode = new System.Windows.Forms.Button();
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
			this.gbProtocol = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cbProtocol = new System.Windows.Forms.ComboBox();
			this.gbCertificate = new System.Windows.Forms.GroupBox();
			this.cmdSelectCertificate = new System.Windows.Forms.Button();
			this.tbCertificate = new System.Windows.Forms.TextBox();
			this.openAssemblyDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
			this.openCertificateDialog = new System.Windows.Forms.OpenFileDialog();
			this.passwordPanel = new System.Windows.Forms.Panel();
			this.gbSiteName = new System.Windows.Forms.GroupBox();
			this.clientTargetPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.clientTaragetLabel = new System.Windows.Forms.Label();
			this.clientTaragetText = new System.Windows.Forms.Label();
			this.cmdCancelSslTest = new System.Windows.Forms.Button();
			this.cmdStartCertificateTest = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tbSiteName = new System.Windows.Forms.TextBox();
			this.gbPassword = new System.Windows.Forms.GroupBox();
			this.cmdClosePasswordPanel = new System.Windows.Forms.Button();
			this.cmdAcceptPassword = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.gbFilePath.SuspendLayout();
			this.gpPort.SuspendLayout();
			this.gbAssemblies.SuspendLayout();
			this.buttonLayout.SuspendLayout();
			this.startPanel.SuspendLayout();
			this.mainLayout.SuspendLayout();
			this.gbProtocol.SuspendLayout();
			this.gbCertificate.SuspendLayout();
			this.passwordPanel.SuspendLayout();
			this.gbSiteName.SuspendLayout();
			this.clientTargetPanel.SuspendLayout();
			this.gbPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdResourceMode
			// 
			this.cmdResourceMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.cmdResourceMode.Location = new System.Drawing.Point(217, 4);
			this.cmdResourceMode.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
			this.cmdResourceMode.Name = "cmdResourceMode";
			this.cmdResourceMode.Size = new System.Drawing.Size(211, 73);
			this.cmdResourceMode.TabIndex = 0;
			this.cmdResourceMode.TabStop = false;
			this.cmdResourceMode.Text = "&Resource based server";
			this.cmdResourceMode.UseVisualStyleBackColor = true;
			this.cmdResourceMode.Click += new System.EventHandler(this.cmdResourceMode_Click);
			// 
			// cmdFileMode
			// 
			this.cmdFileMode.Location = new System.Drawing.Point(0, 4);
			this.cmdFileMode.Margin = new System.Windows.Forms.Padding(0, 4, 3, 4);
			this.cmdFileMode.Name = "cmdFileMode";
			this.cmdFileMode.Size = new System.Drawing.Size(211, 73);
			this.cmdFileMode.TabIndex = 1;
			this.cmdFileMode.TabStop = false;
			this.cmdFileMode.Text = "&File based server";
			this.cmdFileMode.UseVisualStyleBackColor = true;
			this.cmdFileMode.Click += new System.EventHandler(this.cmdFileMode_Click);
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
			this.tbWebroot.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbWebroot.Location = new System.Drawing.Point(12, 30);
			this.tbWebroot.Margin = new System.Windows.Forms.Padding(0);
			this.tbWebroot.Name = "tbWebroot";
			this.tbWebroot.Size = new System.Drawing.Size(373, 27);
			this.tbWebroot.TabIndex = 0;
			this.tbWebroot.Text = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			this.tbWebroot.Enter += new System.EventHandler(this.tbWebroot_Enter);
			this.tbWebroot.Leave += new System.EventHandler(this.tbWebroot_Leave);
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
			this.tbPort.BackColor = System.Drawing.SystemColors.ControlLight;
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
			this.tbPort.Enter += new System.EventHandler(this.tbPort_Enter);
			this.tbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPort_KeyPress);
			this.tbPort.Leave += new System.EventHandler(this.tbPort_Leave);
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
			this.cbAssemblies.BackColor = System.Drawing.SystemColors.ControlLight;
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
			this.cbAssemblies.Enter += new System.EventHandler(this.cbAssemblies_Enter);
			this.cbAssemblies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAssemblies_KeyDown);
			this.cbAssemblies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAssemblies_KeyPress);
			this.cbAssemblies.Leave += new System.EventHandler(this.cbAssemblies_Leave);
			// 
			// buttonLayout
			// 
			this.buttonLayout.AutoSize = true;
			this.buttonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonLayout.Controls.Add(this.cmdFileMode);
			this.buttonLayout.Controls.Add(this.cmdResourceMode);
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
			this.startPanel.Location = new System.Drawing.Point(11, 422);
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
			this.mainLayout.Controls.Add(this.gbProtocol);
			this.mainLayout.Controls.Add(this.gbCertificate);
			this.mainLayout.Controls.Add(this.startPanel);
			this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(8);
			this.mainLayout.Size = new System.Drawing.Size(451, 507);
			this.mainLayout.TabIndex = 7;
			this.mainLayout.WrapContents = false;
			// 
			// gbProtocol
			// 
			this.gbProtocol.Controls.Add(this.button1);
			this.gbProtocol.Controls.Add(this.cbProtocol);
			this.gbProtocol.Location = new System.Drawing.Point(8, 255);
			this.gbProtocol.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbProtocol.Name = "gbProtocol";
			this.gbProtocol.Padding = new System.Windows.Forms.Padding(0);
			this.gbProtocol.Size = new System.Drawing.Size(432, 74);
			this.gbProtocol.TabIndex = 7;
			this.gbProtocol.TabStop = false;
			this.gbProtocol.Text = "Security protocol:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(615, 27);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 27);
			this.button1.TabIndex = 4;
			this.button1.TabStop = false;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// cbProtocol
			// 
			this.cbProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbProtocol.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cbProtocol.IntegralHeight = false;
			this.cbProtocol.Location = new System.Drawing.Point(12, 30);
			this.cbProtocol.Margin = new System.Windows.Forms.Padding(0);
			this.cbProtocol.MaxDropDownItems = 12;
			this.cbProtocol.Name = "cbProtocol";
			this.cbProtocol.Size = new System.Drawing.Size(408, 28);
			this.cbProtocol.TabIndex = 0;
			this.cbProtocol.SelectedIndexChanged += new System.EventHandler(this.cbProtocol_SelectedIndexChanged);
			this.cbProtocol.TextChanged += new System.EventHandler(this.cbProtocol_TextChanged);
			this.cbProtocol.Enter += new System.EventHandler(this.cbProtocol_Enter);
			this.cbProtocol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProtocol_KeyDown);
			this.cbProtocol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProtocol_KeyPress);
			this.cbProtocol.Leave += new System.EventHandler(this.cbProtocol_Leave);
			// 
			// gbCertificate
			// 
			this.gbCertificate.Controls.Add(this.cmdSelectCertificate);
			this.gbCertificate.Controls.Add(this.tbCertificate);
			this.gbCertificate.Enabled = false;
			this.gbCertificate.Location = new System.Drawing.Point(8, 337);
			this.gbCertificate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
			this.gbCertificate.Name = "gbCertificate";
			this.gbCertificate.Padding = new System.Windows.Forms.Padding(0);
			this.gbCertificate.Size = new System.Drawing.Size(432, 74);
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
			// tbCertificate
			// 
			this.tbCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCertificate.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbCertificate.Location = new System.Drawing.Point(12, 30);
			this.tbCertificate.Margin = new System.Windows.Forms.Padding(0);
			this.tbCertificate.Name = "tbCertificate";
			this.tbCertificate.Size = new System.Drawing.Size(408, 27);
			this.tbCertificate.TabIndex = 0;
			this.tbCertificate.Text = "C:\\Code\\localhost2.pfx";
			this.tbCertificate.TextChanged += new System.EventHandler(this.tbCertificate_TextChanged);
			this.tbCertificate.Enter += new System.EventHandler(this.tbCertificate_Enter);
			this.tbCertificate.Leave += new System.EventHandler(this.tbCertificate_Leave);
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
			this.passwordPanel.Controls.Add(this.gbSiteName);
			this.passwordPanel.Controls.Add(this.gbPassword);
			this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.passwordPanel.Location = new System.Drawing.Point(0, 0);
			this.passwordPanel.Name = "passwordPanel";
			this.passwordPanel.Size = new System.Drawing.Size(452, 508);
			this.passwordPanel.TabIndex = 9;
			this.passwordPanel.Visible = false;
			this.passwordPanel.Click += new System.EventHandler(this.passwordPanel_Click);
			this.passwordPanel.Resize += new System.EventHandler(this.passwordPanel_Resize);
			// 
			// gbSiteName
			// 
			this.gbSiteName.Controls.Add(this.clientTargetPanel);
			this.gbSiteName.Controls.Add(this.cmdCancelSslTest);
			this.gbSiteName.Controls.Add(this.cmdStartCertificateTest);
			this.gbSiteName.Controls.Add(this.button2);
			this.gbSiteName.Controls.Add(this.button3);
			this.gbSiteName.Controls.Add(this.tbSiteName);
			this.gbSiteName.Location = new System.Drawing.Point(11, 202);
			this.gbSiteName.Margin = new System.Windows.Forms.Padding(0);
			this.gbSiteName.Name = "gbSiteName";
			this.gbSiteName.Padding = new System.Windows.Forms.Padding(0);
			this.gbSiteName.Size = new System.Drawing.Size(400, 100);
			this.gbSiteName.TabIndex = 10;
			this.gbSiteName.TabStop = false;
			this.gbSiteName.Text = " Site / certificate header name:";
			this.gbSiteName.Visible = false;
			// 
			// clientTargetPanel
			// 
			this.clientTargetPanel.AutoSize = true;
			this.clientTargetPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clientTargetPanel.Controls.Add(this.clientTaragetLabel);
			this.clientTargetPanel.Controls.Add(this.clientTaragetText);
			this.clientTargetPanel.Location = new System.Drawing.Point(10, 69);
			this.clientTargetPanel.Margin = new System.Windows.Forms.Padding(0);
			this.clientTargetPanel.Name = "clientTargetPanel";
			this.clientTargetPanel.Size = new System.Drawing.Size(269, 20);
			this.clientTargetPanel.TabIndex = 5;
			// 
			// clientTaragetLabel
			// 
			this.clientTaragetLabel.AutoSize = true;
			this.clientTaragetLabel.Location = new System.Drawing.Point(0, 0);
			this.clientTaragetLabel.Margin = new System.Windows.Forms.Padding(0);
			this.clientTaragetLabel.Name = "clientTaragetLabel";
			this.clientTaragetLabel.Size = new System.Drawing.Size(149, 20);
			this.clientTaragetLabel.TabIndex = 6;
			this.clientTaragetLabel.Text = "Client target address:";
			// 
			// clientTaragetText
			// 
			this.clientTaragetText.AutoSize = true;
			this.clientTaragetText.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.clientTaragetText.Location = new System.Drawing.Point(149, 0);
			this.clientTaragetText.Margin = new System.Windows.Forms.Padding(0);
			this.clientTaragetText.Name = "clientTaragetText";
			this.clientTaragetText.Size = new System.Drawing.Size(120, 20);
			this.clientTaragetText.TabIndex = 7;
			this.clientTaragetText.Text = "https://localhost";
			// 
			// cmdCancelSslTest
			// 
			this.cmdCancelSslTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancelSslTest.AutoSize = true;
			this.cmdCancelSslTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdCancelSslTest.Location = new System.Drawing.Point(310, 29);
			this.cmdCancelSslTest.Margin = new System.Windows.Forms.Padding(0);
			this.cmdCancelSslTest.Name = "cmdCancelSslTest";
			this.cmdCancelSslTest.Size = new System.Drawing.Size(79, 30);
			this.cmdCancelSslTest.TabIndex = 4;
			this.cmdCancelSslTest.TabStop = false;
			this.cmdCancelSslTest.Text = "  Cancel  ";
			this.cmdCancelSslTest.UseVisualStyleBackColor = true;
			this.cmdCancelSslTest.Click += new System.EventHandler(this.cmdCancelSslTest_Click);
			// 
			// cmdStartCertificateTest
			// 
			this.cmdStartCertificateTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdStartCertificateTest.AutoSize = true;
			this.cmdStartCertificateTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdStartCertificateTest.Location = new System.Drawing.Point(217, 29);
			this.cmdStartCertificateTest.Margin = new System.Windows.Forms.Padding(0);
			this.cmdStartCertificateTest.Name = "cmdStartCertificateTest";
			this.cmdStartCertificateTest.Size = new System.Drawing.Size(86, 30);
			this.cmdStartCertificateTest.TabIndex = 3;
			this.cmdStartCertificateTest.TabStop = false;
			this.cmdStartCertificateTest.Text = " Start test ";
			this.cmdStartCertificateTest.UseVisualStyleBackColor = true;
			this.cmdStartCertificateTest.Click += new System.EventHandler(this.cmdStartCertificateTest_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Location = new System.Drawing.Point(514, 27);
			this.button2.Margin = new System.Windows.Forms.Padding(0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(71, 30);
			this.button2.TabIndex = 2;
			this.button2.TabStop = false;
			this.button2.Text = " Cancel ";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.AutoSize = true;
			this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button3.Location = new System.Drawing.Point(443, 27);
			this.button3.Margin = new System.Windows.Forms.Padding(0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(63, 30);
			this.button3.TabIndex = 1;
			this.button3.TabStop = false;
			this.button3.Text = "   OK   ";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// tbSiteName
			// 
			this.tbSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSiteName.Location = new System.Drawing.Point(12, 30);
			this.tbSiteName.Margin = new System.Windows.Forms.Padding(0);
			this.tbSiteName.Name = "tbSiteName";
			this.tbSiteName.Size = new System.Drawing.Size(195, 27);
			this.tbSiteName.TabIndex = 0;
			this.tbSiteName.Text = "localhost";
			this.tbSiteName.TextChanged += new System.EventHandler(this.tbSiteName_TextChanged);
			this.tbSiteName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSiteName_KeyDown);
			// 
			// gbPassword
			// 
			this.gbPassword.Controls.Add(this.cmdClosePasswordPanel);
			this.gbPassword.Controls.Add(this.cmdAcceptPassword);
			this.gbPassword.Controls.Add(this.tbPassword);
			this.gbPassword.Location = new System.Drawing.Point(11, 0);
			this.gbPassword.Margin = new System.Windows.Forms.Padding(0);
			this.gbPassword.Name = "gbPassword";
			this.gbPassword.Padding = new System.Windows.Forms.Padding(0);
			this.gbPassword.Size = new System.Drawing.Size(400, 74);
			this.gbPassword.TabIndex = 9;
			this.gbPassword.TabStop = false;
			this.gbPassword.Text = " Certificate file password(it can be empty): ";
			// 
			// cmdClosePasswordPanel
			// 
			this.cmdClosePasswordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClosePasswordPanel.AutoSize = true;
			this.cmdClosePasswordPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdClosePasswordPanel.Location = new System.Drawing.Point(310, 29);
			this.cmdClosePasswordPanel.Margin = new System.Windows.Forms.Padding(0);
			this.cmdClosePasswordPanel.Name = "cmdClosePasswordPanel";
			this.cmdClosePasswordPanel.Size = new System.Drawing.Size(79, 30);
			this.cmdClosePasswordPanel.TabIndex = 2;
			this.cmdClosePasswordPanel.TabStop = false;
			this.cmdClosePasswordPanel.Text = "  Cancel  ";
			this.cmdClosePasswordPanel.UseVisualStyleBackColor = true;
			this.cmdClosePasswordPanel.Click += new System.EventHandler(this.cmdCancelSslTest_Click);
			// 
			// cmdAcceptPassword
			// 
			this.cmdAcceptPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAcceptPassword.AutoSize = true;
			this.cmdAcceptPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdAcceptPassword.Location = new System.Drawing.Point(240, 29);
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
			this.tbPassword.Location = new System.Drawing.Point(12, 30);
			this.tbPassword.Margin = new System.Windows.Forms.Padding(0);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '#';
			this.tbPassword.Size = new System.Drawing.Size(218, 27);
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
			this.ClientSize = new System.Drawing.Size(452, 508);
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
			this.gbProtocol.ResumeLayout(false);
			this.gbCertificate.ResumeLayout(false);
			this.gbCertificate.PerformLayout();
			this.passwordPanel.ResumeLayout(false);
			this.gbSiteName.ResumeLayout(false);
			this.gbSiteName.PerformLayout();
			this.clientTargetPanel.ResumeLayout(false);
			this.clientTargetPanel.PerformLayout();
			this.gbPassword.ResumeLayout(false);
			this.gbPassword.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private Button cmdResourceMode;
        private Button cmdFileMode;
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
        private Button cmdSelectCertificate;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private OpenFileDialog openCertificateDialog;
        private Panel passwordPanel;
        private GroupBox gbPassword;
        private Button cmdAcceptPassword;
        private TextBox tbPassword;
        private Button cmdClosePasswordPanel;
		private Button cmdLoadAssembly;
        private GroupBox gbProtocol;
        private Button button1;
        private ComboBox cbProtocol;
        private GroupBox gbSiteName;
        private Button button2;
        private Button button3;
        private TextBox tbSiteName;
        private Button cmdCancelSslTest;
        private Button cmdStartCertificateTest;
        private FlowLayoutPanel clientTargetPanel;
        private Label clientTaragetLabel;
        private Label clientTaragetText;
    }
}