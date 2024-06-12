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
			titlePanel = new CommonPanel();
			closeButton = new Button();
			titleLabel = new CommonLabel();
			mainLayout = new CommonFlowLayoutPanel();
			messagePanel = new CommonFlowLayoutPanel();
			messagePicturePanel = new CommonPanel();
			messagePicture = new CommonPanel();
			textLabel = new CommonLabel();
			buttonPanel = new CommonFlowLayoutPanel();
			cmdOk = new Button();
			cmdNo = new Button();
			cmdCancel = new Button();
			titlePanel.SuspendLayout();
			mainLayout.SuspendLayout();
			messagePanel.SuspendLayout();
			messagePicturePanel.SuspendLayout();
			buttonPanel.SuspendLayout();
			SuspendLayout();
			// 
			// titlePanel
			// 
			titlePanel.Controls.Add(closeButton);
			titlePanel.Controls.Add(titleLabel);
			titlePanel.Dock = DockStyle.Top;
			titlePanel.Location = new Point(0, 0);
			titlePanel.Margin = new Padding(0);
			titlePanel.Name = "titlePanel";
			titlePanel.Size = new Size(400, 33);
			titlePanel.TabIndex = 0;
			titlePanel.Resize += titlePanel_Resize;
			// 
			// closeButton
			// 
			closeButton.Anchor = AnchorStyles.Right;
			closeButton.BackColor = SystemColors.ButtonFace;
			closeButton.BackgroundImage = Properties.Resources.closeX;
			closeButton.BackgroundImageLayout = ImageLayout.Stretch;
			closeButton.FlatAppearance.BorderSize = 0;
			closeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			closeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight;
			closeButton.FlatStyle = FlatStyle.Flat;
			closeButton.Location = new Point(370, 4);
			closeButton.Margin = new Padding(3, 0, 0, 0);
			closeButton.Name = "closeButton";
			closeButton.Size = new Size(26, 27);
			closeButton.TabIndex = 15;
			closeButton.TabStop = false;
			closeButton.TextImageRelation = TextImageRelation.ImageAboveText;
			closeButton.UseVisualStyleBackColor = false;
			closeButton.Click += closeButton_Click;
			// 
			// titleLabel
			// 
			titleLabel.Dock = DockStyle.Fill;
			titleLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			titleLabel.Location = new Point(0, 0);
			titleLabel.Margin = new Padding(0);
			titleLabel.Name = "titleLabel";
			titleLabel.Padding = new Padding(4);
			titleLabel.Size = new Size(400, 33);
			titleLabel.TabIndex = 2;
			titleLabel.Text = "Title";
			titleLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// mainLayout
			// 
			mainLayout.AutoSize = true;
			mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			mainLayout.BackColor = Color.WhiteSmoke;
			mainLayout.Controls.Add(titlePanel);
			mainLayout.Controls.Add(messagePanel);
			mainLayout.Controls.Add(buttonPanel);
			mainLayout.FlowDirection = FlowDirection.TopDown;
			mainLayout.Location = new Point(1, 1);
			mainLayout.Margin = new Padding(0);
			mainLayout.Name = "mainLayout";
			mainLayout.Size = new Size(400, 190);
			mainLayout.TabIndex = 0;
			// 
			// messagePanel
			// 
			messagePanel.Anchor = AnchorStyles.Top;
			messagePanel.AutoSize = true;
			messagePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			messagePanel.Controls.Add(messagePicturePanel);
			messagePanel.Controls.Add(textLabel);
			messagePanel.Location = new Point(0, 33);
			messagePanel.Margin = new Padding(0);
			messagePanel.MinimumSize = new Size(400, 0);
			messagePanel.Name = "messagePanel";
			messagePanel.Padding = new Padding(12, 12, 12, 0);
			messagePanel.Size = new Size(400, 108);
			messagePanel.TabIndex = 3;
			// 
			// messagePicturePanel
			// 
			messagePicturePanel.AutoSize = true;
			messagePicturePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			messagePicturePanel.Controls.Add(messagePicture);
			messagePicturePanel.Location = new Point(12, 12);
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
			textLabel.AutoSize = true;
			textLabel.Dock = DockStyle.Left;
			textLabel.Location = new Point(111, 12);
			textLabel.Name = "textLabel";
			textLabel.Padding = new Padding(4);
			textLabel.Size = new Size(79, 96);
			textLabel.TabIndex = 1;
			textLabel.Text = "Hello world!";
			textLabel.TextAlign = ContentAlignment.MiddleLeft;
			textLabel.DoubleClick += textLabel_DoubleClick;
			// 
			// buttonPanel
			// 
			buttonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonPanel.AutoSize = true;
			buttonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			buttonPanel.Controls.Add(cmdOk);
			buttonPanel.Controls.Add(cmdNo);
			buttonPanel.Controls.Add(cmdCancel);
			buttonPanel.Location = new Point(161, 141);
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
			// MessageForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			BackColor = SystemColors.ActiveBorder;
			ClientSize = new Size(450, 165);
			ControlBox = false;
			Controls.Add(mainLayout);
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
			titlePanel.ResumeLayout(false);
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
		private CommonFlowLayoutPanel messagePanel;
		private CommonPanel titlePanel;
		private CommonLabel titleLabel;
		private Button closeButton;
	}
}