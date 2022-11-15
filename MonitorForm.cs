using System.Reflection;
using System.Runtime.InteropServices ;
using System.IO.Pipes ;
using System.Text ;
using System.Security.AccessControl ;
using System.Security.Cryptography.X509Certificates ;
using System.Net ;
using WebSockets ;
using System.Security.Cryptography ;
using System.Security.Authentication ;
namespace SimpleHttp
{
	public partial class MonitorForm : Form
	{
		MessageForm messageForm ;
		StartServerForm startServerForm ;
		PipeSecurity pipeSecurity ;
		protected bool closeProgramDemand ;
		protected bool closeProgramConfirmed ;
		protected string webroot ;
		protected NamedPipeServerStream recivier ;
		protected StartServerMode mode ;
		protected Assembly resourceAssembly ;
		protected string startingMessage ;
		protected int port ;
		protected bool autoStarted ;
		protected bool autoStart ;
		protected WebServer webServer ;
		protected FormWindowState previousWindowState ;
		protected FormWindowState restoredWindowState ;
		protected SolidBrush logBackBrush0 ;
		protected SolidBrush logBackBrush1 ;
		protected SolidBrush logInkBrush ;
		protected SolidBrush logSelectedBackBrush ;
		protected SolidBrush logSelectedInkBrush ;
		public static Color mixColor ( Color c1 , Color c2 )
		{
			return Color.FromArgb ( ( ( int ) c1.A + ( int ) c2.A ) >> 1 , ( ( int ) c1.R + ( int ) c2.R ) >> 1 , ( ( int ) c1.G + ( int ) c2.G ) >> 1 , ( c1.B + c2.B ) >> 1 ) ;
		}
		public MonitorForm ( int port , bool autoStart , StartServerMode mode , string source , string message )
		{
			InitializeComponent() ;
			logInkBrush = new SolidBrush ( SystemColors.WindowText ) ;
			logBackBrush0 = new SolidBrush ( SystemColors.Window ) ;
			logBackBrush1 = new SolidBrush ( SystemColors.Control ) ;
			logSelectedBackBrush = new SolidBrush ( mixColor ( SystemColors.Highlight , SystemColors.ControlDarkDark ) ) ;
			logSelectedInkBrush = new SolidBrush ( SystemColors.HighlightText ) ;
			requestGrid.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control ;
			requestGrid.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText ;
			requestGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = logSelectedBackBrush.Color ;
			requestGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = logSelectedInkBrush.Color ;
			requestGrid.RowsDefaultCellStyle.SelectionBackColor = logSelectedBackBrush.Color ;
			requestGrid.RowsDefaultCellStyle.SelectionForeColor = logSelectedInkBrush.Color ;
			responseGrid.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control ;
			responseGrid.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText ;
			responseGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = logSelectedBackBrush.Color ;
			responseGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = logSelectedInkBrush.Color ;
			responseGrid.RowsDefaultCellStyle.SelectionBackColor = logSelectedBackBrush.Color ;
			responseGrid.RowsDefaultCellStyle.SelectionForeColor = logSelectedInkBrush.Color ;

			webServer = null ;
			resourceAssembly = null ;
			this.autoStart = autoStart ;
			if ( mode == StartServerMode.resourceServer )
			{
				foreach ( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies () )
					if ( assembly.GetName().Name == source ) 
					{
						resourceAssembly = assembly ;
						break ;
					}
				if ( ( resourceAssembly == null ) && string.IsNullOrEmpty ( message ) ) message = "Assembly not found: \"" + source + "\"" ;
			}
			else 
			{
				mode = StartServerMode.fileServer ; //!!!!
				webroot = string.IsNullOrEmpty ( source ) ? Program.ExecutableFolder () : source ;
			}
			this.port = port ;
			startingMessage = message ;
			this.mode = mode ;
			requestGrid.Rows.Add ( ) ;
			if ( string.IsNullOrEmpty ( startingMessage ) && autoStart )
			{
				ShowInTaskbar = false ;
			}
			this.HandleCreated += FirstTime_HandleCreated ;
		}

