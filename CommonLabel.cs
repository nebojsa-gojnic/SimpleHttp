using System ;
using System.ComponentModel ;
using System.Windows.Forms ;
using System.Diagnostics ;
namespace SimpleHttp
{
	public class CommonLabel : System.Windows.Forms.Label 
	{
		static readonly IntPtr HTCAPTION = new IntPtr ( 2 ) ;  
		protected bool MyAutoDragForm = true ;
		[ Browsable ( true ) ]
		[ DefaultValue ( true ) ]
		public bool AutoDragForm 
		{
			get { return MyAutoDragForm ; }
			set { MyAutoDragForm = value ; } 
		}
        [DebuggerStepThrough]
		protected override void WndProc ( ref Message m )
		{	
			if ( MyAutoDragForm && !DesignMode  )
				if ( m.Msg == WindowMessage.WM_LButtonDown ) 
				{
					//base.WndProc ( ref m ) ;
                    API.SendMessageA ( TopLevelControl.Handle , WindowMessage.WM_NCLButtonDown , HTCAPTION , m.LParam ) ; 
					return ;
				}
			base.WndProc ( ref m ) ;
		}
	}
}
