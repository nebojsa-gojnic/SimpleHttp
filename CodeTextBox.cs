using System ;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Windows.Forms ;


namespace SimpleHttp
{
	/// <summary>
	/// TextBox with better ctrl+arrow keyboard control(it does better positioning)
	/// and no flickering(fuck you Microsoft)
	/// </summary>
	public class CodeTextBox:TextBox
	{
		/// <summary>
		/// Auxiliary vairable for the doubleClickX property
		/// </summary>
		private static int _doubleClickX ;
		/// <summary>
		/// Maximal horizontal distance for double click<br/>
		/// more then that does not raise the event
		/// </summary>
		public static int doubleClickX 
		{
			get => _doubleClickX ;
		}
		/// <summary>
		/// Auxiliary vairable for the doubleClickY property
		/// </summary>
		private static int _doubleClickY ;
		/// <summary>
		/// Maximal vertical distance for double click<br/>
		/// more then that does not raise the event
		/// </summary>
		public static int doubleClickY 
		{
			get => _doubleClickY ;
		}
		/// <summary>
		/// Auxiliary vairable for the _doubleClickTime property
		/// </summary>
		private static int _doubleClickTime ;
		/// <summary>
		/// Double click time in milliseconds
		/// </summary>
		public static int doubleClickTime 
		{
			get => _doubleClickTime ;
		}
		/// <summary>
		/// Read and set values to doubleClickX, doubleClickY and doubleClickTime.
		/// </summary>
		public static void readDoubleClickSettingsFromOS ()
		{
			_doubleClickX = API.GetSystemMetrics ( API.SystemMetrics.CXDOUBLECLK ) ;
			_doubleClickY = API.GetSystemMetrics ( API.SystemMetrics.CYDOUBLECLK ) ;
			_doubleClickTime = API.GetDoubleClickTime () ;
		}
		/// <summary>
		/// Static construcor. It calls readDoubleClickSettingsFromOS() method in order to read and set values to doubleClickX, doubleClickY and doubleClickTime.
		/// </summary>
		static CodeTextBox ()
		{
			readDoubleClickSettingsFromOS () ;
		}
		/// <summary>
		/// We need this for manual paint
		/// </summary>
		protected API.PaintStruct paintStruct ;
		/// <summary>
		/// We need this to find left top corner of the client area 
		/// </summary>
		protected API.APIPoint clientPoint ;
		/// <summary>
		/// We need this to find left top corner of the client area 
		/// </summary>
		protected API.APIRect windowRect  ;
		/// <summary>
		/// SelectionStart value preour to KeyDown event<br/?
		/// We need this to maintain  text selection direction(leftToRightSelection property)
		/// </summary>
		protected int selectionStartPreKeyDown ; 
		/// <summary>
		/// Sum of SelectionStart and SelectionLength values preour to KeyDown event<br/?
		/// We need this to maintain text selection direction(leftToRightSelection property)
		/// </summary>
		protected int selectionEndPreKeyDown ;
		/// <summary>
		/// Ah
		/// </summary>
		protected Bitmap paintBuffer ;
		/// <summary>
		/// Creates new instance od the CodeTextBox class
		/// </summary>
		public CodeTextBox ():base()
		{
			paintBuffer = null ;
			clientPoint = new API.APIPoint () ;
			clientPoint.x = 0 ;
			clientPoint.y = 0 ;
			windowRect = new API.APIRect () ;
			//SetStyle ( ControlStyles.AllPaintingInWmPaint , true ) ;
			//SetStyle ( ControlStyles.UserPaint , true ) ;
			SetStyle ( ControlStyles.OptimizedDoubleBuffer , false) ;
			paintStruct = new API.PaintStruct () ;
			paintStruct.fErase = false ;
			paintStruct.rcPaint = new API.APIRect () ;
			paintStruct.rcPaint.Left = 0 ;
			paintStruct.rcPaint.Top = 0 ;
			 _mouseDownThickCount = Environment.TickCount ;
			_mouseIsDown = false ;
			//SetStyle ( ControlStyles.AllPaintingInWmPaint , true ) ;
			//SetStyle ( ControlStyles.UserPaint , true ) ;
			//SetStyle ( ControlStyles.Opaque , false ) ;
			//SetStyle ( ControlStyles.SupportsTransparentBackColor , true ) ;
		}
		/// <summary>
		/// Auxiliary variable for the mouseIsDown property
		/// </summary>
		protected bool _mouseIsDown ;
		/// <summary>
		/// True when mouse is down/pressed on this control
		/// </summary>
		protected bool mouseIsDown 
		{
			get => _mouseIsDown ;
		}
		/// <summary>
		/// Auxiliary variable for the mouseDownThickCount property
		/// </summary>
		protected int _mouseDownThickCount ;
		/// <summary>
		/// Value of the SelectionThickCount property when mouse was down on control
		/// </summary>
		protected int mouseDownThickCount 
		{
			get => _mouseDownThickCount ;
		}
		/// <summary>
		/// Auxiliary variable for the mouseDownPosition 
		/// </summary>
		protected Point _mouseDownPosition ;
		/// <summary>
		/// Realtive mouse coordinates last time when mouse was down
		/// </summary>
		protected Point mouseDownPosition 
		{
			get => _mouseDownPosition  ;
		}
		/// <summary>
		/// Auxiliary variable for the mouseDownSelectionStart property
		/// </summary>
		protected int _mouseDownSelectionStart ;
		/// <summary>
		/// Value of the SelectionStart property when mouse was down on control
		/// </summary>
		protected int mouseDownSelectionStart 
		{
			get => _mouseDownSelectionStart ;
		}
		/// <summary>
		/// Auxiliary variable for the mouseDownSelectionLength property
		/// </summary>
		protected int _mouseDownSelectionLength ;
		/// <summary>
		/// Value of the SelectionLength property when mouse was down on control
		/// </summary>
		protected int mouseDownSelectionLength 
		{
			get => _mouseDownSelectionLength ;
		}
		/// <summary>
		/// Auxiliary variable for the leftToRightSelection property
		/// </summary>
		protected bool _leftToRightSelection ;
		/// <summary>
		/// Value of this property is true when actual selection end holds caret (selection start index is lower then selection end index)
		/// </summary>
		public bool leftToRightSelection 
		{
			get => _leftToRightSelection ;
		}
		/// <summary>
		/// Get method the caretIndex property
		/// </summary>
		/// <returns>Returns caret character position</returns>
		protected int getCaretIndex ()
		{
			return _leftToRightSelection ? SelectionStart + SelectionLength : SelectionStart ;
		}
		/// <summary>
		/// This method set value for the mouseDownSelectionStart property before it calls base method in order to raise MouseDownEvent.
		/// </summary>
		/// <param name="e">(MouseEventArgs)</param>
		protected override void OnMouseDown ( MouseEventArgs e )
		{
			_mouseIsDown = true ;
			System.Diagnostics.Debug.WriteLine ( "Mouse is down" ) ;
			System.Diagnostics.Debug.WriteLine ( e.X.ToString () + " , " + e.Y.ToString () ) ;
			int newTick = Environment.TickCount ;
			unsafe
			{
				//System.Diagnostics.Debug.WriteLine ( newTick - _mouseDownThickCount ) ;
				//System.Diagnostics.Debug.WriteLine ( doubleClickTime ) ;
				//System.Diagnostics.Debug.WriteLine ( ( newTick - _mouseDownThickCount ) <= doubleClickTime ) ;
				//System.Diagnostics.Debug.WriteLine ( doubleClickX )
				//System.Diagnostics.Debug.WriteLine ( doubleClickY <= Math.Abs ( _mouseDownPosition .Y - e.Location.Y ) ) ;
				System.Diagnostics.Debug.WriteLine ( doubleClickY.ToString () + " , " + Math.Abs ( _mouseDownPosition .Y - e.Location.Y ).ToString () ) ;
				if ( ( ( newTick - _mouseDownThickCount ) <= doubleClickTime ) &&
					 ( doubleClickX >= Math.Abs ( mouseDownPosition.X - e.Location.X ) ) &&
						 ( doubleClickY >= Math.Abs ( mouseDownPosition.Y - e.Location.Y ) ) )
				{
					selectWordFromPosition ( _mouseDownSelectionStart ) ;
					_mouseDownSelectionStart = SelectionStart ;
					_mouseDownSelectionLength = SelectionLength ;
					_mouseDownThickCount = newTick - 10000 ;			//  ha!!!!!!!!!
				}  
				else 
				{
					_mouseDownSelectionStart = SelectionStart ;
					_mouseDownSelectionLength = SelectionLength ;
					_leftToRightSelection = true ;
					_mouseDownThickCount = newTick ;
				}
				_mouseDownPosition = e.Location ;
			}
			base.OnMouseDown ( e ) ;
		}
		/// <summary>
		/// This method set value for the leftToRightSelection property before it calls base method in order to raise MouseUpEvent.
		/// </summary>
		/// <param name="e">(MouseEventArgs)</param>
		protected override void OnMouseUp ( MouseEventArgs e )
		{
			_leftToRightSelection = _mouseDownSelectionStart == SelectionStart ;
			_mouseIsDown = false ;
			System.Diagnostics.Debug.WriteLine ( "Mouse is up" ) ;
			base.OnMouseUp ( e ) ;
		}
		/// <summary>
		/// For the auto selection on doubleclick
		/// </summary>
		public enum SelectionContentType
		{
			nothing = 0 ,
			space = 1 ,
			symbol = 2 ,
			charOrDiggit = 3 ,
		}
		/// <summary>
		/// Auto selection method(for doubleclick),
		/// what a chore
		/// </summary>
		/// <param name="position">Current curet position</param>
		protected void selectWordFromPosition ( int position )
		{
			int length = Text.Length ;
			//	end of line or end of text
			SelectionContentType rightType = length > position ? SelectionContentType.symbol : SelectionContentType.nothing ;
			int rightPosition = length -1 ;						// ha!
			if ( rightType != SelectionContentType.nothing )
				switch ( Text [ position ] )
				{
					case '\r' :
					case '\n' :
						rightType = SelectionContentType.nothing ;
					break ;
					case '\t' :
					case '\u00A2' :												//	non-breakable space
					case ' ' :				
						rightType = SelectionContentType.space ;
						for ( int i = position ; i < length ; i++ )				//	searching for the space end(SF?)
							switch ( Text [ i ] )
							{
								case '\r' :
								case '\n' :
									rightPosition = i - 1 ;   
									i = length ;								//	break the for loop
								break ;
								case '\t' :
								case '\u00A2' :									//	non-breakable space
								case ' ' :										//	keep on rolling
								break ;
								default :										//	we found the first non-space character
									rightPosition = i - 1 ;   
									i = length ;								//	break the for loop
								break ;
							}
					break ;
					default :													//	not a space or end of line
						if ( char.IsLetterOrDigit ( Text [ position ] ) )
						{
							rightType = SelectionContentType.charOrDiggit ;
							for ( int i = position ; i < length ; i++ )			//	searching for the neighter char or diggit (SF?)
								if ( !char.IsLetterOrDigit ( Text [ i ] ) ) 
								{
										rightPosition = i - 1 ;   
										i = length ;							//	break the for loop
								}
						}
						else 
						{
							rightType = SelectionContentType.symbol ;
							for ( int i = position ; i < length ; i++ )			//	searching for the end of "other" sequence
								switch ( Text [ i ] )
								{
									case '\r' :
									case '\n' :
										rightPosition = i - 1 ;   
										i = length ;							//	break the for loop
									break ;
									case '\t' :
									case '\u00A2' :								//	non-breakable space
									case ' ' :									//	keep on rolling
										rightPosition = i - 1 ;   
										i = length ;							//	break the for loop
									break ;
									default :									//	we found the first non-space character
										if ( char.IsLetterOrDigit ( Text [ i ] ) ) 
										{
											rightPosition = i - 1 ;				//	break the for loop
											i = length ;							
										}
									break ;
								}
						}
					break ;
				}
			int leftPosition = position - 1 ;
			SelectionContentType leftType = leftPosition >= 0 ? SelectionContentType.symbol : SelectionContentType.nothing ;
			if ( leftType != SelectionContentType.nothing  )					//  selection is not at the begin, left part is not empty
				switch ( Text [ leftPosition ] )
				{
					case '\r' :
					case '\n' :
						leftType = SelectionContentType.nothing ;
					break ;
					case '\t' :
					case '\u00A2' :												//	non-breakable space
					case ' ' :				
						leftType = SelectionContentType.space ;
						for ( int i = leftPosition ; i >= 0 ; i-- )					//	searching for the space start(SF?)
							switch ( Text [ i ] )
							{
								case '\r' :
								case '\n' :
									leftPosition = i + 1 ;   
									i = -1 ;									//	break the for loop
								break ;
								case '\t' :
								case '\u00A2' :									//	non-breakable space
								case ' ' :										//	keep on rolling
								break ;
								default :										//	we found the first non-space character
									leftPosition = i + 1 ;   
									i = -1 ;									//	break the for loop
								break ;
							}
					break ;
					default :													//	not a space or end of line
						if ( char.IsLetterOrDigit ( Text [ leftPosition ] ) )
						{
							leftType = SelectionContentType.charOrDiggit ;
							for ( int i = leftPosition ; i >= 0 ; i-- )				//	searching for the non char or diggit (SF?)
								if ( !char.IsLetterOrDigit ( Text [ i ] ) ) 
								{
									leftPosition = i + 1 ;   
									i = -1 ;									//	break the for loop
								}
						}
						else 
						{
							leftType = SelectionContentType.symbol ;
							for ( int i = leftPosition ; i >= 0 ; i-- )			//	searching for the end of "other" sequence
								switch ( Text [ i ] )
								{
									case '\r' :
									case '\n' :
									case '\t' :
									case '\u00A2' :								//	non-breakable space
									case ' ' :									//	keep on rolling
										leftPosition = i ;      
										i = -1 ;								//	break the for loop
									break ;
									default :									//	we found the first non-space character
										if ( char.IsLetterOrDigit ( Text [ i ] ) ) 
										{
											leftPosition = i + 1 ;      
											i = -1 ;								//	break the for loop
										}
									break ;
								}
						}
					break ;
				}

			if ( rightType == SelectionContentType.nothing )
			{
				if ( leftType == SelectionContentType.nothing )
				{

					if ( ( position >= 0 ) && ( position < length ) )
					{
						SelectionStart = position ;
						SelectionLength = 0 ;
					}
				}
				else
				{
					SelectionStart = leftPosition ;
					SelectionLength = position - leftPosition + 1 ;
				}
					
			}
			else if ( leftType == SelectionContentType.nothing )
			{
				SelectionStart = position ;
				SelectionLength = rightPosition - position + 1 ;
			}
			else if ( leftType == rightType )
			{
				SelectionStart = leftPosition ;
				SelectionLength = rightPosition - leftPosition + 1 ;
			}
			else if ( leftType < rightType )
			{
				SelectionStart = position ;
				SelectionLength = rightPosition - position + 1 ;
			}
			else 
			{
				SelectionStart = leftPosition ;
				SelectionLength = position - leftPosition  ;
			}
		}
		/// <summary>
		/// This method (re)set value of the mouseDownThickCount property and raises Enter event.
		/// </summary>
		/// <param name="e">(EventArgs)</param>
		protected override void OnEnter ( EventArgs e )
		{
			unsafe
			{
				_mouseDownThickCount =  Environment.TickCount - 100000 ;
			}
			base.OnEnter ( e) ;
		}
		protected void handleLeftArrow ( KeyEventArgs e )
		{
			int position ;
			int len ;
			e.Handled = true ;
			if ( e.Control )
			{
				if ( leftToRightSelection )
				{
					position = SelectionStart + SelectionLength ;
					if ( nextWordLeft ( Text , ref position ) )
					{
						if ( e.Shift )
						{
							if ( position < SelectionStart )
							{
								len = SelectionStart - position ;
								SelectionStart = position ;
								SelectionLength = len ;
								_leftToRightSelection = false ;
							}
							else SelectionLength = position - SelectionStart ;
						}
						else 
						{
							SelectionStart = position ;
							SelectionLength = 0 ;
							_leftToRightSelection = false ;
						}
					}
				}
				else 
				{
					position = SelectionStart ;
					if ( nextWordLeft ( Text , ref position ) )
					{
						if ( e.Shift )
						{
							len = SelectionLength - position + SelectionStart ;
							SelectionStart = position ;
							SelectionLength = len ;
						}
						else 
						{
							SelectionStart = position ;
							SelectionLength = 0 ;
						}
					}
				}
			}
			else if ( e.Shift )
			{
				if ( ( SelectionLength == 0 ) || !_leftToRightSelection )
				{
					if ( SelectionStart == 0 )
						_leftToRightSelection = true ;
					else 
					{
						len = SelectionLength ;
						SelectionStart-- ;
						SelectionLength = len + 1 ;
						_leftToRightSelection = false ;
					}
				}
				else SelectionLength-- ;
			}
			else if ( SelectionLength == 0 ) 
			{
				if ( SelectionStart > 0 ) SelectionStart-- ; 
			}
			else SelectionLength = 0 ;
		}
		protected void handleRightArrow ( KeyEventArgs e )
		{
			int position ;
			int len ;
			e.Handled = true ;
			if ( e.Control )
			{
				if ( leftToRightSelection )
				{
					position = SelectionStart + SelectionLength ;
					if ( nextWordRight ( Text , ref position ) )
					{
						if ( e.Shift )
							SelectionLength = position - SelectionStart ;
						else 
						{
							SelectionStart = position ;
							SelectionLength = 0 ;
						}
					}
				}
				else
				{
					position = SelectionStart ;
					if ( nextWordRight ( Text , ref position ) )
					{
						if ( e.Shift )
						{
							if ( position > SelectionStart + SelectionLength )
							{
								len = position - SelectionStart - SelectionLength ;
								SelectionStart = SelectionStart + SelectionLength ;
								SelectionLength = len ;
								_leftToRightSelection = true ;
							}
							else 
							{
								len = SelectionLength - position + SelectionStart ;
								SelectionStart = position ;
								SelectionLength = len ;
							}
						}
						else 
						{
							SelectionStart = position ;
							SelectionLength = 0 ;
						}
					}
				}
			}
			else if ( e.Shift )
			{
				if ( SelectionLength == 0 ) 
				{
					_leftToRightSelection = true ;
					if ( SelectionStart < TextLength ) SelectionLength = 1 ;
				}
				else if ( !leftToRightSelection )
				{
					len = SelectionLength ;
					SelectionStart++ ;
					SelectionLength = len -1 ;
				}
				else  if ( SelectionStart + SelectionLength < TextLength ) 
					SelectionLength++ ;
			}
			else if ( SelectionLength == 0 )
			{
				if ( SelectionStart < TextLength ) SelectionStart++ ;
			}
			else if ( !leftToRightSelection )
			{
				SelectionLength = 0 ;
			}
			else 
			{
				_leftToRightSelection = true ;
				len = SelectionLength + SelectionStart ;
				SelectionLength = 0 ;
				SelectionStart = len ;
			}
		}
		public bool nextWordLeft ( string text , ref int selectionStart )
		{
			if ( selectionStart <= 0 ) return false ;
			int i ;
			int l = text.Length ;
				
			if ( selectionStart == 1 )
			{
				selectionStart = 0 ;
				return true ;
			}
			if ( char.IsLetterOrDigit ( text [ selectionStart - 1 ] ) )
			{
				for ( i = selectionStart - 2 ; i >= 0 ; i-- )
					if ( !char.IsLetterOrDigit ( text [ i ] ) )
					{
						selectionStart = i + 1  ;
						return true ;
					}
			}
			else 
			{
				for ( i = selectionStart - 2 ; i >= 0 ; i-- )
					if ( char.IsLetterOrDigit ( text [ i ] ) )
					{
						selectionStart = i + 1 ;
						return true ;
					}
			}
			selectionStart = 0 ;
			return true ;
		}
		public bool nextWordRight ( string text , ref int selectionStart )
		{
			int l = text.Length ;
			if ( selectionStart < l )
			{
				if ( selectionStart <= l - 1 ) 
				{
					int i ;
					if ( char.IsLetterOrDigit ( text [ selectionStart ] ) )
					{
						for ( i = selectionStart + 1 ; i < l ; i++ )
							if ( !char.IsLetterOrDigit ( text [ i ] ) )
							{
								selectionStart = i ;
								return true ;
							}
					}
					else 
					{
						for ( i = selectionStart + 1 ; i < l ; i++ )
							if ( char.IsLetterOrDigit ( text [ i ] ) )
							{
								selectionStart = i ;
								return true ;
							}
					
					}
				}
				selectionStart = l ;
				return true ;
			}
			return false ;
		}
		/// <summary>
		/// This method is called from OnKeyDown() if e.Handled is false after call to base.OnKeyDown() 
		/// </summary>
		/// <param name="e">(KeyEventArgs)</param>
		protected virtual void OnHorizontalArrows ( KeyEventArgs e )
		{
			if ( e.Handled ) return ;

			switch ( e.KeyCode )
			{
				case Keys.Left :
					handleLeftArrow ( e ) ;
				break ;
				case Keys.Right :
					handleRightArrow ( e ) ;
				break ;
			}
		}
		/// <summary>
		/// This method raises KeyDown event and if e.Handled is false
		/// it calls OnHorizontalArrows() method 
		/// </summary>
		/// <param name="e">(KeyEventArgs)</param>
		protected override void OnKeyDown ( KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.ShiftKey ) return ; //for debug
			selectionStartPreKeyDown = SelectionStart ;
			selectionEndPreKeyDown = SelectionStart + SelectionLength ;
			base.OnKeyDown ( e ) ;
			if ( e.Handled ) return ;
			OnHorizontalArrows ( e ) ;
		}
		protected override void OnKeyUp ( KeyEventArgs e )
		{
			//if ( e.KeyCode == Keys.ShiftKey ) return ; //for debug
			if ( !e.Control ) //We need this for up/down arrows
			{
				_leftToRightSelection = SelectionStart == selectionStartPreKeyDown || selectionEndPreKeyDown < SelectionStart + SelectionLength ;
			}
			base.OnKeyUp ( e ) ;
		}
		protected bool inPaint ;

