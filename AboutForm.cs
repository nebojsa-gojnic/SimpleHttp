using System ;
using System.Diagnostics ;
using System.Reflection;

namespace SimpleHttp
{
	public partial class AboutForm:Form
	{
		protected Font boldFont ;
		protected Font boldUnderlineFont ;
		protected Label selecteLabel ;
		protected Label selecteLink ;
		public AboutForm ()
		{
			InitializeComponent() ;
			selecteLink = null ;
			selecteLabel = null ;
			boldUnderlineFont = new Font ( ( boldFont = projectLabel.Font ).FontFamily , Font.Size , projectLabel.Font.Style | FontStyle.Underline ) ;
		}

		protected override void OnShown ( EventArgs e )
		{
			topLabel.Text = "Simple Http Server " + Assembly.GetEntryAssembly ().GetName().Version.ToString () ;
			base.OnShown( e) ;
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
			( ( Label ) sender ).Font = boldUnderlineFont ;

		}

		private void link_MouseLeave ( object sender , EventArgs e )
		{
			( ( Label ) sender ).Font = boldFont ;
		}
		
		private void label_MouseDown ( object sender , MouseEventArgs e )
		{
			unselecteAllLabels () ;
			selecteLabel = ( Label ) sender ;
			selecteLabel.BackColor = SystemColors.Window ;
			selecteLabel.ForeColor = SystemColors.WindowText ;
		}
		private void link_MouseDown ( object sender , MouseEventArgs e )
		{
			unselecteAllLabels () ;
			selecteLink = ( Label ) sender ;
			selecteLink.BackColor = SystemColors.Window ;
			selecteLink.ForeColor = SystemColors.WindowText ;
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
			catch ( Exception x )
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


	
	}
}
