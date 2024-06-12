using System.Reflection ;
using System.ComponentModel ;
using System.Runtime.InteropServices ;
using System.Text ;
using System.Security.AccessControl ;
using System.Security.Cryptography.X509Certificates ;
using System.Diagnostics ;
using System.Security.Cryptography ;
using System.Security.Authentication ;
using Microsoft.Win32 ;
using System.Text.RegularExpressions ;
using System.DirectoryServices.ActiveDirectory ;
using System.Diagnostics.Eventing.Reader ;
using System.Drawing.Drawing2D ;
using System.ComponentModel.Design;

namespace SimpleHttp
{
	/// <summary>
	/// Simple title bar with single close button.
	/// </summary>
	[DefaultEvent("CloseButtonClick")]
	public class TitleBar:UserControl
	{
		/// <summary>
		/// Close(x) button 
		/// </summary>
		protected Button closeButton ;
		/// <summary>
		/// Auxilairy variable for the BackgroundBrush property
		/// </summary>
		protected Brush _BackgroundBrush ;
		/// <summary>
		/// Auxilairy variable for the ForegroundBrush property
		/// </summary>
		protected Brush _ForegroundBrush ;
		/// <summary>
		/// For painting
		/// </summary>
		protected Rectangle textCliptRectangle ;
		/// <summary>
		/// Creates new instance of TitleBar class
		/// </summary>
		public TitleBar():base()
		{
			SetStyle ( ControlStyles.AllPaintingInWmPaint , true ) ;
			SetStyle ( ControlStyles.UserPaint , true ) ;

			SetStyle ( ControlStyles.Opaque , false ) ;
			SetStyle ( ControlStyles.SupportsTransparentBackColor , true) ;
			closeButton = new Button () ;
			closeButton.Parent = this ;
			closeButton.BackgroundImage = SimpleHttp.Properties.Resources.closeX ;
			closeButton.BackgroundImageLayout = ImageLayout.Zoom ;
			closeButton.BackColor = SystemColors.ButtonFace ;
			closeButton.ForeColor = SystemColors.ControlText ;
			closeButton.UseVisualStyleBackColor = false ;
			closeButton.FlatStyle = FlatStyle.Flat ;
			closeButton.FlatAppearance.BorderSize = 0 ;
			closeButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark ;
			closeButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlLightLight ;
			closeButton.Anchor = AnchorStyles.Right | AnchorStyles.Top ;
			base.BackColor = SystemColors.ControlDarkDark ;
			base.ForeColor = SystemColors.ControlLightLight ;
			_BackgroundBrush = new SolidBrush ( base.BackColor ) ;
			_ForegroundBrush = new SolidBrush ( base.ForeColor ) ;
		}

