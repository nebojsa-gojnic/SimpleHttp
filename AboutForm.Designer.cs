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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.dialogPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.topLabel = new System.Windows.Forms.Label();
			this.labelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.copyAllLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectLabel = new System.Windows.Forms.Label();
			this.linkMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyLinkMenuSeparator0 = new System.Windows.Forms.ToolStripSeparator();
			this.copyLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyLinkMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.copyAllLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.middleLabel = new System.Windows.Forms.Label();
			this.webSocketLabel = new System.Windows.Forms.Label();
			this.bottomLabel = new System.Windows.Forms.Label();
			this.ninjaLabel = new System.Windows.Forms.Label();
			this.bottomPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.closeButton = new System.Windows.Forms.Button();
			this.mainPanel.SuspendLayout();
			this.dialogPanel.SuspendLayout();
			this.labelMenu.SuspendLayout();
			this.linkMenu.SuspendLayout();
			this.bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.AutoSize = true;
			this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainPanel.Controls.Add(this.dialogPanel);
			this.mainPanel.Controls.Add(this.bottomPanel);
			this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(375, 276);
			this.mainPanel.TabIndex = 0;
			this.mainPanel.WrapContents = false;
			this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLabel_MouseDown);
			// 
			// dialogPanel
			// 
			this.dialogPanel.AutoSize = true;
			this.dialogPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.dialogPanel.Controls.Add(this.topLabel);
			this.dialogPanel.Controls.Add(this.projectLabel);
			this.dialogPanel.Controls.Add(this.middleLabel);
			this.dialogPanel.Controls.Add(this.webSocketLabel);
			this.dialogPanel.Controls.Add(this.bottomLabel);
			this.dialogPanel.Controls.Add(this.ninjaLabel);
			this.dialogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dialogPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.dialogPanel.Location = new System.Drawing.Point(0, 0);
			this.dialogPanel.Margin = new System.Windows.Forms.Padding(0);
			this.dialogPanel.Name = "dialogPanel";
			this.dialogPanel.Padding = new System.Windows.Forms.Padding(12);
			this.dialogPanel.Size = new System.Drawing.Size(375, 228);
			this.dialogPanel.TabIndex = 1;
			this.dialogPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLabel_MouseDown);
			// 
			// topLabel
			// 
			this.topLabel.AutoSize = true;
			this.topLabel.ContextMenuStrip = this.labelMenu;
			this.topLabel.Location = new System.Drawing.Point(12, 12);
			this.topLabel.Margin = new System.Windows.Forms.Padding(0);
			this.topLabel.Name = "topLabel";
			this.topLabel.Size = new System.Drawing.Size(198, 40);
			this.topLabel.TabIndex = 0;
			this.topLabel.Text = "Simple Http Server,\r\nAuthor Nebojša Gojnić, 2022\r\n";
			this.topLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
			// 
			// labelMenu
			// 
			this.labelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLabelMenuItem,
            this.labelMenuSeparator,
            this.copyAllLabelMenuItem});
			this.labelMenu.Name = "labelMenu";
			this.labelMenu.Size = new System.Drawing.Size(118, 54);
			this.labelMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.labelMenu_Closed);
			// 
			// copyLabelMenuItem
			// 
			this.copyLabelMenuItem.Name = "copyLabelMenuItem";
			this.copyLabelMenuItem.Size = new System.Drawing.Size(117, 22);
			this.copyLabelMenuItem.Text = "Copy";
			this.copyLabelMenuItem.Click += new System.EventHandler(this.copyLabelMenuItem_Click);
			// 
			// labelMenuSeparator
			// 
			this.labelMenuSeparator.Name = "labelMenuSeparator";
			this.labelMenuSeparator.Size = new System.Drawing.Size(114, 6);
			// 
			// copyAllLabelMenuItem
			// 
			this.copyAllLabelMenuItem.Name = "copyAllLabelMenuItem";
			this.copyAllLabelMenuItem.Size = new System.Drawing.Size(117, 22);
			this.copyAllLabelMenuItem.Text = "Copy all";
			this.copyAllLabelMenuItem.Click += new System.EventHandler(this.copyAllLabelMenuItem_Click);
			// 
			// projectLabel
			// 
			this.projectLabel.AutoSize = true;
			this.projectLabel.ContextMenuStrip = this.linkMenu;
			this.projectLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.projectLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.projectLabel.Location = new System.Drawing.Point(12, 52);
			this.projectLabel.Margin = new System.Windows.Forms.Padding(0);
			this.projectLabel.Name = "projectLabel";
			this.projectLabel.Size = new System.Drawing.Size(326, 20);
			this.projectLabel.TabIndex = 1;
			this.projectLabel.Text = "https://github.com/nebojsa-gojnic/SimpleHttp";
			this.projectLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.link_MouseDown);
			this.projectLabel.MouseEnter += new System.EventHandler(this.link_MouseEnter);
			this.projectLabel.MouseLeave += new System.EventHandler(this.link_MouseLeave);
			// 
			// linkMenu
			// 
			this.linkMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLinkMenuItem,
            this.copyLinkMenuSeparator0,
            this.copyLinkMenuItem,
            this.copyLinkMenuSeparator1,
            this.copyAllLinkMenuItem});
			this.linkMenu.Name = "labelMenu";
			this.linkMenu.Size = new System.Drawing.Size(118, 82);
			this.linkMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.linkMenu_Closed);
			// 
			// openLinkMenuItem
			// 
			this.openLinkMenuItem.Name = "openLinkMenuItem";
			this.openLinkMenuItem.Size = new System.Drawing.Size(117, 22);
			this.openLinkMenuItem.Text = "Open";
			this.openLinkMenuItem.Click += new System.EventHandler(this.openLinkMenuItem_Click);
			// 
			// copyLinkMenuSeparator0
			// 
			this.copyLinkMenuSeparator0.Name = "copyLinkMenuSeparator0";
			this.copyLinkMenuSeparator0.Size = new System.Drawing.Size(114, 6);
			// 
			// copyLinkMenuItem
			// 
			this.copyLinkMenuItem.Name = "copyLinkMenuItem";
			this.copyLinkMenuItem.Size = new System.Drawing.Size(117, 22);
			this.copyLinkMenuItem.Text = "Copy";
			this.copyLinkMenuItem.Click += new System.EventHandler(this.copyLinkMenuItem_Click);
			// 
			// copyLinkMenuSeparator1
			// 
			this.copyLinkMenuSeparator1.Name = "copyLinkMenuSeparator1";
			this.copyLinkMenuSeparator1.Size = new System.Drawing.Size(114, 6);
			// 
			// copyAllLinkMenuItem
			// 
			this.copyAllLinkMenuItem.Name = "copyAllLinkMenuItem";
			this.copyAllLinkMenuItem.Size = new System.Drawing.Size(117, 22);
			this.copyAllLinkMenuItem.Text = "Copy all";
			this.copyAllLinkMenuItem.Click += new System.EventHandler(this.copyAllLinkMenuItem_Click);
			// 
			// middleLabel
			// 
			this.middleLabel.AutoSize = true;
			this.middleLabel.ContextMenuStrip = this.labelMenu;
			this.middleLabel.Location = new System.Drawing.Point(12, 80);
			this.middleLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.middleLabel.Name = "middleLabel";
			this.middleLabel.Size = new System.Drawing.Size(283, 40);
			this.middleLabel.TabIndex = 2;
			this.middleLabel.Text = "This is test and demo project \r\nfor Nebojša Gojnić\'s WebSockets projects";
			this.middleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
			// 
			// webSocketLabel
			// 
			this.webSocketLabel.AutoSize = true;
			this.webSocketLabel.ContextMenuStrip = this.linkMenu;
			this.webSocketLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.webSocketLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.webSocketLabel.Location = new System.Drawing.Point(12, 120);
			this.webSocketLabel.Margin = new System.Windows.Forms.Padding(0);
			this.webSocketLabel.Name = "webSocketLabel";
			this.webSocketLabel.Size = new System.Drawing.Size(332, 20);
			this.webSocketLabel.TabIndex = 3;
			this.webSocketLabel.Text = "https://github.com/nebojsa-gojnic/WebSockets";
			this.webSocketLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.link_MouseDown);
			this.webSocketLabel.MouseEnter += new System.EventHandler(this.link_MouseEnter);
			this.webSocketLabel.MouseLeave += new System.EventHandler(this.link_MouseLeave);
			// 
			// bottomLabel
			// 
			this.bottomLabel.AutoSize = true;
			this.bottomLabel.ContextMenuStrip = this.labelMenu;
			this.bottomLabel.Location = new System.Drawing.Point(12, 148);
			this.bottomLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.bottomLabel.Name = "bottomLabel";
			this.bottomLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.bottomLabel.Size = new System.Drawing.Size(292, 48);
			this.bottomLabel.TabIndex = 4;
			this.bottomLabel.Text = "Nebojša Gojnić\'s WebSockets is developed\r\non original Dave Haig\'s WebSockets";
			this.bottomLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
			// 
			// ninjaLabel
			// 
			this.ninjaLabel.AutoSize = true;
			this.ninjaLabel.ContextMenuStrip = this.linkMenu;
			this.ninjaLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ninjaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.ninjaLabel.Location = new System.Drawing.Point(12, 196);
			this.ninjaLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ninjaLabel.Name = "ninjaLabel";
			this.ninjaLabel.Size = new System.Drawing.Size(351, 20);
			this.ninjaLabel.TabIndex = 5;
			this.ninjaLabel.Text = "https://github.com/ninjasource/Ninja.WebSockets";
			this.ninjaLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.link_MouseDown);
			this.ninjaLabel.MouseEnter += new System.EventHandler(this.link_MouseEnter);
			this.ninjaLabel.MouseLeave += new System.EventHandler(this.link_MouseLeave);
			// 
			// bottomPanel
			// 
			this.bottomPanel.AutoSize = true;
			this.bottomPanel.Controls.Add(this.closeButton);
			this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.bottomPanel.Location = new System.Drawing.Point(0, 228);
			this.bottomPanel.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.bottomPanel.Name = "bottomPanel";
			this.bottomPanel.Size = new System.Drawing.Size(363, 36);
			this.bottomPanel.TabIndex = 0;
			this.bottomPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLabel_MouseDown);
			// 
			// closeButton
			// 
			this.closeButton.AutoSize = true;
			this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.closeButton.Location = new System.Drawing.Point(292, 0);
			this.closeButton.Margin = new System.Windows.Forms.Padding(0);
			this.closeButton.Name = "closeButton";
			this.closeButton.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.closeButton.Size = new System.Drawing.Size(71, 36);
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			this.closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLabel_MouseDown);
			// 
			// AboutForm
			// 
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(376, 276);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.Text = "Simple Http Server";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.noLabel_MouseDown);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.dialogPanel.ResumeLayout(false);
			this.dialogPanel.PerformLayout();
			this.labelMenu.ResumeLayout(false);
			this.linkMenu.ResumeLayout(false);
			this.bottomPanel.ResumeLayout(false);
			this.bottomPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