		private void FirstTime_HandleCreated ( object? sender , EventArgs e )
		{
			this.HandleCreated -= FirstTime_HandleCreated ;
			if ( string.IsNullOrEmpty ( startingMessage ) )
			{
				if ( autoStart )
				{
					if ( mode == StartServerMode.fileServer )
						autoStarted = startFileServer ( port , webroot , "utf-8" , null , SslProtocols.None ) ;
					else autoStarted = startResourceServer ( port , "utf-8" , resourceAssembly , null , SslProtocols.None ) ;
					if ( autoStarted ) Visible = false ;
				}
			}
			else 
			{
				Opacity = 1.0 ;
				BeginInvoke ( () =>
				{
					showServerStarterForm () ;
					if ( !string.IsNullOrWhiteSpace ( startingMessage ) )
						ShowMessage ( SimpleHttp.Properties.Resources.warningIcon , "Bad starting parameters" , 
							startingMessage , "" , "" , "Continue" ) ;
				} ) ;
			}			
		}

		public MonitorForm() : this ( 80 , false  , StartServerMode.resourceServer , "" , "" )
		{
		}
		protected override void OnShown ( EventArgs e )
		{
			restoredWindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : WindowState ;
			pipeSecurity = new PipeSecurity() ;
			pipeSecurity.AddAccessRule ( new PipeAccessRule ( "Everyone" , PipeAccessRights.FullControl, AccessControlType.Allow ) ) ;
			try
			{
				recivier = NamedPipeServerStreamAcl.Create ( "SimpleHttp" , PipeDirection.In , 1 , PipeTransmissionMode.Byte , PipeOptions.Asynchronous , 65536 , 65536 , pipeSecurity ) ;
			}
			catch 
			{
				BeginInvoke ( Close ) ;
				return ;
			}
			recivier.WaitForConnectionAsync ().ContinueWith ( onPipeConnected ) ;
			
			responseGrid.Height = requestGrid.ColumnHeadersHeight * 4 + 6 ;



			HideProperties () ;
			int h = statusLabel.Height - 2 ;
			stopButton.Size = new Size ( h , h ) ;
			stopButton.Location = new Point ( spliterLayout.Right - stopButton.Width - 1 , statusLabel.Top - 1 ) ;
			//stopButton.Location = new Point ( spliterLayout.Left , statusLabel.Top ) ;
			stopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right ;
			//statusLabel.Padding = new Padding ( stopButton.Width + 1 , statusLabel.Padding.Top , statusLabel.Padding.Right , statusLabel.Padding.Bottom ) ;
			if ( !isListening && string.IsNullOrEmpty ( startingMessage ) )
				if ( startServerForm == null ) showServerStarterForm () ;
			base.OnShown ( e ) ;
        }
		protected override void OnActivated(EventArgs e)
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
				BeginInvoke ( iconMenu_ItemClicked , new object [ 2 ] { iconMenu , new ToolStripItemClickedEventArgs ( showMonitorMenuItem ) } )  ;
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
		protected void showServerStarterForm ()
		{
			spliterLayout.Enabled = false ;
			if ( startServerForm == null )
			{
				startServerForm = new StartServerForm ( ) ;
				startServerForm.Owner = this ;
				startServerForm.Show () ;
				startServerForm.FormClosing += startServerForm_FormClosing ;	
				startServerForm.FormClosed += startServerForm_FormClosed ;
				startServerForm.resourceServerChoosen += startServerForm_resourceServerChoosen ;
				startServerForm.fileServerChoosen += startServerForm_fileServerChoosen ;
				startServerForm.invalidWebrootFolder += startServerForm_invalidWebrootFolder ;
				startServerForm.assemblyLoadError += startServerForm_assemblyLoadError ;
				startServerForm.certificateFailedOnClient += startServerForm_certificateFailedOnClient ;
				startServerForm.certificateFailedOnServer += startServerForm_certificateFailedOnServer ;
				startServerForm.invalidPortNumber += startServerForm_invalidPortNumber ;
				startServerForm.certificateLoadFailure += startServerForm_certificateLoadFailure ;
				startServerForm.certificateAccepted += startServerForm_certificateAccepted ;
				startServerForm.openTcpTestFailed += startServerForm_openTcpTestFailed ;
				//startServerForm.FormClosing += startServerForm_FormClosing ;
				startServerForm.Disposed += startServerForm_Disposed ;
			}
			else 
			{
				startServerForm.Visible = true ;
				startServerForm.BringToFront () ;
				startServerForm.Select () ;
			}
			startServerForm.mode = mode ;
			if ( mode == StartServerMode.fileServer )
				startServerForm.webroot = webroot ;
			else
			{
				if ( resourceAssembly != null )
				{
					if ( !startServerForm.setAssemblyListIndex ( resourceAssembly ) )
					{
						ShowMessage ( SimpleHttp.Properties.Resources.closeIcon ,
							"Invalid assembly" ,
							"Assembly \"" + resourceAssembly.GetName().Name + "\" not found" ,
							"" , "" , "Continue" ) ;
					}
				}
			}
		}
		private void startServerForm_FormClosing ( object? sender, FormClosingEventArgs e )
		{
			if ( e.CloseReason == CloseReason.UserClosing )
			{
				e.Cancel = true ;
				startServerForm.Hide () ;
			}
		}