		protected override void OnPaddingChanged ( EventArgs e )
		{
			setSizeAndLayout () ;
			base.OnPaddingChanged ( e ) ;
		}
		/// <summary>
		/// Background brush, from BackColor 
		/// </summary>
		[Description("Background brush, from BackColor")]
		[Browsable(false)]
		public virtual Brush BackgroundBrush 
		{
			get => _BackgroundBrush ;
		}
		/// <summary>
		/// Foreground brush, from ForeColor 
		/// </summary>
		[Description("Foreground brush, from ForeColor")]
		[Browsable(false)]
		public virtual Brush ForegroundBrush 
		{
			get => _ForegroundBrush ;
		}
		[Browsable(false)]
		public override bool AutoSize 
		{ 
			get => true ; 
			set => base.AutoSize = true ; 
		}
		[Browsable(false)]
		public virtual new AutoSizeMode AutoSizeMode
		{ 
			get => AutoSizeMode.GrowAndShrink ; 
			set => base.AutoSizeMode = AutoSizeMode.GrowAndShrink ; 
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Close button(x) background color when mouse button is over this control")]
		[Browsable(true)]
		[DefaultValue(typeof(Color),"ControlLightLight")]
		public virtual Color CloseButtonMouseOverColor 
		{
			get => closeButton.FlatAppearance.MouseOverBackColor ;
			set => closeButton.FlatAppearance.MouseOverBackColor= value ;
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Close button(x) background color when mouse button is pressed")]
		[Browsable(true)]
		[DefaultValue(typeof(Color),"ControlDark")]
		public virtual Color CloseButtonMouseDownColor 
		{
			get => closeButton.FlatAppearance.MouseDownBackColor ;
			set => closeButton.FlatAppearance.MouseDownBackColor= value ;
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Close button(x) background color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color),"ButtonFace")]
		public virtual Color CloseButtonBackColor 
		{
			get => closeButton.BackColor ;
			set => closeButton.BackColor = value ;
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Close button(x) image")]
		public virtual Image CloseButtonImage
		{
			get => closeButton.BackgroundImage ;
			set => closeButton.BackgroundImage = value ;
		}
		/// <summary>
		/// When user click on close button
		/// </summary>
		[Description("When user click on close button")]
		[Browsable(true)]
		public event EventHandler CloseButtonClick
		{
			add => closeButton.Click += value ;
			remove => closeButton.Click -= value ;
		}
		/// <summary>
		/// When user double-click on close button
		/// </summary>
		[Description("When user double-click on close button")]
		[Browsable(true)]
		public event EventHandler CloseButtonDoubleClick
		{
			add => closeButton.DoubleClick += value ;
			remove => closeButton.DoubleClick-= value ;
		}
		/// <summary>
		/// When user put mouse down on close button
		/// </summary>
		[Description("When user put mouse down on close button")]
		[Browsable(true)]
		public event MouseEventHandler CloseButtonMouseDown
		{
			add => closeButton.MouseDown += value ;
			remove => closeButton.MouseDown -= value ;
		}
		/// <summary>
		/// When user relase mouse button on close button
		/// </summary>
		[Description("When user relase mouse button on close button")]
		[Browsable(true)]
		public event MouseEventHandler CloseButtonMouseUp
		{
			add => closeButton.MouseUp += value ;
			remove => closeButton.MouseUp -= value ;
		}
		/// <summary>
		/// Set method for the Text property
		/// </summary>
		/// <param name="value">New value for the Text property</param>
		protected void SetText ( string value )
		{
			Invalidate ( textCliptRectangle ) ;
			base.Text = value ; 
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Text ...")]
		[Browsable(true)]
		public override string Text 
		{ 
			get => base.Text ; 
			set => SetText ( value ) ;
		}
		/// <summary>
		/// Set method for the BackColor property
		/// </summary>
		/// <param name="value">New value for the BackColor property</param>
		protected virtual void SetBackColor ( Color value )
		{
			base.BackColor = value ; 
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Background color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color),"ControlDarkDark")]
		public override Color BackColor 
		{ 
			get => base.BackColor ; 
			set => SetBackColor ( value ) ; 
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Foreground color")]
		[Browsable(true)]
		[DefaultValue(typeof(Color),"ControlLightLight")]
		public override Color ForeColor 
		{ 
			get => base.ForeColor ; 
			set => base.ForeColor = value ; 
		}
		protected void setSizeAndLayout ()
		{			
			int fullSize = Font.Height ;
			int halfSize = fullSize >> 1 ;
			int quarterSize = fullSize >> 2 ;
			closeButton.Bounds = new Rectangle ( Width -  fullSize - quarterSize - Padding.Right , Padding.Top + quarterSize , fullSize , fullSize ) ;
			
			textCliptRectangle = new Rectangle ( Padding.Left + quarterSize , Padding.Top + quarterSize , Width - fullSize - halfSize - quarterSize - Padding.Horizontal , fullSize ) ;
			//title size
			fullSize += halfSize + Padding.Vertical ;
			MinimumSize = new Size ( 0 , fullSize ) ;
			MaximumSize = new Size ( int.MaxValue , fullSize ) ;
			Size = new Size ( Width , fullSize ) ;
		}
		protected override void OnFontChanged ( EventArgs e )
		{
			setSizeAndLayout () ;
			base.OnFontChanged ( e ) ;
		}
		protected override void OnResize ( EventArgs e )
		{
			setSizeAndLayout () ;
			base.OnResize(e) ;
		}
		protected override void OnLayout ( LayoutEventArgs e )
		{
			setSizeAndLayout () ;
			base.OnLayout ( e ) ;
		}
		/// <summary>
		/// This method fills background with background color, then it calls base.OnPaintBackground<br/>
		/// base.OnPaintBackground method raises PaintBackground  event.
		/// </summary>
		/// <param name="e">*PaintEventArgs)</param>
		protected override void OnPaintBackground ( PaintEventArgs e )
		{
			e.Graphics.FillRectangle ( _BackgroundBrush , new Rectangle ( Point.Empty , Size ) ) ;
			base.OnPaintBackground ( e ) ;
		}
		protected virtual void paintText ( Graphics graphics )
		{
			graphics.SetClip ( textCliptRectangle ) ;
			graphics.DrawString ( Text , Font , _ForegroundBrush , new Rectangle ( textCliptRectangle.Location , new Size ( 65535 , textCliptRectangle.Height ) ) ) ;
		}
		/// <summary>
		/// This method calls paintText() method than base.OnPaint(),<br/>
		/// base.OnPaint method raises Paint event.
		/// </summary>
		/// <param name="e">*PaintEventArgs)</param>
		protected override void OnPaint ( PaintEventArgs e )
		{
			paintText ( e.Graphics ) ;
			base.OnPaint ( e ) ;
		}
		
		static readonly IntPtr HTCAPTION = new IntPtr ( 2 ) ;  
		protected bool MyAutoDragForm = true ;
		[ Browsable ( true ) ]
		[ DefaultValue ( true ) ] 
		public bool AutoDragForm 
		{
			get { return MyAutoDragForm ; }
			set { MyAutoDragForm = value ; } 
		}
		[DebuggerStepThroughAttribute]
		protected override void WndProc ( ref Message m )
		{	
			if ( MyAutoDragForm && !DesignMode )
				if ( m.Msg == WindowMessage.WM_LButtonDown ) 
				{ 
					API.SendMessageA ( TopLevelControl.Handle , WindowMessage.WM_NCLButtonDown , HTCAPTION , m.LParam ) ; 
					return ;
				}	
			base.WndProc ( ref m ) ;
		}
		//[Description("Close button(x) foreground color")]
		//[Browsable(true)]
		//public virtual Color CloseButtonForeColor 
		//{
		//	get => closeButton.ForeColor ;
		//	set => closeButton.ForeColor = value ;
		//}
	}
}
