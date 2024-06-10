using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using SourceGenerated;

namespace System.Windows.Forms;

/// <summary>Represents a Windows text box control.</summary>
[Designer("System.Windows.Forms.Design.TextBoxDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[SRDescription("DescriptionTextBox")]
public class TextBox : TextBoxBase
{
	private static readonly object EVENT_TEXTALIGNCHANGED = new object();

	private bool acceptsReturn;

	private char passwordChar;

	private bool useSystemPasswordChar;

	private CharacterCasing characterCasing;

	private ScrollBars scrollBars;

	private HorizontalAlignment textAlign;

	private bool selectionSet;

	private AutoCompleteMode autoCompleteMode;

	private AutoCompleteSource autoCompleteSource = AutoCompleteSource.None;

	private AutoCompleteStringCollection autoCompleteCustomSource;

	private bool fromHandleCreate;

	private StringSource stringSource;

	private string placeholderText = string.Empty;

	/// <summary>Gets or sets a value indicating whether pressing ENTER in a multiline <see cref="T:System.Windows.Forms.TextBox" /> control creates a new line of text in the control or activates the default button for the form.</summary>
	/// <returns>
	///   <see langword="true" /> if the ENTER key creates a new line of text in a multiline version of the control; <see langword="false" /> if the ENTER key activates the default button for the form. The default is <see langword="false" />.</returns>
	[SRCategory("CatBehavior")]
	[DefaultValue(false)]
	[SRDescription("TextBoxAcceptsReturnDescr")]
	public bool AcceptsReturn
	{
		get
		{
			return acceptsReturn;
		}
		set
		{
			acceptsReturn = value;
		}
	}

	/// <summary>Gets or sets an option that controls how automatic completion works for the <see cref="T:System.Windows.Forms.TextBox" />.</summary>
	/// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteMode" />. The following are the values.  
	///  <see cref="F:System.Windows.Forms.AutoCompleteMode.Append" /> Appends the remainder of the most likely candidate string to the existing characters, highlighting the appended characters.  
	///  <see cref="F:System.Windows.Forms.AutoCompleteMode.Suggest" /> Displays the auxiliary drop-down list associated with the edit control. This drop-down is populated with one or more suggested completion strings.  
	///  <see cref="F:System.Windows.Forms.AutoCompleteMode.SuggestAppend" /> Appends both <see langword="Suggest" /> and <see langword="Append" /> options.  
	///  <see cref="F:System.Windows.Forms.AutoCompleteMode.None" /> Disables automatic completion. This is the default.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteMode" />.</exception>
	[DefaultValue(AutoCompleteMode.None)]
	[SRDescription("TextBoxAutoCompleteModeDescr")]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return autoCompleteMode;
		}
		set
		{
			EnumValidator.Validate(value);
			bool autoComplete = false;
			if (autoCompleteMode != 0 && value == AutoCompleteMode.None)
			{
				autoComplete = true;
			}
			autoCompleteMode = value;
			SetAutoComplete(autoComplete);
		}
	}

	/// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
	/// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource" />. The options are <see langword="AllSystemSources" />, <see langword="AllUrl" />, <see langword="FileSystem" />, <see langword="HistoryList" />, <see langword="RecentlyUsedList" />, <see langword="CustomSource" />, and <see langword="None" />. The default is <see langword="None" />.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource" />.</exception>
	[DefaultValue(AutoCompleteSource.None)]
	[SRDescription("TextBoxAutoCompleteSourceDescr")]
	[TypeConverter(typeof(TextBoxAutoCompleteSourceConverter))]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			return autoCompleteSource;
		}
		set
		{
			switch (value)
			{
			case AutoCompleteSource.FileSystem:
			case AutoCompleteSource.HistoryList:
			case AutoCompleteSource.RecentlyUsedList:
			case AutoCompleteSource.AllUrl:
			case AutoCompleteSource.AllSystemSources:
			case AutoCompleteSource.FileSystemDirectories:
			case AutoCompleteSource.CustomSource:
			case AutoCompleteSource.None:
				autoCompleteSource = value;
				SetAutoComplete(reset: false);
				break;
			case AutoCompleteSource.ListItems:
				throw new NotSupportedException(System.SR.TextBoxAutoCompleteSourceNoItems);
			default:
				throw new InvalidEnumArgumentException("value", (int)value, typeof(AutoCompleteSource));
			}
		}
	}

	/// <summary>Gets or sets a custom <see cref="T:System.Collections.Specialized.StringCollection" /> to use when the <see cref="P:System.Windows.Forms.TextBox.AutoCompleteSource" /> property is set to <see langword="CustomSource" />.</summary>
	/// <returns>A <see cref="T:System.Collections.Specialized.StringCollection" /> to use with <see cref="P:System.Windows.Forms.TextBox.AutoCompleteSource" />.</returns>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	[SRDescription("TextBoxAutoCompleteCustomSourceDescr")]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public AutoCompleteStringCollection AutoCompleteCustomSource
	{
		get
		{
			if (autoCompleteCustomSource == null)
			{
				autoCompleteCustomSource = new AutoCompleteStringCollection();
				autoCompleteCustomSource.CollectionChanged += OnAutoCompleteCustomSourceChanged;
			}
			return autoCompleteCustomSource;
		}
		set
		{
			if (autoCompleteCustomSource != value)
			{
				if (autoCompleteCustomSource != null)
				{
					autoCompleteCustomSource.CollectionChanged -= OnAutoCompleteCustomSourceChanged;
				}
				autoCompleteCustomSource = value;
				if (value != null)
				{
					autoCompleteCustomSource.CollectionChanged += OnAutoCompleteCustomSourceChanged;
				}
				SetAutoComplete(reset: false);
			}
		}
	}

	/// <summary>Gets or sets whether the <see cref="T:System.Windows.Forms.TextBox" /> control modifies the case of characters as they are typed.</summary>
	/// <returns>One of the <see cref="T:System.Windows.Forms.CharacterCasing" /> enumeration values that specifies whether the <see cref="T:System.Windows.Forms.TextBox" /> control modifies the case of characters. The default is <see langword="CharacterCasing.Normal" />.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property.</exception>
	[SRCategory("CatBehavior")]
	[DefaultValue(CharacterCasing.Normal)]
	[SRDescription("TextBoxCharacterCasingDescr")]
	public CharacterCasing CharacterCasing
	{
		get
		{
			return characterCasing;
		}
		set
		{
			if (characterCasing != value)
			{
				EnumValidator.Validate(value);
				characterCasing = value;
				RecreateHandle();
			}
		}
	}

	/// <summary>Gets or sets a value indicating whether this is a multiline <see cref="T:System.Windows.Forms.TextBox" /> control.</summary>
	/// <returns>
	///   <see langword="true" /> if the control is a multiline <see cref="T:System.Windows.Forms.TextBox" /> control; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
	public override bool Multiline
	{
		get
		{
			return base.Multiline;
		}
		set
		{
			if (Multiline != value)
			{
				base.Multiline = value;
				if (value && AutoCompleteMode != 0)
				{
					RecreateHandle();
				}
			}
		}
	}

	private protected override bool PasswordProtect => PasswordChar != '\0';

	/// <summary>Gets the required creation parameters when the control handle is created.</summary>
	/// <returns>A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation parameters when the handle to the control is created.</returns>
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			switch (characterCasing)
			{
			case CharacterCasing.Lower:
				createParams.Style |= 16;
				break;
			case CharacterCasing.Upper:
				createParams.Style |= 8;
				break;
			}
			HorizontalAlignment horizontalAlignment = RtlTranslateHorizontal(textAlign);
			createParams.ExStyle &= -4097;
			switch (horizontalAlignment)
			{
			case HorizontalAlignment.Left:
				createParams.Style |= 0;
				break;
			case HorizontalAlignment.Center:
				createParams.Style |= 1;
				break;
			case HorizontalAlignment.Right:
				createParams.Style |= 2;
				break;
			}
			if (Multiline)
			{
				if ((scrollBars & ScrollBars.Horizontal) == ScrollBars.Horizontal && textAlign == HorizontalAlignment.Left && !base.WordWrap)
				{
					createParams.Style |= 1048576;
				}
				if ((scrollBars & ScrollBars.Vertical) == ScrollBars.Vertical)
				{
					createParams.Style |= 2097152;
				}
			}
			if (useSystemPasswordChar)
			{
				createParams.Style |= 32;
			}
			return createParams;
		}
	}

	/// <summary>Gets or sets the character used to mask characters of a password in a single-line <see cref="T:System.Windows.Forms.TextBox" /> control.</summary>
	/// <returns>The character used to mask characters entered in a single-line <see cref="T:System.Windows.Forms.TextBox" /> control. Set the value of this property to 0 (character value) if you do not want the control to mask characters as they are typed. Equals 0 (character value) by default.</returns>
	[SRCategory("CatBehavior")]
	[DefaultValue('\0')]
	[Localizable(true)]
	[SRDescription("TextBoxPasswordCharDescr")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public char PasswordChar
	{
		get
		{
			if (!base.IsHandleCreated)
			{
				CreateHandle();
			}
			return (char)(int)global::Interop.User32.SendMessageW(this, (global::Interop.User32.WM)210u, (IntPtr)0, (IntPtr)0);
		}
		set
		{
			passwordChar = value;
			if (!useSystemPasswordChar && base.IsHandleCreated && PasswordChar != value)
			{
				global::Interop.User32.SendMessageW(this, (global::Interop.User32.WM)204u, (IntPtr)value, (IntPtr)0);
				VerifyImeRestrictedModeChanged();
				ResetAutoComplete(force: false);
				Invalidate();
			}
		}
	}

	/// <summary>Gets or sets which scroll bars should appear in a multiline <see cref="T:System.Windows.Forms.TextBox" /> control.</summary>
	/// <returns>One of the <see cref="T:System.Windows.Forms.ScrollBars" /> enumeration values that indicates whether a multiline <see cref="T:System.Windows.Forms.TextBox" /> control appears with no scroll bars, a horizontal scroll bar, a vertical scroll bar, or both. The default is <see langword="ScrollBars.None" />.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property.</exception>
	[SRCategory("CatAppearance")]
	[Localizable(true)]
	[DefaultValue(ScrollBars.None)]
	[SRDescription("TextBoxScrollBarsDescr")]
	public ScrollBars ScrollBars
	{
		get
		{
			return scrollBars;
		}
		set
		{
			if (scrollBars != value)
			{
				EnumValidator.Validate(value);
				scrollBars = value;
				RecreateHandle();
			}
		}
	}

	/// <summary>Gets or sets the text associated with this control.</summary>
	/// <returns>The text associated with this control.</returns>
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			selectionSet = false;
		}
	}

	/// <summary>Gets or sets how text is aligned in a <see cref="T:System.Windows.Forms.TextBox" /> control.</summary>
	/// <returns>One of the <see cref="T:System.Windows.Forms.HorizontalAlignment" /> enumeration values that specifies how text is aligned in the control. The default is <see langword="HorizontalAlignment.Left" />.</returns>
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property.</exception>
	[Localizable(true)]
	[SRCategory("CatAppearance")]
	[DefaultValue(HorizontalAlignment.Left)]
	[SRDescription("TextBoxTextAlignDescr")]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return textAlign;
		}
		set
		{
			if (textAlign != value)
			{
				EnumValidator.Validate(value);
				textAlign = value;
				RecreateHandle();
				OnTextAlignChanged(EventArgs.Empty);
			}
		}
	}

	/// <summary>Gets or sets a value indicating whether the text in the <see cref="T:System.Windows.Forms.TextBox" /> control should appear as the default password character.</summary>
	/// <returns>
	///   <see langword="true" /> if the text in the <see cref="T:System.Windows.Forms.TextBox" /> control should appear as the default password character; otherwise, <see langword="false" />.</returns>
	[SRCategory("CatBehavior")]
	[DefaultValue(false)]
	[SRDescription("TextBoxUseSystemPasswordCharDescr")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public bool UseSystemPasswordChar
	{
		get
		{
			return useSystemPasswordChar;
		}
		set
		{
			if (value != useSystemPasswordChar)
			{
				useSystemPasswordChar = value;
				RecreateHandle();
				if (value)
				{
					ResetAutoComplete(force: false);
				}
			}
		}
	}

	[Localizable(true)]
	[DefaultValue("")]
	[SRDescription("TextBoxPlaceholderTextDescr")]
	public virtual string PlaceholderText
	{
		get
		{
			return placeholderText;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (placeholderText != value)
			{
				placeholderText = value;
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}
	}

	/// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.TextBox.TextAlign" /> property has changed.</summary>
	[SRCategory("CatPropertyChanged")]
	[SRDescription("RadioButtonOnTextAlignChangedDescr")]
	public event EventHandler TextAlignChanged
	{
		add
		{
			base.Events.AddHandler(EVENT_TEXTALIGNCHANGED, value);
		}
		remove
		{
			base.Events.RemoveHandler(EVENT_TEXTALIGNCHANGED, value);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.TextBox" /> class.</summary>
	public TextBox()
	{
	}

	internal override Size GetPreferredSizeCore(Size proposedConstraints)
	{
		Size empty = Size.Empty;
		if (Multiline && !base.WordWrap && (ScrollBars & ScrollBars.Horizontal) != 0)
		{
			empty.Height += SystemInformation.GetHorizontalScrollBarHeightForDpi(_deviceDpi);
		}
		if (Multiline && (ScrollBars & ScrollBars.Vertical) != 0)
		{
			empty.Width += SystemInformation.GetVerticalScrollBarWidthForDpi(_deviceDpi);
		}
		proposedConstraints -= empty;
		return base.GetPreferredSizeCore(proposedConstraints) + empty;
	}

	/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.TextBox" /> and optionally releases the managed resources.</summary>
	/// <param name="disposing">
	///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ResetAutoComplete(force: true);
			if (autoCompleteCustomSource != null)
			{
				autoCompleteCustomSource.CollectionChanged -= OnAutoCompleteCustomSourceChanged;
			}
			if (stringSource != null)
			{
				stringSource.ReleaseAutoComplete();
				stringSource = null;
			}
		}
		base.Dispose(disposing);
	}

	/// <summary>Determines whether the specified key is an input key or a special key that requires preprocessing.</summary>
	/// <param name="keyData">One of the key's values.</param>
	/// <returns>
	///   <see langword="true" /> if the specified key is an input key; otherwise, <see langword="false" />.</returns>
	protected override bool IsInputKey(Keys keyData)
	{
		if (Multiline && (keyData & Keys.Alt) == 0 && (keyData & Keys.KeyCode) == Keys.Return)
		{
			return acceptsReturn;
		}
		return base.IsInputKey(keyData);
	}

	private void OnAutoCompleteCustomSourceChanged(object sender, CollectionChangeEventArgs e)
	{
		if (AutoCompleteSource == AutoCompleteSource.CustomSource)
		{
			SetAutoComplete(reset: true);
		}
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected unsafe override void OnBackColorChanged(EventArgs e)
	{
		base.OnBackColorChanged(e);
		if (Application.RenderWithVisualStyles && base.IsHandleCreated && base.BorderStyle == BorderStyle.Fixed3D)
		{
			global::Interop.User32.RedrawWindow(new HandleRef(this, base.Handle), null, IntPtr.Zero, global::Interop.User32.RDW.INVALIDATE | global::Interop.User32.RDW.FRAME);
		}
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		if (AutoCompleteMode != 0)
		{
			RecreateHandle();
		}
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		if (!selectionSet)
		{
			selectionSet = true;
			if (SelectionLength == 0 && Control.MouseButtons == MouseButtons.None)
			{
				SelectAll();
			}
		}
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.</summary>
	/// <param name="e">The event data.</param>
	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		if (!base.IsHandleCreated)
		{
			return;
		}
		SetSelectionOnHandle();
		if (passwordChar != 0 && !useSystemPasswordChar)
		{
			global::Interop.User32.SendMessageW(this, (global::Interop.User32.WM)204u, (IntPtr)passwordChar, (IntPtr)0);
		}
		VerifyImeRestrictedModeChanged();
		if (AutoCompleteMode == AutoCompleteMode.None)
		{
			return;
		}
		try
		{
			fromHandleCreate = true;
			SetAutoComplete(reset: false);
		}
		finally
		{
			fromHandleCreate = false;
		}
	}

	/// <summary>Raises the <see cref="M:System.Windows.Forms.Control.OnHandleDestroyed(System.EventArgs)" /> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected override void OnHandleDestroyed(EventArgs e)
	{
		if (stringSource != null)
		{
			stringSource.ReleaseAutoComplete();
			stringSource = null;
		}
		base.OnHandleDestroyed(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (base.IsHandleCreated && ContainsNavigationKeyCode(e.KeyCode))
		{
			base.AccessibilityObject?.RaiseAutomationEvent(global::Interop.UiaCore.UIA.Text_TextSelectionChangedEventId);
		}
	}

	private bool ContainsNavigationKeyCode(Keys keyCode)
	{
		if ((uint)(keyCode - 33) <= 7u)
		{
			return true;
		}
		return false;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (base.IsHandleCreated)
		{
			base.AccessibilityObject?.RaiseAutomationEvent(global::Interop.UiaCore.UIA.Text_TextSelectionChangedEventId);
		}
	}

	/// <summary>Raises the <see cref="E:System.Windows.Forms.TextBox.TextAlignChanged" /> event.</summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected virtual void OnTextAlignChanged(EventArgs e)
	{
		if (base.Events[EVENT_TEXTALIGNCHANGED] is EventHandler eventHandler)
		{
			eventHandler(this, e);
		}
	}

	/// <summary>Processes a command key.</summary>
	/// <param name="m">A <see cref="T:System.Windows.Forms.Message" />, passed by reference that represents the window message to process.</param>
	/// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the shortcut key to process.</param>
	/// <returns>
	///   <see langword="true" /> if the command key was processed by the control; otherwise, <see langword="false" />.</returns>
	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		bool flag = base.ProcessCmdKey(ref m, keyData);
		if (!flag && Multiline && ShortcutsEnabled && keyData == (Keys.A | Keys.Control))
		{
			SelectAll();
			return true;
		}
		return flag;
	}

	/// <summary>Sets the selected text to the specified text without clearing the undo buffer.</summary>
	/// <param name="text">The text to replace.</param>
	public void Paste(string text)
	{
		base.SetSelectedTextInternal(text, clearUndo: false);
	}

	private protected override void SelectInternal(int start, int length, int textLen)
	{
		selectionSet = true;
		base.SelectInternal(start, length, textLen);
	}

	private string[] GetStringsForAutoComplete()
	{
		string[] array = new string[AutoCompleteCustomSource.Count];
		for (int i = 0; i < AutoCompleteCustomSource.Count; i++)
		{
			array[i] = AutoCompleteCustomSource[i];
		}
		return array;
	}

	private void SetAutoComplete(bool reset)
	{
		if (Multiline || passwordChar != 0 || useSystemPasswordChar || AutoCompleteSource == AutoCompleteSource.None)
		{
			return;
		}
		if (AutoCompleteMode != 0)
		{
			if (!fromHandleCreate)
			{
				AutoCompleteMode autoCompleteMode = AutoCompleteMode;
				this.autoCompleteMode = AutoCompleteMode.None;
				RecreateHandle();
				this.autoCompleteMode = autoCompleteMode;
			}
			if (AutoCompleteSource == AutoCompleteSource.CustomSource)
			{
				if (!base.IsHandleCreated || AutoCompleteCustomSource == null)
				{
					return;
				}
				if (AutoCompleteCustomSource.Count == 0)
				{
					ResetAutoComplete(force: true);
				}
				else if (stringSource == null)
				{
					stringSource = new StringSource(GetStringsForAutoComplete());
					if (!stringSource.Bind(new HandleRef(this, base.Handle), (global::Interop.Shell32.AUTOCOMPLETEOPTIONS)AutoCompleteMode))
					{
						throw new ArgumentException(System.SR.AutoCompleteFailure);
					}
				}
				else
				{
					stringSource.RefreshList(GetStringsForAutoComplete());
				}
			}
			else if (base.IsHandleCreated)
			{
				global::Interop.Shlwapi.SHACF sHACF = global::Interop.Shlwapi.SHACF.DEFAULT;
				if (AutoCompleteMode == AutoCompleteMode.Suggest)
				{
					sHACF |= global::Interop.Shlwapi.SHACF.AUTOSUGGEST_FORCE_ON | global::Interop.Shlwapi.SHACF.AUTOAPPEND_FORCE_OFF;
				}
				if (AutoCompleteMode == AutoCompleteMode.Append)
				{
					sHACF |= global::Interop.Shlwapi.SHACF.AUTOSUGGEST_FORCE_OFF | global::Interop.Shlwapi.SHACF.AUTOAPPEND_FORCE_ON;
				}
				if (AutoCompleteMode == AutoCompleteMode.SuggestAppend)
				{
					sHACF |= global::Interop.Shlwapi.SHACF.AUTOSUGGEST_FORCE_ON;
					sHACF |= global::Interop.Shlwapi.SHACF.AUTOAPPEND_FORCE_ON;
				}
				global::Interop.Shlwapi.SHAutoComplete(this, (global::Interop.Shlwapi.SHACF)((uint)AutoCompleteSource | (uint)sHACF));
			}
		}
		else if (reset)
		{
			ResetAutoComplete(force: true);
		}
	}

	private void ResetAutoComplete(bool force)
	{
		if ((AutoCompleteMode != AutoCompleteMode.None || force) && base.IsHandleCreated)
		{
			global::Interop.Shlwapi.SHAutoComplete(this, global::Interop.Shlwapi.SHACF.URLALL | global::Interop.Shlwapi.SHACF.FILESYSTEM | global::Interop.Shlwapi.SHACF.AUTOSUGGEST_FORCE_OFF | global::Interop.Shlwapi.SHACF.AUTOAPPEND_FORCE_OFF);
		}
	}

	private void ResetAutoCompleteCustomSource()
	{
		AutoCompleteCustomSource = null;
	}

	private void WmPrint(ref Message m)
	{
		base.WndProc(ref m);
		if (((int)m.LParam & 2) == 0 || !Application.RenderWithVisualStyles || base.BorderStyle != BorderStyle.Fixed3D)
		{
			return;
		}
		using Graphics graphics = Graphics.FromHdc(m.WParam);
		Rectangle rect = new Rectangle(0, 0, base.Size.Width - 1, base.Size.Height - 1);
		RefCountedCache<Pen, Color, Color>.Scope scope = VisualStyleInformation.TextControlBorder.GetCachedPenScope();
		try
		{
			graphics.DrawRectangle(scope, rect);
			rect.Inflate(-1, -1);
			graphics.DrawRectangle(SystemPens.Window, rect);
		}
		finally
		{
			scope.Dispose();
		}
	}

	private void DrawPlaceholderText(global::Interop.Gdi32.HDC hdc)
	{
		TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding;
		Rectangle clientRectangle = base.ClientRectangle;
		if (RightToLeft == RightToLeft.Yes)
		{
			textFormatFlags |= TextFormatFlags.RightToLeft;
			switch (TextAlign)
			{
			case HorizontalAlignment.Center:
				textFormatFlags |= TextFormatFlags.HorizontalCenter;
				clientRectangle.Offset(0, 1);
				break;
			case HorizontalAlignment.Left:
				textFormatFlags |= TextFormatFlags.Right;
				clientRectangle.Offset(1, 1);
				break;
			case HorizontalAlignment.Right:
				textFormatFlags |= TextFormatFlags.Default;
				clientRectangle.Offset(0, 1);
				break;
			}
		}
		else
		{
			textFormatFlags &= ~TextFormatFlags.RightToLeft;
			switch (TextAlign)
			{
			case HorizontalAlignment.Center:
				textFormatFlags |= TextFormatFlags.HorizontalCenter;
				clientRectangle.Offset(0, 1);
				break;
			case HorizontalAlignment.Left:
				textFormatFlags |= TextFormatFlags.Default;
				clientRectangle.Offset(1, 1);
				break;
			case HorizontalAlignment.Right:
				textFormatFlags |= TextFormatFlags.Right;
				clientRectangle.Offset(0, 1);
				break;
			}
		}
		TextRenderer.DrawTextInternal(hdc, PlaceholderText, Font, clientRectangle, SystemColors.GrayText, TextRenderer.DefaultQuality, textFormatFlags);
	}

	/// <summary>Processes Windows messages.</summary>
	/// <param name="m">A Windows Message object.</param>
	protected unsafe override void WndProc(ref Message m)
	{
		switch ((global::Interop.User32.WM)m.Msg)
		{
		case global::Interop.User32.WM.LBUTTONDOWN:
		{
			MouseButtons mouseButtons = Control.MouseButtons;
			bool validationCancelled = base.ValidationCancelled;
			Focus();
			if (mouseButtons == Control.MouseButtons && (!base.ValidationCancelled || validationCancelled))
			{
				base.WndProc(ref m);
			}
			break;
		}
		case global::Interop.User32.WM.PAINT:
			if (ShouldRenderPlaceHolderText())
			{
				global::Interop.User32.InvalidateRect(base.Handle, null, global::Interop.BOOL.TRUE);
			}
			base.WndProc(ref m);
			if (ShouldRenderPlaceHolderText())
			{
				global::Interop.User32.InvalidateRect(base.Handle, null, global::Interop.BOOL.TRUE);
				global::Interop.User32.BeginPaintScope paintScope = new global::Interop.User32.BeginPaintScope(base.Handle);
				try
				{
					DrawPlaceholderText(paintScope);
					global::Interop.User32.ValidateRect(this, null);
					break;
				}
				finally
				{
					paintScope.Dispose();
				}
			}
			break;
		case global::Interop.User32.WM.PRINT:
			WmPrint(ref m);
			break;
		default:
			base.WndProc(ref m);
			break;
		}
	}

	private bool ShouldRenderPlaceHolderText()
	{
		if (!string.IsNullOrEmpty(PlaceholderText) && !GetStyle(ControlStyles.UserPaint) && !Focused)
		{
			return TextLength == 0;
		}
		return false;
	}
}
