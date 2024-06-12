using System ;
using System.ComponentModel;
using System.Diagnostics;
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
		/// We need this for maunal paint
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
			//SetStyle ( ControlStyles.AllPaintingInWmPaint , true ) ;
			//SetStyle ( ControlStyles.UserPaint , true ) ;
			//SetStyle ( ControlStyles.Opaque , false ) ;
			//SetStyle ( ControlStyles.SupportsTransparentBackColor , true ) ;
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
			_mouseDownSelectionStart = SelectionStart ;
			base.OnMouseDown ( e ) ;
		}
		/// <summary>
		/// This method set value for the leftToRightSelection property before it calls base method in order to raise MouseUpEvent.
		/// </summary>
		/// <param name="e">(MouseEventArgs)</param>
		protected override void OnMouseUp ( MouseEventArgs e )
		{
			_leftToRightSelection = _mouseDownSelectionStart == SelectionStart ;
			base.OnMouseUp ( e ) ;
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

		protected bool sc ;
		[DebuggerStepThroughAttribute]
		protected override void WndProc ( ref Message m )
		{
			switch ( m.Msg )
			{
				case WindowMessage.WM_EraseBackground :
					m.Result = new IntPtr ( 1 ) ;
					return ;
				case WindowMessage.WM_Paint :
					if ( inPaint )
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