		//[DebuggerStepThroughAttribute]
		protected override void WndProc ( ref Message m )
		{
			switch ( m.Msg )
			{
				case WindowMessage.WM_LButtonDown :
					m.Msg = WindowMessage.WM_LButtonDown ;
				break ;
				case WindowMessage.WM_LButtonDblClk :
					// m.Msg = WindowMessage.WM_LButtonDown ;
					// This is supposed to work but it does not
					// whoever made .net System.Windows.Forms was a retartd

					// so we do it manualy instead
					int i = m.LParam.ToInt32 () ;
					OnMouseDown ( new MouseEventArgs ( MouseButtons.Left , 2 , i & 0xFFFF , i >> 16 , 0 ) ) ;
				return ;
				case WindowMessage.WM_EraseBackground :
					m.Result = new IntPtr ( 1 ) ;
					return ;
				case WindowMessage.WM_Paint :
					if ( inPaint || _mouseIsDown )
						break ;
					else 
					{
						inPaint = true ;
						
						PaintCore () ;

						inPaint = false ;
						m.Result = IntPtr.Zero ;
						return ;
					}
			}
			base.WndProc ( ref m )  ;
		}
		protected virtual void PaintCore ()
		{
			if ( paintBuffer == null )
				paintBuffer = new Bitmap ( Width , Height ) ;
			else if ( ( paintBuffer.Width != Width ) || ( paintBuffer.Height != Height ) )
			{
				paintBuffer.Dispose () ;
				paintBuffer = new Bitmap ( Width , Height ) ;
			}
			int scrTop = API.GetScrollPos ( Handle , API.ScrollBarDirection.SB_VERT ) ;
			DrawToBitmap ( paintBuffer , new Rectangle ( Point.Empty , Size ) ) ; //sendig message from message and wainting on result, @#@!!!

			IntPtr hdc = API.BeginPaint ( Handle , ref paintStruct ) ;
			//	this how we get sceen coordinates,
			//	why screen coordinates?
			//	well, we just need coordinates is same co. system to find difference,
			//	and thats how its down in Windows
			clientPoint.x = 0 ;
			clientPoint.y = 0 ;
			API.ClientToScreen ( Handle , ref clientPoint ) ;
			API.GetWindowRect ( Handle , ref windowRect ) ;
			Graphics graphics = Graphics.FromHdc ( hdc ) ;
			graphics.DrawImageUnscaled ( paintBuffer , new Point ( windowRect.Left - clientPoint.x , windowRect.Top - clientPoint.y ) ) ;

			base.OnPaint ( new PaintEventArgs ( graphics , new Rectangle ( ( int ) graphics.ClipBounds.Left , ( int ) graphics.ClipBounds.Top , ( int ) graphics.ClipBounds.Width , ( int ) graphics.ClipBounds.Height ) ) ) ;
			//_Paint?.Invoke ( this , new PaintEventArgs ( graphics , new Rectangle ( ( int ) graphics.ClipBounds.Left , ( int ) graphics.ClipBounds.Top , ( int ) graphics.ClipBounds.Width , ( int ) graphics.ClipBounds.Height ) ) ) ;
			
			//System.Diagnostics.Debug.WriteLine ( string.Concat ( "location: " , windowRect.Left , " ,    client: " , clientPoint.x , "    delta: " , windowRect.Left - clientPoint.x ) ) ;

			API.ShowCaret ( Handle ) ;
			API.EndPaint ( hdc , ref paintStruct ) ;
			graphics.Dispose () ;
		}
		protected override void Dispose ( bool disposing )
		{
			paintBuffer?.Dispose () ;
			paintBuffer = null ;
			base.Dispose ( disposing )  ;
		}
	}
	
		 
}
