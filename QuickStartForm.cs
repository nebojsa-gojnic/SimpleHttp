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
using System.Diagnostics;
using Newtonsoft.Json.Linq;

//I:\Code\Nodes\PipeMania\PipeManiaService\Resources
//I:\Code\localhost2.pfx
namespace SimpleHttp
{
	public partial class QuickStartForm : Form
	{
		//Personal Information Exchange (*.pkx)|*.pkx
		protected StartServerMode _mode ;
		protected Bitmap mainLayoutBitmap ;
		protected Brush mainLayoutGrayBrush ;
		protected Brush mainLayoutWindowBrush ;
		protected Color inactiveEditBack ;
		protected Dictionary <string,Dictionary<SslProtocols,CertificateTest>> certificateTests ;
		protected CertificateTest runningTest ;
		/// <summary>
		/// last Focused control
		/// </summary>
		protected Control lastControl ;
		public enum certificateRequestedBy
		{
			none = 0 ,
			startButtonClick = 1 ,
			showParametersClick = 2 
		}
		/// <summary>
		/// If this flag is set to true then fileServerChoosen or resourceServerChoosen event will be fired in acceptCertificate() method(server will start)
		/// </summary>
		protected certificateRequestedBy certificateBy ;
		/// <summary>
		/// Semi-bold font
		/// </summary>
		protected Font boldFont ;
		/// <summary>
		/// Semi-bold underline font
		/// </summary>
		protected Font boldUnderlineFont ;
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
		/// Auxiliary variable for the configData property
		/// </summary>
		protected WebServerConfigData _configData ;
		/// <summary>
		/// Auxiliary variable for the configData property
		/// </summary>
		protected void setConfigData ( WebServerConfigData value )
		{
			if ( value != null )
			{
				tbSiteName.Text = string.IsNullOrWhiteSpace ( value.sitename ) ? "localhost" : value.sitename ;
				tbPort.Text = value.port.ToString() ;
				tbPassword.Text = value.sslCertificatePassword ;
				tbCertificate.Text = value.sslCertificateSource ;
				sslProtocol = value.sslProtocol ;
				JObject httpServiceConfigData = null ;
				try
				{
					httpServiceConfigData = value.services [ "resourceHttpService" ].configData ;
				}
				catch { }
				object obj ;
				if ( httpServiceConfigData == null )
				{
					try
					{
						httpServiceConfigData = value.services [ "fileHttpService" ].configData ;
					}
					catch { }
					if ( httpServiceConfigData == null )
					{ }
					else
					{
						mode = StartServerMode.fileServer ;
						obj = httpServiceConfigData [ "webroot" ] ;
						tbWebroot.Text = obj == null ? "" : obj.ToString () ;
					}
				}
				else
				{
					mode = StartServerMode.resourceServer ;
					obj = httpServiceConfigData [ "assemblyPath" ] ;
					if ( obj != null ) insertLoadedAssembly ( AssemblyItem.loadAssemblyItem ( obj.ToString () ) ) ;
				}
				_certificateLoadError = null ;
				_certificateClientError = null ;
				_certificateServerError = null ;
				_certificate = null ;

				if ( useSsl ) 
				{
					try
					{
						_certificate = configData.sslCertificate ;
					}
					catch { }
					//if ( _certificate == null )
					//{ }
				}
				createConfigData () ;
				//validateValues ( true , true ) ;					
			}
		}
		/// <summary>
		/// Creates new value for configData property based on current form values
		/// </summary>
		protected void createConfigData ()
		{
			_configData = mode == StartServerMode.fileServer ?
				new FileWebConfigData ( tbWebroot.Text.Trim () , tbSiteName.Text.Trim () , port , tbCertificate.Text.Trim () , tbPassword.Text , sslProtocol ) :
				new ResourceWebConfigData ( resourceAssemblySource , tbSiteName.Text.Trim () , port , tbCertificate.Text.Trim () , tbPassword.Text , sslProtocol ) ;
		}
		/// <summary>
		/// Auxiliary variable for the configData property
		/// </summary>
		protected WebServerConfigData getConfigData ()
		{
			if ( _configData == null ) createConfigData () ;
			return _configData ;
		}
		/// <summary>
		/// JSON configuration data based on data form this form
		/// </summary>
		public WebServerConfigData configData
		{
			get => getConfigData () ;
			set => setConfigData ( value ) ;
		}