		private void startServerForm_certificateAccepted ( object? sender , X509Certificate2 e )
		{
			ShowMessage ( SimpleHttp.Properties.Resources.greenCheck , "Certificate accepted" , 
					"Client server comunication commited, certificate accepted." , "" , "" , "    OK    " ) ;
		}

		private void startServerForm_invalidPortNumber ( object? sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Invalid port number" , e.GetException() ) ;
		}

		private void startServerForm_certificateLoadFailure ( object? sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Cannot load certificate" , e.GetException() ) ;
		}

		private void startServerForm_Disposed ( object? sender , EventArgs e )
		{
			if ( startServerForm == ( StartServerForm ) sender ) startServerForm = null ;
		}

		private void startServerForm_invalidWebrootFolder ( object? sender , string folder )
		{
			ShowMessage ( SimpleHttp.Properties.Resources.textIcon , "Invalid folder" , 
					folder.Trim () == "" ? 
					"No webroot folder specified" :				
					( "Folder not found:\r\n" + folder ) , " Close " , "" , "" ) ;
		}

		private void startServerForm_fileServerChoosen ( object? sender , EventArgs e )
		{
			spliterLayout.Enabled = true ;
			StartServerForm? startServerForm = ( StartServerForm? ) sender ;
			autoStarted = false ;
			startFileServer ( startServerForm.port , startServerForm.webroot , "utf-8" , startServerForm.certificate , startServerForm.sslProtocol ) ;
			startServerForm.Hide () ;
			restoreForm () ;
		}
		
		private void startServerForm_resourceServerChoosen ( object sender , EventArgs e )
		{
			autoStarted = false ;
			startResourceServer ( startServerForm.port , "utf-8" , startServerForm.selectedAssembly , startServerForm.certificate , startServerForm.sslProtocol ) ;
			startServerForm.Hide () ;
			restoreForm () ;
		}
		
		private void startServerForm_assemblyLoadError ( object sender , ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Error loading assembly" , e.GetException() ) ;
		}
		private void startServerForm_openTcpTestFailed ( object? sender, ErrorEventArgs e )
		{
			InvokeShowErrorMessage ( "Cannot make test tpc connection" , e.GetException() ) ;
		}
		private void startServerForm_certificateFailedOnServer ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( ()=>
			{
				if ( messageForm != null )
					if ( messageForm.Text == "Certificate failed on client side" )
					{
						ShowMessage ( SimpleHttp.Properties.Resources.warningIcon ,
							"Certificate failed" , 
							"Client side error:\r\n" + 
							messageForm.messageText  + "\r\nServer side error:\r\n" + e.GetException().Message ,
							"" , "" , " Close " ) ;
						return ;
					}
				ShowErrorMessage ( "Certificate failed on server side" , e.GetException() ) ;
			} ) ;
		}
		
