using System ;
using System.Collections.Generic ;
using System.Windows.Forms ;
using System.Text ;

namespace SimpleHttp
{
	public class CommonCheckBox:CheckBox
	{
		protected override bool ShowFocusCues => false ;
		protected override bool ShowKeyboardCues => false ;
	}
}
