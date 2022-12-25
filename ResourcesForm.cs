using System ;
using System.Drawing ;
using System.Drawing.Drawing2D ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Reflection ;
using System.Text ;
using System.Net.Http ;
using System.Windows.Forms ;
using WebSockets ;

namespace SimpleHttp
{
	/// <summary>
	/// Resource viewer
	/// </summary>
	public partial class ResourcesForm : Form
	{
		protected SolidBrush normalBackBrush ;
		protected SolidBrush normalInkBrush ;
		protected SolidBrush alternateBackBrush ;
		protected SolidBrush alternateInkBrush ;
		protected SolidBrush selectedBackBrush ;
		protected SolidBrush selectedInkBrush ;
		protected SolidBrush searchBackBrush ;
		protected SolidBrush searchInkBrush ;
		/// <summary>
		/// Starting character position in selected item
		/// </summary>
		protected int searchPosition ;
		// <summary>
		/// Selected string length on selected list index text
		/// </summary>
		protected int searchLength ;
		protected int mouseDownSelectionStart ;
		/// <summary>
		/// This is true when selection start is really(!) smaller then selection end.
		/// <br/>I don't know how to read caret text position(not a screen position)
		/// </summary>
		protected bool leftToRightSelection ;

		//protected int mouseDownSelectionStart ;
		public ResourcesForm():this ( null )
		{
		}
		public ResourcesForm ( Assembly resourceAssembly )
		{
			InitializeComponent() ;
			normalBackBrush = new SolidBrush ( SystemColors.Window ) ;
			normalInkBrush = new SolidBrush ( SystemColors.WindowText ) ;
			alternateBackBrush = new SolidBrush ( SystemColors.Control ) ;
			alternateInkBrush = new SolidBrush ( SystemColors.ControlText ) ;
			selectedBackBrush = new SolidBrush ( MonitorForm.mixColors ( SystemColors.Highlight , SystemColors.ControlDarkDark ) ) ;
			selectedInkBrush = new SolidBrush ( SystemColors.HighlightText ) ;
			searchBackBrush = new SolidBrush ( MonitorForm.mixColors ( SystemColors.Highlight , SystemColors.ControlLight ) ) ;
			//searchInkBrush = new SolidBrush ( SystemColors.HighlightText ) ;
			searchInkBrush = new SolidBrush ( Color.Yellow ) ;
			this.resourceAssembly = resourceAssembly ;
		}
		/// <summary>
		/// Auxiliary variabel for the resourceAssembly property
		/// </summary>
		protected Assembly _resourceAssembly ;
		/// <summary>
		/// Set method for the resourceAssembly property
		/// </summary>
		/// <param name="value">New value for resourceAssembly property</param>
		protected void setresourceAssembly ( Assembly value )
		{
			if ( value == _resourceAssembly ) return ;
			lbAssemblyName.Text = ( _resourceAssembly = value ) == null ?  "<no assemlby>" : _resourceAssembly.GetName().FullName ;
			loadResources () ;
		}
		protected void loadResources ()
		{
			ListBox.ObjectCollection items = resourceList.Items ;
			resourceList.ItemHeight = getItemHeight () ;
			setPageCount () ;
			items.Clear () ;
			resourceList.Sorted = false ;
			if ( resourceAssembly != null ) 
			{
				items.AddRange ( resourceAssembly.GetManifestResourceNames () ) ;
				resourceList.Sorted = true ;
			}
		}
		/// <summary>
		/// Assembly to read resources from
		/// </summary>
		public Assembly resourceAssembly
		{
			get => _resourceAssembly ;
			set => setresourceAssembly ( value ) ;
		}
		protected override void OnShown ( EventArgs e )
		{
			setTextWidthHint ( null ) ;
			sizeTestLabel.Location = new Point ( -sizeTestLabel.Width , -sizeTestLabel.Height  ) ;
			resourceList.ItemHeight = getItemHeight () ;
			setPageCount () ;
			searchBox_Resize ( searchBox , e ) ;
			base.OnShown ( e ) ;
		}
		
