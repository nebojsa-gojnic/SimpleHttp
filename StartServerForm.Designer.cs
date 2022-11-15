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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartServerForm));
			this.cmdResourceMode = new System.Windows.Forms.Button();
			this.cmdFileMode = new System.Windows.Forms.Button();
			this.gbFilePath = new System.Windows.Forms.GroupBox();
			this.cmdSelectPath = new System.Windows.Forms.Button();
			this.tbWebroot = new System.Windows.Forms.TextBox();
			this.assembliesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.assembliesCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesCutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.assembliesBrowseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folders = new System.Windows.Forms.FolderBrowserDialog();
			this.gbAssemblies = new System.Windows.Forms.GroupBox();
			this.cmdLoadAssembly = new System.Windows.Forms.Button();
			this.cbAssemblies = new System.Windows.Forms.ComboBox();
			this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.sitrPortPanel = new System.Windows.Forms.Panel();
			this.gbSiteName = new System.Windows.Forms.GroupBox();
			this.tbSiteName = new System.Windows.Forms.TextBox();
			this.sitePortGap = new System.Windows.Forms.Panel();
			this.gpPort = new System.Windows.Forms.GroupBox();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.gbProtocol = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cbProtocol = new System.Windows.Forms.ComboBox();
			this.gbCertificate = new System.Windows.Forms.GroupBox();
			this.cmdSelectCertificate = new System.Windows.Forms.Button();
			this.tbCertificate = new System.Windows.Forms.TextBox();
			this.gbSiteUri = new System.Windows.Forms.GroupBox();
			this.lbSiteUri = new System.Windows.Forms.Label();
			this.clientTargetPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.filePathPanel = new System.Windows.Forms.Panel();
			this.cmdStartFileMode = new System.Windows.Forms.Button();
			this.assembliesPanel = new System.Windows.Forms.Panel();
			this.cmdStartResourceMode = new System.Windows.Forms.Button();
			this.openAssemblyDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
			this.openCertificateDialog = new System.Windows.Forms.OpenFileDialog();
			this.passwordPanel = new System.Windows.Forms.Panel();
			this.gbPassword = new System.Windows.Forms.GroupBox();
			this.cmdClosePasswordPanel = new System.Windows.Forms.Button();
			this.cmdAcceptPassword = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.gbFilePath.SuspendLayout();
			this.assembliesContextMenu.SuspendLayout();
			this.gbAssemblies.SuspendLayout();
			this.buttonLayout.SuspendLayout();
			this.mainLayout.SuspendLayout();
			this.sitrPortPanel.SuspendLayout();
			this.gbSiteName.SuspendLayout();
			this.gpPort.SuspendLayout();
			this.gbProtocol.SuspendLayout();
			this.gbCertificate.SuspendLayout();
			this.gbSiteUri.SuspendLayout();
			this.filePathPanel.SuspendLayout();
			this.assembliesPanel.SuspendLayout();
			this.passwordPanel.SuspendLayout();
			this.gbPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdResourceMode
			// 
			this.cmdResourceMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.cmdResourceMode.Location = new System.Drawing.Point(217, 4);
			this.cmdResourceMode.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
			this.cmdResourceMode.Name = "cmdResourceMode";
			this.cmdResourceMode.Size = new System.Drawing.Size(211, 49);
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
			this.cmdFileMode.Size = new System.Drawing.Size(211, 49);
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
			this.gbFilePath.Location = new System.Drawing.Point(0, 0);
			this.gbFilePath.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbFilePath.Name = "gbFilePath";
			this.gbFilePath.Padding = new System.Windows.Forms.Padding(0);
			this.gbFilePath.Size = new System.Drawing.Size(318, 74);
			this.gbFilePath.TabIndex = 1;
			this.gbFilePath.TabStop = false;
			this.gbFilePath.Text = " Local disk &path: ";
			this.gbFilePath.Resize += new System.EventHandler(this.gbFilePath_Resize);
			// 
			// cmdSelectPath
			// 
			this.cmdSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectPath.Location = new System.Drawing.Point(266, 30);
			this.cmdSelectPath.Name = "cmdSelectPath";
			this.cmdSelectPath.Size = new System.Drawing.Size(40, 27);
			this.cmdSelectPath.TabIndex = 1;
			this.cmdSelectPath.TabStop = false;
			this.cmdSelectPath.Text = "...";
			this.cmdSelectPath.UseVisualStyleBackColor = true;
			this.cmdSelectPath.Click += new System.EventHandler(this.cmdSelectPath_Click);
			this.cmdSelectPath.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdSelectPath_MouseUp);
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
			this.tbWebroot.Size = new System.Drawing.Size(259, 27);
			this.tbWebroot.TabIndex = 0;
			this.tbWebroot.Text = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			this.tbWebroot.Enter += new System.EventHandler(this.tbWebroot_Enter);
			this.tbWebroot.Leave += new System.EventHandler(this.tbWebroot_Leave);
			// 
			// assembliesContextMenu
			// 
			this.assembliesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assembliesCopyMenuItem,
            this.assembliesCutMenuItem,
            this.assembliesPasteMenuItem,
            this.assembliesLine1,
            this.assembliesBrowseMenuItem,
            this.assembliesShowMenuItem});
			this.assembliesContextMenu.Name = "assembliesContextMenu";
			this.assembliesContextMenu.Size = new System.Drawing.Size(166, 120);
			this.assembliesContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.assembliesContextMenu_Opening);
			this.assembliesContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.assembliesContextMenu_ItemClicked);
			// 
			// assembliesCopyMenuItem
			// 
			this.assembliesCopyMenuItem.Name = "assembliesCopyMenuItem";
			this.assembliesCopyMenuItem.Size = new System.Drawing.Size(165, 22);
			this.assembliesCopyMenuItem.Text = "Copy";
			// 
			// assembliesCutMenuItem
			// 
			this.assembliesCutMenuItem.Name = "assembliesCutMenuItem";
			this.assembliesCutMenuItem.Size = new System.Drawing.Size(165, 22);
			this.assembliesCutMenuItem.Text = "Cut";
			// 
			// assembliesPasteMenuItem
			// 
			this.assembliesPasteMenuItem.Name = "assembliesPasteMenuItem";
			this.assembliesPasteMenuItem.Size = new System.Drawing.Size(165, 22);
			this.assembliesPasteMenuItem.Text = "Paste";
			// 
			// assembliesLine1
			// 
			this.assembliesLine1.Name = "assembliesLine1";
			this.assembliesLine1.Size = new System.Drawing.Size(162, 6);
			// 
			// assembliesBrowseMenuItem
			// 
			this.assembliesBrowseMenuItem.Name = "assembliesBrowseMenuItem";
			this.assembliesBrowseMenuItem.Size = new System.Drawing.Size(165, 22);
			this.assembliesBrowseMenuItem.Text = "Browse from disk";
			// 
			// assembliesShowMenuItem
			// 
			this.assembliesShowMenuItem.Name = "assembliesShowMenuItem";
			this.assembliesShowMenuItem.Size = new System.Drawing.Size(165, 22);
			this.assembliesShowMenuItem.Text = "Show resources";
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
			this.gbAssemblies.Location = new System.Drawing.Point(0, 0);
			this.gbAssemblies.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbAssemblies.Name = "gbAssemblies";
			this.gbAssemblies.Padding = new System.Windows.Forms.Padding(0);
			this.gbAssemblies.Size = new System.Drawing.Size(318, 74);
			this.gbAssemblies.TabIndex = 2;
			this.gbAssemblies.TabStop = false;
			this.gbAssemblies.Text = " Assemblies: ";
			this.gbAssemblies.Resize += new System.EventHandler(this.gbAssemblies_Resize);
			// 
			// cmdLoadAssembly
			// 
			this.cmdLoadAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdLoadAssembly.ContextMenuStrip = this.assembliesContextMenu;
			this.cmdLoadAssembly.Location = new System.Drawing.Point(266, 30);
			this.cmdLoadAssembly.Margin = new System.Windows.Forms.Padding(0);
			this.cmdLoadAssembly.Name = "cmdLoadAssembly";
			this.cmdLoadAssembly.Size = new System.Drawing.Size(40, 27);
			this.cmdLoadAssembly.TabIndex = 4;
			this.cmdLoadAssembly.TabStop = false;
			this.cmdLoadAssembly.Text = "...";
			this.cmdLoadAssembly.UseVisualStyleBackColor = true;
			this.cmdLoadAssembly.Click += new System.EventHandler(this.cmdLoadAssembly_Click);
			this.cmdLoadAssembly.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdLoadAssembly_MouseUp);
			// 
			// cbAssemblies
			// 
			this.cbAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAssemblies.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cbAssemblies.ContextMenuStrip = this.assembliesContextMenu;
			this.cbAssemblies.IntegralHeight = false;
			this.cbAssemblies.Location = new System.Drawing.Point(12, 30);
			this.cbAssemblies.Margin = new System.Windows.Forms.Padding(0);
			this.cbAssemblies.MaxDropDownItems = 12;
			this.cbAssemblies.Name = "cbAssemblies";
			this.cbAssemblies.Size = new System.Drawing.Size(294, 28);
			this.cbAssemblies.TabIndex = 0;
			this.cbAssemblies.DropDown += new System.EventHandler(this.cbAssemblies_DropDown);
			this.cbAssemblies.SelectedIndexChanged += new System.EventHandler(this.cbAssemblies_SelectedIndexChanged);
			this.cbAssemblies.DropDownClosed += new System.EventHandler(this.cbAssemblies_DropDownClosed);
			this.cbAssemblies.Enter += new System.EventHandler(this.cbAssemblies_Enter);
			this.cbAssemblies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAssemblies_KeyDown);
			this.cbAssemblies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAssemblies_KeyPress);
			this.cbAssemblies.Leave += new System.EventHandler(this.cbAssemblies_Leave);
			this.cbAssemblies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbAssemblies_MouseDown);
			// 
			// buttonLayout
			// 
			this.buttonLayout.AutoSize = true;
			this.buttonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonLayout.Controls.Add(this.cmdFileMode);
			this.buttonLayout.Controls.Add(this.cmdResourceMode);
			this.buttonLayout.Location = new System.Drawing.Point(11, 319);
			this.buttonLayout.Name = "buttonLayout";
			this.buttonLayout.Size = new System.Drawing.Size(428, 57);
			this.buttonLayout.TabIndex = 5;
			this.buttonLayout.WrapContents = false;
			// 
			// mainLayout
			// 
			this.mainLayout.AutoSize = true;
			this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainLayout.Controls.Add(this.sitrPortPanel);
			this.mainLayout.Controls.Add(this.gbProtocol);
			this.mainLayout.Controls.Add(this.gbCertificate);
			this.mainLayout.Controls.Add(this.gbSiteUri);
			this.mainLayout.Controls.Add(this.buttonLayout);
			this.mainLayout.Controls.Add(this.filePathPanel);
			this.mainLayout.Controls.Add(this.assembliesPanel);
			this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(8);
			this.mainLayout.Size = new System.Drawing.Size(450, 547);
			this.mainLayout.TabIndex = 7;
			this.mainLayout.WrapContents = false;
			// 
			// sitrPortPanel
			// 
			this.sitrPortPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.sitrPortPanel.Controls.Add(this.gbSiteName);
			this.sitrPortPanel.Controls.Add(this.sitePortGap);
			this.sitrPortPanel.Controls.Add(this.gpPort);
			this.sitrPortPanel.Location = new System.Drawing.Point(8, 8);
			this.sitrPortPanel.Margin = new System.Windows.Forms.Padding(0);
			this.sitrPortPanel.Name = "sitrPortPanel";
			this.sitrPortPanel.Size = new System.Drawing.Size(429, 74);
			this.sitrPortPanel.TabIndex = 8;
			// 
			// gbSiteName
			// 
			this.gbSiteName.Controls.Add(this.tbSiteName);
			this.gbSiteName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSiteName.Location = new System.Drawing.Point(0, 0);
			this.gbSiteName.Name = "gbSiteName";
			this.gbSiteName.Padding = new System.Windows.Forms.Padding(0);
			this.gbSiteName.Size = new System.Drawing.Size(303, 74);
			this.gbSiteName.TabIndex = 6;
			this.gbSiteName.TabStop = false;
			this.gbSiteName.Text = " Site &name:";
			// 
			// tbSiteName
			// 
			this.tbSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSiteName.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbSiteName.Location = new System.Drawing.Point(12, 30);
			this.tbSiteName.Margin = new System.Windows.Forms.Padding(0);
			this.tbSiteName.MaxLength = 5;
			this.tbSiteName.Name = "tbSiteName";
			this.tbSiteName.Size = new System.Drawing.Size(279, 27);
			this.tbSiteName.TabIndex = 0;
			this.tbSiteName.Text = "localhost";
			this.tbSiteName.TextChanged += new System.EventHandler(this.tbSiteName_TextChanged);
			this.tbSiteName.Enter += new System.EventHandler(this.tbSiteName_Enter);
			this.tbSiteName.Leave += new System.EventHandler(this.tbSiteName_Leave);
			// 
			// sitePortGap
			// 
			this.sitePortGap.Dock = System.Windows.Forms.DockStyle.Right;
			this.sitePortGap.Location = new System.Drawing.Point(303, 0);
			this.sitePortGap.Name = "sitePortGap";
			this.sitePortGap.Size = new System.Drawing.Size(6, 74);
			this.sitePortGap.TabIndex = 1;
			// 
			// gpPort
			// 
			this.gpPort.Controls.Add(this.tbPort);
			this.gpPort.Dock = System.Windows.Forms.DockStyle.Right;
			this.gpPort.Location = new System.Drawing.Point(309, 0);
			this.gpPort.Name = "gpPort";
			this.gpPort.Padding = new System.Windows.Forms.Padding(0);
			this.gpPort.Size = new System.Drawing.Size(120, 74);
			this.gpPort.TabIndex = 5;
			this.gpPort.TabStop = false;
			this.gpPort.Text = " &Port: ";
			// 
			// tbPort
			// 
			this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPort.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbPort.Location = new System.Drawing.Point(12, 30);
			this.tbPort.Margin = new System.Windows.Forms.Padding(0);
			this.tbPort.MaxLength = 5;
			this.tbPort.Name = "tbPort";
			this.tbPort.PlaceholderText = "1-65535";
			this.tbPort.Size = new System.Drawing.Size(98, 27);
			this.tbPort.TabIndex = 0;
			this.tbPort.Text = "50080";
			this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
			this.tbPort.Enter += new System.EventHandler(this.tbPort_Enter);
			this.tbPort.Leave += new System.EventHandler(this.tbPort_Leave);
			// 
			// gbProtocol
			// 
			this.gbProtocol.Controls.Add(this.button1);
			this.gbProtocol.Controls.Add(this.cbProtocol);
			this.gbProtocol.Location = new System.Drawing.Point(8, 86);
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
			this.gbCertificate.Location = new System.Drawing.Point(8, 168);
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
			// gbSiteUri
			// 
			this.gbSiteUri.Controls.Add(this.lbSiteUri);
			this.gbSiteUri.Controls.Add(this.clientTargetPanel);
			this.gbSiteUri.Controls.Add(this.button2);
			this.gbSiteUri.Controls.Add(this.button3);
			this.gbSiteUri.Location = new System.Drawing.Point(8, 250);
			this.gbSiteUri.Margin = new System.Windows.Forms.Padding(0);
			this.gbSiteUri.Name = "gbSiteUri";
			this.gbSiteUri.Padding = new System.Windows.Forms.Padding(0);
			this.gbSiteUri.Size = new System.Drawing.Size(432, 66);
			this.gbSiteUri.TabIndex = 11;
			this.gbSiteUri.TabStop = false;
			this.gbSiteUri.Text = " Site addres:";
			// 
			// lbSiteUri
			// 
			this.lbSiteUri.AutoSize = true;
			this.lbSiteUri.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lbSiteUri.Location = new System.Drawing.Point(12, 30);
			this.lbSiteUri.Margin = new System.Windows.Forms.Padding(0);
			this.lbSiteUri.Name = "lbSiteUri";
			this.lbSiteUri.Size = new System.Drawing.Size(120, 20);
			this.lbSiteUri.TabIndex = 7;
			this.lbSiteUri.Text = "https://localhost";
			// 
			// clientTargetPanel
			// 
			this.clientTargetPanel.AutoSize = true;
			this.clientTargetPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clientTargetPanel.Location = new System.Drawing.Point(9, 34);
			this.clientTargetPanel.Margin = new System.Windows.Forms.Padding(0);
			this.clientTargetPanel.Name = "clientTargetPanel";
			this.clientTargetPanel.Size = new System.Drawing.Size(0, 0);
			this.clientTargetPanel.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Location = new System.Drawing.Point(749, 24);
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
			this.button3.Location = new System.Drawing.Point(678, 24);
			this.button3.Margin = new System.Windows.Forms.Padding(0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(63, 30);
			this.button3.TabIndex = 1;
			this.button3.TabStop = false;
			this.button3.Text = "   OK   ";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// filePathPanel
			// 
			this.filePathPanel.AutoSize = true;
			this.filePathPanel.Controls.Add(this.gbFilePath);
			this.filePathPanel.Controls.Add(this.cmdStartFileMode);
			this.filePathPanel.Location = new System.Drawing.Point(11, 382);
			this.filePathPanel.Name = "filePathPanel";
			this.filePathPanel.Size = new System.Drawing.Size(426, 74);
			this.filePathPanel.TabIndex = 9;
			// 
			// cmdStartFileMode
			// 
			this.cmdStartFileMode.Location = new System.Drawing.Point(326, 14);
			this.cmdStartFileMode.Margin = new System.Windows.Forms.Padding(0);
			this.cmdStartFileMode.Name = "cmdStartFileMode";
			this.cmdStartFileMode.Size = new System.Drawing.Size(100, 49);
			this.cmdStartFileMode.TabIndex = 2;
			this.cmdStartFileMode.TabStop = false;
			this.cmdStartFileMode.Text = "Start";
			this.cmdStartFileMode.UseVisualStyleBackColor = true;
			this.cmdStartFileMode.Click += new System.EventHandler(this.cmdStart_Click);
			// 
			// assembliesPanel
			// 
			this.assembliesPanel.AutoSize = true;
			this.assembliesPanel.Controls.Add(this.cmdStartResourceMode);
			this.assembliesPanel.Controls.Add(this.gbAssemblies);
			this.assembliesPanel.Location = new System.Drawing.Point(11, 462);
			this.assembliesPanel.Name = "assembliesPanel";
			this.assembliesPanel.Size = new System.Drawing.Size(426, 74);
			this.assembliesPanel.TabIndex = 10;
			// 
			// cmdStartResourceMode
			// 
			this.cmdStartResourceMode.Location = new System.Drawing.Point(326, 14);
			this.cmdStartResourceMode.Margin = new System.Windows.Forms.Padding(0);
			this.cmdStartResourceMode.Name = "cmdStartResourceMode";
			this.cmdStartResourceMode.Size = new System.Drawing.Size(100, 49);
			this.cmdStartResourceMode.TabIndex = 2;
			this.cmdStartResourceMode.TabStop = false;
			this.cmdStartResourceMode.Text = "Start";
			this.cmdStartResourceMode.UseVisualStyleBackColor = true;
			this.cmdStartResourceMode.Click += new System.EventHandler(this.cmdStart_Click);
			// 
			// openAssemblyDialog
			// 
			this.openAssemblyDialog.DefaultExt = "dll";
			this.openAssemblyDialog.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.e" +
    "xe|Any|*.*";
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
			// 
			// passwordPanel
			// 
			this.passwordPanel.Controls.Add(this.gbPassword);
			this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.passwordPanel.Location = new System.Drawing.Point(0, 0);
			this.passwordPanel.Name = "passwordPanel";
			this.passwordPanel.Size = new System.Drawing.Size(452, 485);
			this.passwordPanel.TabIndex = 9;
			this.passwordPanel.Visible = false;
			this.passwordPanel.Resize += new System.EventHandler(this.passwordPanel_Resize);
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
			this.ClientSize = new System.Drawing.Size(452, 485);
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
			this.assembliesContextMenu.ResumeLayout(false);
			this.gbAssemblies.ResumeLayout(false);
			this.buttonLayout.ResumeLayout(false);
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.sitrPortPanel.ResumeLayout(false);
			this.gbSiteName.ResumeLayout(false);
			this.gbSiteName.PerformLayout();
			this.gpPort.ResumeLayout(false);
			this.gpPort.PerformLayout();
			this.gbProtocol.ResumeLayout(false);
			this.gbCertificate.ResumeLayout(false);
			this.gbCertificate.PerformLayout();
			this.gbSiteUri.ResumeLayout(false);
			this.gbSiteUri.PerformLayout();
			this.filePathPanel.ResumeLayout(false);
			this.assembliesPanel.ResumeLayout(false);
			this.passwordPanel.ResumeLayout(false);
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
		private Button cmdSelectPath;
        private FolderBrowserDialog folders;
        private GroupBox gbAssemblies;
        private ComboBox cbAssemblies;
        private FlowLayoutPanel buttonLayout;
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
        private ContextMenuStrip assembliesContextMenu;
        private ToolStripMenuItem assembliesCopyMenuItem;
        private ToolStripMenuItem assembliesPasteMenuItem;
        private ToolStripMenuItem assembliesCutMenuItem;
        private ToolStripSeparator assembliesLine1;
        private ToolStripMenuItem assembliesBrowseMenuItem;
        private ToolStripMenuItem assembliesShowMenuItem;
        private Panel sitrPortPanel;
        private GroupBox gbSiteName;
        private TextBox tbSiteName;
        private GroupBox gpPort;
        private TextBox tbPort;
        private Panel sitePortGap;
		private Panel filePathPanel;
		private Button cmdStartFileMode;
		private Panel assembliesPanel;
		private Button cmdStartResourceMode;
		private GroupBox gbSiteUri;
		private Label lbSiteUri;
		private FlowLayoutPanel clientTargetPanel;
		private Button button2;
		private Button button3;
	}
}