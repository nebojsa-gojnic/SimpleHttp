namespace SimpleHttp
{
	partial class ResourcesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourcesForm));
			resourceList = new ListBox();
			mainPanel = new CommonFlowLayoutPanel();
			namePanel = new CommonFlowLayoutPanel();
			assemblyNameLabel = new CommonLabel();
			lbAssemblyName = new CommonLabel();
			searchPanel = new CommonPanel();
			searchBox = new CodeTextBox();
			searchLabel = new Label();
			saveFileDialog = new SaveFileDialog();
			sizeTestLabel = new CommonLabel();
			titleBar = new TitleBar();
			mainPanel.SuspendLayout();
			namePanel.SuspendLayout();
			searchPanel.SuspendLayout();
			SuspendLayout();
			// 
			// resourceList
			// 
			resourceList.DrawMode = DrawMode.OwnerDrawFixed;
			resourceList.FormattingEnabled = true;
			resourceList.ItemHeight = 15;
			resourceList.Location = new Point(9, 83);
			resourceList.Margin = new Padding(0);
			resourceList.Name = "resourceList";
			resourceList.Size = new Size(377, 409);
			resourceList.TabIndex = 1;
			resourceList.DrawItem += resourceList_DrawItem;
			resourceList.SelectedIndexChanged += resourceList_SelectedIndexChanged;
			resourceList.DoubleClick += resourceList_DoubleClick;
			resourceList.MouseDown += resourceList_MouseDown;
			resourceList.MouseUp += resourceList_MouseUp;
			resourceList.Resize += resourceList_Resize;
			// 
			// mainPanel
			// 
			mainPanel.AutoSize = true;
			mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			mainPanel.Controls.Add(namePanel);
			mainPanel.Controls.Add(searchPanel);
			mainPanel.Controls.Add(resourceList);
			mainPanel.Dock = DockStyle.Top;
			mainPanel.FlowDirection = FlowDirection.TopDown;
			mainPanel.Location = new Point(1, 31);
			mainPanel.Margin = new Padding(0);
			mainPanel.Name = "mainPanel";
			mainPanel.Padding = new Padding(9);
			mainPanel.Size = new Size(396, 501);
			mainPanel.TabIndex = 1;
			mainPanel.WrapContents = false;
			mainPanel.Resize += mainPanel_Resize;
			// 
			// namePanel
			// 
			namePanel.AutoSize = true;
			namePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			namePanel.Controls.Add(assemblyNameLabel);
			namePanel.Controls.Add(lbAssemblyName);
			namePanel.Dock = DockStyle.Top;
			namePanel.Location = new Point(9, 9);
			namePanel.Margin = new Padding(0);
			namePanel.Name = "namePanel";
			namePanel.Padding = new Padding(0, 6, 0, 6);
			namePanel.Size = new Size(377, 32);
			namePanel.TabIndex = 2;
			// 
			// assemblyNameLabel
			// 
			assemblyNameLabel.AutoSize = true;
			assemblyNameLabel.Location = new Point(0, 6);
			assemblyNameLabel.Margin = new Padding(0);
			assemblyNameLabel.Name = "assemblyNameLabel";
			assemblyNameLabel.Size = new Size(116, 20);
			assemblyNameLabel.TabIndex = 1;
			assemblyNameLabel.Text = "Assembly name:";
			// 
			// lbAssemblyName
			// 
			lbAssemblyName.AutoSize = true;
			lbAssemblyName.Location = new Point(116, 6);
			lbAssemblyName.Margin = new Padding(0);
			lbAssemblyName.Name = "lbAssemblyName";
			lbAssemblyName.Size = new Size(62, 20);
			lbAssemblyName.TabIndex = 0;
			lbAssemblyName.Text = "<none>";
			// 
			// searchPanel
			// 
			searchPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			searchPanel.Controls.Add(searchBox);
			searchPanel.Controls.Add(searchLabel);
			searchPanel.Location = new Point(9, 47);
			searchPanel.Margin = new Padding(0, 6, 0, 6);
			searchPanel.Name = "searchPanel";
			searchPanel.Size = new Size(377, 30);
			searchPanel.TabIndex = 0;
			// 
			// searchBox
			// 
			searchBox.Dock = DockStyle.Fill;
			searchBox.Location = new Point(56, 0);
			searchBox.Margin = new Padding(3, 4, 3, 4);
			searchBox.Name = "searchBox";
			searchBox.Size = new Size(321, 27);
			searchBox.TabIndex = 0;
			searchBox.WordWrap = false;
			searchBox.TextChanged += searchBox_TextChanged;
			searchBox.KeyDown += searchBox_KeyDown;
			searchBox.MouseDown += searchBox_MouseDown;
			searchBox.MouseUp += searchBox_MouseUp;
			searchBox.Resize += searchBox_Resize;
			// 
			// searchLabel
			// 
			searchLabel.AutoSize = true;
			searchLabel.Dock = DockStyle.Left;
			searchLabel.Location = new Point(0, 0);
			searchLabel.Margin = new Padding(0);
			searchLabel.Name = "searchLabel";
			searchLabel.Padding = new Padding(0, 2, 0, 0);
			searchLabel.Size = new Size(56, 22);
			searchLabel.TabIndex = 2;
			searchLabel.Text = "Search:";
			// 
			// sizeTestLabel
			// 
			sizeTestLabel.AutoSize = true;
			sizeTestLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			sizeTestLabel.Location = new Point(-173, -279);
			sizeTestLabel.Margin = new Padding(0);
			sizeTestLabel.Name = "sizeTestLabel";
			sizeTestLabel.Size = new Size(35, 20);
			sizeTestLabel.TabIndex = 2;
			sizeTestLabel.Text = "Test";
			// 
			// titleBar
			// 
			titleBar.AutoSize = true;
			titleBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			titleBar.CloseButtonImage = (Image)resources.GetObject("titleBar.CloseButtonImage");
			titleBar.Dock = DockStyle.Top;
			titleBar.Location = new Point(1, 1);
			titleBar.MaximumSize = new Size(int.MaxValue, 30);
			titleBar.MinimumSize = new Size(0, 30);
			titleBar.Name = "titleBar";
			titleBar.Size = new Size(396, 30);
			titleBar.TabIndex = 2;
			titleBar.Text = "titleBar1";
			titleBar.CloseButtonClick += titleBar_CloseButtonClick;
			// 
			// ResourcesForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(398, 548);
			Controls.Add(sizeTestLabel);
			Controls.Add(mainPanel);
			Controls.Add(titleBar);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ResourcesForm";
			Padding = new Padding(1);
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Show;
			Text = "Assembly Resources";
			mainPanel.ResumeLayout(false);
			mainPanel.PerformLayout();
			namePanel.ResumeLayout(false);
			namePanel.PerformLayout();
			searchPanel.ResumeLayout(false);
			searchPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox resourceList;
        private CommonFlowLayoutPanel mainPanel;
        private CommonFlowLayoutPanel namePanel;
        private CommonLabel lbAssemblyName;
        private SaveFileDialog saveFileDialog;
        private CommonLabel sizeTestLabel;
        private CodeTextBox searchBox;
		private CommonPanel searchPanel;
		private Label searchLabel;
		private TitleBar titleBar;
		private CommonLabel assemblyNameLabel;
	}
}