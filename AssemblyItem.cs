using System ;
using System.Reflection ;

namespace SimpleHttp
{
	/// <summary>
	/// Wrapper around Assembly for ComboBox and ListBox item
	/// </summary>
	public class AssemblyItem
	{
		/// <summary>
		/// Assembly instance
		/// </summary>
		public Assembly assembly { get ; protected set ; }
		/// <summary>
		/// Short assembly name and version("name, version")
		/// </summary>
		public string nameAndVersion { get ; protected set ; }
		/// <summary>
		/// Short assembly name
		/// </summary>
		public string name { get ; protected set ; }
		/// <summary>
		/// Loca case short assembly name
		/// </summary>
		public string lowCaseName { get ; protected set ; }
		/// <summary>
		/// When showBrackets is true string representation of this instance is inside of angular brackets("&lt;name, version&gt;").
		/// <br/>
		/// That is the case when Assembly is directly loaded from filename
		/// </summary>
		public bool showBrackets { get ; protected set ; }
		/// <summary>
		/// Auxiliary variable for the source property
		/// </summary>
		protected string _source ;
		/// <summary>
		/// Get method for the source property
		/// </summary>
		protected string getSource ()
		{
			return _source == null ? assembly.FullName : _source ;
		}
		/// <summary>
		/// Assembly source
		/// </summary>
		public string source 
		{ 
			get => getSource() ;
		}
		/// <summary>
		/// Loads new Assembly instance from given file name and wraps it into new AssemblyItem instance
		/// </summary>	
		/// <param name="assemblyFileName">Full path and name to valid Assembly file</param>
		public AssemblyItem ( string assemblyFileName ) : this ( Assembly.LoadFrom ( assemblyFileName ) , true )
		{
			_source = assemblyFileName ;
		}
		/// <summary>
		/// Creates new instance with given Assembly instance
		/// </summary>
		/// <param name="assembly">Assembly instance to wrap and represent as item</param>
		public AssemblyItem ( Assembly assembly ):this ( assembly , false ) 
		{
		}
		/// <summary>
		/// Creates new instance with given Assembly instance
		/// </summary>
		/// <param name="assembly">Assembly instance to wrap and represent as item</param>
		/// <param name="showBrackets">Set value to showBrackets.
		/// If it is true then ToString method presents name and version inside of angualr brackets</param>
		public AssemblyItem ( Assembly assembly , bool showBrackets )
		{
			_source = null ;
			this.assembly = assembly ;
			name = this.assembly.FullName ;
			nameAndVersion = name ;
			this.showBrackets = showBrackets ;
			int i = name.IndexOf ( ',' ) ;
			if ( i != -1 )
			{
				int j = name.IndexOf ( ',' , i + 1 ) ;
				if ( j != -1 ) nameAndVersion = name.Substring ( 0 , j ) ;
				name = name.Substring ( 0 , i ) ;
			}
			lowCaseName = name.ToLower () ;
		}
		/// <summary>
		/// String representation of this AssemblyItem instance.
		/// </summary>
		/// <returns>Returns "name, version" or "&lt;name, version&gt;"</returns>
		public override string ToString()
		{
			return showBrackets ? ( "<" + nameAndVersion + ">" ) : nameAndVersion ;
		}
		public override bool Equals ( object? obj )
		{
			return Equals ( obj as AssemblyItem ) ;
		}
		public virtual bool Equals ( AssemblyItem? assemblyItem )
		{
			if ( assemblyItem == null ) return false ;
			return assemblyItem.assembly == assembly ;
		}
	}
}
