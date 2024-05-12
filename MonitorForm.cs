using System.Reflection;
using System.ComponentModel ;
using System.Runtime.InteropServices ;
using System.IO.Pipes ;
using System.Text ;
using System.Security.AccessControl ;
using System.Security.Cryptography.X509Certificates ;
using System.Net ;
using System.Diagnostics ;
using WebSockets ;
using System.Security.Cryptography ;
using System.Security.Authentication ;
using Newtonsoft.Json.Linq ;
using Newtonsoft.Json ;
using Microsoft.Win32 ;
using System.Text.RegularExpressions;

namespace SimpleHttp
{
	public partial class MonitorForm : Form
	{
		public MonitorForm() : this ( new HttpStartParameters ( new string [ 0 ] ) )
		{
		}
		public MonitorForm ( HttpStartParameters startParameters )
		{
			InitializeComponent() ;
			Visible = false ;
			Opacity =  0.0 ;
			WindowState = FormWindowState.Minimized ; //!!!!

			JsonSerializerSettings settings = new JsonSerializerSettings () ;
			settings.Formatting = Formatting.Indented ;
			jsonSerializer = JsonSerializer.Create ( settings ) ;

			searchSplitter.Controls.Add ( searchSplitterInner = getSplitterInner ( verticalSplitterPainer ) ) ;
			logListSplitter.Controls.Add ( logListSplitterInner = getSplitterInner ( verticalSplitterPainer ) ) ;
			propertiesSplitter.Controls.Add ( propertiesSplitterInner = getSplitterInner ( horizontalSplitterPainer ) ) ;

			requestGrid.Controls.Add ( getGridBottomLine () ) ;
			responseGrid.Controls.Add ( getGridBottomLine () ) ;

			//currentStartParameters =
			programStartParameters = startParameters ;
			KeyPreview = true ;
			_monitorActive = false ;
			normalBackBrush = new SolidBrush ( SystemColors.Window ) ;
			normalInkBrush = new SolidBrush ( SystemColors.WindowText ) ;
			alternateBackBrush = new SolidBrush ( SystemColors.Control ) ;
			alternateInkBrush = new SolidBrush ( SystemColors.ControlText ) ;
			selectedBackBrush = new SolidBrush ( MonitorForm.mixColors ( SystemColors.Highlight , SystemColors.ControlDarkDark ) ) ;
			selectedInkBrush = new SolidBrush ( SystemColors.HighlightText ) ;
			searchBackBrush = new SolidBrush ( MonitorForm.mixColors ( SystemColors.Highlight , SystemColors.ControlLight ) ) ;
			//searchInkBrush = new SolidBrush ( SystemColors.HighlightText ) ;
			searchInkBrush = new SolidBrush ( Color.Yellow ) ;
			errorBackBrush = new SolidBrush ( mixColors ( Color.White , Color.LightSalmon ) ) ;
			alternateErrorBackBrush = new SolidBrush ( mixColors ( Color.White , Color.DarkSalmon ) ) ;
			errorInkBrush = new SolidBrush ( Color.DarkRed ) ;
			alternateErrorInkBrush = new SolidBrush ( Color.DarkRed ) ;
			selectedErrorBackBrush = new SolidBrush ( Color.DarkRed ) ;
			selectedErrorInkBrush = new SolidBrush ( Color.LightYellow ) ;
			buttonBrush = new SolidBrush ( SystemColors.ButtonFace ) ;
			lightPen = new Pen ( SystemColors.ButtonHighlight ) ;
			darkPen = new Pen ( SystemColors.ButtonShadow ) ;
			darkerPen = new Pen ( SystemColors.ControlDarkDark ) ;




			requestGrid.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control ;
			requestGrid.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText ;
			requestGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectedBackBrush.Color ;
			requestGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectedInkBrush.Color ;
			requestGrid.RowsDefaultCellStyle.SelectionBackColor = selectedBackBrush.Color ;
			requestGrid.RowsDefaultCellStyle.SelectionForeColor = selectedInkBrush.Color ;
			responseGrid.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control ;
			responseGrid.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText ;
			responseGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectedBackBrush.Color ;
			responseGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectedInkBrush.Color ;
			responseGrid.RowsDefaultCellStyle.SelectionBackColor = selectedBackBrush.Color ;
			responseGrid.RowsDefaultCellStyle.SelectionForeColor = selectedInkBrush.Color ;

			webServer = null ;
			resourceAssemblyName = null ;

			boldUnderlineFont = new Font ( uriLabel.Font.FontFamily , Font.Size , uriLabel.Font.Style ) ;
			configFileNameLabel.Font = 
			resourceLabel.Font = 
			requestLabel.Font = 
			uriLabel.Font = 
			boldFont = new Font ( boldUnderlineFont , FontStyle.Regular ) ;
			_searchBoxDemanded = getSearchBoxDemanded () ;
		}


		MessageForm messageForm ;
		QuickStartForm quickStartForm ;
		PipeSecurity pipeSecurity ;
		protected ResourcesForm resourcesForm ;
		protected bool closeProgramDemand ;
		protected bool closeProgramConfirmed ;
		protected string webroot ;
		protected string source ;
		protected NamedPipeServerStream recivier ;
		protected string resourceAssemblyName ;
		protected int port ;
		protected Uri siteUri ;
		protected SslProtocols protocol ;
		protected bool autoStarted ;
		protected WebServer webServer ;
		protected JsonSerializer jsonSerializer ;
		/// <summary>
		/// Previous FormWindowState, we need it to react properly when form is restored
		/// </summary>
		protected FormWindowState previousWindowState ;
		/// <summary>
		/// Windows state when form was NOT minimized
		/// </summary>
		protected FormWindowState restoredWindowState ;
		/// <summary>
		/// Starting character position in selected item
		/// </summary>
		protected int searchPosition ;
		/// <summary>
		/// 
		/// </summary>
		protected int searchItemIndex ;
		// <summary>
		/// Selected string length on selected list index text
		/// </summary>
		protected int searchLength ;

		protected SolidBrush normalBackBrush ;
		protected SolidBrush normalInkBrush ;
		protected SolidBrush alternateBackBrush ;
		protected SolidBrush alternateInkBrush ;
		protected SolidBrush selectedBackBrush ;
		protected SolidBrush selectedInkBrush ;
		protected SolidBrush searchBackBrush ;
		protected SolidBrush searchInkBrush ;
		protected SolidBrush selectedErrorInkBrush ;
		protected SolidBrush selectedErrorBackBrush ;
		protected SolidBrush errorInkBrush ;
		protected SolidBrush alternateErrorInkBrush ;
		protected SolidBrush errorBackBrush ;
		protected SolidBrush alternateErrorBackBrush ;
		protected SolidBrush buttonBrush ;
		protected Pen lightPen ;
		protected Pen darkPen ;
		protected Pen darkerPen ;

		protected Font boldFont ;
		protected Font boldUnderlineFont ;
		protected StartServerMode serverMode ;
		/// <summary>
		/// Inital start parameters
		/// </summary>
		protected HttpStartParameters programStartParameters ;
		/// <summary>
		/// Current start parameters
		/// </summary>
		//protected HttpStartParameters currentStartParameters ;
		/// <summary>
		/// Set method for the monitorActive property
		/// </summary>
		/// <param name="value">New value monitorActive property</param>
		protected void setMonitorActive ( bool value )
		{
			_monitorActive = value ;
			setActiveStateIcon () ;
		}
		/// <summary>
		/// Events are logged and dispalyed when this is true 
		/// </summary>
		protected bool _monitorActive ;
		/// <summary>
		/// Events are logged and dispalyed when this is true 
		/// </summary>
		public bool monitorActive 
		{
			get => _monitorActive ;
			set => setMonitorActive ( value ) ;
		}

		/// <summary>
		/// search box width prior to splitter dragging
		/// </summary>
		protected int searchBoxWidth ;
		/// <summary>
		/// Panel inside searchSplitter since Splitter class does not support painting
		/// </summary>
		protected Panel searchSplitterInner ;
		/// <summary>
		/// Panel inside logListSplitter since Splitter class does not support painting
		/// </summary>
		protected Panel logListSplitterInner ;
		/// <summary>
		/// Panel inside propertiesSplitter since Splitter class does not support painting
		/// </summary>
		protected Panel propertiesSplitterInner ;

		public static Color mixColors ( Color c1 , Color c2 )
		{
			return Color.FromArgb ( ( ( int ) c1.A + ( int ) c2.A ) >> 1 , ( ( int ) c1.R + ( int ) c2.R ) >> 1 , ( ( int ) c1.G + ( int ) c2.G ) >> 1 , ( c1.B + c2.B ) >> 1 ) ;
		}
		
		public static Panel getSplitterInner ( PaintEventHandler paintHandler )
		{
			Panel splitterInner = new Panel () ;
			splitterInner.Dock = DockStyle.Fill ;
			//searchSplitterInner.BackColor = SystemColors.ButtonShadow ;
			splitterInner.BorderStyle = BorderStyle.None ;
			splitterInner.Enabled = false ;
			splitterInner.BackColor = SystemColors.ButtonShadow ;
			splitterInner.Paint += paintHandler ;
			return splitterInner ;
		}
		public static Panel getGridBottomLine ()
		{
			Panel panel = new Panel () ;
			panel.Height = 1 ;
			panel.BackColor = SystemColors.ButtonShadow ;
			//pn.BackColor = Color.Red ;
			panel.Dock = DockStyle.Bottom ;
			return panel ;
		}
		
		/// <summary>
		/// Auxiliary variable for the jsonEditorVisible property
		/// </summary>
		private bool _jsonEditorVisible ;
		/// <summary>
		/// Set method for the jsonEditorVisible property
		/// </summary>
		/// <param name="value">New value for the jsonEditorVisible property</param>
		private void setJsonEditorVisible ( bool value )
		{
			if ( value )
			{
				_jsonEditorVisible = true ;
				jsonEditor.Visible = true ;
				midPanel.Visible = false ;
				jsonEditor.BringToFront () ;
			}
			else 
			{
				_jsonEditorVisible = false ;
				jsonEditor.Visible = false ;
				midPanel.Visible = true ;
				midPanel.BringToFront () ;
			}
			viewSwitch.BackgroundImage = images24.Images [ value ? "monitor" : "json" ] ;
		}
		/// <summary>
		/// Hides/shows json editor
		/// </summary>
		public bool jsonEditorVisible
		{
			get => _jsonEditorVisible ;
			set => setJsonEditorVisible ( value ) ;
		}

		/// <summary>
		/// Set method for the propertiesVisible porperty
		/// </summary>
		/// <param name="value">New value for the propertiesVisible porperty</param>
		public void setPropertiesVisible ( bool value )
		{
			if ( value ) 
				showProperties () ;
			else 
			{
				logPanel.Padding = new Padding ( 0 ) ;
				propertiesPanel.Visible = false ;
				logListSplitter.Visible = false ;
			}
		}
		/// <summary>
		/// Right panel visibility(request&amp;respond headers)
		/// </summary>
		public bool propertiesVisible
		{
			get => propertiesPanel.Visible ;
			set => setPropertiesVisible ( value ) ;
		}
		/// <summary>
		/// This starts pipe to reve
		/// </summary>
		protected bool startPipeRecieve ()
		{
			pipeSecurity = new PipeSecurity() ;
			pipeSecurity.AddAccessRule ( new PipeAccessRule ( "Everyone" , PipeAccessRights.FullControl, AccessControlType.Allow ) ) ;
			try
			{
				recivier = NamedPipeServerStreamAcl.Create ( "SimpleHttp" , PipeDirection.In , 1 , PipeTransmissionMode.Byte , PipeOptions.Asynchronous , 65536 , 65536 , pipeSecurity ) ;
			}
			catch 
			{
				BeginInvoke ( Close ) ;
				return false ;
			}
			recivier.WaitForConnectionAsync ().ContinueWith ( onPipeConnected ) ;
			return true ;
		}
		protected override void OnShown ( EventArgs e )
		{
			restoredWindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : WindowState ;
			if ( !startPipeRecieve() ) return ;



			

			string startingMessage = programStartParameters.errorMessage ;
			serverMode = programStartParameters.mode ;
			setTextWidthHint ( null ) ;
			loadSearchBoxWidth () ;
			setTextWidthHint ( null ) ;
			loadSearchBoxWidth () ;

			responseGrid.Height = requestGrid.ColumnHeadersHeight * 4 + 6 ;

			if ( jsonEditorVisible ) API.SetTabWidth ( jsonEditor.Handle , 8 ) ; //why 8?


			propertiesVisible = false ;
			try
			{
				reflectServerStatus ( programStartParameters.configData ) ;
				jsonEditor.Text = json2string ( programStartParameters.configData ) ;
			}
			catch { }
			_jsonConfigFile = programStartParameters.jsonConfigFile ;
			if ( string.IsNullOrWhiteSpace ( startingMessage ) )
			{
				if ( string.IsNullOrWhiteSpace ( programStartParameters.jsonConfigFile ) )
				{

					if ( programStartParameters.autoStart )
					{
						//jsonEditorVisible = false ;
						if ( autoStarted = startWebServer ( programStartParameters.configData , out startingMessage ) ) 
						{
							Visible = false ;
						}
						else
						{
							Opacity = 1.0 ;
							restoreForm ( () =>
							{
								showQuickStartForm ( programStartParameters.configData ) ;
								if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
									showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Bad starting parameters" , 
										startingMessage , "" , "" , "Continue" ) ;
							} ) ;
						}
					}
					else 
					{
						Opacity = 1.0 ;
						restoreForm ( new ThreadStart ( showQuickStartForm ) ) ;
					}	
				}
				else 
				{
					jsonEditorVisible = true ;
					if ( autoStarted = startWebServer ( programStartParameters.configData , out startingMessage ) )
					{
						Visible = false ;
						midPanel.Enabled = true ;
					}
					else
					{
						Opacity = 1.0 ;
						BeginInvoke ( () =>
						{
							if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
								showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Bad starting parameters" , 
									startingMessage , "" , "" , "Continue" ) ;
						} ) ;
					}
				}
			}
			else 
			{
				Opacity = 1.0 ;
				BeginInvoke ( () =>
				{
					showQuickStartForm ( programStartParameters.configData ) ;
					if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
						showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Bad starting parameters" , 
							startingMessage , "" , "" , "Continue" ) ;
				} ) ;
			}	

			//	if ( string.IsNullOrWhiteSpace ( programStartParameters.jsonConfigFile ) )
			//	{
			//		if ( ( messageForm == null ) && ( quickStartForm == null ) )
			//			loadQuickStartForm ( programStartParameters ) ;
			//	}
			//	else
			//	{

			//	}
			OnResize ( e ) ;
			base.OnShown ( e ) ;
        }
		protected override void OnActivated ( EventArgs e )
		{
			if ( WindowState != FormWindowState.Minimized ) Opacity = 1.0 ;
			base.OnActivated ( e ) ;
		}
