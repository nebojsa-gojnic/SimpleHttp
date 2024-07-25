using System ;
using System.Windows.Forms ;
using System.Reflection ;
using System.Text ;
using System.Net ;
using System.Net.Sockets ;
using System.Net.Security ;
using System.Security ;
using System.Security.Authentication ;
using System.Security.Cryptography ;
using System.Security.Cryptography.X509Certificates ;
using WebSockets ;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq ;

namespace SimpleHttp
{
	/// <summary>
	/// Site SSL certificate tester
	/// </summary>
	public class CertificateTest : IDisposable
	{
		/// <summary>
		/// Creates new instance of CertificateTest class
		/// </summary>
		/// <param name="source">Certificate file path</param>
		/// <param name="password">Password for certificate file, it can be empty</param>
		/// <param name="sslProtocol">SSL protocol to use(SslProtocols enum).<br/>
		/// SslProtocols.Tls2 and SslProtocols.Tls3 are the only really valid options.</param>
		/// <param name="port">Socket port, it you set to 0 any availible port will be usesd(system supplied),<br/>
		/// and this.port property value will be changed to reall value once webServer starts listening</param>
		/// <param name="siteName">Site name, also known as Header Site Name("CN=site_name_here")</param>
		public CertificateTest ( string source , string password , SslProtocols sslProtocol , int port , string siteName )
		{
			this.source = source ;
			this.password = password == null ? "" : password ;
			this.accepted = false ;
			this.loaded = false ;
			this.sslProtocol = sslProtocol ;
			this.port = port ; 
			this.siteName = siteName ;
		}
		/// <summary>
		/// This is true if object is disposed
		/// </summary>
		public bool isDisposed
		{
			get ;
			protected set ;
		}
		/// <summary>
		/// This is true if certificate is loaded from given source
		/// </summary>
		public bool loaded
		{
			get ;
			protected set ;
		}
		/// <summary>
		/// This is true if certificate is loaded ans positivly tested
		/// </summary>
		public bool accepted
		{
			get ;
			protected set ;
		}
		/// <summary>
		/// Site name to target
		/// </summary>
		public string siteName
		{
			get ;
			set ;
		}
		/// <summary>
		/// HttpClient instance
		/// </summary>
		protected HttpClient httpClient ;
		/// <summary>
		/// Web Server for testing
		/// </summary>
		protected WebServer webServer ;
		/// <summary>
		/// Certificate
		/// </summary>
		public X509Certificate2 certificate
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// Tls 1.2 or Tls 1.3
		/// </summary>
		public SslProtocols sslProtocol
		{
			get ;
			protected set ;
		}
		/// <summary>
		/// Auxiliary variable for the port property
		/// </summary>
		protected int _port ;
		/// <summary>
		/// Get method for the port property
		/// </summary>
		protected int getPort ()
		{
			//( ( IPEndPoint ) _listener.LocalEndpoint ).Port
			return webServer == null ? _port : webServer.port ;
		}
		/// <summary>
		/// Set method for the port property
		/// </summary>
		protected void setPort ( int value )
		{
			_port = value ;
		}
		/// <summary>
		/// Port
		/// </summary>
		public int port
		{
			get => getPort () ;
			protected set => setPort ( value ) ;
		}
		/// <summary>
		/// Full file path to certificate
		/// </summary>
		public string source 
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// Certificate file password
		/// </summary>
		public string password
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// Error on client side
		/// </summary>
		public Exception certificateClientError
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// Error on server side
		/// </summary>
		public Exception certificateServerError
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// Invalid password or file load error
		/// </summary>
		public Exception certificateLoadError
		{
			get ;
			protected set ;
		} = null! ; // I dont know when they introduced this in C# but I HATE IT
		/// <summary>
		/// This event is fired when certificate loading started
		/// </summary>
		public event EventHandler loadingStarted ; 
		/// <summary>
		/// This event is fired when certificate client server communication started(real test)
		/// </summary>
		public event EventHandler attemptingComunication ; 
		/// <summary>
		/// This is fired if loading of certificate failes
		/// </summary>
		public event ErrorEventHandler certificateLoadFailed ;
		/// <summary>
		/// This is fired if SSL comuncatin failes on client side.
		/// <br/>This event can be fired before of after certificateFailedOnServer therefore
		/// <br/>object handling event must be able to adjust its work for two asynchronious messages.
		/// </summary>
		public event ErrorEventHandler certificateFailedOnClient ;
		/// <summary>
		/// This is fired if SSL comuncatin failes on server side.
		/// <br/>This event can be fired before of after certificateFailedOnClient therefore
		/// <br/>object handling event must be able to adjust its work for two asynchronious messages.
		/// </summary>
		public event ErrorEventHandler certificateFailedOnServer ;
		/// <summary>
		/// Fired when certificate tested and accepted
		/// </summary>
		public event EventHandler certificateAccepted ;
		/// <summary>
		/// Fired when certificate loaded. After certificate is loaded further testing must be activated with testCertifiate() call.
		/// </summary>
		public event EventHandler<CertificateSource> certificateLoaded ;
		/// <summary>
		/// Raised when TCP connection is interrupted or cannot be open for reasons not related to SSL.
		/// </summary>
		public event EventHandler<ErrorEventArgs> openTcpTestFailed ;
		/// <summary>
		/// Tries to load certificate. If exception is raised it is delivered via certificateLoadFailed event.
		/// </summary>
		public void loadCertifiacte ()
		{
			certificate = null ; //cs8625 !?!?
			certificateLoadError = null ;
			certificateClientError = null ;
			certificateServerError = null ;
			try
			{ 
				certificate = new X509Certificate2 ( source , password ) ;
				loadingStarted?.Invoke ( this , new EventArgs () ) ;
				loaded = true ;
				certificateLoaded?.Invoke ( this , new CertificateSource ( certificate , source ) ) ;
			}
			catch ( Exception x )
			{
				certificateLoadError = x ;
			}
			if ( certificateLoadError != null ) 
			{
				certificateLoadFailed?.Invoke ( this , new ErrorEventArgs ( certificateLoadError ) ) ;
				if ( certificate != null ) certificate.Dispose () ;
			}
		}
		/// <summary>
		/// Attepmts to make client server communication over SSL(TLS).
		/// <br/>It starts asynchonious communcation and it may delviers result exception(s)
		/// <br/>via openTcpTestFailed, certificateFailedOnClient, certificateFailedOnServer events.
		/// If test is successfull it will be reflected via certificateAccepted, see onHttpClient() method.
		/// </summary>
		public void testCertifiate ( )
		{
			certificateServerError = null ;
			certificateClientError = null ;
			if ( certificate == null ) 
			{
				loadCertifiacte () ;
				return ;
			}
			attemptingComunication?.Invoke ( this , new EventArgs () ) ;
			try
			{
				if ( webServer == null )
				{
					webServer = new WebServer () ;
					webServer.addPath ( "*" , 0 , "Tester" , typeof ( TestHttpService ) , new TestHttpService.TestHttpServiceData ( "test message" ) ) ;
					webServer.connectionErrorRaised += webServer_connectionErrorRaised ;
					webServer.serviceErrorRaised += webServer_serviceErrorRaised;
					webServer.disposed += webServer_disposed ;
				}
				else webServer.Stop () ;
				webServer.addPath ( "/*" , 0 , new HttpServiceActivator ( typeof ( TestHttpService ) , new TestHttpService.TestHttpServiceData ( "Certificate Test Message" ) ) ) ;

				webServer.Listen ( new TestWebConfigData ( "Connectin OK" , siteName , _port , "" , "" , sslProtocol , certificate ) ) ;
				httpClient = new HttpClient () ;
				httpClient.GetStringAsync ( "https://" + siteName + ":" + webServer.port.ToString () + "/" ).ContinueWith ( onHttpClient ) ;
			}
			catch ( Exception x )
			{ 
				if ( webServer != null )
				{
					WebServer wb = webServer ;
					webServer = null ;
					wb.Dispose() ;
				}
				certificateClientError = x ;
				if ( httpClient != null ) httpClient.Dispose() ;
			}
			if ( certificateClientError != null ) onOpenTcpTestFailed ( new ErrorEventArgs ( certificateClientError ) ) ;
		}
		/// <summary>
		/// When webServer is disposed this event handler set webServer null.
		/// </summary>
		/// <param name="sender">Disposed WebServer instance.</param>
		/// <param name="e">(EventArgs)</param>
		private void webServer_disposed ( object? sender , EventArgs e )
		{
			if ( webServer == sender as WebServer ) webServer = null ;
		}
		/// <summary>
		/// When critical error is raised on webServer during coomunication test
		/// <br/>this event handler calls onOpenTcpTestFailed() method in order to raise openTcpTestFailed event
		/// </summary>
		/// <param name="sender">WebServer instance</param>
		/// <param name="e">ErrorEventArgs instance, call GetException() method to get exception</param>
		private void webServer_serviceErrorRaised ( object sender , IncomingHttpConnection e )
		{
			if ( webServer == sender as WebServer ) onOpenTcpTestFailed ( new ErrorEventArgs ( e.error ) ) ;
		}
		/// <summary>
		/// When error is raised during connection handling on webServer 
		/// <br/>this event handler calls onCertificateFailedOnServer() method in order to raise certificateFailedOnServer event
		/// </summary>
		/// <param name="sender">WebServer instance</param>
		/// <param name="e">IncomingHttpConnection instance, the exception is in error property</param>
		private void webServer_connectionErrorRaised ( object? sender , IncomingHttpConnection e )
		{
			onCertificateFailedOnServer ( new ErrorEventArgs ( certificateServerError = e.error ) ) ;
		}
		/// <summary>
		/// This method is fired after client communication attempt is finished.
		/// <br/>If successfull it will call acceptHttpClient() method
		/// <br/>otherwise it will call onCertificateFailedOnClient() method
		/// <br/>in order to raise certificateFailedOnClient event.
		/// </summary>
		/// <param name="task">(Task&lt;string&gt;)</param>
		protected void onHttpClient ( Task<string> task )
		{
			if ( task.Exception == null )
				acceptHttpClient ( ) ;
			else 
			{
				certificateClientError = task.Exception ;
				if ( certificateClientError.InnerException != null ) certificateClientError = certificateClientError.InnerException ;
				onCertificateFailedOnClient  ( new ErrorEventArgs ( certificateClientError ) ) ;
			}
		}
		/// <summary>
		/// This method checks if certificateClientError is null for 2 seconds.<br/>
		/// If certificateClientError is still null after 2 seconds<br/>
		/// it calls onAcceptCertificate() method in order to reflect success via certificateAccepted event.
		/// <br/>It also disposes webServer at the end.
		/// </summary>
		protected void acceptHttpClient ( )
		{
			certificateClientError = null ;
			if ( certificateClientError == null ) 
			{
				for ( int i = 0 ; i < 10 ; i++ )
					if ( certificateServerError == null )
						Thread.Sleep ( 200 ) ;
					else break ;
				if ( certificateServerError == null ) onAcceptCertificate ( ) ;
			}
			else onCertificateFailedOnClient ( new ErrorEventArgs ( certificateClientError ) ) ;
			try
			{
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
		}
		/// <summary>
		/// This method raises certificateFailedOnServer event and stores exception in certificateServerError property 
		/// </summary>
		/// <param name="e">(ErrorEventArgs), call GetException() method to get exception</param>
		protected void onCertificateFailedOnServer ( ErrorEventArgs e )
		{
			certificateServerError = e.GetException() ;
			certificateFailedOnServer?.Invoke ( this , e ) ;
			try
			{
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
		}
		/// <summary>
		/// This method raises certificateFailedOnClient event and stores exception in certificateFailedOnClient property 
		/// </summary>
		/// <param name="e">(ErrorEventArgs), call GetException() method to get exception</param>
		protected void onCertificateFailedOnClient ( ErrorEventArgs e )
		{
			certificateClientError = e.GetException() ;
			certificateFailedOnClient?.Invoke ( this , certificateClientError.InnerException == null ? e : new ErrorEventArgs ( certificateClientError.InnerException ) ) ;
			try
			{
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
		}
		/// <summary>
		/// This method raises openTcpTestFailed event and stores exception in openTcpTestFailed property 
		/// </summary>
		/// <param name="e">(ErrorEventArgs), call GetException() method to get exception</param>
		protected void onOpenTcpTestFailed ( ErrorEventArgs e )
		{
			openTcpTestFailed?.Invoke ( this , e ) ;
			try
			{
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
		}
		/// <summary>
		/// This methos set accepted property value to true and raises certificateAccepted
		/// </summary>
		protected void onAcceptCertificate (  ) 
		{
			accepted = true ;
			certificateAccepted?.Invoke ( this , new EventArgs () ) ;
		}
		/// <summary>
		/// Dispose all that should be disposed and set isDisposed property value to true 
		/// </summary>
		public virtual void Dispose()
		{
			if ( isDisposed ) return ;
			isDisposed = true ;
			try
			{ 
				if ( webServer != null ) webServer.Dispose () ;
			}
			catch { }
		}
	}
}
