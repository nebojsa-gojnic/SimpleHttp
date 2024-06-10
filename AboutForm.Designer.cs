using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttp
{
	public partial class AboutForm
	{
		private FlowLayoutPanel mainPanel;
        private FlowLayoutPanel dialogPanel;
        private FlowLayoutPanel bottomPanel;
		private Button closeButton;

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			mainPanel = new FlowLayoutPanel();
			dialogPanel = new FlowLayoutPanel();
			topLabel = new Label();
			labelMenu = new ContextMenuStrip(components);
			copyLabelMenuItem = new ToolStripMenuItem();
			labelMenuSeparator = new ToolStripSeparator();
			copyAllLabelMenuItem = new ToolStripMenuItem();
			projectLabel = new Label();
			linkMenu = new ContextMenuStrip(components);
			openLinkMenuItem = new ToolStripMenuItem();
			copyLinkMenuSeparator0 = new ToolStripSeparator();
			copyLinkMenuItem = new ToolStripMenuItem();
			copyLinkMenuSeparator1 = new ToolStripSeparator();
			copyAllLinkMenuItem = new ToolStripMenuItem();
			middleLabel = new Label();
			webSocketLabel = new Label();
			bottomLabel = new Label();
			ninjaLabel = new Label();
			bottomPanel = new FlowLayoutPanel();
			closeButton = new Button();
			mainPanel.SuspendLayout();
			dialogPanel.SuspendLayout();
			labelMenu.SuspendLayout();
			linkMenu.SuspendLayout();
			bottomPanel.SuspendLayout();
			SuspendLayout();
			// 
			// mainPanel
			// 
			mainPanel.AutoSize = true;
			mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			mainPanel.Controls.Add(dialogPanel);
			mainPanel.Controls.Add(bottomPanel);
			mainPanel.FlowDirection = FlowDirection.TopDown;
			mainPanel.Location = new Point(0, 0);
			mainPanel.Margin = new Padding(0);
			mainPanel.Name = "mainPanel";
			mainPanel.Size = new Size(375, 276);
			mainPanel.TabIndex = 0;
			mainPanel.WrapContents = false;
			mainPanel.MouseDown += noLabel_MouseDown;
			// 
			// dialogPanel
			// 
			dialogPanel.AutoSize = true;
			dialogPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			dialogPanel.Controls.Add(topLabel);
			dialogPanel.Controls.Add(projectLabel);
			dialogPanel.Controls.Add(middleLabel);
			dialogPanel.Controls.Add(webSocketLabel);
			dialogPanel.Controls.Add(bottomLabel);
			dialogPanel.Controls.Add(ninjaLabel);
			dialogPanel.Dock = DockStyle.Fill;
			dialogPanel.FlowDirection = FlowDirection.TopDown;
			dialogPanel.Location = new Point(0, 0);
			dialogPanel.Margin = new Padding(0);
			dialogPanel.Name = "dialogPanel";
			dialogPanel.Padding = new Padding(12);
			dialogPanel.Size = new Size(375, 228);
			dialogPanel.TabIndex = 1;
			dialogPanel.MouseDown += noLabel_MouseDown;
			// 
			// topLabel
			// 
			topLabel.AutoSize = true;
			topLabel.ContextMenuStrip = labelMenu;
			topLabel.Location = new Point(12, 12);
			topLabel.Margin = new Padding(0);
			topLabel.Name = "topLabel";
			topLabel.Size = new Size(198, 40);
			topLabel.TabIndex = 0;
			topLabel.Text = "Simple Http Server,\r\nAuthor Nebojša Gojnić, 2022\r\n";
			topLabel.MouseDown += label_MouseDown;
			// 
			// labelMenu
			// 
			labelMenu.Items.AddRange(new ToolStripItem[] { copyLabelMenuItem, labelMenuSeparator, copyAllLabelMenuItem });
			labelMenu.Name = "labelMenu";
			labelMenu.Size = new Size(118, 54);
			labelMenu.Closed += labelMenu_Closed;
			// 
			// copyLabelMenuItem
			// 
			copyLabelMenuItem.Name = "copyLabelMenuItem";
			copyLabelMenuItem.Size = new Size(117, 22);
			copyLabelMenuItem.Text = "Copy";
			copyLabelMenuItem.Click += copyLabelMenuItem_Click;
			// 
			// labelMenuSeparator
			// 
			labelMenuSeparator.Name = "labelMenuSeparator";
			labelMenuSeparator.Size = new Size(114, 6);
			// 
			// copyAllLabelMenuItem
			// 
			copyAllLabelMenuItem.Name = "copyAllLabelMenuItem";
			copyAllLabelMenuItem.Size = new Size(117, 22);
			copyAllLabelMenuItem.Text = "Copy all";
			copyAllLabelMenuItem.Click += copyAllLabelMenuItem_Click;
			// 
			// projectLabel
			// 
			projectLabel.AutoSize = true;
			projectLabel.ContextMenuStrip = linkMenu;
			projectLabel.Cursor = Cursors.Hand;
			projectLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			projectLabel.Location = new Point(12, 52);
			projectLabel.Margin = new Padding(0);
			projectLabel.Name = "projectLabel";
			projectLabel.Size = new Size(326, 20);
			projectLabel.TabIndex = 1;
			projectLabel.Text = "https://github.com/nebojsa-gojnic/SimpleHttp";
			projectLabel.MouseDown += link_MouseDown;
			projectLabel.MouseEnter += link_MouseEnter;
			projectLabel.MouseLeave += link_MouseLeave;
			// 
			// linkMenu
			// 
			linkMenu.Items.AddRange(new ToolStripItem[] { openLinkMenuItem, copyLinkMenuSeparator0, copyLinkMenuItem, copyLinkMenuSeparator1, copyAllLinkMenuItem });
			linkMenu.Name = "labelMenu";
			linkMenu.Size = new Size(118, 82);
			linkMenu.Closed += linkMenu_Closed;
			// 
			// openLinkMenuItem
			// 
			openLinkMenuItem.Name = "openLinkMenuItem";
			openLinkMenuItem.Size = new Size(117, 22);
			openLinkMenuItem.Text = "Open";
			openLinkMenuItem.Click += openLinkMenuItem_Click;
			// 
			// copyLinkMenuSeparator0
			// 
			copyLinkMenuSeparator0.Name = "copyLinkMenuSeparator0";
			copyLinkMenuSeparator0.Size = new Size(114, 6);
			// 
			// copyLinkMenuItem
			// 
			copyLinkMenuItem.Name = "copyLinkMenuItem";
			copyLinkMenuItem.Size = new Size(117, 22);
			copyLinkMenuItem.Text = "Copy";
			copyLinkMenuItem.Click += copyLinkMenuItem_Click;
			// 
			// copyLinkMenuSeparator1
			// 
			copyLinkMenuSeparator1.Name = "copyLinkMenuSeparator1";
			copyLinkMenuSeparator1.Size = new Size(114, 6);
			// 
			// copyAllLinkMenuItem
			// 
			copyAllLinkMenuItem.Name = "copyAllLinkMenuItem";
			copyAllLinkMenuItem.Size = new Size(117, 22);
			copyAllLinkMenuItem.Text = "Copy all";
			copyAllLinkMenuItem.Click += copyAllLinkMenuItem_Click;
			// 
			// middleLabel
			// 
			middleLabel.AutoSize = true;
			middleLabel.ContextMenuStrip = labelMenu;
			middleLabel.Location = new Point(12, 80);
			middleLabel.Margin = new Padding(0, 8, 0, 0);
			middleLabel.Name = "middleLabel";
			middleLabel.Size = new Size(283, 40);
			middleLabel.TabIndex = 2;
			middleLabel.Text = "This is test and demo project \r\nfor Nebojša Gojnić's WebSockets projects";
			middleLabel.MouseDown += label_MouseDown;
			// 
			// webSocketLabel
			// 
			webSocketLabel.AutoSize = true;
			webSocketLabel.ContextMenuStrip = linkMenu;
			webSocketLabel.Cursor = Cursors.Hand;
			webSocketLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			webSocketLabel.Location = new Point(12, 120);
			webSocketLabel.Margin = new Padding(0);
			webSocketLabel.Name = "webSocketLabel";
			webSocketLabel.Size = new Size(332, 20);
			webSocketLabel.TabIndex = 3;
			webSocketLabel.Text = "https://github.com/nebojsa-gojnic/WebSockets";
			webSocketLabel.MouseDown += link_MouseDown;
			webSocketLabel.MouseEnter += link_MouseEnter;
			webSocketLabel.MouseLeave += link_MouseLeave;
			// 
			// bottomLabel
			// 
			bottomLabel.AutoSize = true;
			bottomLabel.ContextMenuStrip = labelMenu;
			bottomLabel.Location = new Point(12, 148);
			bottomLabel.Margin = new Padding(0, 8, 0, 0);
			bottomLabel.Name = "bottomLabel";
			bottomLabel.Padding = new Padding(0, 8, 0, 0);
			bottomLabel.Size = new Size(292, 48);
			bottomLabel.TabIndex = 4;
			bottomLabel.Text = "Nebojša Gojnić's WebSockets is developed\r\non original Dave Haig's WebSockets";
			bottomLabel.MouseDown += label_MouseDown;
			// 
			// ninjaLabel
			// 
			ninjaLabel.AutoSize = true;
			ninjaLabel.ContextMenuStrip = linkMenu;
			ninjaLabel.Cursor = Cursors.Hand;
			ninjaLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
			ninjaLabel.Location = new Point(12, 196);
			ninjaLabel.Margin = new Padding(0);
			ninjaLabel.Name = "ninjaLabel";
			ninjaLabel.Size = new Size(351, 20);
			ninjaLabel.TabIndex = 5;
			ninjaLabel.Text = "https://github.com/ninjasource/Ninja.WebSockets";
			ninjaLabel.MouseDown += link_MouseDown;
			ninjaLabel.MouseEnter += link_MouseEnter;
			ninjaLabel.MouseLeave += link_MouseLeave;
			// 
			// bottomPanel
			// 
			bottomPanel.AutoSize = true;
			bottomPanel.Controls.Add(closeButton);
			bottomPanel.Dock = DockStyle.Bottom;
			bottomPanel.FlowDirection = FlowDirection.RightToLeft;
			bottomPanel.Location = new Point(0, 228);
			bottomPanel.Margin = new Padding(0, 0, 12, 12);
			bottomPanel.Name = "bottomPanel";
			bottomPanel.Size = new Size(363, 36);
			bottomPanel.TabIndex = 0;
			bottomPanel.MouseDown += noLabel_MouseDown;
			// 
			// closeButton
			// 
			closeButton.AutoSize = true;
			closeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			closeButton.Location = new Point(292, 0);
			closeButton.Margin = new Padding(0);
			closeButton.Name = "closeButton";
			closeButton.Padding = new Padding(8, 3, 8, 3);
			closeButton.Size = new Size(71, 36);
			closeButton.TabIndex = 0;
			closeButton.Text = "Close";
			closeButton.UseVisualStyleBackColor = true;
			closeButton.Click += closeButton_Click;
			closeButton.MouseDown += noLabel_MouseDown;
			// 
			// AboutForm
			// 
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			CancelButton = closeButton;
			ClientSize = new Size(376, 276);
			Controls.Add(mainPanel);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			ShowInTaskbar = false;
			Text = "Simple Http Server";
			MouseDown += noLabel_MouseDown;
			mainPanel.ResumeLayout(false);
			mainPanel.PerformLayout();
			dialogPanel.ResumeLayout(false);
			dialogPanel.PerformLayout();
			labelMenu.ResumeLayout(false);
			linkMenu.ResumeLayout(false);
			bottomPanel.ResumeLayout(false);
			bottomPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private Label label1;
        private Label topLabel;
        private Label projectLabel;
        private Label middleLabel;
        private Label webSocketLabel;
        private Label bottomLabel;
        private Label ninjaLabel;
		private ContextMenuStrip labelMenu;
		private System.ComponentModel.IContainer components;
		private ToolStripMenuItem copyLabelMenuItem;
		private ToolStripSeparator labelMenuSeparator;
		private ToolStripMenuItem copyAllLabelMenuItem;
		private ContextMenuStrip linkMenu;
		private ToolStripMenuItem openLinkMenuItem;
		private ToolStripSeparator copyLinkMenuSeparator0;
		private ToolStripMenuItem copyLinkMenuItem;
		private ToolStripSeparator copyLinkMenuSeparator1;
		private ToolStripMenuItem copyAllLinkMenuItem;
	}
}
