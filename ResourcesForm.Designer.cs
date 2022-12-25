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
			this.resourceList = new System.Windows.Forms.ListBox();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.searchPanel = new System.Windows.Forms.Panel();
			this.searchBox = new System.Windows.Forms.TextBox();
			this.searchLabel = new System.Windows.Forms.Label();
			this.namePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.assemblyNameLabel = new System.Windows.Forms.Label();
			this.lbAssemblyName = new System.Windows.Forms.Label();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.sizeTestLabel = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.searchPanel.SuspendLayout();
			this.namePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// resourceList
			// 
			this.resourceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resourceList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.resourceList.FormattingEnabled = true;
			this.resourceList.IntegralHeight = false;
			this.resourceList.ItemHeight = 15;
			this.resourceList.Location = new System.Drawing.Point(9, 55);
			this.resourceList.Margin = new System.Windows.Forms.Padding(0, 0, 14, 5);
			this.resourceList.Name = "resourceList";
			this.resourceList.Size = new System.Drawing.Size(497, 449);
			this.resourceList.TabIndex = 1;
			this.resourceList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.resourceList_DrawItem);
			this.resourceList.SelectedIndexChanged += new System.EventHandler(this.resourceList_SelectedIndexChanged);
			this.resourceList.DoubleClick += new System.EventHandler(this.resourceList_DoubleClick);
			this.resourceList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resourceList_MouseDown);
			this.resourceList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resourceList_MouseUp);
			this.resourceList.Resize += new System.EventHandler(this.resourceList_Resize);
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.resourceList);
			this.mainPanel.Controls.Add(this.searchPanel);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 33);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
			this.mainPanel.Size = new System.Drawing.Size(515, 515);
			this.mainPanel.TabIndex = 1;
			this.mainPanel.Resize += new System.EventHandler(this.mainPanel_Resize);
			// 
			// searchPanel
			// 
			this.searchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.searchPanel.Controls.Add(this.searchBox);
			this.searchPanel.Controls.Add(this.searchLabel);
			this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.searchPanel.Location = new System.Drawing.Point(9, 11);
			this.searchPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchPanel.Name = "searchPanel";
			this.searchPanel.Size = new System.Drawing.Size(497, 44);
			this.searchPanel.TabIndex = 0;
			// 
			// searchBox
			// 
			this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchBox.Location = new System.Drawing.Point(56, 0);
			this.searchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(441, 27);
			this.searchBox.TabIndex = 0;
			this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
			this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
			this.searchBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseDown);
			this.searchBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseUp);
			this.searchBox.Resize += new System.EventHandler(this.searchBox_Resize);
			// 
			// searchLabel
			// 
			this.searchLabel.AutoSize = true;
			this.searchLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.searchLabel.Location = new System.Drawing.Point(0, 0);
			this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
			this.searchLabel.Name = "searchLabel";
			this.searchLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.searchLabel.Size = new System.Drawing.Size(56, 24);
			this.searchLabel.TabIndex = 2;
			this.searchLabel.Text = "Search:";
			// 
			// namePanel
			// 
			this.namePanel.AutoSize = true;
			this.namePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.namePanel.Controls.Add(this.assemblyNameLabel);
			this.namePanel.Controls.Add(this.lbAssemblyName);
			this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.namePanel.Location = new System.Drawing.Point(0, 0);
			this.namePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.namePanel.Name = "namePanel";
			this.namePanel.Padding = new System.Windows.Forms.Padding(9, 13, 9, 0);
			this.namePanel.Size = new System.Drawing.Size(515, 33);
			this.namePanel.TabIndex = 2;
			// 
			// assemblyNameLabel
			// 
			this.assemblyNameLabel.AutoSize = true;
			this.assemblyNameLabel.Location = new System.Drawing.Point(9, 13);
			this.assemblyNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.assemblyNameLabel.Name = "assemblyNameLabel";
			this.assemblyNameLabel.Size = new System.Drawing.Size(116, 20);
			this.assemblyNameLabel.TabIndex = 1;
			this.assemblyNameLabel.Text = "Assembly name:";
			// 
			// lbAssemblyName
			// 
			this.lbAssemblyName.AutoSize = true;
			this.lbAssemblyName.Location = new System.Drawing.Point(125, 13);
			this.lbAssemblyName.Margin = new System.Windows.Forms.Padding(0);
			this.lbAssemblyName.Name = "lbAssemblyName";
			this.lbAssemblyName.Size = new System.Drawing.Size(62, 20);
			this.lbAssemblyName.TabIndex = 0;
			this.lbAssemblyName.Text = "<none>";
			// 
			// sizeTestLabel
			// 
			this.sizeTestLabel.AutoSize = true;
			this.sizeTestLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.sizeTestLabel.Location = new System.Drawing.Point(-174, -280);
			this.sizeTestLabel.Margin = new System.Windows.Forms.Padding(0);
			this.sizeTestLabel.Name = "sizeTestLabel";
			this.sizeTestLabel.Size = new System.Drawing.Size(35, 20);
			this.sizeTestLabel.TabIndex = 2;
			this.sizeTestLabel.Text = "Test";
			// 
			// ResourcesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 548);
			this.Controls.Add(this.sizeTestLabel);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.namePanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResourcesForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Assembly Resources";
			this.mainPanel.ResumeLayout(false);
			this.searchPanel.ResumeLayout(false);
			this.searchPanel.PerformLayout();
			this.namePanel.ResumeLayout(false);
			this.namePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private ListBox resourceList;
        private Panel mainPanel;
        private FlowLayoutPanel namePanel;
        private Label lbAssemblyName;
		private Label assemblyNameLabel;
        private SaveFileDialog saveFileDialog;
        private Label sizeTestLabel;
        private TextBox searchBox;
		private Panel searchPanel;
		private Label searchLabel;
	}
}