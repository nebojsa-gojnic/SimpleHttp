using System ;
using System.IO ;
using System.IO.Pipes ;
using System.Text ;
using System.Diagnostics ;
using System.Security.Authentication ;
using Newtonsoft.Json.Linq ;
using Newtonsoft.Json ;
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
			//{
			//	//SimpleHttp.MonitorForm.PipeManiaHttpService sr = new MonitorForm.PipeManiaHttpService () ;
			//	//string name =  sr.GetType().AssemblyQualifiedName ;
			//	Type tp = System.Type.GetType ( "SimpleHttp.MonitorForm+PipeManiaHttpService" , true , true ) ;
			//	WebSockets.WebServerConfigData wb = new WebSockets.WebServerConfigData () ;
			//	string ds = "{ 'services':[ { 'name':'act1' , 'source':'SimpleHttp.MonitorForm+PipeManiaHttpService,SimpleHttp' } , 2 , '2' , [ 1 , 2 , 3 ] ] , 'paths':[ { 'path':'/*' , 'service':'act1' } ] } " ;
			//	wb.loadFromJSON ( JsonConvert.DeserializeObject <JObject> ( ds ) ) ;
			//}

			//MonitorForm.PipeManiaHttpService.PipeManiaHttpServiceData data = new MonitorForm.PipeManiaHttpService.PipeManiaHttpServiceData (  ) ;
			//data.loadFromJSON ( "{ \"saveFolder\":\"c:\\filder\",\"kata\":1}") ;
			//string s ;
			//data.saveToJSON ( out s ) ;
			//data.loadFromJSON ( s ) ;
			//WebSockets.ResourcesHttpService.ResourcesHttpServiceData da2 = new WebSockets.ResourcesHttpService.ResourcesHttpServiceData ( ) ;
			//da2.loadFromJSON ( "{ \"assemblyPath\":\"PipeMania.dll\" }" ) ;
			//da2.saveToJSON ( out s ) ;
			//da2.loadFromJSON ( s ) ;
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
			Application.SetCompatibleTextRenderingDefault ( true ) ;
			//Form form = new Form () ;
			//CodeTextBox textBox = new CodeTextBox () ;
			//textBox.Dock = DockStyle.Fill ;
			//textBox.Multiline = true ;
			//textBox.ScrollBars = ScrollBars.Vertical ;
			//form.Controls.Add ( textBox ) ;
			//TextBox textBox2 = new TextBox () ;
			//textBox2.Dock = DockStyle.Top ;
			//form.Controls.Add ( textBox2 ) ;
			//textBox.KeyDown += ( object? sender , KeyEventArgs e ) =>
			//	{ 
			//		textBox2.Text = textBox.leftToRightSelection ? "->" : "<-" ;
			//	} ;
			//textBox.KeyUp += ( object? sender , KeyEventArgs e ) =>
			//	{ 
			//		textBox2.Text = textBox.leftToRightSelection ? "->" : "<-" ;
			//	} ;

			//Application.Run ( form ) ;
			Application.Run ( new MonitorForm ( new HttpStartParameters ( args ) ) ) ;
			//Application.Run ( new Form1 ( )  ) ;
		}


	}
}