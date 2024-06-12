using System ;
using System.Collections.Generic ;
using System.ComponentModel;
using System.Drawing ;
using System.Text ;
using System.Windows.Forms ;

namespace SimpleHttp
{
	public partial class MessageForm : Form
	{
		// nullable/non-nullable, omg what did thay do with C#
		public event EventHandler<ButtonKind>? buttonClicked ;
		protected bool keyDownHandledByUser ;
		protected char pressedChar ;
		public MessageForm()
		{
			InitializeComponent() ;
			pressedChar = char.MinValue ;
			keyDownHandledByUser = false ;
			titlePanel.BackColor = MonitorForm.titleBackColor ;
			titlePanel.ForeColor = MonitorForm.titleForeColor ;
			MonitorForm.AssingFlatButtonAppearance ( closeButton ) ;
			//closeButton.BackColor = MonitorForm.errorEditBackColor ;
		}
		/// <summary>
		/// Button kind: ok(first),no(second),cancel(third)
		/// </summary>
		public enum ButtonKind
		{
			/// <summary>
			/// X button at the top right corner
			/// </summary>
			close= 0 , 
			/// <summary>
			/// First button, generaly confirmation(ok,yes,apply,)
			/// </summary>
			ok = 1 , 
			/// <summary>
			/// Second button, generaly opositie or destructive action
			/// </summary>
			no = 2 ,
			/// <summary>
			/// Last button, close or continue, genaraly "do nothing" button.
			/// </summary>
			cancel = 3 
		}


