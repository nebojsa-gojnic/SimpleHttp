using System ;
using System.Drawing ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Security.Cryptography.X509Certificates ;
using System.Reflection ;
using System.Net ;
using System.Text ;
using System.Net.Http ;
using System.Windows.Forms ;
using System.Net.Security;
using System.Security ;
using System.Security.Authentication ;
using System.Security.Cryptography ;
using System.Net.Sockets ;
using WebSockets ;

namespace SimpleHttp
{
	public partial class StartServerForm : Form
	{
		//Personal Information Exchange (*.pkx)|*.pkx
		protected StartServerMode _mode ;
		protected TcpListener tcpListener ;
		protected Bitmap mainLayoutBitmap ;
		protected Brush mainLayoutGrayBrush ;
		protected Brush mainLayoutWindowBrush ;
		protected Color inactiveEditBack ;
		protected Dictionary <string,Dictionary<SslProtocols,CertificateTest>> certificateTests ;
		protected CertificateTest runningTest ;
		public class PasswordPanelBackgroundState
		{
			public Rectangle passwordBounds ;
			public Rectangle siteNameBounds ;
			public bool passwordVisible ;
			public bool siteNameVisible ;
			public PasswordPanelBackgroundState ()
			{
				passwordBounds = 
				siteNameBounds = Rectangle.Empty ;
				passwordVisible = 
				siteNameVisible = false ;
			}
		}
		protected PasswordPanelBackgroundState passwordPanelBackgroundState  ;
		/// <summary>
		/// Auxiliary variable for the certificatePassword property
		/// </summary>
		protected string _certificatePassword ;
		/// <summary>
		/// Set method for the certificatePassword property
		/// </summary>
		/// <param name="value">New value for the certificatePassword property</param>
		public void setCertificatePassword ( string value ) 
		{
			tbPassword.Text = 
			_certificatePassword = value ;
		}
		/// <summary>
		/// Password for cerificate file
		/// </summary>
		public string certificatePassword 
		{
			get => _certificatePassword ;
			set => setCertificatePassword ( value ) ;
		}
		/// <summary>
		/// Auxiliary variable for the resourceAssembly property
		/// </summary>
		protected Assembly _resourceAssembly ;
		/// <summary>
		/// Set method for the resourceAssembly property
		/// </summary>
		/// <param name="value">New value for the resourceAssembly property</param>
		public void setResourceAssembly ( Assembly value ) 
		{
			_resourceAssembly = value ;
		}
		/// <summary>
		/// Selectred assembly with resources
		/// </summary>
		public Assembly resourceAssembly 
		{
			get => _resourceAssembly ;
			protected set => setResourceAssembly ( value ) ;
		}
		/// <summary>
		/// Loaded yet not accepted certificate 
		/// </summary>
		protected X509Certificate2 _loadedCertificate ;
		/// <summary>
		/// Auxiliary variable for the certificate property
		/// </summary>
		protected X509Certificate2 _certificate ;
		/// <summary>
		/// The path to the file from which the certificate is loaded.
		/// </summary>
		protected string _certificateFilePath ;
		/// <summary>
		/// Certifacte loaded with path from "certificate" text box
		/// </summary>
		/// <returns>
		/// Returns certifacte loaded with path from "certificate" text box or null
		/// </returns>
		public X509Certificate2 certificate 
		{
			get => useSsl ? _certificate : null ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateClientError property
		/// </summary>
		protected Exception _certificateClientError ;
		/// <summary>
		/// Certificate error on client ssl authentification or null
		/// </summary>
		public Exception certificateClientError 
		{
			get => _certificateClientError ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateServerError property
		/// </summary>
		protected Exception _certificateServerError ;
		/// <summary>
		/// Certificate error on server ssl authentification or null
		/// </summary>
		public Exception certificateServerError 
		{
			get => _certificateServerError ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateLoadError property
		/// </summary>
		protected Exception _certificateLoadError ;
		/// <summary>
		/// Certificate  (file) load error 
		/// </summary>
		public Exception certificateLoadError 
		{
			get => _certificateLoadError ;
		}
		/// <summary>
		/// Auxiliary variable for the assemblyPath property
		/// </summary>
		protected string _assemblyPath ;
		/// <summary>
		/// Set method for the assemblyPath property
		/// </summary>
		/// <param name="value">New value for the assemblyPath property</param>
		public void setAssemblyPath ( string value ) 
		{
			_assemblyPath = value ;
		}
		/// <summary>
		/// Password for cerificate file
		/// </summary>
		public string assemblyPath 
		{
			get => _assemblyPath ;
			set => setAssemblyPath ( value ) ;
		}
		public bool useSsl
		{
			get => cbProtocol.SelectedIndex >= 1 ;
		}
		/// <summary>
		/// Get method for the sslProtocol
		/// </summary>
		/// <returns></returns>
		public SslProtocols getSslProtocol ()
		{
			return cbProtocol.SelectedIndex == -1 ? SslProtocols.None :
				( ( EnumItem<SslProtocols> ) cbProtocol.Items [ cbProtocol.SelectedIndex ] ).value ;
		}
		public SslProtocols sslProtocol
		{
			get => getSslProtocol () ;
		}
		/// <summary>
		/// Creates new instance of StartServerForm
		/// </summary>
		public StartServerForm()
		{
			InitializeComponent() ;
			certificateTests = new Dictionary<string, Dictionary<SslProtocols, CertificateTest>> () ;

			runningTest = null ;
			passwordPanelBackgroundState = new PasswordPanelBackgroundState () ;
			_assemblyPath = "" ;
			certificatePassword = "" ;
			Color col1 = SystemColors.Window ;
			Color col2 = SystemColors.ButtonFace ;
			tbCertificate.BackColor =
			cbAssemblies.BackColor =
			tbWebroot.BackColor =
			cbProtocol.BackColor = 
			inactiveEditBack = Color.FromArgb (  255 ,
												( ( int ) col1.R + ( int ) col2.R ) >> 1 ,
												( ( int ) col1.G + ( int ) col2.G ) >> 1 ,
												( ( int ) col1.B + ( int ) col2.B ) >> 1 ) ;
			
			loadAssemblies () ;
			tcpListener = null ;
			mainLayoutBitmap = null ;
			mainLayoutGrayBrush = new SolidBrush ( Color.FromArgb ( 150 , Color.Gray ) ) ;
			mainLayoutWindowBrush = new SolidBrush ( SystemColors.Control ) ;
			ComboBox.ObjectCollection protocolItems = cbProtocol.Items ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "No security, flat HTTP" , SslProtocols.None ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "None (operating system default protocol)" , SslProtocols.None ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "Defualt (obsolete, SSL 3 and TLS 1.0)" , SslProtocols.Default ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "TLS (TLS 1.0, provided for backward compatibility)" , SslProtocols.Tls ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "TLS 1.0 (obsolete)" , SslProtocols.Tls11 ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "TLS 1.2" , SslProtocols.Tls12 ) ) ;
			protocolItems.Add ( new EnumItem<SslProtocols> ( "TLS 1.3" , SslProtocols.Tls13 ) ) ;
			cbProtocol.SelectedIndex = 0 ;
			cbProtocol.SelectionLength = 0 ;
			//gbPassword.Location = new Point ( - gbPassword.Width , - gbPassword.Height ) ;
		}
		/// <summary>
		/// This method set (again)location and then calls base method(to raise Shown event)
		/// </summary>
		/// <param name="e">(EventArgs)</param>
		protected override void OnShown ( EventArgs e )
		{
			BeginInvoke ( setLocation ) ;
			gbCertificate_Resize ( this , e ) ;
			base.OnShown ( e ) ;
		}
		/// <summary>
		/// This method set mode and location and then calls base method(to raise HandleCreated event)
		/// </summary>
		/// <param name="e">(EventArgs)</param>
		protected override void OnHandleCreated ( EventArgs e )
		{
			_mode = StartServerMode.resourceServer;
			mode = StartServerMode.fileServer ;
			setLocation () ;
			base.OnHandleCreated(e) ;
		}
		/// <summary>
		/// Set location(in center of owner if any)
		/// </summary>
		private void setLocation ()
		{
			if ( Owner != null )
				Location = new Point ( Owner.Left + ( ( Owner.Width - Width ) >> 1 ) ,
									   Owner.Top + ( ( Owner.Height - Height ) >> 1 ) ) ;
		}
		/// <summary>
		/// Set method for the Mode property
		/// </summary>
		/// <param name="value">New value for the Mode property</param>
		protected void setMode ( StartServerMode value ) 
		{
			if ( _mode == value ) return ;
			_mode = value ;
			if ( _mode == StartServerMode.fileServer )
			{
				cmdFileMode.BackColor = SystemColors.Window ;
				cmdResourceMode.BackColor = SystemColors.ButtonFace ;
				gbAssemblies.Visible = false ;
				gbFilePath.Visible = true ;
				checkFolderSelection ( false , false ) ;
			}
			else
			{
				cmdResourceMode.BackColor = SystemColors.Window ;
				cmdFileMode.BackColor = SystemColors.ButtonFace ;
				gbAssemblies.Visible = true ;
				gbFilePath.Visible = false ;
				cbAssemblies_SelectedIndexChanged ( cbAssemblies , new EventArgs () ) ;
			}
		}
		/// <summary>
		/// Server start mode(file system or resource assemly)
		/// </summary>
		public StartServerMode mode 
		{ 
			get => _mode ; 
			set => setMode ( value ) ;
		}
		/// <summary>
		/// Disk folder path where webroot is
		/// </summary>
		public string webroot 
		{
			get => tbWebroot.Text ;
			set => tbWebroot.Text = value ;
		}
		/// <summary>
		/// Get method for Port poperty
		/// </summary>
		/// <returns>Returns number from "Port" text box or zero(if not valid numeric input)</returns>
		protected int getPort ()
		{
			int p ;
			return int.TryParse ( tbPort.Text.Trim () , out p ) ? p : 80 ;
		}
		/// <summary>
		/// Returns number from "Port" text box or zero(if not valid numeric input)
		/// </summary>
		public int port
		{
			get => getPort () ;
		}
		
		/// <summary>
		/// When user click "Resource based server" button
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdResourceMode_Click ( object sender , EventArgs e )
		{
			mode = StartServerMode.resourceServer ;
		}
		/// <summary>
		/// When user click "Filebased server" button
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdFileMode_Click ( object sender , EventArgs e )
		{
			mode = StartServerMode.fileServer ;
		}
		/// <summary>
		/// When user change value of the port text box this event handler calls checkPort method
		/// </summary>
		/// <param name="sender">(TextBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void tbPort_TextChanged ( object sender, EventArgs e )
		{
			checkPort ( false ) ;
		}
		/// <summary>
		/// Checks if the port value specified in port text box is valid.
		/// </summary>
		/// <param name="raiseEvents">When this parameter is true and the port value is invalid, invalidPortNumber event is raised</param>
		/// <returns>Return true if port value is valid, otherwise false</returns>
		private bool checkPort ( bool raiseEvents )
		{
			int i ;
			if ( int.TryParse ( tbPort.Text.Trim() , out i ) )
				if ( ( i < 0 ) || ( i > 65535 ) )
				{
					tbPort.BackColor = Color.MistyRose ;
					if ( raiseEvents ) _invalidPortNumber?.Invoke ( this , new ErrorEventArgs ( new ApplicationException ( "Invalid port number value(" + i.ToString() + "), allowed range is 1-65535" ) ) ) ;
				}
				else 
				{
					tbPort.BackColor = SystemColors.Window ;
					return true ;
				}
			else 
			{
				tbPort.BackColor = Color.MistyRose ;
				if ( raiseEvents )  _invalidPortNumber?.Invoke ( this , new ErrorEventArgs ( new ApplicationException ( "Invalid text for port number, \"" + tbPort.Text.Trim() + "\" cannot be converted to number" ) ) ) ;
			}
			return false ;
		}
		/// <summary>
		/// This event handler opens folder dialog for user to choose webroot path.
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdSelectPath_Click ( object sender, EventArgs e )
        {
			folders.RootFolder = Environment.SpecialFolder.MyComputer ;
			folders.SelectedPath = tbWebroot.Text ;
			openFileDialogFileOk = false ;
			folders.ShowDialog ( this ) ;
        }
		/// <summary>
		/// This event handler opens file dialog to for user to choose certificate file
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdSelectCertificate_Click ( object sender, EventArgs e )
		{
			openCertificateDialog.FileName = tbCertificate.Text ;
			openFileDialogFileOk = false ;
			openCertificateDialog.ShowDialog () ;
			if ( openFileDialogFileOk )
			{
				tbCertificate.Text = openCertificateDialog.FileName ;
				showCertificatePassword () ;
			}
		}
		/// <summary>
		/// Some resizing ...
		/// </summary>
		/// <param name="sender">(Panel)</param>
		/// <param name="e">(EventArgs)</param>
		private void gbCertificate_Resize ( object sender , EventArgs e )
		{
			int w = tbWebroot.Height * 5 / 4 ;
			cmdSelectCertificate.Left = 
			cmdSelectPath.Left = 
			cmdSelectCertificate.Left = gbCertificate.Width - tbCertificate.Left + 1 ;
			cmdLoadAssembly.Bounds =
			cmdSelectCertificate.Bounds =
			cmdSelectPath.Bounds = new Rectangle ( tbCertificate.Right - w , tbCertificate.Top , w , tbCertificate.Height ) ;
			
			int ss = cbAssemblies.SelectionStart ;
			int sl = cbAssemblies.SelectionLength ;
			cbAssemblies.Width = cmdSelectCertificate.Left - tbCertificate.Left ;	
			cbAssemblies.SelectionStart = ss ;
			cbAssemblies.SelectionLength = sl ;

			ss = tbWebroot.SelectionStart ;
			sl = tbWebroot.SelectionLength ;
			tbWebroot.Width = cbAssemblies.Width ;
			tbWebroot.SelectionStart = ss ;
			tbWebroot.SelectionLength = sl ;
			
			ss = tbCertificate.SelectionStart ;
			sl = tbCertificate.SelectionLength ;
			tbCertificate.Width = cbAssemblies.Width ;		
			tbCertificate.SelectionStart = ss ;
			tbCertificate.SelectionLength = sl ;

			ss = cbProtocol.SelectionStart ;
			sl = cbProtocol.SelectionLength ;
			cbProtocol.Width = cmdSelectCertificate.Right - tbCertificate.Left - 1 ;			
			cbProtocol.SelectionStart = ss ;
			cbProtocol.SelectionLength = sl ;
			gbPassword.Size = gbAssemblies.Size ;
			
			gbSiteName.Width = gbAssemblies.Width ;
			gbPassword.Left =
			gbSiteName.Left = gbAssemblies.Left ;

		}
		/// <summary>
		/// Some resizing ...
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdSelectFolder_Resize ( object sender , EventArgs e )
		{
			Region oldRegion = cmdSelectPath.Region ;
			Region newRegion = new Region ( new Rectangle ( 1 , 1 , cmdSelectPath.Width - 2 , cmdSelectPath.Height - 2 ) ) ;
			cmdSelectPath.Region = newRegion ;
			try
			{ 
				if ( oldRegion != null ) oldRegion.Dispose () ;
			}
			catch { }
		}
		private void tbPort_KeyPress ( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar >= '0' && e.KeyChar <= '9' )
			{ }
			else if ( e.KeyChar == '\b' )
			{ }
			else e.Handled = true ;
		}
		/// <summary>
		/// Load assemblies visible in current application domain
		/// </summary>
		public void loadAssemblies ()
		{
			cbAssemblies.Items.Clear () ;
			cbAssemblies.Sorted = false ;
			//cbAssemblies.Items.Add ( "<load from file system>" ) ;
			foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies () )
				cbAssemblies.Items.Add ( new AssemblyItem ( assembly ) ) ;
			cbAssemblies.Sorted = true ;
			//int c = cbAssemblies.Items.Count ;
			//object [] items = new object [ c ] ;
			//cbAssemblies.Items.CopyTo ( items , 0 ) ;
			//cbAssemblies.Items.Clear () ;
			cbAssemblies.Sorted = false ;
		}
		//public static IEnumerable<Assembly> GetAllAssemblies()
		//{
		//	List<string> list = new List<string>();
		//	Stack<Assembly> stack = new Stack<Assembly>();