		/// <summary>
		/// Get method for the SiteUri property
		/// </summary>
		/// <returns>Returns Uri based on values supplied in hostname, port and security protocol field. Can be null.</returns>
		protected Uri getSiteUri ()
		{
			Uri uri ;
			Uri.TryCreate ( lbSiteUri.Text , new UriCreationOptions () , out uri ) ;
			return uri ;
		}
		/// <summary>
		/// Returns Uri based on values supplied in hostname, port and security protocol field. Can be null.
		/// </summary>
		public Uri siteUri
		{
			get => getSiteUri() ;
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
		/// Auxiliary variable for the resourceAssemblySource property
		/// </summary>
		protected string _resourceAssemblySource ;
		/// <summary>
		/// Selectred assemblySource with resources
		/// </summary>
		public string resourceAssemblySource 
		{
			get => _resourceAssemblySource ;
		}
		/// <summary>
		/// Loaded yet not accepted certificate 
		/// </summary>
		protected X509Certificate2 _loadedCertificate ;
		/// <summary>
		/// Auxiliary variable for the certificate property
		/// </summary>
		protected X509Certificate2 _certificate ;
		/// <summary>r
		/// The path to the file from which the certificate is loaded.
		/// </summary>
		protected string _certificateFilePath ;
		/// <summary>
		/// certificate loaded with path from "certificate" text box
		/// </summary>
		/// <returns>
		/// Returns certificate loaded with path from "certificate" text box or null
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
		/// Get method for the sslProtocol property
		/// </summary>
		/// <returns>Returns one of the SslProtocols enum values according to user choice</returns>
		public SslProtocols getSslProtocol ()
		{
			return cbProtocol.SelectedIndex == -1 ? SslProtocols.None :
				( ( EnumItem<SslProtocols> ) cbProtocol.Items [ cbProtocol.SelectedIndex ] ).value ;
		}
		/// <summary>
		/// Set method for the sslProtocol property
		/// </summary>
		/// <param name="value">New value for the sslProtocol property</param>
		public void setSslProtocol ( SslProtocols value)
		{
			ComboBox.ObjectCollection items = cbProtocol.Items ;
			int c = items.Count ;
			for ( int i = 0 ; i < c ; i++ )
			{
				if ( ( ( EnumItem<SslProtocols> ) items [ i ] ).value == value )
				{
					cbProtocol.SelectedIndex = i ;
					return ;
				}
			}
			cbProtocol.SelectedIndex = -1 ;
		}
		/// <summary>
		/// SSL protocol(or flat http)
		/// </summary>
		public SslProtocols sslProtocol
		{
			get => getSslProtocol () ;
			set => setSslProtocol ( value ) ;
		}
		/// <summary>
		/// Creates new instance of StartServerForm
		/// </summary>
		public QuickStartForm()
		{
			InitializeComponent() ;
			certificateTests = new Dictionary<string, Dictionary<SslProtocols, CertificateTest>> () ;

			boldUnderlineFont = lbSiteUri.Font ;
			boldFont = new Font ( boldUnderlineFont , FontStyle.Regular ) ;
			runningTest = null ;
			_assemblyPath = "" ;
			certificatePassword = "" ;
			Color col1 = SystemColors.Window ;
			Color col2 = SystemColors.ButtonFace ;
			tbPort.BackColor =
			tbSiteName.BackColor =
			tbCertificate.BackColor =
			cbAssemblies.BackColor =
			tbWebroot.BackColor =
			cbProtocol.BackColor = 
			inactiveEditBack = Color.FromArgb (  255 ,
												( ( int ) col1.R + ( int ) col2.R ) >> 1 ,
												( ( int ) col1.G + ( int ) col2.G ) >> 1 ,
												( ( int ) col1.B + ( int ) col2.B ) >> 1 ) ;
			
			loadAssemblies () ;
			mainLayoutBitmap = null ;
			mainLayoutGrayBrush = new SolidBrush ( Color.FromArgb ( 150 , Color.Gray ) ) ;
			mainLayoutWindowBrush = new SolidBrush ( SystemColors.Control ) ;

			cbProtocol.Items.Add ( new EnumItem<SslProtocols> ( "Flat HTTP" , SslProtocols.None ) ) ;
			cbProtocol.Items.Add ( new EnumItem<SslProtocols> ( "TLS 1.2" , SslProtocols.Tls12 ) ) ;
			cbProtocol.Items.Add ( new EnumItem<SslProtocols> ( "TLS 1.3" , SslProtocols.Tls13 ) ) ;
			//cbProtocol.Items.AddRange ( getSslProtocols () ) ;

			cbProtocol.SelectedIndex = 0 ;
			cbProtocol.SelectionLength = 0 ;
			setSiteUriText () ;

			gbProtocol.MouseUp += groupBox_MouseUp ;
			gbCertificate.MouseUp += groupBox_MouseUp ;
			gbPassword.MouseUp += groupBox_MouseUp ;
			gbSiteName.MouseUp += groupBox_MouseUp ;
			gbWebroot.MouseUp += groupBox_MouseUp ;
			gbAssemblies.MouseUp  += groupBox_MouseUp ;
			gbPort.MouseUp  += groupBox_MouseUp ;

			//gbPassword.Location = new Point ( - gbPassword.Width , - gbPassword.Height ) ;
		}

		private void groupBox_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{
				( ( GroupBox ) sender ).Controls [ 0 ].Focus () ;
			}
			catch { }
		}

