namespace SimpleHttp
{
	partial class MonitorForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;



		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
			logList = new ListBox();
			logListMenu = new ContextMenuStrip(components);
			openLogMenuItem = new ToolStripMenuItem();
			logMenuLine0 = new ToolStripSeparator();
			deleteItemLogMenuItem = new ToolStripMenuItem();
			logMenuLine1 = new ToolStripSeparator();
			selectAllLogMenuItem = new ToolStripMenuItem();
			logPanel = new Panel();
			logListSplitter = new Splitter();
			requestGrid = new DataGridView();
			colName = new DataGridViewTextBoxColumn();
			colValue = new DataGridViewTextBoxColumn();
			gridContextMenu = new ContextMenuStrip(components);
			gridCopyMenuItem = new ToolStripMenuItem();
			gridLine0 = new ToolStripSeparator();
			gridSearchMenuItem = new ToolStripMenuItem();
			gridLine1 = new ToolStripSeparator();
			gridSelectAllMenuItem = new ToolStripMenuItem();
			labelCopyMenuItem = new ToolStripMenuItem();
			labelContextMenu = new ContextMenuStrip(components);
			midPanel = new Panel();
			propertiesPanel = new Panel();
			propertiesSplitter = new Splitter();
			responsePanel = new Panel();
			responseGrid = new DataGridView();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			responseTopPanel = new FlowLayoutPanel();
			responseLabel = new Label();
			requestPanel = new Panel();
			closePropertiesButton = new Button();
			requestTopPanel = new FlowLayoutPanel();
			errorLabel = new Label();
			linkContextMenu = new ContextMenuStrip(components);
			linkOpenMenuItem = new ToolStripMenuItem();
			folderOpenMenuItem = new ToolStripMenuItem();
			linkContextMenuLine1 = new ToolStripSeparator();
			linkCopyMenuItem = new ToolStripMenuItem();
			originLabel = new Label();
			methodLabel = new Label();
			requestLabel = new Label();
			httpLabel = new Label();
			requestBottomPanel = new Panel();
			jsonEditor = new CodeTextBox();
			resourceTypeLabel = new Label();
			notifyIcon = new NotifyIcon(components);
			iconMenu = new ContextMenuStrip(components);
			aboutMenuItem = new ToolStripMenuItem();
			toolStripSeparator0 = new ToolStripSeparator();
			startJSONConfigMenuItem = new ToolStripMenuItem();
			showQuickStartMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			showMainWindowMenuItem = new ToolStripMenuItem();
			showStartParametersMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			stopServerMenuItem = new ToolStripMenuItem();
			closeProgramMenuItem = new ToolStripMenuItem();
			menuButton = new Button();
			statusPanel = new FlowLayoutPanel();
			searchButton = new Button();
			searchLabel = new Label();
			searchBox = new TextBox();
			searchSplitter = new Splitter();
			uriLabel = new Label();
			resourceLabel = new Label();
			testLabel = new Label();
			topPanel = new Panel();
			buttonPanel = new FlowLayoutPanel();
			viewSwitch = new Button();
			monitorSwitch = new Button();
			startStopSwitch = new Button();
			configFileNameLabel = new Label();
			configContextMenu = new ContextMenuStrip(components);
			browseConfigFileMenuItem = new ToolStripMenuItem();
			toolStripSeparator4 = new ToolStripSeparator();
			saveConfigFileMenuItem = new ToolStripMenuItem();
			toolStripSeparator5 = new ToolStripSeparator();
			copyConfigNameMenuItem = new ToolStripMenuItem();
			configLabel = new Label();
			saveFileDialog = new SaveFileDialog();
			images24 = new ImageList(components);
			openFileDialog = new OpenFileDialog();
			logListMenu.SuspendLayout();
			logPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)requestGrid).BeginInit();
			gridContextMenu.SuspendLayout();
			labelContextMenu.SuspendLayout();
			midPanel.SuspendLayout();
			propertiesPanel.SuspendLayout();
			responsePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)responseGrid).BeginInit();
			responseTopPanel.SuspendLayout();
			requestPanel.SuspendLayout();
			requestTopPanel.SuspendLayout();
			linkContextMenu.SuspendLayout();
			iconMenu.SuspendLayout();
			statusPanel.SuspendLayout();
			topPanel.SuspendLayout();
			buttonPanel.SuspendLayout();
			configContextMenu.SuspendLayout();
			SuspendLayout();
			// 
			// logList
			// 
			logList.BackColor = SystemColors.ButtonFace;
			logList.ContextMenuStrip = logListMenu;
			logList.Dock = DockStyle.Fill;
			logList.DrawMode = DrawMode.OwnerDrawFixed;
			logList.FormattingEnabled = true;
			logList.IntegralHeight = false;
			logList.ItemHeight = 15;
			logList.Location = new Point(0, 0);
			logList.Margin = new Padding(3, 4, 3, 4);
			logList.Name = "logList";
			logList.SelectionMode = SelectionMode.MultiExtended;
			logList.Size = new Size(711, 525);
			logList.TabIndex = 0;
			logList.Click += logList_Click;
			logList.DrawItem += logList_DrawItem;
			logList.SelectedIndexChanged += logList_SelectedIndexChanged;
			logList.DoubleClick += logList_DoubleClick;
			logList.KeyDown += logList_KeyDown;
			logList.MouseUp += logList_MouseUp;
			// 
			// logListMenu
			// 
			logListMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			logListMenu.Items.AddRange(new ToolStripItem[] { openLogMenuItem, logMenuLine0, deleteItemLogMenuItem, logMenuLine1, selectAllLogMenuItem });
			logListMenu.Name = "logListMenu";
			logListMenu.Size = new Size(199, 82);
			logListMenu.Opening += logListMenu_Opening;
			logListMenu.ItemClicked += logListMenu_ItemClicked;
			// 
			// openLogMenuItem
			// 
			openLogMenuItem.Name = "openLogMenuItem";
			openLogMenuItem.Size = new Size(198, 22);
			openLogMenuItem.Text = "Open target address";
			// 
			// logMenuLine0
			// 
			logMenuLine0.Name = "logMenuLine0";
			logMenuLine0.Size = new Size(195, 6);
			// 
			// deleteItemLogMenuItem
			// 
			deleteItemLogMenuItem.Name = "deleteItemLogMenuItem";
			deleteItemLogMenuItem.ShortcutKeys = Keys.Delete;
			deleteItemLogMenuItem.Size = new Size(198, 22);
			deleteItemLogMenuItem.Text = "Delete";
			// 
			// logMenuLine1
			// 
			logMenuLine1.Name = "logMenuLine1";
			logMenuLine1.Size = new Size(195, 6);
			// 
			// selectAllLogMenuItem
			// 
			selectAllLogMenuItem.Name = "selectAllLogMenuItem";
			selectAllLogMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			selectAllLogMenuItem.Size = new Size(198, 22);
			selectAllLogMenuItem.Text = "Select all";
			// 
			// logPanel
			// 
			logPanel.Controls.Add(logList);
			logPanel.Dock = DockStyle.Fill;
			logPanel.Location = new Point(0, 0);
			logPanel.Margin = new Padding(0);
			logPanel.Name = "logPanel";
			logPanel.Padding = new Padding(0, 0, 2, 0);
			logPanel.Size = new Size(713, 525);
			logPanel.TabIndex = 0;
			// 
			// logListSplitter
			// 
			logListSplitter.Dock = DockStyle.Right;
			logListSplitter.Location = new Point(713, 0);
			logListSplitter.MinExtra = 200;
			logListSplitter.MinSize = 150;
			logListSplitter.Name = "logListSplitter";
			logListSplitter.Size = new Size(4, 525);
			logListSplitter.TabIndex = 1;
			logListSplitter.TabStop = false;
			logListSplitter.Visible = false;
			logListSplitter.MouseEnter += splitter_MouseEnter;
			logListSplitter.MouseLeave += splitter_MouseLeave;
			// 
			// requestGrid
			// 
			requestGrid.AllowUserToAddRows = false;
			requestGrid.AllowUserToDeleteRows = false;
			requestGrid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			requestGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			requestGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			requestGrid.BorderStyle = BorderStyle.None;
			requestGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
			requestGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			requestGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ButtonFace;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.Padding = new Padding(4, 2, 4, 2);
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			requestGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			requestGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			requestGrid.Columns.AddRange(new DataGridViewColumn[] { colName, colValue });
			requestGrid.ContextMenuStrip = gridContextMenu;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.Padding = new Padding(4, 2, 4, 2);
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			requestGrid.DefaultCellStyle = dataGridViewCellStyle3;
			requestGrid.Dock = DockStyle.Fill;
			requestGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
			requestGrid.EnableHeadersVisualStyles = false;
			requestGrid.Location = new Point(0, 69);
			requestGrid.Margin = new Padding(0);
			requestGrid.Name = "requestGrid";
			requestGrid.ReadOnly = true;
			requestGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			requestGrid.RowHeadersVisible = false;
			requestGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			requestGrid.RowTemplate.Height = 25;
			requestGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			requestGrid.ShowCellErrors = false;
			requestGrid.Size = new Size(269, 164);
			requestGrid.TabIndex = 1;
			requestGrid.CellMouseDown += requestGrid_CellMouseDown;
			requestGrid.Enter += requestGrid_Enter;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colName.FillWeight = 40F;
			colName.HeaderText = "Name";
			colName.Name = "colName";
			colName.ReadOnly = true;
			// 
			// colValue
			// 
			colValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colValue.FillWeight = 60F;
			colValue.HeaderText = "Value";
			colValue.Name = "colValue";
			colValue.ReadOnly = true;
			// 
			// gridContextMenu
			// 
			gridContextMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			gridContextMenu.Items.AddRange(new ToolStripItem[] { gridCopyMenuItem, gridLine0, gridSearchMenuItem, gridLine1, gridSelectAllMenuItem });
			gridContextMenu.Name = "gridContextMenu";
			gridContextMenu.Size = new Size(173, 82);
			gridContextMenu.Opening += gridContextMenu_Opening;
			gridContextMenu.ItemClicked += gridContextMenu_ItemClicked;
			// 
			// gridCopyMenuItem
			// 
			gridCopyMenuItem.Name = "gridCopyMenuItem";
			gridCopyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
			gridCopyMenuItem.Size = new Size(172, 22);
			gridCopyMenuItem.Text = "&Copy";
			// 
			// gridLine0
			// 
			gridLine0.Name = "gridLine0";
			gridLine0.Size = new Size(169, 6);
			// 
			// gridSearchMenuItem
			// 
			gridSearchMenuItem.Name = "gridSearchMenuItem";
			gridSearchMenuItem.Size = new Size(172, 22);
			gridSearchMenuItem.Text = "&Search internet";
			// 
			// gridLine1
			// 
			gridLine1.Name = "gridLine1";
			gridLine1.Size = new Size(169, 6);
			// 
			// gridSelectAllMenuItem
			// 
			gridSelectAllMenuItem.Name = "gridSelectAllMenuItem";
			gridSelectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			gridSelectAllMenuItem.Size = new Size(172, 22);
			gridSelectAllMenuItem.Text = "Select &all";
			// 
			// labelCopyMenuItem
			// 
			labelCopyMenuItem.Name = "labelCopyMenuItem";
			labelCopyMenuItem.Size = new Size(106, 22);
			labelCopyMenuItem.Text = "&Copy";
			// 
			// labelContextMenu
			// 
			labelContextMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			labelContextMenu.Items.AddRange(new ToolStripItem[] { labelCopyMenuItem });
			labelContextMenu.Name = "gridContextMenu";
			labelContextMenu.Size = new Size(107, 26);
			labelContextMenu.Opening += labelContextMenu_Opening;
			labelContextMenu.ItemClicked += labelContextMenu_ItemClicked;
			// 
			// midPanel
			// 
			midPanel.Controls.Add(logPanel);
			midPanel.Controls.Add(logListSplitter);
			midPanel.Controls.Add(propertiesPanel);
			midPanel.Dock = DockStyle.Fill;
			midPanel.Location = new Point(8, 39);
			midPanel.Margin = new Padding(0);
			midPanel.Name = "midPanel";
			midPanel.Size = new Size(987, 525);
			midPanel.TabIndex = 8;
			midPanel.Visible = false;
			midPanel.Resize += midPanel_Resize;
			// 
			// propertiesPanel
			// 
			propertiesPanel.Controls.Add(propertiesSplitter);
			propertiesPanel.Controls.Add(responsePanel);
			propertiesPanel.Controls.Add(requestPanel);
			propertiesPanel.Dock = DockStyle.Right;
			propertiesPanel.Location = new Point(717, 0);
			propertiesPanel.Margin = new Padding(0);
			propertiesPanel.Name = "propertiesPanel";
			propertiesPanel.Padding = new Padding(1, 0, 0, 0);
			propertiesPanel.Size = new Size(270, 525);
			propertiesPanel.TabIndex = 1;
			propertiesPanel.Visible = false;
			// 
			// propertiesSplitter
			// 
			propertiesSplitter.Dock = DockStyle.Top;
			propertiesSplitter.Location = new Point(1, 237);
			propertiesSplitter.Margin = new Padding(0);
			propertiesSplitter.Name = "propertiesSplitter";
			propertiesSplitter.Size = new Size(269, 4);
			propertiesSplitter.TabIndex = 7;
			propertiesSplitter.TabStop = false;
			propertiesSplitter.MouseEnter += splitter_MouseEnter;
			propertiesSplitter.MouseLeave += splitter_MouseLeave;
			// 
			// responsePanel
			// 
			responsePanel.Controls.Add(responseGrid);
			responsePanel.Controls.Add(responseTopPanel);
			responsePanel.Dock = DockStyle.Fill;
			responsePanel.Location = new Point(1, 237);
			responsePanel.Name = "responsePanel";
			responsePanel.Size = new Size(269, 288);
			responsePanel.TabIndex = 5;
			// 
			// responseGrid
			// 
			responseGrid.AllowUserToAddRows = false;
			responseGrid.AllowUserToDeleteRows = false;
			responseGrid.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.BackColor = SystemColors.ButtonFace;
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			responseGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			responseGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			responseGrid.BorderStyle = BorderStyle.None;
			responseGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
			responseGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.Control;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.Padding = new Padding(4, 2, 4, 2);
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			responseGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			responseGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			responseGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
			responseGrid.ContextMenuStrip = gridContextMenu;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.Padding = new Padding(4, 2, 4, 2);
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			responseGrid.DefaultCellStyle = dataGridViewCellStyle6;
			responseGrid.Dock = DockStyle.Fill;
			responseGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
			responseGrid.EnableHeadersVisualStyles = false;
			responseGrid.Location = new Point(0, 36);
			responseGrid.Margin = new Padding(3, 4, 3, 4);
			responseGrid.Name = "responseGrid";
			responseGrid.ReadOnly = true;
			responseGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = SystemColors.Window;
			dataGridViewCellStyle7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle7.Padding = new Padding(8, 2, 8, 2);
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			responseGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
			responseGrid.RowHeadersVisible = false;
			responseGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			responseGrid.RowTemplate.Height = 25;
			responseGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			responseGrid.Size = new Size(269, 252);
			responseGrid.TabIndex = 4;
			responseGrid.Enter += responseGrid_Enter;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewTextBoxColumn1.FillWeight = 40F;
			dataGridViewTextBoxColumn1.HeaderText = "Name";
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewTextBoxColumn2.FillWeight = 60F;
			dataGridViewTextBoxColumn2.HeaderText = "Value";
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// responseTopPanel
			// 
			responseTopPanel.AutoSize = true;
			responseTopPanel.Controls.Add(responseLabel);
			responseTopPanel.Dock = DockStyle.Top;
			responseTopPanel.Location = new Point(0, 0);
			responseTopPanel.Margin = new Padding(3, 4, 3, 4);
			responseTopPanel.Name = "responseTopPanel";
			responseTopPanel.Padding = new Padding(0, 6, 0, 5);
			responseTopPanel.Size = new Size(269, 36);
			responseTopPanel.TabIndex = 3;
			// 
			// responseLabel
			// 
			responseLabel.AutoSize = true;
			responseTopPanel.SetFlowBreak(responseLabel, true);
			responseLabel.Location = new Point(0, 11);
			responseLabel.Margin = new Padding(0, 5, 0, 0);
			responseLabel.Name = "responseLabel";
			responseLabel.Size = new Size(75, 20);
			responseLabel.TabIndex = 1;
			responseLabel.Text = "Response:";
			responseLabel.MouseDown += responseLabel_MouseDown;
			// 
			// requestPanel
			// 
			requestPanel.Controls.Add(requestGrid);
			requestPanel.Controls.Add(closePropertiesButton);
			requestPanel.Controls.Add(requestTopPanel);
			requestPanel.Controls.Add(requestBottomPanel);
			requestPanel.Dock = DockStyle.Top;
			requestPanel.Location = new Point(1, 0);
			requestPanel.Name = "requestPanel";
			requestPanel.Size = new Size(269, 237);
			requestPanel.TabIndex = 6;
			requestPanel.Layout += requestPanel_Layout;
			// 
			// closePropertiesButton
			// 
			closePropertiesButton.BackgroundImage = Properties.Resources.rightDoubleArrow;
			closePropertiesButton.BackgroundImageLayout = ImageLayout.Stretch;
			closePropertiesButton.FlatAppearance.BorderSize = 0;
			closePropertiesButton.FlatStyle = FlatStyle.Flat;
			closePropertiesButton.Location = new Point(177, 4);
			closePropertiesButton.Margin = new Padding(3, 4, 3, 4);
			closePropertiesButton.Name = "closePropertiesButton";
			closePropertiesButton.Size = new Size(18, 21);
			closePropertiesButton.TabIndex = 6;
			closePropertiesButton.TabStop = false;
			closePropertiesButton.TextImageRelation = TextImageRelation.ImageAboveText;
			closePropertiesButton.UseVisualStyleBackColor = false;
			closePropertiesButton.Click += closePropertiesButton_Click;
			// 
			// requestTopPanel
			// 
			requestTopPanel.AutoSize = true;
			requestTopPanel.Controls.Add(errorLabel);
			requestTopPanel.Controls.Add(originLabel);
			requestTopPanel.Controls.Add(methodLabel);
			requestTopPanel.Controls.Add(requestLabel);
			requestTopPanel.Controls.Add(httpLabel);
			requestTopPanel.Dock = DockStyle.Top;
			requestTopPanel.Location = new Point(0, 0);
			requestTopPanel.Margin = new Padding(0);
			requestTopPanel.Name = "requestTopPanel";
			requestTopPanel.Padding = new Padding(0, 0, 0, 5);
			requestTopPanel.Size = new Size(269, 69);
			requestTopPanel.TabIndex = 2;
			// 
			// errorLabel
			// 
			errorLabel.AutoSize = true;
			errorLabel.ContextMenuStrip = linkContextMenu;
			requestTopPanel.SetFlowBreak(errorLabel, true);
			errorLabel.ForeColor = Color.DarkRed;
			errorLabel.Location = new Point(0, 0);
			errorLabel.Margin = new Padding(0, 0, 5, 0);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(0, 20);
			errorLabel.TabIndex = 2;
			errorLabel.MouseDown += errorLabel_MouseDown;
			errorLabel.MouseEnter += errorLabel_MouseEnter;
			errorLabel.MouseLeave += errorLabel_MouseLeave;
			// 
			// linkContextMenu
			// 
			linkContextMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			linkContextMenu.Items.AddRange(new ToolStripItem[] { linkOpenMenuItem, folderOpenMenuItem, linkContextMenuLine1, linkCopyMenuItem });
			linkContextMenu.Name = "gridContextMenu";
			linkContextMenu.Size = new Size(148, 76);
			linkContextMenu.Opening += linkContextMenu_Opening;
			linkContextMenu.ItemClicked += linkContextMenu_ItemClicked;
			// 
			// linkOpenMenuItem
			// 
			linkOpenMenuItem.Name = "linkOpenMenuItem";
			linkOpenMenuItem.Size = new Size(147, 22);
			linkOpenMenuItem.Text = "&Open link";
			// 
			// folderOpenMenuItem
			// 
			folderOpenMenuItem.Name = "folderOpenMenuItem";
			folderOpenMenuItem.Size = new Size(147, 22);
			folderOpenMenuItem.Text = "Open &folder";
			// 
			// linkContextMenuLine1
			// 
			linkContextMenuLine1.Name = "linkContextMenuLine1";
			linkContextMenuLine1.Size = new Size(144, 6);
			// 
			// linkCopyMenuItem
			// 
			linkCopyMenuItem.Name = "linkCopyMenuItem";
			linkCopyMenuItem.Size = new Size(147, 22);
			linkCopyMenuItem.Text = "&Copy";
			// 
			// originLabel
			// 
			originLabel.AutoSize = true;
			originLabel.ContextMenuStrip = labelContextMenu;
			requestTopPanel.SetFlowBreak(originLabel, true);
			originLabel.Location = new Point(0, 20);
			originLabel.Margin = new Padding(0);
			originLabel.Name = "originLabel";
			originLabel.Size = new Size(64, 20);
			originLabel.TabIndex = 0;
			originLabel.Text = "Origin: ?";
			originLabel.TextAlign = ContentAlignment.MiddleLeft;
			originLabel.MouseDown += originLabel_MouseDown;
			// 
			// methodLabel
			// 
			methodLabel.AutoSize = true;
			methodLabel.ContextMenuStrip = labelContextMenu;
			methodLabel.Location = new Point(0, 44);
			methodLabel.Margin = new Padding(0, 2, 0, 0);
			methodLabel.Name = "methodLabel";
			methodLabel.Size = new Size(16, 20);
			methodLabel.TabIndex = 3;
			methodLabel.Text = "?";
			methodLabel.TextAlign = ContentAlignment.MiddleLeft;
			methodLabel.MouseDown += methodLabel_MouseDown;
			// 
			// requestLabel
			// 
			requestLabel.AutoSize = true;
			requestLabel.ContextMenuStrip = linkContextMenu;
			requestLabel.Cursor = Cursors.Hand;
			requestLabel.Location = new Point(16, 44);
			requestLabel.Margin = new Padding(0, 2, 0, 0);
			requestLabel.Name = "requestLabel";
			requestLabel.Padding = new Padding(2, 0, 2, 0);
			requestLabel.Size = new Size(19, 20);
			requestLabel.TabIndex = 1;
			requestLabel.Text = "/";
			requestLabel.TextAlign = ContentAlignment.MiddleLeft;
			requestLabel.MouseDown += requestLabel_MouseDown;
			requestLabel.MouseEnter += requestLabel_MouseEnter;
			requestLabel.MouseLeave += requestLabel_Mouseleave;
			// 
			// httpLabel
			// 
			httpLabel.AutoSize = true;
			httpLabel.ContextMenuStrip = labelContextMenu;
			requestTopPanel.SetFlowBreak(httpLabel, true);
			httpLabel.Location = new Point(35, 44);
			httpLabel.Margin = new Padding(0, 2, 0, 0);
			httpLabel.Name = "httpLabel";
			httpLabel.Size = new Size(16, 20);
			httpLabel.TabIndex = 4;
			httpLabel.Text = "?";
			httpLabel.TextAlign = ContentAlignment.MiddleLeft;
			httpLabel.MouseDown += httpLabel_MouseDown;
			// 
			// requestBottomPanel
			// 
			requestBottomPanel.Dock = DockStyle.Bottom;
			requestBottomPanel.Location = new Point(0, 233);
			requestBottomPanel.Margin = new Padding(0);
			requestBottomPanel.Name = "requestBottomPanel";
			requestBottomPanel.Size = new Size(269, 4);
			requestBottomPanel.TabIndex = 9;
			// 
			// jsonEditor
			// 
			jsonEditor.AcceptsReturn = true;
			jsonEditor.AcceptsTab = true;
			jsonEditor.AccessibleRole = AccessibleRole.Document;
			jsonEditor.AllowDrop = true;
			jsonEditor.Dock = DockStyle.Fill;
			jsonEditor.HideSelection = false;
			jsonEditor.Location = new Point(8, 39);
			jsonEditor.Margin = new Padding(0);
			jsonEditor.Multiline = true;
			jsonEditor.Name = "jsonEditor";
			jsonEditor.ScrollBars = ScrollBars.Both;
			jsonEditor.Size = new Size(987, 525);
			jsonEditor.TabIndex = 10;
			jsonEditor.WordWrap = false;
			jsonEditor.Click += jsonEditor_Click;
			jsonEditor.VisibleChanged += jsonEditor_VisibleChanged;
			// 
			// resourceTypeLabel
			// 
			resourceTypeLabel.AutoSize = true;
			resourceTypeLabel.ContextMenuStrip = labelContextMenu;
			resourceTypeLabel.Location = new Point(225, 4);
			resourceTypeLabel.Margin = new Padding(0);
			resourceTypeLabel.Name = "resourceTypeLabel";
			resourceTypeLabel.Padding = new Padding(0, 2, 0, 2);
			resourceTypeLabel.Size = new Size(88, 24);
			resourceTypeLabel.TabIndex = 4;
			resourceTypeLabel.Text = "Not started ";
			resourceTypeLabel.TextAlign = ContentAlignment.MiddleCenter;
			resourceTypeLabel.MouseDown += resourceTypeLabel_MouseDown;
			// 
			// notifyIcon
			// 
			notifyIcon.ContextMenuStrip = iconMenu;
			notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
			notifyIcon.Text = "...";
			notifyIcon.Visible = true;
			notifyIcon.MouseDown += notifyIcon_MouseDown;
			notifyIcon.MouseUp += notifyIcon_MouseUp;
			// 
			// iconMenu
			// 
			iconMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			iconMenu.ImageScalingSize = new Size(1, 1);
			iconMenu.Items.AddRange(new ToolStripItem[] { aboutMenuItem, toolStripSeparator0, startJSONConfigMenuItem, showQuickStartMenuItem, toolStripSeparator1, showMainWindowMenuItem, showStartParametersMenuItem, toolStripSeparator2, stopServerMenuItem, closeProgramMenuItem });
			iconMenu.Name = "iconMenu";
			iconMenu.RenderMode = ToolStripRenderMode.Professional;
			iconMenu.ShowImageMargin = false;
			iconMenu.Size = new Size(206, 204);
			iconMenu.Opening += iconMenu_Opening;
			iconMenu.ItemClicked += iconMenu_ItemClicked;
			// 
			// aboutMenuItem
			// 
			aboutMenuItem.Margin = new Padding(0, 2, 0, 2);
			aboutMenuItem.Name = "aboutMenuItem";
			aboutMenuItem.Padding = new Padding(0, 2, 0, 0);
			aboutMenuItem.Size = new Size(205, 22);
			aboutMenuItem.Text = "About the program";
			// 
			// toolStripSeparator0
			// 
			toolStripSeparator0.Name = "toolStripSeparator0";
			toolStripSeparator0.Size = new Size(202, 6);
			// 
			// startJSONConfigMenuItem
			// 
			startJSONConfigMenuItem.Margin = new Padding(0, 2, 0, 2);
			startJSONConfigMenuItem.Name = "startJSONConfigMenuItem";
			startJSONConfigMenuItem.Padding = new Padding(0, 2, 0, 0);
			startJSONConfigMenuItem.Size = new Size(205, 22);
			startJSONConfigMenuItem.Text = "Start current configuration";
			// 
			// showQuickStartMenuItem
			// 
			showQuickStartMenuItem.Margin = new Padding(0, 2, 0, 2);
			showQuickStartMenuItem.Name = "showQuickStartMenuItem";
			showQuickStartMenuItem.Padding = new Padding(0, 2, 0, 0);
			showQuickStartMenuItem.Size = new Size(205, 22);
			showQuickStartMenuItem.Text = "Show quick start form";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(202, 6);
			// 
			// showMainWindowMenuItem
			// 
			showMainWindowMenuItem.Margin = new Padding(0, 2, 0, 2);
			showMainWindowMenuItem.Name = "showMainWindowMenuItem";
			showMainWindowMenuItem.Padding = new Padding(0, 2, 0, 0);
			showMainWindowMenuItem.Size = new Size(205, 22);
			showMainWindowMenuItem.Text = "Show";
			// 
			// showStartParametersMenuItem
			// 
			showStartParametersMenuItem.Margin = new Padding(0, 2, 0, 2);
			showStartParametersMenuItem.Name = "showStartParametersMenuItem";
			showStartParametersMenuItem.Padding = new Padding(0, 2, 0, 0);
			showStartParametersMenuItem.Size = new Size(205, 22);
			showStartParametersMenuItem.Text = "Show starting parameters";
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(202, 6);
			// 
			// stopServerMenuItem
			// 
			stopServerMenuItem.Margin = new Padding(0, 2, 0, 2);
			stopServerMenuItem.Name = "stopServerMenuItem";
			stopServerMenuItem.Padding = new Padding(0, 2, 0, 0);
			stopServerMenuItem.Size = new Size(205, 22);
			stopServerMenuItem.Text = "Stop http server";
			// 
			// closeProgramMenuItem
			// 
			closeProgramMenuItem.Margin = new Padding(0, 2, 0, 2);
			closeProgramMenuItem.Name = "closeProgramMenuItem";
			closeProgramMenuItem.Padding = new Padding(0, 2, 0, 0);
			closeProgramMenuItem.Size = new Size(205, 22);
			closeProgramMenuItem.Text = "Close program and server";
			// 
			// menuButton
			// 
			menuButton.BackgroundImage = Properties.Resources.settings;
			menuButton.BackgroundImageLayout = ImageLayout.Stretch;
			menuButton.FlatAppearance.BorderSize = 0;
			menuButton.FlatStyle = FlatStyle.Flat;
			menuButton.Location = new Point(248, 4);
			menuButton.Margin = new Padding(3, 4, 3, 4);
			menuButton.Name = "menuButton";
			menuButton.Size = new Size(26, 27);
			menuButton.TabIndex = 5;
			menuButton.TabStop = false;
			menuButton.TextImageRelation = TextImageRelation.ImageAboveText;
			menuButton.UseVisualStyleBackColor = false;
			menuButton.MouseDown += stopButton_MouseDown;
			// 
			// statusPanel
			// 
			statusPanel.AutoSize = true;
			statusPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			statusPanel.Controls.Add(searchButton);
			statusPanel.Controls.Add(searchLabel);
			statusPanel.Controls.Add(searchBox);
			statusPanel.Controls.Add(searchSplitter);
			statusPanel.Controls.Add(uriLabel);
			statusPanel.Controls.Add(resourceTypeLabel);
			statusPanel.Controls.Add(resourceLabel);
			statusPanel.Location = new Point(0, 0);
			statusPanel.Margin = new Padding(0);
			statusPanel.Name = "statusPanel";
			statusPanel.Padding = new Padding(0, 4, 0, 0);
			statusPanel.Size = new Size(313, 31);
			statusPanel.TabIndex = 6;
			// 
			// searchButton
			// 
			searchButton.BackgroundImage = Properties.Resources.searchIcon;
			searchButton.BackgroundImageLayout = ImageLayout.Zoom;
			searchButton.FlatAppearance.BorderSize = 0;
			searchButton.FlatStyle = FlatStyle.Flat;
			searchButton.Location = new Point(0, 4);
			searchButton.Margin = new Padding(0);
			searchButton.Name = "searchButton";
			searchButton.RightToLeft = RightToLeft.Yes;
			searchButton.Size = new Size(25, 27);
			searchButton.TabIndex = 10;
			searchButton.TabStop = false;
			searchButton.TextImageRelation = TextImageRelation.ImageAboveText;
			searchButton.UseVisualStyleBackColor = false;
			searchButton.Visible = false;
			searchButton.Click += searchButton_Click;
			// 
			// searchLabel
			// 
			searchLabel.AutoSize = true;
			searchLabel.ContextMenuStrip = labelContextMenu;
			searchLabel.Location = new Point(25, 4);
			searchLabel.Margin = new Padding(0);
			searchLabel.Name = "searchLabel";
			searchLabel.Padding = new Padding(0, 2, 0, 2);
			searchLabel.Size = new Size(56, 24);
			searchLabel.TabIndex = 8;
			searchLabel.Text = "Search:";
			searchLabel.TextAlign = ContentAlignment.MiddleCenter;
			searchLabel.Visible = false;
			// 
			// searchBox
			// 
			searchBox.Location = new Point(81, 4);
			searchBox.Margin = new Padding(0);
			searchBox.MaximumSize = new Size(330, 0);
			searchBox.MinimumSize = new Size(50, 0);
			searchBox.Name = "searchBox";
			searchBox.Size = new Size(140, 27);
			searchBox.TabIndex = 0;
			searchBox.Visible = false;
			searchBox.TextChanged += searchBox_TextChanged;
			searchBox.KeyDown += searchBox_KeyDown;
			searchBox.Resize += searchBox_Resize;
			// 
			// searchSplitter
			// 
			searchSplitter.Location = new Point(221, 4);
			searchSplitter.Margin = new Padding(0);
			searchSplitter.MinExtra = 0;
			searchSplitter.MinSize = 0;
			searchSplitter.Name = "searchSplitter";
			searchSplitter.Size = new Size(4, 27);
			searchSplitter.TabIndex = 9;
			searchSplitter.TabStop = false;
			searchSplitter.Visible = false;
			searchSplitter.SplitterMoving += searchSplitter_SplitterMoving;
			searchSplitter.SplitterMoved += searchSplitter_SplitterMoved;
			searchSplitter.MouseDown += searchSplitter_MouseDown;
			searchSplitter.MouseEnter += splitter_MouseEnter;
			searchSplitter.MouseLeave += splitter_MouseLeave;
			searchSplitter.MouseUp += searchSplitter_MouseUp;
			// 
			// uriLabel
			// 
			uriLabel.AutoSize = true;
			uriLabel.ContextMenuStrip = linkContextMenu;
			uriLabel.Cursor = Cursors.Hand;
			uriLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
			uriLabel.Location = new Point(225, 4);
			uriLabel.Margin = new Padding(0);
			uriLabel.Name = "uriLabel";
			uriLabel.Padding = new Padding(0, 2, 0, 2);
			uriLabel.Size = new Size(0, 19);
			uriLabel.TabIndex = 5;
			uriLabel.TextAlign = ContentAlignment.MiddleLeft;
			uriLabel.TextChanged += uriLabel_TextChanged;
			uriLabel.MouseDown += uriLabel_MouseDown;
			uriLabel.MouseEnter += uriLabel_MouseEnter;
			uriLabel.MouseLeave += uriLabel_MouseLeave;
			// 
			// resourceLabel
			// 
			resourceLabel.AutoSize = true;
			resourceLabel.ContextMenuStrip = linkContextMenu;
			resourceLabel.Cursor = Cursors.Hand;
			resourceLabel.Location = new Point(313, 4);
			resourceLabel.Margin = new Padding(0);
			resourceLabel.Name = "resourceLabel";
			resourceLabel.Padding = new Padding(0, 2, 0, 2);
			resourceLabel.Size = new Size(0, 24);
			resourceLabel.TabIndex = 6;
			resourceLabel.TextAlign = ContentAlignment.MiddleLeft;
			resourceLabel.MouseDown += resourceLabel_MouseDown;
			resourceLabel.MouseEnter += resourceLabel_MouseEnter;
			resourceLabel.MouseLeave += resourceLabel_MouseLeave;
			// 
			// testLabel
			// 
			testLabel.AutoSize = true;
			testLabel.Location = new Point(-399, -271);
			testLabel.Margin = new Padding(0);
			testLabel.Name = "testLabel";
			testLabel.Padding = new Padding(3);
			testLabel.Size = new Size(90, 26);
			testLabel.TabIndex = 7;
			testLabel.Text = "Not started";
			// 
			// topPanel
			// 
			topPanel.AutoSize = true;
			topPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			topPanel.Controls.Add(buttonPanel);
			topPanel.Controls.Add(statusPanel);
			topPanel.Dock = DockStyle.Top;
			topPanel.Location = new Point(8, 4);
			topPanel.Margin = new Padding(0);
			topPanel.Name = "topPanel";
			topPanel.Padding = new Padding(0, 0, 0, 4);
			topPanel.Size = new Size(987, 35);
			topPanel.TabIndex = 8;
			topPanel.Resize += topPanel_Resize;
			// 
			// buttonPanel
			// 
			buttonPanel.AutoSize = true;
			buttonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			buttonPanel.Controls.Add(menuButton);
			buttonPanel.Controls.Add(viewSwitch);
			buttonPanel.Controls.Add(monitorSwitch);
			buttonPanel.Controls.Add(startStopSwitch);
			buttonPanel.Controls.Add(configFileNameLabel);
			buttonPanel.Controls.Add(configLabel);
			buttonPanel.Dock = DockStyle.Right;
			buttonPanel.FlowDirection = FlowDirection.RightToLeft;
			buttonPanel.Location = new Point(710, 0);
			buttonPanel.Margin = new Padding(0);
			buttonPanel.Name = "buttonPanel";
			buttonPanel.Size = new Size(277, 31);
			buttonPanel.TabIndex = 10;
			buttonPanel.WrapContents = false;
			// 
			// viewSwitch
			// 
			viewSwitch.BackgroundImage = Properties.Resources.monitor;
			viewSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			viewSwitch.FlatAppearance.BorderSize = 0;
			viewSwitch.FlatStyle = FlatStyle.Flat;
			viewSwitch.Location = new Point(216, 4);
			viewSwitch.Margin = new Padding(3, 4, 3, 4);
			viewSwitch.Name = "viewSwitch";
			viewSwitch.Size = new Size(26, 27);
			viewSwitch.TabIndex = 7;
			viewSwitch.TabStop = false;
			viewSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			viewSwitch.UseVisualStyleBackColor = false;
			viewSwitch.Click += viewSwitch_Click;
			viewSwitch.MouseEnter += viewSwitch_MouseEnter;
			viewSwitch.MouseLeave += viewSwitch_MouseLeave;
			// 
			// monitorSwitch
			// 
			monitorSwitch.BackgroundImage = Properties.Resources.monWhite;
			monitorSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			monitorSwitch.FlatAppearance.BorderSize = 0;
			monitorSwitch.FlatStyle = FlatStyle.Flat;
			monitorSwitch.Location = new Point(184, 4);
			monitorSwitch.Margin = new Padding(3, 4, 3, 4);
			monitorSwitch.Name = "monitorSwitch";
			monitorSwitch.Size = new Size(26, 27);
			monitorSwitch.TabIndex = 8;
			monitorSwitch.TabStop = false;
			monitorSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			monitorSwitch.UseVisualStyleBackColor = false;
			monitorSwitch.Click += monitorSwitch_Click;
			// 
			// startStopSwitch
			// 
			startStopSwitch.BackgroundImage = Properties.Resources.play;
			startStopSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			startStopSwitch.FlatAppearance.BorderSize = 0;
			startStopSwitch.FlatStyle = FlatStyle.Flat;
			startStopSwitch.Location = new Point(152, 4);
			startStopSwitch.Margin = new Padding(3, 4, 3, 4);
			startStopSwitch.Name = "startStopSwitch";
			startStopSwitch.Size = new Size(26, 27);
			startStopSwitch.TabIndex = 9;
			startStopSwitch.TabStop = false;
			startStopSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			startStopSwitch.UseVisualStyleBackColor = false;
			startStopSwitch.Click += startStopSwitch_Click;
			// 
			// configFileNameLabel
			// 
			configFileNameLabel.AutoSize = true;
			configFileNameLabel.ContextMenuStrip = configContextMenu;
			configFileNameLabel.Cursor = Cursors.Hand;
			configFileNameLabel.Location = new Point(56, 6);
			configFileNameLabel.Margin = new Padding(0, 6, 0, 0);
			configFileNameLabel.Name = "configFileNameLabel";
			configFileNameLabel.Padding = new Padding(0, 2, 0, 2);
			configFileNameLabel.Size = new Size(93, 24);
			configFileNameLabel.TabIndex = 10;
			configFileNameLabel.Text = "<not saved>";
			configFileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
			configFileNameLabel.MouseDown += configFileNameLabel_MouseDown;
			configFileNameLabel.MouseEnter += configFileNameLabel_MouseEnter;
			configFileNameLabel.MouseLeave += configFileNameLabel_MouseLeave;
			// 
			// configContextMenu
			// 
			configContextMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			configContextMenu.Items.AddRange(new ToolStripItem[] { browseConfigFileMenuItem, toolStripSeparator4, saveConfigFileMenuItem, toolStripSeparator5, copyConfigNameMenuItem });
			configContextMenu.Name = "gridContextMenu";
			configContextMenu.Size = new Size(185, 82);
			configContextMenu.Opening += configContextMenu_Opening;
			configContextMenu.ItemClicked += configContextMenu_ItemClicked;
			// 
			// browseConfigFileMenuItem
			// 
			browseConfigFileMenuItem.Name = "browseConfigFileMenuItem";
			browseConfigFileMenuItem.Size = new Size(184, 22);
			browseConfigFileMenuItem.Text = "&Browse";
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new Size(181, 6);
			// 
			// saveConfigFileMenuItem
			// 
			saveConfigFileMenuItem.Name = "saveConfigFileMenuItem";
			saveConfigFileMenuItem.Size = new Size(184, 22);
			saveConfigFileMenuItem.Text = "Save configuration";
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(181, 6);
			// 
			// copyConfigNameMenuItem
			// 
			copyConfigNameMenuItem.Name = "copyConfigNameMenuItem";
			copyConfigNameMenuItem.Size = new Size(184, 22);
			copyConfigNameMenuItem.Text = "&Copy with full path";
			// 
			// configLabel
			// 
			configLabel.AutoSize = true;
			configLabel.ContextMenuStrip = linkContextMenu;
			configLabel.Location = new Point(0, 6);
			configLabel.Margin = new Padding(0, 6, 0, 0);
			configLabel.Name = "configLabel";
			configLabel.Padding = new Padding(0, 2, 0, 2);
			configLabel.Size = new Size(56, 24);
			configLabel.TabIndex = 11;
			configLabel.Text = "Config:";
			configLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// saveFileDialog
			// 
			saveFileDialog.DefaultExt = "json";
			saveFileDialog.Filter = "JSON|*.json|Any file|*.*";
			saveFileDialog.SupportMultiDottedExtensions = true;
			saveFileDialog.Title = "Save configuration";
			// 
			// images24
			// 
			images24.ColorDepth = ColorDepth.Depth32Bit;
			images24.ImageStream = (ImageListStreamer)resources.GetObject("images24.ImageStream");
			images24.TransparentColor = Color.Transparent;
			images24.Images.SetKeyName(0, "json");
			images24.Images.SetKeyName(1, "log");
			images24.Images.SetKeyName(2, "logRed");
			images24.Images.SetKeyName(3, "monitor");
			images24.Images.SetKeyName(4, "stop");
			images24.Images.SetKeyName(5, "play");
			images24.Images.SetKeyName(6, "monGreen");
			images24.Images.SetKeyName(7, "monRed");
			images24.Images.SetKeyName(8, "monWhite");
			images24.Images.SetKeyName(9, "monYellow");
			images24.Images.SetKeyName(10, "monWhiteCheck");
			images24.Images.SetKeyName(11, "monitorHover");
			// 
			// openFileDialog
			// 
			openFileDialog.Filter = "JSON files(*.json)|*.json|text files(*.txt)|*.txt|any(*.*)|*.*";
			// 
			// MonitorForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1003, 572);
			Controls.Add(midPanel);
			Controls.Add(testLabel);
			Controls.Add(jsonEditor);
			Controls.Add(topPanel);
			DoubleBuffered = true;
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MinimumSize = new Size(600, 360);
			Name = "MonitorForm";
			Opacity = 0D;
			Padding = new Padding(8, 4, 8, 8);
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Show;
			Text = "Simple Http Server Connection Monitor";
			logListMenu.ResumeLayout(false);
			logPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)requestGrid).EndInit();
			gridContextMenu.ResumeLayout(false);
			labelContextMenu.ResumeLayout(false);
			midPanel.ResumeLayout(false);
			propertiesPanel.ResumeLayout(false);
			responsePanel.ResumeLayout(false);
			responsePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)responseGrid).EndInit();
			responseTopPanel.ResumeLayout(false);
			responseTopPanel.PerformLayout();
			requestPanel.ResumeLayout(false);
			requestPanel.PerformLayout();
			requestTopPanel.ResumeLayout(false);
			requestTopPanel.PerformLayout();
			linkContextMenu.ResumeLayout(false);
			iconMenu.ResumeLayout(false);
			statusPanel.ResumeLayout(false);
			statusPanel.PerformLayout();
			topPanel.ResumeLayout(false);
			topPanel.PerformLayout();
			buttonPanel.ResumeLayout(false);
			buttonPanel.PerformLayout();
			configContextMenu.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}


		#endregion

		private Panel logPanel ;
		private ListBox logList;
		private Splitter logListSplitter;
		private DataGridView requestGrid;
		private Panel midPanel;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colValue;
        private FlowLayoutPanel requestTopPanel;
		private Label originLabel;
        private Label requestLabel;
        private Label resourceTypeLabel;
		private NotifyIcon notifyIcon;
        private Button menuButton;
		private ContextMenuStrip iconMenu;
        private ToolStripMenuItem showMainWindowMenuItem;
        private ToolStripSeparator toolStripSeparator0;
        private ToolStripMenuItem stopServerMenuItem;
        private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem closeProgramMenuItem;
		private Panel propertiesPanel ;
        private ToolStripMenuItem showQuickStartMenuItem;
        private Label errorLabel;
        private FlowLayoutPanel statusPanel;
		private Label uriLabel;
        private ContextMenuStrip logListMenu;
        private ToolStripMenuItem deleteItemLogMenuItem;
        private ToolStripMenuItem selectAllLogMenuItem;
		private ContextMenuStrip gridContextMenu;
		private ToolStripMenuItem gridCopyMenuItem;
		private ToolStripMenuItem gridSelectAllMenuItem;
		private ToolStripSeparator gridLine0;
        private Label resourceLabel;
        private ContextMenuStrip linkContextMenu;
        private ToolStripMenuItem linkOpenMenuItem;
        private ToolStripSeparator linkContextMenuLine1;
		private ToolStripMenuItem linkCopyMenuItem;
        private ContextMenuStrip labelContextMenu;
        private ToolStripMenuItem labelCopyMenuItem;
        private Label httpLabel;
        private ToolStripMenuItem openLogMenuItem;
		private Label testLabel;
        private ToolStripMenuItem showStartParametersMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem gridSearchMenuItem;
        private ToolStripSeparator gridLine1;
        private TextBox searchBox;
        private ToolStripSeparator logMenuLine0;
        private ToolStripSeparator logMenuLine1;
        private Panel topPanel;
		private Label searchLabel;
        private Splitter searchSplitter;
        private Button searchButton;
        public Label methodLabel;
		private Panel responsePanel;
		private DataGridView responseGrid;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private FlowLayoutPanel responseTopPanel;
		private Label responseLabel;
		private Splitter propertiesSplitter;
		private Panel requestPanel;
		private Button closePropertiesButton;
		private Panel requestBottomPanel;
        private CodeTextBox jsonEditor;
		private ToolStripMenuItem folderOpenMenuItem;
		private SaveFileDialog saveFileDialog;
		private ToolStripMenuItem startJSONConfigMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private Button viewSwitch;
		private Button monitorSwitch;
		private ImageList images24;
		private Button startStopSwitch;
		private FlowLayoutPanel buttonPanel;
		private Label configFileNameLabel;
		private Label configLabel;
		private ContextMenuStrip configContextMenu;
		private ToolStripMenuItem browseConfigFileMenuItem;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripMenuItem saveConfigFileMenuItem;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem copyConfigNameMenuItem;
		private OpenFileDialog openFileDialog;
	}
}