using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttp
{
	public partial class AboutForm
	{
        private CommonFlowLayoutPanel dialogPanel;
        private CommonFlowLayoutPanel bottomPanel;
		private Button closeButton;

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			dialogPanel = new CommonFlowLayoutPanel();
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
			bottomPanel = new CommonFlowLayoutPanel();
			closeButton = new Button();
			titleBar = new TitleBar();
			dialogPanel.SuspendLayout();
			labelMenu.SuspendLayout();
			linkMenu.SuspendLayout();
			bottomPanel.SuspendLayout();
			SuspendLayout();
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
			dialogPanel.Controls.Add(bottomPanel);
			dialogPanel.FlowDirection = FlowDirection.TopDown;
			dialogPanel.Location = new Point(1, 31);
			dialogPanel.Margin = new Padding(0);
			dialogPanel.Name = "dialogPanel";
			dialogPanel.Padding = new Padding(12);
			dialogPanel.Size = new Size(375, 276);
			dialogPanel.TabIndex = 1;
			dialogPanel.MouseDown += noLabel_MouseDown;
			dialogPanel.Resize += dialogPanel_Resize;
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
			labelMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			labelMenu.Items.AddRange(new ToolStripItem[] { copyLabelMenuItem, labelMenuSeparator, copyAllLabelMenuItem });
			labelMenu.Name = "labelMenu";
			labelMenu.Size = new Size(133, 58);
			labelMenu.Closed += labelMenu_Closed;
			// 
			// copyLabelMenuItem
			// 
			copyLabelMenuItem.Name = "copyLabelMenuItem";
			copyLabelMenuItem.Size = new Size(132, 24);
			copyLabelMenuItem.Text = "Copy";
			copyLabelMenuItem.Click += copyLabelMenuItem_Click;
			// 
			// labelMenuSeparator
			// 
			labelMenuSeparator.Name = "labelMenuSeparator";
			labelMenuSeparator.Size = new Size(129, 6);
			// 
			// copyAllLabelMenuItem
			// 
			copyAllLabelMenuItem.Name = "copyAllLabelMenuItem";
			copyAllLabelMenuItem.Size = new Size(132, 24);
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
			linkMenu.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			linkMenu.Items.AddRange(new ToolStripItem[] { openLinkMenuItem, copyLinkMenuSeparator0, copyLinkMenuItem, copyLinkMenuSeparator1, copyAllLinkMenuItem });
			linkMenu.Name = "labelMenu";
			linkMenu.Size = new Size(181, 110);
			linkMenu.Closed += linkMenu_Closed;
			// 
			// openLinkMenuItem
			// 
			openLinkMenuItem.Name = "openLinkMenuItem";
			openLinkMenuItem.Size = new Size(180, 24);
			openLinkMenuItem.Text = "Open";
			openLinkMenuItem.Click += openLinkMenuItem_Click;
			// 
			// copyLinkMenuSeparator0
			// 
			copyLinkMenuSeparator0.Name = "copyLinkMenuSeparator0";
			copyLinkMenuSeparator0.Size = new Size(177, 6);
			// 
			// copyLinkMenuItem
			// 
			copyLinkMenuItem.Name = "copyLinkMenuItem";
			copyLinkMenuItem.Size = new Size(180, 24);
			copyLinkMenuItem.Text = "Copy";
			copyLinkMenuItem.Click += copyLinkMenuItem_Click;
			// 
			// copyLinkMenuSeparator1
			// 
			copyLinkMenuSeparator1.Name = "copyLinkMenuSeparator1";
			copyLinkMenuSeparator1.Size = new Size(177, 6);
			// 
			// copyAllLinkMenuItem
			// 
			copyAllLinkMenuItem.Name = "copyAllLinkMenuItem";
			copyAllLinkMenuItem.Size = new Size(180, 24);
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
			bottomPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bottomPanel.AutoSize = true;
			bottomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			bottomPanel.Controls.Add(closeButton);
			bottomPanel.FlowDirection = FlowDirection.RightToLeft;
			bottomPanel.Location = new Point(292, 228);
			bottomPanel.Margin = new Padding(0, 12, 0, 0);
			bottomPanel.Name = "bottomPanel";
			bottomPanel.Size = new Size(71, 36);
			bottomPanel.TabIndex = 0;
			bottomPanel.MouseDown += noLabel_MouseDown;
			// 
			// closeButton
			// 
			closeButton.AutoSize = true;
			closeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			closeButton.Location = new Point(0, 0);
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
			// titleBar
			// 
			titleBar.AutoSize = true;
			titleBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			titleBar.CloseButtonImage = (Image)resources.GetObject("titleBar.CloseButtonImage");
			titleBar.Dock = DockStyle.Top;
			titleBar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			titleBar.Location = new Point(1, 1);
			titleBar.Margin = new Padding(0);
			titleBar.MaximumSize = new Size(int.MaxValue, 30);
			titleBar.MinimumSize = new Size(0, 30);
			titleBar.Name = "titleBar";
			titleBar.Size = new Size(372, 30);
			titleBar.TabIndex = 6;
			titleBar.Text = "Simple Http Server";
			titleBar.CloseButtonClick += titleBar_CloseButtonClick;
			titleBar.CloseButtonMouseUp += titleBar_CloseButtonMouseUp;
			titleBar.Resize += tileBar_Resize;
			// 
			// AboutForm
			// 
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			CancelButton = closeButton;
			ClientSize = new Size(374, 306);
			Controls.Add(dialogPanel);
			Controls.Add(titleBar);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			Padding = new Padding(1);
			ShowInTaskbar = false;
			Text = "Simple Http Server";
			MouseDown += noLabel_MouseDown;
			dialogPanel.ResumeLayout(false);
			dialogPanel.PerformLayout();
			labelMenu.ResumeLayout(false);
			linkMenu.ResumeLayout(false);
			bottomPanel.ResumeLayout(false);
			bottomPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

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
		private TitleBar titleBar;
	}
}
