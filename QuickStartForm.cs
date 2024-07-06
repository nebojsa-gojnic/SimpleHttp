using System ;
using System.Drawing ;
using System.Collections.Generic ;
using System.Collections.ObjectModel ;
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
using System.Diagnostics ;
using Newtonsoft.Json.Linq ;

//I:\Code\Nodes\PipeMania\PipeManiaService\Resources
//I:\Code\localhost2.pfx
namespace SimpleHttp
{
	public partial class QuickStartForm : Form
	{
		//Personal Information Exchange (*.pkx)|*.pkx
		protected StartServerMode _mode ;
		protected Bitmap mainLayoutBitmap ;
		protected SolidBrush mainLayoutGrayBrush ;
		protected SolidBrush mainLayoutGrayBrushLighter ;
		protected Brush mainLayoutWindowBrush ;
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
		/// Set method for the resourceNamePrefix property
		/// </summary>
		/// <param name="value">New value for the resourceNamePrefix property</param>
		public void setResourceNamePrefix ( string value ) 
		{
			tbResourceNamePrefix.Text = value ;
		}
		/// <summary>
		/// 
		/// </summary>
		public string resourceNamePrefix 
		{
			get => tbResourceNamePrefix.Text ;
			set => setResourceNamePrefix ( value ) ;
		}
		

