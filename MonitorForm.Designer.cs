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
			logPanel = new CommonPanel();
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
			midPanel = new CommonPanel();
			propertiesPanel = new CommonPanel();
			propertiesSplitter = new Splitter();
			responsePanel = new CommonPanel();
			responseGrid = new DataGridView();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			responseTopPanel = new CommonFlowLayoutPanel();
			responseLabel = new CommonLabel();
			requestPanel = new CommonPanel();
			closePropertiesButton = new Button();
			requestTopPanel = new CommonFlowLayoutPanel();
			errorLabel = new CommonLabel();
			linkContextMenu = new ContextMenuStrip(components);
			linkOpenMenuItem = new ToolStripMenuItem();
			folderOpenMenuItem = new ToolStripMenuItem();
			linkContextMenuLine1 = new ToolStripSeparator();
			linkCopyMenuItem = new ToolStripMenuItem();
			originLabel = new CommonLabel();
			methodLabel = new CommonLabel();
			requestLabel = new CommonLabel();
			httpLabel = new CommonLabel();
			requestBottomPanel = new CommonPanel();
			jsonEditor = new CodeTextBox();
			resourceTypeLabel = new CommonLabel();
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
			startMenu = new ContextMenuStrip(components);
			startFromJSONMenuItem = new ToolStripMenuItem();
			startFromQuickStartMenuItem = new ToolStripMenuItem();
			statusPanel = new CommonFlowLayoutPanel();
			uriLabel = new CommonLabel();
			resourcePanel = new CommonPanel();
			resourceLabel = new CommonLabel();
			searchPanel = new CommonPanel();
			searchSplitter = new CommonPanel();
			searchBox = new CodeTextBox();
			searchLabel = new CommonLabel();
			searchButton = new Button();
			logItemTestLabel = new CommonLabel();
			configPanel = new CommonFlowLayoutPanel();
			configLabel = new CommonLabel();
			configFileNameLabel = new CommonLabel();
			configContextMenu = new ContextMenuStrip(components);
			browseConfigFileMenuItem = new ToolStripMenuItem();
			toolStripSeparator4 = new ToolStripSeparator();
			saveConfigFileMenuItem = new ToolStripMenuItem();
			toolStripSeparator5 = new ToolStripSeparator();
			copyConfigNameMenuItem = new ToolStripMenuItem();
			titleLabel = new CommonLabel();
			saveFileDialog = new SaveFileDialog();
			openFileDialog = new OpenFileDialog();
			toolTip = new ToolTip(components);
			monitorSwitch = new Button();
			viewSwitch = new Button();
			menuButton = new Button();
			closeButton = new Button();
			maximizeButton = new Button();
			minimizeButton = new Button();
			mainPanel = new CommonPanel();
			titlePanel = new CommonPanel();
			buttonPanel = new CommonFlowLayoutPanel();
			startStopSwitch = new Button();
			controlPanel = new FlowLayoutPanel();
			titleTestLabel = new CommonLabel();
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
			startMenu.SuspendLayout();
			statusPanel.SuspendLayout();
			resourcePanel.SuspendLayout();
			searchPanel.SuspendLayout();
			configPanel.SuspendLayout();
			configContextMenu.SuspendLayout();
			mainPanel.SuspendLayout();
			titlePanel.SuspendLayout();
			buttonPanel.SuspendLayout();
			controlPanel.SuspendLayout();
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
			logList.Size = new Size(711, 502);
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
			logListMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			logListMenu.Items.AddRange(new ToolStripItem[] { openLogMenuItem, logMenuLine0, deleteItemLogMenuItem, logMenuLine1, selectAllLogMenuItem });
			logListMenu.Name = "logListMenu";
			logListMenu.Size = new Size(214, 88);
			logListMenu.Opening += logListMenu_Opening;
			logListMenu.ItemClicked += logListMenu_ItemClicked;
			// 
			// openLogMenuItem
			// 
			openLogMenuItem.Name = "openLogMenuItem";
			openLogMenuItem.Size = new Size(213, 24);
			openLogMenuItem.Text = "Open target address";
			// 
			// logMenuLine0
			// 
			logMenuLine0.Name = "logMenuLine0";
			logMenuLine0.Size = new Size(210, 6);
			// 
			// deleteItemLogMenuItem
			// 
			deleteItemLogMenuItem.Name = "deleteItemLogMenuItem";
			deleteItemLogMenuItem.ShortcutKeys = Keys.Delete;
			deleteItemLogMenuItem.Size = new Size(213, 24);
			deleteItemLogMenuItem.Text = "Delete";
			// 
			// logMenuLine1
			// 
			logMenuLine1.Name = "logMenuLine1";
			logMenuLine1.Size = new Size(210, 6);
			// 
			// selectAllLogMenuItem
			// 
			selectAllLogMenuItem.Name = "selectAllLogMenuItem";
			selectAllLogMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			selectAllLogMenuItem.Size = new Size(213, 24);
			selectAllLogMenuItem.Text = "Select all";
			// 
			// logPanel
			// 
			logPanel.AutoDragForm = false;
			logPanel.Controls.Add(logList);
			logPanel.Dock = DockStyle.Fill;
			logPanel.Location = new Point(0, 0);
			logPanel.Margin = new Padding(0);
			logPanel.Name = "logPanel";
			logPanel.Padding = new Padding(0, 0, 2, 0);
			logPanel.Size = new Size(713, 502);
			logPanel.TabIndex = 0;
			// 
			// logListSplitter
			// 
			logListSplitter.Dock = DockStyle.Right;
			logListSplitter.Location = new Point(713, 0);
			logListSplitter.MinExtra = 200;
			logListSplitter.MinSize = 150;
			logListSplitter.Name = "logListSplitter";
			logListSplitter.Size = new Size(4, 502);
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
			gridContextMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			gridContextMenu.Items.AddRange(new ToolStripItem[] { gridCopyMenuItem, gridLine0, gridSearchMenuItem, gridLine1, gridSelectAllMenuItem });
			gridContextMenu.Name = "gridContextMenu";
			gridContextMenu.Size = new Size(191, 88);
			gridContextMenu.Opening += gridContextMenu_Opening;
			gridContextMenu.ItemClicked += gridContextMenu_ItemClicked;
			// 
			// gridCopyMenuItem
			// 
			gridCopyMenuItem.Name = "gridCopyMenuItem";
			gridCopyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
			gridCopyMenuItem.Size = new Size(190, 24);
			gridCopyMenuItem.Text = "&Copy";
			// 
			// gridLine0
			// 
			gridLine0.Name = "gridLine0";
			gridLine0.Size = new Size(187, 6);
			// 
			// gridSearchMenuItem
			// 
			gridSearchMenuItem.Name = "gridSearchMenuItem";
			gridSearchMenuItem.Size = new Size(190, 24);
			gridSearchMenuItem.Text = "&Search internet";
			// 
			// gridLine1
			// 
			gridLine1.Name = "gridLine1";
			gridLine1.Size = new Size(187, 6);
			// 
			// gridSelectAllMenuItem
			// 
			gridSelectAllMenuItem.Name = "gridSelectAllMenuItem";
			gridSelectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
			gridSelectAllMenuItem.Size = new Size(190, 24);
			gridSelectAllMenuItem.Text = "Select &all";
			// 
			// labelCopyMenuItem
			// 
			labelCopyMenuItem.Name = "labelCopyMenuItem";
			labelCopyMenuItem.Size = new Size(112, 24);
			labelCopyMenuItem.Text = "&Copy";
			// 
			// labelContextMenu
			// 
			labelContextMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			labelContextMenu.Items.AddRange(new ToolStripItem[] { labelCopyMenuItem });
			labelContextMenu.Name = "gridContextMenu";
			labelContextMenu.Size = new Size(113, 28);
			labelContextMenu.Opening += labelContextMenu_Opening;
			labelContextMenu.ItemClicked += labelContextMenu_ItemClicked;
			// 
			// midPanel
			// 
			midPanel.AutoDragForm = false;
			midPanel.Controls.Add(logPanel);
			midPanel.Controls.Add(logListSplitter);
			midPanel.Controls.Add(propertiesPanel);
			midPanel.Dock = DockStyle.Fill;
			midPanel.Location = new Point(0, 58);
			midPanel.Margin = new Padding(0);
			midPanel.Name = "midPanel";
			midPanel.Size = new Size(987, 502);
			midPanel.TabIndex = 8;
			midPanel.Visible = false;
			midPanel.Resize += midPanel_Resize;
			// 
			// propertiesPanel
			// 
			propertiesPanel.AutoDragForm = false;
			propertiesPanel.Controls.Add(propertiesSplitter);
			propertiesPanel.Controls.Add(responsePanel);
			propertiesPanel.Controls.Add(requestPanel);
			propertiesPanel.Dock = DockStyle.Right;
			propertiesPanel.Location = new Point(717, 0);
			propertiesPanel.Margin = new Padding(0);
			propertiesPanel.Name = "propertiesPanel";
			propertiesPanel.Padding = new Padding(1, 0, 0, 0);
			propertiesPanel.Size = new Size(270, 502);
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
			responsePanel.AutoDragForm = false;
			responsePanel.Controls.Add(responseGrid);
			responsePanel.Controls.Add(responseTopPanel);
			responsePanel.Dock = DockStyle.Fill;
			responsePanel.Location = new Point(1, 237);
			responsePanel.Name = "responsePanel";
			responsePanel.Size = new Size(269, 265);
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
			responseGrid.Size = new Size(269, 229);
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
			responseLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			responseLabel.Location = new Point(0, 11);
			responseLabel.Margin = new Padding(0, 5, 0, 0);
			responseLabel.Name = "responseLabel";
			responseLabel.Size = new Size(77, 20);
			responseLabel.TabIndex = 1;
			responseLabel.Text = "Response:";
			responseLabel.BackColorChanged += originLabel_BackColorChanged;
			responseLabel.MouseDown += responseLabel_MouseDown;
			// 
			// requestPanel
			// 
			requestPanel.AutoDragForm = false;
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
			toolTip.SetToolTip(closePropertiesButton, "Close this panel");
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
			errorLabel.AutoDragForm = false;
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
			linkContextMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			linkContextMenu.Items.AddRange(new ToolStripItem[] { linkOpenMenuItem, folderOpenMenuItem, linkContextMenuLine1, linkCopyMenuItem });
			linkContextMenu.Name = "gridContextMenu";
			linkContextMenu.Size = new Size(159, 82);
			linkContextMenu.Opening += linkContextMenu_Opening;
			// 
			// linkOpenMenuItem
			// 
			linkOpenMenuItem.Name = "linkOpenMenuItem";
			linkOpenMenuItem.Size = new Size(158, 24);
			linkOpenMenuItem.Text = "&Open link";
			linkOpenMenuItem.Click += linkOpenMenuItem_Click;
			// 
			// folderOpenMenuItem
			// 
			folderOpenMenuItem.Name = "folderOpenMenuItem";
			folderOpenMenuItem.Size = new Size(158, 24);
			folderOpenMenuItem.Text = "Open &folder";
			folderOpenMenuItem.Click += folderOpenMenuItem_Click;
			// 
			// linkContextMenuLine1
			// 
			linkContextMenuLine1.Name = "linkContextMenuLine1";
			linkContextMenuLine1.Size = new Size(155, 6);
			// 
			// linkCopyMenuItem
			// 
			linkCopyMenuItem.Name = "linkCopyMenuItem";
			linkCopyMenuItem.Size = new Size(158, 24);
			linkCopyMenuItem.Text = "&Copy";
			linkCopyMenuItem.Click += linkCopyMenuItem_Click;
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
			methodLabel.AutoDragForm = false;
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
			requestLabel.AutoDragForm = false;
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
			httpLabel.AutoDragForm = false;
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
			requestBottomPanel.AutoDragForm = false;
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
			jsonEditor.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			jsonEditor.HideSelection = false;
			jsonEditor.Location = new Point(0, 58);
			jsonEditor.Margin = new Padding(0);
			jsonEditor.Multiline = true;
			jsonEditor.Name = "jsonEditor";
			jsonEditor.ScrollBars = ScrollBars.Both;
			jsonEditor.Size = new Size(987, 502);
			jsonEditor.TabIndex = 10;
			jsonEditor.WordWrap = false;
			jsonEditor.Paint += jsonEditor_Paint;
			jsonEditor.TextChanged += jsonEditor_TextChanged;
			// 
			// resourceTypeLabel
			// 
			resourceTypeLabel.AutoSize = true;
			resourceTypeLabel.ContextMenuStrip = labelContextMenu;
			resourceTypeLabel.Dock = DockStyle.Left;
			resourceTypeLabel.Location = new Point(0, 0);
			resourceTypeLabel.Margin = new Padding(0);
			resourceTypeLabel.Name = "resourceTypeLabel";
			resourceTypeLabel.Size = new Size(55, 20);
			resourceTypeLabel.TabIndex = 4;
			resourceTypeLabel.Text = "stoped";
			resourceTypeLabel.TextAlign = ContentAlignment.MiddleRight;
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
			iconMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			iconMenu.ImageScalingSize = new Size(1, 1);
			iconMenu.Items.AddRange(new ToolStripItem[] { aboutMenuItem, toolStripSeparator0, startJSONConfigMenuItem, showQuickStartMenuItem, toolStripSeparator1, showMainWindowMenuItem, showStartParametersMenuItem, toolStripSeparator2, stopServerMenuItem, closeProgramMenuItem });
			iconMenu.Name = "iconMenu";
			iconMenu.RenderMode = ToolStripRenderMode.Professional;
			iconMenu.Size = new Size(253, 218);
			iconMenu.Closing += iconMenu_Closing;
			iconMenu.Opening += iconMenu_Opening;
			iconMenu.ItemClicked += iconMenu_ItemClicked;
			// 
			// aboutMenuItem
			// 
			aboutMenuItem.Margin = new Padding(0, 2, 0, 2);
			aboutMenuItem.Name = "aboutMenuItem";
			aboutMenuItem.Padding = new Padding(0, 2, 0, 0);
			aboutMenuItem.Size = new Size(252, 24);
			aboutMenuItem.Text = "About the program";
			aboutMenuItem.Click += aboutMenuItem_Click;
			// 
			// toolStripSeparator0
			// 
			toolStripSeparator0.Name = "toolStripSeparator0";
			toolStripSeparator0.Size = new Size(249, 6);
			// 
			// startJSONConfigMenuItem
			// 
			startJSONConfigMenuItem.Margin = new Padding(0, 2, 0, 2);
			startJSONConfigMenuItem.Name = "startJSONConfigMenuItem";
			startJSONConfigMenuItem.Padding = new Padding(0, 2, 0, 0);
			startJSONConfigMenuItem.Size = new Size(252, 24);
			startJSONConfigMenuItem.Text = "Start current configuration";
			startJSONConfigMenuItem.Click += startJSONConfigMenuItem_Click;
			// 
			// showQuickStartMenuItem
			// 
			showQuickStartMenuItem.Margin = new Padding(0, 2, 0, 2);
			showQuickStartMenuItem.Name = "showQuickStartMenuItem";
			showQuickStartMenuItem.Padding = new Padding(0, 2, 0, 0);
			showQuickStartMenuItem.Size = new Size(252, 24);
			showQuickStartMenuItem.Text = "Show quick start form";
			showQuickStartMenuItem.Click += showQuickStartMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(249, 6);
			// 
			// showMainWindowMenuItem
			// 
			showMainWindowMenuItem.Margin = new Padding(0, 2, 0, 2);
			showMainWindowMenuItem.Name = "showMainWindowMenuItem";
			showMainWindowMenuItem.Padding = new Padding(0, 2, 0, 0);
			showMainWindowMenuItem.Size = new Size(252, 24);
			showMainWindowMenuItem.Text = "Show";
			showMainWindowMenuItem.Click += showMainWindowMenuItem_Click;
			// 
			// showStartParametersMenuItem
			// 
			showStartParametersMenuItem.Margin = new Padding(0, 2, 0, 2);
			showStartParametersMenuItem.Name = "showStartParametersMenuItem";
			showStartParametersMenuItem.Padding = new Padding(0, 2, 0, 0);
			showStartParametersMenuItem.Size = new Size(252, 24);
			showStartParametersMenuItem.Text = "Show starting parameters";
			showStartParametersMenuItem.Click += showStartParametersMenuItem_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(249, 6);
			// 
			// stopServerMenuItem
			// 
			stopServerMenuItem.Margin = new Padding(0, 2, 0, 2);
			stopServerMenuItem.Name = "stopServerMenuItem";
			stopServerMenuItem.Padding = new Padding(0, 2, 0, 0);
			stopServerMenuItem.Size = new Size(252, 24);
			stopServerMenuItem.Text = "Stop http server";
			stopServerMenuItem.Click += stopServerMenuItem_Click;
			// 
			// closeProgramMenuItem
			// 
			closeProgramMenuItem.Margin = new Padding(0, 2, 0, 2);
			closeProgramMenuItem.Name = "closeProgramMenuItem";
			closeProgramMenuItem.Padding = new Padding(0, 2, 0, 0);
			closeProgramMenuItem.Size = new Size(252, 24);
			closeProgramMenuItem.Text = "Close program and server";
			closeProgramMenuItem.Click += closeProgramMenuItem_Click;
			// 
			// startMenu
			// 
			startMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			startMenu.ImageScalingSize = new Size(1, 1);
			startMenu.Items.AddRange(new ToolStripItem[] { startFromJSONMenuItem, startFromQuickStartMenuItem });
			startMenu.Name = "startMenu";
			startMenu.RenderMode = ToolStripRenderMode.Professional;
			startMenu.Size = new Size(292, 52);
			startMenu.Opening += startMenu_Opening;
			// 
			// startFromJSONMenuItem
			// 
			startFromJSONMenuItem.Name = "startFromJSONMenuItem";
			startFromJSONMenuItem.Size = new Size(291, 24);
			startFromJSONMenuItem.Text = "Start current JSON configuration";
			startFromJSONMenuItem.Click += startFromJSONMenuItem_Click;
			// 
			// startFromQuickStartMenuItem
			// 
			startFromQuickStartMenuItem.Name = "startFromQuickStartMenuItem";
			startFromQuickStartMenuItem.Size = new Size(291, 24);
			startFromQuickStartMenuItem.Text = "Start from Quick Start dialog";
			startFromQuickStartMenuItem.Click += startFromQuickStartMenuItem_Click;
			// 
			// statusPanel
			// 
			statusPanel.AutoSize = true;
			statusPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			statusPanel.Controls.Add(uriLabel);
			statusPanel.Controls.Add(resourcePanel);
			statusPanel.Dock = DockStyle.Top;
			statusPanel.Location = new Point(0, 30);
			statusPanel.Margin = new Padding(0);
			statusPanel.Name = "statusPanel";
			statusPanel.Padding = new Padding(0, 4, 0, 0);
			statusPanel.Size = new Size(987, 28);
			statusPanel.TabIndex = 6;
			// 
			// uriLabel
			// 
			uriLabel.AutoDragForm = false;
			uriLabel.AutoSize = true;
			uriLabel.ContextMenuStrip = linkContextMenu;
			uriLabel.Cursor = Cursors.Hand;
			uriLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Underline, GraphicsUnit.Point);
			uriLabel.Location = new Point(0, 4);
			uriLabel.Margin = new Padding(0, 0, 8, 0);
			uriLabel.Name = "uriLabel";
			uriLabel.Padding = new Padding(1, 0, 0, 0);
			uriLabel.Size = new Size(73, 20);
			uriLabel.TabIndex = 5;
			uriLabel.Text = "http://uri";
			uriLabel.TextAlign = ContentAlignment.MiddleLeft;
			uriLabel.TextChanged += uriLabel_TextChanged;
			uriLabel.MouseDown += uriLabel_MouseDown;
			uriLabel.MouseEnter += uriLabel_MouseEnter;
			uriLabel.MouseLeave += uriLabel_MouseLeave;
			// 
			// resourcePanel
			// 
			resourcePanel.AutoDragForm = false;
			resourcePanel.AutoSize = true;
			resourcePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			resourcePanel.Controls.Add(resourceLabel);
			resourcePanel.Controls.Add(resourceTypeLabel);
			resourcePanel.Location = new Point(81, 4);
			resourcePanel.Margin = new Padding(0);
			resourcePanel.MinimumSize = new Size(0, 24);
			resourcePanel.Name = "resourcePanel";
			resourcePanel.Size = new Size(123, 24);
			resourcePanel.TabIndex = 13;
			// 
			// resourceLabel
			// 
			resourceLabel.AutoDragForm = false;
			resourceLabel.AutoSize = true;
			resourceLabel.ContextMenuStrip = linkContextMenu;
			resourceLabel.Cursor = Cursors.Hand;
			resourceLabel.Dock = DockStyle.Left;
			resourceLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			resourceLabel.Location = new Point(55, 0);
			resourceLabel.Margin = new Padding(0);
			resourceLabel.Name = "resourceLabel";
			resourceLabel.Size = new Size(68, 20);
			resourceLabel.TabIndex = 6;
			resourceLabel.Text = "resource";
			resourceLabel.TextAlign = ContentAlignment.MiddleRight;
			resourceLabel.MouseDown += resourceLabel_MouseDown;
			resourceLabel.MouseEnter += resourceLabel_MouseEnter;
			resourceLabel.MouseLeave += resourceLabel_MouseLeave;
			// 
			// searchPanel
			// 
			searchPanel.AutoSize = true;
			searchPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			searchPanel.Controls.Add(searchSplitter);
			searchPanel.Controls.Add(searchBox);
			searchPanel.Controls.Add(searchLabel);
			searchPanel.Dock = DockStyle.Fill;
			searchPanel.Location = new Point(157, 0);
			searchPanel.Margin = new Padding(0);
			searchPanel.MinimumSize = new Size(0, 24);
			searchPanel.Name = "searchPanel";
			searchPanel.Padding = new Padding(0, 3, 0, 0);
			searchPanel.Size = new Size(618, 30);
			searchPanel.TabIndex = 12;
			searchPanel.DoubleClick += title_DoubleClick;
			searchPanel.Resize += searchPanel_Resize;
			// 
			// searchSplitter
			// 
			searchSplitter.AutoDragForm = false;
			searchSplitter.BackColor = SystemColors.ControlDark;
			searchSplitter.CausesValidation = false;
			searchSplitter.Cursor = Cursors.VSplit;
			searchSplitter.Location = new Point(410, 3);
			searchSplitter.Margin = new Padding(0);
			searchSplitter.Name = "searchSplitter";
			searchSplitter.Size = new Size(3, 27);
			searchSplitter.TabIndex = 9;
			searchSplitter.Paint += searchSplitter_Paint;
			searchSplitter.MouseDown += searchSplitter_MouseDown;
			searchSplitter.MouseEnter += splitter_MouseEnter;
			searchSplitter.MouseLeave += splitter_MouseLeave;
			searchSplitter.MouseMove += searchSplitter_MouseMove;
			searchSplitter.MouseUp += searchSplitter_MouseUp;
			// 
			// searchBox
			// 
			searchBox.Dock = DockStyle.Fill;
			searchBox.Location = new Point(62, 3);
			searchBox.Margin = new Padding(0);
			searchBox.MinimumSize = new Size(50, 0);
			searchBox.Name = "searchBox";
			searchBox.Size = new Size(556, 27);
			searchBox.TabIndex = 0;
			searchBox.TextChanged += searchBox_TextChanged;
			searchBox.KeyDown += searchBox_KeyDown;
			searchBox.KeyPress += searchBox_KeyPress;
			searchBox.LostFocus += searchBox_LostFocus;
			searchBox.Resize += searchBox_Resize;
			// 
			// searchLabel
			// 
			searchLabel.AutoSize = true;
			searchLabel.ContextMenuStrip = labelContextMenu;
			searchLabel.Dock = DockStyle.Left;
			searchLabel.Location = new Point(0, 3);
			searchLabel.Margin = new Padding(0);
			searchLabel.Name = "searchLabel";
			searchLabel.Padding = new Padding(6, 2, 0, 2);
			searchLabel.Size = new Size(62, 24);
			searchLabel.TabIndex = 8;
			searchLabel.Text = "Search:";
			searchLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// searchButton
			// 
			searchButton.BackgroundImage = Properties.Resources.searchIcon;
			searchButton.BackgroundImageLayout = ImageLayout.Zoom;
			searchButton.FlatAppearance.BorderSize = 0;
			searchButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			searchButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			searchButton.FlatStyle = FlatStyle.Flat;
			searchButton.Location = new Point(129, 4);
			searchButton.Margin = new Padding(3, 0, 3, 0);
			searchButton.Name = "searchButton";
			searchButton.RightToLeft = RightToLeft.Yes;
			searchButton.Size = new Size(25, 30);
			searchButton.TabIndex = 10;
			searchButton.TabStop = false;
			searchButton.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(searchButton, "Show search box");
			searchButton.UseVisualStyleBackColor = false;
			searchButton.Click += searchButton_Click;
			searchButton.Resize += Box_Resize;
			// 
			// logItemTestLabel
			// 
			logItemTestLabel.AutoDragForm = false;
			logItemTestLabel.AutoSize = true;
			logItemTestLabel.Location = new Point(-399, -271);
			logItemTestLabel.Margin = new Padding(0);
			logItemTestLabel.Name = "logItemTestLabel";
			logItemTestLabel.Padding = new Padding(3);
			logItemTestLabel.Size = new Size(90, 26);
			logItemTestLabel.TabIndex = 7;
			logItemTestLabel.Text = "Not started";
			// 
			// configPanel
			// 
			configPanel.AutoDragForm = false;
			configPanel.AutoSize = true;
			configPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			configPanel.Controls.Add(configLabel);
			configPanel.Controls.Add(configFileNameLabel);
			configPanel.Dock = DockStyle.Right;
			configPanel.Location = new Point(775, 0);
			configPanel.Margin = new Padding(0);
			configPanel.Name = "configPanel";
			configPanel.Padding = new Padding(0, 2, 0, 0);
			configPanel.Size = new Size(128, 30);
			configPanel.TabIndex = 11;
			configPanel.WrapContents = false;
			configPanel.Move += configPanel_Resize;
			configPanel.Resize += configPanel_Resize;
			// 
			// configLabel
			// 
			configLabel.AutoSize = true;
			configLabel.ContextMenuStrip = linkContextMenu;
			configLabel.Dock = DockStyle.Left;
			configLabel.Location = new Point(0, 2);
			configLabel.Margin = new Padding(0);
			configLabel.Name = "configLabel";
			configLabel.Size = new Size(56, 24);
			configLabel.TabIndex = 11;
			configLabel.Text = "Config:";
			configLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// configFileNameLabel
			// 
			configFileNameLabel.AutoDragForm = false;
			configFileNameLabel.AutoSize = true;
			configFileNameLabel.ContextMenuStrip = configContextMenu;
			configFileNameLabel.Cursor = Cursors.Hand;
			configFileNameLabel.Dock = DockStyle.Left;
			configFileNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Underline, GraphicsUnit.Point);
			configFileNameLabel.Location = new Point(56, 2);
			configFileNameLabel.Margin = new Padding(0);
			configFileNameLabel.Name = "configFileNameLabel";
			configFileNameLabel.Padding = new Padding(0, 2, 0, 2);
			configFileNameLabel.Size = new Size(72, 24);
			configFileNameLabel.TabIndex = 10;
			configFileNameLabel.Text = "<empty>";
			configFileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
			toolTip.SetToolTip(configFileNameLabel, "Click here for load/save options");
			configFileNameLabel.MouseDown += configFileNameLabel_MouseDown;
			configFileNameLabel.MouseEnter += configFileNameLabel_MouseEnter;
			configFileNameLabel.MouseLeave += configFileNameLabel_MouseLeave;
			// 
			// configContextMenu
			// 
			configContextMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			configContextMenu.Items.AddRange(new ToolStripItem[] { browseConfigFileMenuItem, toolStripSeparator4, saveConfigFileMenuItem, toolStripSeparator5, copyConfigNameMenuItem });
			configContextMenu.Name = "gridContextMenu";
			configContextMenu.Size = new Size(204, 88);
			configContextMenu.Opening += configContextMenu_Opening;
			configContextMenu.ItemClicked += configContextMenu_ItemClicked;
			// 
			// browseConfigFileMenuItem
			// 
			browseConfigFileMenuItem.Name = "browseConfigFileMenuItem";
			browseConfigFileMenuItem.Size = new Size(203, 24);
			browseConfigFileMenuItem.Text = "&Browse";
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new Size(200, 6);
			// 
			// saveConfigFileMenuItem
			// 
			saveConfigFileMenuItem.Name = "saveConfigFileMenuItem";
			saveConfigFileMenuItem.Size = new Size(203, 24);
			saveConfigFileMenuItem.Text = "Save configuration";
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(200, 6);
			// 
			// copyConfigNameMenuItem
			// 
			copyConfigNameMenuItem.Name = "copyConfigNameMenuItem";
			copyConfigNameMenuItem.Size = new Size(203, 24);
			copyConfigNameMenuItem.Text = "&Copy with full path";
			// 
			// titleLabel
			// 
			titleLabel.AutoSize = true;
			titleLabel.ContextMenuStrip = linkContextMenu;
			titleLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Regular, GraphicsUnit.Point);
			titleLabel.Location = new Point(651, 0);
			titleLabel.Margin = new Padding(0);
			titleLabel.Name = "titleLabel";
			titleLabel.Padding = new Padding(6, 0, 0, 0);
			titleLabel.Size = new Size(118, 25);
			titleLabel.TabIndex = 13;
			titleLabel.Text = "Simple Http";
			titleLabel.TextAlign = ContentAlignment.MiddleLeft;
			titleLabel.DoubleClick += title_DoubleClick;
			// 
			// saveFileDialog
			// 
			saveFileDialog.DefaultExt = "json";
			saveFileDialog.Filter = "JSON|*.json|Any file|*.*";
			saveFileDialog.SupportMultiDottedExtensions = true;
			saveFileDialog.Title = "Save configuration";
			// 
			// openFileDialog
			// 
			openFileDialog.Filter = "JSON files(*.json)|*.json|text files(*.txt)|*.txt|any(*.*)|*.*";
			// 
			// toolTip
			// 
			toolTip.AutomaticDelay = 300;
			toolTip.AutoPopDelay = 20000;
			toolTip.InitialDelay = 300;
			toolTip.OwnerDraw = true;
			toolTip.ReshowDelay = 1;
			toolTip.ShowAlways = true;
			toolTip.ToolTipIcon = ToolTipIcon.Info;
			toolTip.Draw += toolTip_Draw;
			toolTip.Popup += toolTip_Popup;
			// 
			// monitorSwitch
			// 
			monitorSwitch.BackgroundImage = Properties.Resources.monWhiteIcon;
			monitorSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			monitorSwitch.FlatAppearance.BorderSize = 0;
			monitorSwitch.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			monitorSwitch.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			monitorSwitch.FlatStyle = FlatStyle.Flat;
			monitorSwitch.Location = new Point(66, 4);
			monitorSwitch.Margin = new Padding(2, 0, 2, 0);
			monitorSwitch.Name = "monitorSwitch";
			monitorSwitch.Size = new Size(26, 27);
			monitorSwitch.TabIndex = 8;
			monitorSwitch.TabStop = false;
			monitorSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(monitorSwitch, " Click here to activate login");
			monitorSwitch.UseVisualStyleBackColor = false;
			monitorSwitch.Click += monitorSwitch_Click;
			monitorSwitch.MouseUp += Button_MouseUp;
			monitorSwitch.Resize += Box_Resize;
			// 
			// viewSwitch
			// 
			viewSwitch.BackgroundImage = Properties.Resources.monitorIcon;
			viewSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			viewSwitch.FlatAppearance.BorderSize = 0;
			viewSwitch.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			viewSwitch.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			viewSwitch.FlatStyle = FlatStyle.Flat;
			viewSwitch.Location = new Point(35, 4);
			viewSwitch.Margin = new Padding(3, 0, 3, 0);
			viewSwitch.Name = "viewSwitch";
			viewSwitch.Size = new Size(26, 27);
			viewSwitch.TabIndex = 7;
			viewSwitch.TabStop = false;
			viewSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(viewSwitch, "Show log");
			viewSwitch.UseVisualStyleBackColor = false;
			viewSwitch.Click += viewSwitch_Click;
			viewSwitch.MouseEnter += viewSwitch_MouseEnter;
			viewSwitch.MouseLeave += viewSwitch_MouseLeave;
			viewSwitch.MouseUp += Button_MouseUp;
			// 
			// menuButton
			// 
			menuButton.BackgroundImage = Properties.Resources.settings;
			menuButton.BackgroundImageLayout = ImageLayout.Stretch;
			menuButton.FlatAppearance.BorderSize = 0;
			menuButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			menuButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			menuButton.FlatStyle = FlatStyle.Flat;
			menuButton.Location = new Point(3, 4);
			menuButton.Margin = new Padding(3, 0, 3, 0);
			menuButton.Name = "menuButton";
			menuButton.Size = new Size(26, 27);
			menuButton.TabIndex = 5;
			menuButton.TabStop = false;
			menuButton.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(menuButton, "Other actions");
			menuButton.UseVisualStyleBackColor = false;
			menuButton.Click += menuButton_Click;
			menuButton.MouseUp += menuButton_MouseUp;
			menuButton.Resize += Box_Resize;
			// 
			// closeButton
			// 
			closeButton.BackgroundImage = Properties.Resources.closeX;
			closeButton.BackgroundImageLayout = ImageLayout.Stretch;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			closeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			closeButton.FlatStyle = FlatStyle.Flat;
			closeButton.Location = new Point(58, 2);
			closeButton.Margin = new Padding(0);
			closeButton.Name = "closeButton";
			closeButton.Size = new Size(26, 27);
			closeButton.TabIndex = 14;
			closeButton.TabStop = false;
			closeButton.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(closeButton, "Close");
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += closeButton_Click;
			closeButton.MouseUp += Button_MouseUp;
			closeButton.Resize += Box_Resize;
			// 
			// maximizeButton
			// 
			maximizeButton.BackgroundImage = Properties.Resources.restoreIcon;
			maximizeButton.BackgroundImageLayout = ImageLayout.Stretch;
			maximizeButton.FlatAppearance.BorderSize = 0;
			maximizeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			maximizeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			maximizeButton.FlatStyle = FlatStyle.Flat;
			maximizeButton.Location = new Point(32, 2);
			maximizeButton.Margin = new Padding(0);
			maximizeButton.Name = "maximizeButton";
			maximizeButton.Size = new Size(26, 27);
			maximizeButton.TabIndex = 13;
			maximizeButton.TabStop = false;
			maximizeButton.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(maximizeButton, "Maximize");
			maximizeButton.UseVisualStyleBackColor = false;
			maximizeButton.Click += maximizeButton_Click;
			maximizeButton.MouseUp += Button_MouseUp;
			maximizeButton.Resize += Box_Resize;
			// 
			// minimizeButton
			// 
			minimizeButton.BackgroundImage = Properties.Resources.minimizeIcon;
			minimizeButton.BackgroundImageLayout = ImageLayout.Stretch;
			minimizeButton.FlatAppearance.BorderSize = 0;
			minimizeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			minimizeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			minimizeButton.FlatStyle = FlatStyle.Flat;
			minimizeButton.Location = new Point(6, 2);
			minimizeButton.Margin = new Padding(0);
			minimizeButton.Name = "minimizeButton";
			minimizeButton.Size = new Size(26, 27);
			minimizeButton.TabIndex = 12;
			minimizeButton.TabStop = false;
			minimizeButton.TextImageRelation = TextImageRelation.ImageAboveText;
			toolTip.SetToolTip(minimizeButton, "Minimize");
			minimizeButton.UseVisualStyleBackColor = false;
			minimizeButton.Click += minimizeButton_Click;
			minimizeButton.MouseUp += Button_MouseUp;
			minimizeButton.Resize += Box_Resize;
			// 
			// mainPanel
			// 
			mainPanel.BackColor = SystemColors.Control;
			mainPanel.Controls.Add(midPanel);
			mainPanel.Controls.Add(jsonEditor);
			mainPanel.Controls.Add(statusPanel);
			mainPanel.Controls.Add(titlePanel);
			mainPanel.Dock = DockStyle.Fill;
			mainPanel.Location = new Point(8, 4);
			mainPanel.Margin = new Padding(0);
			mainPanel.Name = "mainPanel";
			mainPanel.Size = new Size(987, 560);
			mainPanel.TabIndex = 12;
			// 
			// titlePanel
			// 
			titlePanel.Controls.Add(titleLabel);
			titlePanel.Controls.Add(searchPanel);
			titlePanel.Controls.Add(buttonPanel);
			titlePanel.Controls.Add(configPanel);
			titlePanel.Controls.Add(controlPanel);
			titlePanel.Dock = DockStyle.Top;
			titlePanel.Location = new Point(0, 0);
			titlePanel.Margin = new Padding(0);
			titlePanel.Name = "titlePanel";
			titlePanel.Size = new Size(987, 30);
			titlePanel.TabIndex = 11;
			titlePanel.DoubleClick += title_DoubleClick;
			// 
			// buttonPanel
			// 
			buttonPanel.AutoSize = true;
			buttonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			buttonPanel.Controls.Add(menuButton);
			buttonPanel.Controls.Add(viewSwitch);
			buttonPanel.Controls.Add(monitorSwitch);
			buttonPanel.Controls.Add(startStopSwitch);
			buttonPanel.Controls.Add(searchButton);
			buttonPanel.Dock = DockStyle.Left;
			buttonPanel.Location = new Point(0, 0);
			buttonPanel.Margin = new Padding(0);
			buttonPanel.Name = "buttonPanel";
			buttonPanel.Padding = new Padding(0, 4, 0, 3);
			buttonPanel.Size = new Size(157, 30);
			buttonPanel.TabIndex = 10;
			buttonPanel.WrapContents = false;
			// 
			// startStopSwitch
			// 
			startStopSwitch.BackgroundImage = Properties.Resources.play;
			startStopSwitch.BackgroundImageLayout = ImageLayout.Stretch;
			startStopSwitch.FlatAppearance.BorderSize = 0;
			startStopSwitch.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			startStopSwitch.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			startStopSwitch.FlatStyle = FlatStyle.Flat;
			startStopSwitch.Location = new Point(97, 4);
			startStopSwitch.Margin = new Padding(3, 0, 3, 0);
			startStopSwitch.Name = "startStopSwitch";
			startStopSwitch.Size = new Size(26, 27);
			startStopSwitch.TabIndex = 9;
			startStopSwitch.TabStop = false;
			startStopSwitch.TextImageRelation = TextImageRelation.ImageAboveText;
			startStopSwitch.UseVisualStyleBackColor = false;
			startStopSwitch.Click += startStopSwitch_Click;
			startStopSwitch.MouseUp += Button_MouseUp;
			startStopSwitch.Resize += Box_Resize;
			// 
			// controlPanel
			// 
			controlPanel.AutoSize = true;
			controlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			controlPanel.Controls.Add(minimizeButton);
			controlPanel.Controls.Add(maximizeButton);
			controlPanel.Controls.Add(closeButton);
			controlPanel.Dock = DockStyle.Right;
			controlPanel.Location = new Point(903, 0);
			controlPanel.Margin = new Padding(0);
			controlPanel.Name = "controlPanel";
			controlPanel.Padding = new Padding(6, 2, 0, 0);
			controlPanel.Size = new Size(84, 30);
			controlPanel.TabIndex = 12;
			controlPanel.WrapContents = false;
			// 
			// titleTestLabel
			// 
			titleTestLabel.AutoSize = true;
			titleTestLabel.Location = new Point(-1000, -1000);
			titleTestLabel.Name = "titleTestLabel";
			titleTestLabel.Size = new Size(0, 20);
			titleTestLabel.TabIndex = 8;
			// 
			// MonitorForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(1003, 572);
			ControlBox = false;
			Controls.Add(logItemTestLabel);
			Controls.Add(titleTestLabel);
			Controls.Add(mainPanel);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(600, 360);
			Name = "MonitorForm";
			Opacity = 0D;
			Padding = new Padding(8, 4, 8, 8);
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Show;
			Text = "Simple Http";
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
			startMenu.ResumeLayout(false);
			statusPanel.ResumeLayout(false);
			statusPanel.PerformLayout();
			resourcePanel.ResumeLayout(false);
			resourcePanel.PerformLayout();
			searchPanel.ResumeLayout(false);
			searchPanel.PerformLayout();
			configPanel.ResumeLayout(false);
			configPanel.PerformLayout();
			configContextMenu.ResumeLayout(false);
			mainPanel.ResumeLayout(false);
			mainPanel.PerformLayout();
			titlePanel.ResumeLayout(false);
			titlePanel.PerformLayout();
			buttonPanel.ResumeLayout(false);
			controlPanel.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private ListBox logList;
		private Splitter logListSplitter;
		private DataGridView requestGrid;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colValue;
        private CommonFlowLayoutPanel requestTopPanel;
		private CommonLabel originLabel;
        private CommonLabel requestLabel;
        private CommonLabel resourceTypeLabel;
		private NotifyIcon notifyIcon;
		private ContextMenuStrip iconMenu;
		private ContextMenuStrip startMenu;
        private ToolStripMenuItem showMainWindowMenuItem;
        private ToolStripSeparator toolStripSeparator0;
        private ToolStripMenuItem stopServerMenuItem;
        private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem closeProgramMenuItem;
        private ToolStripMenuItem showQuickStartMenuItem;
        private CommonLabel errorLabel;
        private CommonFlowLayoutPanel statusPanel;
		private CommonLabel uriLabel;
        private ContextMenuStrip logListMenu;
        private ToolStripMenuItem deleteItemLogMenuItem;
        private ToolStripMenuItem selectAllLogMenuItem;
		private ContextMenuStrip gridContextMenu;
		private ToolStripMenuItem gridCopyMenuItem;
		private ToolStripMenuItem gridSelectAllMenuItem;
		private ToolStripSeparator gridLine0;
        private CommonLabel resourceLabel;
        private ContextMenuStrip linkContextMenu;
        private ToolStripMenuItem linkOpenMenuItem;
        private ToolStripSeparator linkContextMenuLine1;
		private ToolStripMenuItem linkCopyMenuItem;
        private ContextMenuStrip labelContextMenu;
        private ToolStripMenuItem labelCopyMenuItem;
        private CommonLabel httpLabel;
        private ToolStripMenuItem openLogMenuItem;
        private ToolStripMenuItem showStartParametersMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem gridSearchMenuItem;
        private ToolStripSeparator gridLine1;
        private CodeTextBox searchBox;
        private ToolStripSeparator logMenuLine0;
        private ToolStripSeparator logMenuLine1;
		private CommonLabel searchLabel;
        private CommonPanel  searchSplitter;
        private Button searchButton;
        public CommonLabel methodLabel;
		private CommonPanel  responsePanel;
		private DataGridView responseGrid;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private CommonFlowLayoutPanel responseTopPanel;
		private CommonLabel responseLabel;
		private Splitter propertiesSplitter;
		private CommonPanel  requestPanel;
		private Button closePropertiesButton;
		private CommonPanel requestBottomPanel;
        private CodeTextBox jsonEditor;
		private ToolStripMenuItem folderOpenMenuItem;
		private SaveFileDialog saveFileDialog;
		private ToolStripMenuItem startJSONConfigMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private CommonLabel configFileNameLabel;
		private CommonLabel configLabel;
		private ContextMenuStrip configContextMenu;
		private ToolStripMenuItem browseConfigFileMenuItem;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripMenuItem saveConfigFileMenuItem;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem copyConfigNameMenuItem;
		private OpenFileDialog openFileDialog;
		private CommonFlowLayoutPanel configPanel;
		private CommonPanel  searchPanel;
		private CommonPanel  resourcePanel;
		private ToolTip toolTip;
		private CommonPanel logPanel;
		private CommonPanel midPanel;
		private CommonPanel propertiesPanel;
		private CommonPanel mainPanel;
		private CommonPanel titlePanel;
		private CommonFlowLayoutPanel buttonPanel;
		private Button menuButton;
		private Button viewSwitch;
		private Button monitorSwitch;
		private Button startStopSwitch;
		private FlowLayoutPanel controlPanel;
		private Button minimizeButton;
		private Button maximizeButton;
		private Button closeButton;
		private CommonLabel titleLabel;
		private ToolStripMenuItem startFromJSONMenuItem;
		private ToolStripMenuItem startFromQuickStartMenuItem;
		private CommonLabel logItemTestLabel;
		private CommonLabel titleTestLabel;
	}
}