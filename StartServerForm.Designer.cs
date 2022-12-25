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
			this.gbWebroot = new System.Windows.Forms.GroupBox();
			this.tbWebroot = new System.Windows.Forms.TextBox();
			this.cmdSelectPath = new System.Windows.Forms.Button();
			this.assembliesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.assembliesCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesCutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.assembliesBrowseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assembliesShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folders = new System.Windows.Forms.FolderBrowserDialog();
			this.gbAssemblies = new System.Windows.Forms.GroupBox();
			this.cbAssemblies = new System.Windows.Forms.ComboBox();
			this.cmdLoadAssembly = new System.Windows.Forms.Button();
			this.buttonLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.cmdFileMode = new System.Windows.Forms.Button();
			this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.statusPanel = new System.Windows.Forms.Panel();
			this.gbSiteName = new System.Windows.Forms.GroupBox();
			this.tbSiteName = new System.Windows.Forms.TextBox();
			this.sitePortGap = new System.Windows.Forms.Panel();
			this.gbPort = new System.Windows.Forms.GroupBox();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gbProtocol = new System.Windows.Forms.GroupBox();
			this.cbProtocol = new System.Windows.Forms.ComboBox();
			this.gbCertificate = new System.Windows.Forms.GroupBox();
			this.tbCertificate = new System.Windows.Forms.TextBox();
			this.cmdSelectCertificate = new System.Windows.Forms.Button();
			this.startPanel = new System.Windows.Forms.Panel();
			this.cmdStart = new System.Windows.Forms.Button();
			this.startContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.parametersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbSiteUri = new System.Windows.Forms.GroupBox();
			this.lbSiteUri = new System.Windows.Forms.Label();
			this.siteUriContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.siteUriOpenItem = new System.Windows.Forms.ToolStripMenuItem();
			this.siteUriLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.siteUriCopyItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientTargetPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.button3 = new System.Windows.Forms.Button();
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
			this.gbWebroot.SuspendLayout();
			this.assembliesContextMenu.SuspendLayout();
			this.gbAssemblies.SuspendLayout();
			this.buttonLayout.SuspendLayout();
			this.mainLayout.SuspendLayout();
			this.statusPanel.SuspendLayout();
			this.gbSiteName.SuspendLayout();
			this.gbPort.SuspendLayout();
			this.gbProtocol.SuspendLayout();
			this.gbCertificate.SuspendLayout();
			this.startPanel.SuspendLayout();
			this.startContextMenu.SuspendLayout();
			this.gbSiteUri.SuspendLayout();
			this.siteUriContextMenu.SuspendLayout();
			this.passwordPanel.SuspendLayout();
			this.gbPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdResourceMode
			// 
			this.cmdResourceMode.Location = new System.Drawing.Point(217, 4);
			this.cmdResourceMode.Margin = new System.Windows.Forms.Padding(3, 4, 0, 4);
			this.cmdResourceMode.Name = "cmdResourceMode";
			this.cmdResourceMode.Size = new System.Drawing.Size(211, 49);
			this.cmdResourceMode.TabIndex = 0;
			this.cmdResourceMode.TabStop = false;
			this.cmdResourceMode.Text = "&Resource based server";
			this.cmdResourceMode.UseVisualStyleBackColor = true;
			this.cmdResourceMode.Click += new System.EventHandler(this.cmdResourceMode_Click);
			this.cmdResourceMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
			// 
			// gbWebroot
			// 
			this.gbWebroot.Controls.Add(this.tbWebroot);
			this.gbWebroot.Controls.Add(this.cmdSelectPath);
			this.gbWebroot.Location = new System.Drawing.Point(8, 233);
			this.gbWebroot.Margin = new System.Windows.Forms.Padding(0, 4, 0, 8);
			this.gbWebroot.Name = "gbWebroot";
			this.gbWebroot.Padding = new System.Windows.Forms.Padding(14);
			this.gbWebroot.Size = new System.Drawing.Size(432, 74);
			this.gbWebroot.TabIndex = 4;
			this.gbWebroot.TabStop = false;
			this.gbWebroot.Text = " Local &disk path: ";
			// 
			// tbWebroot
			// 
			this.tbWebroot.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbWebroot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbWebroot.Location = new System.Drawing.Point(14, 34);
			this.tbWebroot.Margin = new System.Windows.Forms.Padding(0);
			this.tbWebroot.Name = "tbWebroot";
			this.tbWebroot.Size = new System.Drawing.Size(364, 27);
			this.tbWebroot.TabIndex = 4;
			this.tbWebroot.Text = "C:\\Code\\Nodes\\PipeMania\\PipeMania\\Resources";
			this.tbWebroot.Enter += new System.EventHandler(this.tbWebroot_Enter);
			this.tbWebroot.Leave += new System.EventHandler(this.tbWebroot_Leave);
			this.tbWebroot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.edit_MouseUp);
			// 
			// cmdSelectPath
			// 
			this.cmdSelectPath.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdSelectPath.Location = new System.Drawing.Point(378, 34);
			this.cmdSelectPath.Name = "cmdSelectPath";
			this.cmdSelectPath.Size = new System.Drawing.Size(40, 26);
			this.cmdSelectPath.TabIndex = 1;
			this.cmdSelectPath.TabStop = false;
			this.cmdSelectPath.Text = "...";
			this.cmdSelectPath.UseVisualStyleBackColor = true;
			this.cmdSelectPath.Click += new System.EventHandler(this.cmdSelectPath_Click);
			this.cmdSelectPath.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdSelectPath_MouseUp);
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
			this.gbAssemblies.Controls.Add(this.cbAssemblies);
			this.gbAssemblies.Controls.Add(this.cmdLoadAssembly);
			this.gbAssemblies.Location = new System.Drawing.Point(8, 319);
			this.gbAssemblies.Margin = new System.Windows.Forms.Padding(0, 4, 0, 8);
			this.gbAssemblies.Name = "gbAssemblies";
			this.gbAssemblies.Padding = new System.Windows.Forms.Padding(14);
			this.gbAssemblies.Size = new System.Drawing.Size(432, 74);
			this.gbAssemblies.TabIndex = 4;
			this.gbAssemblies.TabStop = false;
			this.gbAssemblies.Text = " Assemblies: ";
			// 
			// cbAssemblies
			// 
			this.cbAssemblies.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cbAssemblies.ContextMenuStrip = this.assembliesContextMenu;
			this.cbAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbAssemblies.IntegralHeight = false;
			this.cbAssemblies.Location = new System.Drawing.Point(14, 34);
			this.cbAssemblies.Margin = new System.Windows.Forms.Padding(0);
			this.cbAssemblies.MaxDropDownItems = 12;
			this.cbAssemblies.Name = "cbAssemblies";
			this.cbAssemblies.Size = new System.Drawing.Size(364, 28);
			this.cbAssemblies.TabIndex = 4;
			this.cbAssemblies.DropDown += new System.EventHandler(this.cbAssemblies_DropDown);
			this.cbAssemblies.SelectedIndexChanged += new System.EventHandler(this.cbAssemblies_SelectedIndexChanged);
			this.cbAssemblies.DropDownClosed += new System.EventHandler(this.cbAssemblies_DropDownClosed);
			this.cbAssemblies.Enter += new System.EventHandler(this.cbAssemblies_Enter);
			this.cbAssemblies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAssemblies_KeyDown);
			this.cbAssemblies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAssemblies_KeyPress);
			this.cbAssemblies.Leave += new System.EventHandler(this.cbAssemblies_Leave);
			this.cbAssemblies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbAssemblies_MouseDown);
			// 
			// cmdLoadAssembly
			// 
			this.cmdLoadAssembly.ContextMenuStrip = this.assembliesContextMenu;
			this.cmdLoadAssembly.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdLoadAssembly.Location = new System.Drawing.Point(378, 34);
			this.cmdLoadAssembly.Margin = new System.Windows.Forms.Padding(0);
			this.cmdLoadAssembly.Name = "cmdLoadAssembly";
			this.cmdLoadAssembly.Size = new System.Drawing.Size(40, 26);
			this.cmdLoadAssembly.TabIndex = 4;
			this.cmdLoadAssembly.TabStop = false;
			this.cmdLoadAssembly.Text = "...";
			this.cmdLoadAssembly.UseVisualStyleBackColor = true;
			this.cmdLoadAssembly.Click += new System.EventHandler(this.cmdLoadAssembly_Click);
			this.cmdLoadAssembly.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdLoadAssembly_MouseUp);
			// 
			// buttonLayout
			// 
			this.buttonLayout.AutoSize = true;
			this.buttonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonLayout.Controls.Add(this.cmdFileMode);
			this.buttonLayout.Controls.Add(this.cmdResourceMode);
			this.buttonLayout.Location = new System.Drawing.Point(8, 172);
			this.buttonLayout.Margin = new System.Windows.Forms.Padding(0);
			this.buttonLayout.Name = "buttonLayout";
			this.buttonLayout.Size = new System.Drawing.Size(428, 57);
			this.buttonLayout.TabIndex = 5;
			this.buttonLayout.WrapContents = false;
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
			this.cmdFileMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
			// 
			// mainLayout
			// 
			this.mainLayout.AutoSize = true;
			this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainLayout.Controls.Add(this.statusPanel);
			this.mainLayout.Controls.Add(this.gbCertificate);
			this.mainLayout.Controls.Add(this.buttonLayout);
			this.mainLayout.Controls.Add(this.gbWebroot);
			this.mainLayout.Controls.Add(this.gbAssemblies);
			this.mainLayout.Controls.Add(this.startPanel);
			this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(8);
			this.mainLayout.Size = new System.Drawing.Size(448, 472);
			this.mainLayout.TabIndex = 7;
			this.mainLayout.WrapContents = false;
			// 
			// statusPanel
			// 
			this.statusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.statusPanel.Controls.Add(this.gbSiteName);
			this.statusPanel.Controls.Add(this.sitePortGap);
			this.statusPanel.Controls.Add(this.gbPort);
			this.statusPanel.Controls.Add(this.panel1);
			this.statusPanel.Controls.Add(this.gbProtocol);
			this.statusPanel.Location = new System.Drawing.Point(8, 8);
			this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
			this.statusPanel.Name = "statusPanel";
			this.statusPanel.Size = new System.Drawing.Size(429, 74);
			this.statusPanel.TabIndex = 0;
			// 
			// gbSiteName
			// 
			this.gbSiteName.Controls.Add(this.tbSiteName);
			this.gbSiteName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSiteName.Location = new System.Drawing.Point(0, 0);
			this.gbSiteName.Name = "gbSiteName";
			this.gbSiteName.Padding = new System.Windows.Forms.Padding(14);
			this.gbSiteName.Size = new System.Drawing.Size(167, 74);
			this.gbSiteName.TabIndex = 0;
			this.gbSiteName.TabStop = false;
			this.gbSiteName.Text = " Site &name:";
			// 
			// tbSiteName
			// 
			this.tbSiteName.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbSiteName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSiteName.Location = new System.Drawing.Point(14, 34);
			this.tbSiteName.Margin = new System.Windows.Forms.Padding(0);
			this.tbSiteName.MaxLength = 0;
			this.tbSiteName.Name = "tbSiteName";
			this.tbSiteName.Size = new System.Drawing.Size(139, 27);
			this.tbSiteName.TabIndex = 0;
			this.tbSiteName.Text = "localhost";
			this.tbSiteName.TextChanged += new System.EventHandler(this.tbSiteName_TextChanged);
			this.tbSiteName.Enter += new System.EventHandler(this.tbSiteName_Enter);
			this.tbSiteName.Leave += new System.EventHandler(this.tbSiteName_Leave);
			this.tbSiteName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.edit_MouseUp);
			this.tbSiteName.Resize += new System.EventHandler(this.tbSiteName_Resize);
			// 
			// sitePortGap
			// 
			this.sitePortGap.Dock = System.Windows.Forms.DockStyle.Right;
			this.sitePortGap.Location = new System.Drawing.Point(167, 0);
			this.sitePortGap.Name = "sitePortGap";
			this.sitePortGap.Size = new System.Drawing.Size(6, 74);
			this.sitePortGap.TabIndex = 1;
			// 
			// gbPort
			// 
			this.gbPort.Controls.Add(this.tbPort);
			this.gbPort.Dock = System.Windows.Forms.DockStyle.Right;
			this.gbPort.Location = new System.Drawing.Point(173, 0);
			this.gbPort.Name = "gbPort";
			this.gbPort.Padding = new System.Windows.Forms.Padding(14);
			this.gbPort.Size = new System.Drawing.Size(90, 74);
			this.gbPort.TabIndex = 1;
			this.gbPort.TabStop = false;
			this.gbPort.Text = " &Port: ";
			// 
			// tbPort
			// 
			this.tbPort.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPort.Location = new System.Drawing.Point(14, 34);
			this.tbPort.Margin = new System.Windows.Forms.Padding(0);
			this.tbPort.MaxLength = 5;
			this.tbPort.Name = "tbPort";
			this.tbPort.PlaceholderText = "1-65535";
			this.tbPort.Size = new System.Drawing.Size(62, 27);
			this.tbPort.TabIndex = 1;
			this.tbPort.Text = "50080";
			this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
			this.tbPort.Enter += new System.EventHandler(this.tbPort_Enter);
			this.tbPort.Leave += new System.EventHandler(this.tbPort_Leave);
			this.tbPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.edit_MouseUp);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(263, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(6, 74);
			this.panel1.TabIndex = 3;
			// 
			// gbProtocol
			// 
			this.gbProtocol.Controls.Add(this.cbProtocol);
			this.gbProtocol.Dock = System.Windows.Forms.DockStyle.Right;
			this.gbProtocol.Location = new System.Drawing.Point(269, 0);
			this.gbProtocol.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.gbProtocol.Name = "gbProtocol";
			this.gbProtocol.Padding = new System.Windows.Forms.Padding(14);
			this.gbProtocol.Size = new System.Drawing.Size(160, 74);
			this.gbProtocol.TabIndex = 2;
			this.gbProtocol.TabStop = false;
			this.gbProtocol.Text = " &Security protocol: ";
			// 
			// cbProtocol
			// 
			this.cbProtocol.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cbProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbProtocol.IntegralHeight = false;
			this.cbProtocol.Location = new System.Drawing.Point(14, 34);
			this.cbProtocol.Margin = new System.Windows.Forms.Padding(0);
			this.cbProtocol.MaxDropDownItems = 12;
			this.cbProtocol.Name = "cbProtocol";
			this.cbProtocol.Size = new System.Drawing.Size(132, 28);
			this.cbProtocol.TabIndex = 2;
			this.cbProtocol.SelectedIndexChanged += new System.EventHandler(this.cbProtocol_SelectedIndexChanged);
			this.cbProtocol.TextChanged += new System.EventHandler(this.cbProtocol_TextChanged);
			this.cbProtocol.Enter += new System.EventHandler(this.cbProtocol_Enter);
			this.cbProtocol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProtocol_KeyDown);
			this.cbProtocol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProtocol_KeyPress);
			this.cbProtocol.Leave += new System.EventHandler(this.cbProtocol_Leave);
			// 
			// gbCertificate
			// 
			this.gbCertificate.Controls.Add(this.tbCertificate);
			this.gbCertificate.Controls.Add(this.cmdSelectCertificate);
			this.gbCertificate.Enabled = false;
			this.gbCertificate.Location = new System.Drawing.Point(8, 90);
			this.gbCertificate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
			this.gbCertificate.Name = "gbCertificate";
			this.gbCertificate.Padding = new System.Windows.Forms.Padding(14);
			this.gbCertificate.Size = new System.Drawing.Size(432, 74);
			this.gbCertificate.TabIndex = 3;
			this.gbCertificate.TabStop = false;
			this.gbCertificate.Text = " Load SSL &certifcate from: ";
			this.gbCertificate.Resize += new System.EventHandler(this.gbCertificate_Resize);
			// 
			// tbCertificate
			// 
			this.tbCertificate.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tbCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCertificate.Location = new System.Drawing.Point(14, 34);
			this.tbCertificate.Margin = new System.Windows.Forms.Padding(0);
			this.tbCertificate.Name = "tbCertificate";
			this.tbCertificate.Size = new System.Drawing.Size(364, 27);
			this.tbCertificate.TabIndex = 3;
			this.tbCertificate.Text = "C:\\Code\\localhost2.pfx";
			this.tbCertificate.TextChanged += new System.EventHandler(this.tbCertificate_TextChanged);
			this.tbCertificate.Enter += new System.EventHandler(this.tbCertificate_Enter);
			this.tbCertificate.Leave += new System.EventHandler(this.tbCertificate_Leave);
			this.tbCertificate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.edit_MouseUp);
			// 
			// cmdSelectCertificate
			// 
			this.cmdSelectCertificate.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdSelectCertificate.Location = new System.Drawing.Point(378, 34);
			this.cmdSelectCertificate.Margin = new System.Windows.Forms.Padding(0);
			this.cmdSelectCertificate.MinimumSize = new System.Drawing.Size(0, 27);
			this.cmdSelectCertificate.Name = "cmdSelectCertificate";
			this.cmdSelectCertificate.Size = new System.Drawing.Size(40, 27);
			this.cmdSelectCertificate.TabIndex = 3;
			this.cmdSelectCertificate.TabStop = false;
			this.cmdSelectCertificate.Text = "...";
			this.cmdSelectCertificate.UseVisualStyleBackColor = true;
			this.cmdSelectCertificate.Click += new System.EventHandler(this.cmdSelectCertificate_Click);
			// 
			// startPanel
			// 
			this.startPanel.AutoSize = true;
			this.startPanel.Controls.Add(this.cmdStart);
			this.startPanel.Controls.Add(this.gbSiteUri);
			this.startPanel.Location = new System.Drawing.Point(8, 401);
			this.startPanel.Margin = new System.Windows.Forms.Padding(0);
			this.startPanel.Name = "startPanel";
			this.startPanel.Size = new System.Drawing.Size(429, 63);
			this.startPanel.TabIndex = 5;
			// 
			// cmdStart
			// 
			this.cmdStart.ContextMenuStrip = this.startContextMenu;
			this.cmdStart.Location = new System.Drawing.Point(329, 14);
			this.cmdStart.Margin = new System.Windows.Forms.Padding(0);
			this.cmdStart.Name = "cmdStart";
			this.cmdStart.Size = new System.Drawing.Size(100, 49);
			this.cmdStart.TabIndex = 2;
			this.cmdStart.TabStop = false;
			this.cmdStart.Text = "Start";
			this.cmdStart.UseVisualStyleBackColor = true;
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			this.cmdStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
			// 
			// startContextMenu
			// 
			this.startContextMenu.AccessibleDescription = "";
			this.startContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuItem,
            this.startLine1,
            this.parametersMenuItem});
			this.startContextMenu.Name = "siteUriContextMenu";
			this.startContextMenu.Size = new System.Drawing.Size(192, 54);
			this.startContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.startContextMenu_ItemClicked);
			// 
			// startMenuItem
			// 
			this.startMenuItem.Name = "startMenuItem";
			this.startMenuItem.Size = new System.Drawing.Size(191, 22);
			this.startMenuItem.Text = "&Start";
			// 
			// startLine1
			// 
			this.startLine1.Name = "startLine1";
			this.startLine1.Size = new System.Drawing.Size(188, 6);
			// 
			// parametersMenuItem
			// 
			this.parametersMenuItem.Name = "parametersMenuItem";
			this.parametersMenuItem.Size = new System.Drawing.Size(191, 22);
			this.parametersMenuItem.Text = "Show start parameters";
			// 
			// gbSiteUri
			// 
			this.gbSiteUri.Controls.Add(this.lbSiteUri);
			this.gbSiteUri.Controls.Add(this.clientTargetPanel);
			this.gbSiteUri.Controls.Add(this.button3);
			this.gbSiteUri.Dock = System.Windows.Forms.DockStyle.Left;
			this.gbSiteUri.Location = new System.Drawing.Point(0, 0);
			this.gbSiteUri.Margin = new System.Windows.Forms.Padding(0);
			this.gbSiteUri.Name = "gbSiteUri";
			this.gbSiteUri.Padding = new System.Windows.Forms.Padding(0);
			this.gbSiteUri.Size = new System.Drawing.Size(313, 63);
			this.gbSiteUri.TabIndex = 11;
			this.gbSiteUri.TabStop = false;
			this.gbSiteUri.Text = " Site addres:";
			// 
			// lbSiteUri
			// 
			this.lbSiteUri.AutoSize = true;
			this.lbSiteUri.ContextMenuStrip = this.siteUriContextMenu;
			this.lbSiteUri.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbSiteUri.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lbSiteUri.Location = new System.Drawing.Point(12, 30);
			this.lbSiteUri.Margin = new System.Windows.Forms.Padding(0);
			this.lbSiteUri.Name = "lbSiteUri";
			this.lbSiteUri.Size = new System.Drawing.Size(120, 20);
			this.lbSiteUri.TabIndex = 7;
			this.lbSiteUri.Text = "https://localhost";
			this.lbSiteUri.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbSiteUri_MouseDown);
			this.lbSiteUri.MouseEnter += new System.EventHandler(this.lbSiteUri_MouseEnter);
			this.lbSiteUri.MouseLeave += new System.EventHandler(this.lbSiteUri_MouseLeave);
			// 
			// siteUriContextMenu
			// 
			this.siteUriContextMenu.AccessibleDescription = "";
			this.siteUriContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siteUriOpenItem,
            this.siteUriLine1,
            this.siteUriCopyItem});
			this.siteUriContextMenu.Name = "siteUriContextMenu";
			this.siteUriContextMenu.Size = new System.Drawing.Size(104, 54);
			this.siteUriContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.siteUriContextMenu_ItemClicked);
			// 
			// siteUriOpenItem
			// 
			this.siteUriOpenItem.Name = "siteUriOpenItem";
			this.siteUriOpenItem.Size = new System.Drawing.Size(103, 22);
			this.siteUriOpenItem.Text = "Open";
			// 
			// siteUriLine1
			// 
			this.siteUriLine1.Name = "siteUriLine1";
			this.siteUriLine1.Size = new System.Drawing.Size(100, 6);
			// 
			// siteUriCopyItem
			// 
			this.siteUriCopyItem.Name = "siteUriCopyItem";
			this.siteUriCopyItem.Size = new System.Drawing.Size(103, 22);
			this.siteUriCopyItem.Text = "Copy";
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
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.AutoSize = true;
			this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button3.Location = new System.Drawing.Point(885, 24);
			this.button3.Margin = new System.Windows.Forms.Padding(0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(63, 30);
			this.button3.TabIndex = 1;
			this.button3.TabStop = false;
			this.button3.Text = "   OK   ";
			this.button3.UseVisualStyleBackColor = true;
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
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartServerForm";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Http Server Startup";
			this.gbWebroot.ResumeLayout(false);
			this.gbWebroot.PerformLayout();
			this.assembliesContextMenu.ResumeLayout(false);
			this.gbAssemblies.ResumeLayout(false);
			this.buttonLayout.ResumeLayout(false);
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.statusPanel.ResumeLayout(false);
			this.gbSiteName.ResumeLayout(false);
			this.gbSiteName.PerformLayout();
			this.gbPort.ResumeLayout(false);
			this.gbPort.PerformLayout();
			this.gbProtocol.ResumeLayout(false);
			this.gbCertificate.ResumeLayout(false);
			this.gbCertificate.PerformLayout();
			this.startPanel.ResumeLayout(false);
			this.startContextMenu.ResumeLayout(false);
			this.gbSiteUri.ResumeLayout(false);
			this.gbSiteUri.PerformLayout();
			this.siteUriContextMenu.ResumeLayout(false);
			this.passwordPanel.ResumeLayout(false);
			this.gbPassword.ResumeLayout(false);
			this.gbPassword.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private Button cmdResourceMode;
        private GroupBox gbWebroot;
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
        private ComboBox cbProtocol;
        private ContextMenuStrip assembliesContextMenu;
        private ToolStripMenuItem assembliesCopyMenuItem;
        private ToolStripMenuItem assembliesPasteMenuItem;
        private ToolStripMenuItem assembliesCutMenuItem;
        private ToolStripSeparator assembliesLine1;
        private ToolStripMenuItem assembliesBrowseMenuItem;
        private ToolStripMenuItem assembliesShowMenuItem;
        private Panel statusPanel;
        private GroupBox gbSiteName;
        private TextBox tbSiteName;
        private GroupBox gbPort;
        private TextBox tbPort;
        private Panel sitePortGap;
		private Panel startPanel;
		private Button cmdStart;
		private GroupBox gbSiteUri;
		private Label lbSiteUri;
		private FlowLayoutPanel clientTargetPanel;
		private Button button3;
        private Button cmdFileMode;
        private ContextMenuStrip siteUriContextMenu;
		private ToolStripMenuItem siteUriOpenItem;
		private ToolStripSeparator siteUriLine1;
        private ToolStripMenuItem siteUriCopyItem;
        private Panel panel1;
        private ContextMenuStrip startContextMenu;
        private ToolStripMenuItem startMenuItem;
        private ToolStripSeparator startLine1;
        private ToolStripMenuItem parametersMenuItem;
    }
}