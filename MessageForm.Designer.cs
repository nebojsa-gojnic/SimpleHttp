namespace SimpleHttp
{
	partial class MessageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
			mainLayout = new CommonFlowLayoutPanel();
			messagePanel = new CommonTableLayoutPanel();
			messagePicturePanel = new CommonPanel();
			messagePicture = new CommonPanel();
			textLabel = new CommonLabel();
			buttonPanel = new CommonFlowLayoutPanel();
			cmdOk = new Button();
			cmdNo = new Button();
			cmdCancel = new Button();
			titleBar = new TitleBar();
			mainLayout.SuspendLayout();
			messagePanel.SuspendLayout();
			messagePicturePanel.SuspendLayout();
			buttonPanel.SuspendLayout();
			SuspendLayout();
			// 
			// mainLayout
			// 
			mainLayout.AutoSize = true;
			mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			mainLayout.Controls.Add(messagePanel);
			mainLayout.Controls.Add(buttonPanel);
			mainLayout.FlowDirection = FlowDirection.TopDown;
			mainLayout.Location = new Point(1, 25);
			mainLayout.Margin = new Padding(0);
			mainLayout.Name = "mainLayout";
			mainLayout.Size = new Size(300, 199);
			mainLayout.TabIndex = 0;
			mainLayout.WrapContents = false;
			mainLayout.Move += mainLayout_Resize;
			mainLayout.Resize += mainLayout_Resize;
			// 
			// messagePanel
			// 
			messagePanel.Anchor = AnchorStyles.Top;
			messagePanel.AutoSize = true;
			messagePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			messagePanel.ColumnCount = 2;
			messagePanel.ColumnStyles.Add(new ColumnStyle());
			messagePanel.ColumnStyles.Add(new ColumnStyle());
			messagePanel.Controls.Add(messagePicturePanel, 0, 0);
			messagePanel.Controls.Add(textLabel, 1, 0);
			messagePanel.Location = new Point(0, 0);
			messagePanel.Margin = new Padding(0);
			messagePanel.MinimumSize = new Size(300, 150);
			messagePanel.Name = "messagePanel";
			messagePanel.Padding = new Padding(12, 12, 12, 0);
			messagePanel.RowStyles.Add(new RowStyle());
			messagePanel.Size = new Size(300, 150);
			messagePanel.TabIndex = 3;
			messagePanel.Click += mainLayout_Resize;
			// 
			// messagePicturePanel
			// 
			messagePicturePanel.Anchor = AnchorStyles.Left;
			messagePicturePanel.AutoSize = true;
			messagePicturePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			messagePicturePanel.Controls.Add(messagePicture);
			messagePicturePanel.Location = new Point(12, 33);
			messagePicturePanel.Margin = new Padding(0);
			messagePicturePanel.MinimumSize = new Size(88, 88);
			messagePicturePanel.Name = "messagePicturePanel";
			messagePicturePanel.Padding = new Padding(8);
			messagePicturePanel.Size = new Size(96, 96);
			messagePicturePanel.TabIndex = 2;
			// 
			// messagePicture
			// 
			messagePicture.BackgroundImage = Properties.Resources.textIcon;
			messagePicture.BackgroundImageLayout = ImageLayout.Zoom;
			messagePicture.Location = new Point(8, 8);
			messagePicture.Margin = new Padding(0);
			messagePicture.MinimumSize = new Size(80, 80);
			messagePicture.Name = "messagePicture";
			messagePicture.Size = new Size(80, 80);
			messagePicture.TabIndex = 0;
			// 
			// textLabel
			// 
			textLabel.Anchor = AnchorStyles.Left;
			textLabel.AutoSize = true;
			textLabel.Location = new Point(111, 69);
			textLabel.Name = "textLabel";
			textLabel.Padding = new Padding(4);
			textLabel.Size = new Size(79, 23);
			textLabel.TabIndex = 1;
			textLabel.Text = "Hello world!";
			textLabel.TextAlign = ContentAlignment.MiddleLeft;
			textLabel.Click += mainLayout_Resize;
			textLabel.DoubleClick += textLabel_DoubleClick;
			// 
			// buttonPanel
			// 
			buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonPanel.AutoSize = true;
			buttonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			buttonPanel.Controls.Add(cmdOk);
			buttonPanel.Controls.Add(cmdNo);
			buttonPanel.Controls.Add(cmdCancel);
			buttonPanel.Location = new Point(61, 150);
			buttonPanel.Margin = new Padding(0);
			buttonPanel.Name = "buttonPanel";
			buttonPanel.Padding = new Padding(12, 8, 12, 12);
			buttonPanel.Size = new Size(239, 49);
			buttonPanel.TabIndex = 1;
			// 
			// cmdOk
			// 
			cmdOk.AutoSize = true;
			cmdOk.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cmdOk.Dock = DockStyle.Bottom;
			cmdOk.Location = new Point(16, 8);
			cmdOk.Margin = new Padding(4, 0, 4, 0);
			cmdOk.Name = "cmdOk";
			cmdOk.Padding = new Padding(4, 2, 4, 2);
			cmdOk.Size = new Size(65, 29);
			cmdOk.TabIndex = 0;
			cmdOk.Text = "    OK    ";
			cmdOk.UseVisualStyleBackColor = true;
			cmdOk.Click += cmdOk_Click;
			// 
			// cmdNo
			// 
			cmdNo.AutoSize = true;
			cmdNo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cmdNo.Dock = DockStyle.Bottom;
			cmdNo.Location = new Point(89, 8);
			cmdNo.Margin = new Padding(4, 0, 4, 0);
			cmdNo.Name = "cmdNo";
			cmdNo.Padding = new Padding(4, 2, 4, 2);
			cmdNo.Size = new Size(65, 29);
			cmdNo.TabIndex = 2;
			cmdNo.Text = "    No    ";
			cmdNo.UseVisualStyleBackColor = true;
			cmdNo.Click += cmdNo_Click;
			// 
			// cmdCancel
			// 
			cmdCancel.AutoSize = true;
			cmdCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cmdCancel.Location = new Point(162, 8);
			cmdCancel.Margin = new Padding(4, 0, 4, 0);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Padding = new Padding(4, 2, 4, 2);
			cmdCancel.Size = new Size(61, 29);
			cmdCancel.TabIndex = 1;
			cmdCancel.Text = "Cancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += cmdCancel_Click;
			// 
			// titleBar
			// 
			titleBar.AutoSize = true;
			titleBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			titleBar.CloseButtonImage = (Image)resources.GetObject("titleBar.CloseButtonImage");
			titleBar.Dock = DockStyle.Top;
			titleBar.Location = new Point(1, 1);
			titleBar.MaximumSize = new Size(int.MaxValue, 24);
			titleBar.MinimumSize = new Size(0, 24);
			titleBar.Name = "titleBar";
			titleBar.Size = new Size(303, 24);
			titleBar.TabIndex = 1;
			titleBar.Text = "titleBar1";
			titleBar.CloseButtonClick += closeButton_Click;
			titleBar.Move += titleBar_Resize;
			titleBar.Resize += titleBar_Resize;
			// 
			// MessageForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(305, 231);
			ControlBox = false;
			Controls.Add(mainLayout);
			Controls.Add(titleBar);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MessageForm";
			Opacity = 0D;
			Padding = new Padding(1);
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "MessageForm";
			mainLayout.ResumeLayout(false);
			mainLayout.PerformLayout();
			messagePanel.ResumeLayout(false);
			messagePanel.PerformLayout();
			messagePicturePanel.ResumeLayout(false);
			buttonPanel.ResumeLayout(false);
			buttonPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private CommonFlowLayoutPanel mainLayout;
        private CommonLabel textLabel;
        private CommonPanel messagePicture;
		private CommonPanel messagePicturePanel ;
        private CommonFlowLayoutPanel buttonPanel;
        private Button cmdCancel;
        private Button cmdOk;
        private Button cmdNo;
		private CommonTableLayoutPanel messagePanel;
		private TitleBar titleBar;
	}
}