		/// <summary>
		/// This method set (again)location and then calls base method(to raise Shown event)
		/// </summary>
		/// <param name="e">(EventArgs)</param>
		protected override void OnShown ( EventArgs e )
		{
			BeginInvoke ( setLocation ) ;
			gbCertificate_Resize ( this , e ) ;
			Size sz = Size ;
			AutoSize = false ;
			Size = sz ;
			base.OnShown ( e ) ;
			Opacity = 1.0 ;
		}
		protected override void OnActivated ( EventArgs e )
		{
			base.OnActivated ( e ) ;
			BeginInvoke ( button_MouseUp  , new object [ 2 ] ) ;
		}
		protected override void OnKeyDown ( KeyEventArgs e )
		{
			ComboBox box ;
			try
			{
				if ( e.Control )
					switch ( e.KeyCode )
					{
						case Keys.F :
							cmdFileMode_Click ( cmdFileMode , e ) ;
						break ;
						case Keys.R :
							cmdResourceMode_Click ( cmdResourceMode , e ) ;
						break ;
					}
				else 
					switch ( e.KeyCode )
					{
						case Keys.Enter :
							
							if ( ActiveControl == tbPassword )
							{ }
							else 

							{
								e.Handled = true ;
								if ( ActiveControl == null )
									tbSiteName.Focus () ;
								else
								{
									box = ActiveControl as ComboBox ;
									if ( box != null )
									{
										if ( box.DroppedDown )
										{
											box.DroppedDown = false ;
											return ;
										}
									}
									if ( ( ActiveControl == tbWebroot ) || ( ActiveControl == cbAssemblies ) )
										cmdStart_Click ( cmdStart , e ) ;
									else API.SendSingleKey ( API.VK.Tab ) ;
								}
							}
						break ;
						case Keys.Cancel :
							e.Handled = true ;
							box = ActiveControl as ComboBox ;
							if ( box != null ) box.DroppedDown = true ;
						break ;
					}
			}
			catch { }
			base.OnKeyDown ( e ) ;
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
				cmdResourceMode.Font = Font ;
				cmdFileMode.Font = boldFont ;
				gbAssemblies.Visible = false ;
				gbWebroot.Visible = true ;
				checkFolderSelection ( false , false ) ;
			}
			else
			{
				cmdResourceMode.BackColor = SystemColors.Window ;
				cmdFileMode.BackColor = SystemColors.ButtonFace ;
				cmdResourceMode.Font = boldFont ;
				cmdFileMode.Font = Font ;
				gbAssemblies.Visible = true ;
				gbWebroot.Visible = false ;
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
		/// Webroot or assembly path(depending on mode property value)
		/// </summary>
		public string source 
		{ 
			get => _mode == StartServerMode.fileServer ? webroot : selectedAssemblySource ; 
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
			try
			{
				( lastControl = cbAssemblies ).Focus () ;
			}
			catch { }
		}
		/// <summary>
		/// When user click "Filebased server" button
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdFileMode_Click ( object sender , EventArgs e )
		{
			mode = StartServerMode.fileServer ;
			try
			{
				( lastControl = tbWebroot ).Focus () ;
			}
			catch { }
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
			setSiteUriText () ;

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
		private void cmdSelectPath_Click ( object sender , EventArgs e )
        {
			folders.RootFolder = Environment.SpecialFolder.MyComputer ;
			folders.SelectedPath = tbWebroot.Text ;
			if ( folders.ShowDialog ( this ) == DialogResult.OK )
				tbWebroot.Text = folders.SelectedPath ;
        }
		/// <summary>
		/// This event handler opens file dialog to for user to choose certificate file
		/// </summary>
		/// <param name="sender">(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdSelectCertificate_Click ( object sender , EventArgs e )
		{
			openCertificateDialog.FileName = tbCertificate.Text ;
			if ( openCertificateDialog.ShowDialog () == DialogResult.OK )
			{
				tbCertificate.Text = openCertificateDialog.FileName ;
				showCertificatePassword () ;
			}
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
		/// <summary>
		/// Checks current certificate state(no sertificate, not tested, loaded, error or valid
		/// </summary>
		/// <returns>Returns current certificate state(no sertificate, not tested, loaded, error or valid</returns>
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
		/// <summary>
		/// Checks current certificate state and change visual state accordingly
		/// </summary>
		/// <param name="raiseEvents">When this parameters true, certificateLoadFailure, certificateFailedOnServer and certificateFailedOnClient events may be fired</param>
		/// <param name="focusErrorControl">>When this parameters true certificate text box may be focused</param>
		/// <returns>Returns true if certificate is loaded and tested, otherwise false</returns>
		protected bool checkAndReflectCertificate ( bool raiseEvents , bool focusErrorControl )
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
							{
								showCertificatePassword () ;
								if ( tbPassword.Text != "" ) cmdAcceptPassword_Click ( cmdAcceptPassword , new EventArgs () ) ;
							}
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
			if ( !checkAndReflectCertificate ( raiseEvents , focusErrorControl ) ) return false ;

			if ( mode == StartServerMode.fileServer )
			{
				if ( !checkFolderSelection ( raiseEvents , focusErrorControl ) ) return false ;
			}
			else 
			{
				if ( !checkAssemlySelection ( raiseEvents , focusErrorControl ) ) return false ;
			}

			if ( !checkPort ( raiseEvents ) ) return false ;

			createConfigData () ;
			return true ;
		}
		private void cmdStart_Click ( object sender , EventArgs e )
		{
			if ( validateValues ( true , true ) )
				_paremetersChoosen?.Invoke ( this , getStartParameters() ) ;
			else certificateBy = passwordPanel.Visible ? certificateRequestedBy.startButtonClick : certificateRequestedBy.none ; 
		}
		private void showStartParametersClick ( )
		{
			certificateBy = certificateRequestedBy.showParametersClick ;
			if ( validateValues ( true , true ) ) 
			{
				certificateBy = certificateRequestedBy.none ;
				_showStartParameters?.Invoke ( this , getStartParameters () ) ;
			}

		}
		/// <summary>
		/// Creates new HttpStartParameters instance filled with data from this form
		/// </summary>
		/// <returns>Returns new HttpStartParameters instance filled with data from this form</returns>
		public HttpStartParameters getStartParameters ()
		{ 
			return 
				new HttpStartParameters ( mode , port , source , siteUri == null ? "" : siteUri.Host , 
											cbProtocol.SelectedIndex > 0 ? tbCertificate.Text : "" , 
											tbPassword.Text , sslProtocol , true ) ;
		}
		//public void loadFromStartParameters ( HttpStartParameters startParameters )
		//{
		//	loadFromStartParameters ( startParameters , null ) ;
		//}
		//public void loadFromStartParameters ( HttpStartParameters startParameters , X509Certificate2 certificate )
		//{
		//	mode = startParameters.mode ;
		//	cbProtocol.SelectedIndexChanged -= cbProtocol_SelectedIndexChanged ;
		//	tbCertificate.TextChanged -= tbCertificate_TextChanged ;
		//	cbAssemblies.SelectedIndexChanged -= cbAssemblies_SelectedIndexChanged ;
		//	tbPort.Text = startParameters.port.ToString() ;
		//	tbSiteName.Text = string.IsNullOrEmpty ( startParameters.sitename ) ? "localhost" : startParameters.sitename ;
		//	tbPassword.Text = _certificatePassword = startParameters.sslCertificatePassword ;
		//	_loadedCertificate = certificate ;
		//	_certificate = certificate ;
		//	_certificateClientError = null ;
		//	_certificateServerError = null ;
		//	_certificateLoadError = null ;
		//	if ( !string.IsNullOrEmpty ( startParameters.sslCertificateSource ) ) tbCertificate.Text = startParameters.sslCertificateSource ;
		//	if ( certificate == null )
		//		cbProtocol.SelectedIndex = 0 ;
		//	else 
		//	{ 
		//		_certificateFilePath =
		//		tbCertificate.Text = startParameters.sslCertificateSource ; //this delete cerificate
		//		switch ( startParameters.sslProtocol )
		//		{
		//			case SslProtocols.Tls13 :
		//				cbProtocol.SelectedIndex = 2 ;
		//			break ;
		//			case SslProtocols.Tls12 :
		//			default :
		//				cbProtocol.SelectedIndex = 1 ;
		//			break ;
		//		}
		//		_loadedCertificate = 
		//		_certificate = certificate ; //!!!!again
		//	}
		//	if ( startParameters.mode == StartServerMode.fileServer )
		//		tbWebroot.Text = startParameters.source ;
		//	else
		//	{
				
		//		int i = findAssemblyItemIndex ( startParameters.source ) ;
		//		if ( i == -1 )
		//			try
		//			{
		//				insertLoadedAssembly ( AssemblyItem.loadAssemblyItem ( _assemblyPath = startParameters.source ) ) ;
		//			}
		//			catch { }
		//		else cbAssemblies.SelectedIndex = i ;
		//	}
		//	cbProtocol.SelectedIndexChanged += cbProtocol_SelectedIndexChanged ;
		//	tbCertificate.TextChanged += tbCertificate_TextChanged ;
		//	cbAssemblies.SelectedIndexChanged += cbAssemblies_SelectedIndexChanged ;
		//	cbAssemblies_SelectedIndexChanged ( cbAssemblies , new EventArgs () ) ;
		//	if ( mode == StartServerMode.fileServer )
		//		cmdFileMode_Click ( cmdFileMode , new EventArgs () ) ;
		//	else cmdResourceMode_Click ( cmdResourceMode, new EventArgs () ) ;
		//	validateValues ( false , false ) ;
		//}
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
				case Keys.Escape :
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
			if ( e.KeyChar == '\u0016' ) return ;
			if ( e.KeyChar == '\u0018' ) return ;
			if ( e.KeyChar == '\u0003' ) return ;
			
			e.Handled = true ; // this here not at the begin

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
				int mc = QuickStartForm.matchCount ( newText , ( ( AssemblyItem )  items [ i ] ).lowCaseName ) ;
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
				int mc = QuickStartForm.matchCount ( newText , items [ i ].ToString().ToLower() ) ;
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
			mainLayout.Enabled = true ; //!!!
			passwordPanel.Enabled = true ;				
			passwordPanel.Visible = false ;				
			_certificate = certificateTest.certificate ;
			_certificateFilePath = certificateTest.source ;
			_certificateLoadError = certificateTest.certificateLoadError ;
			_certificateClientError = certificateTest.certificateClientError ;
			_certificateServerError = certificateTest.certificateServerError ;
			tbCertificate.BackColor = SystemColors.Window ;
			_certificateAccepted?.Invoke ( this , certificate ) ;
			switch ( certificateBy )
			{
				case certificateRequestedBy.startButtonClick :
					if ( validateValues ( true , true ) ) _paremetersChoosen?.Invoke ( this , getStartParameters () ) ;
				break ;
				case certificateRequestedBy.showParametersClick :
					_showStartParameters?.Invoke ( this , getStartParameters () ) ;
				break ;
			}
			certificateBy = certificateRequestedBy.none ;
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
					//|| ( passwordVisible != gbPassword.Visible ) ) 
				{
					mainLayoutBitmap.Dispose () ;
					mainLayoutBitmap = null ;
				}
			if ( mainLayoutBitmap == null ) mainLayoutBitmap = new Bitmap ( mainLayout.Width , mainLayout.Height ) ;
			mainLayout.DrawToBitmap ( mainLayoutBitmap , new Rectangle ( Point.Empty , mainLayout.Size ) ) ;
			
			drawPasswordPanelBackground ( gbPassword.Bounds ) ;
			passwordPanel.BackgroundImageLayout = ImageLayout.None ;
			passwordPanel.BackgroundImage = mainLayoutBitmap ;
			try
			{
				passwordPanel.Visible = true ;
				mainLayout.Enabled = false ; //!!!
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
			if ( passwordPanel.Visible ) setCertificatePasswordBackground () ;
		}
		private void cmdAcceptPassword_Click ( object sender, EventArgs e )
		{
			_loadedCertificate = null ;
			_certificateLoadError = null ;
			_certificateClientError = null ;
			_certificateServerError = null ;
			try
			{ 
				if ( tbSiteName.Text == "" ) tbSiteName.Text = "localhost" ;
				runningTest = new CertificateTest ( tbCertificate.Text , tbPassword.Text , sslProtocol , port, tbSiteName.Text ) ;
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
			BeginInvoke( (Delegate)(() =>
			{
				passwordPanel.Enabled = true ;
				UseWaitCursor = false ;
				tbSiteName.Text = runningTest.siteName ; //??
				cmdStartCertificateTest_Click ( this , new EventArgs () ) ;
				//tbSiteName.Focus () ;
			}) ) ;
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
			mainLayout.Enabled = true ; //!!!
			passwordPanel.Visible = false ;
		}
		
		/// <summary>
		/// This method checks if folder specified in tbWebroot(TextBox) is exisitng 
		/// and set(enables/disables) cmdStart button if raiseEvent flag us up
		/// </summary>
		/// <param name="raiseEvent">When this is true and webroot folder is bad, invalidWebrootFolder event is triggered </param>
		private bool checkAssemlySelection ( bool raiseEvent , bool focusOnError )
		{
			cbAssemblies_SelectedIndexChanged ( cbAssemblies , new EventArgs ()) ; //!!!
			if ( _resourceAssembly == null )
			{
				if ( focusOnError ) cbAssemblies.Focus () ;
				if ( raiseEvent ) _invalidAssemblySelection?.Invoke ( this , cbAssemblies.Text ); ;
				return false ;
			}
			return true  ;
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
				if ( raiseEvent ) _invalidWebrootFolder?.Invoke ( this , tbWebroot.Text ) ;
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
			if ( _assemblyPath != "" ) openAssemblyDialog.FileName = _assemblyPath ;
			if ( openAssemblyDialog.ShowDialog () == DialogResult.OK )
				try
				{
					insertLoadedAssembly ( AssemblyItem.loadAssemblyItem ( _assemblyPath = openAssemblyDialog.FileName ) ) ;
					return ;
				}
				catch ( Exception x )
				{
					_assemblyLoadFailed?.Invoke ( this, new ErrorEventArgs ( x ) ) ;
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
		/// Returns the assembly corresponding to the given source
		/// </summary>
		/// <param name="source">Assembly name, assembly full name or assembly location</param>
		protected Assembly findAssembly ( string source )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			int c = items.Count ;
			source = source.ToLower () ;
			for ( int i = 0 ; i < c ; i++ )
			{
				Assembly assembly = ( ( AssemblyItem ) items [ i ] ).assembly ;
				if ( assembly.Location.ToLower() == source ) return assembly ;
				if ( assembly.FullName.ToLower() == source ) return assembly ;
				if ( assembly.GetName().Name.ToLower() == source ) return assembly ;
			}
			return null ;
		}
		/// <summary>
		/// Returns the assembly corresponding to the given source
		/// </summary>
		/// <param name="source">Assembly name, assembly full name or assembly location</param>
		protected int findAssemblyItemIndex ( string source )
		{
			ComboBox.ObjectCollection items = cbAssemblies.Items ;
			int c = items.Count ;
			source = source.ToLower () ;
			for ( int i = 0 ; i < c ; i++ )
			{
				Assembly assembly = ( ( AssemblyItem ) items [ i ] ).assembly ;
				if ( assembly.Location.ToLower() == source ) return i ;
				if ( assembly.FullName.ToLower() == source ) return i ;
				if ( assembly.GetName().Name.ToLower() == source ) return i ;
			}
			return -1 ;
		}
		/// <summary>
		/// When "assemblies" list index is changed this event hanler calls setAssembliesBackColor() method in order to 
		/// set "assemblies" checkbox color and/or activate openAssemblyDialog(OpenFileDialog)
		/// </summary>
		/// <param name="sender">cbAssemblies(ComboBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbAssemblies_SelectedIndexChanged ( object sender , EventArgs e )
		{
			if ( cbAssemblies.SelectedIndex == -1 )
			{
				_resourceAssemblySource = "" ;
				_resourceAssembly = null ;
			}
			else 
			{
				_resourceAssembly = ( ( AssemblyItem ) cbAssemblies.SelectedItem ).assembly ;
				_resourceAssemblySource = cbAssemblies.SelectedItem.ToString () [ 0 ] == '<' ? _resourceAssembly.Location : _resourceAssembly.FullName ; 
			}
				
			setAssebliesBackColor () ;
			//if ( mode == StartServerMode.resourceServer )
			//	cmdStart.Enabled = ( _resourceAssembly != null ) && 
			//		( ( getCerrtificateState () & CerrtificateState.badMask ) == CerrtificateState.none ) ;
		}
		/// <summary>
		/// Set proper asseblies text box background color
		/// </summary>
		protected void setAssebliesBackColor ()
		{
			cbAssemblies.BackColor = 
				( cbAssemblies.SelectedIndex == -1 ? false : cbAssemblies.Text == cbAssemblies.SelectedItem.ToString () ) 
				? cbAssemblies.Focused ? SystemColors.Window : inactiveEditBack : Color.MistyRose ;
		}
		/// <summary>
		/// Set proper certificate text box background color
		/// </summary>
		protected void setCertificateBackColor ()
		{
			checkAndReflectCertificate ( false , false ) ;
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
		/// Currently selected assembly source
		/// </summary>
		public string selectedAssemblySource
		{
			get => cbAssemblies.SelectedIndex == -1 ? null : ( ( AssemblyItem ) cbAssemblies.SelectedItem ).source ;
		}
		

			/// <summary>
		/// Auxiliary variable for the paremetersChoosen event
		/// </summary>
		protected EventHandler<HttpStartParameters> _paremetersChoosen ;
		/// <summary>
		/// Raised when user choose file based server and click on start button
		/// </summary>
		public event EventHandler<HttpStartParameters> paremetersChoosen 
		{
			add => _paremetersChoosen += value ;
			remove => _paremetersChoosen -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the showStartParameters event
		/// </summary>
		protected EventHandler<HttpStartParameters> _showStartParameters;
		/// <summary>
		/// Raised when user choose to show command line parameters created from this form data
		/// </summary>
		public event EventHandler<HttpStartParameters> showStartParameters 
		{
			add => _showStartParameters += value ;
			remove => _showStartParameters -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the invalidAssemblySelection event
		/// </summary>
		protected EventHandler<string> _invalidAssemblySelection  ;
		/// <summary>
		/// Raised when message about invalid resource assembly selection should be placed from host/owner form(you do it)
		/// </summary>
		public event EventHandler<string> invalidAssemblySelection 
		{
			add => _invalidAssemblySelection += value ;
			remove => _invalidAssemblySelection -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the invalidWebrootFolder event
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
		/// Auxiliary variable for the certificateAccepted event
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
		/// Auxiliary variable for the assemblyLoadFailed event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _assemblyLoadFailed ;
		/// <summary>
		/// Raised when assembly loading failed
		/// </summary>
		public event EventHandler<ErrorEventArgs> assemblyLoadFailed 
		{
			add => _assemblyLoadFailed += value ;
			remove => _assemblyLoadFailed -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the UIErrorRaised event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _UIErrorRaised ;
		/// <summary>
		/// UI error/warning message
		/// </summary>
		public event EventHandler<ErrorEventArgs> UIErrorRaised 
		{
			add => _UIErrorRaised += value ;
			remove => _UIErrorRaised -= value ;
		}
		/// <summary>
		/// Auxiliary variable for the resourceViewNeeded event
		/// </summary>
		protected EventHandler<Assembly> _resourceViewNeeded ;
		/// <summary>
		/// When user activates resource view for an assembly
		/// </summary>
		public event EventHandler<Assembly> resourceViewNeeded  
		{
			add => _resourceViewNeeded += value ;
			remove => _resourceViewNeeded -= value ;
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
			if ( disposing && ( components != null ) ) components.Dispose() ;
			base.Dispose ( disposing ) ;
		}       

		private void cbProtocol_SelectedIndexChanged ( object sender , EventArgs e )
		{
			gbCertificate.Enabled = cbProtocol.SelectedIndex > 0 ;
			tbCertificate_TextChanged ( tbCertificate , e ) ;
			setSiteUriText () ;
		}

		private void cbProtocol_TextChanged ( object sender , EventArgs e )
		{
			cbProtocol_SelectedIndexChanged ( cbProtocol , e ) ;
		}

		private void cbAssemblies_Enter ( object sender , EventArgs e )
		{
			lastControl = cbAssemblies ;
			setAssebliesBackColor () ;
		}

		private void tbSiteName_Enter ( object sender , EventArgs e )
		{
			lastControl = tbSiteName ;
			tbSiteName.BackColor = SystemColors.Window ;
		}
		private void tbPort_Enter ( object sender, EventArgs e )
		{
			lastControl = tbPort ;
			tbPort.BackColor = SystemColors.Window ;
		}
		private void cbProtocol_Enter ( object sender , EventArgs e )
		{
			lastControl = cbProtocol ;
			cbProtocol.BackColor = SystemColors.Window ;
		}
		private void tbCertificate_Enter ( object sender , EventArgs e )
		{
			lastControl = tbCertificate ;
			setCertificateBackColor () ;
		}
		private void tbWebroot_Enter ( object sender, EventArgs e )
		{
			lastControl = tbWebroot ;
			tbWebroot.BackColor = SystemColors.Window ;
		}
		private void cbAssemblies_Leave ( object sender , EventArgs e )
		{
			setAssebliesBackColor () ;
		}

		private void tbCertificate_Leave ( object sender , EventArgs e )
		{
			setCertificateBackColor () ;
		}
		private void cbProtocol_Leave ( object sender, EventArgs e )
		{
			cbProtocol.BackColor = inactiveEditBack ;
		}
		private void tbSiteName_Leave ( object sender , EventArgs e )
		{
			tbSiteName.BackColor = inactiveEditBack ;
		}
		private void tbWebroot_Leave ( object sender, EventArgs e )
		{
			tbWebroot.BackColor = inactiveEditBack ;
		}
		private void tbPort_Leave ( object sender, EventArgs e )
		{
			tbPort.BackColor = inactiveEditBack ;
		}

		private void tbSiteName_TextChanged ( object sender , EventArgs e )
		{
			setSiteUriText () ;
		}
		protected void setSiteUriText ()
		{
			string s = tbSiteName.Text.Trim() ;
			lbSiteUri.Text = s == "" ? "" : ( "http" + ( cbProtocol.SelectedIndex > 0 ? "s" : "" ) + "://" + s + ":" + ( port == 0 ? "(?)" : port.ToString () ) ) ;
		}
		private void tbSiteName_KeyDown ( object sender , KeyEventArgs e )
		{

		}
		protected static EnumItem<SslProtocols> [] _sslProtocols ;
		protected static EnumItem<SslProtocols> [] getSslProtocols ()
		{
			if ( _sslProtocols == null )
				_sslProtocols = new EnumItem<SslProtocols> [ 6 ]
				{
					new EnumItem<SslProtocols> ( "None (operating system default protocol)" , SslProtocols.None ) ,
					new EnumItem<SslProtocols> ( "Defualt (obsolete, SSL 3 and TLS 1.0)" , SslProtocols.Default ) ,
					new EnumItem<SslProtocols> ( "TLS (TLS 1.0, provided for backward compatibility)" , SslProtocols.Tls ) ,
					new EnumItem<SslProtocols> ( "TLS 1.0 (obsolete)" , SslProtocols.Tls11 ) ,
					new EnumItem<SslProtocols> ( "TLS 1.2" , SslProtocols.Tls12 ) ,
					new EnumItem<SslProtocols> ( "TLS 1.3" , SslProtocols.Tls13 ) 	
				} ;
			return _sslProtocols ;
		}
		protected static EnumItem<SslProtocols> [] _sslProtocolsShort ;
		protected static EnumItem<SslProtocols> [] getSslProtocolsShort ()
		{
			if ( _sslProtocolsShort == null )
				_sslProtocolsShort = new EnumItem<SslProtocols> [ 6 ]
				{
					new EnumItem<SslProtocols> ( "OS default" , SslProtocols.None ) ,
					new EnumItem<SslProtocols> ( "SSL 3 or TLS 1.0" , SslProtocols.Default ) ,
					new EnumItem<SslProtocols> ( "TLS 1.0" , SslProtocols.Tls ) ,
					new EnumItem<SslProtocols> ( "TLS 1.0" , SslProtocols.Tls11 ) ,
					new EnumItem<SslProtocols> ( "TLS 1.2" , SslProtocols.Tls12 ) ,
					new EnumItem<SslProtocols> ( "TLS 1.3" , SslProtocols.Tls13 ) 	
				} ;
			return _sslProtocolsShort ;
		}
		public static string getProtocolName ( SslProtocols sslProtocol )
		{
			foreach ( EnumItem<SslProtocols> item in getSslProtocolsShort() )
				if ( item.value == sslProtocol )
					return item.text ;
			return "unknow" ;
		}
		public static string getProtocolDescription ( SslProtocols sslProtocol )
		{
			foreach ( EnumItem<SslProtocols> item in getSslProtocols() )
				if ( item.value == sslProtocol )
					return item.text ;
			return "unknow" ;
		}

		private void assembliesContextMenu_Opening ( object sender, CancelEventArgs e )
		{
			if ( Clipboard.ContainsText () )
			{
				assembliesLine1.Visible = true ;
				assembliesPasteMenuItem.Visible = true ;
			}
			else
			{
				assembliesLine1.Visible = false ;
				assembliesPasteMenuItem.Visible = false ;
			}
			if ( cbAssemblies.SelectionLength > 0 )
			{
				assembliesCutMenuItem.Visible = true ;
				assembliesCopyMenuItem.Visible = true ;
				assembliesLine1.Visible = true ;
			}
			else
			{
				assembliesCutMenuItem.Visible = 
				assembliesCopyMenuItem.Visible = false ;
			}
			// damn, they are not visible yet #@$@!@!
			// assembliesLine1.Visible = assembliesPasteMenuItem.Visible || assembliesCopyMenuItem.Visible || assembliesCutMenuItem.Visible ;
			assembliesShowMenuItem.Visible = resourceAssembly != null ;
		}


		private void assembliesContextMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			try
			{
				if ( e.ClickedItem == assembliesCopyMenuItem )
				{
					if ( cbAssemblies.SelectionLength > 0 ) Clipboard.SetText ( cbAssemblies.SelectedText ) ;
				}
				else if ( e.ClickedItem == assembliesCutMenuItem )
				{
					if ( cbAssemblies.SelectionLength > 0 ) 
					{
						Clipboard.SetText ( cbAssemblies.SelectedText ) ;
						cbAssemblies.SelectedText = "" ;
					}
				}
				else if ( e.ClickedItem == assembliesPasteMenuItem )
				{
					cbAssemblies.SelectedText = Clipboard.GetText() ;
				}
				else if ( e.ClickedItem == assembliesBrowseMenuItem )
				{
					assembliesContextMenu.Hide () ; //!!!
					cmdLoadAssembly_Click ( cmdLoadAssembly , e ) ;
				}
				else if ( e.ClickedItem == assembliesShowMenuItem )
					_resourceViewNeeded?.Invoke ( this ,  resourceAssembly ) ;
			}
			catch { }

		}

		
	
		private void cbAssemblies_MouseDown ( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Right ) 
				if ( !cbAssemblies.Focused )
					cbAssemblies.Focus () ; // dont ask
		}


		private void cmdSelectPath_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{
				tbCertificate.Focus () ; // dont ask
			}
			catch { }
		}

		private void cmdLoadAssembly_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				cbAssemblies.Focus () ; // dont ask
			}
			catch { }
		}

		private void lbSiteUri_MouseEnter ( object sender , EventArgs e )
		{
			lbSiteUri.Font = boldUnderlineFont ;
		}

		private void lbSiteUri_MouseLeave ( object sender , EventArgs e )
		{
			lbSiteUri.Font = boldFont ;
		}

		private void lbSiteUri_MouseDown ( object sender , MouseEventArgs e )
		{
			switch ( e.Button )
			{
				case MouseButtons.Left :
					openSiteUri () ;
				break ;
				case MouseButtons.Right :
				break ;
			}
		}
		private void openSiteUri ()
		{
			try
			{
				Uri uri = new Uri ( lbSiteUri.Text ) ;
				ProcessStartInfo startInfo = new ProcessStartInfo ( uri.ToString () ) ;
				startInfo.UseShellExecute = true ;
				Process.Start ( startInfo ) ;
			}
			catch ( Exception x )
			{
				_UIErrorRaised?.Invoke ( this , new ErrorEventArgs ( x ) ) ;
			}
		}
		private void siteUriContextMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == siteUriOpenItem )
				openSiteUri () ;
			else if ( e.ClickedItem == siteUriCopyItem )
				Clipboard.SetText ( lbSiteUri.Text ) ;
		}

		private void tbSiteName_Resize ( object sender , EventArgs e )
		{
			cmdLoadAssembly.MinimumSize = 
			cmdSelectPath.MinimumSize = 
			cmdSelectCertificate.MinimumSize = new Size ( 0 , tbSiteName.Height ) ;
		}

		private void gbCertificate_Resize ( object sender , EventArgs e )
		{
			statusPanel.Width = gbCertificate.Width ;
			gbWebroot.Width = gbCertificate.Width ;
			gbAssemblies.Width = gbCertificate.Width ;
			gbPassword.Width = gbCertificate.Width ;
			cmdFileMode.Width =
			cmdResourceMode.Width = ( gbCertificate.Width - cmdFileMode.Margin.Horizontal - cmdResourceMode.Margin.Horizontal ) >> 1 ;
			cmdStart.Left = gbCertificate.Width - cmdStart.Width ;
		}


		private void startContextMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == startMenuItem )
				cmdStart_Click ( cmdStart , e ) ;
			else if ( e.ClickedItem == parametersMenuItem )
				showStartParametersClick () ;
		}

		private void button_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{
				if ( Form.ActiveForm == this ) lastControl.Focus () ;
			}
			catch { }
		}

		private void edit_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{ 
				ComboBox box = ActiveControl as ComboBox ;
				if ( box != null )
				{
					if ( !box.DroppedDown )
						( ( Control ) sender ).Focus () ;
				}
			}
			catch { }
		}
	}
}
