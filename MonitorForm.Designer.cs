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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
			this.logList = new System.Windows.Forms.ListBox();
			this.requestGrid = new System.Windows.Forms.DataGridView();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.spliterLayout = new System.Windows.Forms.SplitContainer();
			this.requestPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.lbError = new System.Windows.Forms.Label();
			this.originLabel = new System.Windows.Forms.Label();
			this.requestLabel = new System.Windows.Forms.Label();
			this.responsePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.responseLabel = new System.Windows.Forms.Label();
			this.responseGrid = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.closePropertiesButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showStartDialogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.stopServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeProgramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.requestGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spliterLayout)).BeginInit();
			this.spliterLayout.Panel1.SuspendLayout();
			this.spliterLayout.Panel2.SuspendLayout();
			this.spliterLayout.SuspendLayout();
			this.requestPanel.SuspendLayout();
			this.responsePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.responseGrid)).BeginInit();
			this.iconMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// logList
			// 
			this.logList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.logList.FormattingEnabled = true;
			this.logList.IntegralHeight = false;
			this.logList.ItemHeight = 15;
			this.logList.Location = new System.Drawing.Point(0, 0);
			this.logList.Name = "logList";
			this.logList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.logList.Size = new System.Drawing.Size(493, 380);
			this.logList.TabIndex = 0;
			this.logList.Click += new System.EventHandler(this.logList_Click);
			this.logList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.logList_DrawItem);
			// 
			// requestGrid
			// 
			this.requestGrid.AllowUserToAddRows = false;
			this.requestGrid.AllowUserToDeleteRows = false;
			this.requestGrid.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.requestGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.requestGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.requestGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.requestGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.requestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.requestGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue});
			this.requestGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.requestGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.requestGrid.EnableHeadersVisualStyles = false;
			this.requestGrid.Location = new System.Drawing.Point(0, 69);
			this.requestGrid.MultiSelect = false;
			this.requestGrid.Name = "requestGrid";
			this.requestGrid.ReadOnly = true;
			this.requestGrid.RowHeadersVisible = false;
			this.requestGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.requestGrid.RowTemplate.Height = 25;
			this.requestGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.requestGrid.Size = new System.Drawing.Size(265, 109);
			this.requestGrid.TabIndex = 1;
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.FillWeight = 40F;
			this.colName.HeaderText = "Name";
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			// 
			// colValue
			// 
			this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colValue.FillWeight = 60F;
			this.colValue.HeaderText = "Value";
			this.colValue.Name = "colValue";
			this.colValue.ReadOnly = true;
			// 
			// spliterLayout
			// 
			this.spliterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spliterLayout.Location = new System.Drawing.Point(8, 31);
			this.spliterLayout.Name = "spliterLayout";
			// 
			// spliterLayout.Panel1
			// 
			this.spliterLayout.Panel1.Controls.Add(this.logList);
			// 
			// spliterLayout.Panel2
			// 
			this.spliterLayout.Panel2.Controls.Add(this.requestGrid);
			this.spliterLayout.Panel2.Controls.Add(this.requestPanel);
			this.spliterLayout.Panel2.Controls.Add(this.responsePanel);
			this.spliterLayout.Panel2.Controls.Add(this.responseGrid);
			this.spliterLayout.Size = new System.Drawing.Size(762, 380);
			this.spliterLayout.SplitterDistance = 493;
			this.spliterLayout.TabIndex = 2;
			// 
			// requestPanel
			// 
			this.requestPanel.AutoSize = true;
			this.requestPanel.Controls.Add(this.lbError);
			this.requestPanel.Controls.Add(this.originLabel);
			this.requestPanel.Controls.Add(this.requestLabel);
			this.requestPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.requestPanel.Location = new System.Drawing.Point(0, 0);
			this.requestPanel.Name = "requestPanel";
			this.requestPanel.Size = new System.Drawing.Size(265, 69);
			this.requestPanel.TabIndex = 2;
			// 
			// lbError
			// 
			this.lbError.AutoSize = true;
			this.requestPanel.SetFlowBreak(this.lbError, true);
			this.lbError.ForeColor = System.Drawing.Color.DarkRed;
			this.lbError.Location = new System.Drawing.Point(3, 0);
			this.lbError.Name = "lbError";
			this.lbError.Padding = new System.Windows.Forms.Padding(4);
			this.lbError.Size = new System.Drawing.Size(8, 23);
			this.lbError.TabIndex = 2;
			this.lbError.DoubleClick += new System.EventHandler(this.lbError_DoubleClick);
			// 
			// originLabel
			// 
			this.originLabel.AutoSize = true;
			this.requestPanel.SetFlowBreak(this.originLabel, true);
			this.originLabel.Location = new System.Drawing.Point(3, 23);
			this.originLabel.Name = "originLabel";
			this.originLabel.Padding = new System.Windows.Forms.Padding(4);
			this.originLabel.Size = new System.Drawing.Size(59, 23);
			this.originLabel.TabIndex = 0;
			this.originLabel.Text = "Origin: ?";
			// 
			// requestLabel
			// 
			this.requestLabel.AutoSize = true;
			this.requestPanel.SetFlowBreak(this.requestLabel, true);
			this.requestLabel.Location = new System.Drawing.Point(3, 46);
			this.requestLabel.Name = "requestLabel";
			this.requestLabel.Padding = new System.Windows.Forms.Padding(4);
			this.requestLabel.Size = new System.Drawing.Size(57, 23);
			this.requestLabel.TabIndex = 1;
			this.requestLabel.Text = "Request";
			// 
			// responsePanel
			// 
			this.responsePanel.AutoSize = true;
			this.responsePanel.Controls.Add(this.responseLabel);
			this.responsePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.responsePanel.Location = new System.Drawing.Point(0, 178);
			this.responsePanel.Name = "responsePanel";
			this.responsePanel.Size = new System.Drawing.Size(265, 31);
			this.responsePanel.TabIndex = 3;
			// 
			// responseLabel
			// 
			this.responseLabel.AutoSize = true;
			this.responsePanel.SetFlowBreak(this.responseLabel, true);
			this.responseLabel.Location = new System.Drawing.Point(3, 0);
			this.responseLabel.Name = "responseLabel";
			this.responseLabel.Padding = new System.Windows.Forms.Padding(4, 12, 4, 4);
			this.responseLabel.Size = new System.Drawing.Size(68, 31);
			this.responseLabel.TabIndex = 1;
			this.responseLabel.Text = "Response:";
			// 
			// responseGrid
			// 
			this.responseGrid.AllowUserToAddRows = false;
			this.responseGrid.AllowUserToDeleteRows = false;
			this.responseGrid.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.responseGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.responseGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.responseGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.responseGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.responseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.responseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
			this.responseGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.responseGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.responseGrid.EnableHeadersVisualStyles = false;
			this.responseGrid.Location = new System.Drawing.Point(0, 209);
			this.responseGrid.MultiSelect = false;
			this.responseGrid.Name = "responseGrid";
			this.responseGrid.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.responseGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.responseGrid.RowHeadersVisible = false;
			this.responseGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.responseGrid.RowTemplate.Height = 25;
			this.responseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.responseGrid.Size = new System.Drawing.Size(265, 171);
			this.responseGrid.TabIndex = 4;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.FillWeight = 40F;
			this.dataGridViewTextBoxColumn1.HeaderText = "Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.FillWeight = 60F;
			this.dataGridViewTextBoxColumn2.HeaderText = "Value";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// closePropertiesButton
			// 
			this.closePropertiesButton.BackColor = System.Drawing.SystemColors.Window;
			this.closePropertiesButton.BackgroundImage = global::SimpleHttp.Properties.Resources.closeRightButton;
			this.closePropertiesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.closePropertiesButton.FlatAppearance.BorderSize = 0;
			this.closePropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closePropertiesButton.Location = new System.Drawing.Point(715, 13);
			this.closePropertiesButton.Name = "closePropertiesButton";
			this.closePropertiesButton.Size = new System.Drawing.Size(48, 28);
			this.closePropertiesButton.TabIndex = 3;
			this.closePropertiesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.closePropertiesButton.UseVisualStyleBackColor = false;
			this.closePropertiesButton.Click += new System.EventHandler(this.closePropertiesButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.statusLabel.Location = new System.Drawing.Point(8, 8);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Padding = new System.Windows.Forms.Padding(4);
			this.statusLabel.Size = new System.Drawing.Size(24, 23);
			this.statusLabel.TabIndex = 4;
			this.statusLabel.Text = "...";
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.iconMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "...";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
			this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseUp);
			// 
			// iconMenu
			// 
			this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStartDialogMenuItem,
            this.showMonitorMenuItem,
            this.toolStripSeparator1,
            this.stopServerMenuItem,
            this.toolStripSeparator2,
            this.closeProgramMenuItem});
			this.iconMenu.Name = "iconMenu";
			this.iconMenu.Size = new System.Drawing.Size(158, 96);
			this.iconMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.iconMenu_Closed);
			this.iconMenu.Opening += new System.ComponentModel.CancelEventHandler(this.iconMenu_Opening);
			this.iconMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.iconMenu_ItemClicked);
			// 
			// showStartDialogMenuItem
			// 
			this.showStartDialogMenuItem.Name = "showStartDialogMenuItem";
			this.showStartDialogMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.showStartDialogMenuItem.Size = new System.Drawing.Size(157, 20);
			this.showStartDialogMenuItem.Text = "Start http server";
			// 
			// showMonitorMenuItem
			// 
			this.showMonitorMenuItem.Name = "showMonitorMenuItem";
			this.showMonitorMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.showMonitorMenuItem.Size = new System.Drawing.Size(157, 20);
			this.showMonitorMenuItem.Text = "Show";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
			// 
			// stopServerMenuItem
			// 
			this.stopServerMenuItem.Name = "stopServerMenuItem";
			this.stopServerMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.stopServerMenuItem.Size = new System.Drawing.Size(157, 20);
			this.stopServerMenuItem.Text = "Stop http server";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
			// 
			// closeProgramMenuItem
			// 
			this.closeProgramMenuItem.Name = "closeProgramMenuItem";
			this.closeProgramMenuItem.Padding = new System.Windows.Forms.Padding(0);
			this.closeProgramMenuItem.Size = new System.Drawing.Size(157, 20);
			this.closeProgramMenuItem.Text = "Close program";
			// 
			// stopButton
			// 
			this.stopButton.BackgroundImage = global::SimpleHttp.Properties.Resources.settings;
			this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.stopButton.FlatAppearance.BorderSize = 0;
			this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.stopButton.Location = new System.Drawing.Point(626, 8);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(48, 28);
			this.stopButton.TabIndex = 5;
			this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.stopButton.UseVisualStyleBackColor = false;
			this.stopButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stopButton_MouseDown);
			// 
			// MonitorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(778, 419);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.spliterLayout);
			this.Controls.Add(this.closePropertiesButton);
			this.Controls.Add(this.statusLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MonitorForm";
			this.Opacity = 0D;
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Text = "Simple Http Server Connection Monitor";
			((System.ComponentModel.ISupportInitialize)(this.requestGrid)).EndInit();
			this.spliterLayout.Panel1.ResumeLayout(false);
			this.spliterLayout.Panel2.ResumeLayout(false);
			this.spliterLayout.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spliterLayout)).EndInit();
			this.spliterLayout.ResumeLayout(false);
			this.requestPanel.ResumeLayout(false);
			this.requestPanel.PerformLayout();
			this.responsePanel.ResumeLayout(false);
			this.responsePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.responseGrid)).EndInit();
			this.iconMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ListBox logList;
		private DataGridView requestGrid;
		private SplitContainer spliterLayout;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colValue;
		private Button closePropertiesButton;
        private FlowLayoutPanel requestPanel;
        private Label originLabel;
        private Label requestLabel;
        private Label statusLabel;
        private NotifyIcon notifyIcon;
        private Button stopButton;
        private ContextMenuStrip iconMenu;
        private ToolStripMenuItem showMonitorMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem stopServerMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem closeProgramMenuItem;
        private FlowLayoutPanel responsePanel;
        private Label responseLabel;
        private DataGridView responseGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private ToolStripMenuItem showStartDialogMenuItem;
        private Label lbError;
    }
}