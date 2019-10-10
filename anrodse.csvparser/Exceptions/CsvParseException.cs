using System;

namespace Anrodse.CsvParser.Exceptions
{
	/// <summary>
	/// Class for csv parser exceptions, adds row and col to the exception message
	/// </summary>
	public class CsvParseException : Exception
	{
		#region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CsvParseException() : base() { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="message">Exception message</param>
		public CsvParseException(string message) : base(message) { }

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Exception inner exception</param>
		public CsvParseException(string message, Exception innerException) : base(message, innerException) { }

		#endregion Constructor

		#region Propiedades

		/// <summary>
		/// Row that causes the exception 
		/// </summary>
		public int Row { get; set; }

		/// <summary>
		/// Column that causes the exception 
		/// </summary>
		public string Col { get; set; }

		#endregion Propiedades

	}
}
