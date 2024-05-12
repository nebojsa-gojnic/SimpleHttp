using System ;
using System.Windows.Forms ;


namespace SimpleHttp
{
	/// <summary>
	/// TextBox with better ctrl+arrow keyboard control(it does better positioning)
	/// </summary>
	public class CodeTextBox:TextBox
	{
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
		protected bool leftToRightSelection 
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
			else 
			{
				if ( _leftToRightSelection )
				{
					if ( e.Shift )
					{
						if ( SelectionLength > 0 )
						{
							SelectionLength-- ;
							_leftToRightSelection = false ;
						}
						else if ( SelectionStart > 0 ) 
						{
							SelectionStart-- ;
							SelectionLength = 1 ;
							_leftToRightSelection = false ;
						}
					}
					else if ( SelectionLength == 0 )
					{
						if ( SelectionStart > 0 ) SelectionStart-- ;
					}
					else SelectionLength = 0 ;
				}
				else 
				{
					if ( e.Shift )
					{
						if ( SelectionStart > 0 )
						{
							len = SelectionLength ;
							SelectionStart-- ;
							SelectionLength = len + 1 ;
						}
					}
					else if ( SelectionLength == 0 ) 
					{
						if ( SelectionStart > 0 ) SelectionStart-- ; 
					}
					else SelectionLength = 0 ;
				}
			}
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
			else
			{
				if ( leftToRightSelection )
				{
					if ( e.Shift )
					{
						if ( SelectionStart + SelectionLength < TextLength )
							SelectionLength++ ;
					}
					else if ( SelectionLength == 0 )
					{
						if ( SelectionStart < TextLength ) SelectionStart++ ;
					}
					else SelectionLength = 0 ;
				}
				else 
				{
					if ( e.Shift )
					{
						if ( SelectionLength == 0 )
						{
							if ( SelectionStart > 0 )
							{
								len = SelectionLength ;
								SelectionStart-- ;
								SelectionLength = len + 1 ;
							}
						}
					}
					else if ( SelectionLength == 0 ) 
					{
						if ( SelectionStart > 0 ) SelectionStart-- ; 
					}
					else SelectionLength = 0 ;
				}
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
			base.OnKeyDown ( e ) ;
			OnHorizontalArrows ( e ) ;
		}
	}
}
