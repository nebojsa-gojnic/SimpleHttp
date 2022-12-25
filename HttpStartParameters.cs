using System.Security.Authentication ;
namespace SimpleHttp
{
	/// <summary>
	/// Start parameters with argument parser 
	/// </summary>
	public class HttpStartParameters
	{
		/// <summary>
		/// TCP port (0-65535)
		/// </summary>
		public int port { get ; protected set ; }
		/// <summary>
		/// Folder path for file based server or
		/// <br/>assembly file path or assembly name for resource base server
		/// </summary>
		public string source { get ; protected set ; }
		/// <summary>
		/// Site name(for UI, web server does not need it)
		/// </summary>
		public string sitename { get ; protected set ; }
		/// <summary>
		/// Certificate file path. If empty or null flat HTTP is used.
		/// </summary>
		public string certificate { get ; protected set ; }
		/// <summary>
		/// Certificate file password
		/// </summary>
		public string password { get ; protected set ; }
		/// <summary>
		/// Auto start or not
		/// </summary>
		public bool autoStart { get ; protected set ; }
		/// <summary>
		/// Parsing error message
		/// </summary>
		public string errorMessage { get ; protected set ; }
		/// <summary>
		/// SSL protocol (Tls 1.1, Tls 1.2, Tls 1.3), default is SslProtocols.Tls12
		/// </summary>
		public SslProtocols protocol { get ; protected set ; }
		/// <summary>
		/// File or resource based server
		/// </summary>
		public StartServerMode mode { get ; protected set ; }
		/// <summary>
		/// Enum for argument parser
		/// </summary>
		protected enum commandEnum
		{
			none = 0 ,
			port = 1 ,
			certificate ,
			sitename ,
			password ,
			fileServerMode ,
			resourceServerMode ,
		}
		/// <summary>
		/// Creates new instance of HttpStartParameters from given program start arguments
		/// </summary>
		/// <param name="args">Program start arguments to parse</param>
		public HttpStartParameters ( string[] args )
		{
			bool startFileServer = false ;
			bool startResourceServer = false ;
			port = 80 ;
			autoStart = args.Length > 0 ;
			source = "" ;
			certificate = "" ;
			sitename = "" ;
			password = "" ;
			errorMessage = "" ;
			protocol = SslProtocols.Tls12 ;
			commandEnum command = commandEnum.none ;
			string fileSource ;
			string assemblyName ;
			string badWord = "" ;
			foreach ( string param in args )
			{
				switch ( param [ 0 ] )
				{
					case '/' :
					case '-' :
						switch ( param.Substring ( 1 ).Trim().ToLower() )
						{
							case "webroot" :
							case "folder" :
							case "directory" :
							case "f" :
								command = commandEnum.fileServerMode ;
							break ;
							case "port" :
							case "p" :
								command = commandEnum.port ;
							break ;
							case "resources" :
							case "resource" :
							case "r" :
								command = commandEnum.resourceServerMode ;
							break ;
							case "sitename" :
							case "s" :
								command = commandEnum.sitename ;
							break ;
							case "certificate" :
							case "c" :
								command = commandEnum.certificate ;
							break ;
							case "password" :
							case "pw" :
								command = commandEnum.password ;
							break ;
							case "dialog" :
							case "dontstart" :
							case "d" :
								autoStart = false ;
							break ;
							case "tls" :
								protocol = SslProtocols.Tls ;
								command = commandEnum.none ;
							break ;
							case "tls1" :
								protocol = SslProtocols.Tls ;
								command = commandEnum.none ;
							break ;
							case "tls1.1" :
							case "tls11" :
								protocol = SslProtocols.Tls11 ;
								command = commandEnum.none ;
							break ;
							case "tls1.2" :
							case "tls12" :
								protocol = SslProtocols.Tls12 ;
								command = commandEnum.none ;
							break ;
							case "tls1.3" :
							case "tls13" :
								protocol = SslProtocols.Tls13 ;
								command = commandEnum.none ;
							break ;
							default :
								badWord = param ;
								command = commandEnum.none ;
							break ;
						}
					break ;
					default:
						switch ( command )
						{
							case commandEnum.fileServerMode :
								source = fileSource = param ;
								startFileServer = true ;
								startResourceServer = false ;
								mode = StartServerMode.fileServer ;
							break ;
							case commandEnum.resourceServerMode :
								source = assemblyName = param ;
								startFileServer = false ;
								startResourceServer = true ;
								mode = StartServerMode.resourceServer ;
							break ;
							case commandEnum.port :
								int p ;
								if ( int.TryParse ( param , out p ) ) port = p ;
							break ;
							case commandEnum.certificate :
								certificate = param ;
							break ;
							case commandEnum.sitename :
								sitename = param ;
							break ;
							case commandEnum.password :
								password = param ;
							break ;
							default :
								badWord = param ;
								command = commandEnum.none ;
							break ;
						}
					break ;
				}
				if ( badWord.Length > 0 ) break ; 
			}
			if ( startFileServer && startResourceServer )
			{
				errorMessage = "Cannot use both file system and assemlby resources as source.\r\n" + getGeneralSyntaxText () ;
			}
			else if ( !startFileServer && !startResourceServer )
			{
				errorMessage = "No server type/resource specification found.\r\n" + getGeneralSyntaxText () ;
			}
			else if ( badWord != "" )
			{
				errorMessage = "Invalid syntax at \"" + badWord + "\".\r\n" + getGeneralSyntaxText () ;
			}
		}
		/// <summary>
		/// Creates new instance of HttpStartParameters 
		/// </summary>
		/// <param name="mode">File or resource based server</param>
		/// <param name="port"></param>
		/// <param name="source">Folder path for file based server or
		/// <br/>assembly file path or assembly name for resource base server
		/// </param>
		/// <param name="sitename">Site name(for UI, web server does not need it)</param>
		/// <param name="certificate">Certificate file path. If empty or null flat HTTP is used.</param>
		/// <param name="password">Certificate file password</param>
		/// <param name="protocol">SSL protocol (Tls 1.1, Tls 1.2, Tls 1.3), default is SslProtocols.Tls12</param>
		/// <param name="autoStart">Auto start or not</param>
		public HttpStartParameters ( StartServerMode mode , int port , string source , string sitename , string certificate , string password , SslProtocols protocol , bool autoStart  )
		{
			errorMessage = "" ;
			this.port = port ;
			this.mode = mode ;
			this.source = source ;
			this.sitename = sitename ;
			this.certificate = certificate ;
			this.password = password ;
			this.protocol = protocol ;
			this.autoStart = this.autoStart ;
		}
		public string getGeneralSyntaxText ( )
		{
			string pr = noPath ( Application.ExecutablePath ) ;
			return "Syntax:\r\n" + pr + " < [/f <folder path>] | [/r <assembly name or path>] > [/p <port number>] [/c <certificate file path>] [/pw <certificte file password>] [ /tls11 | /tls12 | /tls13 ] [/s <site name>] [/d]\r\n/d is for \"don't start\"" ;
		}
		public static string noPath ( string path )
		{
			int i = path.LastIndexOf ( '\\' ) ;
			return i == -1 ? path : i == path.Length - 1 ? "" : path.Substring ( i + 1 ) ;
		}
		public static string TlsShort ( SslProtocols protocol )
		{
			switch ( protocol )
			{
				case SslProtocols.Tls :
					return "tls" ;
				case SslProtocols.Tls11 :
					return "tls11" ;
				case SslProtocols.Tls13 :
					return "tls13" ;
				case SslProtocols.Tls12 :
				default:
					return "tls12" ;
			}
		}
		public override string ToString()
		{
			return ( mode == StartServerMode.resourceServer ? "/r" : "/f" ) + " \"" + source + "\" /p " + port.ToString() + " " +
							( string.IsNullOrWhiteSpace ( certificate ) ? "" :
							( "/c \"" + certificate + "\" " + 
							( string.IsNullOrWhiteSpace ( password ) ? "" : ( "/pw \"" + password + "\" " ) ) + 
							"/" + TlsShort ( protocol ) + " " ) +
							( string.IsNullOrWhiteSpace ( sitename ) ? "" : ( "/s \"" + sitename + "\"" ) ) 
							).Trim() ;
		}
	}


}