		private void saveResource ( string resourceName , string fileName )
        {
			if ( resourceList.SelectedIndex == -1 ) return ;
			Stream resourceStream = null ;
			FileStream fileStream = null ;
			Exception ex = null ;
			try
			{
				fileStream = File.OpenWrite ( fileName ) ;
				resourceStream = resourceAssembly.GetManifestResourceStream ( resourceName ) ;
				resourceStream.CopyTo ( fileStream ) ;

			}
			catch ( Exception x )
			{
				ex = x ;
				 
			}
			try
			{ 
				if ( fileStream != null )
				{
					fileStream.Close () ;
					fileStream.Dispose () ;
				}
			}
			catch { }
			try
			{ 
				if ( resourceStream != null )
				{
					resourceStream.Close () ;
					resourceStream.Dispose () ;
				}
			}
			catch { }
			if ( ex != null ) _UIErrorRaised?.Invoke ( this , new ErrorEventArgs ( ex ) ) ;
		}
		/// <summary>
		/// Auxiliary variable for the _UIErrorRaised event
		/// </summary>
		protected EventHandler<ErrorEventArgs> _UIErrorRaised ;
		/// <summary>
		/// UI error/warning message
		/// </summary>
		public event EventHandler<ErrorEventArgs> UIErrorRaised 
		{
			add => _UIErrorRaised += value ;
			remove => _UIErrorRaised -= value ;
		}
		/// <summary>
		/// Aaa, there is always something to resuze
		/// </summary>
		/// <param name="sender">searchBox(TextBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void searchBox_Resize ( object sender , EventArgs e )
		{
			int p = searchBox.Height - ( searchLabel.Height - searchLabel.Padding.Vertical ) ;
			searchLabel.Padding = new Padding ( 0 , ( p + 1 ) >> 1 , 0 , p >> 1 ) ;
		}
		private void searchBox_KeyDown ( object sender , KeyEventArgs e )
		{
			int position ;
			int len ;
			switch ( e.KeyCode )
			{
				//case Keys.Delete :
				//	e.Handled = true ;
				//	if ( searchBox.SelectionLength == 0 )
				//		if ( searchBox.SelectionStart < searchBox.Text.Length )
				//			searchBox.SelectionStart ++ ;
				//		else return ;
				//	searchBox_KeyPress ( sender , new KeyPressEventArgs ( '\b' ) ) ; //backsapce
				//break ;
				case Keys.Enter :
					searchForNextItem ( searchBox.Text ) ;
					e.Handled = true ;
				break ;
				case Keys.L :
				{
					if ( e.Control )
					{
						e.Handled = true ;
						
					}
					break ;
				}
				case Keys.Left :
					handleLeftArrow ( e ) ;
				break ;
				case Keys.Right :
					handleRightArrow ( e ) ;
				break ;
				case Keys.Up :
					e.Handled = true ;
					if ( 0 != resourceList.Items.Count ) 
					{
						searchPosition = -1 ;
						searchLength = 0 ;
						resourceList.SelectedIndex = resourceList.SelectedIndex <= 0 ? 0 : resourceList.SelectedIndex - 1 ;
					}
				break ;
				case Keys.Down :
					e.Handled = true ;
					if ( ( resourceList.SelectedIndex < resourceList.Items.Count ) && ( 0 != resourceList.Items.Count ) )
					{
						searchPosition = -1 ;
						searchLength = 0 ;
						resourceList.SelectedIndex = resourceList.SelectedIndex == -1 ? 0 : resourceList.SelectedIndex + 1 ;
					}
				break ;
			}
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
					position = searchBox.SelectionStart + searchBox.SelectionLength ;
					if ( nextWordLeft ( searchBox.Text , ref position ) )
					{
						if ( e.Shift )
						{
							if ( position < searchBox.SelectionStart )
							{
								len = searchBox.SelectionStart - position ;
								searchBox.SelectionStart = position ;
								searchBox.SelectionLength = len ;
								leftToRightSelection = false ;
							}
							else searchBox.SelectionLength = position - searchBox.SelectionStart ;
						}
						else 
						{
							searchBox.SelectionStart = position ;
							searchBox.SelectionLength = 0 ;
							leftToRightSelection = false ;
						}
					}
				}
				else 
				{
					position = searchBox.SelectionStart ;
					if ( nextWordLeft ( searchBox.Text , ref position ) )
					{
						if ( e.Shift )
						{
							len = searchBox.SelectionLength - position + searchBox.SelectionStart ;
							searchBox.SelectionStart = position ;
							searchBox.SelectionLength = len ;
						}
						else 
						{
							searchBox.SelectionStart = position ;
							searchBox.SelectionLength = 0 ;
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
						if ( searchBox.SelectionLength > 0 )
						{
							searchBox.SelectionLength-- ;
							leftToRightSelection = false ;
						}
						else if ( searchBox.SelectionStart > 0 ) 
						{
							searchBox.SelectionStart-- ;
							searchBox.SelectionLength = 1 ;
							leftToRightSelection = false ;
						}
					}
					else if ( searchBox.SelectionLength == 0 )
					{
						if ( searchBox.SelectionStart > 0 ) searchBox.SelectionStart-- ;
					}
					else searchBox.SelectionLength = 0 ;
				}
				else 
				{
					if ( e.Shift )
					{
						if ( searchBox.SelectionStart > 0 )
						{
							len = searchBox.SelectionLength ;
							searchBox.SelectionStart-- ;
							searchBox.SelectionLength = len + 1 ;
						}
					}
					else if ( searchBox.SelectionLength == 0 ) 
					{
						if ( searchBox.SelectionStart > 0 ) searchBox.SelectionStart-- ; 
					}
					else searchBox.SelectionLength = 0 ;
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
					position = searchBox.SelectionStart + searchBox.SelectionLength ;
					if ( nextWordRight ( searchBox.Text , ref position ) )
					{
						if ( e.Shift )
							searchBox.SelectionLength = position - searchBox.SelectionStart ;
						else 
						{
							searchBox.SelectionStart = position ;
							searchBox.SelectionLength = 0 ;
						}
					}
				}
				else
				{
					position = searchBox.SelectionStart ;
					if ( nextWordRight ( searchBox.Text , ref position ) )
					{
						if ( e.Shift )
						{
							if ( position > searchBox.SelectionStart + searchBox.SelectionLength )
							{
								len = position - searchBox.SelectionStart - searchBox.SelectionLength ;
								searchBox.SelectionStart = searchBox.SelectionStart + searchBox.SelectionLength ;
								searchBox.SelectionLength = len ;
								leftToRightSelection = true ;
							}
							else 
							{
								len = searchBox.SelectionLength - position + searchBox.SelectionStart ;
								searchBox.SelectionStart = position ;
								searchBox.SelectionLength = len ;
							}
						}
						else 
						{
							searchBox.SelectionStart = position ;
							searchBox.SelectionLength = 0 ;
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
						if ( searchBox.SelectionStart + searchBox.SelectionLength < searchBox.TextLength )
							searchBox.SelectionLength++ ;
					}
					else if ( searchBox.SelectionLength == 0 )
					{
						if ( searchBox.SelectionStart < searchBox.TextLength ) searchBox.SelectionStart++ ;
					}
					else searchBox.SelectionLength = 0 ;
				}
				else 
				{
					if ( e.Shift )
					{
						if ( searchBox.SelectionLength == 0 )
						{
							if ( searchBox.SelectionStart > 0 )
							{
								len = searchBox.SelectionLength ;
								searchBox.SelectionStart-- ;
								searchBox.SelectionLength = len + 1 ;
							}
						}
					}
					else if ( searchBox.SelectionLength == 0 ) 
					{
						if ( searchBox.SelectionStart > 0 ) searchBox.SelectionStart-- ; 
					}
					else searchBox.SelectionLength = 0 ;
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

		protected bool noSearch ;
		private void searchBox_TextChanged ( object sender , EventArgs e )
		{
			if ( noSearch ) return ;
			searchForItem ( searchBox.Text ) ;
		}

		private void searchBox_KeyPress ( object sender , KeyPressEventArgs e )
		{
			//if ( e.KeyChar == '\u0016' ) return ;
			//if ( e.KeyChar == '\u0018' ) return ;
			//if ( e.KeyChar == '\u0003' ) return ;
			
			//e.Handled = true ; // this here not at the begin

			//if ( ( e.KeyChar == '<' ) || ( e.KeyChar == '>' ) ) return ;
			//string newText = searchBox.Text ;
			//int selectionStart = searchBox.SelectionStart ;
			//if ( e.KeyChar == '\r' ) 
			//{
			//	int i = searchForNextItem ( newText , ref searchPosition , ref searchLength ) ;
			//	if ( i == -1 )
			//		removeListTextSelection () ;
			//	else 
			//	{
			//		resourceList.SelectedIndex = i ; 
			//		resourceList.Invalidate () ;
			//	}
			//}
			//else 
			//{
			//	if ( e.KeyChar == '\b' ) 
			//	{
			//		if ( searchBox.SelectionLength == 0 ) 
			//		{
			//			if ( selectionStart > 0 ) newText = newText.Substring ( 0 , --selectionStart );
			//		}
			//		else if ( searchBox.SelectionStart + searchBox.SelectionLength == searchBox.Text.Length ) 
			//		{
			//			if ( searchBox.SelectionStart > 0 )
			//			{
			//				searchBox.SelectionStart-- ; 
			//				searchBox.SelectionLength = searchBox.Text.Length - searchBox.SelectionStart ;
			//			}
			//		}
			//	}
			//	else 
			//	{
			//		newText = ( selectionStart == 0 ? "" : newText.Substring ( 0 , selectionStart ) ) +
			//			( ( e.KeyChar == '\b' ?  "" : e.KeyChar ) + newText.Substring ( selectionStart + searchBox.SelectionLength ) ) ;
			//		selectionStart += ( e.KeyChar == '\b' ? 0 : 1 ) ;
			//	}
			//}
			//if ( newText != searchBox.Text )
			//{
			//	if ( newText == ""  )
			//	{
			//		searchBox.Text = "" ;
			//		return ;
			//	}
			//	int s = searchBox.SelectionStart ;
			//	int matchCount ;
			//	int charPosition ;
			//	int i = searchForItem ( newText , out charPosition , out matchCount ) ;
			//	if ( i == -1 )
			//	{
			//		removeListTextSelection () ;
			//		resourceList.Invalidate () ;
			//	}
			//	else 
			//	{
			//		resourceList.SelectedIndex = i ; 
			//		//searchBox.SelectionStart = matchCount ;
			//		//searchBox.SelectionLength = searchBox.Text.Length - matchCount ;
			//		if ( ( searchPosition != charPosition ) || ( searchLength != matchCount ) )
			//		{
			//			searchPosition = charPosition ;
			//			searchLength = matchCount ;
			//			resourceList.Invalidate () ;
			//		}
			//	}
			//	//searchBox.Text = newText ;
			//	int ss = searchBox.SelectionStart ;
			//	searchBox.Text = newText ;
			//	searchBox.SelectionStart = ss + 1 ;
			//	searchBox.SelectionLength = 0 ;
			//}
		}
		protected void removeListTextSelection ()
		{
			if ( searchPosition >= 0 )
			{
				searchPosition = -1 ;
				resourceList.Invalidate () ;
			}
			if ( searchLength > 0 )
			{
				searchLength = 0 ;
				resourceList.Invalidate () ;
			}
		}
		protected int getItemHeight ()
		{
			return 7 * sizeTestLabel.Height / 5 ;
		}
		protected int textWidthHint ;
		protected int textWidthLeftHint ;
		protected int textWidthRightHint ;
		protected void setTextWidthHint ( Graphics graphics )
		{
			bool myGraphics ;
			if ( graphics == null ) 
			{
				graphics = Graphics.FromHwnd ( Handle ) ;
				myGraphics = true ;
			}
			else myGraphics = false ;
			textWidthHint = TextRenderer.MeasureText ( ( IDeviceContext ) graphics , "||" , resourceList.Font ).Width - TextRenderer.MeasureText ( ( IDeviceContext ) graphics , "|" , resourceList.Font ).Width ;
			textWidthRightHint = textWidthHint << 1 ;
			textWidthLeftHint = textWidthHint + 1 ;
			if ( myGraphics ) graphics.Dispose () ;
		}
		private void resourceList_DrawItem ( object sender , DrawItemEventArgs e )
		{
			if ( e.Index == -1 ) return ; //??????!!!!!!!!!!??? @#@$@!!
			IDeviceContext deviceContext = ( IDeviceContext ) e.Graphics ;
			string s = resourceList.Items [ e.Index ].ToString() ;
			bool notSelected = ( e.State & DrawItemState.Selected ) == 0 ;
			bool searchSelected = !notSelected && ( searchPosition >= 0 ) && ( searchPosition < s.Length ) && ( searchLength > 0 ) && ( searchPosition + searchLength <= s.Length )  ;
			SolidBrush back = notSelected ? ( e.Index & 1 ) == 0 ? normalBackBrush : alternateBackBrush : selectedBackBrush ;
			SolidBrush ink = notSelected ? ( e.Index & 1 ) == 0 ? normalInkBrush : alternateInkBrush : selectedInkBrush ;
			e.Graphics.FillRectangle ( back , e.Bounds ) ;
			//e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias ;
			SizeF fullSize = TextRenderer.MeasureText ( s , resourceList.Font ) ;
			int t = ( e.Bounds.Height - ( int ) fullSize.Height ) >> 1 ;
			if ( searchSelected )
				e.Graphics.FillRectangle ( searchBackBrush , 
					e.Bounds.Left + ( searchPosition > 0 ? 
						( TextRenderer.MeasureText ( deviceContext , s.Substring ( 0 , searchPosition ) , resourceList.Font ).Width - textWidthLeftHint ) : 0 ) , 
					e.Bounds.Top + t , 
					TextRenderer.MeasureText ( deviceContext , s.Substring ( searchPosition , searchLength ) , resourceList.Font ).Width - 
								( searchPosition > 0 ? textWidthRightHint : textWidthLeftHint ) , 
					e.Bounds.Height - ( t << 1 ) ) ;

			TextRenderer.DrawText ( deviceContext , s , resourceList.Font , new Point ( e.Bounds.Left , e.Bounds.Top + t ) , ink.Color , Color.Transparent ) ;
		}

		
		private void resourceList_SelectedIndexChanged ( object sender , EventArgs e )
		{
			searchPosition = -1 ;
			searchLength = 0 ;
			if ( resourceList.Focused && ( resourceList.SelectedIndex != -1 ) )
			{
				noSearch = true ;
				searchBox.Text = resourceList.Items [ resourceList.SelectedIndex ].ToString () ;  
				noSearch = false ;
			}
		}
		private void resourceList_DoubleClick ( object sender, EventArgs e )
        {
			if ( resourceList.SelectedIndex == -1 ) return ;
			Exception ex = null ;
			try
			{
				string resourceName = resourceList.SelectedItem.ToString () ;
				string fileName = resourceName ;
				int i = fileName.LastIndexOf ( '.' ) ;
				if ( i == 0 )
					fileName = fileName.Substring ( 1 ) ;
				else if ( i > 0 )
				{
					i = fileName.LastIndexOf ( '.' , i - 1 ) ;
					if ( i != -1 ) fileName = fileName.Substring ( i + 1 ) ;
				}
				saveFileDialog.FileName = fileName ;
				if ( saveFileDialog.ShowDialog ( this ) == DialogResult.OK )
					saveResource ( resourceName , saveFileDialog.FileName ) ;
			}
			catch ( Exception x )
			{
				ex = x ;
			}
			if ( ex != null ) _UIErrorRaised?.Invoke ( this , new ErrorEventArgs ( ex ) ) ;
        }
		private void resourceList_MouseDown ( object sender , MouseEventArgs e )
		{
			searchPosition = -1 ;
			searchLength = 0 ;
		}
		private void resourceList_MouseUp ( object sender , MouseEventArgs e )
		{
			try
			{ 
				searchBox.Focus () ;
			}
			catch {}
			//removeListTextSelection () ;
		}
		/// <summary>
		/// Search for item in resource list
		/// </summary>
		/// <param name="searchText">Text to find(partialy)</param>
		/// <param name="charIndex">Char index or -1</param>
		/// <param name="matchLength">Length of text portion that match search text</param>
		/// <returns>Resource list item index or -1</returns>
		public bool searchForItem ( string searchText )
		{
			ListBox.ObjectCollection items = resourceList.Items ;
			int c = items.Count ;
			searchPosition= -1 ;
			searchLength = 0 ;
			searchText = searchText.ToLower () ;
			int itemIndex = -1 ;
			int currentLength = 0 ;
			int currentCharIndex = -1 ;
			for ( int i = 0 ; i < c ; i++ )
			{
				currentCharIndex = -1 ;
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString().ToLower() , ref currentCharIndex , ref currentLength , true ) )
					if ( currentLength > searchLength )
					{
						searchPosition = currentCharIndex ;
						searchLength = currentLength ;
						itemIndex = i ;
					}
			}
			if ( itemIndex == -1 )
			{
				searchPosition= -1 ;
				searchLength = 0 ;
				resourceList.Invalidate () ;
				return false ;
			}
			else 
			{
				currentCharIndex = searchPosition ;
				currentLength = searchLength ;
				API.LockWindowUpdate ( resourceList.Handle ) ;
				resourceList.SelectedIndex = itemIndex ;
				searchPosition = currentCharIndex ;
				searchLength = currentLength ;
				API.LockWindowUpdate ( IntPtr.Zero ) ;
				resourceList.Invalidate() ;
				return true ;
			}
		}
		public bool searchForNextItem ( string searchText )
		{
			if ( resourceList.SelectedIndex == -1 ) 
				return searchForItem ( searchText ) ;
			ListBox.ObjectCollection items = resourceList.Items ;
			int c = items.Count ;
			int currentLength = searchLength ;
			int currentCharIndex = searchPosition ;
			int itemIndex = -1 ;
			searchText = searchText.ToLower () ;

			if ( HttpConnectionItem.matchLongestLength ( searchText , items [ resourceList.SelectedIndex ].ToString().ToLower() , ref currentCharIndex , ref currentLength , true ) ) 
			{
				itemIndex = resourceList.SelectedIndex ;
				searchPosition = currentCharIndex ;
				searchLength = currentLength ;
				resourceList.Invalidate () ;
				return true ;
			}
			int i ;
			currentCharIndex = -1 ;
			for ( i = resourceList.SelectedIndex + 1 ; i < c ; i++ )
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString().ToLower() , ref currentCharIndex , ref currentLength , false ) )
				{
					API.LockWindowUpdate ( resourceList.Handle ) ;
					resourceList.SelectedIndex = i ;
					API.LockWindowUpdate ( IntPtr.Zero ) ;
					searchPosition = currentCharIndex ;
					searchLength = currentLength ;
					resourceList.Invalidate () ;
					return true ;
				}
			currentCharIndex = -1 ;
			for ( i = 0 ; i < resourceList.SelectedIndex ; i++ )
				if ( HttpConnectionItem.matchLongestLength ( searchText , items [ i ].ToString().ToLower() , ref currentCharIndex , ref currentLength , false ) )
				{
					API.LockWindowUpdate ( resourceList.Handle ) ;
					resourceList.SelectedIndex = i ;
					API.LockWindowUpdate ( IntPtr.Zero ) ;
					searchPosition = currentCharIndex ;
					searchLength = currentLength ;
					resourceList.Invalidate () ;
					return true ;
				}
			return false ;
		}
		