		private void startServerForm_certificateFailedOnClient ( object sender , ErrorEventArgs e )
		{
			BeginInvoke ( ()=>
			{
				if ( messageForm != null )
					if ( messageForm.Text == "Certificate failed on server side" )
					{
						ShowMessage ( SimpleHttp.Properties.Resources.warningIcon ,
							"Certificate failed" , 
							"Client side error:\r\n" + 
							e.GetException().Message + "\r\nServer side error:\r\n" + messageForm.messageText ,
							"" , "" , " Close " ) ;
						return ;
					}
				ShowErrorMessage ( "Certificate failed on client side" , e.GetException() ) ;
			} ) ;
		}
		private bool startFileServer ( int port , string webroot , string charset , X509Certificate2 certificate , SslProtocols sslProtocol )
		{
			try
			{
				mode = StartServerMode.fileServer ;
				isCriticalError = false ;
				this.webroot = webroot ;
				if ( Directory.Exists ( webroot ) )
				{
					webServer = new WebServer ( new HttpServiceFactory ( webroot , null ) , 
												webServer_clientConnected , webServer_serverResponded ,
												webServer_sarted , webServer_stoped , 
												webServer_connectionErrorRaised , 
												webServer_criticalErrorRaised , webServer_disposed ) ;
					//X509Certificate2 cert = StartServerForm.GenerateSelfSignedCertificate () ; // new  X509Certificate2 ( "C:\\Code\\localhost.pfx" ) ;

					webServer.Listen ( port , certificate , sslProtocol ) ;
					//webServer.Listen ( port ) ;
					spliterLayout.Enabled = true ;
					return true ;
					//ServerStarter.start ( port , webroot , webServer_clientConnected , webServer_serverResponded ) ;
				}
				else throw new ApplicationException ( "Folder not found(or inaccessible):\r\n\"" + webroot + "\"" ) ;
			}
			catch ( Exception x )
			{ 
				InvokeShowErrorMessage ( "Error starting file based server" , x ) ;
			}
			return false ;
		}

