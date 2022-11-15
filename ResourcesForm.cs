using System ;
using System.Drawing ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Reflection ;
using System.Text ;
using System.Net.Http ;
using System.Windows.Forms ;

namespace SimpleHttp
{
	/// <summary>
	/// Resource viewer
	/// </summary>
	public partial class ResourcesForm : Form
	{
		public ResourcesForm():this ( null )
		{
			InitializeComponent() ;
		}
		public ResourcesForm ( Assembly resourceAssembly )
		{
			InitializeComponent() ;
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
			items.Clear () ;
			if ( resourceAssembly != null ) items.AddRange ( resourceAssembly.GetManifestResourceNames () ) ;
		}
		/// <summary>
		/// Assembly to read resources from
		/// </summary>
		public Assembly resourceAssembly
		{
			get => _resourceAssembly ;
			set => setresourceAssembly ( value ) ;
		}
	}
}
