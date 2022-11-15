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
			this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.messagePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.messagePicturePanel = new System.Windows.Forms.Panel();
			this.messagePicture = new System.Windows.Forms.PictureBox();
			this.textLabel = new System.Windows.Forms.Label();
			this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdNo = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.mainLayout.SuspendLayout();
			this.messagePanel.SuspendLayout();
			this.messagePicturePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.messagePicture)).BeginInit();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainLayout
			// 
			this.mainLayout.AutoSize = true;
			this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mainLayout.Controls.Add(this.messagePanel);
			this.mainLayout.Controls.Add(this.buttonPanel);
			this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.mainLayout.Location = new System.Drawing.Point(0, 0);
			this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.Padding = new System.Windows.Forms.Padding(12, 12, 8, 12);
			this.mainLayout.Size = new System.Drawing.Size(235, 163);
			this.mainLayout.TabIndex = 0;
			// 
			// messagePanel
			// 
			this.messagePanel.AutoSize = true;
			this.messagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.messagePanel.Controls.Add(this.messagePicturePanel);
			this.messagePanel.Controls.Add(this.textLabel);
			this.messagePanel.Location = new System.Drawing.Point(15, 15);
			this.messagePanel.Name = "messagePanel";
			this.messagePanel.Size = new System.Drawing.Size(181, 96);
			this.messagePanel.TabIndex = 3;
			// 
			// messagePicturePanel
			// 
			this.messagePicturePanel.AutoSize = true;
			this.messagePicturePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.messagePicturePanel.Controls.Add(this.messagePicture);
			this.messagePicturePanel.Location = new System.Drawing.Point(0, 0);
			this.messagePicturePanel.Margin = new System.Windows.Forms.Padding(0);
			this.messagePicturePanel.MinimumSize = new System.Drawing.Size(88, 88);
			this.messagePicturePanel.Name = "messagePicturePanel";
			this.messagePicturePanel.Padding = new System.Windows.Forms.Padding(8);
			this.messagePicturePanel.Size = new System.Drawing.Size(96, 96);
			this.messagePicturePanel.TabIndex = 2;
			// 
			// messagePicture
			// 
			this.messagePicture.Image = global::SimpleHttp.Properties.Resources.textIcon;
			this.messagePicture.Location = new System.Drawing.Point(8, 8);
			this.messagePicture.Margin = new System.Windows.Forms.Padding(0);
			this.messagePicture.MinimumSize = new System.Drawing.Size(80, 80);
			this.messagePicture.Name = "messagePicture";
			this.messagePicture.Size = new System.Drawing.Size(80, 80);
			this.messagePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.messagePicture.TabIndex = 0;
			this.messagePicture.TabStop = false;
			// 
			// textLabel
			// 
			this.textLabel.AutoSize = true;
			this.textLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.textLabel.Location = new System.Drawing.Point(99, 0);
			this.textLabel.Name = "textLabel";
			this.textLabel.Padding = new System.Windows.Forms.Padding(4);
			this.textLabel.Size = new System.Drawing.Size(79, 96);
			this.textLabel.TabIndex = 1;
			this.textLabel.Text = "Hello world!";
			this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonPanel
			// 
			this.buttonPanel.AutoSize = true;
			this.buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonPanel.Controls.Add(this.cmdCancel);
			this.buttonPanel.Controls.Add(this.cmdNo);
			this.buttonPanel.Controls.Add(this.cmdOk);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonPanel.Location = new System.Drawing.Point(12, 114);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.buttonPanel.Size = new System.Drawing.Size(215, 37);
			this.buttonPanel.TabIndex = 1;
			// 
			// cmdCancel
			// 
			this.cmdCancel.AutoSize = true;
			this.cmdCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdCancel.Location = new System.Drawing.Point(150, 8);
			this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cmdCancel.Size = new System.Drawing.Size(61, 29);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdNo
			// 
			this.cmdNo.AutoSize = true;
			this.cmdNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdNo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmdNo.Location = new System.Drawing.Point(77, 8);
			this.cmdNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.cmdNo.Name = "cmdNo";
			this.cmdNo.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cmdNo.Size = new System.Drawing.Size(65, 29);
			this.cmdNo.TabIndex = 2;
			this.cmdNo.Text = "    No    ";
			this.cmdNo.UseVisualStyleBackColor = true;
			this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.AutoSize = true;
			this.cmdOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmdOk.Location = new System.Drawing.Point(4, 8);
			this.cmdOk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cmdOk.Size = new System.Drawing.Size(65, 29);
			this.cmdOk.TabIndex = 0;
			this.cmdOk.Text = "    OK    ";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// MessageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(248, 165);
			this.Controls.Add(this.mainLayout);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MessageForm";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MessageForm";
			this.mainLayout.ResumeLayout(false);
			this.mainLayout.PerformLayout();
			this.messagePanel.ResumeLayout(false);
			this.messagePanel.PerformLayout();
			this.messagePicturePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.messagePicture)).EndInit();
			this.buttonPanel.ResumeLayout(false);
			this.buttonPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private FlowLayoutPanel mainLayout;
        private Label textLabel;
        private PictureBox messagePicture;
		private Panel messagePicturePanel ;
        private FlowLayoutPanel buttonPanel;
        private Button cmdCancel;
        private Button cmdOk;
        private Button cmdNo;
		private FlowLayoutPanel messagePanel;
	}
}