		private bool startResourceServer ( int port , string charset , Assembly resourceAssembly , X509Certificate2 certificate , SslProtocols sslProtocol )
		{
			mode = StartServerMode.resourceServer ;
			this.resourceAssembly = resourceAssembly ;
			isCriticalError = false ;
			//ServerStarter.start ( port , resourceAssembly , webServer_clientConnected , webServer_serverResponded ) ;
			try
			{
				if ( resourceAssembly == null )
					throw new Exception ( "Null resource assembly" ) ;
				else 
				{
					webServer = new WebServer ( new HttpServiceFactory ( resourceAssembly , null ) , 
											webServer_clientConnected , webServer_serverResponded ,
											webServer_sarted , webServer_stoped , webServer_connectionErrorRaised , 
											webServer_criticalErrorRaised , webServer_disposed ) ;
					webServer.Listen ( port , certificate , sslProtocol ) ;
					spliterLayout.Enabled = true ;
					return true ;
				}
			}
			catch ( Exception x )
			{ 
				InvokeShowErrorMessage ( "Error starting resource based server" , x ) ;
			}
			return false ;
		}
		protected void webServer_sarted ( object sender , EventArgs e )
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
				BeginInvoke ( () =>
				{
					if ( IsDisposed ) return ;
					if ( webServer == null ) return ;
					if ( webServer == sender as WebServer ) 
					{
						if ( autoStarted ) Visible = false ;
						HttpServiceFactory httpServiceFactory  = ( HttpServiceFactory ) webServer.serviceFactory ;
						notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
						string t = ( webServer.isSecure ? StartServerForm.getProtocolName ( webServer.sslProtocol ) : "Flat http" ) + " on port " +  webServer.port.ToString () ;

						if ( httpServiceFactory.isResourceBased )
						{
							string a = httpServiceFactory.resourceAssembly.GetName().Name ;
							statusLabel.Text = t + ", assembly: " + a ;
							t = t + ", assembly:\r\n" + a ;
							notifyIcon.Text = t.Substring ( 0 , Math.Min ( 127 , t.Length ) ) ;
						}
						else 
						{
							statusLabel.Text = t + ", webroot: " + httpServiceFactory.webroot ;
							t = t + ", webroot:\r\n" + httpServiceFactory.webroot ;
							notifyIcon.Text = t.Substring ( 0 , Math.Min ( 127 , t.Length ) ) ;
						}
						Icon =
						notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
						stopServerMenuItem.Text = "Stop http server" ;
						notifyIcon.ShowBalloonTip ( 3000 , "Http server is working" , statusLabel.Text , ToolTipIcon.Info ) ;
					}
				} ) ;
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
				if ( webServer == null ) return ;
				if ( webServer == sender as WebServer )
				{
					
					string p = webServer.port.ToString () ;
					HttpServiceFactory httpServiceFactory  = ( HttpServiceFactory ) webServer.serviceFactory ;
					if ( httpServiceFactory.isResourceBased )
					{
						string a = httpServiceFactory.resourceAssembly.GetName().Name ;
						statusLabel.Text = "Stoped on port " + p + ", assembly: " + a ;
						p = "Stoped on port " + p + ", assembly:\r\n" + a ;
						notifyIcon.Text = p.Substring ( 0 , Math.Min ( 127 , p.Length ) ) ;
					}
					else 
					{
						statusLabel.Text = "Stoped on port " + p + ", webroot: " + httpServiceFactory.webroot ;
						p = "Stoped on port " + p + ", webroot:\r\n" + httpServiceFactory.webroot ;
						notifyIcon.Text = p.Substring ( 0 , Math.Min ( 127 , p.Length ) ) ;
					}
					Icon = notifyIcon.Icon = SimpleHttp.Properties.Resources.mainIcon ;
					stopServerMenuItem.Visible = false ;
					showStartDialogMenuItem.Visible = true ;
				}
			} ) ;
		}
		protected bool isCriticalError ;
		protected void webServer_criticalErrorRaised ( object sender , ErrorAndUriEventArgs e )
		{
			Exception ex = e.GetException() ;
			webServer_connectionErrorRaised ( sender , new HttpConnectionDetails ( e.uri , ex ) ) ;
			BeginInvoke ( ()=>
			{
				string s = "Http server is down,\r\n" + ( ex.InnerException == null ? ex.Message : ex.InnerException.Message ) ;
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
		protected override void OnResize ( EventArgs e )
		{
			if ( WindowState != FormWindowState.Minimized ) 
			{ 
				restoredWindowState = WindowState ;
				Opacity = 1.0 ;
				//if ( API.GetForegroundWindowProc () == Handle ) 
				//	Opacity = 1.0 ;
				//else Opacity = 0.8 ;
				if ( previousWindowState == FormWindowState.Minimized )
				{
					if ( messageForm == null )
					{
						if ( startServerForm != null )
							BeginInvoke ( () =>
							{
								startServerForm.BringToFront () ;
								startServerForm.Select () ;
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

		private void startServerForm_FormClosed ( object? sender , FormClosedEventArgs e )
		{
			startServerForm.FormClosed -= startServerForm_FormClosed ; //ah govnari
			startServerForm.Dispose () ;
			if ( isListening ) 
				spliterLayout.Enabled = true ;
			else Close () ;
		}

		public void HideProperties ()
		{
			spliterLayout.Panel2Collapsed = true ;
			closePropertiesButton.Visible = false ;
		}
		public void ShowProperties ()
		{
			spliterLayout.Panel2Collapsed = false ;
			closePropertiesButton.Visible = true ;
			if ( requestGrid.Rows.Count > 0 )
			{
				int h = statusLabel.Height - 2 ;
				closePropertiesButton.Anchor = AnchorStyles.None ;
				closePropertiesButton.Size = new Size ( h * 4 / 3 , h ) ;
				closePropertiesButton.Location = new Point ( -1 + spliterLayout.Right - closePropertiesButton.Width , 1 + spliterLayout.Top ) ;
				closePropertiesButton.BringToFront () ;
				closePropertiesButton.Anchor = AnchorStyles.Right | AnchorStyles.Top ;
			}
			requestGrid.Rows.Clear () ;
			responseGrid.Rows.Clear () ;
			if ( logList.SelectedIndex == -1 ) return ;
			HttpConnectionDetails connectionDetails = ( HttpConnectionDetails ) logList.Items [ logList.SelectedIndex ] ;
			if ( connectionDetails.error == null )
			{
				lbError.Text = "" ;
				lbError.Visible = false ;
			}
			else 
			{
				lbError.Text = connectionDetails.error.InnerException == null ? connectionDetails.error.Message : connectionDetails.error.InnerException.Message ;
				lbError.Visible = true ;
			}
			originLabel.Text = "Origin: " + ( connectionDetails.origin == null ? "?" : connectionDetails.origin.ToString() ) ;
			int i ;
			string [] lines = connectionDetails.requestHeader.Split ( "\r\n" ) ;
			if ( lines.Length > 0 )
			{
				requestLabel.Text = lines [ 0 ] ;
				for ( i = 1 ; i < lines.Length ; i++ )
					addRow ( lines [ i ] , requestGrid ) ;
			}
			else requestLabel.Text = "<empty request>" ;
			lines = connectionDetails.responseHeader.Split ( "\r\n" ) ;
			if ( lines.Length > 0 )
			{
				responseLabel.Text = lines [ 0 ] ;
				for ( i = 1 ; i < lines.Length ; i++ )
					addRow ( lines [ i ] , responseGrid ) ;
			}
		}
		private void addRow ( string line , DataGridView grid )
		{
			if ( line == "" ) return ;
			int i = line.IndexOf ( ':' ) ;
			if ( i == -1 )
				grid.Rows.Add ( new object [ 2 ] { line , "" } ) ;
			else grid.Rows.Add ( new object [ 2 ] { line.Substring ( 0 , i ) , line.Substring ( i + 1 ) } ) ;
		}
		private void webServer_clientConnected ( object sender , HttpConnectionDetails connectionDetails )
		{
			BeginInvoke ( () =>
			{
				ListBox.ObjectCollection listItems = logList.Items ;
				int maxItems = 1000 ;
				logList.ItemHeight = statusLabel.Height ;
				if ( listItems.Count > maxItems )
				{
					int c = logList.Items.Count - maxItems  ;
					object [ ] items = new object [ c ] ;
					for ( int i = 0 ; i < c ; i++ )
						items [ i ] = logList.Items [ i + maxItems ] ;
					listItems.Clear () ;
					listItems.AddRange ( items ) ;
				}
				logList.Items.Add ( connectionDetails ) ;
			} ) ;
		}
		private void webServer_serverResponded ( object sender , HttpConnectionDetails connectionDetails )
		{
			BeginInvoke ( () =>
			{
				DateTime lastDate = connectionDetails.created.AddMinutes ( -1 ) ; 
				ListBox.ObjectCollection items = logList.Items ;
				int c = items.Count - 1 ;
				logList.ItemHeight = statusLabel.Height ;
				for ( int i = c ; i >= 0 ; i-- )
				{
					HttpConnectionDetails oldConnectionDetails = ( HttpConnectionDetails ) items [ i ] ;
					if ( oldConnectionDetails == connectionDetails )
					{
						items.RemoveAt ( i ) ;
						items.Insert ( i , connectionDetails ) ;
						return ;
					}
					if ( oldConnectionDetails.created < lastDate ) break ;
				}
				items.Add ( connectionDetails ) ;
			} ) ;
		}

		private void logList_Click(object sender, EventArgs e)
		{
			if ( logList.SelectedIndex != -1 ) ShowProperties () ;
		}



		private void closePropertiesButton_Click(object sender, EventArgs e)
		{
			HideProperties () ;
		}
		private void focusTopForm ()
		{
			if ( messageForm != null )
				if ( messageForm.Visible )
				{
					messageForm.BringToFront () ;
					return ;
				}
			if ( startServerForm != null )
				if ( startServerForm.Visible )
					startServerForm.BringToFront () ;
		}
		private void messageFormOK_Click ( object sender , EventArgs e )
		{
			( ( Form ) sender ).Dispose () ;
			try
			{
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
			notifyIcon.Text = "Http server is down" ;
			Icon =
			notifyIcon.Icon = SimpleHttp.Properties.Resources.stopIcon ;
			statusLabel.Text = "Closed" ;
			if ( closeProgramDemand ) 
			{
				closeProgramConfirmed = true ;
				Close () ;
			}
			else showServerStarterForm () ;
			focusTopForm () ;
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
			spliterLayout.Enabled = Application.OpenForms.Count == 1 ;
			if ( WindowState == FormWindowState.Minimized ) return ; 
			if ( !ShowInTaskbar ) return ; 
			if ( startServerForm == null ) return ;
			if ( startServerForm.Visible ) startServerForm.Focus () ;
		}
		private void stopButton_Click ( object sender , EventArgs e )
		{

			//ShowMessage ( SimpleHttp.Properties.Resources.warningIcon ,
			//							"Stoping server" , "Do you want to stop http server?" ,
			//							"Stop server" , "" , "Keep sever working" ) ;
			//spliterLayout.Enabled = false ;
		}
		private void messageForm_Disposed ( object sender , EventArgs e )
		{
			MessageForm ms = sender as MessageForm ;
			if ( ms == messageForm ) messageForm = null ;
		}
		protected void showErrorMessage ( string title , string messageText )
		{
			ShowMessage ( SimpleHttp.Properties.Resources.closeIcon , title , messageText , "" , "" , "Continue" ) ;
		}
		public void ShowErrorMessage ( string title , Exception exp )
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
				showServerStarterForm () ;
				showErrorMessage ( title , message ) ;
			}
		}
		public void InvokeShowErrorMessage ( string title , Exception exp  )
		{
			BeginInvoke ( () =>
				{
					ShowErrorMessage ( title , exp ) ;
				} ) ;
		}

		public void ShowMessage ( Image image , string title , string caption , 
									string okButtonText , string noButtonText, string cancelButtonText )
		{

			if ( messageForm == null )
				messageForm = MessageForm.Show ( this , image , title , caption , 
									okButtonText , noButtonText , cancelButtonText ,
									messageFormOK_Click , messageFormNo_Click , messageFormCancel_Click , 
									messageForm_Closed , messageForm_Disposed ) ;
			else
			{
				messageForm.setAll ( image , title , caption , okButtonText , noButtonText , cancelButtonText ) ;
				messageForm.Show () ;
				messageForm.BringToFront () ;
			}
		}
		protected override void OnFormClosing ( FormClosingEventArgs e )
		{
			if ( !closeProgramConfirmed && isListening )
			{
				e.Cancel = true ;
				if ( closeProgramDemand || ( messageForm != null )  && ( e.CloseReason == CloseReason.UserClosing ) )
				{
					ShowMessage ( SimpleHttp.Properties.Resources.closeIcon ,
									"Closing program" , "                  Do you want to close http server?" ,
									"Close program and server" , "Just stop server" , "Keep sever working" ) ;
					
				}
				else
				{
					ShowInTaskbar = false ;
					Hide () ;
				}
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
		private void iconMenu_Opening ( object sender , System.ComponentModel.CancelEventArgs e )
		{
			bool showStartDialogMenuItemVisible = showStartDialogMenuItem.Visible = !isListening ;
			//jebo im pas mater
			showMonitorMenuItem.Visible = !Visible ;
			stopServerMenuItem.Visible = isListening ;
			if ( isListening )
			{
				toolStripSeparator1.Visible = showStartDialogMenuItemVisible || !Visible ;
				toolStripSeparator2.Visible = true ;
			}
			else 
			{
				toolStripSeparator1.Visible = showStartDialogMenuItemVisible || !Visible ;
				toolStripSeparator2.Visible = false ;
			}
			closeProgramMenuItem.Text = isListening ? "Close http server and program" : "Close program" ;
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
				if ( WindowState == FormWindowState.Minimized ) 
				{
					previousWindowState = FormWindowState.Minimized ;
					WindowState = restoredWindowState ;
				}
				Activate () ;
				API.BringWindowToTop ( Handle ) ;
				if ( continueWidth != null ) continueWidth.DynamicInvoke ( args ) ;
			} ) ;
		}
		private void iconMenu_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
		{
			if ( e.ClickedItem == showMonitorMenuItem )
				restoreForm () ;
			else if ( e.ClickedItem == showStartDialogMenuItem )
			{
				restoreForm ( showServerStarterForm ) ;
			}
			else if ( e.ClickedItem == stopServerMenuItem )
			{
				if ( isListening )
					restoreForm ( () =>
					{
						closeProgramDemand = false ;
						closeProgramConfirmed = false ;
						ShowMessage ( SimpleHttp.Properties.Resources.warningIcon ,
												"Stoping server" , "Do you want to close http server?" ,
												"Stop server" , "" , "Keep sever working" ) ;

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
				iconMenu_ItemClicked ( iconMenu , new ToolStripItemClickedEventArgs ( showMonitorMenuItem ) ) ;
			}
		}

		private void iconMenu_Closed ( object sender, ToolStripDropDownClosedEventArgs e )
		{
			//showMenuItem.Visible = true ;

		}

		private void lbError_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText ( lbError.Text ) ;
		}
		private void logList_DrawItem ( object sender , DrawItemEventArgs e )
		{
			
			bool notSelected = ( e.State & DrawItemState.Selected ) == 0 ;
			Brush back = notSelected ? 
				(  e.Index & 1 ) == 0 ? logBackBrush0 : logBackBrush1 
				: logSelectedBackBrush ;
			Brush ink = notSelected ? logInkBrush : logSelectedInkBrush ;
			
			e.Graphics.FillRectangle ( back , e.Bounds ) ;
			if ( e.Index == -1 ) return ; //??????!!!!!!!!!!??? @#@$@!!
			HttpConnectionDetails connectionDetails = ( HttpConnectionDetails ) logList.Items [ e.Index ] ;
			string s = connectionDetails.ToString() ;
			SizeF sz = e.Graphics.MeasureString ( "W|" , logList.Font ) ;
			int t = ( e.Bounds.Height - ( int ) sz.Height ) >> 1 ;
			e.Graphics.DrawString ( s , logList.Font , ink , 
				new Rectangle ( e.Bounds.Left , e.Bounds.Top + t , 65535 , e.Bounds.Height - t ) ) ;
		}

		private void lbError_MouseEnter(object sender, EventArgs e)
		{
			lbError.BackColor = SystemColors.Window ; 
		}

		private void lbError_MouseLeave(object sender, EventArgs e)
		{
			lbError.BackColor = lbError.Parent.BackColor ;
		}

		private void lbError_Click ( object sender , EventArgs e )
		{
			try
			{
				HttpConnectionDetails connectionDetails = ( HttpConnectionDetails ) logList.Items [ logList.SelectedIndex ] ;
				showErrorMessage ( "Stack trace" , connectionDetails.error.StackTrace ) ;
			}
			catch { }
		}
	}
}