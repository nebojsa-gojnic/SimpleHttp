using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleHttp
{
	public partial class MessageForm : Form
	{
		public MessageForm()
		{
			InitializeComponent();
		}

		private void cmdOk_Click ( object sender , EventArgs e )
		{
			cmdOkClicked?.Invoke ( this , e ) ;
		}
		private void cmdNo_Click(object sender, EventArgs e)
		{
			cmdNoClicked?.Invoke ( this , e ) ;
		}

		private void cmdCancel_Click ( object sender , EventArgs e )
		{
			cmdCancelClicked?.Invoke ( this , e ) ;
		}
		public event EventHandler<EventArgs> cmdOkClicked ;
		public event EventHandler<EventArgs> cmdNoClicked ;
		public event EventHandler<EventArgs> cmdCancelClicked ;
		public string messageText
		{
			get => textLabel.Text ;
			set => textLabel.Text = value ;
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
				Location = new Point ( Owner.Left + ( ( Owner.Width - Width ) >> 1 ) , Owner.Top + ( ( Owner.Height - Height ) >> 1 ) ) ;
			Opacity = 1.0 ;
			base.OnShown ( e ) ;
		}
		public static MessageForm ShowYesNo ( Form owner , string title , string caption , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdCancelClicked ,
									FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , 
									"  Yes  " , "" ,  "    No    " ,
									cmdOkClickedHandler , null , cmdCancelClicked , fromClosedHalder ) ;
		}
		public static MessageForm ShowYesNo ( Form owner , string title , string caption , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdCancelClicked ,
									EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , 
									"  Yes  " , "" , "    No    " ,
									cmdOkClickedHandler , null , cmdCancelClicked , null , disposedHandler ) ;
		}
		public static MessageForm ShowOKCancel ( Form owner , string title , string caption , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdCancelClicked ,
									FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , 
									"    OK    " , "" , "Cancel" ,
									cmdOkClickedHandler , null , cmdCancelClicked , fromClosedHalder ) ;
		}
		public static MessageForm ShowOKCancel ( Form owner , string title , string caption , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdCancelClicked ,
									EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , 
									"    OK    " , "" , "Cancel" ,
									cmdOkClickedHandler , null , cmdCancelClicked , null , disposedHandler ) ;
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdNoClicked , EventHandler<EventArgs> cmdCancelClicked ,
									FormClosedEventHandler fromClosedHalder )
		{
			return Show ( owner , title , caption , okButtonText , noButtonText , cancelButtonText , 
									cmdOkClickedHandler , cmdNoClicked , cmdCancelClicked ,
									fromClosedHalder , null ) ;
		
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdNoClicked ,  EventHandler<EventArgs> cmdCancelClicked ,
									EventHandler disposedHandler )
		{
			return Show ( owner , title , caption , okButtonText , noButtonText , cancelButtonText , 
									cmdOkClickedHandler , cmdNoClicked , cmdCancelClicked ,
									null , disposedHandler ) ;
		
		}
		public static MessageForm Show ( Form owner , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdNoClicked , EventHandler<EventArgs> cmdCancelClicked ,
									FormClosedEventHandler? fromClosedHalder , EventHandler? disposedHandler )
		{
			return Show ( owner , SimpleHttp.Properties.Resources.textIcon , title , caption , 
								okButtonText , noButtonText , cancelButtonText , 
							cmdOkClickedHandler , cmdNoClicked , cmdCancelClicked , fromClosedHalder , disposedHandler ) ;
		}
		public static MessageForm Show ( Form owner , Image image , string title , string caption , 
									string okButtonText , string noButtonText , string cancelButtonText , 
									EventHandler<EventArgs> cmdOkClickedHandler , EventHandler<EventArgs> cmdNoClicked , EventHandler<EventArgs> cmdCancelClicked ,
									FormClosedEventHandler? fromClosedHalder , EventHandler? disposedHandler )
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
			messageForm.cmdOkClicked += cmdOkClickedHandler ;
			messageForm.cmdNoClicked += cmdNoClicked ;
			messageForm.cmdCancelClicked += cmdCancelClicked  ;
			messageForm.okButtonText = okButtonText ;
			messageForm.cancelButtonText = cancelButtonText ;
			messageForm.noButtonText = noButtonText ;
			messageForm.Text = title ;
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
			get => messagePicture.Image ;
			set => messagePicture.Image = value ;
		}
		public void setTitleAndCaption ( string title , string caption )
		{ 
			Text = title ;
			messageText = caption ;
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
			messagePicture.Image = image ;
			setAllText ( title , caption , okButtonText , noButtonText , cancelButtonText ) ;
		}

	}
}
