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
using Newtonsoft.Json ;
using Newtonsoft.Json.Linq ;
using Microsoft.Win32 ;
using System.Text.RegularExpressions ;
using System.DirectoryServices.ActiveDirectory ;
using System.Diagnostics.Eventing.Reader ;
using System.Drawing.Drawing2D ;
using System.Net.Http.Headers;
using System.ComponentModel.Design;
using System.DirectoryServices;

namespace SimpleHttp
{
	public partial class MonitorForm : Form
	{
		public static readonly Process currentProcess ;
		public static readonly Pen borderPen ;
		public static readonly Brush backgroundBush ;
		public static readonly Color inactiveEditBackColor ; 
		public static readonly Color errorEditBackColor ;
		public static readonly Color titleBackColor ;
		public static readonly Color titleForeColor ;
		public static readonly Brush toolTipForeBrush ;
		public static readonly FlatButtonAppearance flatButtonAppearance ;
		static MonitorForm ()
		{
			currentProcess = Process.GetCurrentProcess () ;
			borderPen = SystemPens.ControlDark ;
			backgroundBush = SystemBrushes.Control ;
			inactiveEditBackColor = mixColors ( SystemColors.Window , SystemColors.ButtonFace ) ;
			//col2 = SystemColors.ActiveCaption ;
			titleBackColor = SystemColors.ControlDarkDark ;
			titleForeColor = SystemColors.ControlLightLight ;
			errorEditBackColor = Color.MistyRose ;
			toolTipForeBrush = new SolidBrush ( SystemColors.InfoText ) ;

			//	FlatButtonAppearance is not abstract
			//	yet it cannot be created
			//	fuck you Microsoft
			//	fuck you Microsoft
			//	fuck you Microsoft
			//	fuck you Microsoft
			//	fuck you Microsoft
			//	I could make new class but I CANNOT MAKE CONSTRUCTOR
			Button button = new Button () ; 
			flatButtonAppearance = button.FlatAppearance ;
			button.Dispose () ;
			//flatButtonAppearance.BorderColor = Color.Transparent ;
			// fuck this retards, who created this ?
			flatButtonAppearance.BorderSize = 0 ;
			flatButtonAppearance.MouseDownBackColor = SystemColors.ControlLight ;
			//col2 = SystemColors.ActiveCaption ;
			flatButtonAppearance.MouseOverBackColor = SystemColors.ControlLightLight ;
		}
		/// <summary>
		/// Because FlatButtonAppearance class is bullsht
		/// </summary>
		/// <param name="button">Button to assign FlatButtonAppearance values to</param>
		/// <param name="flatButtonAppearance">FlatButtonAppearance instance</param>
		public static void AssingFlatButtonAppearance ( Button button , FlatButtonAppearance flatButtonAppearance )
		{
			button.FlatAppearance.BorderColor = flatButtonAppearance.BorderColor ;
			button.FlatAppearance.BorderSize = flatButtonAppearance.BorderSize ;
			button.FlatAppearance.MouseDownBackColor = flatButtonAppearance.MouseDownBackColor ;
			button.FlatAppearance.MouseOverBackColor = flatButtonAppearance.MouseOverBackColor ;
		}
		/// <summary>
		/// Because FlatButtonAppearance class is bullsht
		/// </summary>
		/// <param name="button">Button to assign FlatButtonAppearance values to</param>
		public static void AssingFlatButtonAppearance ( Button button )
		{
			AssingFlatButtonAppearance ( button , flatButtonAppearance ) ;
		}
		public MonitorForm() : this ( new HttpStartParameters ( new string [ 0 ] ) )
		{
		}
		public MonitorForm ( HttpStartParameters startParameters )
		{
			stringBuilder = new StringBuilder () ;
			iconMenuClosingTimeStamp = Environment.TickCount64 ;

			//SetStyle ( ControlStyles.AllPaintingInWmPaint , true ) ;
			ResizeRedraw = true ;
			//SetStyle ( ControlStyles.ResizeRedraw , false ) ;
			InitializeComponent() ;
			
			AssingFlatButtonAppearance ( minimizeButton ) ;
			AssingFlatButtonAppearance ( maximizeButton ) ;
			AssingFlatButtonAppearance ( closeButton ) ;
			AssingFlatButtonAppearance ( searchButton ) ;
			AssingFlatButtonAppearance ( startStopSwitch ) ;
			AssingFlatButtonAppearance ( monitorSwitch ) ;
			AssingFlatButtonAppearance ( viewSwitch ) ;
			AssingFlatButtonAppearance ( menuButton ) ;
			AssingFlatButtonAppearance ( closePropertiesButton ) ;
			

			//uriLabel.Text = "" ;
			resourceLabel.Text = "" ;
			//resourceTypeLabel.Text = "" ;

			closeButton.BackColor = MonitorForm.errorEditBackColor ;

			DoubleBuffered = false ;
			mousePoint = new API.APIPoint () ;
			toolTipPadding = 2 ;

			canBeResourceServer = false ;
			canBeFileServer = false ;


			Visible = false ;
			Opacity =  0.0 ;
			//WindowState = FormWindowState.Minimized ; //!!!!

			JsonSerializerSettings settings = new JsonSerializerSettings () ;
			settings.Formatting = Formatting.Indented ;


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

			EventArgs e = new EventArgs () ;
			splitter_MouseLeave ( searchSplitter , e ) ;
			splitter_MouseLeave ( logListSplitter , e ) ;
			splitter_MouseLeave ( this.propertiesSplitter , e ) ;
			webServer = null ;
		}
		protected int textWidthHint ;
		protected int textWidthLeftHint ;
		protected int textWidthRightHint ;

		protected long iconMenuClosingTimeStamp ;
		/// <summary>
		/// Tooltop text brush
		/// </summary>
		
		/// <summary>
		/// Tooltop padding
		/// </summary>
		protected int toolTipPadding ;
		/// <summary>
		/// Mouse point during splitter drag
		/// </summary>
		protected API.APIPoint mousePoint ;
		/// <summary>
		/// Absolute screen mouse x-coordinate when seaechSplitter starts dragging
		/// </summary>
		protected int searchBoxMouseDownX ;
		/// <summary>
		/// SearchBox wdth during dragg/resizing
		/// </summary>
		protected int newSearchBoxWidth ;

		protected int searchSplitterMouseDownX ;
		protected MessageForm messageForm ;
		protected QuickStartForm quickStartForm ;
		protected PipeSecurity pipeSecurity ;
		protected ResourcesForm resourcesForm ;
		/// <summary>
		/// If given json config has at least one ResourcesHttpService instacne 
		/// </summary>
		protected bool canBeResourceServer ;
		/// <summary>
		/// If given json config has at least one FileHttpService instacne 
		/// </summary>
		protected bool canBeFileServer ;
		/// <summary>
		/// When use choose to close program,
		/// dialog is not modal so we need a flag
		/// </summary>
		protected bool closeProgramConfirmed ;
		//protected string webroot ;
		//protected string source ;
		protected NamedPipeServerStream recivier ;
		//protected string resourceAssemblyName ;
		//protected int port ;
		///// <summary>
		///// Full current site uri
		///// </summary>
		//protected Uri siteUri ;
		//protected SslProtocols protocol ;
		/// <summary>
		/// True if the given command line parameters actually started the server.
		/// </summary>
		protected bool autoStarted ;
		protected WebServer webServer ;
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
		/// Current start parameters if server activated from the quickStartForm otherwise null
		/// </summary>
		protected HttpStartParameters currentStartParameters ;
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
				toolTip.SetToolTip ( viewSwitch , "Show log" ) ;
				jsonEditor.BringToFront () ;
			}
			else 
			{
				_jsonEditorVisible = false ;
				jsonEditor.Visible = false ;
				toolTip.SetToolTip ( viewSwitch , "Show configuration script" ) ;
				midPanel.Visible = true ;
				midPanel.BringToFront () ;
			}
			viewSwitch.BackgroundImage = value ? SimpleHttp.Properties.Resources.monitorIcon : SimpleHttp.Properties.Resources.jsonIcon ;
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
				toolTip.SetToolTip ( logList , logList.Items.Count == 0 ? "" : "Click to open properties" ) ;
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
		protected bool startPipeReciever ()
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
		protected void setJsonEditorTabs ()
		{
			API.SetTabWidth ( jsonEditor.Handle , 16 ) ; //why 16?
		}
		protected override void OnShown ( EventArgs e )
		{
			base.OnShown ( e ) ;
			unsafe
			{
				iconMenuClosingTimeStamp = Environment.TickCount64 - 10000 ;
			}
			if ( !startPipeReciever() ) return ;
		//	BeginInvoke ( new ThreadStart ( AfterShown ) ) ;
  //      }
		//protected void AfterShown () 
		//{
			restoredWindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : WindowState ;



			

			
			serverMode = programStartParameters.mode ;
			setTextWidthHint ( null ) ;


			responseGrid.Height = requestGrid.ColumnHeadersHeight * 4 + 6 ;

			propertiesVisible = false ;
			loadSearchBoxWidth () ;
			loadSearchBoxVisibility () ;
			//WindowState = FormWindowState.Minimized ;


			BeginInvoke ( new ThreadStart ( readAndExecuteStartingParameters ) ) ;
        }
		protected override void OnActivated(EventArgs e)
		{
			
			base.OnActivated(e) ;
		}
		protected void readAndExecuteStartingParameters ()
		{
			string startingMessage = programStartParameters.errorMessage ;
			jsonEditor.Text = programStartParameters.jsonText ;
			try
			{
				if ( programStartParameters.configData.Properties().Count() != 0 ) jsonEditor.Text = json2string ( programStartParameters.configData ) ; //dont reflect yet, no no
			}
			catch { }
			try
			{ 
				if ( programStartParameters.jsonErrorLineIndex > 0 )
					selectJSONText ( programStartParameters.jsonErrorLineIndex , programStartParameters.jsonErrorColumnIndex ) ;
			}
			catch { }
			try
			{
				_jsonConfigFileName = new FileInfo ( programStartParameters.jsonConfigFile ).FullName ;
			}
			catch		//yes yes
			{
				_jsonConfigFileName = programStartParameters.jsonConfigFile ;
			}

			try
			{
				configFileNameLabel.Text = string.IsNullOrWhiteSpace ( Path.GetFileName ( jsonConfigFileName ) ) ? "<empty>" : Path.GetFileName ( jsonConfigFileName ) ;
			}
			catch { }

			if ( string.IsNullOrWhiteSpace ( startingMessage ) )
			{
				if ( programStartParameters.isEmpty )
					restoreForm () ;
				else if ( string.IsNullOrWhiteSpace ( programStartParameters.jsonConfigFile ) )
				{

					if ( programStartParameters.autoStart )
						if ( autoStarted = startWebServer ( programStartParameters.configData , out startingMessage ) ) 
						{}
						else
						{
							restoreForm ( () =>
							{
								showQuickStartForm ( programStartParameters.configData , true ) ;
								if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
									showWarning ( "Bad starting parameters" ,  startingMessage ) ;
							} ) ;
						}
					else restoreForm ( new Action<WebServerConfigData,bool>(reflectServerStatus) , new object [ 2 ] { programStartParameters.configData , ( programStartParameters.mode == StartServerMode.fileServer ) || ( programStartParameters.mode == StartServerMode.resourceServer ) } ) ;
				}
				else 
				{
					jsonEditorVisible = true ;
					reflectServerStatus ( programStartParameters.configData , false ) ;
					if ( programStartParameters.autoStart )
						autoStarted = startWebServer ( programStartParameters.configData , out startingMessage ) ;
					else restoreForm ( ) ;
				}
			}
			else 
				restoreForm ( () =>
				{
					if ( ( programStartParameters.mode == StartServerMode.fileServer ) || ( programStartParameters.mode == StartServerMode.resourceServer ) )
						showQuickStartForm ( programStartParameters.configData ) ;
					if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
						showWarning ( "Bad starting parameters" , startingMessage ) ;
				} ) ;
		}
		
