namespace SimpleHttp
{
	partial class QuickStartForm
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickStartForm));
			cmdResourceMode = new Button();
			gbWebroot = new CommonGroupBox();
			tbWebroot = new TextBox();
			cmdSelectPath = new Button();
			assembliesContextMenu = new ContextMenuStrip(components);
			assembliesCopyMenuItem = new ToolStripMenuItem();
			assembliesCutMenuItem = new ToolStripMenuItem();
			assembliesPasteMenuItem = new ToolStripMenuItem();
			assembliesLine1 = new ToolStripSeparator();
			assembliesBrowseMenuItem = new ToolStripMenuItem();
			assembliesShowMenuItem = new ToolStripMenuItem();
			folders = new FolderBrowserDialog();
			gbAssemblies = new CommonGroupBox();
			assembliesBottomPanel = new CommonPanel();
			tbResourceNamePrefix = new TextBox();
			namePrefixLabel = new CommonLabel();
			assembliesTopPanel = new CommonPanel();
			cbAssemblies = new ComboBox();
			cmdLoadAssembly = new Button();
			buttonLayout = new CommonFlowLayoutPanel();
			cmdFileMode = new Button();
			mainLayout = new CommonFlowLayoutPanel();
			statusPanel = new CommonPanel();
			gbSiteName = new CommonGroupBox();
			tbSiteName = new TextBox();
			leftSitePortGap = new CommonPanel();
			gbPort = new CommonGroupBox();
			tbPort = new TextBox();
			rightSitePortGap = new CommonPanel();
			gbProtocol = new CommonGroupBox();
			cbProtocol = new ComboBox();
			gbCertificate = new CommonGroupBox();
			tbCertificate = new TextBox();
			cmdSelectCertificate = new Button();
			startPanel = new CommonTableLayoutPanel();
			gbSiteUri = new CommonGroupBox();
			uriLabel = new CommonLabel();
			siteUriContextMenu = new ContextMenuStrip(components);
			siteUriOpenItem = new ToolStripMenuItem();
			siteUriLine1 = new ToolStripSeparator();
			siteUriCopyItem = new ToolStripMenuItem();
			clientTargetPanel = new CommonFlowLayoutPanel();
			button3 = new Button();
			cmdStart = new Button();
			startContextMenu = new ContextMenuStrip(components);
			startMenuItem = new ToolStripMenuItem();
			startLine1 = new ToolStripSeparator();
			makeJSONMenuItem = new ToolStripMenuItem();
			startLine2 = new ToolStripSeparator();
			parametersMenuItem = new ToolStripMenuItem();
			titlePanel = new CommonPanel();
			closeButton = new Button();
			titleLabel = new CommonLabel();
			openAssemblyDialog = new OpenFileDialog();
			openFileDialog1 = new OpenFileDialog();
			openFileDialog2 = new OpenFileDialog();
			openFileDialog3 = new OpenFileDialog();
			openCertificateDialog = new OpenFileDialog();
			passwordPanel = new CommonPanel();
			certificateWaitLabel = new CommonLabel();
			gbPassword = new CommonGroupBox();
			cmdClosePasswordPanel = new Button();
			cmdAcceptPassword = new Button();
			tbPassword = new TextBox();
			cmdStartOptions = new Button();
			gbWebroot.SuspendLayout();
			assembliesContextMenu.SuspendLayout();
			gbAssemblies.SuspendLayout();
			assembliesBottomPanel.SuspendLayout();
			assembliesTopPanel.SuspendLayout();
			buttonLayout.SuspendLayout();
			mainLayout.SuspendLayout();
			statusPanel.SuspendLayout();
			gbSiteName.SuspendLayout();
			gbPort.SuspendLayout();
			gbProtocol.SuspendLayout();
			gbCertificate.SuspendLayout();
			startPanel.SuspendLayout();
			gbSiteUri.SuspendLayout();
			siteUriContextMenu.SuspendLayout();
			startContextMenu.SuspendLayout();
			titlePanel.SuspendLayout();
			passwordPanel.SuspendLayout();
			gbPassword.SuspendLayout();
			SuspendLayout();
			// 
			// cmdResourceMode
			// 
			cmdResourceMode.Location = new Point(217, 4);
			cmdResourceMode.Margin = new Padding(3, 4, 0, 4);
			cmdResourceMode.Name = "cmdResourceMode";
			cmdResourceMode.Size = new Size(211, 49);
			cmdResourceMode.TabIndex = 0;
			cmdResourceMode.TabStop = false;
			cmdResourceMode.Text = "&Resource based server";
			cmdResourceMode.UseVisualStyleBackColor = true;
			cmdResourceMode.Click += cmdResourceMode_Click;
			cmdResourceMode.MouseUp += button_MouseUp;
			// 
			// gbWebroot
			// 
			gbWebroot.Controls.Add(tbWebroot);
			gbWebroot.Controls.Add(cmdSelectPath);
			gbWebroot.Location = new Point(8, 233);
			gbWebroot.Margin = new Padding(0, 4, 0, 8);
			gbWebroot.Name = "gbWebroot";
			gbWebroot.Padding = new Padding(14, 12, 14, 14);
			gbWebroot.Size = new Size(432, 74);
			gbWebroot.TabIndex = 4;
			gbWebroot.TabStop = false;
			gbWebroot.Text = " Local &disk path: ";
			// 
			// tbWebroot
			// 
			tbWebroot.BackColor = SystemColors.ControlLight;
			tbWebroot.Dock = DockStyle.Fill;
			tbWebroot.Location = new Point(14, 32);
			tbWebroot.Margin = new Padding(0);
			tbWebroot.Name = "tbWebroot";
			tbWebroot.Size = new Size(364, 27);
			tbWebroot.TabIndex = 4;
			tbWebroot.Enter += tbWebroot_Enter;
			tbWebroot.Leave += tbWebroot_Leave;
			tbWebroot.MouseUp += edit_MouseUp;
			// 
			// cmdSelectPath
			// 
			cmdSelectPath.Dock = DockStyle.Right;
			cmdSelectPath.Location = new Point(378, 32);
			cmdSelectPath.Name = "cmdSelectPath";
			cmdSelectPath.Size = new Size(40, 28);
			cmdSelectPath.TabIndex = 1;
			cmdSelectPath.TabStop = false;
			cmdSelectPath.Text = "...";
			cmdSelectPath.UseVisualStyleBackColor = true;
			cmdSelectPath.Click += cmdSelectPath_Click;
			cmdSelectPath.MouseUp += cmdSelectPath_MouseUp;
			// 
			// assembliesContextMenu
			// 
			assembliesContextMenu.Items.AddRange(new ToolStripItem[] { assembliesCopyMenuItem, assembliesCutMenuItem, assembliesPasteMenuItem, assembliesLine1, assembliesBrowseMenuItem, assembliesShowMenuItem });
			assembliesContextMenu.Name = "assembliesContextMenu";
			assembliesContextMenu.Size = new Size(166, 120);
			assembliesContextMenu.Opening += assembliesContextMenu_Opening;
			assembliesContextMenu.ItemClicked += assembliesContextMenu_ItemClicked;
			// 
			// assembliesCopyMenuItem
			// 
			assembliesCopyMenuItem.Name = "assembliesCopyMenuItem";
			assembliesCopyMenuItem.Size = new Size(165, 22);
			assembliesCopyMenuItem.Text = "Copy";
			// 
			// assembliesCutMenuItem
			// 
			assembliesCutMenuItem.Name = "assembliesCutMenuItem";
			assembliesCutMenuItem.Size = new Size(165, 22);
			assembliesCutMenuItem.Text = "Cut";
			// 
			// assembliesPasteMenuItem
			// 
			assembliesPasteMenuItem.Name = "assembliesPasteMenuItem";
			assembliesPasteMenuItem.Size = new Size(165, 22);
			assembliesPasteMenuItem.Text = "Paste";
			// 
			// assembliesLine1
			// 
			assembliesLine1.Name = "assembliesLine1";
			assembliesLine1.Size = new Size(162, 6);
			// 
			// assembliesBrowseMenuItem
			// 
			assembliesBrowseMenuItem.Name = "assembliesBrowseMenuItem";
			assembliesBrowseMenuItem.Size = new Size(165, 22);
			assembliesBrowseMenuItem.Text = "Browse from disk";
			// 
			// assembliesShowMenuItem
			// 
			assembliesShowMenuItem.Name = "assembliesShowMenuItem";
			assembliesShowMenuItem.Size = new Size(165, 22);
			assembliesShowMenuItem.Text = "Show resources";
			// 
			// folders
			// 
			folders.SelectedPath = "I:\\Code\\Nodes\\PipeMania\\PipeManiaService\\Resources";
			folders.ShowNewFolderButton = false;
			// 
			// gbAssemblies
			// 
			gbAssemblies.Controls.Add(assembliesBottomPanel);
			gbAssemblies.Controls.Add(assembliesTopPanel);
			gbAssemblies.Location = new Point(8, 319);
			gbAssemblies.Margin = new Padding(0, 4, 0, 8);
			gbAssemblies.Name = "gbAssemblies";
			gbAssemblies.Padding = new Padding(14, 12, 14, 14);
			gbAssemblies.Size = new Size(432, 107);
			gbAssemblies.TabIndex = 4;
			gbAssemblies.TabStop = false;
			gbAssemblies.Text = " Assemblies: ";
			// 
			// assembliesBottomPanel
			// 
			assembliesBottomPanel.Controls.Add(tbResourceNamePrefix);
			assembliesBottomPanel.Controls.Add(namePrefixLabel);
			assembliesBottomPanel.Dock = DockStyle.Top;
			assembliesBottomPanel.Location = new Point(14, 72);
			assembliesBottomPanel.Name = "assembliesBottomPanel";
			assembliesBottomPanel.Size = new Size(404, 36);
			assembliesBottomPanel.TabIndex = 6;
			// 
			// tbResourceNamePrefix
			// 
			tbResourceNamePrefix.BackColor = SystemColors.ControlLight;
			tbResourceNamePrefix.Dock = DockStyle.Fill;
			tbResourceNamePrefix.Location = new Point(94, 0);
			tbResourceNamePrefix.Margin = new Padding(0);
			tbResourceNamePrefix.MaxLength = 0;
			tbResourceNamePrefix.Name = "tbResourceNamePrefix";
			tbResourceNamePrefix.Size = new Size(310, 27);
			tbResourceNamePrefix.TabIndex = 1;
			tbResourceNamePrefix.Text = "localhost";
			tbResourceNamePrefix.Enter += tbResourceNamePrefix_Enter;
			// 
			// namePrefixLabel
			// 
			namePrefixLabel.AutoSize = true;
			namePrefixLabel.Dock = DockStyle.Left;
			namePrefixLabel.Location = new Point(0, 0);
			namePrefixLabel.Name = "namePrefixLabel";
			namePrefixLabel.Padding = new Padding(0, 2, 0, 0);
			namePrefixLabel.Size = new Size(94, 22);
			namePrefixLabel.TabIndex = 0;
			namePrefixLabel.Text = "Name prefix:";
			// 
			// assembliesTopPanel
			// 
			assembliesTopPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			assembliesTopPanel.Controls.Add(cbAssemblies);
			assembliesTopPanel.Controls.Add(cmdLoadAssembly);
			assembliesTopPanel.Dock = DockStyle.Top;
			assembliesTopPanel.Location = new Point(14, 32);
			assembliesTopPanel.Name = "assembliesTopPanel";
			assembliesTopPanel.Size = new Size(404, 40);
			assembliesTopPanel.TabIndex = 5;
			// 
			// cbAssemblies
			// 
			cbAssemblies.BackColor = SystemColors.ControlLight;
			cbAssemblies.ContextMenuStrip = assembliesContextMenu;
			cbAssemblies.IntegralHeight = false;
			cbAssemblies.Location = new Point(0, 0);
			cbAssemblies.Margin = new Padding(0);
			cbAssemblies.MaxDropDownItems = 12;
			cbAssemblies.Name = "cbAssemblies";
			cbAssemblies.Size = new Size(364, 28);
			cbAssemblies.TabIndex = 4;
			cbAssemblies.DropDown += cbAssemblies_DropDown;
			cbAssemblies.SelectedIndexChanged += cbAssemblies_SelectedIndexChanged;
			cbAssemblies.DropDownClosed += cbAssemblies_DropDownClosed;
			cbAssemblies.Enter += cbAssemblies_Enter;
			cbAssemblies.KeyDown += cbAssemblies_KeyDown;
			cbAssemblies.KeyPress += cbAssemblies_KeyPress;
			cbAssemblies.Leave += cbAssemblies_Leave;
			cbAssemblies.MouseDown += cbAssemblies_MouseDown;
			// 
			// cmdLoadAssembly
			// 
			cmdLoadAssembly.ContextMenuStrip = assembliesContextMenu;
			cmdLoadAssembly.Location = new Point(364, 0);
			cmdLoadAssembly.Margin = new Padding(0);
			cmdLoadAssembly.Name = "cmdLoadAssembly";
			cmdLoadAssembly.Size = new Size(40, 28);
			cmdLoadAssembly.TabIndex = 4;
			cmdLoadAssembly.TabStop = false;
			cmdLoadAssembly.Text = "...";
			cmdLoadAssembly.UseVisualStyleBackColor = true;
			cmdLoadAssembly.Click += cmdLoadAssembly_Click;
			cmdLoadAssembly.MouseUp += cmdLoadAssembly_MouseUp;
			// 
			// buttonLayout
			// 
			buttonLayout.AutoSize = true;
			buttonLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			buttonLayout.Controls.Add(cmdFileMode);
			buttonLayout.Controls.Add(cmdResourceMode);
			buttonLayout.Location = new Point(8, 172);
			buttonLayout.Margin = new Padding(0);
			buttonLayout.Name = "buttonLayout";
			buttonLayout.Size = new Size(428, 57);
			buttonLayout.TabIndex = 5;
			buttonLayout.WrapContents = false;
			// 
			// cmdFileMode
			// 
			cmdFileMode.Location = new Point(0, 4);
			cmdFileMode.Margin = new Padding(0, 4, 3, 4);
			cmdFileMode.Name = "cmdFileMode";
			cmdFileMode.Size = new Size(211, 49);
			cmdFileMode.TabIndex = 1;
			cmdFileMode.TabStop = false;
			cmdFileMode.Text = "&File based server";
			cmdFileMode.UseVisualStyleBackColor = true;
			cmdFileMode.Click += cmdFileMode_Click;
			cmdFileMode.MouseUp += button_MouseUp;
			// 
			// mainLayout
			// 
			mainLayout.AutoSize = true;
			mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			mainLayout.Controls.Add(statusPanel);
			mainLayout.Controls.Add(gbCertificate);
			mainLayout.Controls.Add(buttonLayout);
			mainLayout.Controls.Add(gbWebroot);
			mainLayout.Controls.Add(gbAssemblies);
			mainLayout.Controls.Add(startPanel);
			mainLayout.FlowDirection = FlowDirection.TopDown;
			mainLayout.Location = new Point(1, 27);
			mainLayout.Margin = new Padding(0);
			mainLayout.Name = "mainLayout";
			mainLayout.Padding = new Padding(8);
			mainLayout.Size = new Size(448, 505);
			mainLayout.TabIndex = 7;
			mainLayout.WrapContents = false;
			mainLayout.Resize += mainLayout_Resize;
			// 
			// statusPanel
			// 
			statusPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			statusPanel.Controls.Add(gbSiteName);
			statusPanel.Controls.Add(leftSitePortGap);
			statusPanel.Controls.Add(gbPort);
			statusPanel.Controls.Add(rightSitePortGap);
			statusPanel.Controls.Add(gbProtocol);
			statusPanel.Location = new Point(8, 8);
			statusPanel.Margin = new Padding(0);
			statusPanel.Name = "statusPanel";
			statusPanel.Size = new Size(429, 74);
			statusPanel.TabIndex = 0;
			// 
			// gbSiteName
			// 
			gbSiteName.Controls.Add(tbSiteName);
			gbSiteName.Dock = DockStyle.Fill;
			gbSiteName.Location = new Point(0, 0);
			gbSiteName.Name = "gbSiteName";
			gbSiteName.Padding = new Padding(14, 12, 14, 14);
			gbSiteName.Size = new Size(167, 74);
			gbSiteName.TabIndex = 0;
			gbSiteName.TabStop = false;
			gbSiteName.Text = " Site &name:";
			// 
			// tbSiteName
			// 
			tbSiteName.BackColor = SystemColors.ControlLight;
			tbSiteName.Dock = DockStyle.Fill;
			tbSiteName.Location = new Point(14, 32);
			tbSiteName.Margin = new Padding(0);
			tbSiteName.MaxLength = 0;
			tbSiteName.Name = "tbSiteName";
			tbSiteName.Size = new Size(139, 27);
			tbSiteName.TabIndex = 0;
			tbSiteName.Text = "localhost";
			tbSiteName.TextChanged += tbSiteName_TextChanged;
			tbSiteName.Enter += tbSiteName_Enter;
			tbSiteName.Leave += tbSiteName_Leave;
			tbSiteName.MouseUp += edit_MouseUp;
			tbSiteName.Resize += tbSiteName_Resize;
			// 
			// leftSitePortGap
			// 
			leftSitePortGap.Dock = DockStyle.Right;
			leftSitePortGap.Location = new Point(167, 0);
			leftSitePortGap.Name = "leftSitePortGap";
			leftSitePortGap.Size = new Size(6, 74);
			leftSitePortGap.TabIndex = 1;
			// 
			// gbPort
			// 
			gbPort.Controls.Add(tbPort);
			gbPort.Dock = DockStyle.Right;
			gbPort.Location = new Point(173, 0);
			gbPort.Name = "gbPort";
			gbPort.Padding = new Padding(14, 12, 14, 14);
			gbPort.Size = new Size(90, 74);
			gbPort.TabIndex = 1;
			gbPort.TabStop = false;
			gbPort.Text = " &Port: ";
			// 
			// tbPort
			// 
			tbPort.BackColor = SystemColors.ControlLight;
			tbPort.Dock = DockStyle.Fill;
			tbPort.Location = new Point(14, 32);
			tbPort.Margin = new Padding(0);
			tbPort.MaxLength = 5;
			tbPort.Name = "tbPort";
			tbPort.PlaceholderText = "1-65535";
			tbPort.Size = new Size(62, 27);
			tbPort.TabIndex = 1;
			tbPort.Text = "80";
			tbPort.TextAlign = HorizontalAlignment.Center;
			tbPort.TextChanged += tbPort_TextChanged;
			tbPort.Enter += tbPort_Enter;
			tbPort.Leave += tbPort_Leave;
			tbPort.MouseUp += edit_MouseUp;
			// 
			// rightSitePortGap
			// 
			rightSitePortGap.Dock = DockStyle.Right;
			rightSitePortGap.Location = new Point(263, 0);
			rightSitePortGap.Name = "rightSitePortGap";
			rightSitePortGap.Size = new Size(6, 74);
			rightSitePortGap.TabIndex = 3;
			// 
			// gbProtocol
			// 
			gbProtocol.Controls.Add(cbProtocol);
			gbProtocol.Dock = DockStyle.Right;
			gbProtocol.Location = new Point(269, 0);
			gbProtocol.Margin = new Padding(0, 4, 0, 0);
			gbProtocol.Name = "gbProtocol";
			gbProtocol.Padding = new Padding(14, 12, 14, 14);
			gbProtocol.Size = new Size(160, 74);
			gbProtocol.TabIndex = 2;
			gbProtocol.TabStop = false;
			gbProtocol.Text = " &Security protocol: ";
			// 
			// cbProtocol
			// 
			cbProtocol.BackColor = SystemColors.ControlLight;
			cbProtocol.Dock = DockStyle.Fill;
			cbProtocol.IntegralHeight = false;
			cbProtocol.Location = new Point(14, 32);
			cbProtocol.Margin = new Padding(0);
			cbProtocol.MaxDropDownItems = 12;
			cbProtocol.Name = "cbProtocol";
			cbProtocol.Size = new Size(132, 28);
			cbProtocol.TabIndex = 2;
			cbProtocol.SelectedIndexChanged += cbProtocol_SelectedIndexChanged;
			cbProtocol.TextChanged += cbProtocol_TextChanged;
			cbProtocol.Enter += cbProtocol_Enter;
			cbProtocol.KeyDown += cbProtocol_KeyDown;
			cbProtocol.KeyPress += cbProtocol_KeyPress;
			cbProtocol.Leave += cbProtocol_Leave;
			// 
			// gbCertificate
			// 
			gbCertificate.Controls.Add(tbCertificate);
			gbCertificate.Controls.Add(cmdSelectCertificate);
			gbCertificate.Enabled = false;
			gbCertificate.Location = new Point(8, 90);
			gbCertificate.Margin = new Padding(0, 8, 0, 8);
			gbCertificate.Name = "gbCertificate";
			gbCertificate.Padding = new Padding(14, 12, 14, 14);
			gbCertificate.Size = new Size(432, 74);
			gbCertificate.TabIndex = 3;
			gbCertificate.TabStop = false;
			gbCertificate.Text = " Load SSL &certifcate from: ";
			gbCertificate.Resize += gbCertificate_Resize;
			// 
			// tbCertificate
			// 
			tbCertificate.BackColor = SystemColors.ControlLight;
			tbCertificate.Dock = DockStyle.Fill;
			tbCertificate.Location = new Point(14, 32);
			tbCertificate.Margin = new Padding(0);
			tbCertificate.Name = "tbCertificate";
			tbCertificate.Size = new Size(364, 27);
			tbCertificate.TabIndex = 3;
			tbCertificate.TextChanged += tbCertificate_TextChanged;
			tbCertificate.Enter += tbCertificate_Enter;
			tbCertificate.Leave += tbCertificate_Leave;
			tbCertificate.MouseUp += edit_MouseUp;
			// 
			// cmdSelectCertificate
			// 
			cmdSelectCertificate.Dock = DockStyle.Right;
			cmdSelectCertificate.Location = new Point(378, 32);
			cmdSelectCertificate.Margin = new Padding(0);
			cmdSelectCertificate.MinimumSize = new Size(0, 27);
			cmdSelectCertificate.Name = "cmdSelectCertificate";
			cmdSelectCertificate.Size = new Size(40, 28);
			cmdSelectCertificate.TabIndex = 3;
			cmdSelectCertificate.TabStop = false;
			cmdSelectCertificate.Text = "...";
			cmdSelectCertificate.UseVisualStyleBackColor = true;
			cmdSelectCertificate.Click += cmdSelectCertificate_Click;
			// 
			// startPanel
			// 
			startPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			startPanel.AutoSize = true;
			startPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			startPanel.ColumnCount = 2;
			startPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			startPanel.ColumnStyles.Add(new ColumnStyle());
			startPanel.Controls.Add(gbSiteUri, 0, 0);
			startPanel.Controls.Add(cmdStart, 1, 0);
			startPanel.Location = new Point(8, 434);
			startPanel.Margin = new Padding(0);
			startPanel.Name = "startPanel";
			startPanel.RowStyles.Add(new RowStyle());
			startPanel.Size = new Size(432, 63);
			startPanel.TabIndex = 5;
			// 
			// gbSiteUri
			// 
			gbSiteUri.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			gbSiteUri.Controls.Add(uriLabel);
			gbSiteUri.Controls.Add(clientTargetPanel);
			gbSiteUri.Controls.Add(button3);
			gbSiteUri.Location = new Point(0, 0);
			gbSiteUri.Margin = new Padding(0);
			gbSiteUri.Name = "gbSiteUri";
			gbSiteUri.Padding = new Padding(0);
			gbSiteUri.Size = new Size(332, 63);
			gbSiteUri.TabIndex = 11;
			gbSiteUri.TabStop = false;
			gbSiteUri.Text = " Site addres:";
			// 
			// uriLabel
			// 
			uriLabel.AutoSize = true;
			uriLabel.ContextMenuStrip = siteUriContextMenu;
			uriLabel.Cursor = Cursors.Hand;
			uriLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Underline, GraphicsUnit.Point);
			uriLabel.Location = new Point(12, 30);
			uriLabel.Margin = new Padding(0);
			uriLabel.Name = "uriLabel";
			uriLabel.Size = new Size(120, 20);
			uriLabel.TabIndex = 7;
			uriLabel.Text = "https://localhost";
			uriLabel.MouseDown += uriLabel_MouseDown;
			uriLabel.MouseEnter += uriLabel_MouseEnter;
			uriLabel.MouseLeave += uriLabel_MouseLeave;
			// 
			// siteUriContextMenu
			// 
			siteUriContextMenu.AccessibleDescription = "";
			siteUriContextMenu.Items.AddRange(new ToolStripItem[] { siteUriOpenItem, siteUriLine1, siteUriCopyItem });
			siteUriContextMenu.Name = "siteUriContextMenu";
			siteUriContextMenu.Size = new Size(104, 54);
			siteUriContextMenu.ItemClicked += siteUriContextMenu_ItemClicked;
			// 
			// siteUriOpenItem
			// 
			siteUriOpenItem.Name = "siteUriOpenItem";
			siteUriOpenItem.Size = new Size(103, 22);
			siteUriOpenItem.Text = "Open";
			// 
			// siteUriLine1
			// 
			siteUriLine1.Name = "siteUriLine1";
			siteUriLine1.Size = new Size(100, 6);
			// 
			// siteUriCopyItem
			// 
			siteUriCopyItem.Name = "siteUriCopyItem";
			siteUriCopyItem.Size = new Size(103, 22);
			siteUriCopyItem.Text = "Copy";
			// 
			// clientTargetPanel
			// 
			clientTargetPanel.AutoSize = true;
			clientTargetPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			clientTargetPanel.Location = new Point(9, 34);
			clientTargetPanel.Margin = new Padding(0);
			clientTargetPanel.Name = "clientTargetPanel";
			clientTargetPanel.Size = new Size(0, 0);
			clientTargetPanel.TabIndex = 5;
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button3.AutoSize = true;
			button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button3.Location = new Point(904, 24);
			button3.Margin = new Padding(0);
			button3.Name = "button3";
			button3.Size = new Size(63, 30);
			button3.TabIndex = 1;
			button3.TabStop = false;
			button3.Text = "   OK   ";
			button3.UseVisualStyleBackColor = true;
			// 
			// cmdStart
			// 
			cmdStart.Anchor = AnchorStyles.Right;
			cmdStart.ContextMenuStrip = startContextMenu;
			cmdStart.Location = new Point(332, 9);
			cmdStart.Margin = new Padding(0, 6, 0, 0);
			cmdStart.Name = "cmdStart";
			cmdStart.Size = new Size(100, 51);
			cmdStart.TabIndex = 2;
			cmdStart.TabStop = false;
			cmdStart.Text = "Start ";
			cmdStart.UseVisualStyleBackColor = true;
			cmdStart.Click += cmdStart_Click;
			cmdStart.MouseUp += button_MouseUp;
			cmdStart.Resize += cmdStart_Resize;
			// 
			// startContextMenu
			// 
			startContextMenu.AccessibleDescription = "";
			startContextMenu.Items.AddRange(new ToolStripItem[] { startMenuItem, startLine1, makeJSONMenuItem, startLine2, parametersMenuItem });
			startContextMenu.Name = "siteUriContextMenu";
			startContextMenu.Size = new Size(210, 82);
			startContextMenu.ItemClicked += startContextMenu_ItemClicked;
			// 
			// startMenuItem
			// 
			startMenuItem.Name = "startMenuItem";
			startMenuItem.Size = new Size(209, 22);
			startMenuItem.Text = "&Start";
			startMenuItem.Click += startMenuItem_Click;
			// 
			// startLine1
			// 
			startLine1.Name = "startLine1";
			startLine1.Size = new Size(206, 6);
			// 
			// makeJSONMenuItem
			// 
			makeJSONMenuItem.Name = "makeJSONMenuItem";
			makeJSONMenuItem.Size = new Size(209, 22);
			makeJSONMenuItem.Text = "Make JSON";
			makeJSONMenuItem.Click += makeJSONMenuItem_Click;
			// 
			// startLine2
			// 
			startLine2.Name = "startLine2";
			startLine2.Size = new Size(206, 6);
			// 
			// parametersMenuItem
			// 
			parametersMenuItem.Name = "parametersMenuItem";
			parametersMenuItem.Size = new Size(209, 22);
			parametersMenuItem.Text = "Show current parameters ";
			parametersMenuItem.Click += parametersMenuItem_Click;
			// 
			// titlePanel
			// 
			titlePanel.Controls.Add(closeButton);
			titlePanel.Controls.Add(titleLabel);
			titlePanel.Dock = DockStyle.Top;
			titlePanel.Location = new Point(1, 1);
			titlePanel.Margin = new Padding(0);
			titlePanel.Name = "titlePanel";
			titlePanel.Size = new Size(609, 26);
			titlePanel.TabIndex = 11;
			titlePanel.Resize += titlePanel_Resize;
			// 
			// closeButton
			// 
			closeButton.Anchor = AnchorStyles.Right;
			closeButton.BackColor = SystemColors.ButtonFace;
			closeButton.BackgroundImage = Properties.Resources.closeX;
			closeButton.BackgroundImageLayout = ImageLayout.Stretch;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			closeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			closeButton.FlatStyle = FlatStyle.Flat;
			closeButton.Location = new Point(414, -1);
			closeButton.Margin = new Padding(3, 0, 0, 0);
			closeButton.Name = "closeButton";
			closeButton.Size = new Size(26, 27);
			closeButton.TabIndex = 15;
			closeButton.TabStop = false;
			closeButton.TextImageRelation = TextImageRelation.ImageAboveText;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += closeButton_Click;
			closeButton.MouseUp += button_MouseUp;
			// 
			// titleLabel
			// 
			titleLabel.Dock = DockStyle.Left;
			titleLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			titleLabel.Location = new Point(0, 0);
			titleLabel.Name = "titleLabel";
			titleLabel.Padding = new Padding(4);
			titleLabel.Size = new Size(446, 26);
			titleLabel.TabIndex = 2;
			titleLabel.Text = "Quick Start";
			titleLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// openAssemblyDialog
			// 
			openAssemblyDialog.DefaultExt = "dll";
			openAssemblyDialog.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.exe|Any|*.*";
			// 
			// openFileDialog1
			// 
			openFileDialog1.DefaultExt = "dll";
			openFileDialog1.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.exe|Any|*.*";
			// 
			// openFileDialog2
			// 
			openFileDialog2.DefaultExt = "dll";
			openFileDialog2.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.exe|Any|*.*";
			// 
			// openFileDialog3
			// 
			openFileDialog3.DefaultExt = "dll";
			openFileDialog3.Filter = "Default (*.dll;*.exe)|*.dll;*.exe|Libraries (*.dll)|*.dll|Executables (*.exe)|*.exe|Any|*.*";
			// 
			// openCertificateDialog
			// 
			openCertificateDialog.Filter = "Default (*.cer,*.pfx)|*.cer;*.pfx|Certificate file format (*.cer)|*.cer|Personal Information Exchange (*.pkx)|*.pfx|All files(*.*)|*.*";
			// 
			// passwordPanel
			// 
			passwordPanel.Controls.Add(certificateWaitLabel);
			passwordPanel.Controls.Add(gbPassword);
			passwordPanel.Dock = DockStyle.Fill;
			passwordPanel.Location = new Point(1, 1);
			passwordPanel.Name = "passwordPanel";
			passwordPanel.Size = new Size(609, 504);
			passwordPanel.TabIndex = 9;
			passwordPanel.Visible = false;
			passwordPanel.Resize += passwordPanel_Resize;
			// 
			// certificateWaitLabel
			// 
			certificateWaitLabel.AutoSize = true;
			certificateWaitLabel.BackColor = Color.Transparent;
			certificateWaitLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			certificateWaitLabel.ForeColor = Color.White;
			certificateWaitLabel.Location = new Point(70, 151);
			certificateWaitLabel.Name = "certificateWaitLabel";
			certificateWaitLabel.Size = new Size(305, 50);
			certificateWaitLabel.TabIndex = 10;
			certificateWaitLabel.Text = "Loading certificate,\rthis may take more then 5 minutes.";
			certificateWaitLabel.TextAlign = ContentAlignment.MiddleLeft;
			certificateWaitLabel.Visible = false;
			// 
			// gbPassword
			// 
			gbPassword.Controls.Add(cmdClosePasswordPanel);
			gbPassword.Controls.Add(cmdAcceptPassword);
			gbPassword.Controls.Add(tbPassword);
			gbPassword.Location = new Point(11, 0);
			gbPassword.Margin = new Padding(0);
			gbPassword.Name = "gbPassword";
			gbPassword.Padding = new Padding(0);
			gbPassword.Size = new Size(400, 74);
			gbPassword.TabIndex = 9;
			gbPassword.TabStop = false;
			gbPassword.Text = " Certificate file password(it can be empty): ";
			// 
			// cmdClosePasswordPanel
			// 
			cmdClosePasswordPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdClosePasswordPanel.AutoSize = true;
			cmdClosePasswordPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cmdClosePasswordPanel.Location = new Point(310, 29);
			cmdClosePasswordPanel.Margin = new Padding(0);
			cmdClosePasswordPanel.Name = "cmdClosePasswordPanel";
			cmdClosePasswordPanel.Size = new Size(79, 30);
			cmdClosePasswordPanel.TabIndex = 2;
			cmdClosePasswordPanel.TabStop = false;
			cmdClosePasswordPanel.Text = "  Cancel  ";
			cmdClosePasswordPanel.UseVisualStyleBackColor = true;
			cmdClosePasswordPanel.Click += cmdCancelSslTest_Click;
			// 
			// cmdAcceptPassword
			// 
			cmdAcceptPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cmdAcceptPassword.AutoSize = true;
			cmdAcceptPassword.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cmdAcceptPassword.Location = new Point(240, 29);
			cmdAcceptPassword.Margin = new Padding(0);
			cmdAcceptPassword.Name = "cmdAcceptPassword";
			cmdAcceptPassword.Size = new Size(63, 30);
			cmdAcceptPassword.TabIndex = 1;
			cmdAcceptPassword.TabStop = false;
			cmdAcceptPassword.Text = "   OK   ";
			cmdAcceptPassword.UseVisualStyleBackColor = true;
			cmdAcceptPassword.Click += cmdAcceptPassword_Click;
			// 
			// tbPassword
			// 
			tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbPassword.Location = new Point(12, 30);
			tbPassword.Margin = new Padding(0);
			tbPassword.Name = "tbPassword";
			tbPassword.Size = new Size(218, 27);
			tbPassword.TabIndex = 0;
			tbPassword.Text = "I:\\Code\\Nodes\\PipeMania\\PipeManiaService\\Resources";
			tbPassword.KeyDown += tbPassword_KeyDown;
			// 
			// cmdStartOptions
			// 
			cmdStartOptions.Anchor = AnchorStyles.Right;
			cmdStartOptions.BackgroundImage = Properties.Resources.dropDownArrow;
			cmdStartOptions.BackgroundImageLayout = ImageLayout.Stretch;
			cmdStartOptions.FlatAppearance.BorderSize = 0;
			cmdStartOptions.FlatAppearance.MouseOverBackColor = SystemColors.Menu;
			cmdStartOptions.Location = new Point(379, 239);
			cmdStartOptions.Margin = new Padding(0);
			cmdStartOptions.Name = "cmdStartOptions";
			cmdStartOptions.Size = new Size(18, 28);
			cmdStartOptions.TabIndex = 98;
			cmdStartOptions.TabStop = false;
			cmdStartOptions.UseMnemonic = false;
			cmdStartOptions.UseVisualStyleBackColor = true;
			cmdStartOptions.Click += cmdStartOptions_Click;
			cmdStartOptions.MouseUp += button_MouseUp;
			cmdStartOptions.Resize += cmdStartOptions_Resize;
			// 
			// QuickStartForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(611, 506);
			ControlBox = false;
			Controls.Add(mainLayout);
			Controls.Add(titlePanel);
			Controls.Add(passwordPanel);
			Controls.Add(cmdStartOptions);
			DoubleBuffered = true;
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "QuickStartForm";
			Opacity = 0D;
			Padding = new Padding(1);
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.Manual;
			Text = "Quick Start";
			gbWebroot.ResumeLayout(false);
			gbWebroot.PerformLayout();
			assembliesContextMenu.ResumeLayout(false);
			gbAssemblies.ResumeLayout(false);
			assembliesBottomPanel.ResumeLayout(false);
			assembliesBottomPanel.PerformLayout();
			assembliesTopPanel.ResumeLayout(false);
			buttonLayout.ResumeLayout(false);
			mainLayout.ResumeLayout(false);
			mainLayout.PerformLayout();
			statusPanel.ResumeLayout(false);
			gbSiteName.ResumeLayout(false);
			gbSiteName.PerformLayout();
			gbPort.ResumeLayout(false);
			gbPort.PerformLayout();
			gbProtocol.ResumeLayout(false);
			gbCertificate.ResumeLayout(false);
			gbCertificate.PerformLayout();
			startPanel.ResumeLayout(false);
			gbSiteUri.ResumeLayout(false);
			gbSiteUri.PerformLayout();
			siteUriContextMenu.ResumeLayout(false);
			startContextMenu.ResumeLayout(false);
			titlePanel.ResumeLayout(false);
			passwordPanel.ResumeLayout(false);
			passwordPanel.PerformLayout();
			gbPassword.ResumeLayout(false);
			gbPassword.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button cmdResourceMode;
        private CommonGroupBox gbWebroot;
        private TextBox tbWebroot;
		private Button cmdSelectPath;
        private FolderBrowserDialog folders;
        private CommonGroupBox gbAssemblies;
        private ComboBox cbAssemblies;
        private CommonFlowLayoutPanel buttonLayout;
        private CommonFlowLayoutPanel mainLayout;
        private OpenFileDialog openAssemblyDialog;
        private CommonGroupBox gbCertificate;
        private TextBox tbCertificate;
        private Button cmdSelectCertificate;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private OpenFileDialog openCertificateDialog;
        private CommonPanel passwordPanel;
        private CommonGroupBox gbPassword;
        private Button cmdAcceptPassword;
        private TextBox tbPassword;
        private Button cmdClosePasswordPanel;
		private Button cmdLoadAssembly;
        private CommonGroupBox gbProtocol;
        private ComboBox cbProtocol;
        private ContextMenuStrip assembliesContextMenu;
        private ToolStripMenuItem assembliesCopyMenuItem;
        private ToolStripMenuItem assembliesPasteMenuItem;
        private ToolStripMenuItem assembliesCutMenuItem;
        private ToolStripSeparator assembliesLine1;
        private ToolStripMenuItem assembliesBrowseMenuItem;
        private ToolStripMenuItem assembliesShowMenuItem;
        private CommonPanel statusPanel;
		private CommonPanel leftSitePortGap ;
        private CommonGroupBox gbSiteName;
        private TextBox tbSiteName;
        private CommonGroupBox gbPort;
        private TextBox tbPort;
		private Button cmdStart;
		private CommonGroupBox gbSiteUri;
		private CommonFlowLayoutPanel clientTargetPanel;
		private Button button3;
        private Button cmdFileMode;
        private ContextMenuStrip siteUriContextMenu;
		private ToolStripMenuItem siteUriOpenItem;
		private ToolStripSeparator siteUriLine1;
        private ToolStripMenuItem siteUriCopyItem;
        private CommonPanel rightSitePortGap;
        private ContextMenuStrip startContextMenu;
        private ToolStripMenuItem startMenuItem;
        private ToolStripSeparator startLine1;
        private ToolStripMenuItem parametersMenuItem;
		private CommonLabel certificateWaitLabel;
		private CommonTableLayoutPanel startPanel;
		private Button cmdStartOptions;
		private ToolStripMenuItem makeJSONMenuItem;
		private ToolStripSeparator startLine2;
		private CommonPanel titlePanel;
		private Button closeButton;
		private CommonLabel titleLabel;
		private CommonLabel uriLabel;
		private CommonPanel assembliesTopPanel;
		private CommonPanel assembliesBottomPanel;
		private TextBox tbResourceNamePrefix;
		private CommonLabel namePrefixLabel;
	}
}