//|		protected override void OnDeactivate ( EventArgs e )
//		{
//			//Opacity = 0.8 ;
//			base.OnDeactivate ( e ) ;
//		}

		protected void onPipeConnected ( object sender )
		{
			if ( IsDisposed ) return ;
			string line = "" ;
			try
			{
				const int bSize = 65536 ;
				int nRead = bSize ;
				byte[] buffer = new byte [ bSize ] ;
				nRead = recivier.Read ( buffer , 0 , bSize ) ;
				line = Encoding.UTF8.GetString ( buffer , 0 , nRead ) ;
			}
			catch { }
			if ( line.Trim().ToLower () == "show" ) 
				BeginInvoke ( iconMenu_ItemClicked , new object [ 2 ] { iconMenu , new ToolStripItemClickedEventArgs ( showMainWindowMenuItem ) } )  ;
			try
			{
				recivier.Disconnect () ;
				recivier.WaitForConnectionAsync ().ContinueWith ( onPipeConnected ) ;
			}
			catch 
			{
				recivier.Dispose () ;
				recivier = NamedPipeServerStreamAcl.Create ( "SimpleHttp" , PipeDirection.In , 1 , PipeTransmissionMode.Byte , PipeOptions.Asynchronous , 65536 , 65536 , pipeSecurity ) ;

			}
		}
		protected void startJSONConfigMenuItemClick ( )
		{
			if ( jsonEditorVisible ) 
				startServerFromCurrentJSON () ;
			else 
			{
				jsonEditorVisible = true ;
				quickStartForm?.Hide () ;
			}
		}
		protected void startServerFromCurrentJSON ( )
		{
			WebServerConfigData configData = new WebServerConfigData () ;
			try
			{
				quickStartForm?.Close () ;
				serverMode = StartServerMode.jsonConfig ;
				Exception x2 = null ;
				try
				{
					configData.loadFromJSON ( JsonConvert.DeserializeObject <JObject> ( jsonEditor.Text ) ) ;
				}
				catch ( Exception e ) 
				{
					x2 = e ;
				}
				if ( x2 != null ) throw ( x2 ) ;
				
			}
			catch ( Exception x )
			{
				reflectServerStatus ( configData ) ;
				jsonEditorVisible = true ;
				showError ( "Error parsing JSON" , x ) ;
				return ;
			}
			string errorMessage ;
			if ( !startWebServer ( configData , out errorMessage ) )
				showErrorMessage ( "Error starting server" , errorMessage ) ;
		}
		protected void showQuickStartFormAndTakeConfigData ()
		{
			bool wasVisible = quickStartForm == null ? false : quickStartForm.Visible ;
			showQuickStartForm () ;
			if ( !wasVisible )
				try
				{ 
					WebServerConfigData configData = new WebServerConfigData () ;
					configData.loadFromJSON ( JsonConvert.DeserializeObject ( jsonEditor.Text ) as JObject ) ;
					quickStartForm.configData = configData ;
				}
				catch { }
		}
		/// <summary>
		/// Auxiliary variable for the jsonConfigFile 
		/// </summary>
		protected string _jsonConfigFile ;
		public string jsonConfigFile 
		{
			get => _jsonConfigFile ;
		}
		protected WebServerConfigData getConfigData ()
		{
			if ( webServer == null )
				try
				{
					JObject obj = JsonConvert.DeserializeObject ( jsonEditor.Text ) as JObject ;
					WebServerConfigData configData = new WebServerConfigData () ;
					configData.loadFromJSON ( obj ) ;
					return configData ;
				}
				catch
				{
					return null ;
				}
			return webServer.configData ;
		}
		protected void showQuickStartForm ()
		{
				//try
				//{ 
				//	WebServerConfigData configData = new WebServerConfigData () ;
				//	configData.loadFromJSON ( JsonConvert.DeserializeObject ( jsonEditor.Text ) as JObject ) ;
				//	quickStartForm.configData = configData ;
				//}
				//catch { }

			if ( quickStartForm == null ) 
			{
				showQuickStartForm ( getConfigData () ) ; //currentStartParameters == null ? programStartParameters : currentStartParameters ) ;
			}
				//showQuickStartForm ( currentStartParameters.configData , certificate ) ; //currentStartParameters == null ? programStartParameters : currentStartParameters ) ;
			else if ( quickStartForm.Visible )
				quickStartForm.Select () ;
			else
			{
				quickStartForm.Show ( this ) ;
				quickStartForm.configData = getConfigData() ;
			}
			quickStartForm.mode = serverMode ;
		}
		//protected void loadQuickStartForm ( HttpStartParameters startParameters )
		//{
		//	loadCertificate ( startParameters ) ;
		//	loadQuickStartForm ( startParameters , certificate ) ;
		//}
		protected void showQuickStartForm ( WebServerConfigData configData )
		{
			midPanel.Enabled = false ;
			if ( quickStartForm == null )
			{
				quickStartForm = new QuickStartForm ( ) ;
				quickStartForm.Icon = Properties.Resources.mainIcon ;
				quickStartForm.Owner = this ;
				quickStartForm.Show () ;
				quickStartForm.FormClosing += quickStartForm_FormClosing ;	
				quickStartForm.FormClosed += quickStartForm_FormClosed ;
				quickStartForm.paremetersChoosen += quickStartForm_paremetersChoosen ;
				quickStartForm.invalidWebrootFolder += quickStartForm_invalidWebrootFolder ;
				quickStartForm.invalidAssemblySelection += quickStartForm_invalidAssemblySelection ;
				quickStartForm.assemblyLoadFailed += quickStartForm_assemblyLoadFailed ;
				quickStartForm.UIErrorRaised += StartServerForm_UIErrorRaised;
				quickStartForm.certificateFailedOnClient += quickStartForm_certificateFailedOnClient ;
				quickStartForm.certificateFailedOnServer += quickStartForm_certificateFailedOnServer ;
				quickStartForm.invalidPortNumber += quickStartForm_invalidPortNumber ;
				quickStartForm.certificateLoadFailure += quickStartForm_certificateLoadFailure ;
				quickStartForm.certificateAccepted += quickStartForm_certificateAccepted ;
				quickStartForm.openTcpTestFailed += quickStartForm_openTcpTestFailed ;
				quickStartForm.resourceViewNeeded += quickStartForm_resourceViewNeeded ;
				quickStartForm.showStartParameters += quickStartForm_showStartParameters ;
				//quickStartForm.FormClosing += quickStartForm_FormClosing ;
				quickStartForm.Disposed += quickStartForm_Disposed ;
			}
			else 
			{
				quickStartForm.Visible = true ;
				quickStartForm.BringToFront () ;
				quickStartForm.Select () ;
			}
			quickStartForm.configData = configData ;
			//quickStartForm.loadFromStartParameters ( startParameters , certificate ) ;
			//quickStartForm.mode = serverMode ;
			//if ( serverMode == StartServerMode.fileServer )
			//	quickStartForm.webroot = webroot ;
			//else
			//{
			//	if ( resourceAssembly != null )
			//	{
			//		if ( !quickStartForm.setAssemblyListIndex ( resourceAssembly ) )
			//		{
			//			showMessage ( SimpleHttp.Properties.Resources.closeIcon ,
			//				"Invalid assembly" ,
			//				"Assembly \"" + resourceAssembly.GetName().Name + "\" not found" ,
			//				"" , "" , "Continue" ) ;
			//		}
			//	}
			//}
		}

		

		private void quickStartForm_showStartParameters ( object sender, HttpStartParameters e )
		{
			showStartParameters ( "Command line parameters" , e ) ;
		}
		
		private void quickStartForm_resourceViewNeeded ( object sender , Assembly assembly )
		{
			if ( resourcesForm == null )
			{
				resourcesForm = new ResourcesForm ( assembly ) ;
				resourcesForm.Opacity = 0 ;
				resourcesForm.Disposed += resourcesForm_Disposed ;
				resourcesForm.Shown += resourcesForm_Shown ;
				resourcesForm.UIErrorRaised += resourcesForm_UIErrorRaised ;
				//resourcesForm.Icon = Properties.Resources.mainIcon ;
				resourcesForm.Show ( this ) ;
			}
			else 
			{
				resourcesForm.resourceAssembly = assembly ;
				resourcesForm.Show () ;
				resourcesForm.BringToFront () ;
				resourcesForm.Select () ;
			}
		}
		private void resourcesForm_Shown ( object? sender , EventArgs e )
		{
			resourcesForm.Opacity = 1 ;
			resourcesForm.Location = new Point ( 
				Left + ( ( Width - resourcesForm.Width ) >> 1 ) ,
				Top + ( ( Height - resourcesForm.Height ) >> 1 ) ) ;
		}
		private void resourcesForm_UIErrorRaised ( object? sender, ErrorEventArgs e )
		{
			StartServerForm_UIErrorRaised ( sender , e ) ;
		}

		private void resourcesForm_Disposed ( object? sender , EventArgs e )
		{
			if ( sender as ResourcesForm == resourcesForm ) resourcesForm = null ;
		}

		private void StartServerForm_UIErrorRaised ( object? sender, ErrorEventArgs e )
		{
			Exception ex = e.GetException () ;
			showMessage ( SimpleHttp.Properties.Resources.closeIcon , "Minor error" , 
							ex == null ? "Unknow error" : ex.InnerException == null ? ex.Message : ex.InnerException.Message , "" , "" , "Continue" ) ;
		}

		private void quickStartForm_FormClosing ( object? sender, FormClosingEventArgs e )
		{
			if ( e.CloseReason == CloseReason.UserClosing )
			{
				e.Cancel = true ;
				quickStartForm.Hide () ;
				restoreForm () ;
			}
		}
		private void quickStartForm_FormClosed ( object? sender , FormClosedEventArgs e )
		{
			if ( quickStartForm.IsDisposed ) return ;
			quickStartForm.FormClosed -= quickStartForm_FormClosed ; //ah govnari
			quickStartForm.Dispose () ;
			midPanel.Enabled = true ;
			if ( Visible && !IsDisposed && ( WindowState != FormWindowState.Minimized ) )
				restoreForm () ;
			//{
			//	BringToFront () ;
			//	Select () ;
			//}
		}

		private void quickStartForm_certificateAccepted ( object? sender , X509Certificate2 e )
		{
			showMessage ( SimpleHttp.Properties.Resources.greenCheck , "Certificate accepted" , 
					"Client server comunication commited, certificate accepted." , "" , "" , "    OK    " ) ;
		}

		private void quickStartForm_invalidPortNumber ( object? sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Invalid port number" , e.GetException() ) ;
		}

		private void quickStartForm_certificateLoadFailure ( object? sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Cannot load certificate" , e.GetException() ) ;
		}

		private void quickStartForm_Disposed ( object? sender , EventArgs e )
		{
			if ( quickStartForm == ( QuickStartForm ) sender ) quickStartForm = null ;
		}

		private void quickStartForm_invalidWebrootFolder ( object? sender , string folder )
		{
			showMessage ( SimpleHttp.Properties.Resources.textIcon , "Invalid folder" , 
					folder.Trim () == "" ? 
					"No webroot folder specified" :				
					( "Folder not found:\r\n" + folder ) , " Close " , "" , "" ) ;
		}
		private void quickStartForm_invalidAssemblySelection ( object? sender , string assemblyName )
		{
			showMessage ( SimpleHttp.Properties.Resources.textIcon , "Invalid assembly selection" ,
					assemblyName.Trim () == "" ? 
					"Empty assembly selection." :
					"Invalid assembly \"" + assemblyName + "\"." , " Close " , "" , "" ) ;
		}
		protected void setSiteUri ( WebServerConfigData configData )
		{
			try
			{
				siteUri = configData.getSiteUri () ;
				uriLabel.Text = siteUri.ToString () ;
			}
			catch 
			{ 
				uriLabel.Text = "?" ;
			}
		}
		protected void setSiteUri ( bool secure , string siteName , int port )
		{
			try
			{
				siteUri = new Uri ( ( secure ? "https://" : "http://" ) + ( string.IsNullOrWhiteSpace ( siteName ) ? "127.0.0.1" : siteName ) + ":" + port.ToString() ) ;
				uriLabel.Text = siteUri.ToString () ;
			}
			catch 
			{ 
				uriLabel.Text = "?" ;
			}
		}
		private void quickStartForm_paremetersChoosen ( object? sender, HttpStartParameters e )
		{
			string errorMessage ;
			if ( startWebServer ( e.configData , out errorMessage ) )
			{
				quickStartForm.Hide () ;
				restoreForm () ;
			}
			else 
				BeginInvoke ( ()=>
				{
					showErrorMessage ( "Error starting " + ( quickStartForm.mode == StartServerMode.fileServer ? "file" : "resource" ) + " based server" , errorMessage ) ;
				} ) ;

		}
		private void quickStartForm_assemblyLoadFailed ( object sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Error loading assembly" , e.GetException() ) ;
		}
		private void quickStartForm_openTcpTestFailed ( object? sender, ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Cannot make test tpc connection" , e.GetException() ) ;
		}
		private void quickStartForm_certificateFailedOnServer ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( ()=>
			{
				if ( messageForm != null )
					if ( messageForm.Text == "Certificate failed on client side" )
					{
						showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
							"Certificate failed" , 
							"Client side error:\r\n" + 
							messageForm.messageText  + "\r\nServer side error:\r\n" + e.GetException().Message ,
							"" , "" , " Close " ) ;
						return ;
					}
				showError ( "Certificate failed on server side" , e.GetException() ) ;
			} ) ;
		}
		
		private void quickStartForm_certificateFailedOnClient ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( ()=>
			{
				if ( messageForm != null )
					if ( messageForm.Text == "Certificate failed on server side" )
					{
						showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
							"Certificate failed" , 
							"Client side error:\r\n" + 
							e.GetException().Message + "\r\nServer side error:\r\n" + messageForm.messageText ,
							"" , "" , " Close " ) ;
						return ;
					}
				showError ( "Certificate failed on client side" , e.GetException() ) ;
			} ) ;
		}
		//private bool loadCertificate ( HttpStartParameters startParameters ) 
		//{
		//	string errorMessage ;
		//	return loadCertificate ( startParameters , out errorMessage ) ;
		//}
		//private bool loadCertificate ( HttpStartParameters startParameters , out string errorMessage ) 
		//{
		//	errorMessage = "" ;
		//	try
		//	{
		//		if ( !string.IsNullOrEmpty ( programStartParameters.sslCertificateSource ) )
		//			if ( File.Exists ( programStartParameters.sslCertificateSource ) )
		//				certificate = new X509Certificate2 ( programStartParameters.sslCertificateSource , programStartParameters.sslCertificatePassword ) ;
		//	}
		//	catch ( Exception x )
		//	{ 
		//		errorMessage = "Certifacate file error:\r\n" + ( x.InnerException == null ? x.Message : x.InnerException.Message ) ;
		//		return false ;
		//	}
		//	return true ;
		//}
		//private bool startWebServer1 ( HttpStartParameters startParameters , out string errorMessage )
		//{
		//	errorMessage = "" ;
		//	//currentStartParameters = startParameters ;
		//	serverMode = startParameters.mode ;
		//	switch ( serverMode )
		//	{
		//		case StartServerMode.resourceServer :
		//			webroot = "" ;
		//			return startWebServer ( new ResourceWebConfigData ( source = startParameters.source , startParameters.sitename , startParameters.port , startParameters.sslCertificateSource , startParameters.sslCertificatePassword , startParameters.sslProtocol ) , out errorMessage ) ;
		//		case StartServerMode.fileServer :
		//			resourceAssembly = null ;
		//			return startWebServer ( new FileWebConfigData ( source = webroot = startParameters.source , startParameters.sitename , startParameters.port , startParameters.sslCertificateSource , startParameters.sslCertificatePassword , startParameters.sslProtocol ) , out errorMessage ) ;
		//		case StartServerMode.jsonConfig :
		//			try
		//			{ 
		//				WebServerConfigData configData = new WebServerConfigData () ;
		//				configData.loadFromJSONFile ( startParameters.jsonConfigFile ) ;
		//				if ( startParameters.jsonConfigFile != configData.jsonConfigFile )
		//					startParameters = new HttpStartParameters ( configData ) ;
		//				return startWebServer ( configData , out errorMessage ) ;
		//			}
		//			catch ( Exception x )
		//			{
		//				errorMessage = x.Message ;
		//			}
		//		break ;
		//	}
		//			/*
		//	if ( string.IsNullOrEmpty ( currentStartParameters.jsonConfigFile ) )
		//	{
		//		if ( serverMode == StartServerMode.resourceServer )
		//		{
		//			Exception ex = null ;
		//			if ( File.Exists ( source = programStartParameters.source ) )
		//				try
		//				{
		//					resourceAssembly = Assembly.LoadFrom ( programStartParameters.source ) ;
		//				}
		//				catch ( Exception x )
		//				{ 
		//					ex = x ;
		//				}
		//			if ( ex == null )
		//			{
		//				foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies () )
		//					if ( ( assembly.GetName().Name == programStartParameters.source ) || ( assembly.FullName == programStartParameters.source ) ) 
		//					{
		//						resourceAssembly = assembly ;
		//						break ;
		//					}
		//				if ( ( resourceAssembly == null ) && string.IsNullOrEmpty ( errorMessage ) ) errorMessage = "Assembly not found:\r\n\"" + programStartParameters.source + "\"" ;
		//			}
		//			else if ( string.IsNullOrEmpty ( errorMessage ) )
		//				errorMessage = "Cannot load assembly:\r\n\"" + programStartParameters.source + "\"\r\n" + ( ex.InnerException == null ? ex.Message : ex.InnerException.Message ) ;
		//		}
		//		else source = webroot = string.IsNullOrEmpty ( programStartParameters.source ) ? Program.ExecutableFolder () : programStartParameters.source ;
		//	}
		//	else
		//	{
		//		source = webroot = "" ;
		//		resourceAssembly = null ;
		//		try
		//		{ 
		//			WebServerConfigData configData = new WebServerConfigData () ;
		//			configData.loadFromJSONFile ( currentStartParameters.jsonConfigFile ) ;
		//			if ( currentStartParameters.jsonConfigFile != configData.jsonConfigFile )
		//				currentStartParameters = new HttpStartParameters ( configData ) ;
		//			return startWebServer ( configData , out errorMessage ) ;
		//		}
		//		catch ( Exception x )
		//		{
		//			errorMessage = x.Message ;
		//		}
		//	}
		//			*/
		//	//return string.IsNullOrEmpty ( errorMessage ) && loadCertificate ( startParameters , out errorMessage ) ?
		//	//			startWebServer ( startParameters , certificate , resourceAssembly , out errorMessage ) : false ;
		//	errorMessage = "Unknown server mode (" + serverMode.ToString () + ")" ;
		//	return false ;
		//}
		//private bool startWebServer1 ( HttpStartParameters startParameters , X509Certificate2 certificate , Assembly assembly , out string errorMessage )
		//{
		//	isCriticalError = false ;
		//	currentStartParameters = startParameters ;
		//	source = startParameters.source ;
		//	serverMode = startParameters.mode ;
		//	port = startParameters.port ;
		//	protocol = startParameters.sslProtocol ;
		//	resourceAssembly = assembly ;
		//	this.certificate = certificate ;
		//	errorMessage = "" ;
		//	setSiteUri ( !string.IsNullOrEmpty ( startParameters.sslCertificateSource ) , startParameters.sitename , startParameters.port ) ;
		//	if ( resourcesForm != null ) resourcesForm.Hide () ;
		//	try
		//	{
		//		if ( serverMode == StartServerMode.fileServer )
		//		{
		//			this.webroot = source ;
		//			if ( Directory.Exists ( webroot ) )
		//			{
		//				webServer = new WebServer ( 
		//											webServer_clientConnected , webServer_serverResponded ,
		//											webServer_started , webServer_stoped , 
		//											webServer_connectionErrorRaised , 
		//											webServer_criticalErrorRaised , webServer_disposed ) ;
		//				//X509Certificate2 cert = StartServerForm.GenerateSelfSignedCertificate () ; // new  X509Certificate2 ( "C:\\Code\\localhost.pfx" ) ;

		//				//HttpServiceActivator service = new HttpServiceActivator ( typeof ( FileHttpService ) , new FileHttpService.FileHttpServiceData ( webroot ) ) ;
		//				//webServer.addPath ( "/*" , 0 , service ) ;
		//				//webServer.addPath ( "/*/*" , 0 , service ) ;
		//				//webServer.addPath ( "/*/*/*" , 0 , service ) ;
		//				//webServer.Listen ( port , startParameters.sitename , startParameters.certificate , startParameters.password , certificate , protocol ) ;


		//				webServer.Listen ( new FileWebConfigData ( webroot , startParameters.sitename , startParameters.port , startParameters.sslCertificateSource , startParameters.sslCertificatePassword , startParameters.sslProtocol ) ) ;
						
		//				jsonEditor.Text = json2string ( webServer.configData ) ;
		//				jsonEditor.SelectionLength = 0 ;
		//				return true ;
		//			}
		//			else throw new ApplicationException ( "Folder not found(or inaccessible):\r\n\"" + webroot + "\"" ) ;
		//		}
		//		else 
		//		{
		//			if ( resourceAssembly == null )
		//				throw new Exception ( "Null resource assembly" ) ;
		//			else 
		//			{
		//				webServer = new WebServer ( 
		//										webServer_clientConnected , webServer_serverResponded ,
		//										webServer_started , webServer_stoped , webServer_connectionErrorRaised , 
		//										webServer_criticalErrorRaised , webServer_disposed ) ;
		//				HttpServiceActivator service = new HttpServiceActivator ( typeof ( ResourcesHttpService ) , new ResourcesHttpService.ResourcesHttpServiceData ( resourceAssembly ) ) ;

		//				//webServer.addPath ( "/*" , 0 , service ) ;
		//				//webServer.addPath ( "/*/*" , 0 , service ) ;
		//				//webServer.addPath ( "/*/*/*" , 0 , service ) ;
		//				//webServer.Listen ( port , startParameters.sitename , startParameters.certificate , startParameters.password , certificate , protocol ) ;

		//				webServer.Listen ( new ResourceWebConfigData ( resourceAssembly.Location , startParameters.sitename , startParameters.port , startParameters.sslCertificateSource , startParameters.sslCertificatePassword , startParameters.sslProtocol ) ) ;
		//				jsonEditor.Text = json2string ( webServer.configData ) ;
		//				jsonEditor.SelectionLength = 0 ;
		//				return true ;
		//			}
		//		}
		//	}
		//	catch ( Exception x )
		//	{ 
		//		errorMessage = "Error starting " + ( serverMode == StartServerMode.fileServer ? "file" : "resource" ) + " based server.\r\n" + 
		//						( x.InnerException == null ? x.Message : x.InnerException.Message  ) ;
		//	}
		//	return false ;
		//}
		private bool startWebServer ( WebServerConfigData configData , out string errorMessage )
		{
			isCriticalError = false ;
			errorMessage = "" ;
			try
			{
				setSiteUri ( configData ) ;
				//setSiteUri ( !string.IsNullOrEmpty ( configData.sslCertificateSource ) , configData.sitename , port = configData.port ) ;
				protocol = configData.sslProtocol ;
				//certificate = configData.sslCertificate ;
				webServer = new WebServer ( 
													webServer_clientConnected , webServer_serverResponded ,
													webServer_started , webServer_stoped , 
													webServer_connectionErrorRaised , 
													webServer_criticalErrorRaised , webServer_disposed ) ;
				webServer.Listen ( configData ) ;
				return true ;
			}
			catch ( Exception x )
			{ 
				errorMessage = "Error starting server.\r\n" + 
								( x.InnerException == null ? x.Message : x.InnerException.Message  ) ;
			}
			return false ;
		}
		
		protected void webServer_started ( object sender , EventArgs e )
		{
			if ( IsDisposed ) return ;
			if ( webServer == null ) return ;
			if ( webServer == sender as WebServer )
			{
				while ( Handle == IntPtr.Zero )
				{
					if ( IsDisposed ) return ;
					Thread.Sleep ( 500 ) ;
				}
				if ( IsDisposed ) return ;
				BeginInvoke ( new Action<WebServerConfigData>(reflectServerStatus) , new object [ 1 ] { webServer.configData } ) ;
			}
		}
		
		
		protected void webServer_stoped ( object sender , EventArgs e )
		{
			if ( IsDisposed ) return ;
			if ( webServer == null ) return ;
			BeginInvoke ( () =>
			{
				if ( IsDisposed ) return ;
				if ( isCriticalError ) return ;
				reflectServerStatus ( webServer.configData ) ;
			} ) ;
		}
		//protected void reflectServerStatus1 ( WebServer webServer ) 
		//{
		//	if ( IsDisposed ) return ;
		//	if ( webServer == null ) return ;
		//	if ( webServer != this.webServer ) return ;
		//	//if ( autoStarted ) Visible = false ;
		//	string serverStatus = isListening ? "working" : "stoped" ; 
		//	midPanel.Enabled = true ;
		//	configFileNameLabel.Text = currentStartParameters == null ? "<not saved>" :
		//								fileNameOnly ( currentStartParameters.jsonConfigFile ) ;
		//	string t = ( webServer.isSecure ? QuickStartForm.getProtocolName ( webServer.sslProtocol ) : "Flat http" ) + " on port " +  webServer.port.ToString () ;
		//	HttpServiceActivator service = string.IsNullOrEmpty ( currentStartParameters.jsonConfigFile ) ? webServer.getservice ( "/*" ).Value : null ;
		//	setSiteUri ( webServer.configData ) ;
		//	if ( service == null )
		//	{
		//		//setSiteUri ( !string.IsNullOrEmpty ( webServer.configData.sslCertificateSource ) , 
		//		//			webServer.configData.sitename , 
		//		//			port = webServer.configData.port ) ;
		//		if ( webServer.isListening )
		//		{
		//			jsonEditor.Text = json2string ( webServer.configData ) ;
		//			jsonEditor.SelectionLength = 0 ;
		//		}
		//		resourceLabel.Text = "" ;
		//		notifyIcon.Text = ( webServer.isSecure ? QuickStartForm.getProtocolName ( webServer.sslProtocol ) : "Flat http" ) + " on port " +  webServer.port.ToString () ;
		//		resourceTypeLabel.Text = "" ;
				
		//		notifyIcon.ShowBalloonTip ( 3000 , "Http server is " + serverStatus , resourceTypeLabel.Text + " " + resourceLabel.Text  , ToolTipIcon.Info ) ;
		//	}
		//	else 
		//	{
							
		//		notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
		//		//setSiteUri ( !string.IsNullOrEmpty ( currentStartParameters.sslCertificateSource ) , currentStartParameters.sitename , currentStartParameters.port ) ;
		//		Type serviceType = service.serviceType ;
		//		if ( serviceType == typeof ( ResourcesHttpService ) )
		//		{
		//			resourceLabel.Text = service.configData [ "assemblyPath" ].ToString() ;
		//			resourceTypeLabel.Text = uriLabel.Text == "" ? ( t + ", assembly:") : "assembly:" ;
		//			t = t + ", assembly:\r\n" + resourceLabel.Text ;
		//			notifyIcon.ShowBalloonTip ( 3000 , "Resource based http server is " + serverStatus , "Assembly: " + resourceLabel.Text , ToolTipIcon.Info ) ;
		//		}
		//		else if ( serviceType == typeof ( FileHttpService ) )
		//		{

		//			resourceLabel.Text = service.configData [ "webroot" ].ToString() ;
		//			resourceTypeLabel.Text = uriLabel.Text == "" ? ( t + ", webroot:" ) : "webroot:" ;
		//			t = t + ", webroot:\r\n" + resourceLabel.Text ;
		//			notifyIcon.ShowBalloonTip ( 3000 , "File based http server is " + serverStatus , "Web root folder:\r\n" + resourceLabel.Text , ToolTipIcon.Info ) ;
		//		}
		//		else 
		//		{
		//			resourceLabel.Text = "" ;
		//			resourceTypeLabel.Text = uriLabel.Text == "" ? t : "" ;
		//			notifyIcon.ShowBalloonTip ( 3000 , "Http server is working is " + ( isListening ? "working" : "stoped" ) , "Unknown configuartion" , ToolTipIcon.Info ) ;
		//		}
		//		notifyIcon.Text = t.Substring ( 0 , Math.Min ( 127 , t.Length ) ) ;
		//	}
		//	setActiveStateIcon () ;
		//}
		protected void reflectServerStatus ( WebServerConfigData configData )
		{
			string t = ( string.IsNullOrWhiteSpace ( configData.sslCertificateSource ) ? "Flat http" : 
				QuickStartForm.getProtocolName ( configData.sslProtocol ) ) + " on port " + configData.port.ToString () ;
			notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
			setSiteUri ( configData ) ;
			//!string.IsNullOrEmpty ( currentStartParameters.sslCertificateSource ) , currentStartParameters.sitename , currentStartParameters.port ) ;
			bool isListeningActive = isListening ;
			string serverStatus = isListeningActive ? "working" : "stoped" ; 
			//configFileNameLabel.Text = fileNameOnly ( parameters.jsonConfigFile ) ;
			ResourceWebConfigData resourceConfigData = configData as ResourceWebConfigData ;
			if ( resourceConfigData == null ) 
			{ 
				try
				{
					HttpServiceActivator service = configData.services [ "resourceHttpService" ] ;
					if ( service.serviceType == typeof ( ResourcesHttpService ) ) 
					{ 
						resourceConfigData = new ResourceWebConfigData ( 
							service.configData [ "resourceAssemblySource" ].ToString() ,
														configData.sitename , configData.port , 
														configData.sslCertificateSource ,
														configData.sslCertificatePassword ,
														configData.sslProtocol ) ;
						resourceConfigData.loadFromJSON ( configData ) ;
					}
				}
				catch { }
			}
			if ( resourceConfigData == null ) 
			{
				FileWebConfigData fileConfigData = configData as FileWebConfigData ;
				if ( fileConfigData == null ) 
				{ 
					try
					{
						HttpServiceActivator service = configData.services [ "fileHttpService" ] ;
						if ( service.serviceType == typeof ( FileHttpService ) ) 
						{ 
							fileConfigData = new FileWebConfigData ( "" , "" , configData.port , 
															configData.sslCertificateSource ,
															configData.sslCertificatePassword ,
															configData.sslProtocol ) ;
							fileConfigData.loadFromJSON ( configData ) ;
						}
					}
					catch { }
				}
				if ( fileConfigData == null ) 
				{
					//jsonEditor.Text = json2string ( configData ) ;
					resourceLabel.Text = "" ;
					resourceTypeLabel.Text = "" ;
					notifyIcon.ShowBalloonTip ( 3000 , "Http server is " + serverStatus , "Config: " + configFileNameLabel.Text , ToolTipIcon.Info ) ;
				}
				else
				{
					resourceLabel.Text = fileConfigData.webroot ;
					resourceTypeLabel.Text = uriLabel.Text == "" ? ( t + ", webroot:" ) : "webroot:" ;
					t = t + ", webroot:\r\n" + resourceLabel.Text ;
					notifyIcon.ShowBalloonTip ( 3000 , "File based http server is " + serverStatus , "Web root folder:\r\n" + resourceLabel.Text , ToolTipIcon.Info ) ;
					if ( ( webServer != null ) && !isListeningActive )
						restoreForm ( new Action<FileWebConfigData> ( showQuickStartForm ) , new object [ 1 ] { fileConfigData } ) ;
						
				}
			}
			else 
			{
				resourceLabel.Text = resourceAssemblyName = resourceConfigData.assemblySource ;
				resourceTypeLabel.Text = uriLabel.Text == "" ? ( t + ", assembly:") : "assembly:" ;
				t = t + ", assembly:\r\n" + resourceLabel.Text ;
				notifyIcon.ShowBalloonTip ( 3000 , "Resource based http server is " + serverStatus , "Assembly: " + resourceLabel.Text , ToolTipIcon.Info ) ;
				if ( ( webServer != null ) && !isListeningActive )
					restoreForm ( new Action<ResourceWebConfigData> ( showQuickStartForm ) , new object [ 1 ] { resourceConfigData } ) ;
			}
			notifyIcon.Text = t.Substring ( 0 , Math.Min ( 127 , t.Length ) ) ;
			setActiveStateIcon () ;
		}
		public static string fileNameOnly ( string path )
		{
			return ( string.IsNullOrWhiteSpace ( path ) ) ? "<not saved>" : Path.GetFileName ( path ) ;
		}
		/// <summary>
		/// It is always good to have a StringBuilder.
		/// </summary>
		protected StringBuilder stringBuilder ; 
		protected string json2string ( JObject obj )
		{
			if ( stringBuilder  == null ) 
				stringBuilder = new StringBuilder () ;
			else stringBuilder.Clear () ;
			StringWriter sw = new StringWriter ( stringBuilder ) ;
			JsonTextWriter jsonTextWriter = new JsonTextWriter ( sw ) ;
			jsonTextWriter.Formatting = Formatting.Indented ;
			jsonTextWriter.Indentation = 1 ;
			jsonTextWriter.IndentChar = '\t' ;
			jsonSerializer.Serialize ( jsonTextWriter , obj ) ;
			jsonTextWriter.Close () ;
			sw.Dispose () ;
			return stringBuilder.ToString() ;
		}
		protected void setActiveStateIcon ()
		{
			if ( isListening )
			{
				Icon =
				notifyIcon.Icon = monitorActive ? SimpleHttp.Properties.Resources.activeMonitorIcon : SimpleHttp.Properties.Resources.activeIcon ;
				startStopSwitch.BackgroundImage = images24.Images [ "stop" ] ;

				monitorSwitch.BackgroundImage = images24.Images [ monitorActive ? "monYellow" : "monGreen" ] ;

			}
			else 
			{
				startStopSwitch.BackgroundImage = images24.Images [ "play" ] ;
				monitorSwitch.BackgroundImage = images24.Images [ monitorActive ? "monWhiteCheck" : "monWhite" ] ;
			}
		}
		protected bool isCriticalError ;
		protected void webServer_criticalErrorRaised ( object sender , HttpConnectionDetails e )
		{
			webServer_connectionErrorRaised ( sender , e  ) ;
			BeginInvoke ( ()=>
			{
				string s = "Http server is down,\r\n" + ( e.error == null ? "<Uknown error>" : e.error.InnerException == null ? e.error.Message : e.error.InnerException.Message ) ;
				isCriticalError = true ;
				notifyIcon.Text = s.Substring ( 0 , Math.Min ( 127 , s.Length ) ) ;
				Icon = notifyIcon.Icon = SimpleHttp.Properties.Resources.stopIcon ;
				notifyIcon.ShowBalloonTip ( 12000 , "Http server critical error" , s , ToolTipIcon.Info ) ;
			} ) ;
		}
		protected void webServer_connectionErrorRaised ( object sender , HttpConnectionDetails e )
		{
			if ( IsDisposed ) return ;
			if ( webServer == null ) return ;
			webServer_serverResponded ( sender , e ) ;
		}
		protected void webServer_disposed ( object sender , EventArgs e )
		{
			if ( IsDisposed ) return ;
			if ( webServer == null ) return ;
			if ( webServer == sender as WebServer )
			{
				webServer = null ;
			}
		}
		protected int logItemInnerHeight ;
		/// <summary>
		/// I really hate this
		/// </summary>
		protected void calculateItemHeight ()
		{
			logItemInnerHeight = testLabel.Height - testLabel.Padding.Vertical - 1 ;
			Graphics gr = null ;
			using ( gr = Graphics.FromHwnd ( Handle ) )
			{
				logItemInnerHeight = ( int ) gr.MeasureString ( "W|" , logList.Font ).Height ;
			}
			logList.ItemHeight = logItemInnerHeight * 7 / 5 ;
			
		}
		protected override void OnResize ( EventArgs e )
		{
			if ( ( WindowState != FormWindowState.Minimized ) && Visible )
			{ 
				calculateItemHeight () ;
				restoredWindowState = WindowState ;
				Opacity = 1.0 ;
				//if ( API.GetForegroundWindowProc () == Handle ) 
				//	Opacity = 1.0 ;
				//else Opacity = 0.8 ;
				if ( previousWindowState == FormWindowState.Minimized )
				{
					if ( messageForm == null )
					{
						if ( quickStartForm != null )
							BeginInvoke ( () =>
							{
								quickStartForm.BringToFront () ;
								quickStartForm.Select () ;
							} ) ;				
					}
					else 
						BeginInvoke ( ()=>
						{
							messageForm.BringToFront () ;
							messageForm.Select () ;
						} ) ;		
				}
			}
			previousWindowState = WindowState ;
			base.OnResize ( e ) ;
		}

		
		
		/// <summary>
		/// Get method for the selectedConnection property
		/// </summary>
		/// <returns>Retruns value for the selectedConnection property</returns>
		public HttpConnectionDetails getSlectedConnection ()
		{
			return logList.SelectedIndex == -1 ? null : ( ( HttpConnectionItem ) logList.Items [ logList.SelectedIndex ] ).connectionDetails  ;
		}
		public HttpConnectionDetails selectedConnection
		{
			get => getSlectedConnection () ;
		}

		/// <summary>
		/// Get method for the selectedItem property
		/// </summary>
		/// <returns>Retruns value for the selectedItem property</returns>
		public HttpConnectionItem getSlectedItem ()
		{
			return logList.SelectedIndex == -1 ? null : ( HttpConnectionItem ) logList.Items [ logList.SelectedIndex ]  ;
		}
		public HttpConnectionItem selectedItem
		{
			get => getSlectedItem () ;
		}
		public void showProperties ()
		{
			HttpConnectionDetails connectionDetails = selectedConnection ;



			if ( connectionDetails == null ) 
			{
				propertiesVisible = false ;
				return ;
			}
			
			loadProperties ( connectionDetails ) ;
			logListSplitter.Visible = true ;
			propertiesPanel.Visible = true ;
			setClosePropertiesButtonBounds () ;
		}
		public void loadProperties ( HttpConnectionDetails connectionDetails )
		{

			
			midPanel.SuspendLayout () ;
			propertiesPanel.SuspendLayout () ;
			responseTopPanel.SuspendLayout () ;
			requestTopPanel.SuspendLayout () ;
			requestGrid.SuspendLayout () ;
			responseGrid.SuspendLayout () ;
			
			requestGrid.Rows.Clear () ;
			responseGrid.Rows.Clear () ;
			if ( logList.SelectedIndex == -1 ) return ;
			if ( connectionDetails.error == null )
			{
				errorLabel.Text = "" ;
				errorLabel.Visible = false ;
			}
			else 
			{
				errorLabel.Text = connectionDetails.error.InnerException == null ? connectionDetails.error.Message : connectionDetails.error.InnerException.Message ;
				errorLabel.Visible = true ;
			}
			originLabel.Text = "Origin: " + ( connectionDetails.origin == null ? "?" : connectionDetails.origin.ToString() ) ;
			int i ;
			string [] lines = connectionDetails.request.header.Split ( "\r\n" ) ;
			methodLabel.Text = "" ;
			httpLabel.Text = "" ;
			if ( lines.Length > 0 )
			{
				for ( i = 1 ; i < lines.Length ; i++ )
					addPropertyRow ( lines [ i ] , requestGrid ) ;
				if ( connectionDetails.request.uri == null )
					requestLabel.Text = lines [ 0 ] ;
				else 
				{
					methodLabel.Text = connectionDetails.request.method ;
					requestLabel.Text = connectionDetails.request.uri.AbsolutePath.ToString () ;
					httpLabel.Text = connectionDetails.request.protocol ;
				}
			}
			else requestLabel.Text = "<empty request>" ;
			lines = connectionDetails.responseHeader.Split ( "\r\n" ) ;
			if ( lines.Length > 0 )
			{
				responseLabel.Text = lines [ 0 ] ;
				for ( i = 1 ; i < lines.Length ; i++ )
					addPropertyRow ( lines [ i ] , responseGrid ) ;
			}
			requestGrid.ClearSelection () ;
			responseGrid.ClearSelection () ;
			selectedLabel = null ;
			logPanel.Padding = new Padding ( 0 , 0 , 1 , 0  ) ;

			responseTopPanel.ResumeLayout () ;
			responseGrid.ResumeLayout () ;
			requestGrid.ResumeLayout () ;
			requestTopPanel.ResumeLayout () ;
			propertiesPanel.ResumeLayout () ;
			midPanel.ResumeLayout () ;
		}
		[DllImport("user32")]
		public static extern int LockWindowUpdate ( IntPtr hwnd ) ;
		public void setClosePropertiesButtonBounds ()
		{
			setClosePropertiesButtonLocation () ;
		}
		protected void setClosePropertiesButtonLocation ()
		{
			int h = resourceTypeLabel.Height - 2 ;
			closePropertiesButton.Size = menuButton.Size ;
			closePropertiesButton.Location = new Point ( closePropertiesButton.Parent.Width - closePropertiesButton.Width , 4 ) ;
			closePropertiesButton.BringToFront () ;
		}
		public static void addPropertyRow ( string line , DataGridView grid )
		{
			if ( line == "" ) return ;
			int i = line.IndexOf ( ':' ) ;
			if ( i == -1 )
				grid.Rows.Add ( new object [ 2 ] { "" , line } ) ;
			else grid.Rows.Add ( new object [ 2 ] { line.Substring ( 0 , i ) , line.Substring ( i + 1 ) } ) ;
		}
		private void webServer_clientConnected ( object sender , HttpConnectionDetails connectionDetails )
		{
			if ( !monitorActive ) return ;
			BeginInvoke ( () =>
			{
				if ( !monitorActive ) return ;
				ListBox.ObjectCollection listItems = logList.Items ;
				int maxItems = 5000 ;
				int removeCount = 2000 ;
				if ( listItems.Count > maxItems )
				{
					int c = logList.Items.Count - maxItems  ;
					object [ ] items = new object [ c ] ;
					for ( int i = 0 ; i < c ; i++ )
						items [ i ] = logList.Items [ i + removeCount ] ;
					listItems.Clear () ;
					listItems.AddRange ( items ) ;
					if ( searchItemIndex < removeCount )
						setSearchSelection ( -1 , -1 , 0 ) ;
					else searchItemIndex -= removeCount ;
				}
				logList.Items.Add ( new HttpConnectionItem ( connectionDetails ) ) ;
				if ( logList.ContextMenuStrip == null )
					logList.ContextMenuStrip = logListMenu ;
				searchBoxVisible = searchBoxDemanded ;
				searchButton.Visible = !searchBox.Visible ;
			} ) ;
		}
		private void webServer_serverResponded ( object sender , HttpConnectionDetails connectionDetails )
		{
			BeginInvoke ( () =>
			{
				DateTime lastDate = connectionDetails.created.AddMinutes ( -1 ) ; 
				ListBox.ObjectCollection items = logList.Items ;
				int c = items.Count - 1 ;
				for ( int i = c ; i >= 0 ; i-- )
				{
					HttpConnectionItem oldConnectionItem = ( HttpConnectionItem ) items [ i ] ;
					if ( oldConnectionItem.connectionDetails == connectionDetails )
					{
						items.RemoveAt ( i ) ;
						items.Insert ( i , new HttpConnectionItem ( connectionDetails ) ) ;
						return ;
					}
					if ( oldConnectionItem.connectionDetails.created < lastDate ) break ;
				}
				if ( !monitorActive ) return ;
				items.Add ( new HttpConnectionItem ( connectionDetails ) ) ;
			} ) ;
		}

		private void logList_Click ( object sender , EventArgs e )
		{
			showProperties () ;
		}
		private void logList_SelectedIndexChanged ( object sender , EventArgs e )
		{
			if ( propertiesVisible ) showProperties () ;
		}
		private void logList_KeyDown ( object sender , KeyEventArgs e )
		{
			//switch ( e.KeyCode )
			//{
			//	case Keys.Enter :
			//		showProperties () ;
			//	break ;
			//	case Keys.Escape :
			//		hideProperties () ;
			//	break ;
			//}
		}
		
		private void searchBox_KeyDown ( object sender , KeyEventArgs e )
        {
			switch ( e.KeyCode )
			{
				case Keys.Enter :
					searchForNextItem ( searchBox.Text ) ;
				break ;
				case Keys.F5 :
					logList.Invalidate () ;
				break ;
			}
        }
		private void logList_MouseUp ( object sender , MouseEventArgs e )
		{
			searchPosition = 0 ;
			searchItemIndex = -1 ;
			searchLength = 0 ;
		}


		/// <summary>
		/// Search for item in resource list
		/// </summary>
		/// <param name="searchText">Text to find(partialy)</param>
		/// <param name="charIndex">Char index or -1</param>
		/// <param name="matchLength">Length of text portion that match search text</param>
		/// <returns>Resource list item index or -1</returns>
		public bool searchForItem ( string searchText )
		{
			ListBox.ObjectCollection items = logList.Items ;
			int c = items.Count ;
			searchPosition = -1 ;
			searchLength = 0 ;
			searchText = searchText.ToLower () ;
			searchItemIndex = -1 ;
			for ( int i = 0 ; i < c ; i++ )
			{
				int position = -1 ;
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString() , ref position , ref searchLength , true ) )
				{
					searchPosition = position ;
					searchItemIndex = i ;
				}
			}
			if ( searchItemIndex == -1 )
			{
				searchPosition = -1 ;
				searchLength = 0 ;
				logList.Invalidate () ;
				return false ;
			}
			else 
			{
				setSearchSelection ( searchItemIndex , searchPosition , searchLength ) ;
				return true ;
			}
		}
		//public bool searchForNextItem ( string searchText )
		//{
		//	return searchForNextItem ( searchText , true ) ?  true : searchForNextItem ( searchText , false ) ;
		//}
		public bool searchForNextItem ( string searchText )
		{
			//if ( logList.SelectedIndex == -1  ) 
			//	return searchForItem ( searchText ) ;
			ListBox.ObjectCollection items = logList.Items ;
			int c = items.Count ;
			int currentLength = searchLength <= 0 ? 0 : searchLength ; //!!
			int currentCharIndex = searchPosition ;
			bool newSearch = searchLength == 0 ;
			if ( newSearch ) currentCharIndex = -1 ;
			currentLength = searchLength <= 0 ? 0 : searchLength ; //!!
			if ( searchItemIndex > c ) searchItemIndex = -1 ;
			if ( searchItemIndex != -1 )
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ searchItemIndex ].ToString() , ref currentCharIndex , ref currentLength , newSearch ) ) 
					if ( newSearch ) 
					{
						searchPosition = currentCharIndex ;
						searchLength = currentLength ;
					}
					else
					{
						setSearchSelection ( searchItemIndex , currentCharIndex , currentLength ) ;
						return true ;
					}
			int i ;
			currentCharIndex = -1 ;
			for ( i = searchItemIndex + 1 ; i < c ; i++ )
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString() , ref currentCharIndex , ref currentLength , newSearch ) )
					if ( newSearch ) 
					{
						searchPosition = currentCharIndex ;
						searchLength = currentLength ;
						searchItemIndex = i ;
						currentCharIndex = -1 ;//!!!!
					}
					else
					{
						setSearchSelection ( i , currentCharIndex , currentLength ) ;
						return true ;
					}
			currentCharIndex = -1 ;
			for ( i = 0 ; i < searchItemIndex ; i++ )
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString().ToLower() , ref currentCharIndex , ref currentLength , newSearch ) )
					if ( newSearch ) 
					{
						searchPosition = currentCharIndex ;
						searchLength = currentLength ;
						searchItemIndex = i ;
						currentCharIndex = -1 ;
					}
					else
					{
						setSearchSelection ( i , currentCharIndex , currentLength ) ;
						return true ;
					}
			if ( newSearch && ( searchItemIndex != -1 ) )
			{
				setSearchSelection ( searchItemIndex , searchPosition , searchLength ) ;
				return true ;
			}
			return false ;
		}
		protected void fixScrollForLastItem ()
		{
			int lastVisibleIndex = logList.TopIndex + ( logList.ClientSize.Height / logList.ItemHeight ) ;
			if ( lastVisibleIndex <= logList.SelectedIndex ) 
			try
			{
				logList.TopIndex++ ;
			}
			catch { }
		}
		protected void setSearchSelection ( int itemIndex , int charPosition , int length )
		{
			searchItemIndex = itemIndex ;
			searchPosition = charPosition ;
			searchLength = length ;
			if ( itemIndex == -1 )
			{
			}
			else
			{
				bool propertiesWasVisible = propertiesVisible ;
				logList.SelectedIndexChanged -= logList_SelectedIndexChanged ;
				logList.ClearSelected () ;
				logList.SelectedIndex = itemIndex ;
				fixScrollForLastItem () ;
				if ( logList.SelectedIndex != -1 )
				{
					HttpConnectionItem connectionItem = selectedItem ;
					if ( propertiesWasVisible ) 
						showProperties () ;
					else loadProperties ( connectionItem.connectionDetails ) ;
					HttpConnectionItem.FindResult.PositionFlags startPosition = connectionItem.getCharIndexResult ( searchPosition ).position ;
					HttpConnectionItem.FindResult.PositionFlags endPosition = searchLength > 1 ? connectionItem.getCharIndexResult ( searchPosition + searchLength - 1 ).position : startPosition ;
					selectedLabel = null ;
					switch ( startPosition )
					{
						case HttpConnectionItem.FindResult.PositionFlags.error :
							if ( !propertiesWasVisible ) showProperties () ;
							selectedLabel = errorLabel ;
							responseGrid.ClearSelection () ;
							requestGrid.ClearSelection () ;
						break ;
						case HttpConnectionItem.FindResult.PositionFlags.origin:
							if ( !propertiesWasVisible ) showProperties () ;
							selectedLabel = originLabel ;
							responseGrid.ClearSelection () ;
							requestGrid.ClearSelection () ;
						break ;
						case HttpConnectionItem.FindResult.PositionFlags.requestFirstLine :
							if ( endPosition == startPosition ) 
							{
								if ( !propertiesWasVisible ) showProperties () ;
								markSearchInPanel ( requestTopPanel ) ;
								responseGrid.ClearSelection () ;
								requestGrid.ClearSelection () ;
							}
						break ;
						case HttpConnectionItem.FindResult.PositionFlags.requestAfterFirstLine :
							if ( endPosition == startPosition ) 
								if ( markSearchInGrid ( connectionItem.requestFirstLineEnd , requestGrid ) )
								{
									responseGrid.ClearSelection () ;
									logListSplitter.Visible = true ;
									propertiesPanel.Visible = true ;
									setClosePropertiesButtonBounds () ;
								}
						break ;
					case HttpConnectionItem.FindResult.PositionFlags.responseFirstLine :
							if ( endPosition == startPosition ) 
							{
								if ( !propertiesWasVisible ) showProperties () ;
								markSearchInPanel ( responseTopPanel ) ;
								responseGrid.ClearSelection () ;
								requestGrid.ClearSelection () ;
							}
						break ;
						case HttpConnectionItem.FindResult.PositionFlags.responseAfterFirstLine :
							if ( endPosition == startPosition )  
								if ( markSearchInGrid ( connectionItem.responseFirstLineEnd , responseGrid ) )
								{
									requestGrid.ClearSelection () ;
									logListSplitter.Visible = true ;
									propertiesPanel.Visible = true ;
									setClosePropertiesButtonBounds () ;
								}
						break ;
					}
					//httpConnectionDetails.
				}
				logList.SelectedIndexChanged += logList_SelectedIndexChanged ;
			}
		}
		private bool markSearchInGrid ( int currentLength , DataGridView grid )
		{

			if ( searchPosition < 0 ) return false ;
			if ( searchLength <= 0 ) return false ;
			if ( searchLength > searchBox.Text.Length ) return false ; //!!!
			
			int rowCount = grid.RowCount ;
			DataGridViewCell cell = null ;
			int maxLength = 0 ;
			string search = searchBox.Text.Substring ( 0 , searchLength ) ;
			for ( int rowIndex = 0 ; rowIndex < rowCount ; rowIndex++ )
			{
				DataGridViewRow row = grid.Rows [ rowIndex ] ;
				for ( int columnIndex = 0 ; columnIndex < 2 ; columnIndex++ )
				{
					string cellText = ( string ) row.Cells [ columnIndex ].Value ;
					currentLength += cellText.Length ;
					if ( ( currentLength >= searchPosition ) && ( cellText.Length > maxLength ) )
					{
						int currentCharIndex = -1 ;
						if ( HttpConnectionItem.matchLongestLength ( search , cellText , ref currentCharIndex , ref maxLength , true ) )
						{
							cell = row.Cells [ columnIndex ] ;
							break ;
						}
					}
					currentLength ++ ;
				}
			}
			if ( cell == null )
				return false ;
			else 
			{
				grid.ClearSelection () ;
				cell.Selected = true ;
				setGridRowInScroll ( cell ) ;
				return true ;
			}
		}
		private bool markSearchInPanel ( Panel panel )
		{
			Label foundLabel = null ;
			int maxLength = 0 ;
			string search = searchBox.Text.Substring ( 0 , searchLength ) ;
			foreach ( Control control in panel.Controls )
			{
				Label label = control as Label ;	
				int currentCharIndex = -1 ;
				if ( label != null )
					if ( HttpConnectionItem.matchLongestLength ( search , label.Text , ref currentCharIndex , ref maxLength , true ) )
						foundLabel = label ;
			}
			selectedLabel = foundLabel ;
			return foundLabel == null ;
		}
		protected void setGridRowInScroll ( DataGridViewCell cell )
		{
			if ( cell == null ) return ;
			DataGridView grid = cell.DataGridView ;
			DataGridViewCell firstDisplayedCell = grid.FirstDisplayedCell ;
			if ( firstDisplayedCell == null ) return ;
			Rectangle rect = grid.GetCellDisplayRectangle ( cell.ColumnIndex , cell.RowIndex , false ) ;
			//Rectangle rect1 = grid.GetCellDisplayRectangle ( cell.ColumnIndex , firstDisplayedCell.RowIndex , false ) ;
			if ( rect.Height == 0 )
			{
				if ( cell.RowIndex > firstDisplayedCell.RowIndex )
				{
					int c = Math.Min ( grid.Rows.Count - firstDisplayedCell.RowIndex , cell.RowIndex ) ;
					int i = 0 ;
					for ( i = 0 ; i < c ; i++ )
						if ( grid.GetCellDisplayRectangle ( cell.ColumnIndex , cell.RowIndex - i , false ).Height > 0 )
							break ;
					int r = firstDisplayedCell.RowIndex + i + 1 ;
					grid.FirstDisplayedCell = grid.Rows [ Math.Min ( r , grid.Rows.Count - 1 ) ].Cells [ cell.ColumnIndex ] ;
				}
				else
				{
				}
			}
		}
		/// <summary>
		/// Auxiliary variable for the selectedLabel porperty
		/// </summary>
		protected Label _selectedLabel ;
		/// <summary>
		/// Set method for the selectedLabel porperty
		/// </summary>
		/// <param name="label">New value for the selectedLabel porperty</param>
		protected void setSelectLabel ( Label label )
		{
			if ( _selectedLabel != null )
			{
				_selectedLabel.BackColor = BackColor ;
				_selectedLabel.ForeColor = ForeColor ;
			}
			foreach ( Control control in requestTopPanel.Controls )
			{
				control.BackColor = BackColor ;
				control.ForeColor = ForeColor ;
			}
			foreach ( Control control in responseTopPanel.Controls )
			{
				control.BackColor = BackColor ;
				control.ForeColor = ForeColor ;
			}
			errorLabel.ForeColor = Color.DarkRed ;
			_selectedLabel = label ;
			if ( _selectedLabel != null )
			{
				_selectedLabel.BackColor = selectedBackBrush.Color ;
				_selectedLabel.ForeColor = selectedInkBrush.Color ;
			}
		}
		public Label selectedLabel 
		{
			get => _selectedLabel ;
			set => setSelectLabel ( value ) ;
		}

		private void logList_DoubleClick ( object sender , EventArgs e )
		{
			openRequestUri () ;
		}
		private void closePropertiesButton_Click ( object sender , EventArgs e )
		{
			propertiesVisible = false ;
			try			//always try catch focus!
			{
				searchBox.Focus () ;
			}
			catch { }
		}
		private void focusTopForm ()
		{
			if ( messageForm != null )
				if ( messageForm.Visible )
				{
					messageForm.BringToFront () ;
					return ;
				}
			if ( quickStartForm != null )
				if ( quickStartForm.Visible )
					quickStartForm.BringToFront () ;
		}
		private void messageFormOK_Click ( object sender , EventArgs e )
		{
			( ( Form ) sender ).Dispose () ; //?
			if ( webServer == null ) return ;
			try
			{
				webServer.Stop ( true ) ;
			}
			catch { }
			notifyIcon.Text = "Http server is down" ;
			Icon =
			notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
			//resourceTypeLabel.Text = "Closed" ;
			if ( closeProgramDemand ) 
			{
				closeProgramConfirmed = true ;
				Close () ;
			}
			else if ( serverMode == StartServerMode.jsonConfig )
				BringToFront () ;
			//else
			//{
			//	showQuickStartForm () ;
			//	quickStartForm.configData = webServer.configData ;
			//	focusTopForm () ;
			//}
		}
		 
		private void messageFormNo_Click ( object sender , EventArgs e )
		{
			closeProgramDemand = false ;
			messageFormOK_Click ( sender , e ) ;
			( ( Form ) sender ).Dispose () ;
		}
		private void messageFormCancel_Click ( object sender , EventArgs e )
		{
			closeProgramDemand = false ;
			closeProgramConfirmed = false ;
			( ( Form ) sender ).Dispose () ;
			focusTopForm () ;
		}
		private void messageForm_Closed ( object sender , FormClosedEventArgs e )
		{
			closeProgramDemand = false ;
			closeProgramConfirmed = false ;
			midPanel.Enabled = true ;
			int c = 0 ;
			foreach ( Form form in Application.OpenForms )
				if ( form.Visible ) c++ ;

			midPanel.Enabled = c == 1 ;
			if ( WindowState == FormWindowState.Minimized ) return ; 
			if ( !ShowInTaskbar ) return ; 
			if ( quickStartForm == null ) return ;
			if ( quickStartForm.Visible ) quickStartForm.Focus () ;
		}
		private void messageForm_Disposed ( object sender , EventArgs e )
		{
			MessageForm ms = sender as MessageForm ;
			if ( ms == messageForm ) messageForm = null ;
		}
		protected void showErrorMessage ( string title , string messageText )
		{
			showMessage ( SimpleHttp.Properties.Resources.closeIcon , title , messageText , "" , "" , "Continue" ) ;
		}
		public void showError ( string title , Exception exp )
		{
			ShowInTaskbar = true ;
			bool wasVisible = Visible ;
			Visible = true ;
			string message = exp == null ? "Unknown error" : exp.InnerException == null ? exp.Message : exp.InnerException.Message ;
			if ( WindowState == FormWindowState.Minimized ) 
				restoreForm ( showErrorMessage , new object [ 2 ] { title , message } ) ;
			else 
			{
				if ( wasVisible ) Opacity = 1.0 ;
				if ( StartServerMode.jsonConfig != serverMode )
					showQuickStartForm () ;
						
				showErrorMessage ( title , message ) ;
			}
		}
		public void InvokeShowErrorMessage ( string title , Exception exp  )
		{
			BeginInvoke ( () =>
				{
					showError ( title , exp ) ;
				} ) ;
		}

		
		protected override void OnFormClosing ( FormClosingEventArgs e )
		{
			if ( !closeProgramConfirmed && isListening )
			{
				e.Cancel = true ;
				if ( closeProgramDemand || ( messageForm != null )  && ( e.CloseReason == CloseReason.UserClosing ) )
				{
					showMessage ( SimpleHttp.Properties.Resources.closeIcon ,
									"Closing program" , "              Do you want to close http server?" ,
									"Close program and server" , "Just stop server" , "Keep server working" ) ;
					
				}
				else
				{
					ShowInTaskbar = false ;
					Hide () ;
					resourcesForm?.Hide () ;
					aboutForm?.Hide () ;
				}
			}
			else 
			{
				quickStartForm?.Dispose () ;
				resourcesForm?.Dispose () ;
				aboutForm?.Dispose () ;
				messageForm?.Dispose () ;
			}
			base.OnFormClosing ( e ) ;
		}
		/// <summary>
		/// Get method for the isListening property
		/// </summary>
		/// <returns>Retruns true if WebServer instance is not null and listening</returns>
		protected bool getIsListening ()
		{
			try
			{
				return webServer == null ? false : webServer.isListening ;
			}
			catch { }
			return false ;
		}
		/// <summary>
		/// Returns true is web server is active/listening.
		/// </summary>
		public bool isListening 
		{
			get => getIsListening () ;
		}
		/// <summary>
		/// Get method for the isJSONConfig property
		/// </summary>
		/// <returns>
		/// Returns true if web server has the configData property value diferent then null.
		/// </returns>
		public bool getIsJSONConfig () 
		{
			if ( webServer != null )
				if ( webServer.configData != null ) 
					return true ;
			return false ;
		}
		/// <summary>
		/// Returns true if web server has the configData property value diferent then null.
		/// </summary>
		public bool isJSONConfig 
		{
			get => getIsJSONConfig () ;
		}

		
		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && (components != null ) ) components.Dispose() ;
			if ( recivier.IsConnected ) recivier.Disconnect () ;
			recivier.Close () ;
			recivier.Dispose () ;
			base.Dispose( disposing ) ;
		}
		
		private void notifyIcon_MouseDown ( object sender , MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
				restoreForm () ;
		}
		private void notifyIcon_MouseUp ( object sender , MouseEventArgs e )
		{
			//if ( e.Button == MouseButtons.Right )
			//{
			//	APIPoint point ;
			//	GetCursorPos ( out point ) ;
			//	iconMenu.Show ( point.x , point.y ) ;
			//}

		}
		private void stopButton_MouseDown ( object sender , MouseEventArgs e )
		{
			//showMenuItem.Visible = false ;
			
			API.APIPoint po = new API.APIPoint () ;
			API.GetCursorPos ( ref po ) ;
			iconMenu.Show ( po.x - 155 , po.y + 10 ) ;
		}
		
		private void restoreForm ()
		{
			restoreForm ( null , null ) ;
		}
		private void restoreForm ( Delegate continueWidth )
		{
			restoreForm ( continueWidth , null ) ;				 
		}
		private void restoreForm ( Delegate continueWidth , object [] args )
		{
			BeginInvoke ( () =>
			{
				ShowInTaskbar = true ;
				Visible = true ;
				_jsonEditorVisible = jsonEditor.Visible ;
				if ( WindowState == FormWindowState.Minimized ) 
				{
					previousWindowState = FormWindowState.Minimized ;
					WindowState = restoredWindowState ;
				}
				Activate () ;
				API.BringWindowToTop ( Handle ) ;
				calculateItemHeight () ;
				if ( continueWidth == null ) 
					midPanel.Enabled = true ;
				else continueWidth.DynamicInvoke ( args ) ;
			} ) ;
		}
		private void iconMenu_Opening ( object sender , System.ComponentModel.CancelEventArgs e )
		{
			if ( isListening )
			{
				showQuickStartMenuItem.Visible = false ;
				startJSONConfigMenuItem.Visible = false ;
				toolStripSeparator1.Visible = false ;
				stopServerMenuItem.Visible = true ;
			}
			else 
			{
				showQuickStartMenuItem.Visible = true ;
				startJSONConfigMenuItem.Visible = true ;
				toolStripSeparator1.Visible = true ;
				stopServerMenuItem.Visible = false ;
			}
			//if ( 
			showMainWindowMenuItem.Visible = !Visible || WindowState == FormWindowState.Minimized ;
			
			
			if ( jsonEditorVisible )
			{
				startJSONConfigMenuItem.Text = "Start current configuration" ;
			}
			else 
			{
				startJSONConfigMenuItem.Text = "Show current configuration" ;
			}
			closeProgramMenuItem.Text = isListening ? "Close http server and program" : "Close program" ;
		}

		protected AboutForm aboutForm ;
		private void showAboutForm ()
		{
			if ( aboutForm  == null )
			{
				aboutForm = new AboutForm () ;
				aboutForm.Owner = this ;
				aboutForm.Disposed += aboutForm_Disposed ;
				aboutForm.Opacity = 0.0 ;
				aboutForm.Show ( this ) ;
				aboutForm.Shown += aboutForm_Shown ;
			}
			else aboutForm.Show () ;
		}

		private void aboutForm_Shown ( object sender , EventArgs e )
		{
			aboutForm.Location = new Point ( Left + ( ( Width - aboutForm.Width ) >> 1 ) , Top + ( ( Height - aboutForm.Height ) >> 1 ) ) ;
			aboutForm.Opacity = 1.0 ;
		}

		private void aboutForm_Disposed ( object sender , EventArgs e  )
		{
			if ( ( ( Form ) sender ) == aboutForm ) aboutForm = null ;
		}
		private void showMonitorMenuItemClick ()
		{
			jsonEditorVisible = false ;
			try
			{
				if ( jsonEditor.Visible )
					jsonEditor.Focus () ;
				else if ( logPanel.Visible )
					logList.Focus () ;
			}
			catch { }
		}
		private void switchMonitorMenuItemClick ()
		{
			jsonEditorVisible = !jsonEditorVisible ;
			try
			{
				if ( jsonEditor.Visible )
					jsonEditor.Focus () ;
				else if ( logPanel.Visible )
					logList.Focus () ;
			}
			catch { }
		}
		private void iconMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == aboutMenuItem )
				restoreForm ( showAboutForm ) ;
			else if ( e.ClickedItem == showStartParametersMenuItem )
				restoreForm ( showStartParameters , new object [ 2 ] { "Starting parameters" , programStartParameters } ) ;
			else if ( e.ClickedItem == showMainWindowMenuItem )
				restoreForm () ;
			else if ( e.ClickedItem == showQuickStartMenuItem )
				restoreForm ( showQuickStartFormAndTakeConfigData ) ;
			else if ( e.ClickedItem == startJSONConfigMenuItem )
				restoreForm ( startJSONConfigMenuItemClick ) ;
			else if ( e.ClickedItem == stopServerMenuItem )
			{
				if ( isListening )
					restoreForm ( () =>
					{
						closeProgramDemand = false ;
						closeProgramConfirmed = false ;
						showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
												"Stoping server" , "Do you want to stop http server?" ,
												"Stop server" , "" , "Keep server working" ) ;

					} ) ;
				else Close () ;
			}
			else if ( e.ClickedItem == closeProgramMenuItem )
			{
				restoreForm ( () =>
				{
					closeProgramDemand = true ;
					closeProgramConfirmed = false ;
					Close () ;
				} ) ;
			}
		}
		[System.Diagnostics.DebuggerStepThrough]
		protected override void WndProc ( ref Message m )
		{
			try
			{
                if ( m.Msg  == WindowMessage.WM_CopyData )
				{
					API.CopyDataStructure cds = new API.CopyDataStructure() ;
					cds = ( API.CopyDataStructure ) Marshal.PtrToStructure ( m.LParam , typeof ( API.CopyDataStructure ) ) ;
					if ( cds.cbData > 0 )
					{
						string strData = Marshal.PtrToStringUni ( cds.lpData ).ToLower ().Trim () ;
						BeginInvoke ( processCopyDataMessage , strData ) ;
					}
				}
			}
			catch {}
            base.WndProc ( ref m ) ;
		}
		
		private void processCopyDataMessage ( string message )
		{
			if ( message == null ) return ;
			if ( message.Trim().ToLower () == "show" )
			{
				iconMenu_ItemClicked ( iconMenu , new ToolStripItemClickedEventArgs ( showMainWindowMenuItem ) ) ;
			}
		}

		public void showStartParameters ( string title , HttpStartParameters startParameters )
		{
			showMessage ( null , title , exeName() + " " + startParameters.ToString() , "" , "" , "Continue" ) ;
		}
		public void showMessage ( Image image , string title , string caption , 
									string okButtonText , string noButtonText, string cancelButtonText )
		{

			if ( messageForm == null )
			{
				messageForm = MessageForm.Show ( this , image , title , caption , 
									okButtonText , noButtonText , cancelButtonText ,
									messageFormOK_Click , messageFormNo_Click , messageFormCancel_Click , 
									messageForm_Closed , messageForm_Disposed ) ;
				messageForm.Font = Font ;
			}
			else
			{
				messageForm.setAll ( image , title , caption , okButtonText , noButtonText , cancelButtonText ) ;
				messageForm.Show () ;
				messageForm.BringToFront () ;
			}
		}
		private void searchBox_TextChanged ( object sender , EventArgs e )
		{
			searchLength = 0 ;
		}
		protected int textWidthHint ;
		protected int textWidthLeftHint ;
		protected int textWidthRightHint ;
		protected void setTextWidthHint ( Graphics graphics )
		{
			bool myGraphics ;
			if ( graphics == null ) 
			{
				graphics = Graphics.FromHwnd ( Handle ) ;
				myGraphics = true ;
			}
			else myGraphics = false ;
			textWidthHint = TextRenderer.MeasureText ( ( IDeviceContext ) graphics , "||" , logList.Font ).Width - TextRenderer.MeasureText ( ( IDeviceContext ) graphics , "|" , logList.Font ).Width ;
			textWidthRightHint = textWidthHint << 1 ;
			textWidthLeftHint = textWidthHint + 1 ;
			if ( myGraphics ) graphics.Dispose () ;
		}
		private void logList_DrawItem ( object sender , DrawItemEventArgs e )
		{
			if ( e.Index == -1 ) return ; //??????!!!!!!!!!!??? @#@$@!!
			IDeviceContext deviceContext = ( IDeviceContext ) e.Graphics ;
			HttpConnectionItem item = ( HttpConnectionItem ) logList.Items [ e.Index ] ;
			HttpConnectionDetails connectionDetails = ( ( HttpConnectionItem ) logList.Items [ e.Index ] ).connectionDetails ;
			string s = item.ToString() ;
			bool searchSelected = ( searchItemIndex == e.Index ) && ( searchPosition >= 0 ) && ( searchPosition < s.Length ) && ( searchLength > 0 ) && ( searchPosition + searchLength <= s.Length ) ;

			SolidBrush back ;
			SolidBrush ink ;
			if ( ( e.State & DrawItemState.Selected ) == 0 )  
				if ( connectionDetails.error == null )
					if ( ( e.Index & 1 ) == 0 )
					{
						back = normalBackBrush ;
						ink = normalInkBrush ;
					}
					else 
					{
						back = alternateBackBrush ;
						ink = alternateInkBrush ;
					}
				else 
				{
					back = errorBackBrush ;
					ink = errorInkBrush ;
				}
			else // selected
				if ( connectionDetails.error == null )
				{
					back = selectedBackBrush ;
					ink = selectedInkBrush ;
				}
				else 
				{
					back = selectedErrorBackBrush ;
					ink = selectedErrorInkBrush;
				}

			e.Graphics.FillRectangle ( back , e.Bounds ) ;
			Size fullSize = TextRenderer.MeasureText ( deviceContext , s , logList.Font ) ;
			int t = ( e.Bounds.Height - ( int ) fullSize.Height ) >> 1 ;
			if ( searchSelected )
				e.Graphics.FillRectangle ( searchBackBrush , 
					e.Bounds.Left + ( searchPosition > 0 ? 
						( TextRenderer.MeasureText ( deviceContext , s.Substring ( 0 , searchPosition ) , logList.Font ).Width - textWidthLeftHint ) : 0 ) , 
					e.Bounds.Top + t , 
					TextRenderer.MeasureText ( deviceContext , s.Substring ( searchPosition , searchLength ) , logList.Font ).Width - 
								( searchPosition > 0 ? textWidthRightHint : textWidthLeftHint ) , 
					e.Bounds.Height - ( t << 1 ) ) ;
			TextRenderer.DrawText ( deviceContext , s , logList.Font , new Point ( e.Bounds.Left , e.Bounds.Top + t ) , ink.Color , Color.Transparent ) ;
		}
		


		private void verticalSplitterPainer ( object sender , PaintEventArgs e )
		{
			e.Graphics.FillRectangle ( buttonBrush , e.Graphics.ClipBounds ) ;
			e.Graphics.DrawLine ( darkPen , 1.0f , 0.0f , 1.0f , e.Graphics.ClipBounds.Bottom ) ;
			e.Graphics.DrawLine ( lightPen , 2.0f , 0.0f , 2.0f , e.Graphics.ClipBounds.Bottom ) ;
		}
		private void horizontalSplitterPainer ( object sender , PaintEventArgs e )
		{
			e.Graphics.FillRectangle ( buttonBrush , e.Graphics.ClipBounds ) ;
			e.Graphics.DrawLine ( darkPen , 0.0f , 1.0f , e.Graphics.ClipBounds.Right , 1.0f ) ;
			e.Graphics.DrawLine ( lightPen , 0.0f , 2.0f , e.Graphics.ClipBounds.Right , 2.0f ) ;
		}
		private void errorLabel_MouseEnter ( object sender , EventArgs e )
		{
			errorLabel.ForeColor = SystemColors.WindowText ;
			errorLabel.BackColor = SystemColors.Window ; 
		}

		private void errorLabel_MouseLeave ( object sender , EventArgs e )
		{
			if ( _selectedLabel == errorLabel )
				selectedLabel = errorLabel ;
			else
			{
				errorLabel.ForeColor = Color.DarkRed ;
				errorLabel.BackColor = errorLabel.Parent.BackColor ;
			}
		}

		private void errorLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
				showErrorStackTrace () ;
			else linkContextMenu.Tag = errorLabel ;
		}

		
		private void configFileNameLabel_MouseEnter ( object sender , EventArgs e )
		{
			configFileNameLabel.Font =  boldUnderlineFont ;
		}

		private void configFileNameLabel_MouseLeave ( object sender , EventArgs e )
		{
			configFileNameLabel.Font =  boldFont ;
		}
		private void configFileNameLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			if ( e.Button != MouseButtons.Right )
			{
				API.APIPoint po = new API.APIPoint () ;
				API.GetCursorPos ( ref po ) ;
				configContextMenu.Show ( po.x , po.y ) ;
			}
		}

		private void showErrorStackTrace ()
		{
			try
			{
				HttpConnectionDetails connectionDetails = selectedConnection ;
				if ( string.IsNullOrEmpty ( connectionDetails.error.StackTrace ) ) return ;
				showErrorMessage ( "Stack trace" , connectionDetails.error.StackTrace ) ;
			}
			catch { }
		}
		private void copyErrorWithStackTrace ()
		{
			try
			{
				HttpConnectionDetails connectionDetails = selectedConnection ;
				if ( string.IsNullOrEmpty ( connectionDetails.error.StackTrace ) ) 
					Clipboard.SetText ( connectionDetails.error.Message ) ;
				else Clipboard.SetText ( connectionDetails.error.Message + "\r\n" + connectionDetails.error.StackTrace ) ;
			}
			catch { }
		}
		private void logListMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == openLogMenuItem )
				openRequestUri () ;
			else if ( e.ClickedItem == deleteItemLogMenuItem )
				deleteSelectedLogItems () ;
			else if ( e.ClickedItem == selectAllLogMenuItem )
				selectAllLogItems () ;
		}
		public void selectAllLogItems ()
		{
			int c = logList.Items.Count ;
			int t = logList.TopIndex ;
			logList.SelectedIndexChanged -= logList_SelectedIndexChanged ;
			API.LockWindowUpdate ( logList.Handle ) ; // this is stupid
			logList.SuspendLayout () ;
			for ( int i = 0 ; i < c ; i++ )
				logList.SetSelected ( i , true ) ; //this is bad
			logList.TopIndex = t ;
			logList.ResumeLayout () ;
			API.LockWindowUpdate ( IntPtr.Zero ) ; //0 for unlock		
			logList.SelectedIndexChanged += logList_SelectedIndexChanged ;
		}
		public void deleteSelectedLogItems ()
		{
			logList.SelectedIndexChanged -= logList_SelectedIndexChanged ;
			ListBox.ObjectCollection items = logList.Items ;
			int c = items.Count ;
			searchLength = 0 ;
			searchPosition = -1 ;
			searchItemIndex = -1 ;
			for ( int i = c - 1  ; i >= 0 ; i-- )
				if ( logList.GetSelected ( i ) ) items.RemoveAt ( i ) ;
			searchBoxVisible = searchBoxDemanded && searchBoxCanBeVisible ;			
			logList.SelectedIndexChanged += logList_SelectedIndexChanged ;
		}
		private void logListMenu_Opening ( object sender , System.ComponentModel.CancelEventArgs e)
		{
			if ( logMenuLine1.Visible =
			deleteItemLogMenuItem.Visible =
			logList.SelectedItems.Count > 0 )
				logMenuLine0.Visible =
				openLogMenuItem.Visible = selectedConnection.request.uri != null ;
			else logMenuLine0.Visible =
				openLogMenuItem.Visible = false ;
		}

		private void uriLabel_TextChanged ( object sender , EventArgs e )
		{
			uriLabel.Visible = uriLabel.Text.Trim () != "" ;
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
			if ( e.Button == MouseButtons.Left )
				openHostUri () ;
			else linkContextMenu.Tag = uriLabel ;
		}
		
		private void gridContextMenu_Opening ( object sender , CancelEventArgs e )
		{
			if ( requestGrid.Capture )
				gridContextMenu_Opening ( requestGrid , e ) ;
			else if ( responseGrid.Capture )
				gridContextMenu_Opening ( responseGrid , e ) ;
			else e.Cancel = true ;
		}
		private void gridContextMenu_Opening ( DataGridView grid , System.ComponentModel.CancelEventArgs e )
		{
			gridContextMenu.Tag = grid ;
			if ( grid.SelectedCells.Count == 0 )
			{
				gridLine0.Visible = false ;
				//grid.Visible = false ;
				gridSearchMenuItem.Visible = false ;
				gridCopyMenuItem.Visible = false ;
			}
			else 
			{
				if ( ( grid.SelectedCells.Count == 1 ) && ( grid.CurrentCell.ColumnIndex == 0 ) )
				{
					gridLine1.Visible = true ;
					gridSearchMenuItem.Visible = true ;
				}
				else
				{
					gridLine1.Visible = false ;
					gridSearchMenuItem.Visible = false ;
				}
				gridLine0.Visible = true ;
				gridCopyMenuItem.Visible = true ;
			}
		}

		private void gridContextMenu_ItemClicked ( object sender ,  ToolStripItemClickedEventArgs e )
		{
			gridContextMenu_ItemClicked ( ( DataGridView ) gridContextMenu.Tag , e ) ; 
		}
		private void gridContextMenu_ItemClicked ( DataGridView grid , ToolStripItemClickedEventArgs e )
		{
			
			if ( e.ClickedItem == gridCopyMenuItem )
				gridCopy ( grid ) ;
			else if ( e.ClickedItem == gridSearchMenuItem )
				openSearchUri ( grid ) ;
			else if ( e.ClickedItem == gridSelectAllMenuItem )
				grid.SelectAll () ;
		}
		private void gridCopy ( DataGridView grid )
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder () ;
				DataGridViewCell [ ] selectedCells = new DataGridViewCell [ grid.SelectedCells.Count ] ; //fuck you Microsoft, cell are not sorted, they are in order as selected
				grid.SelectedCells.CopyTo ( selectedCells , 0 ) ;
				sortCells ( selectedCells ) ;
				int row = selectedCells [ 0 ].RowIndex ;
				foreach ( DataGridViewCell cell in selectedCells )
				{
					if ( row != cell.RowIndex )
					{
						row = cell.RowIndex ;
						if ( stringBuilder.Length > 0 )
						{
							stringBuilder [ stringBuilder.Length - 1 ] = '\r' ;
							stringBuilder.Append ( '\n' ) ;
						}
					}
					stringBuilder.Append ( cell.Value == null ? "<null>" : cell.Value.ToString () ) ; 
					stringBuilder.Append ( '\t' ) ;
				}
				if ( stringBuilder.Length > 1 )
					Clipboard.SetText ( stringBuilder.ToString ( 0 , stringBuilder.Length - 1 ) ) ;
			}
			catch { }
		}
		/// <summary>
		/// Pleas kill me
		/// </summary>
		/// <param name="cells">Cells copied from grid.SelectedCells list</param>
		public static void sortCells ( DataGridViewCell [ ] cells )
		{
			int c = cells.Length ;
			int maxStep = ( c + 1 ) >> 1 ;

			bool done ;
			for ( int step = maxStep ; step > 0 ; step-- )
			{
				done = true ;
				for ( int position = 0 ; position < c - step ; position++ )
				{
					DataGridViewCell cell0 = cells [ position ] ;
					DataGridViewCell cell1 = cells [ position + step ] ;
					if ( cell0.RowIndex == cell1.RowIndex )
					{
						if ( cell0.ColumnIndex > cell1.ColumnIndex )
						{
							cells [ position ] = cell1 ;
							cells [ position + step ] = cell0 ;
							done = false ;
						}
					}
					else if ( cell0.RowIndex > cell1.RowIndex )
					{
						cells [ position ] = cell1 ;
						cells [ position + step ] = cell0 ;
						done = false ;
					}
				}
				if ( ( step == 1 ) && !done ) step++ ;
			}
		}
		private void resourceLabel_MouseEnter ( object sender , EventArgs e )
		{
			resourceLabel.Font = boldUnderlineFont ;
		}
		private void resourceLabel_MouseLeave ( object sender , EventArgs e )
		{
			resourceLabel.Font = boldFont ;
		}
		public static Assembly FindAssemblyBySource ( string assemblySource )
		{
			Assembly assembly = GetAssemblyByName ( assemblySource ) ;
			if ( assembly == null )
			{
				if ( !Path.IsPathRooted ( assemblySource ) )
				{
					string path = Application.StartupPath ;
					assemblySource = string.Concat ( path , path [ path.Length - 1 ] == '\\' ? "" : "\\" ,  assemblySource ) ;
				}
				AssemblyName assemblyName = AssemblyName.GetAssemblyName ( assemblySource ) ;
				assembly = GetAssemblyByFullName ( assemblyName.FullName ) ;
				if ( assembly == null ) return Assembly.LoadFrom ( assemblySource ) ;
			}
			return assembly ;
		}
		public static Assembly GetOtherAssemblyByName ( Assembly firstAssembly )
		{
			string name = firstAssembly.FullName ;
			return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault ( assembly => ( firstAssembly != assembly ) && ( assembly.FullName == name ) ) ;
		}
		public static Assembly GetAssemblyByFullName ( string fullName )
		{
			return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault ( assembly => assembly.FullName == fullName ) ;
		}
		public static Assembly GetAssemblyByName ( string name )
		{
			return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault ( assembly =>
			{
				string fullName = assembly.GetName().FullName ;
				if ( fullName == name ) return true ;
				return fullName.IndexOf ( name + "," ) != -1 ;
			} ) ;
		}
		private void resourceLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			try
			{
				if ( e.Button == MouseButtons.Left )
					switch ( serverMode )
					{
						case StartServerMode.fileServer :
							openWebrootFolder () ;
						break ;
						case StartServerMode.resourceServer:
							quickStartForm_resourceViewNeeded ( sender , FindAssemblyBySource ( resourceAssemblyName ) ) ;
						break ;
						default:
							jsonEditorVisible = !jsonEditorVisible ;
						break ;
					}
				else linkContextMenu.Tag = resourceLabel ;
			}
			catch { }
		}
		protected void openWebrootFolder ()
		{
			Exception error ;
			if ( resourceLabel.Text == "<not saved>" )
				jsonEditorVisible = !jsonEditorVisible ;
			else if ( !openLink ( resourceLabel.Text , out error ) )
				showError ( "Cannot open uri" , error ) ;
		}
		protected void openConfigFolder ()
		{
			Exception error ;
			if ( webServer == null )
				showError ( "Cannot open uri" , new Exception ( "WebServer instance is null" ) ) ;
			else if ( webServer.configData == null ) 
				showError ( "Cannot open uri" , new Exception ( "No WebServer JSON configuration" ) ) ;
			else if ( string.IsNullOrWhiteSpace ( webServer.configData.jsonConfigFile ) )
				showError ( "Cannot open uri" , new Exception ( "WebServer JSON configuration file name is empty" ) ) ;
			else if ( !openFolder ( webServer.configData.jsonConfigFile , out error ) )
				showError ( "Cannot open uri" , error ) ;
		}
		protected void openHostUri ()
		{
			Exception error ;
			if ( !openLink ( uriLabel.Text , out error ) )
				showError ( "Cannot open uri" , error ) ;
		}
		protected void openRequestUri ()
		{
			Exception error ;
			if ( !openLink ( selectedConnection.request.uri.ToString () , out error ) )
				showError ( "Cannot open uri" , error ) ;
		}
		protected void openSearchUri ( DataGridView grid )
		{
			Exception error = null ;
			try
			{
				openLink ( "https://duckduckgo.com/?q=http+header+%22" + Uri.EscapeUriString ( ( string ) grid.CurrentCell.Value ) + "%22" , out error ) ;
			}
			catch ( Exception x )
			{ 
				error = x ;
			}
			if ( error != null ) showError ( "Error" , error ) ;
		}
		public static bool openFolder ( string uri , out Exception error )
		{
			int i = uri.LastIndexOf ( '\\' ) ;
			if ( i == -1 ) 
			{
				error = new IOException ( "No path in \"" + uri + "\"" ) ;
				return false ;
			}
			//else
			//{
			//	error = null ;
			//	IntPtr mainWindowHandle = Process.Start ( "explorer.exe", "/select,\"" + uri + "\"" ).MainWindowHandle ;
			//	return mainWindowHandle != IntPtr.Zero  ;
			//}
			else return openLink ( uri.Substring ( 0 , i ) , out error ) ;
		}
		public static bool openLink ( string uri , out Exception error )
		{
			error = null ;
			if ( string.IsNullOrEmpty ( uri ) )
				error = new ApplicationException ( "Empty or null uri" ) ;
			else if ( uri == "<not saved>" )
			{
				return true ;
			}
			else 
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo ( "\"" + uri + "\"" ) ; //not "explorer" !
				startInfo.UseShellExecute = true ; //o yeeeaa!
				Process.Start ( startInfo ) ;
				return true ;
			}
			catch ( Exception x )
			{
				error = x.InnerException == null ? x : x.InnerException ;
			}
			return false ;
		}
		private void labelContextMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( ( ( Control ) labelContextMenu.Tag ).Text.Trim() != "" ) 
				Clipboard.SetText ( ( ( Control ) labelContextMenu.Tag).Text ) ;
		}

		private void linkContextMenu_ItemClicked ( object sender, ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == linkOpenMenuItem )
			{
				if ( linkContextMenu.Tag == uriLabel )
					openHostUri () ;
				else if ( linkContextMenu.Tag == requestLabel )
					openRequestUri () ;
				else if ( linkContextMenu.Tag == resourceLabel )
					resourceLabel_MouseDown ( resourceLabel , new MouseEventArgs ( MouseButtons.Left , 1 , 0 , 0 , 0 ) ) ;
				else if ( linkContextMenu.Tag == errorLabel )
					showErrorStackTrace () ;
			}
			else if ( e.ClickedItem == folderOpenMenuItem )
				openConfigFolder () ;
			else if ( e.ClickedItem == linkCopyMenuItem )
				if ( linkContextMenu.Tag == errorLabel )
					copyErrorWithStackTrace () ;
				else if ( linkContextMenu.Tag == requestLabel )
					Clipboard.SetText ( selectedConnection.request.uri.ToString () ) ;
				else if ( ( ( Control ) linkContextMenu.Tag ).Text.Trim() != "" ) 
					Clipboard.SetText ( ( ( Control ) linkContextMenu.Tag ).Text ) ;
		}
		
		private void configContextMenu_Opening ( object sender , System.ComponentModel.CancelEventArgs e )
		{
			browseConfigFileMenuItem.Enabled = !isListening ;
			copyConfigNameMenuItem.Enabled = !string.IsNullOrWhiteSpace ( jsonConfigFile ) ;
		}
		private void configContextMenu_ItemClicked ( object sender, ToolStripItemClickedEventArgs e )
		{
			configContextMenu.Close () ;
			if ( e.ClickedItem == browseConfigFileMenuItem )
			{
				try
				{
					openFileDialog.InitialDirectory = Path.GetDirectoryName ( jsonConfigFile ) ;
					openFileDialog.FileName = Path.GetFileName ( jsonConfigFile ) ;
				}
				catch { }
				if ( openFileDialog.ShowDialog ( this ) == DialogResult.OK )
					if ( tryLoadConfigAs ( openFileDialog.FileName ) )
					{
						int i = openFileDialog.FileName.LastIndexOf ( '\\' ) ;
						configFileNameLabel.Text = i == -1 ? openFileDialog.FileName : openFileDialog.FileName.Substring ( i + 1 ) ;
					}
			}
			else if ( e.ClickedItem == saveConfigFileMenuItem )
			{
				try
				{
					saveFileDialog.InitialDirectory = Path.GetDirectoryName ( jsonConfigFile ) ;
					saveFileDialog.FileName = Path.GetFileName ( jsonConfigFile ) ;
				}
				catch { }
				if ( saveFileDialog.ShowDialog ( this ) == DialogResult.OK )
					if ( trySaveConfigAs ( saveFileDialog.FileName ) )
					{
						int i = saveFileDialog.FileName.LastIndexOf ( '\\' ) ;
						configFileNameLabel.Text = i == -1 ? saveFileDialog.FileName : saveFileDialog.FileName.Substring ( i + 1 ) ;
					}
			}
			else if ( e.ClickedItem == copyConfigNameMenuItem )
				if ( !string.IsNullOrWhiteSpace ( jsonConfigFile ) )
					Clipboard.SetText ( jsonConfigFile ) ;
		}
		public bool tryLoadConfigAs ( string fileName )
		{
			FileStream fileStream = null ;
			TextReader reader = null ;
			bool ret = false ;
			try
			{
				reader = new StreamReader ( fileName ) ;
				jsonEditor.Text = reader.ReadToEnd () ;
				_jsonConfigFile = fileName ;
				ret = true ;
			}
			catch ( Exception x )
			{
				showError ( "File read error" , x ) ;
			}
			try
			{ 
				if ( fileStream != null ) fileStream.Dispose () ;
				if ( reader != null ) reader.Dispose () ;
			}
			catch { }
			return ret ;
		}
		public bool trySaveConfigAs ( string fileName )
		{
			FileStream fileStream = null ;
			bool ret = false ;
			try
			{
				fileStream = File.OpenWrite ( fileName ) ;
				fileStream.Write ( Encoding.UTF8.GetBytes ( jsonEditor.Text ) ) ;
				_jsonConfigFile = fileName ;
				ret = true ;
			}
			catch ( Exception x )
			{
				showError ( "File not saved" , x ) ;
			}
			try
			{ 
				if ( fileStream != null ) fileStream.Dispose () ;
			}
			catch { }
			return ret ;
		}

		private void requestGrid_Enter ( object sender , EventArgs e )
		{
			gridContextMenu.Tag = requestGrid ;
		}

		private void responseGrid_Enter ( object sender , EventArgs e )
		{
			gridContextMenu.Tag = responseGrid ;
		}


		private void resourceTypeLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			labelContextMenu.Tag = resourceTypeLabel ;
		}

		private void originLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			labelContextMenu.Tag = originLabel ;
		}

		private void requestLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			linkContextMenu.Tag = requestLabel ;
			if ( e.Button == MouseButtons.Left )
				openRequestUri () ;			
		}

		private void responseLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			labelContextMenu.Tag = responseLabel ;
		}

		private void methodLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			labelContextMenu.Tag = methodLabel ;
		}

		private void httpLabel_MouseDown ( object sender , MouseEventArgs e )
		{
			labelContextMenu.Tag = httpLabel ;
		}

		private void requestLabel_MouseEnter ( object sender , EventArgs e )
		{
			requestLabel.Font = boldUnderlineFont ;
		}
		private void requestLabel_Mouseleave ( object sender , EventArgs e )
		{
			requestLabel.Font = boldFont ;
		}

		private void labelContextMenu_Opening ( object sender , CancelEventArgs e )
		{
			if ( labelContextMenu.Tag == null ) 
				e.Cancel = true ;
			else if ( ( ( Control ) labelContextMenu.Tag ).Text == "" )
				e.Cancel = true ;
		}

		private void linkContextMenu_Opening ( object sender , CancelEventArgs e )
		{
			if ( linkContextMenu.Tag == null ) 
				e.Cancel = true ;
			else if ( ( ( Control ) linkContextMenu.Tag ).Text == "" )
				e.Cancel = true ;
			if ( ( serverMode == StartServerMode.jsonConfig ) && ( linkContextMenu.Tag == resourceLabel ) )
			{
				folderOpenMenuItem.Visible = true ;
				linkContextMenuLine1.Visible = true ;
				linkOpenMenuItem.Text = "&Open file" ;
			}
			else 
			{
				folderOpenMenuItem.Visible = false ;
				linkContextMenuLine1.Visible = false ;
				if ( isListening )
				{
					linkOpenMenuItem.Text = "&Open link" ;
					linkOpenMenuItem.Visible = true ;
				}
				else linkOpenMenuItem.Visible = false ;
			}
		}

		public static string exeName ( )
		{
			string s = Application.ExecutablePath ;
			int i = s.LastIndexOf ( '\\' ) ;
			return i == -1 ? s : s.Substring ( i + 1 ) ;	
		}

		private void requestGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{ 

				//https://duckduckgo.com/?q=http+header+%22Accept-Encoding%22&ia=web
			}
			catch{ }
		}

        private void topPanel_Resize ( object sender , EventArgs e )
        {
			searchBox_Resize ( sender , e ) ;
			statusPanel.MaximumSize = new Size ( buttonPanel.Left , 0 ) ; 
			if ( IsHandleCreated ) BeginInvoke ( statusPanel.PerformLayout  ) ;
        }

		private void searchBox_Resize ( object sender, EventArgs e )
		{
			//topPanel.SuspendLayout () ;
			statusPanel.SuspendLayout() ;


			//topPanel.Height = Math.Max ( se searchBox.Height ;
			//statusPanel.Width = statusPanel.MaximumSize.Width ;
			startStopSwitch.Size =
			monitorSwitch.Size =
			viewSwitch.Size =
			menuButton.Size = new Size ( searchBox.Height , searchBox.Height ) ;
			
			//menuButton.Location = new Point ( topPanel.Width - menuButton.Width , 0 ) ;
			//monitorSwitch.Location = new Point ( menuButton.Left - viewSwitch.Width - midPanel.Left , 0 ) ;
			//viewSwitch.Location = new Point ( monitorSwitch.Left - viewSwitch.Width - midPanel.Left , 0 ) ;
			//startStopSwitch.Location = new Point ( monitorSwitch.Left - viewSwitch.Width - midPanel.Left , 0 ) ;
			//statusPanel.MaximumSize = new Size ( startStopSwitch.Left , 0 ) ;
			//viewSwitch.Anchor = 
			//menuButton.Anchor = AnchorStyles.Top | AnchorStyles.Right ;
			errorLabel.Margin = new Padding ( 0 , 0 , Math.Max ( 0 , closePropertiesButton.Width - 2 ) , 0 ) ;
			closePropertiesButton.Size = new Size ( searchBox.Height , searchBox.Height ) ;
			searchButton.Size = new Size ( searchBox.Height , searchBox.Height ) ;
			int h = searchBox.Height - resourceLabel.Height + resourceLabel.Padding.Vertical ;
			if ( h < 0 ) h = 0 ;
			int h2 = h >> 1 ;
			h = ( h + 1 ) >> 1 ;
			searchLabel.Padding = new Padding ( searchLabel.Padding.Left , h , searchLabel.Padding.Right , h2 ) ;
			uriLabel.Padding = new Padding ( uriLabel.Padding.Left , h , uriLabel.Padding.Right , h2 ) ;
			resourceTypeLabel.Padding = new Padding ( resourceTypeLabel.Padding.Left , h , resourceTypeLabel.Padding.Right , h2 ) ;
			resourceLabel.Padding = new Padding ( resourceLabel.Padding.Left , h , resourceLabel.Padding.Right , h2 ) ;
			
			//h = searchBox.Bottom ;
			//h2 = buttonPanel.Height - buttonPanel.Padding.Vertical ;
			////topPanel.AutoSize = false ;
			//if ( h2 >= h )
			//	buttonPanel.Padding = 
			//	statusPanel.Padding = Padding.Empty ;
			//else 
			//{
			//	buttonPanel.Padding = Padding.Empty ;
			//	statusPanel.Padding = new Padding ( 0 , h - h2 , 0 , 0 ) ;
			//}
			//topPanel.AutoSize = true ;
			statusPanel.ResumeLayout () ;
			//topPanel.ResumeLayout () ;
			
		}
		/// <summary>
		/// Set method for searchBoxVisible property
		/// </summary>
		/// <param name="value">New value for searchBoxVisible property</param>
		protected void setSearchBoxVisible ( bool value )
		{
			if ( value == searchBox.Visible ) return ;
			statusPanel.SuspendLayout () ;
			searchButton.Visible = searchBoxCanBeVisible && !value ;
			if ( value != searchBox.Visible ) 
			{
				searchSplitter.Margin = new Padding ( 0 , 0 , value ? 8 : 0 , 0 ) ;
				searchLabel.Visible = value ;
				searchBox.Visible = value ;
				searchSplitter.Visible = value ;
				statusPanel.Controls.SetChildIndex ( searchButton , 0 ) ;
				statusPanel.Controls.SetChildIndex ( searchLabel , 1 ) ;
				statusPanel.Controls.SetChildIndex ( searchBox , 2 ) ;
				statusPanel.Controls.SetChildIndex ( searchSplitter , 3 ) ;
			}
			statusPanel.ResumeLayout () ;
		}
		/// <summary>
		/// This property sets/gets search box visibility
		/// </summary>
		public bool searchBoxVisible
		{
			get => searchBox.Visible ;
			protected set => setSearchBoxVisible ( value ) ;
		}
		/// <summary>
		/// Get method for searchBoxCanBeVisible 
		/// </summary>
		/// <returns>Returns true if log list is not empty</returns>
		protected bool getSearchBoxCanBeVisible ()
		{
			return logList.Items.Count > 0 ;
		}
		/// <summary>
		/// Returns true if log list is not empty(search be applied), otherwise false
		/// </summary>
		protected bool searchBoxCanBeVisible 
		{
			get => getSearchBoxCanBeVisible () ;
		}

		/// <summary>
		/// Auxiliary variable for searchBoxDemanded property
		/// </summary>
		public bool _searchBoxDemanded ;
		/// <summary>
		/// Get method to initialize searchBoxDemanded property value
		/// </summary>
		public bool getSearchBoxDemanded ()
		{
			RegistryKey key = null ;
			bool ret = false ;
			try
			{
				key = Application.UserAppDataRegistry ;
				ret = ( int ) key.GetValue ( "ShowLogSearch" ) != 0;
			}
			catch { }
			try
			{
				if ( key != null )
				{
					key.Close () ;
					key.Dispose () ;
				}
			}
			catch { }
			return ret ;
		}
		protected void loadSearchBoxWidth ()
		{
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				searchBox.Width = ( int ) key.GetValue ( "SearchBoxWidth" ) ;
			}
			catch { }
			try
			{
				if ( key != null )
				{
					key.Close () ;
					key.Dispose () ;
				}
			}
			catch { }
		}
		protected void saveSearchBoxWidth ()
		{
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				key.SetValue ( "SearchBoxWidth" , searchBox.Width , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				if ( key != null )
				{
					key.Close () ;
					key.Dispose () ;
				}
			}
			catch { }
		}
		/// <summary>
		/// Set method for searchBoxDemanded property
		/// </summary>
		/// <param name="value">New value method for searchBoxDemanded property</param>
		public void setSearchBoxDemanded ( bool value )
		{
			searchBoxVisible = value ? searchBoxCanBeVisible : false ;
			if ( _searchBoxDemanded == value ) return ;
			_searchBoxDemanded = value ;
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				key.SetValue ( "ShowLogSearch" , value ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }

			try
			{
				if ( key != null )
				{
					key.Close () ;
					key.Dispose () ;
				}
			}
			catch { }
		}
		/// <summary>
		/// This property value is true if user demands search box to be visible
		/// </summary>
		public bool searchBoxDemanded
		{
			get => _searchBoxDemanded ;
			protected set => setSearchBoxDemanded ( value ) ;
		}
		private void searchSplitter_MouseDown ( object sender, MouseEventArgs e )
		{
			searchBoxWidth = searchBox.Width ;
		}
		private void searchSplitter_SplitterMoved ( object sender , SplitterEventArgs e )
		{
			//searchBox.BackColor = SystemColors.Window ;
			if ( searchBox.Enabled )
				saveSearchBoxWidth () ;
			else
			{
				searchLabel.ForeColor = SystemColors.ControlText ;
				searchBox.Enabled = true  ;
				searchBoxDemanded = false ;
				searchBox.Width = searchBoxWidth ;

			}
		}

		private void searchSplitter_SplitterMoving ( object sender , SplitterEventArgs e )
		{
			if ( e.SplitX > searchBox.MaximumSize.Width )
			{
				searchBox.Enabled = true ;
				e.SplitX = searchBox.MaximumSize.Width ;
				searchBox.BackColor = SystemColors.Window ;
			}
			else if ( e.X > searchBox.Left + searchBox.MinimumSize.Width )
			{
				//searchBox.BackColor = SystemColors.Window ;
				searchBox.Enabled = true ;
				searchLabel.ForeColor = SystemColors.ControlText ;
				searchBox.Invalidate () ;
			}
			else
			{
				searchBox.Enabled = false ;
				//searchBox.BackColor = SystemColors.ButtonFace ;
				searchLabel.ForeColor = SystemColors.GrayText ;
				searchBox.Invalidate () ;
			}
		}

		private void searchSplitter_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void searchButton_Click ( object sender , EventArgs e )
		{
			searchBoxDemanded = true ;
			try
			{
				searchBox.Focus () ;
			}
			catch{ }
		}


		private void requestPanel_Layout ( object sender , LayoutEventArgs e )
		{
			setClosePropertiesButtonLocation () ;
		}

		private void splitter_MouseEnter ( object sender , EventArgs e )
		{
			Splitter splitter = ( Splitter ) sender ;
			splitter.Controls[0].Visible = false ;
			splitter.BorderStyle = BorderStyle.FixedSingle ;
			splitter.BackColor = SystemColors.ButtonShadow ;
		}

		private void splitter_MouseLeave ( object sender , EventArgs e )
		{
			Splitter splitter = ( Splitter ) sender ;
			splitter.Controls[0].Visible = true ;
			splitter.BorderStyle = BorderStyle.None ;
			splitter.BackColor = SystemColors.Control ;
		}

		private void midPanel_Resize ( object sender , EventArgs e )
		{
			if ( propertiesVisible )
			{
				if ( midPanel.ClientSize.Width < 200 )
					propertiesPanel.Width = midPanel.ClientSize.Width >> 1 ;
				else if ( propertiesPanel.Width > midPanel.ClientSize.Width - 200 )
					propertiesPanel.Width = midPanel.ClientSize.Width - 200 ;
			}
		}

		private void jsonEditor_Click(object sender, EventArgs e)
		{
			//API.SetTabWidth ( jsonEditor.Handle , 8 ) ;
		}

		private void viewSwitch_Click (object sender, EventArgs e)
		{
			if ( jsonEditorVisible = !jsonEditorVisible )
				quickStartForm?.Hide () ;
		}

		private void monitorSwitch_Click ( object sender, EventArgs e )
		{
			monitorActive = !monitorActive ;
		}

		private void startStopSwitch_Click ( object sender, EventArgs e )
		{
			if ( isListening )
			{
				closeProgramDemand = false ;
				closeProgramConfirmed = false ;
				showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
										"Stoping server" , "Do you want to stop http server?" ,
										"Stop server" , "" , "Keep server working" ) ;

			} 
			else 
			if ( quickStartForm == null )
				startJSONConfigMenuItemClick() ;
			else if ( quickStartForm.Visible )
			{
				quickStartForm_paremetersChoosen ( quickStartForm , quickStartForm.getStartParameters () ) ;
				quickStartForm.BringToFront () ;
				quickStartForm.Select () ;
			}
			else startJSONConfigMenuItemClick() ;
		}

		private void jsonEditor_VisibleChanged ( object sender , EventArgs e )
		{
			if ( jsonEditor.Visible ) API.SetTabWidth ( jsonEditor.Handle , 8 ) ; //why 8?

		}
		private void viewSwitch_MouseEnter ( object sender , EventArgs e )
		{
			if ( jsonEditorVisible ) viewSwitch.BackgroundImage = images24.Images [ "monitorHover" ] ;
		}

		private void viewSwitch_MouseLeave ( object sender , EventArgs e )
		{
			if ( jsonEditorVisible ) viewSwitch.BackgroundImage = images24.Images [ "monitor" ] ;
		}
	}
}