using System ;
using System.Diagnostics ;
using System.Reflection;

namespace SimpleHttp
{
	public partial class AboutForm:Form
	{
		protected Font semiboldFont ;
		protected Font semiboldUnderlineFont ;
		protected Label selecteLabel ;
		protected Label selecteLink ;
		public AboutForm ()
		{
			InitializeComponent() ;
			selecteLink = null ;
			selecteLabel = null ;
			MonitorForm.CreateSemiboldFonts ( Font , out semiboldFont , out semiboldUnderlineFont ) ;
			
			titleBar.Font = MonitorForm.GetNewTitleFont ( Font ) ;
			projectLabel.Font =
				webSocketLabel.Font =
				ninjaLabel.Font = semiboldFont ;
			titleBar.BackColor = MonitorForm.titleBackColor ;
			titleBar.ForeColor = MonitorForm.titleForeColor ;

		}

		protected override void OnShown ( EventArgs e )
		{
			topLabel.Text = "Simple Http Server " + Assembly.GetEntryAssembly().GetName().Version.ToString () ;
			setSize () ;
			base.OnShown ( e ) ;
		}
		private void closeButton_Click ( object sender , EventArgs e )  
		{
			Close () ;
		}
		protected override void OnKeyDown ( KeyEventArgs e )
		{
			if ( ( e.KeyCode == Keys.Enter ) || ( e.KeyCode == Keys.Cancel ) || ( e.KeyCode == Keys.Space ) ) Close () ;
			base.OnKeyDown ( e ) ;
		}

		private void link_MouseEnter ( object sender , EventArgs e )
		{
			( ( Label ) sender ).Font = semiboldUnderlineFont ;
		}

		private void link_MouseLeave ( object sender , EventArgs e )
		{
			( ( Label ) sender ).Font = semiboldFont ;
		}
		
		private void label_MouseDown ( object sender , MouseEventArgs e )
		{
			//unselecteAllLabels () ;
			//selecteLabel = ( Label ) sender ;
			//selecteLabel.BackColor = SystemColors.Window ;
			//selecteLabel.ForeColor = SystemColors.WindowText ;
		}
		private void link_MouseDown ( object sender , MouseEventArgs e )
		{
			//unselecteAllLabels () ;
			//selecteLink = ( Label ) sender ;
			//selecteLink.BackColor = SystemColors.Window ;
			//selecteLink.ForeColor = SystemColors.WindowText ;
			if ( e.Button == MouseButtons.Left )
				openLink ( ( Label ) sender ) ;
		}
		private void noLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			unselecteAllLabels () ;
		}
		private void labelMenu_Closed ( object sender , ToolStripDropDownClosedEventArgs e )
		{
			unselecteAllLabels () ;
		}

		private void linkMenu_Closed ( object sender , ToolStripDropDownClosedEventArgs e )
		{
			unselecteAllLabels () ;
		}
		protected void unselecteAllLabels ()
		{
			if ( selecteLink != null ) 
			{
				selecteLink.BackColor = selecteLink.Parent.BackColor ;
				selecteLink.ForeColor = selecteLink.Parent.ForeColor ;
			}
			if ( selecteLabel != null ) 
			{
				selecteLabel.BackColor = selecteLabel.Parent.BackColor ;
				selecteLabel.ForeColor = selecteLabel.Parent.ForeColor ;
			}
		}
		private void copyLabelMenuItem_Click ( object sender , EventArgs e )
		{
			try
			{
				Clipboard.SetText ( selecteLabel.Text ) ;
			}
			catch { }
		}

		private void copyAllLabelMenuItem_Click ( object sender , EventArgs e )
		{
			copyAll ( ) ;

		}
		private void openLinkMenuItem_Click ( object sender , EventArgs e )
		{
			openLink ( selecteLink ) ;
		}

		private void copyLinkMenuItem_Click ( object sender , EventArgs e )
		{
			try
			{
				Clipboard.SetText ( selecteLink.Text ) ;
			}
			catch { }
		}

		private void copyAllLinkMenuItem_Click ( object sender , EventArgs e )
		{
			copyAll ( ) ;
		}
		private void openLink ( Label linkLabel )
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo ( "\"" + linkLabel.Text + "\"" ) ; //not "explorer" !
				startInfo.UseShellExecute = true ; //o yeeeaa!
				Process.Start ( startInfo ) ;
			}
			catch //( Exception x )
			{
				//showError ( "Cannot open uri" , x ) ;
			}
		}
		private void copyAll ( )
		{
			try
			{
				Clipboard.SetText ( 
					topLabel.Text + "\r\n" + 
					projectLabel.Text + "\r\n" + 
					middleLabel.Text + "\r\n" + 
					webSocketLabel.Text + "\r\n" + 
					bottomLabel.Text + "\r\n" + 
					ninjaLabel.Text
					) ;
			}
			catch { }
		}
		private void dialogPanel_Resize ( object sender, EventArgs e )
		{
			setSize () ;
		}
		private void setSize ()
		{
			Size = new Size ( Padding.Horizontal + dialogPanel.Width , dialogPanel.Height + titleBar.Height + Padding.Vertical ) ;
		}
		private void setMainPanelLocation ()
		{
			dialogPanel.Location = new Point ( Padding.Left , titleBar.Height + Padding.Top ) ;
		}
		private void tileBar_Resize ( object sender, EventArgs e )
		{
			setMainPanelLocation () ;
			setSize () ;
		}
		protected override void OnPaint ( PaintEventArgs e )
		{
			MonitorForm.drawBoxBorder ( e.Graphics , Size ) ;
			base.OnPaint(e) ;
		}
		private void titleBar_CloseButtonClick ( object sender , EventArgs e )
		{
			Close () ;
		}
		private void titleBar_CloseButtonMouseUp ( object sender , MouseEventArgs e )
		{
			try
			{ 
				closeButton.Focus () ;
			}
			catch { }
		}
		protected override void OnResize ( EventArgs e )
		{
			MonitorForm.SetBoxRegion ( this ) ;
			base.OnResize ( e ) ;
		}
		static readonly IntPtr HTCAPTION = new IntPtr ( 2 ) ;  
		[DebuggerStepThroughAttribute]
		protected override void WndProc ( ref Message m )
		{	
			if ( !DesignMode )
				if ( m.Msg == WindowMessage.WM_LButtonDown ) 
				{ 
					API.SendMessageA ( TopLevelControl.Handle , WindowMessage.WM_NCLButtonDown , HTCAPTION , m.LParam ) ; 
					return ;
				}	
			base.WndProc ( ref m ) ;
		}
	}
}
