using System ;
using System.Collections.Generic ;
using System.Text ;
using WebSockets ;

namespace SimpleHttp
{
	public class HttpConnectionItem
	{
		public HttpConnectionItem ( HttpConnectionDetails connectionDetails )
		{
			toStringDirty = true ;
			_connectionDetails = connectionDetails ;
		}
		HttpConnectionDetails _connectionDetails ;
		public HttpConnectionDetails connectionDetails 
		{
			get =>_connectionDetails ;
		}
		/// <summary>
		/// When this flag is up ToString method must create new return value and store it into the _ToString variable
		/// </summary>
		protected bool toStringDirty ;
		/// <summary>
		/// Cached return value for the ToString() method
		/// </summary>
		protected string _ToString ;
		/// <summary>
		/// Cached date string for the ToString() method return value
		/// </summary>
		protected string _datePart ;
		/// <summary>
		/// Cached request header string for the ToString() method return value
		/// </summary>
		protected string _requestPart ;
		/// <summary>
		/// Starting character index of request part in ToString() method return value
		/// </summary>
		protected int _requestPartStart ;
		/// <summary>
		/// Position of the first character after the first request line
		/// </summary>
		protected int _requestFirstLineEnd ;
		/// <summary>
		/// Get method for the responseFirstLineEnd property
		/// </summary>
		/// <returns>Position of the first character after the first response line</returns>
		protected int getRequestFirstLineEnd ()
		{
			if ( toStringDirty ) ToString () ;
			return _requestFirstLineEnd ;
		}
		/// <summary>
		/// Position of the first character after the first response line
		/// </summary>
		public int requestFirstLineEnd
		{
			get => getRequestFirstLineEnd () ;
		}
		/// <summary>
		/// Auxiliary variable for the responseFirstLineEnd property
		/// </summary>
		protected int _responseFirstLineEnd ;
		/// <summary>
		/// Get method for the responseFirstLineEnd property
		/// </summary>
		/// <returns>Position of the first character after the first response line</returns>
		protected int getResponseFirstLineEnd ()
		{
			if ( toStringDirty ) ToString () ;
			return _responseFirstLineEnd ;
		}
		/// <summary>
		/// Position of the first character after the first response line
		/// </summary>
		public int responseFirstLineEnd
		{
			get => getResponseFirstLineEnd () ;
		}
		/// <summary>
		/// Cached error string for the ToString() method return value
		/// </summary>
		protected string _errorPart ;
		/// <summary>
		/// Auxiliary variable for the errorPartStart property
		/// </summary>
		protected int _errorPartStart ;
		/// <summary>
		/// Get method for the errorPartStart property
		/// </summary>
		/// <returns>Starting character index of error part in ToString() method return value</returns>
		protected int getErrorPartStart ()
		{
			if ( toStringDirty ) ToString () ;
			return _errorPartStart ;
		}
		/// <summary>
		/// Starting character index of error part in ToString() method return value
		/// </summary>
		public int errorPartStart 
		{
			get => _errorPartStart ;
		}
		/// <summary>
		/// Cached origin string for the ToString() method return value
		/// </summary>
		protected string _originPart ;
		/// <summary>
		/// Auxiliary variable for the originPartStart property
		/// </summary>
		protected int _originPartStart ;
		/// <summary>
		/// Get method for the originPartStart property
		/// </summary>
		/// <returns>Starting character index of origin part in ToString() method return value</returns>
		protected int getOriginPartStart ()
		{
			if ( toStringDirty ) ToString () ;
			return _originPartStart ;
		}
		/// <summary>
		/// Starting character index of origin part in ToString() method return value
		/// </summary>
		public int originPartStart 
		{
			get => _originPartStart ;
		}
		/// <summary>
		/// Cached response header string for the ToString() method return value
		/// </summary>
		protected string _responsePart ;
		/// <summary>
		/// Auxiliary variable for the responsePartStart property
		/// </summary>
		protected int _responsePartStart ;
		/// <summary>
		/// Get method for the responsePartStart property
		/// </summary>
		/// <returns>Starting character index of response part in ToString() method return value</returns>
		protected int getResponsePartStart ()
		{
			if ( toStringDirty ) ToString () ;
			return _responsePartStart ;
		}
		public class FindResult
		{
			public int charIndex 
			{
				get ;
				protected set ;
			}
			public int length
			{
				get ;
				protected set ;
			}
			[Flags]
			public enum PositionFlags
			{
				none = 0 ,
				date = 1 ,
				requestFirstLine = 2 ,
				requestAfterFirstLine = 4 ,
				error = 8 ,
				origin = 16 ,
				responseFirstLine = 32 ,
				responseAfterFirstLine  = 64 
			}
			public PositionFlags position 
			{
				get ;
				protected set ;
			}
			public FindResult ( int charIndex , PositionFlags position ):this ( charIndex , position , -1 , -1 ) 
			{
			}
			public FindResult ( int charIndex , PositionFlags position , int rowIndex , int columnIndex )
			{
				this.charIndex = charIndex ;
				this.position = position ;
				this.rowIndex = rowIndex ;
				this.columnIndex = columnIndex ;
			}
			public static FindResult empty
			{
				get => new FindResult ( -1 , PositionFlags.none ) ;
			}
			public int rowIndex 
			{
				get ;
				protected set ;
			}
			public int columnIndex 
			{
				get ;
				protected set ;
			}
		}
		/// <summary>
		/// Starting character index of response part in ToString() method return value
		/// </summary>
		protected int responsePartStart 
		{
			get => _responsePartStart ;
		}
		public FindResult findString ( string search , int fromCharIndex )
		{
			return getCharIndexResult ( ToString().IndexOf ( search.ToLower() , fromCharIndex , StringComparison.OrdinalIgnoreCase ) ) ;
		}
		public FindResult getCharIndexResult  ( int index )
		{
			if ( toStringDirty ) ToString () ;
			if ( index == -1 ) 
				return FindResult.empty ;
			else if ( index >= _originPartStart )
				if ( index >= _requestPartStart )
					if ( index >= _requestFirstLineEnd )
						if ( index >= _errorPartStart )
							if ( index >= _responsePartStart )
								if ( index >= _responseFirstLineEnd )
									return new FindResult ( index , FindResult.PositionFlags.responseAfterFirstLine ) ;
								else return new FindResult ( index , FindResult.PositionFlags.responseFirstLine ) ;
							else return new FindResult ( index , FindResult.PositionFlags.error ) ;
						else return new FindResult ( index , FindResult.PositionFlags.requestAfterFirstLine ) ;
					else return new FindResult ( index , FindResult.PositionFlags.requestFirstLine  ) ;
				else return new FindResult ( index , FindResult.PositionFlags.origin ) ;
			else return new FindResult ( index , FindResult.PositionFlags.date ) ;
		}
		public override string ToString()
		{
			if ( toStringDirty )
			{
				_datePart = _connectionDetails.created.ToString ( "yyyy-MM-hh dd:HH:ss" ) + "   "  ;
				_responsePart = _connectionDetails.responseHeader.Replace ( "\r\n" , " " ).Trim () ; //!!!! first
				_originPart = ( _connectionDetails.origin == null ? "?" : _connectionDetails.origin.ToString () ) + ( _responsePart == "" ? "" : "  ->  " ) ;
				_originPartStart = _datePart.Length ;
				_requestPart = ( _connectionDetails.request == null ? "!" : _connectionDetails.request.header.Replace ( "\r\n" , " " ) ) + " " ;
				_requestPartStart = _originPartStart + _originPart.Length ; 
				_requestFirstLineEnd = _requestPartStart + ( _connectionDetails.request == null ? 0 : _connectionDetails.request.header.IndexOf ( '\r' ) ) ;
				_errorPart = ( _connectionDetails.error == null ? "" : _connectionDetails.error.InnerException == null ? ( _connectionDetails.error.Message + " " ) : ( _connectionDetails.error.InnerException.Message + " " ) ) ;
				_errorPartStart = _requestPartStart + _requestPart.Length ;
				_responsePartStart = _errorPartStart + _errorPart.Length ; 
				_responseFirstLineEnd = _responsePartStart + _connectionDetails.responseHeader.IndexOf ( '\r' ) ;
				_ToString = _datePart + _originPart + _requestPart + _errorPart + _responsePart ;
				toStringDirty = false ;
			}
			return _ToString ;
		}
		public static int matchCount ( string search , string source , int startingPositon , int minLength , out int charPosition )
		{
			int c = search.Length ;
			charPosition = -1 ;
			for ( int length = minLength ; length <= c ; length++ )
			{
				int currentPosition = source.IndexOf ( search.Substring ( 0 , length ) , startingPositon ) ;
				if ( currentPosition == -1 )
					return length - 1 ;
				else charPosition = currentPosition ;
			}
			return c ;
		}
		/// <summary>
		/// Search for given text sequence in given text starting after given char position.
		/// <br/>If new seach position is found charIndex and length are changed and
		/// <br/>the method returns true, otherwise false and charIndex and length are NOT changed  
		/// </summary>
		/// <param name="search">Text to search for</param>
		/// <param name="source">Text to search in</param>
		/// <param name="charIndex">Previous starting char index(or -1). If longer or equal text sequence is found this parameter returns that position, otherwise it remains unchanged.</param>
		/// <param name="length">Current search length. If longer or equal text sequence is found this parameter returns new length, otherwise it remains unchanged.</param>
		/// <returns>Returns true if new search occurance if found </returns>
		public static bool matchLongestLength ( string search , string source , ref int charIndex , ref int length , bool longerOnly )
		{
			return matchLongestLength ( search , source , ref charIndex , ref length , longerOnly , StringComparison.OrdinalIgnoreCase ) ;
		}
		/// <summary>
		/// Search for given text sequence in given text starting after given char position.
		/// <br/>If new seach position is found charIndex and length are changed and
		/// <br/>the method returns true, otherwise false and charIndex and length are NOT changed  
		/// </summary>
		/// <param name="search">Text to search for</param>
		/// <param name="source">Text to search in</param>
		/// <param name="charIndex">Previous starting char index(or -1). If longer or equal text sequence is found this parameter returns that position, otherwise it remains unchanged.</param>
		/// <param name="length">Current search length. If longer or equal text sequence is found this parameter returns new length, otherwise it remains unchanged.</param>
		/// <param name="comparison">One of the static values in StringComparison class. StringComparison.OrdinalIgnoreCase is default</param>
		/// <returns>Returns true if new search occurance if found </returns>
		public static bool matchLongestLength ( string search , string source , ref int charIndex , ref int length , bool longerOnly , StringComparison comparison )
		{
			int c = search.Length ;
			int startingLength = longerOnly ? ( length + 1 ) : length ;
			int startingPosition = charIndex < 0 ? 0 : ( charIndex + 1 ) ;
			if ( startingPosition > source.Length - length ) return false ;
			int foundLength = 0 ;
			int foundPosition = -1 ;
			if ( comparison == null ) comparison = StringComparison.OrdinalIgnoreCase ;
			for ( int currentLength = startingLength ; currentLength <= c ; currentLength++ )
			{
				int currentPosition = source.IndexOf ( search.Substring ( 0 , currentLength ) , startingPosition , comparison ) ;
				if ( currentPosition == -1 ) break ;
				foundPosition = currentPosition ;
				foundLength = currentLength ;
			}
			if ( ( foundPosition >= 0 ) && ( foundLength > 0 ) )
			{
				charIndex = foundPosition ;
				length = foundLength ;
				return true ;
			}
			return false ;
		}
	}
}
