using System ;
using System.IO ;
using System.IO.Pipes ;
using System.Text ;
using System.Diagnostics ;

namespace SimpleHttp
{
	public static class Program
	{
		private class ProgramStartParameters
		{
			public int port { get ; protected set ; }
			public string source { get ; protected set ; }
			public bool startFileServer { get ; protected set ; }
			public bool startResourceServer { get ; protected set ; }
			public bool autoStart { get ; protected set ; }
			public string errorMessage { get ; protected set ; }
			public StartServerMode mode { get ; protected set ; }
			public ProgramStartParameters ( string[] args )
			{
				startFileServer = false ;
				startResourceServer = false ;
				port = 80 ;
				autoStart = args.Length > 0 ;
				bool prevStartFileServer = false ;
				bool prevStartResourceServer = false ;
				bool prevPort = false ;
				string fileSource ;
				string assemblyName ;
				string badWord = "" ;
				foreach ( string param in args )
				{
					switch ( param [ 0 ] )
					{
						case '/' :
						case '-' :
							switch ( param [ 1 ] )
							{
								case 'f' :
									prevStartFileServer = true ;
									startResourceServer = true ;
									prevPort = false ;
								break ;
								case 'p' :
									prevPort = true ;
								break ;
								case 'r' :
									prevPort = false ;
									prevStartResourceServer = true ;
									startFileServer = true ;
								break ;
								case 's' :
									prevPort = false ;
									autoStart = false ;
									prevStartFileServer = false ;
									prevStartResourceServer = false ;
								break ;
								default :
									prevPort = false ;
									prevStartFileServer = false ;
									prevStartResourceServer = false ;
								break ;
							}
						break ;
						default:
							if ( prevPort )
							{
								int p ;
								if ( int.TryParse ( param , out p ) ) port = p ;
								prevPort = false ;
							}
							else if ( prevStartFileServer )
							{
								source = fileSource = param ;
								prevStartFileServer = false ;
								mode = StartServerMode.fileServer ;
							}
							else if ( prevStartResourceServer )
							{
								source = assemblyName = param ;
								prevStartResourceServer = false ;
								mode = StartServerMode.resourceServer ;
							}
							else badWord = param ;
						break ;
					}
				}
				if ( startFileServer && startResourceServer )
				{
					errorMessage = "Cannot use both file system and assemlby resources as source.\r\n" + getGeneralSyntaxText () ;
				}
				else if ( badWord != "" )
				{
					errorMessage = "Invalid syntax at \"" + badWord + "\".\r\n" + getGeneralSyntaxText () ;
				}
			}
			public string getGeneralSyntaxText ( )
			{
				string pr = noPath ( Application.ExecutablePath ) ;
				return "Syntax:\r\n" + pr + " /r <assembly name> [/p <port number>] [/s]\r\nor\r\n" +
						pr + " /f <folder path> [/p <port number>] [/s]\r\r/s - no auto start, show dialog instead" ;
			}
			public static string noPath ( string path )
			{
				int i = path.LastIndexOf ( '\\' ) ;
				return i == -1 ? path : i == path.Length - 1  ? "" : path.Substring ( i + 1 ) ;
			}
		}
		public static string ExecutableFolder ()
		{
			string s = Application.ExecutablePath ;
			int i = s.LastIndexOf ( '\\' ) ;
			return i == -1 ? s : s.Substring ( 0 , i ) ;
		}
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			Process currentProcess = Process.GetCurrentProcess () ;
			//PipeMania.App.dummy = "" ;
			foreach ( Process process in Process.GetProcessesByName ( "SimpleHttp" ) )
				if ( process.Id != currentProcess.Id )
				{
					
					//API.ShowWindow ( process.MainWindowHandle , ShowWindowStyle.SW_Show ) ;
					//API.RestoreWindow ( process.MainWindowHandle ) ;
					//API.SendCopyData ( process.MainWindowHandle , "show" ) ;

					NamedPipeClientStream sender = null ;
					try
					{
						sender = new NamedPipeClientStream ( "." , "SimpleHttp" , PipeDirection.Out ) ;
						sender.Connect ( 1000 ) ;
						sender.Write ( Encoding.ASCII.GetBytes ( "show" ) ) ;
						sender.Flush () ;
						sender.Close () ;
						sender.Dispose () ;
						sender = null ;
					}
					catch { }
					try
					{
						if ( sender != null ) sender.Dispose () ;
					}
					catch { }

					return ;
				}

			ApplicationConfiguration.Initialize() ;
			ProgramStartParameters pars = new ProgramStartParameters ( args ) ;
			Application.Run ( new MonitorForm ( pars.port , pars.autoStart , pars.mode , pars.source , pars.errorMessage ) ) ;
		}
	}
}