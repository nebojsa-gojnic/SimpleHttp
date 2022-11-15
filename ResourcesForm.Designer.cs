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
			this.resourceList = new System.Windows.Forms.ListBox();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.namePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.assemblyNameLabel = new System.Windows.Forms.Label();
			this.lbAssemblyName = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.namePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// resourceList
			// 
			this.resourceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resourceList.FormattingEnabled = true;
			this.resourceList.IntegralHeight = false;
			this.resourceList.ItemHeight = 15;
			this.resourceList.Location = new System.Drawing.Point(8, 8);
			this.resourceList.Margin = new System.Windows.Forms.Padding(0);
			this.resourceList.Name = "resourceList";
			this.resourceList.Size = new System.Drawing.Size(449, 337);
			this.resourceList.TabIndex = 0;
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.resourceList);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 25);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(8);
			this.mainPanel.Size = new System.Drawing.Size(465, 353);
			this.mainPanel.TabIndex = 1;
			// 
			// namePanel
			// 
			this.namePanel.AutoSize = true;
			this.namePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.namePanel.Controls.Add(this.assemblyNameLabel);
			this.namePanel.Controls.Add(this.lbAssemblyName);
			this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.namePanel.Location = new System.Drawing.Point(0, 0);
			this.namePanel.Name = "namePanel";
			this.namePanel.Padding = new System.Windows.Forms.Padding(8, 10, 8, 0);
			this.namePanel.Size = new System.Drawing.Size(465, 25);
			this.namePanel.TabIndex = 2;
			// 
			// assemblyNameLabel
			// 
			this.assemblyNameLabel.AutoSize = true;
			this.assemblyNameLabel.Location = new System.Drawing.Point(8, 10);
			this.assemblyNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.assemblyNameLabel.Name = "assemblyNameLabel";
			this.assemblyNameLabel.Size = new System.Drawing.Size(94, 15);
			this.assemblyNameLabel.TabIndex = 1;
			this.assemblyNameLabel.Text = "Assembly name:";
			// 
			// lbAssemblyName
			// 
			this.lbAssemblyName.AutoSize = true;
			this.lbAssemblyName.Location = new System.Drawing.Point(102, 10);
			this.lbAssemblyName.Margin = new System.Windows.Forms.Padding(0);
			this.lbAssemblyName.Name = "lbAssemblyName";
			this.lbAssemblyName.Size = new System.Drawing.Size(50, 15);
			this.lbAssemblyName.TabIndex = 0;
			this.lbAssemblyName.Text = "<none>";
			// 
			// ResourcesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 378);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.namePanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResourcesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Resources Viewer";
			this.mainPanel.ResumeLayout(false);
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
	}
}