		//	stack.Push ( Assembly.GetEntryAssembly () ) ;

		//	do
		//	{
		//		Assembly assembly = stack.Pop() ;

		//		yield return assembly ;

		//		foreach ( AssemblyName reference in assembly.GetReferencedAssemblies() )
		//			if ( !list.Contains ( reference.FullName ) )
		//				try
		//				{
		//					stack.Push ( Assembly.Load ( reference ) ) ;
		//					list.Add ( reference.FullName ) ;
		//				}
		//				catch { }

		//	}
		//	while ( stack.Count > 0 ) ;

		//}
		/// <summary>
		/// Get method for the certficateIsValid property
		/// </summary>
		/// <returns>Returns true if certificate is existing and valid</returns>
		protected bool getCertficateIsValid ()
		{
			return ( _certificateLoadError == null ) && ( _certificateClientError == null )
				&& ( _certificateServerError == null ) && ( _certificate != null ) ;
		}
		[Flags]
		public enum CerrtificateState
		{
			none = 0 ,
			notTested = 1 ,
			loaded = 2 ,
			error = 4 ,
			valid = 127 ,
			badMask = 7
		}
		public CerrtificateState getCerrtificateState ()
		{
			if ( !useSsl ) return CerrtificateState.none ;
			if ( _certificateFilePath != tbCertificate.Text ) return CerrtificateState.notTested ;
			if ( ( _certificateLoadError != null ) || 
				 ( _certificateClientError != null ) ||
				 ( _certificateServerError != null ) ) return CerrtificateState.error ;
			return _certificate == null ? 
					 _loadedCertificate == null ? 
						CerrtificateState.notTested : CerrtificateState.loaded :
					 CerrtificateState.valid ;
		}
		/// <summary>
		/// Returns true if certificate is existing and valid
		/// </summary>
		public bool certficateIsValid
		{
			get => getCertficateIsValid () ;
		}
		protected bool checkCertificate ( bool raiseEvents , bool focusErrorControl )
		{
			if ( useSsl )
				switch ( getCerrtificateState () )
				{
					case CerrtificateState.loaded :
						tbCertificate.BackColor = tbCertificate.Focused ? SystemColors.Window : SystemColors.Info ;		
						if ( raiseEvents ) 
							showCertificatePassword () ;
					return false ;
					case CerrtificateState.notTested :
						tbCertificate.BackColor = SystemColors.Info ;
						if ( focusErrorControl ) tbCertificate.Focus () ;
						if ( raiseEvents ) 
							if ( File.Exists ( tbCertificate.Text ) )
								showCertificatePassword () ;
							else _certificateLoadFailure?.Invoke ( this , new ErrorEventArgs ( _certificateLoadError = new IOException ( "File not found:\r\n" + tbCertificate.Text  ) ) ) ;
					return false ;
					case CerrtificateState.error :
						tbCertificate.BackColor = Color.MistyRose ;
						if ( focusErrorControl ) tbCertificate.Focus () ;
						if ( raiseEvents )
						{
							showCertificatePassword () ;
							if ( _certificateLoadError == null )
							{ 
								if ( _certificateClientError != null )
									_certificateFailedOnClient?.Invoke ( this , new ErrorEventArgs ( _certificateClientError ) ) ; 
								if ( _certificateServerError != null )
									_certificateFailedOnServer?.Invoke ( this , new ErrorEventArgs ( _certificateServerError ) ) ; 
							}
							else 
								_certificateLoadFailure?.Invoke ( this , new ErrorEventArgs ( _certificateLoadError ) ) ;
						}
					return false ;
				}
			tbCertificate.BackColor = tbCertificate.Focused ? SystemColors.Window : inactiveEditBack ;		
			return true ;
		}
		protected bool validateValues ( bool raiseEvents , bool focusErrorControl )
		{
			if ( !checkCertificate ( true , true ) ) return false ;
			if ( mode == StartServerMode.fileServer )
				if ( !checkFolderSelection ( raiseEvents , focusErrorControl ) ) return false ;
			return checkPort ( raiseEvents ) ;
		}
		private void cmdStart_Click ( object sender , EventArgs e )
		{
			if ( validateValues ( true , true ) )
				( mode == StartServerMode.fileServer ? _fileServerChoosen : _resourceServerChoosen )?.Invoke ( this , e ) ;
		}
		public static void setSelection ( ComboBox control , int oldSelectionStart , string oldText )
		{
			int s = matchCount ( oldText , control.Text ) ;
			control.SelectionStart = s < oldSelectionStart ? s : oldSelectionStart ;
			control.SelectionLength = control.SelectionStart == 0 ? 0 : control.Text.Length - control.SelectionStart ;
		}
		private void cbAssemblies_KeyDown ( object sender , KeyEventArgs e )
		{
			string oldText ;
			int oldSelectionStart ;
			switch ( e.KeyCode )
			{
				case Keys.Escape:
					cbAssemblies.DroppedDown = false ;
				break ;
				case Keys.Left :
					if ( !e.Control )
						if ( cbAssemblies.SelectionStart + cbAssemblies.SelectionLength == cbAssemblies.Text.Length )
						{
							if ( cbAssemblies.SelectionStart > 0 )
							{
								cbAssemblies.SelectionStart-- ;
								cbAssemblies.SelectionLength = cbAssemblies.Text.Length - cbAssemblies.SelectionStart ;
								e.Handled = true ;
							}
						}
				break ;
				case Keys.Right :
					if ( !e.Control )
						if ( cbAssemblies.SelectionStart + cbAssemblies.SelectionLength == cbAssemblies.Text.Length )
						{
							if ( cbAssemblies.SelectionStart < cbAssemblies.Text.Length - 1 )
							{
								cbAssemblies.SelectionStart++ ;
								cbAssemblies.SelectionLength = cbAssemblies.Text.Length - cbAssemblies.SelectionStart ;
								e.Handled = true ;
							}
						}
				break ;
				case Keys.Up :
					if ( cbAssemblies.SelectedIndex > 0 ) 
					{
						e.Handled = true ;
						oldText = cbAssemblies.Text ;
						oldSelectionStart = cbAssemblies.SelectionStart ;
						cbAssemblies.SelectedIndex-- ;
						setSelection ( cbAssemblies , oldSelectionStart , oldText ) ;
					}
				break ;
				case Keys.Down :
					if ( cbAssemblies.SelectedIndex < cbAssemblies.Items.Count - 1 )
					{
						e.Handled = true ;
						oldText = cbAssemblies.Text ;
						oldSelectionStart = cbAssemblies.SelectionStart ;
						cbAssemblies.SelectedIndex++ ;
						setSelection ( cbAssemblies , oldSelectionStart , oldText ) ;
					}
				break ;
			}
		}
		private void cbAssemblies_KeyPress ( object sender, KeyPressEventArgs e )
		{
			e.Handled = true ;
			if ( ( e.KeyChar == '<' ) || ( e.KeyChar == '>' ) ) return ;
			string newText = cbAssemblies.Text ;
			int selectionStart = cbAssemblies.SelectionStart ;
				
			if ( e.KeyChar == '\b' ) 
			{
				if ( cbAssemblies.SelectionLength == 0 ) 
				{
					if ( selectionStart > 0 ) newText = newText.Substring ( 0 , --selectionStart );
				}
				else if ( cbAssemblies.SelectionStart + cbAssemblies.SelectionLength == cbAssemblies.Text.Length ) 
				{
					if ( cbAssemblies.SelectionStart > 0 )
					{
						cbAssemblies.SelectionStart-- ; 
						cbAssemblies.SelectionLength = cbAssemblies.Text.Length - cbAssemblies.SelectionStart ;
					}
				}
			}
			else 
			{
				newText = ( selectionStart == 0 ? "" : newText.Substring ( 0 , selectionStart ) ) +
					( ( e.KeyChar == '\b' ?  "" : e.KeyChar ) + newText.Substring ( selectionStart + cbAssemblies.SelectionLength ) ) ;
				selectionStart += ( e.KeyChar == '\b' ? 0 : 1 ) ;
			}
			if ( newText != cbAssemblies.Text )
			{
				int s = cbAssemblies.SelectionStart ;
				int matchCount ;
				int i = searchForAssembly ( newText , out matchCount ) ;
				if ( i != -1 )
				{
					cbAssemblies.SelectedIndex = i ; 
					//cbAssemblies.Text = newText ;
					cbAssemblies.SelectionStart = matchCount ;
					cbAssemblies.SelectionLength = cbAssemblies.Text.Length - matchCount ;
				}
				//cbAssemblies.Text = newText ;
				
			}
		}
		public int searchForAssembly ( string newText , out int matchCount )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			matchCount = 0 ;
			int c = items.Count ;
			int position = -1 ;
			newText = newText.ToLower () ;
			for ( int i = 0 ; i < c ; i++ )
			{
				int mc = StartServerForm.matchCount ( newText , ( ( AssemblyItem )  items [ i ] ).lowCaseName ) ;
				if ( mc > matchCount )
				{
					position = i ;
					matchCount = mc ;
				}
			}
			return position ;
		}
		private void cbProtocol_KeyDown ( object sender , KeyEventArgs e )
		{
			string oldText ;
			int oldSelectionStart ;
			switch ( e.KeyCode )
			{
				case Keys.Escape:
					cbProtocol.DroppedDown = false ;
				break ;
				case Keys.Left :
					if ( !e.Control )
						if ( cbProtocol.SelectionStart + cbProtocol.SelectionLength == cbProtocol.Text.Length )
						{
							if ( cbProtocol.SelectionStart > 0 )
							{
								cbProtocol.SelectionStart-- ;
								cbProtocol.SelectionLength = cbProtocol.Text.Length - cbProtocol.SelectionStart ;
								e.Handled = true ;
							}
						}
				break ;
				case Keys.Right :
					if ( !e.Control )
						if ( cbProtocol.SelectionStart + cbProtocol.SelectionLength == cbProtocol.Text.Length )
						{
							if ( cbProtocol.SelectionStart < cbProtocol.Text.Length - 1 )
							{
								cbProtocol.SelectionStart++ ;
								cbProtocol.SelectionLength = cbProtocol.Text.Length - cbProtocol.SelectionStart ;
								e.Handled = true ;
							}
						}
				break ;
				case Keys.Up :
					if ( cbProtocol.SelectedIndex > 0 ) 
					{
						e.Handled = true ;
						oldText = cbProtocol.Text ;
						oldSelectionStart = cbProtocol.SelectionStart ;
						cbProtocol.SelectedIndex-- ;
						setSelection ( cbProtocol , oldSelectionStart , oldText ) ;
					}
				break ;
				case Keys.Down :
					if ( cbProtocol.SelectedIndex < cbProtocol.Items.Count - 1 )
					{
						e.Handled = true ;
						oldText = cbProtocol.Text ;
						oldSelectionStart = cbProtocol.SelectionStart ;
						cbProtocol.SelectedIndex++ ;
						setSelection ( cbProtocol , oldSelectionStart , oldText ) ;
					}
				break ;
			}
		}
		private void cbProtocol_KeyPress ( object sender, KeyPressEventArgs e )
		{
			e.Handled = true ;
			if ( ( e.KeyChar == '<' ) || ( e.KeyChar == '>' ) ) return ;
			string newText = cbProtocol.Text ;
			int selectionStart = cbProtocol.SelectionStart ;
				
			if ( e.KeyChar == '\b' ) 
			{
				if ( cbProtocol.SelectionLength == 0 ) 
				{
					if ( selectionStart > 0 ) newText = newText.Substring ( 0 , --selectionStart );
				}
				else if ( cbProtocol.SelectionStart + cbProtocol.SelectionLength == cbProtocol.Text.Length ) 
				{
					if ( cbProtocol.SelectionStart > 0 )
					{
						cbProtocol.SelectionStart-- ; 
						cbProtocol.SelectionLength = cbProtocol.Text.Length - cbProtocol.SelectionStart ;
					}
				}
			}
			else 
			{
				newText = ( selectionStart == 0 ? "" : newText.Substring ( 0 , selectionStart ) ) +
					( ( e.KeyChar == '\b' ?  "" : e.KeyChar ) + newText.Substring ( selectionStart + cbProtocol.SelectionLength ) ) ;
				selectionStart += ( e.KeyChar == '\b' ? 0 : 1 ) ;
			}
			if ( newText != cbProtocol.Text )
			{
				int s = cbProtocol.SelectionStart ;
				int matchCount ;
				int i = searchForProtocol ( newText , out matchCount ) ;
				if ( i != -1 )
				{
					cbProtocol.SelectedIndex = i ; 
					//cbProtocol.Text = newText ;
					cbProtocol.SelectionStart = matchCount ;
					cbProtocol.SelectionLength = cbProtocol.Text.Length - matchCount ;
				}
				//cbProtocol.Text = newText ;
				
			}
		}
		public int searchForProtocol ( string newText , out int matchCount )
		{
			ComboBox.ObjectCollection items = cbProtocol.Items ;
			matchCount = 0 ;
			int c = items.Count ;
			int position = -1 ;
			newText = newText.ToLower () ;
			for ( int i = 0 ; i < c ; i++ )
			{
				int mc = StartServerForm.matchCount ( newText , items [ i ].ToString().ToLower() ) ;
				if ( mc > matchCount )
				{
					position = i ;
					matchCount = mc ;
				}
			}
			return position ;
		}
		public static int matchCount ( string search , string source )
		{
			int c = Math.Min ( search.Length , source.Length ) ;
			for ( int i = 0 ; i < c ; i++ )
				if ( search [ i ] != source [ i ] ) return i ;
			return c ;
		}
		public static X509Certificate2 GenerateSelfSignedCertificate()
		{
			string secp256r1Oid = "1.2.840.10045.3.1.7";  //oid for prime256v1(7)  other identifier: secp256r1
        
			//string subjectName = "Self-Signed-Cert-Example";

			var ecdsa = ECDsa.Create ( ECCurve.CreateFromValue(secp256r1Oid ) );

			var certRequest = new CertificateRequest ( "CN=localhost" , ecdsa , HashAlgorithmName.SHA256 ) ;

			//add extensions to the request (just as an example)
			//add keyUsage
			certRequest.CertificateExtensions.Add ( new X509KeyUsageExtension ( X509KeyUsageFlags.DigitalSignature , true ) ) ;

			// generate the cert and sign
			X509Certificate2 generatedCert = certRequest.CreateSelfSigned ( DateTimeOffset.Now.AddDays ( -1 ) , DateTimeOffset.Now.AddYears ( 10 ) ) ; 

			//has to be turned into pfx or Windows at least throws a security credentials not found during sslStream.connectAsClient or HttpClient request...
			X509Certificate2 pfxGeneratedCert = new X509Certificate2 ( generatedCert.Export ( X509ContentType.Pfx ) ) ; 
			generatedCert.Dispose () ;
			return pfxGeneratedCert ;
		}
		protected void onCertificateFailedOnServer ( CertificateTest certificateTest , ErrorEventArgs e )
		{
			_certificate = null ;
			_certificateServerError = e.GetException() ;
			if ( _certificateServerError.InnerException != null ) _certificateServerError = _certificateServerError.InnerException ;
			tbCertificate.BackColor = Color.MistyRose ;
			_certificateFailedOnServer?.Invoke ( this , e ) ;
			passwordPanel.Enabled = true ;
			UseWaitCursor = false ;
			addCertificateTest ( certificateTest ) ;

		}
		protected void onCertificateFailedOnClient ( CertificateTest certificateTest , ErrorEventArgs e )
		{
			UseWaitCursor = false ;
			passwordPanel.Enabled = true ;
			_certificate = null ;
			_certificateClientError = e.GetException() ;
			tbCertificate.BackColor = Color.MistyRose ;
			if ( _certificateClientError.InnerException != null ) _certificateClientError = _certificateClientError.InnerException ;
			addCertificateTest ( certificateTest ) ;
			_certificateFailedOnClient?.Invoke ( this , e ) ; ;
		}
		protected void onOpenTcpTestFailed ( CertificateTest certificateTest , ErrorEventArgs e )
		{
			passwordPanel.Enabled = true ;
			UseWaitCursor = false ;
			tbCertificate.BackColor = Color.LightSalmon ;
			addCertificateTest ( certificateTest ) ;
			_openTcpTestFailed?.Invoke ( this , e ) ;
		}
		/// <summary>
		/// This is invoked on main thread when SSL authethification pass client conncection test.
		/// It checks values of both _certificateClientError and _certificateServerError variables in order to set cetfiticate and visuals.
		/// If any of these variable values is null then
		/// </summary>
		/// <param name="certificateTest">CertifiacteTest instance with all relevant data</param>
		protected void acceptCertificate ( CertificateTest certificateTest )
		{
			addCertificateTest ( certificateTest ) ;
			UseWaitCursor = false ;
			passwordPanel.Enabled = true ;				
			passwordPanel.Visible = false ;				
			_certificate = certificateTest.certificate ;
			_certificateFilePath = certificateTest.source ;
			_certificateLoadError = certificateTest.certificateLoadError ;
			_certificateClientError = certificateTest.certificateClientError ;
			_certificateServerError = certificateTest.certificateServerError ;
			tbCertificate.BackColor = SystemColors.Window ;
			_certificateAccepted?.Invoke ( this , certificate ) ;
		}
		/// <summary>
		/// Add CertificateTest instance into certificateTests dictionary
		/// </summary>
		/// <param name="certificateTest">CertificateTest instance to add into certificateTests dictionary</param>
		protected void addCertificateTest ( CertificateTest certificateTest )
		{
			string s = certificateTest.source.Trim().ToLower() ;
			Dictionary<SslProtocols,CertificateTest> testsByProtocol ;
			if ( certificateTests.ContainsKey ( s ) )
			{
				testsByProtocol = certificateTests [ s ] ;
				if ( testsByProtocol.ContainsKey ( certificateTest.sslProtocol ) )
				{
					CertificateTest oldTest = testsByProtocol [ certificateTest.sslProtocol ] ;
					if ( oldTest != certificateTest )			//!!!!!
					{
						testsByProtocol [ certificateTest.sslProtocol ].Dispose () ;
						testsByProtocol [ certificateTest.sslProtocol ] = certificateTest ;
					}
				}
				else testsByProtocol.Add ( certificateTest.sslProtocol , certificateTest ) ;
			}
			else 
			{
				testsByProtocol= new Dictionary<SslProtocols, CertificateTest> ( 3 ) ;
				testsByProtocol.Add ( certificateTest.sslProtocol , certificateTest ) ;
				certificateTests.Add ( s , testsByProtocol ) ;
			}
		}
		/// <summary>
		/// Show password text box
		/// </summary>
		private void showCertificatePassword ()
		{
			_loadedCertificate = null ;
			gbPassword.Visible = true ;
			gbSiteName.Visible = false ;
			setCertificatePasswordBackground () ;
			BeginInvoke ( () =>
			{
				if ( IsDisposed ) return ;
				if ( Form.ActiveForm == this ) tbPassword.Focus () ;
			} ) ;
		}

		/// <summary>
		/// This method tries to load certificate and connect over SSL with it.
		/// </summary>
		private void setCertificatePasswordBackground ()
		{
			if ( mainLayoutBitmap != null )
				if ( ( mainLayoutBitmap.Width != mainLayout.Width ) || ( mainLayoutBitmap.Height != mainLayout.Height ) 
					|| ( passwordPanelBackgroundState.passwordVisible != gbPassword.Visible )
					|| ( passwordPanelBackgroundState.siteNameVisible != gbSiteName.Visible )
					|| ( !passwordPanelBackgroundState.passwordBounds.Equals ( gbPassword.Bounds ) )
					|| ( !passwordPanelBackgroundState.siteNameBounds.Equals ( gbSiteName.Bounds ) ) )
				{
					mainLayoutBitmap.Dispose () ;
					mainLayoutBitmap = null ;
				}
			if ( mainLayoutBitmap == null ) mainLayoutBitmap = new Bitmap ( mainLayout.Width , mainLayout.Height ) ;
			mainLayout.DrawToBitmap ( mainLayoutBitmap , new Rectangle ( Point.Empty , mainLayout.Size ) ) ;

			passwordPanelBackgroundState.passwordVisible = gbPassword.Visible ;
			passwordPanelBackgroundState.siteNameVisible = gbSiteName.Visible ;
			passwordPanelBackgroundState.passwordBounds = gbPassword.Bounds ;
			passwordPanelBackgroundState.siteNameBounds = gbSiteName.Bounds ;

			drawPasswordPanelBackground ( gbSiteName.Visible ? gbSiteName.Bounds : gbPassword.Bounds ) ;
			passwordPanel.BackgroundImageLayout = ImageLayout.None ;
			passwordPanel.BackgroundImage = mainLayoutBitmap ;
			try
			{
				passwordPanel.Visible = true ;
				passwordPanel.BringToFront () ;
			}
			catch { }
		}
		private void drawPasswordPanelBackground ( Rectangle panelBounds )
		{
			Rectangle rect = new Rectangle ( Point.Empty , mainLayout.Size ) ;
			using ( Graphics graphics = Graphics.FromImage ( mainLayoutBitmap ) )
			{
				graphics.FillRectangle ( mainLayoutGrayBrush , rect ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , 0 , mainLayout.Width , panelBounds.Top - 2 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , panelBounds.Top - 2 , panelBounds.Left - 4 , panelBounds.Height + 6 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , panelBounds.Bottom + 4 , mainLayout.Width , mainLayout.Height - panelBounds.Bottom - 4 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( panelBounds.Right + 4 , panelBounds.Top - 2 , mainLayout.Width - panelBounds.Right + 4 , panelBounds.Height + 6  ) ) ;
				
				//graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 4 , panelBounds.Top - 2 , panelBounds.Width + 8 , panelBounds.Height + 6 ) ) ;

				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 5 , panelBounds.Top - 3 , panelBounds.Width + 10 , panelBounds.Height + 7 ) ) ;

				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 6 , panelBounds.Top - 2 , 1 , panelBounds.Height + 5 ) ) ;
				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Right + 5 , panelBounds.Top - 2 , 1 , panelBounds.Height + 5 ) ) ;
				
			}
		}
		private void passwordPanel_Resize ( object sender , EventArgs e )
		{
			gbPassword.Location = new Point ( ( passwordPanel.Width - gbPassword.Width ) >> 1 , gbCertificate.Bottom ) ;
			gbSiteName.Location = new Point ( ( passwordPanel.Width - gbSiteName.Width ) >> 1 , gbCertificate.Bottom ) ;
			if ( gbSiteName.Bottom > passwordPanel.Height - 20 )
				gbSiteName.Top = gbSiteName.Top - gbSiteName.Bottom + passwordPanel.Height - 20 ;
			if ( passwordPanel.Visible ) setCertificatePasswordBackground () ;
		}
		private void passwordPanel_Click ( object sender, EventArgs e )
		{
			passwordPanel.Visible = false ;
		}
		private void cmdAcceptPassword_Click ( object sender, EventArgs e )
		{
			_loadedCertificate = null ;
			_certificateLoadError = null ;
			_certificateClientError = null ;
			_certificateServerError = null ;
			try
			{ 
				runningTest = new CertificateTest ( tbCertificate.Text , tbPassword.Text , sslProtocol , port, "localhost" ) ;
				runningTest.certificateFailedOnClient += certificateTest_certificateFailedOnClient ;
				runningTest.certificateFailedOnServer += certificateTest_certificateFailedOnServer ;
				runningTest.certificateLoadFailed += certificateTest_certificateLoadFailed ;
				runningTest.openTcpTestFailed += certificateTest_openTcpTestFailed ;
				runningTest.certificateAccepted += certificateTest_certificateAccepted ;
				runningTest.certificateLoaded += certificateTest_certificateLoaded ;
				runningTest.loadCertifiacte () ;
				UseWaitCursor = true ;
				passwordPanel.Enabled = false ;
				/*
				_loadedCertificate = new X509Certificate2 ( tbCertificate.Text , tbPassword.Text ) ;
				startSslComunication ( _loadedCertificate , tbCertificate.Text ) ;
				*/
			}
			catch ( Exception x )
			{
				_certificateLoadError = x ;
				UseWaitCursor = false ;
				passwordPanel.Enabled = true ;
			}
			if ( _certificateLoadError != null ) 
			{
				_certificateLoadFailure?.Invoke ( this , new ErrorEventArgs ( _certificateLoadError ) ) ;
				if ( certificate != null ) certificate.Dispose () ;
			}
		}


		private void certificateTest_certificateFailedOnClient ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( onCertificateFailedOnClient , new object [ 2 ] { sender , e } ) ;
		}

		private void certificateTest_certificateFailedOnServer ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( onCertificateFailedOnServer , new object [ 2 ] { sender , e } ) ;
		}

		private void certificateTest_openTcpTestFailed ( object? sender , ErrorEventArgs e )
		{
			BeginInvoke ( onOpenTcpTestFailed , new object [ 2 ] { sender , e } ) ;
		}
		
		private void certificateTest_certificateLoaded ( object? sender , CertificateSource e )
		{
			BeginInvoke ( () =>
			{
				passwordPanel.Enabled = true ;
				UseWaitCursor = false ;
				gbPassword.Visible = false ;
				gbSiteName.Visible = true ;
				setCertificatePasswordBackground () ;
				_loadedCertificate = e.certificate ;
				
				if ( tbSiteName.Text == runningTest.siteName )
					tbSiteName_TextChanged ( tbSiteName , new EventArgs () ) ;
				else tbSiteName.Text = runningTest.siteName ;

				tbSiteName.Focus () ;
			} ) ;
		}
		private void cmdStartCertificateTest_Click ( object sender, EventArgs e)
		{
			try
			{
				runningTest.siteName = tbSiteName.Text.Trim () ;
				runningTest.testCertifiate () ;
				UseWaitCursor = true ;
				passwordPanel.Enabled = false ;
			}
			catch ( Exception x )
			{ 
				onOpenTcpTestFailed ( runningTest , new ErrorEventArgs ( x ) ) ;
			}
		}
		/// <summary>
		/// This event handler reacts when CertificateTest instance accepts certificate
		/// </summary>
		/// <param name="sender">CertificateTest instance</param>
		/// <param name="e">(EventArgs)</param>
		private void certificateTest_certificateAccepted ( object? sender , EventArgs e )
		{
			BeginInvoke ( () =>
			{
				acceptCertificate ( ( CertificateTest ) sender ) ;
			} ) ;
		}
		/// <summary>
		/// This event handler reacts when CertificateTest instance cannot load certificate file
		/// </summary>
		/// <param name="sender">CertificateTest instance</param>
		/// <param name="e">ErrorEventArgs instance, call GetException() method to get exception</param>
		private void certificateTest_certificateLoadFailed ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( () =>
			{
				UseWaitCursor = false ;
				passwordPanel.Enabled = true ;
				addCertificateTest ( ( CertificateTest ) sender ) ;
				_certificateLoadFailure?.Invoke ( this , e ) ;
			} ) ;			
		}
		/// <summary>
		/// When user press Cancel button on password or site name input
		/// </summary>
		/// <param name="sender">Button instance</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdCancelSslTest_Click ( object sender , EventArgs e )
		{
			passwordPanel.Visible = false ;
		}
		

		
		/// <summary>
		/// This method checks if folder specified in tbWebroot(TextBox) is exisitng 
		/// and set(enables/disables) cmdStart button if raiseEvent flag us up
		/// </summary>
		/// <param name="raiseEvent">When this is true and webroot folder is bad, invalidWebrootFolder event is triggered </param>
		private bool checkFolderSelection ( bool raiseEvent , bool focusOnError )
		{
			if ( Directory.Exists ( tbWebroot.Text ) )
			{
				tbWebroot.BackColor = SystemColors.Window ;
				return true ;
			}
			else 
			{
				tbWebroot.BackColor = Color.MistyRose ; 
				if ( focusOnError ) tbWebroot.Focus () ;
				if ( raiseEvent ) _invalidWebrootFolder?.Invoke ( this , tbWebroot.Text ); ;
				return false ;
			}
		}
		/// <summary>
		/// When user press button near assemblies combo box this method handles click event
		/// and opens file dialog.
		/// </summary>
		/// <param name="sender">Button instance</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdLoadAssembly_Click ( object sender , EventArgs e )
		{
			openFileDialogFileOk = false ;
			if ( _assemblyPath != "" ) openAssemblyDialog.FileName = _assemblyPath ;
			openAssemblyDialog.ShowDialog () ;
			if ( openFileDialogFileOk )
				try
				{
					insertLoadedAssembly ( new AssemblyItem ( _assemblyPath = openAssemblyDialog.FileName ) ) ;
					return ;
				}
				catch ( Exception x )
				{
					_assemblyLoadError?.Invoke ( this, new ErrorEventArgs ( x ) ) ;
				}
		}
		/// <summary>
		/// Inserts new Assmebly loaded from disk
		/// </summary>
		/// <param name="newItem">AssemblyItem instance with Assembly</param>
		protected void insertLoadedAssembly ( AssemblyItem newItem )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			string assemblyName = newItem.ToString () ;
			int c = items.Count ;
			Assembly assembly = newItem.assembly ;
			for ( int i = 0 ; i < c ; i++ )
			{
				AssemblyItem item = ( AssemblyItem ) items [ i ] ;
				int r = string.Compare ( assemblyName , items [ i ].ToString () ) ;
				if ( r == 0 )
				{
					items.RemoveAt ( i ) ;
					items.Insert ( i , newItem ) ;
					cbAssemblies.SelectedIndex = i ;
					return ;
				}
				else if ( r < 0 )
				{
					items.Insert ( i , newItem ) ;
					cbAssemblies.SelectedIndex = i ;
					return ;
				}
			}
			items.Add ( newItem ) ;
			cbAssemblies.SelectedIndex = items.Count - 1 ;
		}
		/// <summary>
		/// When "assemblies" list index is changed this event hanler calls setAssembliesBackColor() method in order to 
		/// set "assemblies" checkbox color and/or activate openAssemblyDialog(OpenFileDialog)
		/// </summary>
		/// <param name="sender">cbAssemblies(ComboBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbAssemblies_SelectedIndexChanged ( object sender , EventArgs e )
		{
			_resourceAssembly = cbAssemblies.SelectedIndex == -1 ? null : ( ( AssemblyItem ) cbAssemblies.SelectedItem ).assembly ;
			setAssebliesBackColor () ;
			if ( mode == StartServerMode.resourceServer )
				cmdStart.Enabled = ( _resourceAssembly != null ) && 
					( ( getCerrtificateState () & CerrtificateState.badMask ) == CerrtificateState.none ) ;
		}
		/// <summary>
		/// Set proper asseblies text box background color
		/// </summary>
		protected void setAssebliesBackColor ()
		{
			cbAssemblies.BackColor = 
				( cmdStart.Enabled = cbAssemblies.SelectedIndex == -1 ? false : cbAssemblies.Text == cbAssemblies.SelectedItem.ToString () ) 
				? cbAssemblies.Focused ? SystemColors.Window : inactiveEditBack : Color.MistyRose ;
		}
		/// <summary>
		/// Set proper certificate text box background color
		/// </summary>
		protected void setCertificateBackColor ()
		{
			checkCertificate ( false , false ) ;
		}
		/// <summary>
		/// When "assemblies" dropdown list is open this event hanler set cbAssemblies(ComboBox)
		/// </summary>
		/// <param name="sender">cbAssemblies(ComboBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbAssemblies_DropDown ( object sender, EventArgs e )
		{
			cbAssemblies.BackColor = SystemColors.Window ;
		}

		/// <summary>
		/// When "assemblies" dropdown list is closed this event hanler calls setAssembliesBackColor() method in order to set(enables/disables) cmdStart button
		/// </summary>
		/// <param name="sender">cbAssemblies(ComboBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbAssemblies_DropDownClosed ( object sender , EventArgs e )
		{
			cbAssemblies_SelectedIndexChanged ( cbAssemblies , e ) ;
		}
		/// <summary>
		/// Search for index of given assembly in assembly combo
		/// </summary>
		/// <param name="resourceAssembly">Assembly instance</param>
		/// <returns>Returns index of given assembly in assembly combo box or -1(if not found)</returns>
		public int getAssemblyListIndex ( Assembly resourceAssembly )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			int c = items.Count ;
			for ( int i = 0 ; i < c ; i++ )
				if ( ( ( AssemblyItem ) items [ i ] ).assembly == resourceAssembly )
				{
					return i ;
				}
			return -1 ;
		}
		/// <summary>
		/// Try to set selected index of assembly combo according given assembly.
		/// </summary>
		/// <param name="resourceAssembly">Assembly instance</param>
		/// <returns>Retruns true if given assembly is in list and list index set to item with given assembly</returns>
		public bool setAssemblyListIndex ( Assembly resourceAssembly )
		{
			int i = getAssemblyListIndex ( resourceAssembly ) ;
			if ( i == -1 ) return false ;
			cbAssemblies.SelectedIndex = i ;
			return true ;
		}
		/// <summary>
		/// Currently selected assembly
		/// </summary>
		public Assembly selectedAssembly
		{
			get => cbAssemblies.SelectedIndex == -1 ? null : ( ( AssemblyItem ) cbAssemblies.SelectedItem ).assembly ;
		}
		/// <summary>
		/// Auxiliary variable for the resourcesClicked event
		/// </summary>
		protected EventHandler _resourceServerChoosen ;
		/// <summary>
		/// Raised when user choose resource based server and click on start button
		/// </summary>
		public event EventHandler resourceServerChoosen 
		{
			add => _resourceServerChoosen += value ;
			remove => _resourceServerChoosen -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the resourcesClicked event
		/// </summary>
		protected EventHandler _fileServerChoosen ;
		/// <summary>
		/// Raised when user choose file based server and click on start button
		/// </summary>
		public event EventHandler fileServerChoosen 
		{
			add => _fileServerChoosen += value ;
			remove => _fileServerChoosen -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the resourcesClicked event
		/// </summary>
		protected EventHandler<string> _invalidWebrootFolder ;
		/// <summary>
		/// Raised when message about invalid webroot folder should be placed from host/owner form(you do it)
		/// </summary>
		public event EventHandler<string> invalidWebrootFolder 
		{
			add => _invalidWebrootFolder += value ;
			remove => _invalidWebrootFolder -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the resourcesClicked event
		/// </summary>
		protected EventHandler<X509Certificate2> _certificateAccepted ;
		/// <summary>
		/// Raised when certifatced loaded and tested
		/// </summary>
		public event EventHandler<X509Certificate2> certificateAccepted 
		{
			add => _certificateAccepted += value ;
			remove => _certificateAccepted -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateFailedOnClient event
		/// </summary>
		protected ErrorEventHandler _certificateFailedOnClient ;
		/// <summary>
		/// Raised when certificate SSL test failes on client side
		/// </summary>
		public event ErrorEventHandler certificateFailedOnClient 
		{
			add => _certificateFailedOnClient += value ;
			remove => _certificateFailedOnClient -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateFailedOnServer event
		/// </summary>
		protected ErrorEventHandler _certificateFailedOnServer ;
		/// <summary>
		/// Raised when certificate SSL test failes on Server side
		/// </summary>
		public event ErrorEventHandler certificateFailedOnServer 
		{
			add => _certificateFailedOnServer += value ;
			remove => _certificateFailedOnServer -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the certificateLoadFailure event
		/// </summary>
		protected ErrorEventHandler _certificateLoadFailure ;
		/// <summary>
		/// Raised when certificate file cannnot be open for any reason including but not limiting to bad password
		/// </summary>
		public event ErrorEventHandler certificateLoadFailure 
		{
			add => _certificateLoadFailure += value ;
			remove => _certificateLoadFailure -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the invalidPortNumbere event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _invalidPortNumber ;
		/// <summary>
		/// Raised when user somehow manage to type invalid number in port number text box
		/// </summary>
		public event EventHandler<ErrorEventArgs> invalidPortNumber 
		{
			add => _invalidPortNumber += value ;
			remove => _invalidPortNumber -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the _onOpenTcpTestFailed event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _openTcpTestFailed ;
		/// <summary>
		/// Raised when certificate SSL test failed
		/// </summary>
		public event EventHandler<ErrorEventArgs> openTcpTestFailed 
		{
			add => _openTcpTestFailed += value ;
			remove => _openTcpTestFailed -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the assemblyLoadError event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _assemblyLoadError ;
		/// <summary>
		/// Raised when assembly loading failed
		/// </summary>
		public event EventHandler<ErrorEventArgs> assemblyLoadError 
		{
			add => _assemblyLoadError += value ;
			remove => _assemblyLoadError -= value ;
		}
		/// <summary>
		/// This flag indicated if openAssemblyDialog or openCertificateDialog accepted file
		/// </summary>
		protected bool openFileDialogFileOk ;
		/// <summary>
		/// When user accepts file via openAssemblyDialog or openCertificateDialog this event handler raises openFileDialogFileOk flag
		/// </summary>
		/// <param name="sender">openAssemblyDialog or openCertificateDialog(OpenFileDialog)</param>
		/// <param name="e">(CancelEventArgs)</param>
		private void openFileDialog_FileOk ( object sender, CancelEventArgs e )
		{
			openFileDialogFileOk = true ;
		}
		/// <summary>
		/// This keydown event handler restores clipboard copy/cut functionality(commonly disabled for password text box)
		/// <br/>It also handles Enter and Escape keys.
		/// </summary>
		/// <param name="sender">(TextBox)</param>
		/// <param name="e">(KeyEventArgs)</param>
		private void tbPassword_KeyDown ( object sender , KeyEventArgs e )
		{
			if ( e.Control )
				switch ( e.KeyCode )
				{
					case Keys.V :
						tbPassword.Cut () ;
						e.Handled = true ;
					break ;
					case Keys.C :
						tbPassword.Copy () ;
						e.Handled = true ;
					break ;
				}
			else 
				switch ( e.KeyCode )
				{
					case Keys.Enter :
						cmdAcceptPassword_Click ( cmdAcceptPassword , e ) ;
						e.Handled = true ;
					break ;
					case Keys.Escape :
						cmdCancelSslTest_Click ( cmdClosePasswordPanel , e ) ;
						e.Handled = true ;
					break ;
				}
		}
		/// <summary>
		/// Whenever certificate file path is changed this method search trought the certificateTests dictionary and set<br>
		/// </br>_certificateLoadError, _certificateClientError, _certificateServerError and _certificate to proper values 
		/// </summary>
		/// <param name="sender">(TextBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void tbCertificate_TextChanged ( object sender , EventArgs e )
		{
			string s = tbCertificate.Text.Trim().ToLower() ;
			//first this 
			_certificateLoadError = null ;
			_certificateClientError = null ;
			_certificateServerError = null ;
			_certificate = null ; 
			if ( certificateTests.ContainsKey ( s ) )
			{
				Dictionary<SslProtocols,CertificateTest> testsByProtocol = certificateTests [ s ] ;
				if ( testsByProtocol.ContainsKey ( sslProtocol ) )
				{
					CertificateTest certificateTest = testsByProtocol [ sslProtocol ] ;
					tbPassword.Text = certificateTest.password ;
					_certificateLoadError = certificateTest.certificateLoadError ;
					_certificateServerError = certificateTest.certificateServerError ;
					_certificateClientError = certificateTest.certificateClientError ;
					_certificate = certificateTest.certificate ;
				}
				else foreach ( CertificateTest certificateTest in testsByProtocol.Values )
					{
						tbPassword.Text = certificateTest.password ;
						_certificateLoadError = certificateTest.certificateLoadError ;
						break ;
					}
			}
			setCertificateBackColor () ;
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}       

		private void cbProtocol_SelectedIndexChanged ( object sender , EventArgs e )
		{
			gbCertificate.Enabled = cbProtocol.SelectedIndex > 0 ;
			tbCertificate_TextChanged ( tbCertificate , e ) ;
		}

		private void cbProtocol_TextChanged ( object sender , EventArgs e )
		{
			cbProtocol_SelectedIndexChanged ( cbProtocol , e ) ;
		}

		private void cbAssemblies_Enter ( object sender , EventArgs e )
		{
			setAssebliesBackColor () ;
		}

		private void cbAssemblies_Leave ( object sender , EventArgs e )
		{
			setAssebliesBackColor () ;
		}

		private void tbCertificate_Leave ( object sender , EventArgs e )
		{
			setCertificateBackColor () ;
		}

		private void tbCertificate_Enter ( object sender , EventArgs e )
		{
			setCertificateBackColor () ;
		}

		private void cbProtocol_Enter ( object sender , EventArgs e )
		{
			cbProtocol.BackColor = SystemColors.Window ;
		}

		private void cbProtocol_Leave ( object sender, EventArgs e )
		{
			cbProtocol.BackColor = inactiveEditBack ;
		}

		private void tbWebroot_Leave ( object sender, EventArgs e )
		{
			tbWebroot.BackColor = inactiveEditBack ;
		}
		private void tbWebroot_Enter ( object sender, EventArgs e )
		{
			tbWebroot.BackColor = SystemColors.Window ;
		}
		private void tbPort_Leave ( object sender, EventArgs e )
		{
			tbPort.BackColor = inactiveEditBack ;
		}
		private void tbPort_Enter ( object sender, EventArgs e )
		{
			tbPort.BackColor = SystemColors.Window ;
		}

		private void tbSiteName_TextChanged ( object sender , EventArgs e )
		{
			string s = tbSiteName.Text.Trim() ;
			clientTaragetText.Text = s == "" ? "" : ( "https://" + s + ":" + ( port == 0 ? "(?)" : port.ToString () ) ) ;
		}

		private void tbSiteName_KeyDown ( object sender , KeyEventArgs e )
		{
			switch ( e.KeyCode )
			{
				case Keys.Enter :
					e.Handled = true ;
					cmdStartCertificateTest_Click ( cmdStartCertificateTest , e ) ;
				break ;
				case Keys.Cancel :
					e.Handled = true ;
					cmdCancelSslTest_Click ( cmdCancelSslTest , e ) ;
				break ;
			}
		}


		//{
		//	public X509Certificate2 certificate 
		//	{
		//		get ;
		//		protected set ;
		//	}
		//	public string fileName
		//	{
		//		get ;
		//		protected set ;
		//	}
		//	/// <summary>
		//	/// Certificate error on client ssl authentification or null
		//	/// </summary>
		//	public Exception certificateClientError 
		//	{
		//		get ;
		//		protected set ;
		//	}
		//	/// <summary>
		//	/// Certificate error on server ssl authentification or null
		//	/// </summary>
		//	public Exception certificateServerError 
		//	{
		//		get ;
		//		protected set ;
		//	}
		//	/// <summary>
		//	/// Auxiliary variable for the certificateLoadError property
		//	/// </summary>
		//	protected Exception _certificateLoadError ;
		//	/// <summary>
		//	/// Certificate  (file) load error 
		//	/// </summary>
		//	public Exception certificateLoadError 
		//	{
		//		get => _certificateLoadError ;
		//	}

		//}

	}
}
