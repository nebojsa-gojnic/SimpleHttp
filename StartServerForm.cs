using System ;
using System.Drawing ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Security.Cryptography.X509Certificates ;
using System.Reflection ;
using System.Net ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows.Forms ;
using System.Net.Security;
using System.Security.Authentication ;
using System.Security.Cryptography ;
using System.Net.Sockets;
using System.Drawing.Printing;

namespace SimpleHttp
{
	public partial class StartServerForm : Form
	{
		public const SslProtocols sslProtocol = SslProtocols.Tls12 ;
		//Personal Information Exchange (*.pkx)|*.pkx
		protected StartServerMode _mode ;
		protected TcpListener tcpListener ;
		protected Bitmap mainLayoutBitmap ;
		protected Brush mainLayoutGrayBrush ;
		protected Brush mainLayoutWindowBrush ;
		protected bool ignorebNoCertificateCheck ;

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
			get => cbNoCertificate.Checked ? null : _certificate ;
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
		
		/// <summary>
		/// Creates new instance of StartServerForm
		/// </summary>
		public StartServerForm()
		{
			InitializeComponent() ;
			_assemblyPath = "" ;
			certificatePassword = "" ;
			loadAssemblies () ;
			tcpListener = null ;
			mainLayoutBitmap = null ;
			mainLayoutGrayBrush = new SolidBrush ( Color.FromArgb ( 150 , Color.Gray ) ) ;
			mainLayoutWindowBrush = new SolidBrush ( SystemColors.Control ) ;
			ignorebNoCertificateCheck = false ;
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
		/// Set location(in center of owner if any(
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
				cmdStartOnFiles.BackColor = Color.White ;
				cmdStartOnResources.BackColor = SystemColors.ButtonFace ;
				gbAssemblies.Visible = false ;
				gbFilePath.Visible = true ;
				checkFolderSelection ( false ) ;
			}
			else
			{
				cmdStartOnResources.BackColor = Color.White ;
				cmdStartOnFiles.BackColor = SystemColors.ButtonFace ;
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
		
		
		private void cmdStartOnResources_Click ( object sender , EventArgs e )
		{
			mode = StartServerMode.resourceServer ;
		}
		
		private void cmdStartOnFiles_Click ( object sender , EventArgs e )
		{
			mode = StartServerMode.fileServer ;
		}
		private void tbPort_TextChanged ( object sender, EventArgs e )
		{
			checkPort ( false ) ;
		}
		private void checkPort ( bool raiseEvents )
		{
			int i ;
			if ( int.TryParse ( tbPort.Text.Trim() , out i ) )
				if ( ( i < 0 ) || ( i > 65535 ) )
				{
					cmdStart.Enabled = false ;
					tbPort.BackColor = Color.MistyRose ;
					if ( raiseEvents ) _invalidPortNumber?.Invoke ( this , new ErrorEventArgs ( new ApplicationException ( "Invalid port number value(" + i.ToString() + "), allowed range is 1-65535" ) ) ) ;
				}
				else tbPort.BackColor = SystemColors.Window ;
			else 
			{
				cmdStart.Enabled = false ;
				tbPort.BackColor = Color.MistyRose ;
				if ( raiseEvents )  _invalidPortNumber?.Invoke ( this , new ErrorEventArgs ( new ApplicationException ( "Invalid text for port number, \"" + tbPort.Text.Trim() + "\" cannot be converted to number" ) ) ) ;
			}
		}
		private void cmdSelectPath_Click ( object sender, EventArgs e )
        {
			folders.RootFolder = Environment.SpecialFolder.MyComputer ;
			folders.SelectedPath = tbWebroot.Text ;
			openFileDialogFileOk = false ;
			folders.ShowDialog ( this ) ;
        }
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
		private void gbCertificate_Resize ( object sender , EventArgs e )
		{
			int w = tbWebroot.Height * 5 / 4 ;
			cmdLoadAssembly.Bounds =
			cmdSelectCertificate.Bounds =
			cmdSelectPath.Bounds = new Rectangle ( tbCertificate.Right - w , tbCertificate.Top , w , tbCertificate.Height ) ;
			tbWebroot.Width = 
			cbAssemblies.Width =
			tbCertificate.Width = cmdSelectCertificate.Left - tbCertificate.Left ;			
		}
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
		public void loadAssemblies ()
		{
			cbAssemblies.Items.Clear () ;
			cbAssemblies.Sorted = false ;
			//cbAssemblies.Items.Add ( "<load from file system>" ) ;
			foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies () )
				cbAssemblies.Items.Add ( new AssemblyItem ( assembly ) ) ;
			cbAssemblies.Sorted = true ;
		}
		public static IEnumerable<Assembly> GetAllAssemblies()
		{
			List<string> list = new List<string>();
			Stack<Assembly> stack = new Stack<Assembly>();

			stack.Push ( Assembly.GetEntryAssembly () ) ;

			do
			{
				Assembly assembly = stack.Pop() ;

				yield return assembly ;

				foreach ( AssemblyName reference in assembly.GetReferencedAssemblies() )
					if ( !list.Contains ( reference.FullName ) )
						try
						{
							stack.Push ( Assembly.Load ( reference ) ) ;
							list.Add ( reference.FullName ) ;
						}
						catch { }

			}
			while ( stack.Count > 0 ) ;

		}
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
			if ( cbNoCertificate.Checked ) return CerrtificateState.none ;
			if ( ( _certificateLoadError != null ) || 
				 ( _certificateClientError != null ) ||
				 ( _certificateServerError != null ) ) return CerrtificateState.error ;
			return _certificate == null ? _loadedCertificate == null ? 
				CerrtificateState.notTested : CerrtificateState.loaded : CerrtificateState.valid ;
		}
		/// <summary>
		/// Returns true if certificate is existing and valid
		/// </summary>
		public bool certficateIsValid
		{
			get => getCertficateIsValid () ;
		}
		protected void validateValues ( bool raiseEvents )
		{
			if ( !cbNoCertificate.Checked )
				switch ( getCerrtificateState () )
				{
					case CerrtificateState.notTested :
						cmdStart.Enabled = false ;
						tbCertificate.BackColor = Color.MistyRose ;
						if ( raiseEvents ) showCertificatePassword () ;
					return ;
					case CerrtificateState.error :
						cmdStart.Enabled = false ;
						tbCertificate.BackColor = Color.MistyRose ;
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
					return ;
				}
			cmdStart.Enabled = true ;
			if ( mode == StartServerMode.fileServer )
				checkFolderSelection ( raiseEvents ) ;
			if ( cmdStart.Enabled )
			{
				checkPort ( raiseEvents ) ;
			}
		}
		private void cmdStart_Click ( object sender , EventArgs e )
		{
			validateValues ( true ) ;
			if ( cmdStart.Enabled )
			( mode == StartServerMode.fileServer ? _fileServerChoosen : _resourceServerChoosen )? .Invoke ( this , e ) ;
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
						setSelection ( oldSelectionStart , oldText ) ;
					}
				break ;
				case Keys.Down :
					if ( cbAssemblies.SelectedIndex < cbAssemblies.Items.Count - 1 )
					{
						e.Handled = true ;
						oldText = cbAssemblies.Text ;
						oldSelectionStart = cbAssemblies.SelectionStart ;
						cbAssemblies.SelectedIndex++ ;
						setSelection ( oldSelectionStart , oldText ) ;
					}
				break ;
			}
		}
		private void setSelection ( int oldSelectionStart , string oldText )
		{
			int s = matchCount ( oldText , cbAssemblies.Text ) ;
			cbAssemblies.SelectionStart = s < oldSelectionStart ? s : oldSelectionStart ;
			cbAssemblies.SelectionLength = cbAssemblies.SelectionStart == 0 ? 0 : cbAssemblies.Text.Length - cbAssemblies.SelectionStart ;
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
		/// <summary>
		/// This method accepts TCP connection during SSL certificate test.
		/// </summary>
		/// <param name="ar">This parameter carries the AcceptTcpClienState instance in the AsyncState property.
		/// <br/>AcceptTcpClienState instance contains TcpClient and X509Certificate2</param>
		public void OnAcceptTcpClient ( IAsyncResult ar ) 
		{
			AcceptTcpClienState state = null ;
			Exception ex = null ;
			SslStream sslStream = null ;
			try
			{
				state = ( AcceptTcpClienState ) ar.AsyncState ;
				TcpClient tcpClient = tcpListener.EndAcceptTcpClient ( ar ) ;
				sslStream = new SslStream ( tcpClient.GetStream() ) ;
				sslStream.AuthenticateAsServer ( state.certificate , false , sslProtocol , false ) ;
				BeginInvoke ( tryAcceptCertificate , new object [ 2 ] { state.certificate , state.certificateFilePath } ) ;
			}
			catch ( Exception x )
			{
				ex = x ;
			}
			try
			{
				if ( state != null )
					if ( state.tcpListener != null ) tcpListener.Stop () ;
			}
			catch { }
			try
			{
				if ( sslStream != null ) sslStream.Dispose () ;
			}
			catch { }
			if ( ex != null ) 
			{
				BeginInvoke ( onCertificateFailedOnServer , new object [ 1 ] { new ErrorEventArgs ( ex ) } ) ;
			}
		}
		protected void onCertificateFailedOnServer ( ErrorEventArgs e )
		{
			_certificate = null ;
			_certificateServerError = e.GetException() ;
			tbCertificate.BackColor = Color.MistyRose ;
			_certificateFailedOnServer?.Invoke ( this , e ) ;
		}
		protected void onCertificateFailedOnClient ( ErrorEventArgs e )
		{
			_certificate = null ;
			_certificateClientError = e.GetException() ;
			tbCertificate.BackColor = Color.MistyRose ;
			_certificateFailedOnClient?.Invoke ( this , e ) ;
		}
		protected void onOpenTcpTestFailed ( ErrorEventArgs e )
		{
			tbCertificate.BackColor = Color.LightSalmon ;
			_openTcpTestFailed?.Invoke ( this , e ) ;
		}
		/// <summary>
		/// This is invoked on main thread when SSL authethification pass client conncection test.
		/// It checks values of both _certificateClientError and _certificateServerError variables in order to set cetfiticate and visuals.
		/// If any of these variable values is null then
		/// </summary>
		/// <returns>Returns true if values in both _certificateClientError and _certificateServerError variables are null.</returns>
		protected bool tryAcceptCertificate ( X509Certificate2 certificate , string certificateFilePath )
		{
			if ( ( _certificateClientError == null ) && ( _certificateServerError == null ) )
			{
				_certificate = certificate ;
				_certificateFilePath = certificateFilePath ;
				cbNoCertificate.Checked = false ;
				tbCertificate.BackColor = SystemColors.Window ;
				return true ;
			}
			else 
			{
				tbCertificate.BackColor = Color.MistyRose ;
				return false ;
			}

		}
		/// <summary>
		/// TcpListener and X509Certificate2
		/// </summary>
		public class AcceptTcpClienState 
		{
			public TcpListener tcpListener
			{
				get ; protected set ;
			}
			public X509Certificate2 certificate
			{
				get ; protected set ;
			}
			public string certificateFilePath
			{
				get ; protected set ;
			}
			public AcceptTcpClienState ( TcpListener tcpListener , X509Certificate2 certificate , string certificateFilePath ) 
			{
				this.tcpListener = tcpListener ;
				this.certificateFilePath = certificateFilePath ;
				this.certificate = certificate ;
			}
		}
		
		/// <summary>
		/// This method tries to load certificate and connect over SSL with it.
		/// </summary>
		private void showCertificatePassword ()
		{
			ignorebNoCertificateCheck = true ;
			cbNoCertificate.Checked = true ;
			ignorebNoCertificateCheck = false  ;
			_loadedCertificate = null ;
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
				if ( ( mainLayoutBitmap.Width != mainLayout.Width ) || ( mainLayoutBitmap.Height != mainLayout.Height ) )
				{
					mainLayoutBitmap.Dispose () ;
					mainLayoutBitmap = null ;
				}
			if ( mainLayoutBitmap == null ) mainLayoutBitmap = new Bitmap ( mainLayout.Width , mainLayout.Height ) ;
			mainLayout.DrawToBitmap ( mainLayoutBitmap , new Rectangle ( Point.Empty , mainLayout.Size ) ) ;
			drawPasswordPanelBackground () ;
			passwordPanel.BackgroundImageLayout = ImageLayout.None ;
			passwordPanel.BackgroundImage = mainLayoutBitmap ;
			try
			{
				passwordPanel.Visible = true ;
				passwordPanel.BringToFront () ;
			}
			catch { }
		}
		private void drawPasswordPanelBackground ()
		{
			Rectangle rect = new Rectangle ( Point.Empty , mainLayout.Size ) ;
			using ( Graphics graphics = Graphics.FromImage ( mainLayoutBitmap ) )
			{
				graphics.FillRectangle ( mainLayoutGrayBrush , rect ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , 0 , mainLayout.Width , gbPassword.Top - 2 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , gbPassword.Top - 2 , gbPassword.Left - 4 , gbPassword.Height + 6 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , gbPassword.Bottom + 4 , mainLayout.Width , mainLayout.Height - gbPassword.Bottom - 4 ) ) ;
				//graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( gbPassword.Right + 4 , gbPassword.Top - 2 , mainLayout.Width - gbPassword.Right + 4 , gbPassword.Height + 6  ) ) ;
				
				//graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( gbPassword.Left - 4 , gbPassword.Top - 2 , gbPassword.Width + 8 , gbPassword.Height + 6 ) ) ;

				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( gbPassword.Left - 5 , gbPassword.Top - 3 , gbPassword.Width + 10 , gbPassword.Height + 7 ) ) ;

				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( gbPassword.Left - 6 , gbPassword.Top - 2 , 1 , gbPassword.Height + 5 ) ) ;
				graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( gbPassword.Right + 5 , gbPassword.Top - 2 , 1 , gbPassword.Height + 5 ) ) ;
				
			}
		}
		private void passwordPanel_Resize(object sender, EventArgs e)
		{
			gbPassword.Location = new Point ( ( passwordPanel.Width - gbPassword.Width ) >> 1 , gbCertificate.Bottom ) ;
			if ( passwordPanel.Visible ) setCertificatePasswordBackground () ;
		}
		private void passwordPanel_Click ( object sender, EventArgs e )
		{
			passwordPanel.Visible = false ;
		}

		private void cmdAcceptPassword_Click ( object sender, EventArgs e )
		{
			_certificateLoadError = null ;
			_loadedCertificate = null ;
			try
			{ 
				_loadedCertificate = new X509Certificate2 ( tbCertificate.Text , tbPassword.Text ) ;
				checkSslCertificate ( _loadedCertificate , tbCertificate.Text ) ;
			}
			catch ( Exception x )
			{
				_certificateLoadError = x ;
			}
			if ( _certificateLoadError != null ) 
			{
				_certificateLoadFailure?.Invoke ( this , new ErrorEventArgs ( _certificateLoadError ) ) ;
				if ( certificate != null ) certificate.Dispose () ;
			}
			passwordPanel.Visible = false ;
			validateValues ( true ) ;
		}
		private void cmdCancelSslTest_Click ( object sender, EventArgs e )
		{
			passwordPanel.Visible = false ;
		}
		/// <summary>
		/// This method tries to load certificate and connect over SSL with it.
		/// </summary>
		private void checkSslCertificate ( X509Certificate2 certificate , string certificateFilePath )
		{
			ErrorEventArgs errorEventArgs = null ;
			
			_certificateServerError = null ;
			_certificateClientError = null ;
			tbCertificate.BackColor = SystemColors.Window ;
			try
			{
				//_certificate = GenerateSelfSignedCertificate () ;
				tcpListener = new TcpListener ( IPAddress.Any , 0 ) ;
				tcpListener.Start () ;
				tcpListener.BeginAcceptTcpClient ( OnAcceptTcpClient , new AcceptTcpClienState ( tcpListener , certificate , certificateFilePath ) ) ;
				makeClientTestRequest ( ( ( IPEndPoint ) tcpListener.LocalEndpoint ).Port ) ;
			}
			catch ( Exception x )
			{ 
				errorEventArgs = new ErrorEventArgs ( x ) ;
				tbCertificate.BackColor = Color.MistyRose ; 
			}
			//try
			//{
			//	if ( certificate != null ) certificate.Dispose () ;
			//}
			//catch { }
			//try
			//{
			//	if ( sslClientSteam != null ) sslClientSteam.Dispose () ;
			//}
			if ( errorEventArgs != null ) onOpenTcpTestFailed ( errorEventArgs ) ;
		}
		protected void makeClientTestRequest ( int port )
		{
			TcpClient tcpClient = null ;
			ErrorEventArgs errorEventArgs = null ;
			try
			{
				tcpClient = new TcpClient ( new IPEndPoint ( new IPAddress ( new byte [ 4 ] { 127 , 0 , 0 , 1 } ) , 50011 ) ) ;
				tcpClient.Connect ( new IPEndPoint ( new IPAddress ( new byte [ 4 ] { 127 , 0 , 0 , 1 } ) , port ) ) ;
				NetworkStream clientStream = tcpClient.GetStream () ;
				SslStream sslClientSteam = new SslStream ( clientStream ) ;
				SslClientAuthenticationOptions ops = new SslClientAuthenticationOptions () ;
				ops.TargetHost = "localhost" ;
				ops.EnabledSslProtocols = sslProtocol ;
				ops.AllowRenegotiation = true ;
				sslClientSteam.AuthenticateAsClient ( ops ) ;
				sslClientSteam.Write ( System.Text.Encoding.ASCII.GetBytes ( "Hello" ) ) ;
			}
			catch ( Exception x )
			{
				errorEventArgs = new ErrorEventArgs ( x ) ;
			}
			try
			{
				if ( tcpClient != null ) tcpClient.Close () ;
			}
			catch { }
			try
			{
				if ( tcpClient != null ) tcpClient.Dispose () ;
			}
			catch { }
			if ( errorEventArgs  != null ) onCertificateFailedOnClient ( errorEventArgs ) ;

		}
		/// <summary>
		/// This method checks if folder specified in tbWebroot(TextBox) is exisitng 
		/// and set(enables/disables) cmdStart button if raiseEvent flag us up
		/// </summary>
		/// <param name="raiseEvent">When this is true and webroot folder is bad, invalidWebrootFolder event is triggered </param>
		private void checkFolderSelection ( bool raiseEvent )
		{
			if ( Directory.Exists ( tbWebroot.Text ) )
			{
				cmdStart.Enabled = true ;
				tbWebroot.BackColor = SystemColors.Window ;
			}
			else 
			{
				cmdStart.Enabled = true ;
				if ( raiseEvent ) invalidWebrootFolder?.Invoke ( this , tbWebroot.Text ); ;
				tbWebroot.BackColor = Color.MistyRose ; 
			}
		}
		
		private void cmdLoadAssembly_Click ( object sender, EventArgs e )
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
		/// Set "assemblies" combo box background color and
		/// </summary>
		private void setAssembliesBackColor1 ()
		{
			cbAssemblies.BackColor = 
			( cmdStart.Enabled = cbAssemblies.SelectedIndex == -1 ? false : cbAssemblies.Text == cbAssemblies.SelectedItem.ToString () ) 
			? SystemColors.ButtonFace : Color.MistyRose ;
		}
		/// <summary>
		/// Inserts new Assmebly loaded from disk
		/// </summary>
		/// <param name="newItem">AssemblyItem instance with Assembly</param>
		protected void insertLoadedAssembly ( AssemblyItem newItem )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			string assemblyName = "<" + newItem.assembly.GetName().Name + ">" ;
			int c = items.Count ;
			Assembly assembly = newItem.assembly ;
			for ( int i = 0 ; i < c ; i++ )
			{
				AssemblyItem item = ( AssemblyItem ) items [ i ] ;
				int r = string.Compare ( "<" + item.assembly.GetName().Name + ">" , assemblyName ) ;
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
			cbAssemblies.BackColor = _resourceAssembly == null ? Color.MistyRose : SystemColors.ButtonFace ;
			if ( mode == StartServerMode.resourceServer )
				cmdStart.Enabled = ( _resourceAssembly != null ) && 
					( ( getCerrtificateState () & CerrtificateState.badMask ) == CerrtificateState.none ) ;
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
		protected EventHandler _invalidWebrootFolder ;
		/// <summary>
		/// Raised when message about invalid webroot folder should be placed from host/owner form(you do it)
		/// </summary>
		public event EventHandler<string> invalidWebrootFolder ;

		/// <summary>
		/// Auxiliary variable for the certificateFailedOnClient event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _certificateFailedOnClient ;
		/// <summary>
		/// Raised when certificate SSL test failes on client side
		/// </summary>
		public event EventHandler<ErrorEventArgs> certificateFailedOnClient 
		{
			add => _certificateFailedOnClient += value;
			remove => _certificateFailedOnClient -= value;
		}
		/// <summary>
		/// Auxiliary variable for the certificateFailedOnServer event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _certificateFailedOnServer ;
		/// <summary>
		/// Raised when certificate SSL test failes on Server side
		/// </summary>
		public event EventHandler<ErrorEventArgs> certificateFailedOnServer 
		{
			add => _certificateFailedOnServer += value;
			remove => _certificateFailedOnServer -= value;
		}
		/// <summary>
		/// Auxiliary variable for the certificateLoadFailure event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _certificateLoadFailure ;
		/// <summary>
		/// Raised when certificate file cannnot be open for any reason including but not limiting to bad password
		/// </summary>
		public event EventHandler<ErrorEventArgs> certificateLoadFailure 
		{
			add => _certificateLoadFailure += value;
			remove => _certificateLoadFailure -= value;
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
			add => _invalidPortNumber += value;
			remove => _invalidPortNumber -= value;
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
			add => _assemblyLoadError += value;
			remove => _assemblyLoadError -= value;
		}
		/// <summary>
		/// This flag indicated if openAssemblyDialog or openCertificateDialog accepted file
		/// </summary>
		protected bool openFileDialogFileOk ;
		/// <summary>
		/// When user accepts file via openAssemblyDialog or openCertificateDialog this event handler raises openFileDialogFileOk flag
		/// </summary>
		/// <param name="sender">openAssemblyDialog or openCertificateDialog(OpenFileDialog)</param>
		/// <param name="e"></param>
		private void openFileDialog_FileOk ( object sender, CancelEventArgs e )
		{
			openFileDialogFileOk = true ;
		}

		/// <summary>
		/// When user checks/unchecsk "No certificate" box this event handler enables/disables "certificate" text box
		/// </summary>
		/// <param name="sender">cbNoCertificate(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbNoCertificate_CheckedChanged ( object sender , EventArgs e )
		{
			if ( ignorebNoCertificateCheck ) return ;
			tbCertificate.Enabled = !cbNoCertificate.Checked ;
			validateValues ( false ) ;
		}

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
						cmdCancelSslTest_Click ( cmdCancelSslTest , e ) ;
						e.Handled = true ;
					break ;
				}
		}
	}
}
