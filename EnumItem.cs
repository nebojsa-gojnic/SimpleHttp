using System ;

namespace SimpleHttp
{
	public class EnumItem<T> where T : Enum
	{
		public string text { get ; set ; }
		public T value { get ; set ; }
		public override string ToString()
		{
			return text ;
		}
		public EnumItem ( T value ) : this ( value.ToString() , value )
		{
		}
		public EnumItem ( string text , T value )
		{
			this.text = text ;
			this.value = value ;
		}
	}
}