		/// <summary>
		/// Auxiliary variable for the configData property
		/// </summary>
		protected WebServerConfigData _configData ;
		/// <summary>
		/// Set method for the configData property
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
				string path ;
				string prefix ;
				mode = getMode ( value , out path , out prefix ) ;
				switch ( _mode )
				{
					case StartServerMode.resourceServer :
						insertLoadedAssembly ( AssemblyItem.loadAssemblyItem ( path ) ) ;
						tbResourceNamePrefix.Text = prefix ;
					break ;
					case StartServerMode.fileServer :
						tbWebroot.Text = path == null ? "" : tbWebroot.Text = path ;
					break ;
					default :
						tbWebroot.Text = "" ;
					break ;
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
		/// Set method for the configData property
		/// </summary>
		public static StartServerMode getMode ( WebServerConfigData value , out string path , out string prefix )
		{
			StartServerMode mode = StartServerMode.jsonConfig ;
			path = null ;
			prefix = null ;
			if ( value != null )
			{
				JObject httpServiceConfigData = null ;
				int c = value.services.Count ;
				object obj ;
				foreach ( HttpServiceActivator activator in value.services.Values )
					try
					{
						if ( ( activator.serviceType == typeof ( ResourcesHttpService ) ) || 
							( activator.serviceType.IsSubclassOf ( typeof ( ResourcesHttpService ) ) ) )
						{
							httpServiceConfigData = activator.configData ;
							mode = StartServerMode.resourceServer ;
							obj = httpServiceConfigData [ "resourceNamePrefix" ] ;
							if ( obj != null ) 
							{
								prefix = obj.ToString () ;
							}
							obj = httpServiceConfigData [ "resourceAssemblySource" ] ;
							if ( obj != null ) 
							{
								path = obj.ToString () ;
								break ;
							}
						}
						else if ( ( activator.serviceType == typeof ( FileHttpService ) ) || 
							( activator.serviceType.IsSubclassOf ( typeof ( FileHttpService ) ) ) )
						{
							httpServiceConfigData = activator.configData ;
							mode = StartServerMode.fileServer ;
							obj = httpServiceConfigData [ "webroot" ] ;
							if ( obj != null ) 
							{
								path = obj.ToString () ;
								break ;
							}
						}
					}
					catch { }
			}
			return mode ;				
		}
		/// <summary>
		/// Creates new value for configData property based on current form values
		/// </summary>
		protected void createConfigData ()
		{
			_configData = mode == StartServerMode.resourceServer ?
				new ResourceWebConfigData ( resourceAssemblySource , resourceNamePrefix , port , tbSiteName.Text.Trim () , tbCertificate.Text.Trim () , tbPassword.Text , sslProtocol ) :
				new FileWebConfigData ( tbWebroot.Text.Trim () , port , tbSiteName.Text.Trim () , tbCertificate.Text.Trim () , tbPassword.Text , sslProtocol ) ;
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
			Uri.TryCreate ( uriLabel.Text , new UriCreationOptions () , out uri ) ;
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
			cmdStartOptions.Parent = cmdStart ;
			certificateTests = new Dictionary<string, Dictionary<SslProtocols, CertificateTest>> () ;

			MonitorForm.AssingFlatButtonAppearance ( closeButton ) ;

			titlePanel.BackColor = MonitorForm.titleBackColor ;
			titlePanel.ForeColor = MonitorForm.titleForeColor ;
			runningTest = null ;
			_assemblyPath = "" ;
			certificatePassword = "" ;
			//closeButton.BackColor = MonitorForm.errorEditBackColor ;

			tbPort.BackColor =
			tbSiteName.BackColor =
			tbCertificate.BackColor =
			cbAssemblies.BackColor =
			tbWebroot.BackColor =
			tbResourceNamePrefix.BackColor = 
			cbProtocol.BackColor = MonitorForm.inactiveEditBackColor ;
			
			loadAssemblies () ;
			mainLayoutBitmap = null ;
			mainLayoutGrayBrush = new SolidBrush ( Color.FromArgb ( 150 , Color.Gray ) ) ;
			mainLayoutGrayBrushLighter = new SolidBrush ( Color.FromArgb ( 70 , Color.Gray ) ) ;
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
			gbAssemblies.MouseUp += groupBox_MouseUp ;
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
			base.OnShown ( e ) ;
			cmdStart_Resize ( cmdStart , e ) ;
			Opacity = 1.0 ;
		}
		protected override void OnActivated ( EventArgs e )
		{
			base.OnActivated ( e ) ;
			BeginInvoke ( button_MouseUp  , new object [ 2 ] ) ;
		}
		protected override void OnFontChanged ( EventArgs e )
		{
			MonitorForm.CreateSemiboldFonts ( Font , out boldFont , out boldUnderlineFont ) ;
			uriLabel.Font = boldFont ;
			titleLabel.Font = MonitorForm.GetNewTitleFont ( Font ) ;
			int h = titleLabel.Font.Height ;
			closeButton.Size = new Size ( h , h ) ;
			titlePanel.Height = ( 3 * h ) >> 1 ;
			foreach ( Component component in components.Components )
			{
				Control Control = component as Control ;
				if ( Control != null ) Control.Font = Font ;
			}
			certificateWaitLabel.Font = titleLabel.Font ;
			certificateWaitLabel.Padding = new Padding ( certificateWaitLabel.Font.Height ) ;
			base.OnFontChanged ( e ) ;
		}
		protected override void OnPaintBackground ( PaintEventArgs e )
		{
			base.OnPaintBackground ( e ) ;
			MonitorForm.drawBoxBorder ( e.Graphics , Size ) ;
		}
		protected override void OnResize ( EventArgs e )
		{
			MonitorForm.SetBoxRegion ( this ) ;
			base.OnResize ( e ) ;
		}
		private void mainLayout_Resize( object sender , EventArgs e )
		{
			mainLayout.Location = new Point ( Padding.Left , titlePanel.Bottom ) ;
			Size = new Size ( Padding.Horizontal + mainLayout.Width , Padding.Vertical + mainLayout.Bottom ) ;
			
			//Height = Padding.Vertical + mainLayout.Bottom  ;
		}
		private void certificateWaitLabel_Resize ( object sender , EventArgs e )
		{
			MonitorForm.SetBoxRegion ( certificateWaitLabel ) ;
		}
		
		private void titlePanel_Resize ( object sender , EventArgs e )
		{
			int d = ( titlePanel.Height - closeButton.Height ) >> 1 ;
			closeButton.Location = new Point ( titlePanel.Width - closeButton.Width - d , d ) ;
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
			mainLayout.SuspendLayout () ; //for the first time this actually does something
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
			mainLayout.ResumeLayout () ;
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
		private void closeButton_Click ( object sender , EventArgs e )
		{
			Close () ;
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
					tbPort.BackColor = MonitorForm.errorEditBackColor ;
					if ( raiseEvents ) _invalidPortNumber?.Invoke ( this , new ErrorEventArgs ( new ApplicationException ( "Invalid port number value(" + i.ToString() + "), allowed range is 1-65535" ) ) ) ;
				}
				else 
				{
					tbPort.BackColor = SystemColors.Window ;
					return true ;
				}
			else 
			{
				tbPort.BackColor = MonitorForm.errorEditBackColor ;
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
			try
			{
				openCertificateDialog.InitialDirectory = Path.GetDirectoryName ( tbCertificate.Text  ) ;
				openCertificateDialog.FileName = Path.GetFileName ( tbCertificate.Text ) ;
			}
			catch { }
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
						tbCertificate.BackColor = MonitorForm.errorEditBackColor ;
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
			tbCertificate.BackColor = tbCertificate.Focused ? SystemColors.Window : MonitorForm.inactiveEditBackColor ;		
			return true ;
		}
		protected bool validateValues ( bool raiseEvents , bool focusErrorControl )
		{

			if ( mode == StartServerMode.fileServer )
			{
				if ( !checkFolderSelection ( raiseEvents , focusErrorControl ) ) return false ;
			}
			else 
			{
				if ( !checkAssemlySelection ( raiseEvents , focusErrorControl ) ) return false ;
			}

			if ( !checkPort ( raiseEvents ) ) return false ;
			if ( !checkAndReflectCertificate ( raiseEvents , focusErrorControl ) ) return false ;

			createConfigData () ;
			return true ;
		}
		private void cmdStart_Click ( object sender , EventArgs e )
		{
			if ( validateValues ( true , true ) )
				_paremetersChoosen?.Invoke ( this , getStartParameters() ) ;
			else certificateBy = passwordPanel.Visible ? certificateRequestedBy.startButtonClick : certificateRequestedBy.none ; 
		}
		private void cmdStartOptions_Click ( object sender , EventArgs e )
		{
			startContextMenu.Show ( cmdStartOptions , Point.Empty ) ;
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
				new HttpStartParameters ( mode , port , source , resourceNamePrefix , siteUri == null ? "" : siteUri.Host , 
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
			certificateWaitLabel.Visible = false ;
			if ( _certificateServerError.InnerException != null ) _certificateServerError = _certificateServerError.InnerException ;
			tbCertificate.BackColor = MonitorForm.errorEditBackColor ;
			_certificateFailedOnServer?.Invoke ( this , e ) ;
			passwordPanel.Enabled = true ;
			UseWaitCursor = false ;
			addCertificateTest ( certificateTest ) ;

		}
		protected void onCertificateFailedOnClient ( CertificateTest certificateTest , ErrorEventArgs e )
		{
			UseWaitCursor = false ;
			passwordPanel.Enabled = true ;
			certificateWaitLabel.Visible = false ;
			_certificate = null ;
			_certificateClientError = e.GetException() ;
			tbCertificate.BackColor = MonitorForm.errorEditBackColor ;
			if ( _certificateClientError.InnerException != null ) _certificateClientError = _certificateClientError.InnerException ;
			addCertificateTest ( certificateTest ) ;
			_certificateFailedOnClient?.Invoke ( this , e ) ; ;
		}
		protected void onOpenTcpTestFailed ( CertificateTest certificateTest , ErrorEventArgs e )
		{
			passwordPanel.Enabled = true ;
			UseWaitCursor = false ;
			certificateWaitLabel.Visible = false ;
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
			certificateWaitLabel.Visible = false ;
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
			
			certificateWaitLabel.Visible = false ;
			setCertificatePasswordBackground () ; // passwordPanel.Visible = true   is inside of setCertificatePasswordBackground call
			BeginInvoke ( () =>
			{
				if ( IsDisposed ) return ;
				if ( Form.ActiveForm == this ) tbPassword.Focus () ;
			} ) ;
		}

		/// <summary>
		/// 
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
			
			drawGrayOnMainLayoutBitmap ( ) ;
			passwordPanel.BackgroundImageLayout = ImageLayout.None ;
			passwordPanel.BackgroundImage = mainLayoutBitmap ;
			//passwordPanel.BackColor = Color.Red ;
			try
			{
				passwordPanel.Visible = true ;
				mainLayout.Enabled = false ; //!!!
				passwordPanel.BringToFront () ;
			}
			catch { }
		}
		private void gbPassword_EnabledChange ( object sender , EventArgs e )
		{
			gbPassword.Visible = gbPassword.Enabled ;
			//gbPassword.BackColor = gbPassword.Enabled ? passwordPanel.BackColor : mainLayoutGrayBrush.Color ;
			//tbPassword.BackColor = gbPassword.Enabled ? SystemColors.Window : Color.LightGray ;
			//if ( !gbPassword.Enabled ) e.Graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( Point.Empty , gbPassword.Size ) ) ;
		}
		private void drawGrayOnMainLayoutBitmap ( )
		{
			using ( Graphics graphics = Graphics.FromImage ( mainLayoutBitmap ) )
			{
				graphics.FillRectangle ( mainLayoutGrayBrush ,  new Rectangle ( Point.Empty , mainLayout.Size )  ) ;
				gbPassword.DrawToBitmap ( mainLayoutBitmap , gbPassword.Bounds ) ;
				graphics.FillRectangle ( mainLayoutGrayBrushLighter , gbPassword.Bounds ) ;
				////graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , 0 , mainLayout.Width , panelBounds.Top - 2 ) ) ;
				////graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , panelBounds.Top - 2 , panelBounds.Left - 4 , panelBounds.Height + 6 ) ) ;
				////graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( 0 , panelBounds.Bottom + 4 , mainLayout.Width , mainLayout.Height - panelBounds.Bottom - 4 ) ) ;
				////graphics.FillRectangle ( mainLayoutGrayBrush , new Rectangle ( panelBounds.Right + 4 , panelBounds.Top - 2 , mainLayout.Width - panelBounds.Right + 4 , panelBounds.Height + 6  ) ) ;
				
				////graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 4 , panelBounds.Top - 2 , panelBounds.Width + 8 , panelBounds.Height + 6 ) ) ;

				//graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 5 , panelBounds.Top - 3 , panelBounds.Width + 10 , panelBounds.Height + 7 ) ) ;

				//graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Left - 6 , panelBounds.Top - 2 , 1 , panelBounds.Height + 5 ) ) ;
				//graphics.FillRectangle ( mainLayoutWindowBrush , new Rectangle ( panelBounds.Right + 5 , panelBounds.Top - 2 , 1 , panelBounds.Height + 5 ) ) ;
				
			}
		}
		private void passwordPanel_Resize ( object sender , EventArgs e )
		{
			gbPassword.Location = new Point ( ( passwordPanel.Width - gbPassword.Width ) >> 1 , gbCertificate.Bottom ) ;
			int h1 = ClientSize.Height - gbPassword.Bottom ;
			certificateWaitLabel.MaximumSize = passwordPanel.Size ;
			certificateWaitLabel.Location = new Point ( ( ClientSize.Width - certificateWaitLabel.Width ) >> 1 , ( gbPassword.Top - certificateWaitLabel.Height ) >> 1 ) ;
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
				certificateWaitLabel.Visible = false ;
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
				certificateWaitLabel.Visible = true ;
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
			//Thread.Sleep ( 10000 ) ;
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
				tbWebroot.BackColor = tbWebroot.Focused ? SystemColors.Window : MonitorForm.inactiveEditBackColor ;
				return true ;
			}
			else 
			{
				tbWebroot.BackColor = MonitorForm.errorEditBackColor ;
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
			try
			{
				openAssemblyDialog.InitialDirectory = Path.GetDirectoryName ( tbCertificate.Text  ) ;
				openAssemblyDialog.FileName = Path.GetFileName ( tbCertificate.Text ) ;
			}
			catch { }
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
			if ( newItem == null ) return ;
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
				_resourceAssemblySource = cbAssemblies.SelectedItem.ToString () [ 0 ] == '<' ? ResourcesHttpService.ResourcesHttpServiceData.getAssemlyLocation ( _resourceAssembly ) : _resourceAssembly.FullName ; 
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
				? cbAssemblies.Focused ? SystemColors.Window : MonitorForm.inactiveEditBackColor : MonitorForm.errorEditBackColor ;
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
		private void tbWebroot_TextChange ( object sender, EventArgs e )
		{
			if ( !tbWebroot.Focused ) checkFolderSelection ( false , false ) ;
		}
		private void tbResourceNamePrefix_Enter ( object sender, EventArgs e )
		{
			
			lastControl = tbResourceNamePrefix ;
			tbResourceNamePrefix.BackColor = SystemColors.Window ;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">(TextBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void tbResourceNamePrefix_TextChanged ( object sender, EventArgs e )
		{
			checkPort ( false ) ;
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
			cbProtocol.BackColor = MonitorForm.inactiveEditBackColor ;
		}
		private void tbSiteName_Leave ( object sender , EventArgs e )
		{
			tbSiteName.BackColor = MonitorForm.inactiveEditBackColor ;
		}
		private void tbWebroot_Leave ( object sender, EventArgs e )
		{
			checkFolderSelection ( false , false ) ;
		}
		private void tbPort_Leave ( object sender, EventArgs e )
		{
			tbPort.BackColor = MonitorForm.inactiveEditBackColor ;
		}
		private void tbResourceNamePrefix_Leave(object sender, EventArgs e)
		{
			tbResourceNamePrefix.BackColor = MonitorForm.inactiveEditBackColor ;
		}
		private void tbSiteName_TextChanged ( object sender , EventArgs e )
		{
			setSiteUriText () ;
		}
		protected void setSiteUriText ()
		{
			string s = tbSiteName.Text.Trim() ;
			uriLabel.Text = s == "" ? "" : ( "http" + ( cbProtocol.SelectedIndex > 0 ? "s" : "" ) + "://" + s + ":" + ( port == 0 ? "(?)" : port.ToString () ) ) ;
		}
		private void tbSiteName_KeyDown ( object sender , KeyEventArgs e )
		{

		}
		/// <summary>
		/// Auxiliary variable for the sslProtocols property.
		/// </summary>
		protected static IDictionary<SslProtocols,string> _sslProtocolsSource ;
		/// <summary>
		/// Auxiliary variable for the sslProtocols property.
		/// </summary>
		protected static IReadOnlyDictionary<SslProtocols,string> _sslProtocols ;
		/// <summary>
		/// Get method for the sslProtocols property.
		/// </summary>
		/// <returns>Unique list of all SslProtocols items with long descriptions.</returns>
		protected static IReadOnlyDictionary<SslProtocols,string> getSslProtocols ()
		{
			if ( _sslProtocols == null )
				_sslProtocols = new ReadOnlyDictionary<SslProtocols,string> (
					_sslProtocolsSource = new Dictionary <SslProtocols,string> (
						new KeyValuePair<SslProtocols,string> [ 6 ]
						{
							new KeyValuePair<SslProtocols,string> ( SslProtocols.None , "None (operating system default protocol)" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Default ,"Defualt (obsolete, SSL 3 and TLS 1.0)" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls , "TLS (TLS 1.0, provided for backward compatibility)" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls11 , "TLS 1.0 (obsolete)" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls12 , "TLS 1.2" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls13 , "TLS 1.3" ) 	
						} ) ) ;
			return _sslProtocols ;
		}
		/// <summary>
		/// It returns unique list of all SslProtocols items with long descriptions.
		/// </summary>
		public static IReadOnlyDictionary<SslProtocols,string> sslProtocols 
		{
			get=> getSslProtocols () ;
		}
		/// <summary>
		/// Auxiliary variable for the sslProtocolsShort property.
		/// </summary>
		protected static IDictionary<SslProtocols,string> _sslProtocolsShortSource ;
		/// <summary>
		/// Auxiliary variable for the sslProtocolsShort property.
		/// </summary>
		protected static IReadOnlyDictionary<SslProtocols,string> _sslProtocolsShort ;
		/// <summary>
		/// Get method for the sslProtocolsShort property.
		/// </summary>
		protected static IReadOnlyDictionary<SslProtocols,string>getSslProtocolsShort ()
		{
			
			if ( _sslProtocolsShort == null )
				_sslProtocolsShort = new ReadOnlyDictionary <SslProtocols,string> (
					_sslProtocolsShortSource = new Dictionary<SslProtocols,string> ( 
						new KeyValuePair<SslProtocols,string> [ 6 ]
						{
							new KeyValuePair<SslProtocols,string> ( SslProtocols.None , "OS default" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Default , "SSL 3 or TLS 1.0" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls , "TLS 1.0" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls11 , "TLS 1.0" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls12 , "TLS 1.2" ) ,
							new KeyValuePair<SslProtocols,string> ( SslProtocols.Tls13 , "TLS 1.3" ) 
						} ) ) ;
			return _sslProtocolsShort ;
		}
		/// <summary>
		/// It returns unique list of all SslProtocols items with short descriptions.
		/// </summary>
		public static IReadOnlyDictionary<SslProtocols,string> sslProtocolsShort 
		{
			get=> getSslProtocolsShort () ;
		}
		/// <summary>
		/// Returns SslProtocls value that coresponds to given short name by searching throught the sslProtocolsShort array of KeyValuePair&lt;SslProtocols,string&gt;
		/// </summary>
		/// <param name="shortName">Short name to look for</param>
		/// <returns>Returns SslProtocls value that coresponds to given short name or SslProtocols.None if nothing found</returns>
		public static SslProtocols getProtocolByName ( string shortName )
		{
			foreach ( KeyValuePair<SslProtocols,string> item in sslProtocols )
				if ( item.Value == shortName )
					return item.Key ;
			return SslProtocols.None ;
		}
		/// <summary>
		/// Returns SslProtocls value that coresponds to given long name by searching throught the sslProtocols array of KeyValuePair&lt;SslProtocols,string&gt;
		/// </summary>
		/// <param name="longName">Long name/description to look for</param>
		/// <returns>Returns SslProtocls value that coresponds to given short name or SslProtocols.None if nothing found</returns>
		public static SslProtocols getProtocolDescription ( string longName )
		{
			foreach ( KeyValuePair<SslProtocols,string> item in getSslProtocols() )
				if ( item.Value == longName )
					return item.Key ;
			return SslProtocols.None ;
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

		
		private void assembliesCopyMenuItem_Click ( object sender, EventArgs e )
		{
			if ( cbAssemblies.SelectionLength > 0 ) Clipboard.SetText ( cbAssemblies.SelectedText ) ;
		}
		private void assembliesCutMenuItem_Click ( object sender, EventArgs e )
		{
			Clipboard.SetText ( cbAssemblies.SelectedText ) ;
			cbAssemblies.SelectedText = "" ;
		}
		private void assembliesPasteMenuItem_Click ( object sender, EventArgs e )
		{
			cbAssemblies.SelectedText = Clipboard.GetText() ;
		}
		private void assembliesBrowseMenuItem_Click ( object sender, EventArgs e )
		{
			assembliesContextMenu.Hide () ; //!!!
			cmdLoadAssembly_Click ( cmdLoadAssembly , e ) ;
		}
		private void assembliesShowMenuItem_Click ( object sender, EventArgs e )
		{
			_resourceViewNeeded?.Invoke ( this ,  resourceAssembly ) ;
		}


		private void siteUriOpenItem_Click ( object sender , EventArgs e )
		{
			openSiteUri () ;
		}

		private void siteUriCopyItem_Click ( object sender , EventArgs e )
		{
			Clipboard.SetText ( uriLabel.Text ) ;
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

		private void uriLabel_MouseEnter ( object sender , EventArgs e )
		{
			uriLabel.Font = boldUnderlineFont ;
		}

		private void uriLabel_MouseLeave ( object sender , EventArgs e )
		{
			uriLabel.Font = boldFont ;
		}

		private void uriLabel_MouseDown ( object sender , MouseEventArgs e )
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
				Uri uri = new Uri ( uriLabel.Text ) ;
				ProcessStartInfo startInfo = new ProcessStartInfo ( uri.ToString () ) ;
				startInfo.UseShellExecute = true ;
				Process.Start ( startInfo ) ;
			}
			catch ( Exception x )
			{
				_UIErrorRaised?.Invoke ( this , new ErrorEventArgs ( x ) ) ;
			}
		}
		private void cmdStart_Resize ( object sender , EventArgs e )
		{
			int w = cmdStart.Height >> 1 ;
			int h = w * 10 / 11 ;
			cmdStartOptions.Bounds = new Rectangle ( cmdStart.Width - w - 6 , 1 + ( ( cmdStart.Height - h ) >> 1 ) , w , h) ;
		}
		private void cmdStartOptions_Resize ( object sender , EventArgs e )
		{
			Region oldRegion = cmdStartOptions.Region ;
			cmdStartOptions.Region = new Region ( new Rectangle ( 2 , 2 , cmdStartOptions.Width - 4 , cmdStartOptions.Height - 4 ) ) ;
			oldRegion?.Dispose () ;
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


		private void startMenuItem_Click ( object sender , EventArgs e )
		{
			cmdStart_Click ( cmdStart , e ) ;
		}
		private void parametersMenuItem_Click ( object sender , EventArgs e )
		{
			showStartParametersClick () ;
		}
		/// <summary>
		/// Auxiliary variable for then JSONScriptMade event
		/// </summary>
		protected EventHandler<string> _JSONScriptMade  ;
		/// <summary>
		/// When user choose to export JSON text
		/// </summary>
		public event EventHandler<string> JSONScriptMade  
		{
			add => _JSONScriptMade += value ;
			remove => _JSONScriptMade -= value ;
		}
		/// <summary>
		/// Auxiliary variable for then JSONScriptMade event
		/// </summary>
		protected EventHandler<WebServerConfigData> _ExportConfig ;
		/// <summary>
		/// When user choose to export JSON text
		/// </summary>
		public event EventHandler<WebServerConfigData> ExportConfig
		{
			add => _ExportConfig += value ;
			remove => _ExportConfig -= value ;
		}
		private void makeJSONMenuItem_Click ( object sender , EventArgs e )
		{
			createConfigData () ;
			_JSONScriptMade?.Invoke ( this , _configData.GetJSONString ( ) ) ;
			_ExportConfig?.Invoke ( this , _configData ) ;
		}

		private void button_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{
				if ( Form.ActiveForm == this ) lastControl.Focus () ;
			}
			catch { }
		}
		private void cmdStartOptions_MouseUp ( object sender , MouseEventArgs e )
		{
			if ( startContextMenu.Visible ) return ;
			if ( e.Button == MouseButtons.Right ) return ;
			button_MouseUp ( cmdStart , e ) ;
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