		/// <summary>
		/// Ah selection direction, it all starts here
		/// </summary>
		/// <param name="sender">searchBox(TextBox)</param>
		/// <param name="e">(MouseEventArgs)</param>
		private void searchBox_MouseDown ( object sender , MouseEventArgs e )
		{
			mouseDownSelectionStart = searchBox.SelectionStart ;
		}
		private void searchBox_MouseUp ( object sender , MouseEventArgs e )
		{
			leftToRightSelection = mouseDownSelectionStart == searchBox.SelectionStart ;
		}
		/// <summary>
		/// Auxiliary variable for the pageCount property
		/// </summary>
		protected int _pageCount ;
		/// <summary>
		/// Set method for the pageCount property
		/// </summary>
		protected void setPageCount ()
		{
			_pageCount = ( resourceList.Height - 4 ) / resourceList.ItemHeight ;
		}
		/// <summary>
		/// Maximal number of fully visible (resource)items in list
		/// </summary>
		public int pageCount 
		{
			get => _pageCount ;
		}
		private void resourceList_Resize ( object sender , EventArgs e )
		{
			setPageCount () ;
		}
		/// <summary>
		/// This resize event handler punches a hole in the mainPanel region so that the resize grip becomes visible
		/// </summary>
		/// <param name="sender">mainPanel(Panel)</param>
		/// <param name="e">(EventArgs)</param>
		private void mainPanel_Resize ( object sender , EventArgs e )
		{
			Region oldRegion = mainPanel.Region ;
			GraphicsPath path = new GraphicsPath () ;
			path.AddRectangle ( new Rectangle ( Point.Empty , mainPanel.Size ) ) ;
			path.AddRectangle ( new Rectangle ( mainPanel.Width - mainPanel.Padding.Right , mainPanel.Height - ( mainPanel.Padding.Top << 1 ) , mainPanel.Padding.Right , mainPanel.Padding.Top << 1 ) ) ;
			path.AddRectangle ( new Rectangle ( mainPanel.Width - ( mainPanel.Padding.Right << 1 ) , mainPanel.Height - mainPanel.Padding.Top , mainPanel.Padding.Right , mainPanel.Padding.Top ) ) ;
			//path.AddRectangle ( new Rectangle ( Width - 120 , Height - 120 , Width , Height ) ) ;
			Region region = new Region ( path ) ;
			mainPanel.Region = region ;
			if ( oldRegion != null ) oldRegion.Dispose () ;
		}
	}
}
