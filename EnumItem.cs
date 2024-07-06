using System ;

namespace SimpleHttp
{
	/// <summary>
	/// Simple text value item for ListBox/ComboBox list.
	/// </summary>
	/// <typeparam name="T">Type for the value property.</typeparam>
	public class EnumItem<T> where T : Enum
	{
		/// <summary>
		/// Text to represent this instance appereance through ToString() method
		/// </summary>
		public string text { get ; set ; }
		/// <summary>
		/// Real value
		/// </summary>
		public T value { get ; set ; }
		/// <summary>
		/// This method returns value of the text property
		/// </summary>
		/// <returns>value of the text property</returns>
		public override string ToString()
		{
			return text ;
		}
		public EnumItem ( T value ) : this ( value.ToString() , value )
		{
		}
		/// <summary>
		/// Creates new instance of the EnumItem&lt;T&gt; class
		/// </summary>
		/// <param name="text">Text value for ToString() method</param>
		/// <param name="value">Real value</param>
		public EnumItem ( string text , T value )
		{
			this.text = text ;
			this.value = value ;
		}
	}
}
