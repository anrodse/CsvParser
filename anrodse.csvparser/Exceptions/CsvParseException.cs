using System;

namespace Anrodse.CsvParser.Exceptions
{
	/// <summary>
	/// Class for csv parser exceptions, adds row and col to the exception message
	/// </summary>
	public class CsvParseException : Exception
	{
		#region Constructor

		public CsvParseException() : base() { }
		public CsvParseException(string message) : base(message) { }

		public CsvParseException(string message, Exception innerException) : base(message, innerException) { }

		#endregion Constructor

		#region Propiedades

		public int Row { get; set; }

		public string Col { get; set; }

		#endregion Propiedades

	}
}