		private void cmdOk_Click ( object sender , EventArgs e )
		{
			buttonClicked?.Invoke ( this , ButtonKind.ok ) ;
		}
		private void cmdNo_Click ( object sender , EventArgs e )
		{
			buttonClicked?.Invoke ( this , ButtonKind.no ) ;
		}
		private void cmdCancel_Click ( object sender , EventArgs e )
		{
			buttonClicked?.Invoke ( this , ButtonKind.cancel ) ;
		}
		private void closeButton_Click ( object sender , EventArgs e )
		{
			buttonClicked?.Invoke ( this , ButtonKind.close ) ;
		}
		public string messageText
		{
			get => textLabel.Text ;
			set => textLabel.Text = value ;
		}
		public string title
		{
			get => titleLabel.Text ;
			set => titleLabel.Text = value ;
		}
		public void setOkButtonText ( string value )
		{
			if ( cmdOk.Text == value ) return ;
			cmdOk.Text = value ;
			cmdOk.Visible = cmdOk.Text.Length > 0 ; 
		}
		public string okButtonText
		{
			get => cmdOk.Text ;
			set => setOkButtonText ( value ) ;
		}
		public void setNoButtonText ( string value )
		{
			if ( cmdNo.Text == value ) return ;
			cmdNo.Text = value ;
			cmdNo.Visible = cmdNo.Text.Length > 0 ; 
		}
		public string noButtonText
		{
			get => cmdNo.Text ;
			set => setNoButtonText ( value ) ;
		}
		public void setCancelButtonText ( string value )
		{
			if ( cmdCancel.Text == value ) return ;
			cmdCancel.Text = value ;
			cmdCancel.Visible = cmdCancel.Text.Length > 0 ; 
		}
		public string cancelButtonText
		{
			get => cmdCancel.Text ;
			set => setCancelButtonText ( value ) ;
		}
		protected override void OnShown ( EventArgs e )
		{
			if ( this.Owner != null )
				if (  this.Owner.WindowState == FormWindowState.Minimized )
				{
					API.WindowPlacement wp = new API.WindowPlacement () ;
					API.GetWindowPlacement ( Owner.Handle , ref wp ) ;
					Location = new Point ( wp.NormalPosition.Left + ( ( wp.NormalPosition.Right - wp.NormalPosition.Left - Width ) >> 1 ) , wp.NormalPosition.Top + ( ( wp.NormalPosition.Bottom - wp.NormalPosition.Top - Height ) >> 1 ) ) ;
				}
				else Location = new Point ( Owner.Left + ( ( Owner.Width - Width ) >> 1 ) , Owner.Top + ( ( Owner.Height - Height ) >> 1 ) ) ;
			Opacity = 1.0 ;
			base.OnShown ( e ) ;
		}
		public static MessageForm ShowYesNo ( Form owner , string title , string caption , 
									EventHandler<ButtonKind> clickHandler , FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , 
									"  Yes  " , "" ,  "    No    " , clickHandler , fromClosedHalder ) ;
		}
		public static MessageForm ShowYesNo ( Form owner , string title , string caption , 
									EventHandler<ButtonKind> clickHandler , EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , 
									"  Yes  " , "" , "    No    " , clickHandler , null , disposedHandler ) ;
		}
		public static MessageForm ShowOKCancel ( Form owner , string title , string caption , 
									EventHandler<ButtonKind> clickHandler , FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , "    OK    " , "" , "Cancel" , clickHandler , fromClosedHalder ) ;
		}
		public static MessageForm ShowOKCancel ( Form owner , string title , string caption , 
									EventHandler<ButtonKind> clickHandler , EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , "    OK    " , "" , "Cancel" , clickHandler , null , disposedHandler ) ;
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<ButtonKind> clickHandler , FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , okButtonText , noButtonText , cancelButtonText , 
									clickHandler , fromClosedHalder , null ) ;
		
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<ButtonKind> clickHandler , EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , okButtonText , noButtonText , cancelButtonText , clickHandler , null , disposedHandler ) ;
		
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<ButtonKind> clickHandler ,FormClosedEventHandler? fromClosedHalder , EventHandler? disposedHandler )
		{
			return Show ( owner , SimpleHttp.Properties.Resources.textIcon , title , caption , okButtonText , noButtonText , cancelButtonText , 
							clickHandler , fromClosedHalder , disposedHandler ) ;
		}
		public static MessageForm Show ( Form owner , Image image , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<ButtonKind> clickHandler , FormClosedEventHandler? fromClosedHalder , EventHandler? disposedHandler )
		{
			MessageForm messageForm = new MessageForm () ;
			if ( owner == null )
				messageForm.Show ( ) ;
			else 
			{
				messageForm.Location = new Point ( -20000 , -20000 ) ;
				messageForm.Show ( owner ) ;
			}
			messageForm.messageImage = image ;
			messageForm.buttonClicked += clickHandler ;
			messageForm.okButtonText = okButtonText ;
			messageForm.cancelButtonText = cancelButtonText ;
			messageForm.noButtonText = noButtonText ;
			messageForm.title = title ;
			messageForm.messageText = caption ;
			messageForm.FormClosed += fromClosedHalder ;
			messageForm.Disposed += disposedHandler ;
			if ( owner != null )
				messageForm.Location = new Point ( owner.Left + ( ( owner.Width - messageForm.Width ) >> 1 ) , 
												owner.Top + ( ( owner.Height - messageForm.Height ) >> 1 ) ) ;
			return messageForm ;
		}
		public Image messageImage 
		{
			get => messagePicture.BackgroundImage ;
			set => setMessageImage ( value ) ;
		}
		protected void setMessageImage ( Image value )
		{
			messagePicture.BackgroundImage = value ;
			messagePicturePanel.Visible = value != null ;
		}

		public void setTitleAndCaption ( string title , string caption )
		{ 
			Text = title ;
			messageText = caption ;
		}
		protected override void OnTextChanged(EventArgs e)
		{
			titleLabel.Text = Text ;
			base.OnTextChanged(e) ;
		}
		public void setButtonText ( string okButtonText , string noButtonText , string cancelButtonText )
		{ 
			this.okButtonText = okButtonText ;
			this.noButtonText = noButtonText ;
			this.cancelButtonText = cancelButtonText ;
		}
		public void setAllText ( string title , string caption , string okButtonText , string noButtonText , string cancelButtonText )
		{ 
			setTitleAndCaption ( title , caption ) ;
			setButtonText ( okButtonText , noButtonText , cancelButtonText ) ;
		}
		public void setAll ( Image image , string title , string caption , string okButtonText , string noButtonText ,  string cancelButtonText )
		{ 
			messageImage = image ;
			messagePicturePanel.Visible = image != null ;
			setAllText ( title , caption , okButtonText , noButtonText , cancelButtonText ) ;
		}
		protected override void OnHandleCreated ( EventArgs e )
		{
			Screen screen = Screen.FromHandle ( Handle ) ;
			Rectangle bounds = screen.Bounds ;
			textLabel.MaximumSize = new Size ( bounds.Width > bounds.Height ? bounds.Width >> 1 : ( bounds.Width << 1 ) / 3 , 0 ) ;
			base.OnHandleCreated ( e ) ;
		}

        private void textLabel_DoubleClick ( object sender , EventArgs e )
        {
			try
			{
				Clipboard.SetText ( textLabel.Text ) ;
			}
			catch { }
        }
		protected override void OnFontChanged ( EventArgs e )
		{
			titleLabel.Font = MonitorForm.GetNewTitleFont ( Font ) ;
			int h = titleLabel.Font.Height ;
			closeButton.Size = new Size ( h , h ) ;
			titlePanel.Height = ( 3 * h ) >> 1 ;
			base.OnFontChanged ( e ) ;
		}
		private void titlePanel_Resize ( object sender , EventArgs e )
		{
			int d = ( titlePanel.Height - closeButton.Height ) >> 1 ;
			closeButton.Location = new Point ( titlePanel.Width - closeButton.Width - d , d ) ;
		}
		protected override void OnResize ( EventArgs e )
		{
			MonitorForm.SetBoxRegion ( this ) ;
			base.OnResize ( e ) ;
		}
		protected override void OnKeyDown ( KeyEventArgs e )
		{
			keyDownHandledByUser = e.Handled ;
			pressedChar = char.MinValue ;
			base.OnKeyDown ( e ) ;
			keyDownHandledByUser = e.Handled ;
		}
		protected override void OnKeyPress ( KeyPressEventArgs e )
		{
			pressedChar = e.Handled ? char.MinValue : e.KeyChar ;
			base.OnKeyPress ( e ) ;
		}
		protected override void OnKeyUp ( KeyEventArgs e )
		{
			base.OnKeyDown ( e ) ;
			if ( keyDownHandledByUser || e.Handled ) return ;
			switch ( e.KeyCode )
			{
				case Keys.Escape :
					closeButton_Click ( closeButton , e ) ;
				break ;
				case Keys.Enter :
					if ( cmdOk.Visible ) 
					{
						e.Handled = true ;
						cmdOk_Click ( cmdOk  , e ) ;
					}
					else if ( cmdNo.Visible )
					{
						e.Handled = true ;
						cmdNo_Click ( cmdNo , e ) ;
					}
					else if ( cmdCancel.Visible )
					{
						e.Handled = true ;
						cmdCancel_Click ( cmdNo , e ) ;
					}
					else closeButton_Click ( closeButton , e ) ;
				break ;
				default :
				break ;
			}
		}
		protected bool handleHotKey ( char key )
		{
			if ( key == char.MinValue ) return false ;
			return false ;
		}
		protected override void OnPaint ( PaintEventArgs e )
		{
			MonitorForm.drawBoxBorder ( e.Graphics , Size ) ;
		}
	}
}
