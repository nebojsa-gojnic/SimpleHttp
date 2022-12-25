using System ;
using System.IO ;
using System.IO.Pipes ;
using System.Text ;
using System.Diagnostics ;
using System.Security.Authentication ;
namespace SimpleHttp
{
	public static class Program
	{
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
			Application.SetCompatibleTextRenderingDefault ( false ) ;
			Application.Run ( new MonitorForm ( new HttpStartParameters ( args ) ) ) ;
		}
	}
}