		protected override void OnDeactivate ( EventArgs e )
		{
			if ( !statusPanel.Visible ) reverTitlePanelControls () ; //possible situation if form lose focus during splitter dragging
			base.OnDeactivate(e) ;
		}

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
				restoreForm () ;
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
				startServerFromCurrentJSON  () ;
			else 
			{
				jsonEditorVisible = true ;
				quickStartForm?.Hide () ;
			}
		}
		protected void startServerFromCurrentJSON ( )
		{
			startServerFromCurrentJSON ( false ) ;
		}
		protected void startServerFromCurrentJSON ( bool ignoreConfigurationErrors )
		{
			WebServerConfigData configData = getConfigDataFromJSON ( true , false ) ;
			if ( configData == null ) return ;
			string errorMessage ;
			string configErrors ;
			currentStartParameters = null ;
			if ( ignoreConfigurationErrors )
			{
				if ( !startWebServer ( configData , out errorMessage ) )
					showWarning ( "Server not started" , errorMessage ) ;
			}
			else 
				if ( startWebServer ( configData , out configErrors , out errorMessage ) )
				{ 
					if ( !string.IsNullOrWhiteSpace ( configErrors ) )
						showWarning ( "Server is running" , "Server is running, some configuration errors are ignored.\r\n" + configErrors ) ;
				}
				else 
					if ( string.IsNullOrWhiteSpace ( configErrors ) )
						showWarning ( "Server not started" , errorMessage ) ;
					else showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Server configuration errors" , "Configuration error(s):\r\n" + configErrors + "\r\n Do you want to start server anywahy?" , "Ignore, run server" , "" , "Close" ) ;
		}
		protected void selectJSONText ( JsonReaderException jsonException ) 
		{
			selectJSONText ( jsonException.LineNumber , jsonException.LinePosition ) ;
		}
		protected void selectJSONText ( int lineNumber , int columnPosition ) 
		{
			try
			{
				int lineStartPosition = -1 ; //!!!!
				//int length = jsonEditor.Text.Length ;
				//for ( int i = 0 ; i < length ; i++ )
				//	switch ( jsonEditor.Text [ i ] )
				//	{
				//		case ' ' :
				//		case '\t' :
				//		case '\r' :
				//		case '\n' :
				//		break ;
				//		default :
				//			lineStartPosition = i ;
				//			i = length + 1 ;
				//		break ;
				//	}
				for ( int currentLine = 1 ; currentLine < lineNumber ; currentLine++ )
					lineStartPosition = jsonEditor.Text.IndexOf ( "\r\n" , lineStartPosition + 1 ) ;
				int selectionStart = lineStartPosition + columnPosition + 1 ; 
				jsonEditor.SelectionStart = selectionStart ;
				jsonEditor.ScrollToCaret () ;
				jsonEditor.SelectionLength = Math.Min ( 2 , jsonEditor.Text.Length - jsonEditor.SelectionStart ) ;
				if ( jsonEditor.SelectionLength == 0 )
				{
					jsonEditor.SelectionStart = selectionStart -1 ;
					jsonEditor.SelectionLength =  1 ;
				}
			}
			catch { }
		}
		/// <summary>
		/// Auxiliary variable for the jsonConfigFileName 
		/// </summary>
		protected string _jsonConfigFileName ;
		/// <summary>
		/// Name and path to json config file
		/// </summary>
		public string jsonConfigFileName 
		{
			get => _jsonConfigFileName ;
		}
		protected WebServerConfigData getConfigDataFromJSON ( bool showErrorMessage )
		{
			return getConfigDataFromJSON ( showErrorMessage , false ) ;
		}
		protected WebServerConfigData getConfigDataFromJSON ( bool showErrorMessage , bool ignoreEmpty )
		{
			
			WebServerConfigData configData = new WebServerConfigData () ;
			try
			{
				if ( string.IsNullOrWhiteSpace ( jsonEditor.Text ) ) 
				{
					if ( showErrorMessage && !ignoreEmpty ) showInfo ( "No JSON configuration" , "No text int JSON coniguration box." ) ;
					return null ;
				}
				JObject jObject = JObject.Parse ( jsonEditor.Text ) ;
				try
				{
					configData.loadFromJSON ( jObject ) ;
				}
				catch ( EmptyJSONException )
				{
					return null ;
				}
				catch ( Exception x1 )
				{ 
					if ( showErrorMessage ) showError ( "Bad JSON configuration" , x1 ) ;
					return null ;
				}
				return configData ;
			}
			catch ( JsonReaderException jsonException )
			{
				reflectServerStatus ( configData , false ) ;
				jsonEditorVisible = true ;
				if ( showErrorMessage ) showError ( "Error parsing JSON" , jsonException ) ;
				selectJSONText ( jsonException ) ;
			}
			catch ( Exception x )
			{
				reflectServerStatus ( configData , false ) ;
				jsonEditorVisible = true ;
				if ( showErrorMessage ) showError ( "Error parsing JSON" , x ) ;
			}
			return null ;
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
				showQuickStartForm ( getConfigDataFromJSON ( true , true ) ) ; //currentStartParameters == null ? programStartParameters : currentStartParameters ) ;
			}
				//showQuickStartForm ( currentStartParameters.configData , certificate ) ; //currentStartParameters == null ? programStartParameters : currentStartParameters ) ;
			else if ( quickStartForm.Visible )
				quickStartForm.Select () ;
			else
			{
				quickStartForm.Show ( this ) ;
				quickStartForm.configData = getConfigDataFromJSON ( true , true ) ;
			}
			//quickStartForm.mode = serverMode ;
		}
		//protected void loadQuickStartForm ( HttpStartParameters startParameters )
		//{
		//	loadCertificate ( startParameters ) ;
		//	loadQuickStartForm ( startParameters , certificate ) ;
		//}
		protected void showQuickStartForm ( WebServerConfigData configData )
		{
			showQuickStartForm ( configData , false ) ;
		}
		protected void showQuickStartForm ( WebServerConfigData configData , bool forceConfigData )
		{
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
				quickStartForm.ExportConfig += quickStartForm_ExportConfig ;
				//quickStartForm.FormClosing += quickStartForm_FormClosing ;
				quickStartForm.Disposed += quickStartForm_Disposed ;
			}
			else 
			{
				if ( quickStartForm.Visible )
				{
					if ( forceConfigData )
						quickStartForm.configData = configData ;
				}
				else 
				{
					quickStartForm.Visible = true ;
					quickStartForm.configData = configData ;
				}
			}
			quickStartForm.configData = configData ;
			if ( messageForm != null )
				if ( messageForm.Visible )
				{
					messageForm.BringToFront () ;
					messageForm.Select () ;
					return ;
				}
			quickStartForm.BringToFront () ;
			quickStartForm.Select () ;
		}

		private void showCommandLineMenuItem_Click ( object sender , EventArgs e )
		{
			showStartingCommandLine () ;
		}
		private void quickStartForm_showStartParameters ( object sender , HttpStartParameters e )
		{
			showStartParameters ( quickStartForm.getStartParameters () ) ;
		}
		private void quickStartForm_ExportConfig ( object sender , WebServerConfigData configData )
		{
			loadJSONFromQuickStartForm ( false ) ;
		}
		private void loadJSONFromQuickStartForm ( bool ignoreUnsavedChanges )
		{
			if ( quickStartForm == null ) return ;
			string jsonString = json2string ( quickStartForm.configData ) ;
			if ( jsonString == jsonEditor.Text ) 
				showInfo ( "Current json configuration" , "No changes were made" ) ;
			else  if ( ( configFileNameLabel.Text == "<not saved>" ) && !ignoreUnsavedChanges )
				showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Current json configuration not saved" , "Current json configuration is changed but not saved.\r\nDo you want to save it now?" , "Save now" , "Overwrite, ignore changes" , "Cancel" ) ;
			else
			{
				jsonEditor.Text = jsonString ;
				setJsonEditorTabs () ;
				configFileNameLabel.Text = "<not saved>" ;
				reflectServerStatus ( quickStartForm.configData , false ) ;
			}
		}
		private void showResourceForm ( Assembly assembly )
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
		private void quickStartForm_resourceViewNeeded ( object sender , Assembly assembly )
		{
			showResourceForm ( assembly ) ;
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
				//siteUri =  ;
				uriLabel.Text = configData == null ? "" : configData.getSiteUri ().ToString () ;
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
				uriLabel.Text = new Uri ( ( secure ? "https://" : "http://" ) + ( string.IsNullOrWhiteSpace ( siteName ) ? "127.0.0.1" : siteName ) + ":" + port.ToString() ).ToString () ; ;
			}
			catch 
			{ 
				uriLabel.Text = "?" ;
			}
		}
		private void quickStartForm_paremetersChoosen ( object? sender , HttpStartParameters e )
		{
			startFromQuickStartForm ( e , false ) ;

		}
		private void startFromQuickStartForm ( HttpStartParameters e , bool ignoreNotSaved )
		{
			string errorMessage ;
			string jsonString = json2string ( e.configData ) ;
			if ( !ignoreNotSaved && ( configFileNameLabel.Text == "<not saved>" ) )
				if ( jsonString != jsonEditor.Text )
				{ 
					showMessage ( SimpleHttp.Properties.Resources.warningIcon , "Starting web server" , "Current json configuration is changed but not saved.\r\nDo you want to save it now?" , "Save now" , "Overwrite and run server" , "Cancel" ) ;
					return ;
				}
			currentStartParameters = quickStartForm.getStartParameters () ;
			if ( startWebServer ( e.configData , out errorMessage ) )
			{
				jsonEditor.Text = jsonString ;
				quickStartForm.Hide () ;
				restoreForm () ;
			}
			else 
				BeginInvoke ( ()=>
				{
					showErrorMessage ( "Error starting " + ( quickStartForm.mode == StartServerMode.fileServer ? "file" : "resource" ) + " based server" , errorMessage ) ;
					//quickStartForm.SendToBack () ;  //fuuuck this does OPOSITE!!!!
					//quickStartForm.Activated += quickStartForm1_Activated;
				} ) ;
		}

		private void quickStartForm1_Activated(object? sender, EventArgs e)
		{
			quickStartForm.Activated -= quickStartForm1_Activated;
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
					if ( messageForm.title == "Certificate failed on client side" )
					{
						showWarning( 
							"Certificate failed" , 
							"Client side error:\r\n" + 
							messageForm.messageText  + "\r\nServer side error:\r\n" + e.GetException().Message ) ;
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
					if ( messageForm.title == "Certificate failed on server side" )
					{
						showWarning( "Certificate failed" , 
							"Client side error:\r\n" + 
							e.GetException().Message + "\r\nServer side error:\r\n" + messageForm.messageText ) ;
						return ;
					}
				showError ( "Certificate failed on client side" , e.GetException() ) ;
			} ) ;
		}
		private bool startWebServer ( WebServerConfigData configData , out string errorMessage )
		{
			errorMessage = "" ;
			try
			{
				setSiteUri ( configData ) ;
				//setSiteUri ( !string.IsNullOrEmpty ( configData.sslCertificateSource ) , configData.sitename , port = configData.port ) ;
				//protocol = configData.sslProtocol ;
				//certificate = configData.sslCertificate ;
				int length = 0 ;
				foreach ( Exception x in configData.errorList )
					length = length + x.Message.Length + 2 ;
				StringBuilder stringBuilder = new StringBuilder ( length ) ;
				foreach ( Exception x in configData.errorList )
				{
					stringBuilder.Append ( x.Message ) ;
					stringBuilder.Append ( '\r' ) ;
					stringBuilder.Append ( '\n' ) ;
				}
				
				webServer = new WebServer (		webServer_clientConnected , webServer_serverResponded ,
												webServer_started , webServer_stoped , 
												webServer_connectionErrorRaised , 
												webServer_serviceErrorRaised , webServer_disposed ) ;
				webServer.Listen ( configData ) ;
				if ( stringBuilder.Length > 2 ) 
					errorMessage = "Server is running, configuration errors are ignored:\r\n" + stringBuilder.ToString () ;
				return true ;
			}
			catch ( Exception x )
			{ 
				errorMessage = "Error starting server.\r\n" + 
								( x.InnerException == null ? x.Message : x.InnerException.Message  ) ;
				webServer?.Dispose () ;
			}
			return false ;

		}
		private bool startWebServer ( WebServerConfigData configData , out string configErrors , out string errorMessage )
		{
			errorMessage = "" ;
			configErrors= "" ;
			try
			{
				setSiteUri ( configData ) ;
				//setSiteUri ( !string.IsNullOrEmpty ( configData.sslCertificateSource ) , configData.sitename , port = configData.port ) ;
				//protocol = configData.sslProtocol ;
				//certificate = configData.sslCertificate ;
				int length = 0 ;
				foreach ( Exception x in configData.errorList )
					length = length + x.Message.Length + 2 ;
				StringBuilder stringBuilder = new StringBuilder ( length ) ;
				foreach ( Exception x in configData.errorList )
				{
					stringBuilder.Append ( x.Message ) ;
					stringBuilder.Append ( '\r' ) ;
					stringBuilder.Append ( '\n' ) ;
				}
				if ( stringBuilder.Length > 2 ) 
				{
					configErrors = stringBuilder.ToString ().Substring ( 2 ) ;
					return false ;
				}
				
				webServer = new WebServer (		webServer_clientConnected , webServer_serverResponded ,
												webServer_started , webServer_stoped , 
												webServer_connectionErrorRaised , 
												webServer_serviceErrorRaised , webServer_disposed ) ;
				webServer.Listen ( configData ) ;
				return true ;
			}
			catch ( Exception x )
			{ 
				errorMessage = "Error starting server.\r\n" + 
								( x.InnerException == null ? x.Message : x.InnerException.Message  ) ;
				webServer?.Dispose () ;
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
				BeginInvoke ( new Action<WebServerConfigData,bool>(reflectServerStatus) , webServer.configData , false ) ;
			}
		}
		
		
		protected void webServer_stoped ( object sender , EventArgs e )
		{
			if ( IsDisposed ) return ;
			if ( webServer == null ) return ;
			BeginInvoke ( () =>
			{
				if ( IsDisposed ) return ;
				if ( webServer == null ) return ;

				WebServerConfigData configData = webServer.configData ;
				webServer.Dispose () ; 
				reflectServerStatus ( configData , true ) ;
				
			} ) ;
		}
		protected void stopServerAndCloseProgram ()
		{
			webServer?.Stop ( true ) ;
			webServer?.Dispose () ;
			closeProgramConfirmed = true ;
			Close () ;
		}
		protected void stopServerAndReflectServerStatus ()
		{
			if ( webServer == null ) return ;
			WebServerConfigData configData = webServer.configData ;
			webServer.Stop ( true ) ;
			webServer?.Dispose () ; 
			reflectServerStatus ( configData , true ) ;
		}

		protected void reflectServerStatus ( WebServerConfigData configData , bool autoQuickStartForm )
		{
			string baloonTipText = "." ;
			string baloonTipTitle = "." ;
			string notifyIconText = ( string.IsNullOrWhiteSpace ( configData.sslCertificateSource ) ? "Flat http" : 
				QuickStartForm.sslProtocolsShort [ configData.sslProtocol ] ) + " on port " + configData.port.ToString () ;
			notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
			setSiteUri ( configData ) ;

			bool isListeningActive = isListening ;
			string serverStatus = isListeningActive ? "working" : "stoped" ; 
			ResourceWebConfigData resourceConfigData = configData as ResourceWebConfigData ;

			if ( isListeningActive ) quickStartForm?.Hide () ;
			resourceLabel.Text = "" ;
			resourceTypeLabel.Text = "" ;
			string path ;
			string resourceNamePrefix ;
			string debugPathPrefix ;
			bool useDebugService  ;
			serverMode = QuickStartForm.getMode ( configData , out path , out resourceNamePrefix , out useDebugService , out debugPathPrefix ) ;
			
			switch ( serverMode )
			{
				case StartServerMode.fileServer :
					resourceLabel.Text = path ;
					notifyIconText = notifyIconText + ", assembly:\r\n" + resourceLabel.Text ;
					baloonTipText = "Assembly: " + resourceLabel.Text  ;
					baloonTipTitle = "Resource based http server is " + serverStatus ;
					if ( autoQuickStartForm  && !isListeningActive )
						restoreForm ( new Action<WebServerConfigData> ( showQuickStartForm ) , new object [ 1 ] { configData } ) ;
				break ;
				case StartServerMode.resourceServer :
					resourceLabel.Text = path ;
					notifyIconText = notifyIconText + ", webroot:\r\n" + resourceLabel.Text ;
					baloonTipTitle = "File based http server is " + serverStatus ;
					baloonTipText = "Web root folder:\r\n" + resourceLabel.Text ;
					if ( autoQuickStartForm  && !isListeningActive )
						restoreForm ( new Action<WebServerConfigData> ( showQuickStartForm ) , new object [ 1 ] { configData } ) ;
				break ;
				case StartServerMode.jsonConfig :
					baloonTipText = "Config: " + configFileNameLabel.Text ;
					baloonTipTitle = "Http server is " + serverStatus ;
				break ;
			}
			if ( configData.errorList.Count > 0 ) 
			{
				notifyIconText += "\r\nThere are configuration errors" ;
				baloonTipText = "There are configuration errors\r\n" + baloonTipText ;
			}
			notifyIcon.ShowBalloonTip ( 3000 , baloonTipTitle , baloonTipText , ToolTipIcon.Info ) ;
			notifyIcon.Text = notifyIconText.Substring ( 0 , Math.Min ( 127 , notifyIconText.Length ) ) ;
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
		public string json2string ( JObject jObject )
		{
			WebServerConfigData.json2string ( jObject , stringBuilder ) ;
			return stringBuilder.ToString () ;
		}
		
		protected void setActiveStateIcon ()
		{
			if ( isListening )
			{
				Icon =
				notifyIcon.Icon = monitorActive ? SimpleHttp.Properties.Resources.activeMonitorIcon : SimpleHttp.Properties.Resources.activeIcon ;
				startStopSwitch.BackgroundImage = SimpleHttp.Properties.Resources.stop ;
				toolTip.SetToolTip ( startStopSwitch , "Server is running\r\nClick here to stop it" ) ;

				monitorSwitch.BackgroundImage = monitorActive ? SimpleHttp.Properties.Resources.monYellowIcon : SimpleHttp.Properties.Resources.monGreenIcon ;
			}
			else 
			{
				startStopSwitch.BackgroundImage = SimpleHttp.Properties.Resources.play ;
				toolTip.SetToolTip ( startStopSwitch , "Click here to start http(s) server" ) ;
				monitorSwitch.BackgroundImage = monitorActive ? SimpleHttp.Properties.Resources.monWhiteCheckIcon : SimpleHttp.Properties.Resources.monWhiteIcon;
			}
			toolTip.SetToolTip ( monitorSwitch ,  monitorActive ? "Logging is active" : "Click here to activate logging" ) ;
		}
		protected void webServer_serviceErrorRaised ( object sender , HttpConnectionDetails e )
		{
			webServer_connectionErrorRaised ( sender , e  ) ;
			//WebServerConfigData configData = webServer.configData ;
			//if ( !webServer.isListening ) webServer.Dispose () ;
			//BeginInvoke ( ()=>
			//{
			//	if ( webServer != null ) return ; //server restarted ?
			//	string s = "Http server is down,\r\n" + ( e.error == null ? "<Uknown error>" : e.error.InnerException == null ? e.error.Message : e.error.InnerException.Message ) ;
			//	isCriticalError = true ;
			//	notifyIcon.Text = s.Substring ( 0 , Math.Min ( 127 , s.Length ) ) ;
			//	Icon = notifyIcon.Icon = SimpleHttp.Properties.Resources.stopIcon ;
			//	notifyIcon.ShowBalloonTip ( 12000 , "Http server critical error" , s , ToolTipIcon.Info ) ;
			//	reflectServerStatus ( configData ) ;
			//} ) ;
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
			if ( webServer == sender as WebServer ) webServer = null ;
		}
		protected int logItemInnerHeight ;
		/// <summary>
		/// I really hate this
		/// </summary>
		protected void calculateLogItemHeight ()
		{
			logItemInnerHeight = logItemTestLabel.Height - logItemTestLabel.Padding.Vertical - 1 ;
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
				if ( WindowState == FormWindowState.Maximized )
				{
					maximizeButton.BackgroundImage = SimpleHttp.Properties.Resources.restoreIcon ;
					toolTip.SetToolTip ( maximizeButton , "Restore" ) ;
				}
				else 
				{
					toolTip.SetToolTip ( maximizeButton , "Miximize" ) ;
					maximizeButton.BackgroundImage = SimpleHttp.Properties.Resources.maximizeIcon ;;
				}
				//if ( Opacity == 0f ) 
				//{
				//	Opacity = 1.0f ;
				//}
				calculateLogItemHeight  () ;
				restoredWindowState = WindowState ;	
				SetBoxRegion ( this ) ;
			}
			base.OnResize ( e ) ;
		}
		public static void CreateSemiboldFonts ( Font fontPrototype , out Font semiboldFont , out Font semiboldUnderlineFont ) 
		{
			CreateSemiboldFonts ( fontPrototype.Name , fontPrototype.SizeInPoints , out semiboldFont , out semiboldUnderlineFont ) ;
		}
		public static void CreateSemiboldFonts ( string fontName , float fontSizeInPoints , out Font semiboldFont , out Font semiboldUnderlineFont ) 
		{
			semiboldFont = GetNewSemiboldFont ( fontName , fontSizeInPoints ) ;
			semiboldUnderlineFont = new Font ( semiboldFont , FontStyle.Underline ) ;
		}
		public static Font GetNewTitleFont ( Font fontPrototype ) 
		{
			return GetNewSemiboldFont ( fontPrototype.Name , 1.15f * fontPrototype.SizeInPoints ) ;
		}
		public static Font GetNewSemiboldFont ( string fontName , float fontSizeInPoints ) 
		{
			Font semiboldFont = null ;
			string newFontName = string.Concat ( fontName , " Semibold" ) ;
			try
			{
				semiboldFont = new Font ( newFontName , fontSizeInPoints , FontStyle.Regular , GraphicsUnit.Point ) ;
			}
			catch { }
			if ( semiboldFont == null ) goto bad ;
			if ( semiboldFont.FontFamily.Name == newFontName ) return semiboldFont ;
			semiboldFont.Dispose () ;
bad:
			return new Font ( fontName , fontSizeInPoints , FontStyle.Bold , GraphicsUnit.Point ) ;
		}
		protected override void OnFontChanged ( EventArgs e )
		{
			CreateSemiboldFonts ( Font , out boldFont , out boldUnderlineFont ) ;
			resourceLabel.Font = boldFont ;
			configFileNameLabel.Font = boldFont ;
			resourceLabel.Font = boldFont ;
			requestLabel.Font = boldFont ;
			uriLabel.Font = boldFont ;
			titleTestLabel.Font =
			titleLabel.Font = MonitorForm.GetNewTitleFont ( Font ) ;
			foreach ( Component component in components.Components )
			{
				Control Control = component as Control ;
				if ( Control != null ) Control.Font = Font ;
			}

			//int h = Font.Height  ;
			//closeButton.Size = new Size ( h , h ) ;
			//titlePanel.Height = h << 1 ;
			base.OnFontChanged ( e ) ;
		}
		protected override void OnPaintBackground ( PaintEventArgs e )
		{
			base.OnPaintBackground ( e ) ;
			if ( WindowState == FormWindowState.Normal ) drawBoxBorder ( e.Graphics , Size ) ;
		}
		public static void SetBoxRegion ( Control control )
		{
			Region region = control.Region ;
			control.Region = getNewBoxRegion ( control.Size ) ;
			region?.Dispose () ;
		}
		public static void drawBoxBorder ( Graphics graphics , Size size )
		{
			//graphics.FillRectangle ( Brushes.YellowGreen , new Rectangle ( Point.Empty , size ) ) ;
			//graphics.CompositingQuality = CompositingQuality.HighSpeed ;
			//graphics.InterpolationMode = InterpolationMode.Low ;
			graphics.PixelOffsetMode = PixelOffsetMode.None ;
			graphics.FillRectangle ( backgroundBush , new Rectangle ( Point.Empty , size ) ) ;
			graphics.DrawLine ( borderPen , new Point ( 1 , 0 ) , new Point ( size.Width - 2 , 0 ) ) ;
			graphics.DrawLine ( borderPen , new Point ( size.Width - 1 , 1 ) , new Point ( size.Width - 1 , size.Height - 2 ) ) ;
			graphics.DrawLine ( borderPen , new Point ( 0 , 1 ) , new Point ( 0 , size.Height - 2 ) ) ;
			graphics.DrawLine ( borderPen , new Point ( 1 , size.Height - 1 ) , new Point ( size.Width - 2 , size.Height - 1 ) ) ;
		}
		/// <summary>
		public static Region getNewBoxRegion ( Size size )
		{
			GraphicsPath shape = new GraphicsPath () ;
			shape.AddRectangle ( new Rectangle ( Point.Empty , size ) ) ;
			Size size1 = new Size ( 1 , 1 ) ;
			shape.AddRectangle ( new Rectangle ( Point.Empty , size1 ) ) ;
			shape.AddRectangle ( new Rectangle ( new Point ( 0 , size.Height - 1 ) , size1 ) ) ;
			shape.AddRectangle ( new Rectangle ( new Point ( size.Width - 1 , 0 ) , size1 ) ) ;
			shape.AddRectangle ( new Rectangle ( new Point ( size.Width - 1 , size.Height - 1 ) , size1 ) ) ;
			Region region = new Region ( shape ) ;
			shape.Dispose () ;
			return region ;
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
				toolTip.SetToolTip ( logList , logList.Items.Count == 0 ? "" : "Click to open properties" ) ;
				return ;
			}
			toolTip.SetToolTip ( logList , "" ) ;
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
			string [] lines = connectionDetails.request.headerText.Split ( "\r\n" ) ;
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
			closePropertiesButton.Location = new Point ( closePropertiesButton.Parent.Width - menuButton.Width , 4 ) ;
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
				AddLogItem ( new HttpConnectionItem ( connectionDetails ) ) ;
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
				AddLogItem ( new HttpConnectionItem ( connectionDetails ) ) ;
			} ) ;
		}
		private void AddLogItem ( HttpConnectionItem item )
		{
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
					selectLogItemAndMarkText ( -1 , -1 , 0 ) ;
				else searchItemIndex -= removeCount ;
			}
			listItems.Add ( item ) ;
			if ( logList.ContextMenuStrip == null )
				logList.ContextMenuStrip = logListMenu ;
			toolTip.SetToolTip ( logList , propertiesPanel.Visible ? "" : "Click to open properties" ) ;
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
		protected override void OnKeyDown ( KeyEventArgs e )
		{
			
			//statusPanel.Invalidate () ;		
			//searchPanel.Invalidate () ;
			//searchBox.Invalidate ( true ) ;
			//searchBox.Update () ;
			setTitleLabelPosition() ;
			base.OnKeyDown(e) ;
		}
		private void searchBox_KeyDown ( object sender , KeyEventArgs e )
        {
			if ( titlePanelBitmap == null )
			switch ( e.KeyCode )
			{
				case Keys.Enter :
					if ( jsonEditorVisible )
						searchNextJsonText ( searchBox.Text ) ;
					else searchForNextHeaderItem ( searchBox.Text ) ;
				break ;
				case Keys.F5 :
					logList.Invalidate () ;
				break ;
			}
			else 
			{
				e.Handled = true ;
				if ( e.KeyCode == Keys.Escape ) reverTitlePanelControls () ;
			}
        }
		private void searchBox_KeyPress ( object sender , KeyPressEventArgs e )
		{
			if ( titlePanelBitmap == null )
			{
			}
			else e.Handled = true ;

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
				selectLogItemAndMarkText ( searchItemIndex , searchPosition , searchLength ) ;
				return true ;
			}
		}
		
		//public bool searchForNextHeaderItem ( string searchText )
		//{
		//	return searchForNextHeaderItem ( searchText , true ) ?  true : searchForNextHeaderItem ( searchText , false ) ;
		//}
		/// <summary>
		/// This method tries to select next search text occurrence in the json editor.
		/// </summary>
		/// <param name="searchText">Text to find</param>
		/// <returns>Returns true if successful in search</returns>
		public bool searchNextJsonText ( string searchText )
		{
			if ( string.IsNullOrEmpty ( searchText ) ) return false ;
			if ( searchText.Length > jsonEditor.Text.Length ) return false ;

			try		//I dont trust my self and Im leazy
			 {
				int l = jsonEditor.SelectionStart + jsonEditor.SelectionLength ;
				bool endSelection = l == jsonEditor.Text.Length ;
				int i = jsonEditor.Text.IndexOf ( searchText , endSelection ? 0 : l , StringComparison.OrdinalIgnoreCase ) ;
				if ( ( i == -1 ) && ( jsonEditor.SelectionStart > 0 ) && !endSelection )
						i = jsonEditor.Text.IndexOf ( searchText , StringComparison.OrdinalIgnoreCase ) ;
				if ( i != -1 )
				{
					jsonEditor.SelectionStart = i ;
					jsonEditor.SelectionLength = searchText.Length ;
					jsonEditor.ScrollToCaret () ;
					return true ;
				}
			}
			catch { }
			return false ;
		}
		/// <summary>
		/// Search for next appeareance of the given text in right properties panel(http headers).<br/>
		/// It marks found text.
		/// </summary>
		/// <param name="searchText">Text to find</param>
		/// <returns>Returns true if given text found</returns>
		public bool searchForNextHeaderItem ( string searchText )
		{
			//if ( logList.SelectedIndex == -1  ) 
			//	return searchForItem ( searchText ) ;
			ListBox.ObjectCollection items = logList.Items ;
			if ( string.IsNullOrEmpty( searchText ) ) return false ;
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
						selectLogItemAndMarkText ( searchItemIndex , currentCharIndex , currentLength ) ;
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
						selectLogItemAndMarkText ( i , currentCharIndex , currentLength ) ;
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
						selectLogItemAndMarkText ( i , currentCharIndex , currentLength ) ;
						return true ;
					}
			if ( newSearch && ( searchItemIndex != -1 ) )
			{
				selectLogItemAndMarkText ( searchItemIndex , searchPosition , searchLength ) ;
				return true ;
			}
			return false ;
		}
		/// <summary>
		/// Makes selected item visible(scroll in focus)
		/// </summary>
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
		/// <summary>
		/// This method selects log item and marks selected text on the right panel(headers) 
		/// </summary>
		/// <param name="itemIndex">Item index(in log list)</param>
		/// <param name="charPosition">Char position in log item string</param>
		/// <param name="length">Selection length</param>
		protected void selectLogItemAndMarkText ( int itemIndex , int charPosition , int length )
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
									showProperties () ;
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
			return markSearchInGrid ( searchBox.Text , searchPosition , searchLength , currentLength , grid ) ;
		}
		public static bool markSearchInGrid ( string searchText , int searchPosition , int searchLength  , int currentLength , DataGridView grid )
		{

			if ( searchPosition < 0 ) return false ;
			if ( searchLength <= 0 ) return false ;
			if ( searchLength > searchText.Length ) return false ; //!!!
			
			int rowCount = grid.RowCount ;
			DataGridViewCell cell = null ;
			int maxLength = 0 ;
			string search = searchText.Substring ( 0 , searchLength ) ;
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
				scrollToCell ( cell ) ;
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
		/// <summary>
		/// Make the row with the given cell visible(by scrolling)
		/// </summary>
		/// <param name="cell">Cell to make visible</param>
		public static void scrollToCell ( DataGridViewCell cell )
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
				else {}
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
		public bool tryDialogSave ()
		{
			try
			{
				saveFileDialog.InitialDirectory = Path.GetDirectoryName ( jsonConfigFileName ) ;
				saveFileDialog.FileName = Path.GetFileName ( jsonConfigFileName ) ;
			}
			catch { }
			if ( saveFileDialog.ShowDialog ( this ) == DialogResult.OK )
				return trySaveConfigAs ( saveFileDialog.FileName ) ;
			return false ;					
		}
		private void messageForm_buttonClick ( object sender , MessageForm.ButtonKind buttonKind )
		{
			if ( messageForm != sender ) return ;
			BringToFront () ;
			Select () ;
			if ( ( buttonKind == MessageForm.ButtonKind.cancel ) || ( buttonKind == MessageForm.ButtonKind.close ) )
			{
				closeProgramConfirmed = false ;
				( ( Form ) sender ).Dispose () ;
				focusTopForm () ;
			}
			else switch ( messageForm.title.Trim() )
			{
				case "Stoping server" :
					if ( buttonKind == MessageForm.ButtonKind.ok )
						stopServerAndReflectServerStatus () ;
				break ;
				case "Load new json config file" :
					switch ( buttonKind )
					{
						case MessageForm.ButtonKind.ok :
							tryDialogSave () ;
							browseJsonFile ( true ) ;
						break ;
						case MessageForm.ButtonKind.no :
							messageForm.Hide () ;
							browseJsonFile ( true ) ;
						return ;
					}
				break ;
				case "Server configuration errors" :
					if ( buttonKind == MessageForm.ButtonKind.ok )
						startServerFromCurrentJSON ( true ) ;
				return ; //Yes dont close message form
				case "Starting web server" :
					switch ( buttonKind )
					{
						case MessageForm.ButtonKind.ok :
						if ( tryDialogSave () ) 
							if ( quickStartForm != null )
							{
								string errorMessage ;
								currentStartParameters = quickStartForm.getStartParameters () ;
								if ( startWebServer ( quickStartForm.configData , out errorMessage ) )
								{
									jsonEditor.Text = json2string ( quickStartForm.configData ) ;
									quickStartForm.Hide () ;
								}
							}
						break ;
						case MessageForm.ButtonKind.no :
							//( ( Form ) sender ).Dispose () ;
							messageForm.Hide () ;
							if ( quickStartForm != null ) startFromQuickStartForm ( quickStartForm.getStartParameters () , true ) ;
						break ;
					}
				break ;
				case "Current json configuration not saved" :
					switch ( buttonKind )
					{
						case MessageForm.ButtonKind.ok :
							if ( quickStartForm == null ? false : quickStartForm.Visible )
								saveConfigFileMenuItem_Click ( saveConfigFileMenuItem , new EventArgs () ) ;
							else saveConfigFileMenuItem_Click ( saveConfigFileMenuItem , new EventArgs () ) ;
						break ;
						case MessageForm.ButtonKind.no :
							( ( Form ) sender ).Dispose () ;
							loadJSONFromQuickStartForm ( true ) ;			//loadJSONFromQuickStartForm() method checks if quickStartForm is null, no worries
						break ;
					}
				break ;
				case "Closing program" :
					switch ( buttonKind )
					{
						case MessageForm.ButtonKind.ok :
							if ( messageForm.okButtonText == "Save to file" )
							{
								if ( tryDialogSave () )
									Close () ;
							}
							else 
							{
								webServer?.Stop ( true ) ;
								webServer?.Dispose () ;
								messageForm.Hide () ;
								Close () ;
								return ;	//!!!!!! da
							}
						break ;
						case MessageForm.ButtonKind.no :
							if ( messageForm.noButtonText == "Just close program" )
							{
								closeProgramConfirmed = true ;
								Close () ;
							}
							else stopServerAndReflectServerStatus () ;
						break ;
					}
				break ;
				default :
					switch ( buttonKind )
					{
						case MessageForm.ButtonKind.ok :
							//if ( webServer == null ) return ;
							//try
							//{
							//	webServer.Stop ( true ) ;
							//}
							//catch { }
							//notifyIcon.Text = "Http server is down" ;
							//Icon =
							//notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
							////resourceTypeLabel.Text = "Closed" ;
							//if ( closeProgramDemand ) 
							//{
							//	closeProgramConfirmed = true ;
							//	Close () ;
							//}
							//else if ( serverMode == StartServerMode.jsonConfig )
							//	BringToFront () ;
						break ;
						case MessageForm.ButtonKind.no :
							( ( Form ) sender ).Dispose () ;
						break ;
					}
				break ;
			}
			messageForm?.Dispose () ; //?
		}

		private void messageForm_Closed ( object sender , FormClosedEventArgs e )
		{
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
			if ( sender as MessageForm == messageForm ) messageForm = null ;
		}
		protected void showErrorMessage ( string title , string messageText )
		{
			showMessage ( SimpleHttp.Properties.Resources.closeIcon , title , messageText , "" , "" , "Continue" ) ;
		}
		public void showError ( string title , JsonException jsonException )
		{
			ShowInTaskbar = true ;
			Visible = true ;
			showErrorMessage ( title , HttpStartParameters.GetFixedTextFromJsonException ( jsonException ) ) ;
		}
		public void showError ( string title , Exception exp )
		{
			string message = exp == null ? "Unknown error" : exp.InnerException == null ? exp.Message : exp.InnerException.Message ;
			showErrorMessage ( title , message ) ;
		}
		public void InvokeShowErrorMessage ( string title , Exception exp  )
		{
			BeginInvoke ( () =>
				{
					showError ( title , exp ) ;
				} ) ;
		}

		protected void showClosingQuestion ()
		{
			showMessage ( SimpleHttp.Properties.Resources.closeIcon ,
							"Closing program" , "              Do you want to close http server?" ,
							"Close program and server" , "Just stop server" , "Keep server working" ) ;
		}
		protected void showNotSavedClosingQuestion ()
		{
			showMessage ( SimpleHttp.Properties.Resources.closeIcon ,
							"Closing program" , "Current configuration JSON not saved,\r\nDo you want to save it now?" ,
							"Save to file" , "Just close program" , "Cancel" ) ;
		}
		protected override void OnFormClosing ( FormClosingEventArgs e )
		{
			if ( closeProgramConfirmed || !( isListening  || ( configFileNameLabel.Text == "<not saved>" ) ) )
			{
				quickStartForm?.Dispose () ;
				resourcesForm?.Dispose () ;
				aboutForm?.Dispose () ;
				messageForm?.Dispose () ;
			}
			else 
			{
				e.Cancel = true ;
				if ( isListening ) 
					showClosingQuestion () ;
				else showNotSavedClosingQuestion () ;
				//if ( closeProgramDemand || ( messageForm != null )  && ( e.CloseReason == CloseReason.UserClosing ) )
				//	showClosingQuestion () ;
				//else
				//{
				//	ShowInTaskbar = false ;
				//	Hide () ;
				//	resourcesForm?.Hide () ;
				//	aboutForm?.Hide () ;
				//}
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
			if ( disposing && ( components != null ) ) components.Dispose() ;
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
		private void menuButton_MouseUp ( object sender , MouseEventArgs e )
		{
			unsafe
			{
				iconMenuClosingTimeStamp = Environment.TickCount64 - 2001 ;
			}
			Button_MouseUp ( sender , e ) ;
		}
		private void menuButton_Click ( object sender , EventArgs e )
		{
			unsafe
			{
				if ( Environment.TickCount64 - iconMenuClosingTimeStamp < 2000 )
					return ;
			}
			
			BeginInvoke ( ()=>
			{
				API.APIPoint po = new API.APIPoint () ;
				API.GetCursorPos ( ref po ) ;
				iconMenu.Show ( po.x - 10 , po.y + 10 ) ;
			} ) ;
		}
		
		private void iconMenu_Closing ( object sender , ToolStripDropDownClosingEventArgs e )
		{
			iconMenuClosingTimeStamp = Environment.TickCount64 ;
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
				if ( WindowState == FormWindowState.Minimized )  WindowState = restoredWindowState ;
				Activate () ;
				API.BringWindowToTop ( Handle ) ;
				calculateLogItemHeight () ;
				if ( continueWidth == null ) 
					midPanel.Enabled = true ;
				else continueWidth.DynamicInvoke ( args ) ;
				Opacity = 1.0 ;
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
				showCurrentParametersMenuItem.Visible = currentStartParameters != null ;
			}
			else 
			{
				showQuickStartMenuItem.Visible = true ;
				startJSONConfigMenuItem.Visible = true ;
				toolStripSeparator1.Visible = true ;
				stopServerMenuItem.Visible = false ;
				showCurrentParametersMenuItem.Visible = quickStartForm == null ? false : quickStartForm.Visible ;
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

		private void aboutMenuItem_Click ( object sender , EventArgs e )
		{
			restoreForm ( showAboutForm ) ;
		}
		private void showQuickStartMenuItem_Click ( object sender , EventArgs e )
		{
			restoreForm ( new ThreadStart ( showQuickStartForm ) ) ;
		}
		private void startJSONConfigMenuItem_Click ( object sender , EventArgs e )
		{
			restoreForm ( startJSONConfigMenuItemClick ) ;
		}
		private void showMainWindowMenuItem_Click ( object sender , EventArgs e )
		{
			restoreForm () ;
		}
		private void showCurrentParametersMenuItem_Click ( object sender , EventArgs e )
		{
			HttpStartParameters parameters = quickStartForm == null ? currentStartParameters : quickStartForm.Visible ? quickStartForm.getStartParameters () : currentStartParameters  ;
			if ( parameters != null )
				restoreForm ( showStartParameters  , new object [ 1 ] { parameters } ) ;
		}
		private void stopServerMenuItem_Click ( object sender, EventArgs e )
		{
			if ( isListening )
				restoreForm ( () =>
				{
					closeProgramConfirmed = false ;
					showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
											"Stoping server" , "Do you want to stop http server?" ,
											"Stop server" , "" , "Keep server working" ) ;

				} ) ;
			else Close () ;
		}
		private void closeProgramMenuItem_Click ( object sender , EventArgs e )
		{
			restoreForm ( () =>
				{
					closeProgramConfirmed = false ;
					Close () ;
				} ) ;
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
	
       
		/// <summary>
		/// We need this to make borderless form sizeable.
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		protected virtual bool ProccessNCHitTest ( ref Message m )
        {
            //if ( ProccessNCLButtonDown ( ref m ) ) return true ;
            Point po = API.PointFromParam ( m ) ;
            int w2 = ( Width - ClientSize.Width ) / 2 ;
			bool done = false ;
			if ( po.X < 6 )
				if ( po.Y < 6 )
				{
					done = true ;
					m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.TopLeft ) ;
				}
				else if ( po.Y >= Height - 8 )
				{
					done = true ;
					m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.BottomLeft ) ;
				}

			if ( !done )
				if ( po.X < 4 )
				{
					done = true ;
					m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.Left) ;
				}
				else 
				{
					if ( po.X >= Width - 8 )
						if ( po.Y < 6 )
						{
							done = true ;
							m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.TopRight ) ;
						}
						else if ( po.Y >= Height - 8 )
						{
							done = true ;
							m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.BottomRight ) ;
						}
					if ( !done )
						if ( po.X >= Width - 5 )
						{
							done = true ;
							m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.Right ) ;
						}
						else 
						{
							if ( po.Y < 4 )
							{
								done = true ;
								m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.Top ) ;
							}
							else if ( po.Y >= Height - 5 )
							{
								done = true ;
								m.Result = new IntPtr ( ( int ) API.NCHitTestEnum.Bottom ) ;
							}
						}
				}
			if ( !done )
				if ( po.Y < titlePanel.Top )
					m.Result = new IntPtr ( ( int )  API.NCHitTestEnum.Caption ) ;
				else m.Result = new IntPtr ( ( int )  API.NCHitTestEnum.Client ) ;

			return true ;
        }
		[System.Diagnostics.DebuggerStepThrough]
		protected override void WndProc ( ref Message m )
		{
			try
			{
				switch ( m.Msg ) 
				{
					case WindowMessage.WM_CopyData :
						API.CopyDataStructure cds = new API.CopyDataStructure() ;
						cds = ( API.CopyDataStructure ) Marshal.PtrToStructure ( m.LParam , typeof ( API.CopyDataStructure ) ) ;
						if ( cds.cbData > 0 )
						{
							string strData = Marshal.PtrToStringUni ( cds.lpData ).ToLower ().Trim () ;
							BeginInvoke ( processCopyDataMessage , strData ) ;
						}
					break ;
					case WindowMessage.WM_NCHitTest :
						ProccessNCHitTest ( ref m ) ;
					return ;
					case WindowMessage.WM_LButtonDown :
						if ( !DesignMode ) API.SendMessageA ( TopLevelControl.Handle , WindowMessage.WM_NCLButtonDown , new IntPtr ( 2 ) , m.LParam ) ; 
					return ;
				}
			}
			catch {}
            base.WndProc ( ref m ) ;
		}
		
		private void processCopyDataMessage ( string message )
		{
			if ( message == null ) return ;
			if ( message.Trim().ToLower () == "show" )
				restoreForm () ;
		}
		public void showStartingCommandLine (  )
		{
			showInfo ( "Starting command line" , currentProcess.MainModule.FileName + " " + programStartParameters.commandLine ) ;
		}

		public void showStartParameters ( HttpStartParameters parameters )
		{
			showInfo ( "Command line parameters" , currentProcess.MainModule.FileName + " " + parameters.ToString () ) ;
		}
		public void showWarning ( string title , string caption )
		{
			showMessage ( SimpleHttp.Properties.Resources.warningIcon , title , caption , "" , "" , "Continue" ) ;
		}
		public void showInfo ( string title , string caption )
		{
			showMessage ( SimpleHttp.Properties.Resources.textIcon , title , caption , "" , "" , "Continue" ) ;
		}
		public void showMessage ( Image image , string title , string caption )
		{
			showMessage ( image , title , caption , "" , "" , "Continue" ) ;
		}
		public void showMessage ( Image image , string title , string caption , string cancelButtonText )
		{
			showMessage ( image , title , caption , "" , "" , cancelButtonText ) ;
		}
		public void showMessage ( Image image , string title , string caption , string okButtonText , string noButtonText , string cancelButtonText )
		{
			if ( WindowState == FormWindowState.Minimized ) 
				restoreForm (  new Action<Image,string,string,string,string,string>(showMessage) , new object [ 6 ] { image , title , caption , okButtonText , noButtonText , cancelButtonText } ) ;
			else 
			{
				//just incase
				ShowInTaskbar = true ;
				Visible = true ;

				if ( messageForm == null )
				{
					messageForm = MessageForm.Show ( this , image , title , caption , 
										okButtonText , noButtonText , cancelButtonText ,
										messageForm_buttonClick , messageForm_Closed , messageForm_Disposed ) ;
					messageForm.Font = Font ;
				}
				else
				{
					messageForm.setAll ( image , title , caption , okButtonText , noButtonText , cancelButtonText ) ;
					messageForm.Show () ;
					messageForm.BringToFront () ;
				}
			}
		}


		private void searchBox_TextChanged ( object sender , EventArgs e )
		{
			searchLength = 0 ;
		}
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
			configFileNameLabel.Font = boldUnderlineFont ;
		}

		private void configFileNameLabel_MouseLeave ( object sender , EventArgs e )
		{
			configFileNameLabel.Font = boldFont ;
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
		private void gridContextMenu_Opening ( DataGridView grid , CancelEventArgs e )
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
			if ( e.Button == MouseButtons.Left )
				folderOpenMenuItem_Click ( folderOpenMenuItem , e ) ;
			else linkContextMenu.Tag = resourceLabel ;
		}
		protected void openWebrootFolder ()
		{
			Exception error ;
			if ( resourceLabel.Text == "<not saved>" )
				jsonEditorVisible = !jsonEditorVisible ;
			else if ( !openFolder ( resourceLabel.Text , out error ) )
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
		public static bool openFolder ( string folder , out Exception error )
		{
			error = null ;
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo ( "\"" + folder + "\"" ) ; //not "explorer" !
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


		private void linkOpenMenuItem_Click ( object sender , EventArgs e )
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
		private void folderOpenMenuItem_Click ( object sender , EventArgs e )
		{
			switch ( serverMode )
			{
				case StartServerMode.fileServer :
					openWebrootFolder () ;
				break ;
				case StartServerMode.resourceServer :
					showResourceForm ( FindAssemblyBySource ( resourceLabel.Text ) ) ;
				break ;
			}
		}
		private void linkCopyMenuItem_Click ( object sender , EventArgs e )
		{
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
			saveConfigFileMenuItem.Enabled = configFileNameLabel.Text != "<empty>" ;
			copyConfigNameMenuItem.Enabled = !string.IsNullOrWhiteSpace ( jsonConfigFileName ) ;
		}
		private void browseJsonFile ( bool ignoreUnsavedChanges )
		{
			if ( !ignoreUnsavedChanges && ( configFileNameLabel.Text == "<not saved>" ) )
					showMessage ( SimpleHttp.Properties.Resources.warningIcon , 
						"Load new json config file" , 
						"Current json configuration is changed but not saved.\r\nDo you want to save it now?" , "Save now" , "Abandon changes" , "Cancel" ) ;
				else 
				{
					try
					{
						openFileDialog.InitialDirectory = Path.GetDirectoryName ( jsonConfigFileName ) ;
						openFileDialog.FileName = Path.GetFileName ( jsonConfigFileName ) ;
					}
					catch { }
					try
					{
						openFileDialog.InitialDirectory = openFileDialog.FileName.Substring ( 0 , openFileDialog.FileName.LastIndexOf ( '\\' ) ) ;
					}
					catch { }
					messageForm?.Hide () ;
					if ( openFileDialog.ShowDialog ( this ) == DialogResult.OK )
						if ( tryLoadConfigAs ( openFileDialog.FileName ) )
							quickStartForm?.Hide () ;
				}
		}
		private void configContextMenu_ItemClicked ( object sender, ToolStripItemClickedEventArgs e )
		{
			configContextMenu.Close () ;
			if ( e.ClickedItem == browseConfigFileMenuItem )
			{
				browseJsonFile ( false ) ;
			}
			else if ( e.ClickedItem == saveConfigFileMenuItem )
				saveConfigFileMenuItem_Click ( saveConfigFileMenuItem , e ) ;
			else if ( e.ClickedItem == copyConfigNameMenuItem )
				if ( !string.IsNullOrWhiteSpace ( jsonConfigFileName ) )
					Clipboard.SetText ( jsonConfigFileName ) ;
		}
		public void saveConfigFileMenuItem_Click ( object sender , EventArgs e )
		{
			messageForm?.Hide () ;
			tryDialogSave () ;
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
				_jsonConfigFileName = new FileInfo ( fileName ).FullName ;
				
				configFileNameLabel.Text = Path.GetFileName ( _jsonConfigFileName ) ;

			}
			catch ( Exception x )
			{
				showError ( "File read error" , x ) ;
				goto endLab ;
			}
			
				
			try
			{
				if ( !isListening )
				{
					WebServerConfigData configData = getConfigDataFromJSON ( true ) ;
					if ( configData == null ) goto endLab ;
					reflectServerStatus ( configData , false ) ;
					if ( serverMode != StartServerMode.jsonConfig )
						showQuickStartForm ( configData ) ;
				}
				ret = true ;
			}
			catch ( Exception x )
			{
				showError ( "Invalida JSON data" , x ) ;
				goto endLab ;
			}
endLab:
			try
			{ 
				fileStream?.Dispose () ;
				reader?.Dispose () ;
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
				fileStream = File.Create ( fileName ) ;
				fileStream.Write ( Encoding.UTF8.GetBytes ( jsonEditor.Text ) ) ;
				_jsonConfigFileName = new FileInfo ( fileName ).FullName ;
				configFileNameLabel.Text = Path.GetFileName ( _jsonConfigFileName ) ;
				
				ret = true ;
			}
			catch ( Exception x )
			{
				showError ( "File not saved" , x ) ;
			}
			try
			{ 
				fileStream?.Dispose () ;
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
				folderOpenMenuItem.Visible = ( linkContextMenu.Tag == resourceLabel ) && ( serverMode == StartServerMode.fileServer ) ;
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
		private void configPanel_Resize ( object sender, EventArgs e )
		{
			setTitleLabelPosition () ;
		}
		private void searchPanel_Resize ( object sender, EventArgs e )
		{
			setSearchBoxMaximumSize () ;
			searchBox.Width = _searchBoxWidth ;
			setTitleLabelPosition () ;
		}
		private void setSearchBoxMaximumSize ()
		{
			searchBox.MaximumSize = new Size ( Math.Min ( _searchBoxWidth , searchPanel.Width - searchSplitter.Width - searchBox.Left ) , 0 ) ;
		}
		
		private void searchBox_Resize ( object sender, EventArgs e )
		{
			//topPanel.SuspendLayout () ;startStopSwitch
			searchBox.MaximumSize = new Size ( searchBox.Height << 4 , 0 ) ;
			statusPanel.SuspendLayout() ;
			int w = searchBox.Height << 1 ;
			searchBox.MinimumSize = new Size ( w , 0 ) ;
			setSearchBoxMaximumSize () ;


			
			searchSplitter.Bounds = new Rectangle ( searchPanel.Padding.Left + searchLabel.Width + searchBox.Width , searchPanel.Padding.Top , 5 , searchBox.Height ) ;//@#@$@!!
			//searchSplitter.Height = searchBox.Height ;

			minimizeButton.Size =
			maximizeButton.Size =
			closeButton.Size =
			searchButton.Size = 
			startStopSwitch.Size =
			monitorSwitch.Size =
			viewSwitch.Size =
			menuButton.Size = new Size ( searchBox.Height , searchBox.Height ) ;


			resourcePanel.MinimumSize = new Size ( 0 , searchBox.Height ) ;
			titlePanel.Height = startStopSwitch.Bottom + buttonPanel.Padding.Bottom ;

			
			configPanel.MaximumSize = new Size ( configPanel.Padding.Horizontal + searchLabel.Width + ( searchBox.Height << 2 ) , Math.Max ( configLabel.Height + 1 + configPanel.Padding.Vertical , statusPanel.Height ) ) ;
			errorLabel.Margin = new Padding ( 0 , 0 , Math.Max ( 0 , closePropertiesButton.Width - 2 ) , 0 ) ;
			closePropertiesButton.Size = new Size ( searchBox.Height , searchBox.Height ) ;

			//int h = searchBox.Height - resourceLabel.Height + resourceLabel.Padding.Vertical ;
			//if ( h < 0 ) h = 0 ;
			//int h2 = h >> 1 ;
			//h = ( h + 1 ) >> 1 ;
			//searchLabel.Padding = new Padding ( searchLabel.Padding.Left , h , searchLabel.Padding.Right , h2 ) ;
			//uriLabel.Padding = new Padding ( uriLabel.Padding.Left , h , uriLabel.Padding.Right , h2 ) ;
			//resourceTypeLabel.Padding = new Padding ( resourceTypeLabel.Padding.Left , h , resourceTypeLabel.Padding.Right , h2 ) ;
			//resourceLabel.Padding = new Padding ( resourceLabel.Padding.Left , h , resourceLabel.Padding.Right , h2 ) ;
			
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
			setTitleLabelPosition () ;
			//topPanel.ResumeLayout () ;
			
		}
		protected void Box_Resize ( object sender , EventArgs e )
		{
			SetBoxRegion ( ( Control ) sender ) ;
		}
		/// <summary>
		/// Auxiliary variable for the searchBoxVisible 
		/// </summary>
		protected bool _searchBoxVisible ;
		/// <summary>
		/// Set method for searchBoxVisible property
		/// </summary>
		/// <param name="value">New value for searchBoxVisible property</param>
		protected void setSearchBoxVisible ( bool value )
		{
			setSearchBoxVisible ( value , false ) ;
		}
		/// <summary>
		/// Set method for searchBoxVisible property
		/// </summary>
		/// <param name="value">New value for searchBoxVisible property</param>
		protected void setSearchBoxVisible ( bool value , bool doNotSaveToRegistry )
		{
		//	if ( value == searchPanel.Visible ) return ;
			//searchBoxCanBeVisible && 
			_searchBoxVisible = value ;
			searchButton.Visible = !value ;
			searchPanel.Visible = value ;
			

			if ( !doNotSaveToRegistry ) saveSearchBoxVisible ( ) ;

			searchBox_Resize ( searchBox , new EventArgs () ) ;
			setSearchBoxWidth ( _searchBoxWidth , false ) ;
		}
		/// <summary>
		/// 
		/// </summary>
		protected void saveSearchBoxVisible ( )
		{
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				key.SetValue ( "SearchBoxVisible" , searchPanel.Visible ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }

			try
			{
				key?.Dispose () ;
			}
			catch { }

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
		public void setSearchBoxWidth ( int value )
		{
			setSearchBoxWidth ( value , false ) ;
		}
		public void setSearchBoxWidth ( int value , bool doNotSaveToRegistry )
		{
			_searchBoxWidth = value ;
			//if ( searchPanel.Width == 0 ) return ; //fuck you Microsoft
			setSearchBoxMaximumSize () ;

			
			if ( doNotSaveToRegistry ) return ;

			saveSearchBoxWidth () ;
			setTitleLabelPosition () ;
		}
		/// <summary>
		/// searchBox width
		/// </summary>
		protected int _searchBoxWidth ;

		/// <summary>
		/// searchBox width
		/// </summary>
		public int searchBoxWidth 
		{
			get => _searchBoxWidth ;
			set => setSearchBoxWidth ( value ) ;
		}
		protected void loadSearchBoxWidth ()
		{
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				setSearchBoxWidth ( ( int ) key.GetValue ( "SearchBoxWidth" ) , true ) ;
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
		protected void loadSearchBoxVisibility ()
		{
			RegistryKey key = null ;
			bool SearchBoxVisibleValue = false ;
			// this will fail on the first start since registry is empty
			try
			{
				key = Application.UserAppDataRegistry ;
				//fuck (bool) 1 cannot do that!!
				SearchBoxVisibleValue = ( ( int ) key.GetValue ( "SearchBoxVisible" ) == 0 ) ? false : true ;
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
			setSearchBoxVisible ( SearchBoxVisibleValue ) ;
		}
		protected void saveSearchBoxWidth ()
		{
			RegistryKey key = null ;
			try
			{
				key = Application.UserAppDataRegistry ;
				key.SetValue ( "SearchBoxWidth" , _searchBoxWidth , RegistryValueKind.DWord ) ;
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

		private void searchSplitter_Paint ( object sender , PaintEventArgs e )
		{
			drawVericalSplit ( e.Graphics , searchSplitter.Size ) ;
		}
		public static void drawVericalSplit ( Graphics graphics , Size size )
		{
			int w = ( ( size.Width + 1 ) >> 1 ) - 1 ;
			graphics.DrawLine ( SystemPens.ControlDarkDark , w , 0 , w , size.Height ) ;
			w-- ;
			graphics.DrawLine ( SystemPens.ControlLightLight, w , 0 , w , size.Height ) ;
			//graphics.DrawLine ( Pens.Yellow , w , 0 , w , size.Height ) ;
			//graphics.DrawLine ( Pens.Orange , w , 0 , w , size.Height ) ;
		}
		private void splitter_MouseEnter ( object sender , EventArgs e )
		{
			Control splitter = ( Control  ) sender ;
			//splitter.BorderStyle = BorderStyle.FixedSingle ;
			splitter.BackColor = SystemColors.ControlLightLight ;
		}

		private void splitter_MouseLeave ( object sender , EventArgs e )
		{
			Control splitter = ( Control  ) sender ;
			splitter.BackColor = SystemColors.ControlLight ;
		}
		protected Bitmap titlePanelBitmap ;
		
		/// <summary>
		/// And we still need paint @#@#@!!!!
		/// </summary>
		/// <param name="sender">topPanel</param>
		/// <param name="e">(PaintEventArgs)</param>
		private void titlePanel_Paint ( object sender , PaintEventArgs e )
		{
			if ( titlePanelBitmap == null ) return ;
			//if ( sender != null ) System.Diagnostics.Debug.WriteLine ( "topPanel_Paint real" ) ;
			Bitmap newBitmap = new Bitmap ( titlePanelBitmap , titlePanel.Size ) ;
			Graphics graphics = Graphics.FromImage ( newBitmap ) ;
			graphics.DrawImageUnscaled ( titlePanelBitmap , Point.Empty ) ;
			graphics.DrawRectangle ( Pens.Gray , new Rectangle ( searchBox.Left + searchPanel.Left , searchBox.Top + searchPanel.Top , newSearchBoxWidth , searchBox.Height - 1 ) ) ; //yes -1
			graphics.Dispose () ;
			e.Graphics.DrawImageUnscaled ( newBitmap , Point.Empty ) ; 
		}

		/// <summary>
		/// Splitter control is confused inside of control with auto layout.<br/>
		/// In addition we must expand parent control(s) width before dragging occur.
		/// </summary>
		/// <param name="sender">searchSplitter</param>
		/// <param name="e">(MouseEventArgs)</param>
		private void searchSplitter_MouseDown ( object sender , MouseEventArgs e )
		{
			bool titleLabelVisible = titleLabel.Visible ;
			Bitmap bitmap = titlePanelBitmap = new Bitmap ( titlePanel.Width , titlePanel.Height ) ;
			titlePanel.DrawToBitmap ( bitmap , new Rectangle ( Point.Empty , titlePanel.Size ) ) ;
			if ( titleLabel.Visible )
				titleLabel.DrawToBitmap ( bitmap , titleLabel.Bounds ) ;
			searchBox.Focus () ; //very important
			searchBoxMouseDownX = e.Location.X ;
			foreach ( Control control in titlePanel.Controls )
				control.Visible = false ;
	
			titlePanel.Paint += titlePanel_Paint ;		//asdasda@#@#@#@Q#@~!!!!!!

		}

		private void searchSplitter_MouseMove ( object sender , MouseEventArgs e )
		{
			if ( titlePanelBitmap == null ) return ;
			newSearchBoxWidth = searchBox.Width + e.Location.X - searchBoxMouseDownX ;
			if ( newSearchBoxWidth < searchBox.MinimumSize.Width ) 
			{
				newSearchBoxWidth = searchBox.MinimumSize.Width ;
				searchSplitter.Cursor = Cursors.PanWest ;
			}
			else if ( newSearchBoxWidth > 1000 ) 
			{
				searchSplitter.Cursor = Cursors.Default ;
				newSearchBoxWidth = searchBox.MaximumSize.Width ;
			}
			else searchSplitter.Cursor = Cursors.VSplit ;

			//topPanel.Invalidate () ;  fuuuuck this
			Graphics graphics = titlePanel.CreateGraphics () ;
			titlePanel_Paint ( titlePanel , new PaintEventArgs ( graphics , new Rectangle ( Point.Empty , titlePanel.Size ) ) ) ;
			graphics.Dispose () ;
		}
		private void searchSplitter_KeyDown ( object sender , KeyEventArgs e )
		{
			if ( ( e.KeyCode == Keys.Escape ) && ( titlePanelBitmap != null ) )
			{
				titlePanelBitmap.Dispose () ;
				titlePanelBitmap = null ;
				reverTitlePanelControls () ;
			}
		}
		private void searchSplitter_MouseUp ( object sender , MouseEventArgs e )
		{
			if ( titlePanelBitmap == null ) return ;
			API.SendMessageA ( titlePanel.Handle , WindowMessage.WM_SetRedraw , IntPtr.Zero , IntPtr.Zero ) ;
			reverTitlePanelControls () ;			
			if ( newSearchBoxWidth > searchBox.MinimumSize.Width )
			{
				searchBoxWidth = newSearchBoxWidth ;
				searchBox.Focus () ;
			}
			else 
			{
				searchBoxVisible = false ;	
				if ( jsonEditorVisible )
					jsonEditor.Focus () ;
				else logList.Focus  () ;
			}
			searchSplitter.Cursor = Cursors.VSplit ;
			API.SendMessageA ( titlePanel.Handle , WindowMessage.WM_SetRedraw , new IntPtr ( 1 ) , IntPtr.Zero ) ;
			//BeginInvoke ( titlePanel.Invalidate ) ;
			titlePanel.Invalidate ( true ) ;		
			//statusPanel.Invalidate () ;		
			//searchPanel.Invalidate () ;
		}

		/// <summary>
		/// Anything that can be clicked MUST recall focus to some text box(Im old)
		/// </summary>
		/// <param name="sender">Any button/control</param>
		/// <param name="e">(MouseEventArgs)</param>
		private void Button_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{
				if ( jsonEditorVisible )
					jsonEditor.Focus () ;
				else logList.Focus  () ;
			}
			catch { }
		}
		protected void reverTitlePanelControls ()
		{
			//Bitmap bitmap = topPanel.BackgroundImage as Bitmap ;
			titlePanel.SuspendLayout () ;
			foreach ( Control control in titlePanel.Controls )
				control.Visible = true ;
			setSearchBoxVisible ( _searchBoxVisible , false ) ;

			titlePanelBitmap?.Dispose () ;
			titlePanelBitmap = null ;
			jsonEditor.TabStop = true ;
			try
			{
				titlePanel.Paint -= titlePanel_Paint ;
			}
			catch { }			
			titlePanel.ResumeLayout () ;
		}
		protected void setTitleLabelVisibility ()
		{
			titleLabel.Visible = titleLabel.Right < configPanel.Left ;
		}
		protected void setTitleLabelPosition()
		{
			titleLabel.Location = new Point ( searchPanel.Visible ? searchPanel.Left + searchBox.Right + searchSplitter.Width : buttonPanel.Right , searchPanel.Top + searchBox.Bottom - titleLabel.Height ) ;
			setTitleLabelVisibility () ;
		}
		protected void topPanel_MouseDown ( object sender , MouseEventArgs e )
		{
			if ( !statusPanel.Visible ) reverTitlePanelControls () ; //just in case
		}
		private void title_DoubleClick ( object sender , EventArgs e )
		{
			WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized ;
		}
		private void searchButton_Click ( object sender , EventArgs e )
		{
			searchBoxVisible = true ;
			try
			{
				searchBox.Focus () ;
			}
			catch{ }
		}
		private void searchBox_LostFocus ( object sender , EventArgs e )
		{
			reverTitlePanelControls () ;
		}


		private void requestPanel_Layout ( object sender , LayoutEventArgs e )
		{
			setClosePropertiesButtonLocation () ;
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
		private void jsonEditor_Paint ( object sender , PaintEventArgs e )
		{
			if ( Opacity == 0f ) return ;
			jsonEditor.Paint -= jsonEditor_Paint ;
			setJsonEditorTabs () ; //fuck
		}
		private void jsonEditor_Enter ( object sender , EventArgs e )
		{
		}
		private void jsonEditor_TextChanged ( object sender , EventArgs e )
		{
			configFileNameLabel.Text = "<not saved>" ;
		}

		private void viewSwitch_Click ( object sender , EventArgs e )
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
				showMessage ( SimpleHttp.Properties.Resources.warningIcon ,
										"Stoping server" , "Do you want to stop http server?" ,
										"Stop server" , "" , "Keep server working" ) ;

			} 
			else 
			if ( quickStartForm == null )
				startJSONConfigMenuItemClick() ;
			else if ( quickStartForm.Visible )
				startMenu.Show ( startStopSwitch , new Point ( -20 , -10 ) ) ;
			else startJSONConfigMenuItemClick() ;
		}

		private void startFromJSONMenuItem_Click ( object sender , EventArgs e )
		{
			startServerFromCurrentJSON () ;
		}
		private void startFromQuickStartMenuItem_Click ( object sender , EventArgs e )
		{
			if ( quickStartForm == null ) return ;
			startFromQuickStartForm ( quickStartForm.getStartParameters () , false ) ;
			if ( messageForm == null ? false : messageForm.Visible )
			{
				messageForm.Select () ;
				messageForm.BringToFront () ;
			}
			else if ( quickStartForm == null ? false : quickStartForm.Visible )
			{
				quickStartForm.BringToFront () ;
				quickStartForm.Select () ;
			}
		}

		private void startMenu_Opening ( object sender , CancelEventArgs e )
		{
			startFromQuickStartMenuItem.Enabled = quickStartForm == null ? false : quickStartForm.Visible ;
		}
		private void minimizeButton_Click ( object sender, EventArgs e )
		{
			// we have to retrive focus in Button_Mouse ()
			// so we want this to happen afterward
			BeginInvoke ( ()=>
			{
				WindowState = FormWindowState.Minimized ;
			} ) ;

		}
		private void maximizeButton_Click ( object sender, EventArgs e )
		{
			WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized ;
		}
		private void closeButton_Click ( object sender, EventArgs e )
		{
			closeProgramConfirmed = false ;
			if ( isListening )
				showClosingQuestion () ;
			else Close () ;
		}
		private void viewSwitch_MouseEnter ( object sender , EventArgs e )
		{
			if ( jsonEditorVisible ) viewSwitch.BackgroundImage = SimpleHttp.Properties.Resources.monitorHoverIcon ;
		}

		private void viewSwitch_MouseLeave ( object sender , EventArgs e )
		{
			if ( jsonEditorVisible ) viewSwitch.BackgroundImage = SimpleHttp.Properties.Resources.monitorIcon ;
		}
		private void toolTip_Draw ( object sender , DrawToolTipEventArgs e )
		{
			e.DrawBackground() ;
			e.DrawBorder () ;
			//e.Graphics.FillPie ( Brushes.Blue , new Rectangle ( 10 , 10 , 30 , 30 ) , 0f , 1.6f ) ;
			e.Graphics.DrawString ( e.ToolTipText , Font , toolTipForeBrush , new Point ( toolTipPadding << 1 , toolTipPadding ) ) ;

			//IntPtr toolTiphandle = API.WindowFromDC  ( e.Graphics.GetHdc () ) ;
			//e.Graphics.ReleaseHdc () ;

			//API.APIRect rect = new API.APIRect () ;
			//API.GetWindowRect ( toolTiphandle , ref rect ) ;
		}

		private void toolTip_Popup ( object sender , PopupEventArgs e )
		{
			Graphics graphics = CreateGraphics () ;
			Size size = graphics.MeasureString ( toolTip.GetToolTip ( e.AssociatedControl ) , Font ).ToSize () ;
			toolTipPadding = size.Height >> 1 ;
			e.ToolTipSize = new Size ( size.Width + size.Height , size.Height + toolTipPadding ) ;
			toolTipPadding = toolTipPadding >> 1 ;
			graphics.Dispose () ;
		}
	}
}